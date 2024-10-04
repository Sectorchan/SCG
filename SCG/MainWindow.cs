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
using SCG.Forms;
using static System.Windows.Forms.DataFormats;


namespace WinFormsApp1
{
    public partial class MainWindow : Form
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
            catch (Exception ex)
            {
                MessageBox.Show("Fehler bei Debugoutput", ex.Message, MessageBoxButtons.OK);
                SSLargument1 = "Fehler bei Debugoutput";
                return SSLargument1;
            }
        }

        public MainWindow()
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
        /// <summary>
        /// Creates the CA private Key
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Creates the CA public certificate
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

        /// <summary>
        /// Creates the Intermediate private key
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_inter_key_gen_Click(object sender, EventArgs e)
        {
            //Openssl command: openssl2.exe genrsa -aes256 -passout pass:test2 -out certificates/intermediate/private/int.key.pem 4096
            if ((!string.IsNullOrWhiteSpace(tb_inter_priv_name.Text) || !string.IsNullOrWhiteSpace(tb_inter_key_pw1.Text) || !string.IsNullOrWhiteSpace(tb_inter_key_pw2.Text)))// Check if no box is empty.
            {
                if (tb_inter_key_pw1.Text.Length >= 4 && tb_inter_key_pw2.Text.Length >= 4)
                {
                    if (tb_inter_key_pw1.Text.Equals(tb_inter_key_pw2.Text))
                    {
                        SSLargument = @"genrsa -aes256 -passout pass:" + tb_inter_key_pw1.Text + " -out certificates/intermediate/private/" + tb_inter_priv_name.Text + ".key.pem 4096";
                        tb_debugoutput.Text = debugoutput(SSLargument);
                    }
                    else { MessageBox.Show("Passwort NICHT Identisch", "Fehlende Information", MessageBoxButtons.OK); }
                }
                else { MessageBox.Show("Passwort mindestern 4 Stellen", "Fehlende Information", MessageBoxButtons.OK); }
            }
            else { MessageBox.Show("Eingabe unvollständig!", "Fehlende Information", MessageBoxButtons.OK); }
        }
        /// <summary>
        /// Creates the Intermediate CSR
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_inter_csr_gen_Click(object sender, EventArgs e)
        {
            //Openssl command: openssl2.exe req -config openssl-inter.cnf -new -sha256 -key certificates/intermediate/private/int.key.pem -passin pass:test2 -out certificates/intermediate/csr/int.csr.pem -subj "/C=DE/ST=Bavaria/L=Schwabhausen/O=Lang-Lan/OU=IT/CN=Lang-Intermediate2509/emailAddress=admin2@diefamilielang.de"
            if (!string.IsNullOrWhiteSpace(tb_inter_priv_name.Text) || !string.IsNullOrWhiteSpace(tb_inter_key_pw1.Text) || !string.IsNullOrWhiteSpace(tb_inter_key_pw2.Text))// Check if no box is empty.
            {
                if (tb_inter_key_pw1.Text.Length >= 4 && tb_inter_key_pw2.Text.Length >= 4)
                {
                    if (tb_inter_key_pw1.Text.Equals(tb_inter_key_pw2.Text))
                    {
                        SSLargument = @"req -config " + openSSLcnf_inter + " -new -sha256 -key certificates/intermediate/private/" + tb_inter_priv_name.Text + ".key.pem -passin pass:" + tb_inter_key_pw1.Text + "  -out certificates/intermediate/csr/" + tb_inter_priv_name.Text + ".csr.pem -subj \"/C=DE/ST=Bavaria/L=Schwabhausen/O=Lang-Lan/OU=IT/CN=Lang-Intermediate2709/emailAddress=admin-intermediate@diefamilielang.de\"";
                        tb_debugoutput.Text = debugoutput(SSLargument);
                    }
                    else { MessageBox.Show("Passwort NICHT Identisch", "Fehlende Information", MessageBoxButtons.OK); }
                }
                else { MessageBox.Show("Passwort mindestern 4 Stellen", "Fehlende Information", MessageBoxButtons.OK); }
            }
            else { MessageBox.Show("Eingabe unvollständig!", "Fehlende Information", MessageBoxButtons.OK); }
        }
        /// <summary>
        /// Creates the Intermediate certificate signed by the CA
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_inter_sign_ca_name_Click(object sender, EventArgs e)
        {
            //openssl command: openssl2.exe ca -config openssl-ca.cnf -passin pass:test -rand_serial -extensions v3_intermediate_ca -days 3650 -batch -md sha256 -in certificates/intermediate/csr/int.csr.pem -out certificates/intermediate/certs/int.cert.pem 
            //                              ca -config openssl-ca.cnf -passin pass:test -rand_serial -extensions v3_intermediate_ca -days 3650 -batch -md sha256 -in certificates/intermediate/csr/int.csr.pem -out certificates/intermediate/certs/int.cert.pem"
            if (tb_inter_sign_ca_key_in.Text.Length >= 4)
            {
                SSLargument = @"ca -config " + openSSLcnf_ca + " -passin pass:" + tb_inter_sign_ca_key_in.Text + " -rand_serial -extensions v3_intermediate_ca -days " + tb_inter_cert_days.Text + " -batch -md sha256 -in certificates/intermediate/csr/" + tb_inter_cert_name.Text + ".csr.pem -out certificates/intermediate/certs/" + tb_inter_cert_name.Text + ".cert.pem";
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

        /// <summary>
        /// Creates the application or server private key
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_appl_priv_gen_click(object sender, EventArgs e)
        {
            SSLargument = @"genrsa -out certificates/server/private/" + tb_appl_priv_name.Text + ".key.pem 4096";
            tb_debugoutput.Text = debugoutput(SSLargument);
        }
        /// <summary>
        /// Creates the application or server CSR
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_appl_csr_gen_click(object sender, EventArgs e)
        {
            SSLargument = @"req -config " + openSSLcnf_inter + " -x509 -key certificates/server/private/" + tb_appl_priv_name.Text + ".key.pem -sha256 -out certificates/server/csr/" + tb_appl_csr_name.Text + ".csr.pem -subj \"/C=DE/ST=Bavaria/L=Schwabhausen/O=Lang-Lan/OU=IT/CN=server/emailAddress=admin@diefamilielang.de/subjectAltName=DNS:ubn-grafana.lang,DNS:grafana,IP:192.168.1.20\"";
            tb_debugoutput.Text = debugoutput(SSLargument);
        }
        /// <summary>
        /// Creates the application or server public certificate signed from the Intermediate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_appl_sign_inter_name_Click(object sender, EventArgs e)
        {
            SSLargument = @"ca -config " + openSSLcnf_inter + " -passin pass:" + tb_inter_key_pw1.Text + " -extensions server_cert  -rand_serial -batch -days " + tb_appl_cert_days.Text + " -md sha256 -in certificates/server/csr/" + tb_appl_priv_name.Text + ".csr.pem -out certificates/server/certs/" + tb_appl_csr_name.Text + ".cert.pem ";    //-subj \"/C=DE/ST=Bavaria/L=Schwabhausen/O=Lang-Lan/OU=IT/CN=server/emailAddress=admin@diefamilielang.de/subjectAltName=DNS:ubn-grafana.lang, DNS:grafana, IP:192.168.1.20\"";
            tb_debugoutput.Text = debugoutput(SSLargument);
        }

        private void opensslCnfCa_click(object sender, EventArgs e)
        {
            var myForm = new openSSL_CA_Configfile();
            myForm.Show();


        }

        private void opensslCnfInt_click(object sender, EventArgs e)
        {
            

        }
    }

}
