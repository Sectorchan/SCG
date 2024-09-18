using System;
using System.IO;
using System.Diagnostics;
using System.Linq;
using System.Xml;
using System.Runtime.ConstrainedExecution;
using System.Security.Claims;
using System.Windows.Forms;
using System.Reflection;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {

        String CA_Name;
        String CA_priv_key;
        String SSLargument = "";
        String opensslCnfCa = "openssl.cnf";

        public Form1()
        {
            #region ca
            if (!Directory.Exists("certificates\\ca"))
            {
                Directory.CreateDirectory("certificates\\ca");
            }
            if (!Directory.Exists("certificates\\ca\\certs"))
            {
                Directory.CreateDirectory("certificates\\ca\\certs");
            }
            if (!Directory.Exists("certificates\\ca\\crl"))
            {
                Directory.CreateDirectory("certificates\\ca\\crl");
            }
            if (!Directory.Exists("certificates\\ca\\newcerts"))
            {
                Directory.CreateDirectory("certificates\\ca\\newcerts");
            }
            if (!Directory.Exists("certificates\\ca\\private"))
            {
                Directory.CreateDirectory("certificates\\ca\\private");
            }
            if (!File.Exists("certificates\\ca\\index.txt"))
            {
                File.Create("certificates\\ca\\index.txt");
            }
            if (!File.Exists("certificates\\ca\\serial"))
            {
                File.Create("certificates\\ca\\serial");
            }
            #endregion
            #region intermediate
            if (!Directory.Exists("certificates\\intermediate"))
            {
                Directory.CreateDirectory("certificates\\intermediate");
            }
            if (!Directory.Exists("certificates\\intermediate\\certs"))
            {
                Directory.CreateDirectory("certificates\\intermediate\\certs");
            }
            if (!Directory.Exists("certificates\\intermediate\\crl"))
            {
                Directory.CreateDirectory("certificates\\intermediate\\crl");
            }
            if (!Directory.Exists("certificates\\intermediate\\csr"))
            {
                Directory.CreateDirectory("certificates\\intermediate\\csr");
            }
            if (!Directory.Exists("certificates\\intermediate\\newcerts"))
            {
                Directory.CreateDirectory("certificates\\intermediate\\newcerts");
            }
            if (!Directory.Exists("certificates\\intermediate\\private"))
            {
                Directory.CreateDirectory("certificates\\intermediate\\private");
            }
            #endregion



            InitializeComponent();
        }
        //CA Private Key
        private void ca_priv_key_gen_click(object sender, EventArgs e)
        {
            if ((!String.IsNullOrWhiteSpace(tb_ca_priv_name.Text) || !String.IsNullOrWhiteSpace(tb_ca_key_pw1.Text) || !String.IsNullOrWhiteSpace(tb_ca_key_pw2.Text)))// Check if no box is empty.
            {
                if (tb_ca_key_pw1.Text.Length >= 4 && tb_ca_key_pw2.Text.Length >= 4)
                {
                    if (tb_ca_key_pw1.Text.Equals(tb_ca_key_pw2.Text))
                    {
                        //MessageBox.Show("Passwort Identisch", "Fehlende Information", MessageBoxButtons.OK);
                        SSLargument = "genrsa -aes256 -passout pass:" + tb_ca_key_pw1.Text + " -out certificates/ca/private/" + tb_ca_priv_name.Text + ".key.pem 4096";
                        Process process = new Process();
                        process.StartInfo.FileName = "openssl2.exe";
                        process.StartInfo.Arguments = SSLargument;
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.Start();
                        process.WaitForExit();
                        tb_debugoutput.Text = SSLargument;

                    }
                    else { MessageBox.Show("Passwort NICHT Identisch", "Fehlende Information", MessageBoxButtons.OK); }
                }
                else { MessageBox.Show("Passwort mindestern 4 Stellen", "Fehlende Information", MessageBoxButtons.OK); }
            }
            else { MessageBox.Show("Eingabe unvollständig!", "Fehlende Information", MessageBoxButtons.OK); }
        }
        //CA Certificate
        private void ca_cert_key_gen_Click(object sender, EventArgs e)
        {
            if ((!String.IsNullOrWhiteSpace(tb_ca_priv_name.Text) || !String.IsNullOrWhiteSpace(tb_ca_key_pw1.Text) || !String.IsNullOrWhiteSpace(tb_ca_key_pw2.Text)))// Check if no box is empty.
            {
                if (tb_ca_key_pw1.Text.Length >= 4 && tb_ca_key_pw2.Text.Length >= 4)
                {
                    if (tb_ca_key_pw1.Text.Equals(tb_ca_key_pw2.Text))
                    {
                        // MessageBox.Show("Passwort Identisch", "Fehlende Information", MessageBoxButtons.OK);

                        //openssl2.exe req -config certificates/ca/openssl.cnf -key certificates/ca/private/qw.key.pem -passin pass:test -new -x509 -days 7300 -sha256 -extensions v3_ca -out certificates/ca/certs/qw.cert.pem -subj "/C=DE/ST=Bavaria/L=Schwabhausen/O=Lang-Lan/OU=IT/CN=Lang-CA/emailAddress=admin3@diefamilielang.de"

                        SSLargument = "req -config certificates/ca/openssl.cnf -key certificates/ca/private/" + tb_ca_priv_name.Text + ".key.pem -passin pass:" + tb_ca_key_pw1.Text + " -new -x509 -days " + tb_ca_cert_days.Text + " -sha256 -extensions v3_ca -out certificates/ca/certs/" + tb_ca_priv_name.Text + ".cert.pem -subj \"/C=DE/ST=Bavaria/L=Schwabhausen/O=Lang-Lan/OU=IT/CN=Lang-CA/emailAddress=admmin@diefamilielang.de\"";
                        Process process = new Process();
                        process.StartInfo.FileName = "openssl2.exe";
                        process.StartInfo.Arguments = SSLargument;
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.Start();
                        process.WaitForExit();
                        tb_debugoutput.Text = SSLargument;
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
            if ((!String.IsNullOrWhiteSpace(tb_inter_priv_name.Text) || !String.IsNullOrWhiteSpace(tb_inter_key_pw1.Text) || !String.IsNullOrWhiteSpace(tb_inter_key_pw2.Text)))// Check if no box is empty.
            {
                if (tb_inter_key_pw1.Text.Length >= 4 && tb_inter_key_pw2.Text.Length >= 4)
                {
                    if (tb_inter_key_pw1.Text.Equals(tb_inter_key_pw2.Text))
                    {
                        MessageBox.Show("Passwort Identisch", "Fehlende Information", MessageBoxButtons.OK);
                        SSLargument = "genrsa -aes256 -passout pass:" + tb_inter_key_pw1.Text + " -out certificates/intermediate/private/" + tb_inter_priv_name.Text + ".pem 4096";
                        Process process = new Process();
                        process.StartInfo.FileName = "openssl2.exe";
                        process.StartInfo.Arguments = SSLargument;
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.Start();
                        process.WaitForExit();
                        MessageBox.Show(SSLargument);

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
            if ((!String.IsNullOrWhiteSpace(tb_inter_priv_name.Text) || !String.IsNullOrWhiteSpace(tb_inter_key_pw1.Text) || !String.IsNullOrWhiteSpace(tb_inter_key_pw2.Text)))// Check if no box is empty.
            {
                if (tb_inter_key_pw1.Text.Length >= 4 && tb_inter_key_pw2.Text.Length >= 4)
                {
                    if (tb_inter_key_pw1.Text.Equals(tb_inter_key_pw2.Text))
                    {
                        MessageBox.Show("Passwort Identisch intermediate csr", "Fehlende Information", MessageBoxButtons.OK);

                        SSLargument = "req -config certificates/intermediate/openssl.cnf -key certificates/intermediate/private/" + tb_inter_priv_name.Text + ".pem -passin pass:" + tb_inter_key_pw1.Text + " -new -x509 -days " + tb_inter_cert_days.Text + " -sha256 -extensions v3_ca -out certificates/intermediate/csr/" + tb_inter_priv_name.Text + ".csr.pem"; // -subj \"/C=DE/ST=Bavaria/L=Schwabhausen/O=Lang-Lan/OU=IT/CN=Lang-CA/emailAddress=admmin@diefamilielang.de\"";
                        Process process = new Process();
                        process.StartInfo.FileName = "openssl2.exe";
                        process.StartInfo.Arguments = SSLargument;
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                        process.Start();
                        process.WaitForExit();
                        MessageBox.Show(SSLargument);
                    }
                    else { MessageBox.Show("Passwort NICHT Identisch", "Fehlende Information", MessageBoxButtons.OK); }
                }
                else { MessageBox.Show("Passwort mindestern 4 Stellen", "Fehlende Information", MessageBoxButtons.OK); }
            }
            else { MessageBox.Show("Eingabe unvollständig!", "Fehlende Information", MessageBoxButtons.OK); }
        }
        //Intermediate Sign against CA
        private void cb_inter_sign_changed(object sender, EventArgs e)
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

        private void bt_cat_gen_Click(object sender, EventArgs e)
        {
            //cat intermediate/certs/Lang-intermediate.cert.pem certs/Lang - CA.cert.pem > intermediate/certs/Lang-CA-chain.cert.pem
            if (!String.IsNullOrWhiteSpace(tb_cat_ca_name.Text) || !String.IsNullOrWhiteSpace(tb_cat_inter_name.Text))
            {
                //MessageBox.Show("Passwort Identisch", "Fehlende Information", MessageBoxButtons.OK);
                SSLargument = "cat certificates/intermediate/certs/" + tb_cat_inter_name.Text + ".cert.pem certificates/ca/certs/" + tb_cat_ca_name.Text + "Lang-CA.cert.pem > certificates/intermediate/certs/" + tb_cat_res_name.Text + ".cert.pem";
                Process process = new Process();
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.Arguments = SSLargument;
                process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                process.Start();
                process.WaitForExit();
                MessageBox.Show(SSLargument);
            }
        } 

        private void bt_inter_sign_ca_name_Click(object sender, EventArgs e)
        {
            //         openssl ca -config openssl.cnf \
            //   -extensions v3_intermediate_ca \
            //   -days 3650 - notext - md sha256 \
            //   -in intermediate/csr/Lang-intermediate.csr.pem \
            //   -out intermediate/certs/Lang-intermediate.cert.pem

            String tmp_read = File.ReadAllText("certificates/ca/openssl.cnf");
            tmp_read = tmp_read.Replace("private_key", "private_key = $dir/certificates/ca/private/qw.key.pem");
            tmp_read = tmp_read.Replace("certificate", "certificate = $dir/certificates/ca/certs/qw.cert.pem");
            File.WriteAllText("certificates/ca/openssl-nachschreiben.cnf", tmp_read);
           


            SSLargument = "ca -config certificates/ca/openssl-nachschreiben.cnf -extensions v3_intermediate_ca -passin pass:asdf -days 360 -md sha265 -in certificates/intermediate/csr/qwa.csr.pem -out certificates/intermediate/certs/qwa.cert.pem";
            Process process = new Process();
            process.StartInfo.FileName = "openssl2.exe";
            process.StartInfo.Arguments = SSLargument;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;
            process.StartInfo.RedirectStandardOutput = true;
            process.Start();

            tb_debugoutput.Text = process.StandardOutput.ReadToEnd();
            //process.WaitForInputIdle();
            //process.WaitForExit();
            MessageBox.Show(SSLargument);

        }

        
    }

    }
