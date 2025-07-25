using FluentResults;
using PL;
using static PL.Utils.Tools;

namespace SCG.Forms
{
    public partial class WriteFile : Form
    {
        #region Members
        private string _ServerName { get; set; }
        private Certs _certs { get; set; }
        public string PrivateKeyPem { get; set; }
        public string _privateKey { get; set; }
        public string _publicKey { get; set; }
        public byte[] _selfSigned { get; set; }
        private string _csr { get; set; }
        private serverType _ServerType { get; set; }
        private certType _Certificate { get; set; }

        #endregion

       
        /// <summary>
        /// Write Private, Public, selfSigned, Signed
        /// </summary>
        /// <param name="serverType"></param>
        /// <param name="serverName"></param>
        /// <param name="certificate"></param>
        /// <param name="certs"></param>
        public WriteFile(serverType serverType, string serverName, certType certificate, PL.Certs certs)
        {
            _ServerType = serverType;
            _ServerName = certs.name;
            _Certificate = certificate;
            _certs = certs;

            if (_Certificate == certType.priv)
            {
                InitializeComponent();
                Cb_cert_ext.Items.AddRange(["Select extension", "PFX files(*.pfx)|*.pfx", "PEM files(*.pem)|*.pem"]);
                Cb_cert_ext.SelectedIndex = 0;
                Text = "Privatekey Certificate";
            }
            else if (_Certificate == certType.pub)
            {
                InitializeComponent();
                Cb_cert_ext.Items.AddRange(["Select extension", "DER files(*.der)|*.der", "CRT files(*.crt)|*.crt", "CER files(*.cer)|*.cer"]);
                Cb_cert_ext.SelectedIndex = 0;
                Text = "Publickey Certificate";
            }
            else if (_Certificate == certType.selfSigned)
            {
                InitializeComponent();
                Cb_cert_ext.Items.AddRange(["Select extension", "PFX files(*.pfx)|*.pfx", "CER files(*.cer)|*.cer"]);
                Cb_cert_ext.SelectedIndex = 0;
                Text = "SelfSigned Certificate";
            }
                      else if (_Certificate == certType.signed)
            {
                InitializeComponent();
                Cb_cert_ext.Items.AddRange(["Select extension", "PFX files(*.pfx)|*.pfx", "CER files(*.cer)|*.cer"]);
                Cb_cert_ext.SelectedIndex = 0;
                Text = "Signed Certificate";
            }

        }

        private void Bt_write_cert_Click(object sender, EventArgs e)
        {
            string ext = Convert.ToString(Cb_cert_ext.SelectedItem);
            string ext_out = ext.Substring(ext.IndexOf('|') + 2);

            Result<string> res2 = SaveFile(_ServerName + "-" + _Certificate, ext_out, Convert.ToString(Cb_cert_ext.SelectedItem));
            if (res2.IsSuccess)
            {
                MessageBox.Show($"{_ServerName}-{_Certificate}{ext_out} erfolgreich abgespeichert \\n in ");
                Close();
            }
            #region hide
            //if (_Certificate == certType.priv)
            //{
            //    Result<string> res1 = SaveFile(_ServerName + "-" + _Certificate, ext_out, Convert.ToString(Cb_cert_ext.SelectedItem));
            //    if (res1.IsSuccess)
            //    { Close(); }
            //}
            //else if (_Certificate == certType.pub)
            //{
            //    Result<string> res2 = SaveFile(_ServerName + "-" + _Certificate, ext_out, Convert.ToString(Cb_cert_ext.SelectedItem));
            //    if (res2.IsSuccess)
            //    {
            //        MessageBox.Show($"{_ServerName}-{_Certificate}{ext_out} erfolgreich abgespeichert \\n in ");
            //        Close();
            //    }
            //}
            //else if (_Certificate == certType.selfSigned)
            //{
            //    Result<string> res2 = SaveFile(_ServerName + "-" + _Certificate, ext_out, Convert.ToString(Cb_cert_ext.SelectedItem));
            //    if (res2.IsSuccess)
            //    {
            //        MessageBox.Show($"{_ServerName}-{_Certificate}{ext_out} erfolgreich abgespeichert");
            //        Close();
            //    }
            //}
            //else if (_Certificate == certType.csr)
            //{
            //    Result<string> res3 = SaveFile(_ServerName + "-" + _Certificate, ext_out, Convert.ToString(Cb_cert_ext.SelectedItem));
            //    if (res3.IsSuccess)
            //    { Close(); }
            //}
            //else if (_Certificate == certType.signed)
            //{
            //    Result<string> res2 = SaveFile(_ServerName + "-" + _Certificate, ext_out, Convert.ToString(Cb_cert_ext.SelectedItem));
            //    if (res2.IsSuccess)
            //    {
            //        MessageBox.Show($"{_ServerName}-{_Certificate}{ext_out} erfolgreich abgespeichert");
            //        Close();
            //    }
            //}
            #endregion
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
                        //if (_Certificate == certType.priv)
                        //{
                        //    File.WriteAllText(SaveFile.FileName, _certs.private_key);
                        //    return Result.Ok("Success");
                        //}
                        //else if (_Certificate == certType.pub)
                        //{
                        //    File.WriteAllText(SaveFile.FileName, _certs.public_cert);
                        //    return Result.Ok("Success");
                        //}
                        //else if (_Certificate == certType.selfSigned)
                        //{
                        //    return Result.Ok("Success");
                        //}
                        //else if (_Certificate == certType.signed)
                        //{
                        //    return Result.Ok("Success");
                        //}
                        //return Result.Fail($"Certificate failed to write");


                        if (_ServerType == serverType.ca)
                        {
                            if (_Certificate == certType.priv)
                            {
                                File.WriteAllText(SaveFile.FileName, _certs.private_key);
                                return Result.Ok("Success");
                            }
                            else if (_Certificate == certType.pub)
                            {
                                File.WriteAllText(SaveFile.FileName, _certs.public_cert);
                                return Result.Ok("Success");
                            }
                            else if (_Certificate == certType.selfSigned)
                            {
                                return Result.Ok("Success");
                            }
                        }
                        else if (_ServerType == serverType.intermediate || _ServerType == serverType.server || _ServerType == serverType.user)
                        {
                            if (_Certificate == certType.priv)
                            {
                                File.WriteAllText(SaveFile.FileName, _certs.private_key);
                                return Result.Ok("Success");
                            }
                            else if (_Certificate == certType.pub)
                            {
                                File.WriteAllText(SaveFile.FileName, _certs.public_cert);
                                return Result.Ok("Success");
                            }
                            else if (_Certificate == certType.signed)
                            {
                                File.WriteAllBytes(SaveFile.FileName, _certs.ss_cert);
                                return Result.Ok("Success");
                            }
                        }
                        return Result.Fail($"Intermediate Certificate failed to write");
                    }
                    return Result.Fail("Fail");
                }
            }
            catch (Exception ex)
            { return Result.Fail(Convert.ToString(ex)); }
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
