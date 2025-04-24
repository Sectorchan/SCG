using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using FluentResults;
using Microsoft.VisualBasic;
using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Tls;
using PL;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static PL.Utils.Tools;

namespace SCG.Forms
{
    public partial class WriteFile : Form
    {
        #region Members
        private string _ServerName { get; set; }
        public string PrivateKeyPem { get; set; }
        public string _privateKey { get; set; }
        public string _publicKey { get; set; }
        public byte[] _selfSigned { get; set; }
        private serverType _ServerType { get; set; }
        private certType _Certificate { get; set; }

        #endregion
        public WriteFile(serverType serverType, string serverName, certType certificate)
        {
            _ServerType = serverType;
            _Certificate = certificate;
            _ServerName = serverName;

            if (_Certificate == certType.priv)
            {
                _privateKey = (string)Utils.dictCaDetails["private_key"];

                InitializeComponent();
                Cb_cert_ext.Items.AddRange(["Select extension", "PFX files(*.pfx)|*.pfx", "PEM files(*.pem)|*.pem"]);
                Cb_cert_ext.SelectedIndex = 0;
                Bt_write_cert.AccessibleName = "ca";
            }
            else if (_Certificate == certType.pub)
            {
                _publicKey = (string)Utils.dictCaDetails["public_cert"];
                InitializeComponent();
                Cb_cert_ext.Items.AddRange(["Select extension", "DER files(*.der)|*.der", "CRT files(*.crt)|*.crt", "CER files(*.cer)|*.cer"]);
                Cb_cert_ext.SelectedIndex = 0;
                Text = "Export Publickey";
            }
            else if (_Certificate == certType.selfSigned)
            {
                InitializeComponent();
                Cb_cert_ext.Items.AddRange(["Select extension", "PFX files(*.pfx)|*.pfx", "CER files(*.cer)|*.cer"]);
                Cb_cert_ext.SelectedIndex = 0;
                Text = "Export SelfSigned Certificate";
            }

        }
        public WriteFile(serverType serverType, string serverName, certType certificate, byte[] selfSigned)
        {
            _ServerType = serverType;
            _Certificate = certificate;
            _ServerName = serverName;
            _selfSigned = selfSigned;

            if (_Certificate == certType.priv)
            {
                _privateKey = (string)Utils.dictCaDetails["private_key"];

                InitializeComponent();
                Cb_cert_ext.Items.AddRange(["Select extension", "PFX files(*.pfx)|*.pfx", "PEM files(*.pem)|*.pem"]);
                Cb_cert_ext.SelectedIndex = 0;
                Bt_write_cert.AccessibleName = "ca";
            }
            else if (_Certificate == certType.pub)
            {
                _publicKey = (string)Utils.dictCaDetails["public_cert"];
                InitializeComponent();
                Cb_cert_ext.Items.AddRange(["Select extension", "DER files(*.der)|*.der", "CRT files(*.crt)|*.crt", "CER files(*.cer)|*.cer"]);
                Cb_cert_ext.SelectedIndex = 0;
                Text = "Export Publickey";
            }
            else if (_Certificate == certType.selfSigned)
            {
                InitializeComponent();
                Cb_cert_ext.Items.AddRange(["Select extension", "PFX files(*.pfx)|*.pfx", "CER files(*.cer)|*.cer"]);
                Cb_cert_ext.SelectedIndex = 0;
                Text = "Export SelfSigned Certificate";
            }

        }

        private void Bt_write_cert_Click(object sender, EventArgs e)
        {
            string ext = Convert.ToString(Cb_cert_ext.SelectedItem);
            string ext_out = ext.Substring(ext.IndexOf('|') + 2);

            Button btn = (Button)sender;

            if (_Certificate == certType.priv)
            {
                Result<string> res = SaveFile(_ServerName, ext_out, Convert.ToString(Cb_cert_ext.SelectedItem));
                if (res.IsSuccess)
                {
                    Close();
                }
            }
            else if (_Certificate == certType.pub)
            {
                Result<string> res = SaveFile(_ServerName, ext_out, Convert.ToString(Cb_cert_ext.SelectedItem));
                if (res.IsSuccess)
                {
                    Close();
                }
            }
            else if (Text == "Export SelfSigned Certificate")
            {
                Result<string> res = SaveFile(_ServerName, ext_out, Convert.ToString(Cb_cert_ext.SelectedItem));
                if (res.IsSuccess)
                {
                    Close();
                }
            }

        }

