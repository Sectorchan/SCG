using System;
using System.IO;
using System.Diagnostics;
using System.Linq;
using System.Xml;
using System.Runtime.ConstrainedExecution;
using System.Security.Claims;
using System.Windows.Forms;
using System.Reflection;
using static System.Windows.Forms.LinkLabel;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {

        string SSLargument = "";
        string openSSL_bin = "openssl2.exe";
        string openSSLcnf_ca = "openssl-ca.cnf";
        string openSSLcnf_inter = "openssl-inter.cnf";
  


        /// <summary>
        /// Will be passed to the OpenSSL binary
        /// </summary>
        /// <param name="SSLargument1"></param>
        /// <returns></returns>
        private string debugoutput(string SSLargument1)
        {
            try
            {
                Process process = new Process();
                process.StartInfo.FileName = openSSL_bin;
                process.StartInfo.Arguments = SSLargument1;
                //process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.OutputDataReceived += new DataReceivedEventHandler((sender, e) =>
                {
                    // Prepend line numbers to each line of the output.
                    if (!string.IsNullOrEmpty(e.Data))
                    {
                        tb_debugoutput.Text += e.Data;
                    }
                });
                process.Start();
                process.WaitForExit();
                process.Close();
                process.StartInfo.ErrorDialog = true;

                return SSLargument1;
            }
            catch {
                MessageBox.Show("Fehler bei Debugoutput", "Fehlende Information", MessageBoxButtons.OK);
                SSLargument1 = "Fehler bei Debugoutput";
                return SSLargument1;
            }
        }

        public Form1()
        {

            #region CheckFolderStructure
            //check the Folderstructure and re-create it if necessary
            StreamReader sr = new StreamReader("FolderStructure.txt");
            string? folder;

            while ((folder = sr.ReadLine()) != null)
            {
                folder = folder.Trim();
                if (folder.EndsWith(".txt"))
                {
                    if (!File.Exists(folder))
                    {
                        File.Create(folder);
                    }
                }
                else
                {
                    if (!Directory.Exists(folder))
                    {
                        Directory.CreateDirectory(folder);
                    }
                }

            }
            #endregion
            InitializeComponent();
         
        }
        //CA Private Key
        private void ca_priv_key_gen_click(object sender, EventArgs e)
        {
            //Openssl command: openssl2.exe genrsa -aes256 -passout pass:test -out certificates/ca/private/ca.key.pem 4096
            if (!string.IsNullOrWhiteSpace(tb_ca_priv_name.Text) || !string.IsNullOrWhiteSpace(tb_ca_key_pw1.Text) || !string.IsNullOrWhiteSpace(tb_ca_key_pw2.Text))// Check if no box is empty.
            {
                if ((tb_ca_key_pw1.Text.Length >= 4) && (tb_ca_key_pw2.Text.Length >= 4)) //openssl requires atleast 4 digit passwords
                {
                    if (tb_ca_key_pw1.Text.Equals(tb_ca_key_pw2.Text))
                    {
                        SSLargument = @"genrsa -aes256 -passout pass:" + tb_ca_key_pw1.Text + " -out certificates/ca/private/" + tb_ca_priv_name.Text + ".key.pem 4096";
                        tb_debugoutput.Text = debugoutput(SSLargument);
                    }
                    else { MessageBox.Show("Passwort NICHT Identisch", "Fehlende Information", MessageBoxButtons.OK); }
                }
                else { MessageBox.Show("Passwort mindestern 4 Stellen", "Fehlende Information", MessageBoxButtons.OK); }
            }
            else { MessageBox.Show("Eingabe unvollständig!", "Fehlende Information", MessageBoxButtons.OK); }
        }
        //CA Certificate
        /// <summary>
        /// Creates the public certificate for the CA
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ca_cert_key_gen_Click(object sender, EventArgs e)
        {
            //Openssl command: openssl2.exe req -config openssl-ca.cnf -key certificates/ca/private/ca.key.pem -passin pass:test -new -x509 -days 7300 -sha256 -extensions v3_ca -out certificates/ca/certs/ca.cert.pem -subj "/C=DE/ST=Bavaria/L=Schwabhausen/O=Lang-Lan/OU=IT/CN=Lang-CA2509/emailAddress=admin3@diefamilielang.de"
            if (!string.IsNullOrWhiteSpace(tb_ca_priv_name.Text) || !string.IsNullOrWhiteSpace(tb_ca_key_pw1.Text) || !string.IsNullOrWhiteSpace(tb_ca_key_pw2.Text))// Check if no box is empty.
            {
                if (tb_ca_key_pw1.Text.Length >= 4 && tb_ca_key_pw2.Text.Length >= 4)
                {
                    if (tb_ca_key_pw1.Text.Equals(tb_ca_key_pw2.Text))
                    {
                        SSLargument = @"req -config " + openSSLcnf_ca + " -key certificates/ca/private/" + tb_ca_priv_name.Text + ".key.pem -passin pass:" + tb_ca_key_pw_in.Text + " -new -x509 -days " + tb_ca_cert_days.Text + " -sha256 -extensions v3_ca -out certificates/ca/certs/" + tb_ca_priv_name.Text + ".cert.pem -subj \"/C=DE/ST=Bavaria/L=Schwabhausen/O=Lang-Lan/OU=IT/CN=Lang-CA/emailAddress=admmin@diefamilielang.de\"";
                        tb_debugoutput.Text = debugoutput(SSLargument);
                    }
                    else { MessageBox.Show("Passwort NICHT Identisch", "Fehlende Information", MessageBoxButtons.OK); }
                }
                else { MessageBox.Show("Passwort mindestern 4 Stellen", "Fehlende Information", MessageBoxButtons.OK); }
            }
            else { MessageBox.Show("Eingabe unvollständig!", "Fehlende Information", MessageBoxButtons.OK); }
        }

        //Intermediate Private key
        private void bt_inter_key_gen_Click(object sender, EventArgs e)
        {
            if ((!string.IsNullOrWhiteSpace(tb_inter_priv_name.Text) || !string.IsNullOrWhiteSpace(tb_inter_key_pw1.Text) || !string.IsNullOrWhiteSpace(tb_inter_key_pw2.Text)))// Check if no box is empty.
            {
                if (tb_inter_key_pw1.Text.Length >= 4 && tb_inter_key_pw2.Text.Length >= 4)
                {
                    if (tb_inter_key_pw1.Text.Equals(tb_inter_key_pw2.Text))
                    {
                        SSLargument = "genrsa -aes256 -passout pass:" + tb_inter_key_pw1.Text + " -out certificates/intermediate/private/" + tb_inter_priv_name.Text + ".key.pem 4096";
                        tb_debugoutput.Text = debugoutput(SSLargument);
                    }
                    else { MessageBox.Show("Passwort NICHT Identisch", "Fehlende Information", MessageBoxButtons.OK); }
                }
                else { MessageBox.Show("Passwort mindestern 4 Stellen", "Fehlende Information", MessageBoxButtons.OK); }
            }
            else { MessageBox.Show("Eingabe unvollständig!", "Fehlende Information", MessageBoxButtons.OK); }
        }
        //Intermediate CSR
        private void bt_inter_csr_gen_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tb_inter_priv_name.Text) || !string.IsNullOrWhiteSpace(tb_inter_key_pw1.Text) || !string.IsNullOrWhiteSpace(tb_inter_key_pw2.Text))// Check if no box is empty.
            {
                if (tb_inter_key_pw1.Text.Length >= 4 && tb_inter_key_pw2.Text.Length >= 4)
                {
                    if (tb_inter_key_pw1.Text.Equals(tb_inter_key_pw2.Text))
                    {
                        SSLargument = @"req -config " + openSSLcnf_inter + " -new -passin pass:" + tb_inter_key_pw1.Text + " -sha256 -key certificates/intermediate/private/" + tb_inter_priv_name.Text + ".key.pem -out certificates/intermediate/csr/" + tb_inter_priv_name.Text + ".csr.pem -subj \"/C=DE/ST=Bavaria/L=Schwabhausen/O=Lang-Lan/OU=IT/CN=Lang-Intermediate/emailAddress=admin-intermediate@diefamilielang.de\"";
                        tb_debugoutput.Text = debugoutput(SSLargument);
                    }
                    else { MessageBox.Show("Passwort NICHT Identisch", "Fehlende Information", MessageBoxButtons.OK); }
                }
                else { MessageBox.Show("Passwort mindestern 4 Stellen", "Fehlende Information", MessageBoxButtons.OK); }
            }
            else { MessageBox.Show("Eingabe unvollständig!", "Fehlende Information", MessageBoxButtons.OK); }
        }
        //Intermediate CSR sign CA
        private void bt_inter_sign_ca_name_Click(object sender, EventArgs e)
        {
            if (tb_inter_key_pw_in.Text.Length >= 4)
            {
                SSLargument = @"ca -config " + openSSLcnf_ca + " -extensions v3_intermediate_ca -rand_serial -batch -days " + tb_inter_cert_days.Text + " -notext -md sha256 -passin pass:" + tb_inter_key_pw_in.Text + " -in certificates/intermediate/csr/qwa.csr.pem -out certificates/intermediate/certs/qwa.cert.pem";
                tb_debugoutput.Text = debugoutput(SSLargument);
            }
        }

        private void cb_inter_sign_CheckStateChanged(object sender, EventArgs e)
        {
            if (cb_inter_sign.Checked)
            {
                bt_inter_sign_ca_name.Enabled = true;
            }
            else
            {
                bt_inter_sign_ca_name.Enabled = false;
            }
        }

        //Application private key
        private void bt_appl_priv_gen_click(object sender, EventArgs e)
        {
            SSLargument = @"genrsa -out certificates/server/private/" + tb_appl_priv_name.Text + ".key.pem 4096";
            tb_debugoutput.Text = debugoutput(SSLargument);
        }
        //Application CSR
        private void bt_appl_csr_gen_click(object sender, EventArgs e)
        {
            SSLargument = @"req -config " + openSSLcnf_inter + " -x509 -key certificates/server/private/" + tb_appl_priv_name.Text + ".key.pem -sha256 -out certificates/server/csr/" + tb_appl_csr_name.Text + ".csr.pem -subj \"/C=DE/ST=Bavaria/L=Schwabhausen/O=Lang-Lan/OU=IT/CN=server/emailAddress=admin@diefamilielang.de/subjectAltName=DNS:ubn-grafana.lang,DNS:grafana,IP:192.168.1.20\"";
            tb_debugoutput.Text = debugoutput(SSLargument);
        }
        //Application CSR sign against Intermediate
        private void bt_appl_sign_inter_name_Click(object sender, EventArgs e)
        {
            // openssl      ca -config openssl-inter.cnf        -extensions server_cert -passin pass:test2                         - days 365                            -batch -rand_serial -notext -md sha256 -in certificates/server/csr/server.csr.pem                         -out certificates/server/certs/                             .cert.pem -subj  "/C=DE/ST=Bavaria/L=Schwabhausen/O=Lang-Lan/OU=IT/CN=server/emailAddress=admin@diefamilielang.de/subjectAltName=DNS:server.lang, DNS:sl, IP:192.168.1.22"
            SSLargument = @"ca -config " + openSSLcnf_inter + " -extensions server_cert -passin pass:" + tb_inter_key_pw1.Text + "-days " + tb_appl_cert_days.Text + " -batch -rand_serial -notext -md sha256 -in certificates/server/csr/" + tb_appl_priv_name.Text + ".csr.pem -out certificates/server/certs/" + tb_appl_csr_name.Text + ".cert.pem -subj \"/C=DE/ST=Bavaria/L=Schwabhausen/O=Lang-Lan/OU=IT/CN=server/emailAddress=admin@diefamilielang.de/subjectAltName=DNS:ubn-grafana.lang, DNS:grafana, IP:192.168.1.20\"";
            tb_debugoutput.Text = debugoutput(SSLargument);
        }

        private void tb_appl_csr_name_TextChanged(object sender, EventArgs e)
        {

        }
    }

}
