using FluentResults;
using PL;
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
        private string _csr { get; set; }
        private serverType _ServerType { get; set; }
        private certType _Certificate { get; set; }

        #endregion
        public WriteFile(serverType serverType, string serverName, certType certificate)
        {
            _ServerType = serverType;
            _ServerName = serverName;
            _Certificate = certificate;

            if (_Certificate == certType.priv)
            {
                if (_ServerType == serverType.ca)
                {
                    _privateKey = (string)Utils.dictCaDetails["private_key"];
                }
                else if (_ServerType == serverType.intermediate)
                {
                    _privateKey = (string)Utils.dictInterDetails["private_key"];
                }
                else if (_ServerType == serverType.server)
                {
                    _privateKey = (string)Utils.dictServerDetails["private_key"];
                }
                else if (_ServerType == serverType.user)
                {
                    _privateKey = (string)Utils.dictUserDetails["private_key"];
                }
                InitializeComponent();
                Cb_cert_ext.Items.AddRange(["Select extension", "PFX files(*.pfx)|*.pfx", "PEM files(*.pem)|*.pem"]);
                Cb_cert_ext.SelectedIndex = 0;
                //Bt_write_cert.AccessibleName = "ca";
            }
            else if (_Certificate == certType.pub)
            {
                if (_ServerType == serverType.ca)
                {
                    _publicKey = (string)Utils.dictCaDetails["public_cert"];
                }
                else if (_ServerType == serverType.intermediate)
                {
                    _publicKey = (string)Utils.dictInterDetails["public_cert"];
                }
                else if (_ServerType == serverType.server)
                {
                    _publicKey = (string)Utils.dictServerDetails["public_cert"];
                }
                else if (_ServerType == serverType.user)
                {
                    _publicKey = (string)Utils.dictUserDetails["public_cert"];
                }
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
            else if (_Certificate == certType.csr)
            {
                if (_ServerType == serverType.ca)
                {
                    MessageBox.Show("Not implemented");
                    Close();
                }
                else if (_ServerType == serverType.intermediate)
                {
                    _csr = (string)Utils.dictInterDetails["certsign_req"];
                }
                else if (_ServerType == serverType.server)
                {
                    _csr = (string)Utils.dictServerDetails["certsign_req"];
                }
                else if (_ServerType == serverType.user)
                {
                    MessageBox.Show("Not implemented");
                    Close();
                }

                InitializeComponent();
                Cb_cert_ext.Items.AddRange(["Select extension", "CSR files(*.csr)|*.csr", "PEM files(*.pem)|*.pem"]);
                Cb_cert_ext.SelectedIndex = 0;
                Text = "Export CSR";
            }


        }
        public WriteFile(serverType serverType, string serverName, certType certificate, byte[] selfSigned)
        {
            _ServerType = serverType;
            _ServerName = serverName;
            _Certificate = certificate;
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
            else if (_Certificate == certType.csr)
            {
                InitializeComponent();
                Cb_cert_ext.Items.AddRange(["Select extension", "PEM files(*.pem)|*.pem", "DER files(*.der)|*.der"]);
                Cb_cert_ext.SelectedIndex = 0;
                Text = "Export SelfSigned Certificate";
            }

        }

        private void Bt_write_cert_Click(object sender, EventArgs e)
        {
            string ext = Convert.ToString(Cb_cert_ext.SelectedItem);
            string ext_out = ext.Substring(ext.IndexOf('|') + 2);

            if (_Certificate == certType.priv)
            {
                Result<string> res1 = SaveFile(_ServerName + "-" + _Certificate, ext_out, Convert.ToString(Cb_cert_ext.SelectedItem));
                if (res1.IsSuccess)
                { Close(); }
            }
            else if (_Certificate == certType.pub)
            {
                Result<string> res2 = SaveFile(_ServerName + "-" + _Certificate, ext_out, Convert.ToString(Cb_cert_ext.SelectedItem));
                if (res2.IsSuccess)
                {
                    MessageBox.Show($"{_ServerName}-{_Certificate}{ext_out} erfolgreich abgespeichert \\n in ");
                    Close(); }
            }
            else if (_Certificate == certType.selfSigned)
            {
                Result<string> res2 = SaveFile(_ServerName + "-" + _Certificate, ext_out, Convert.ToString(Cb_cert_ext.SelectedItem));
                if (res2.IsSuccess)
                {
                    MessageBox.Show($"{_ServerName}-{_Certificate}{ext_out} erfolgreich abgespeichert");
                    Close();
                }
            }
            else if (_Certificate == certType.csr)
            {
                Result<string> res3 = SaveFile(_ServerName + "-" + _Certificate, ext_out, Convert.ToString(Cb_cert_ext.SelectedItem));
                if (res3.IsSuccess)
                { Close(); }
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
                                    File.WriteAllBytes(SaveFile.FileName, _selfSigned);
                                    return Result.Ok("Success");
                                }
                                return Result.Fail($"CA Certificate failed to write");
                            case serverType.intermediate:
                                if (_Certificate == certType.priv)
                                {
                                    File.WriteAllText(SaveFile.FileName, (string)Utils.dictInterDetails["private_key"]);
                                    return Result.Ok("Success");
                                }
                                else if (_Certificate == certType.pub)
                                {
                                    File.WriteAllText(SaveFile.FileName, (string)Utils.dictInterDetails["public_cert"]);
                                    return Result.Ok("Success");
                                }
                                else if (_Certificate == certType.selfSigned)
                                {
                                    File.WriteAllBytes(SaveFile.FileName, _selfSigned);
                                    return Result.Ok("Success");
                                }
                                else if (_Certificate == certType.csr)
                                {
                                    if (defaultFileExtension == ".pem")
                                    {
                                        File.WriteAllText(SaveFile.FileName, (string)Utils.dictInterDetails["certsign_req"]);
                                        File.WriteAllText(SaveFile.FileName + "privatekey", (string)Utils.dictInterDetails["private_key"]);

                                        return Result.Ok(Path.GetFileName(SaveFile.FileName));
                                    }
                                    else if (defaultFileExtension == ".csr")
                                    {
                                        byte[] cert = Utils.Certs.ConvertPemToCsrBytes((string)Utils.dictInterDetails["certsign_req"]);
                                        File.WriteAllBytes(SaveFile.FileName, cert);
                                        return Result.Ok("Success");
                                    }
                                }
                                return Result.Fail($"Intermediate Certificate failed to write");
                            case serverType.server:
                                if (_Certificate == certType.priv)
                                {
                                    File.WriteAllText(SaveFile.FileName, (string)Utils.dictServerDetails["private_key"]);
                                    return Result.Ok("Success");
                                }
                                else if (_Certificate == certType.pub)
                                {
                                    File.WriteAllText(SaveFile.FileName, (string)Utils.dictServerDetails["public_cert"]);
                                    return Result.Ok("Success");
                                }
                                else if (_Certificate == certType.selfSigned)
                                {
                                    File.WriteAllBytes(SaveFile.FileName, _selfSigned);
                                    return Result.Ok("Success");
                                }
                                else if (_Certificate == certType.csr)
                                {
                                    if (defaultFileExtension == ".pem")
                                    {
                                        File.WriteAllText(SaveFile.FileName, (string)Utils.dictServerDetails["certsign_req"]);
                                        File.WriteAllText(SaveFile.FileName + "privatekey", (string)Utils.dictServerDetails["private_key"]);
                                        
                                        return Result.Ok(Path.GetFileName(SaveFile.FileName));
                                    }
                                    else if (defaultFileExtension == ".csr")
                                    {
                                        byte[] cert = Utils.Certs.ConvertPemToCsrBytes((string)Utils.dictServerDetails["certsign_req"]);
                                        File.WriteAllBytes(SaveFile.FileName, cert);
                                        return Result.Ok("Success");
                                    }
                                }
                                return Result.Fail($"Server Certificate failed to write");
                            case serverType.user:
                                if (_Certificate == certType.priv)
                                {
                                    File.WriteAllText(SaveFile.FileName, (string)Utils.dictUserDetails["private_key"]);
                                    return Result.Ok("Success");
                                }
                                else if (_Certificate == certType.pub)
                                {
                                    File.WriteAllText(SaveFile.FileName, (string)Utils.dictUserDetails["public_cert"]);
                                    return Result.Ok("Success");
                                }
                                else if (_Certificate == certType.selfSigned)
                                {
                                    File.WriteAllBytes(SaveFile.FileName, _selfSigned);
                                    return Result.Ok("Success");
                                }
                                else if (_Certificate == certType.csr)
                                {
                                    if (defaultFileExtension == ".pem")
                                    {
                                        File.WriteAllText(SaveFile.FileName, (string)Utils.dictUserDetails["certsign_req"]);
                                        File.WriteAllText(SaveFile.FileName + "privatekey", (string)Utils.dictUserDetails["private_key"]);

                                        return Result.Ok(Path.GetFileName(SaveFile.FileName));
                                    }
                                    else if (defaultFileExtension == ".csr")
                                    {
                                        byte[] cert = Utils.Certs.ConvertPemToCsrBytes((string)Utils.dictUserDetails["certsign_req"]);
                                        File.WriteAllBytes(SaveFile.FileName, cert);
                                        return Result.Ok("Success");
                                    }
                                }
                                return Result.Fail($"User Certificate failed to write");
                            default:
                                return Result.Fail("Not implemented");
                        }
                    }
                    return Result.Fail("Fail");
                }
            }
            catch (Exception ex)
            { return Result.Fail(Convert.ToString(ex)); }
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
        { Bt_write_cert.Enabled = false; }

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
