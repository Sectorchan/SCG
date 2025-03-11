using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using FluentResults;
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
        public string ServerName { get; set; }
        public string PrivateKeyPem { get; set; }
        public string PrivateKey { get; set; }
        public byte[] PublicKey { get; set; }

        #endregion
        public WriteFile(string serverName, string privateKeyPem)
        {
            ServerName = serverName;
            PrivateKeyPem = privateKeyPem;

            InitializeComponent();
            Cb_cert_ext.Items.AddRange(["PFX files(*.pfx)|*.pfx", "PEM files(*.pem)|*.pem"]);
            Cb_cert_ext.SelectedIndex = 0;
            Text = "Export Privatekey";
        }
        public WriteFile(string serverName, int keyType)
        {
            ServerName = serverName;
            if (keyType == 0)
            {
                PrivateKey = Utils.dictCaDetails["private_key"];

                InitializeComponent();
                Cb_cert_ext.Items.AddRange(["Select extension", "PFX files(*.pfx)|*.pfx", "PEM files(*.pem)|*.pem"]);
                Cb_cert_ext.SelectedIndex = 0;
                Text = "Export Privatekey";
            }
            else if (keyType == 1)
            {
                //PublicKey = Convert.ToByte(Utils.dictCaDetails["public_cert"]);
                ServerName = serverName;
                //PublicKey = publicKey;

                InitializeComponent();
                Cb_cert_ext.Items.AddRange(["Select extension", "DER files(*.der)|*.der", "CRT files(*.crt)|*.crt", "CER files(*.cer)|*.cer"]);
                Cb_cert_ext.SelectedIndex = 0;
                Text = "Export Publickey";
            }
        }
        public WriteFile(string serverName, byte[] publicKey)
        {
            ServerName = serverName;

            PublicKey = publicKey;

            InitializeComponent();
            Cb_cert_ext.Items.AddRange(["DER files(*.der)|*.der", "CRT files(*.crt)|*.crt", "CER files(*.cer)|*.cer"]);
            Cb_cert_ext.SelectedIndex = 0;
            Text = "Export Publickey";
        }

        private void Bt_write_cert_Click(object sender, EventArgs e)
        {
            string ext = Convert.ToString(Cb_cert_ext.SelectedItem);
            string ext_out = ext.Substring(ext.IndexOf('|') + 2);

            if (Text == "Export Privatekey")
            {
                Result res = SaveFile(ServerName + ext_out, Convert.ToString(Cb_cert_ext.SelectedItem), PrivateKey);
                if (res.IsSuccess)
                {
                    Close();
                }

                
            }
            else if (Text == "Export Publickey")
            {
                Result res = SaveFile(ServerName + ext_out, Convert.ToString(Cb_cert_ext.SelectedItem), PublicKey);
                if (res.IsSuccess)
                {
                    Close();
                }
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
