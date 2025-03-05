using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
            if (Text == "Export Publickey")
            {

                SaveFile(ServerName + ext_out, Convert.ToString(Cb_cert_ext.SelectedItem), PublicKey);
            }
            else if (Text == "Export Privatekey")
            {
                SaveFile(ServerName + Convert.ToString(Cb_cert_ext.SelectedItem), Convert.ToString(Cb_cert_ext.SelectedItem), PrivateKeyPem);

            }
            // Utils.Tools.SaveFile(ServerName + Convert.ToString(Cb_ca_priv_ext.SelectedItem), Convert.ToString(Cb_ca_priv_ext.SelectedItem), PrivateKeyPem);
        }

        private void WriteFile_Load(object sender, EventArgs e)
        {

        }


    }
}