        public Result<string> SaveFile(string defaultFileName, string defaultFileExtension, string filter)
        {
            try
            {
                using (SaveFileDialog SaveFile = new SaveFileDialog())
                {
                    SaveFile.FileName = defaultFileName + defaultFileExtension;
                    SaveFile.Filter = filter; 
                    SaveFile.AddExtension = true;
                    SaveFile.RestoreDirectory = true;
                    SaveFile.Title = "Save Privatekey File";

                    if (SaveFile.ShowDialog() == DialogResult.OK)
                    {
                        switch (_ServerType)
                        {
                            case serverType.ca:

                                if (_Certificate == certType.priv)
                                {
                                    File.WriteAllText(SaveFile.FileName, (string)Utils.dictCaDetails["private_key"]);
                                    return Result.Ok("Success");
                                }
                                else if (_Certificate == certType.pub)
                                {
                                    File.WriteAllText(SaveFile.FileName, (string)Utils.dictCaDetails["public_cert"]);
                                    return Result.Ok("Success");
                                }
                                else if (_Certificate == certType.selfSigned)
                                {
                                    string s = (string)Utils.dictCaDetails["ss_cert"];

                                    if (Utils.dictCaDetails.TryGetValue("ss_cert", out object? value))
                                    {
                                        if (value is string base64String)
                                        {
                                            try
                                            {
                                                byte[] certBytes2 = Convert.FromBase64String(base64String);
                                                File.WriteAllBytes("meinzertifikat.pfx", certBytes2);
                                            }
                                            catch (FormatException ex)
                                            {
                                                Console.WriteLine("Fehler beim Konvertieren von Base64: " + ex.Message);
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Wert ist nicht vom Typ string: " + value?.GetType().FullName);
                                        }

                                    
                                        //MessageBox.Show(value.GetType().FullName);
                                        if (value is byte[] certBytes)
                                        {
                                            File.WriteAllBytes("meinzertifikat.pfx", certBytes);
                                            return Result.Ok("Private Key sucessfully written");
                                        }
                                        //File.WriteAllText(SaveFile.FileName, (string)Utils.dictCaDetails["ss_cert"]);
                                        else
                                        {
                                            return Result.Fail("Fail");
                                        }
                                    }
                                }
                                return Result.Fail("Fail");

                            case serverType.intermediate:
                                return Result.Fail("Fail");
                            case serverType.server:
                                return Result.Fail("Fail");
                            case serverType.user:
                                return Result.Fail("Fail");
                            default:
                                return Result.Fail("Fail");
                        }



                    }
                    return Result.Fail("Fail");
                }
            }
            catch (Exception ex)
            {
                return Result.Fail(Convert.ToString(ex));
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            //    base.OnFormClosing(e);
            //    if (e.CloseReason == CloseReason.WindowsShutDown) return;

            //    switch (MessageBox.Show(this, "Are you sure you want to close?", "Closing", MessageBoxButtons.YesNo))
            //    {
            //        case DialogResult.No:
            //            e.Cancel = true;
            //            break;
            //        default:
            //            break;
            //    }
        }

        private void WriteFile_Load(object sender, EventArgs e)
        {
            Bt_write_cert.Enabled = false;
        }

        private void Cb_cert_ext_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!Cb_cert_ext.SelectedItem.Equals("Select extension"))
            {
                Bt_write_cert.Enabled = true;
            }
            else
            { Bt_write_cert.Enabled = false; }
        }
    }
}
