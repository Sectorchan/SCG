using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using FluentResults;
using Microsoft.Data.Sqlite;
using PL;
using WinFormsApp1;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static SCG.Ssql;
using RadioButton = System.Windows.Forms.RadioButton;
using System.Threading.Tasks.Dataflow;
using System.Runtime.InteropServices.JavaScript;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;


namespace SCG.Forms;
public partial class Server : Form
{
    public Server()
    {
        InitializeComponent();
    }

    private void server_onLoad(object sender, EventArgs e)
    {
        Bt_gen_priv.Enabled = false;

        lb_server_certs.Items.Clear();
        ReadServers(lb_server_certs);
        lb_server_certs.Sorted = true;
        string SqlTable = panel1.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).Text;
        if (SqlTable == "CA")
        {
            cb_isCa.Checked = true;
            cb_issueCert.Checked = true;
        }
        //Result<List<string>> result = ReadServers(lb_server_certs);
        //if (result.IsSuccess)
        //{
        //    foreach (var item in result.Value)
        //    {
        //        lb_server_certs.Items.Add(item);
        //    }
        //    lb_server_certs.Sorted = true;
        //}
        //else
        //{
        //    MessageBox.Show(result.Reasons[0].Message.ToString());
        //}
    }

    public Result<List<string>> ReadServers(dynamic control)
    {
        try
        {
            Result<SQLTable> result = SqlTable();
            List<string> serverList = new List<string>();
            Result<List<string>> result2 = Utils.Sql.SqlSelect(Global.database, "name", result.Value);

            if (result2.IsSuccess)
            {
                if (result2.Value == null)
                {
                    return Result.Fail("Empty List");
                }
                else
                {
                    foreach (var item in result2.Value)
                    {
                        control.Items.Add(item);
                    }
                    return Result.Ok(serverList);
                }
            }
            else
            {
                return Result.Fail("Fehler");
            }
        }
        catch (Exception ex)
        {
            return Result.Fail(ex.Message);

        }

    }

    public Result<SQLTable> SqlTable()
    {
        string SqlTable = panel1.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).Text;
        SQLTable Table = SQLTable.undefined;
        switch (SqlTable)
        {
            case "CA":
                Table = SQLTable.ca;
                break;
            case "Intermediate":
                Table = SQLTable.intermediate;
                break;
            case "Server":
                Table = SQLTable.server;
                break;
            case "User":
                Table = SQLTable.user;
                break;
        }
        return Result.Ok(Table);
    }
    /// <summary>
    /// Query the selection of the RadioButton
    /// </summary>
    /// <returns>Returns the visible text of the selected RadioButton</returns>
    private Result<SQLTable> CertType()
    {
        string serverType = panel1.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).Text;
        SQLTable Table = SQLTable.undefined;
        switch (serverType)
        {
            case "CA":
                Table = SQLTable.ca;
                break;
            case "Intermediate":
                Table = SQLTable.intermediate;
                break;
            case "Server":
                Table = SQLTable.server;
                break;
            case "User":
                Table = SQLTable.user;
                break;
        }
        return Result.Ok(Table);
    }

    /// <summary>
    /// Button click "Generate Private Key" > generates a private key and store it on the SQLite database.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Bt_gen_priv_onClick(object sender, EventArgs e)
    {
        try
        {
            int PrivateBits = int.Parse(cb_priv_bits.Text);
            int pubDuration = int.Parse(tb_pub_dura.Text);

            Result<RSA> cert = Utils.Certs.GenCertPair(PrivateBits);
            Result<SQLTable> table = SqlTable();

            byte[] RSAPrivate = cert.Value.ExportRSAPrivateKey();
            byte[] RSAPublic = cert.Value.ExportRSAPublicKey();

            Result<int> result2 = Utils.Sql.InsertInto(Global.database, table.Value, tb_ca_name.Text, RSAPrivate, RSAPublic, PrivateBits, pubDuration);

            if (result2.IsSuccess)
            {
                MessageBox.Show($"Added {result2.Value} entries to the database", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lb_server_certs.Items.Clear();
                ReadServers(lb_server_certs);
                lb_server_certs.Sorted = true;
            }
            else
            {

                MessageBox.Show(result2.Reasons[0].Message.ToString());
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString(), sender.ToString());
        }

    }
    /// <summary>
    /// Enables the Generate Private Key button
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void cb_new_server_CheckedChanged(object sender, EventArgs e)
    {
        if (cb_new_server.Checked && (lb_priv_bits.Text != "") && tb_ca_name.Text != "")
        {
            Bt_gen_priv.Enabled = true;
        }
        else
        {
            Bt_gen_priv.Enabled = false;
        }
    }

    /// <summary>
    /// Generates the public key, corresponding to the matching name of the private key
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    //private void bt_gen_pub_key_Click(object sender, EventArgs e)
    //{
    //    int pubDura = Convert.ToInt16(tb_pub_dura.Text);
    //    //string pubPasswd = tb_pub_passwd.Text;
    //    //string pubConfig = tb_pub_cnf.Text;
    //    string serverSelect = lb_server_certs.SelectedItem.ToString();
    //    Result<SQLTable> table = SqlTable();

    //    Result<byte[]> privateKey = Utils.Sql.SelectWhere(Global.database, "private_content", table.Value, "name", serverSelect);
    //    if (privateKey.IsSuccess)
    //    {

    //        byte[] publicKey = Utils.Certs.CreatePubKey(pubDura, privateKey.Value);
    //        Result<int> result = Utils.Sql.Update(Global.database, SQLTable.ca, publicKey, serverSelect);

    //        //if (result.IsSuccess)
    //        //{
    //        //    MessageBox.Show($"Updated {result.Value} row(s) in the database", "SQL Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
    //        //}
    //        //else
    //        //{
    //        //    MessageBox.Show(result.Reasons[0].Message.ToString());
    //        //}
    //    }

    //    //string result = lb_server_certs.SelectedItem.ToString();
    //    //MessageBox.Show(privateKey);
    //}

    private void bt_upd_dest_names_Click(object sender, EventArgs e)
    {
        string sub_c = tb_sub_c.Text;
        string sub_s = tb_sub_st.Text;
        string sub_l = tb_sub_loc.Text;
        string sub_o = tb_sub_orga.Text;
        string sub_ou = tb_sub_ou.Text;
        string sub_n = tb_sub_cn.Text;
        string sub_e = tb_sub_email.Text;
        string serverSelect = lb_server_certs.SelectedItem.ToString();

        Result<SQLTable> result = SqlTable();
        if (result.IsSuccess)
        {
            Result<int> result2 = Utils.Sql.Update(Global.database, result.Value, serverSelect, sub_c, sub_s, sub_l, sub_o, sub_ou, sub_n, sub_e);
            if (result2.IsSuccess)
            {
                MessageBox.Show($"Updated {result2.Value} row(s) in the database", "SQL Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(result2.Reasons[0].Message.ToString());
            }
        }
    }

    private void bt_gen_csr_Click(object sender, EventArgs e)
    {
        int keySize = int.Parse(cb_priv_bits.Text);
        string sub_c = tb_sub_c.Text;
        string sub_s = tb_sub_st.Text;
        string sub_l = tb_sub_loc.Text;
        string sub_o = tb_sub_orga.Text;
        string sub_ou = tb_sub_ou.Text;
        string sub_n = tb_sub_cn.Text;
        string sub_e = tb_sub_email.Text;

        //string serverSelect = lb_server_certs.SelectedItem.ToString();
        string searchTerm = lb_server_certs.SelectedItem.ToString();

        using (RSA rsa = RSA.Create(keySize))  // Using a larger key size for a CA (e.g., 4096 bits)
        {
            // Step 2: Define the subject for the CA certificate (this is the subject name)
            string subject = $"C={sub_c}, ST={sub_s}, L={sub_l}, L={sub_l}, O={sub_o}, OU={sub_ou}, CN={sub_c}";

            // Step 3: Create the CertificateRequest with the RSA key pair and subject
            var req = new CertificateRequest(subject, rsa, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);

            // Step 4: Set CA-specific properties like Basic Constraints (must be a CA)
            // The CA certificate must have the Basic Constraints extension set to "CA: true".
            Result<SQLTable> table = SqlTable();

            req.CertificateExtensions.Add(
                              new X509BasicConstraintsExtension(cb_isCa.Checked, cb_notPathlen.Checked, Convert.ToInt16(cb_depth.Text), cb_issueCert.Checked));
            // Step 5: Set the certificate validity period (e.g., 10 years for a CA)
            DateTimeOffset notBefore = DateTimeOffset.Now;
            int duration = Convert.ToInt16(tb_pub_dura.Text);
            DateTimeOffset notAfter = notBefore.AddMonths(duration);

            // Step 6: Create the self-signed CA certificate
            X509Certificate2 caCertificate = req.CreateSelfSigned(notBefore, notAfter);

            // Step 7: Export the certificate (optional: save to file, or use as needed)
            byte[] caCertBytes = caCertificate.Export(X509ContentType.Cert);
            byte[] privateKey = rsa.ExportRSAPrivateKey();
            byte[] publicKey = rsa.ExportRSAPublicKey();

            Result<int> Update = Utils.Sql.Update(Global.database, table.Value, privateKey, publicKey, searchTerm, sub_c, sub_s, sub_l,
                sub_o, sub_ou, sub_c, sub_e, cb_isCa.Checked, cb_notPathlen.Checked, Convert.ToInt16(cb_depth.Text), cb_issueCert.Checked, true);

            if (Update.IsSuccess)
            {
                MessageBox.Show($"Updated {Update.Value} row(s) in the database", "SQL Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (Update.IsFailed)
            {
                MessageBox.Show(Update.Reasons[0].Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void panel1_EnabledChanged(object sender, EventArgs e)
    {
        MessageBox.Show(sender.ToString());
    }

    private void radioButtons_CheckedChanged(object sender, EventArgs e)
    {
        string SqlTable = panel1.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).Text;
        if (SqlTable == "CA")
        {
            cb_isCa.Checked = true;
            cb_issueCert.Checked = true;
        }
        else if (SqlTable == "Intermediate")
        {

        }
        else if (SqlTable == "Server")
        {

        }
        else if (SqlTable == "User")
        {

        }
    }
}


