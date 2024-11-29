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
using System.Runtime.ConstrainedExecution;



namespace SCG.Forms;
public partial class Server : Form
{
    public Server()
    {
        InitializeComponent();
    }

    string privateKeyPath = "cert\\privateKey.txt";
    string publicKeyPath = "cert\\publicKey.txt";
    string certPath = "cert\\cert.der";
    string server = string.Empty;
    int i = 0;

    private void server_onLoad(object sender, EventArgs e)
    {
        //Bt_gen_ca_priv.Enabled = false;

        lb_server_certs.Items.Clear();
        ReadServers(lb_server_certs);
        lb_server_certs.Sorted = true;

        string SqlTable = panel1.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).Text;
        if (SqlTable == "CA")
        {
            cb_isCa.Checked = true;
            cb_issueCert.Checked = true;
        }
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
                if (result2.Value != null)
                {
                    foreach (var item in result2.Value)
                    {
                        control.Items.Add(item);
                    }
                    return Result.Ok(serverList);
                }
                else
                {

                    return Result.Fail("Empty List");
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
    /// Enables the Generate Private Key button
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void cb_new_server_CheckedChanged(object sender, EventArgs e)
    {
        if (cb_new_server.Checked && (lbl_priv_bits.Text != "") && tb_ca_name.Text != "")
        {
            Bt_gen_ca_priv.Enabled = true;
        }
        else
        {
            Bt_gen_ca_priv.Enabled = false;
        }
    }

    /// <summary>
    /// Generates the public key, corresponding to the matching name of the private key
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
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
            cb_isCa.Checked = false;
            cb_issueCert.Checked = false;
        }
        else if (SqlTable == "Server")
        {
            cb_isCa.Checked = false;
            cb_issueCert.Checked = false;
        }
        else if (SqlTable == "User")
        {
            cb_isCa.Checked = false;
            cb_issueCert.Checked = false;
        }
    }

    #region CA
    /// <summary>
    /// Button click "Generate Private Key" > generates a private key and store it on the SQLite database.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>

    private void Bt_gen_ca_priv_onClick(object sender, EventArgs e)
    {
        try
        {
            int PrivateBits = int.Parse(cb_priv_bits.Text);
            using (RSA rsa5 = RSA.Create(PrivateBits))
            {
                // Private Key in Datei speichern
                string privateKey = Convert.ToBase64String(rsa5.ExportRSAPrivateKey());
                File.WriteAllText(privateKeyPath, privateKey);
                MessageBox.Show($"Privater Schlüssel wurde in {privateKeyPath} gespeichert.");
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString(), sender.ToString());
        }

    }
    /// <summary>
    /// Button click "Generate Public Key"
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Bt_gen_ca_pub_onClick(object sender, EventArgs e)
    {
        try
        {
            string serverSelect = Convert.ToString(lb_server_certs.SelectedItem);
            //Result<SQLTable> resTable = SqlTable();
            //Result<List<object>> resWhere = Utils.Sql.SelectWhereObject(Global.database, ["private_bits", "private_content"], resTable.Value, "name", serverSelect);

            using (RSA rsaFromFile = RSA.Create(int.Parse(cb_priv_bits.Text)))
            {
                // Private Key aus Datei lesen
                string privateKeyFromFile = File.ReadAllText(privateKeyPath);
                byte[] privateKeyBytes = Convert.FromBase64String(privateKeyFromFile);
                rsaFromFile.ImportRSAPrivateKey(privateKeyBytes, out _);

                // Öffentlichen Schlüssel exportieren und speichern
                string publicKey = Convert.ToBase64String(rsaFromFile.ExportRSAPublicKey());
                File.WriteAllText(publicKeyPath, publicKey);
                MessageBox.Show($"Öffentlicher Schlüssel wurde in {publicKeyPath} gespeichert.");
            }

            lb_server_certs.SelectedItem = serverSelect;
        }
        catch (Exception ex)
        { MessageBox.Show(ex.Message.ToString()); }
    }
    /// <summary>
    /// Button click "Generate CSR" > generates a Certificate sign request file incl Self signed for CA
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void bt_gen_csr_Click(object sender, EventArgs e)
    {
        try
        {
            string serverSelect = Convert.ToString(lb_server_certs.SelectedItem);
            //Result<SQLTable> resTable = SqlTable();                                         //0             1                   2               3               4               5                   6               7                   8               9           10          11          12      13          14  
            //Result<List<object>> resWhere = Utils.Sql.SelectWhereObject(Global.database, ["private_bits", "private_content", "public_cert", "subj_country", "subj_state", "subj_location", "subj_organisation", "subj_orgaunit", "subj_commonname", "subj_email", "isCa", "not_pathlen", "depth", "canIssue", "public_duration"], resTable.Value, "name", serverSelect);


            //string subject = $"C={resWhere.Value[3]}, ST={resWhere.Value[4]}, L={resWhere.Value[5]}, O={resWhere.Value[6]}, OU={resWhere.Value[7]}, CN={resWhere.Value[8]}, Email={resWhere.Value[9]}";
            string subject = $"C=C, ST=ST, L=L";
            // Private Key aus Datei lesen
            string privateKeyFromFile = File.ReadAllText(privateKeyPath);
            byte[] privateKeyBytes = Convert.FromBase64String(privateKeyFromFile);

            // Öffentlichen Schlüssel aus Datei lesen
            string publicKeyFromFile = File.ReadAllText(publicKeyPath);
            byte[] publicKeyBytes = Convert.FromBase64String(publicKeyFromFile);
            var distinguishedName = new X500DistinguishedName(subject);

            var cert = Utils.Certs.CreateSSCert(4096, subject, privateKeyBytes, publicKeyBytes, true, true, 0, true, 1);


            //using (RSA RSAFromFile = RSA.Create(int.Parse(cb_priv_bits.Text)))
            //{



            //    var request = new CertificateRequest(distinguishedName, RSAFromFile, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
            //    request.CertificateExtensions.Add(new X509BasicConstraintsExtension(true, true, 0, true));

            //    // Zertifikat erstellen und signieren
            //    DateTimeOffset notBefore = DateTimeOffset.UtcNow;
            //    DateTimeOffset notAfter = notBefore.AddYears(1);

            //    var certificate = request.CreateSelfSigned(notBefore, notAfter);
            //    var export = certificate.Export(X509ContentType.Cert);
            //    File.WriteAllBytes(certPath, export);

            //    MessageBox.Show("Selbstsigniertes Zertifikat wurde erfolgreich erstellt.");
            //}



        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }

    }
    /// <summary>
    /// Button click "Generate SelfSigned > Signs his own cert
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Bt_ca_selfSigned_Click(object sender, EventArgs e)
    {
        try
        {

        }
        catch (Exception ex)
        { MessageBox.Show(ex.Message.ToString()); }
    }
    #endregion

    #region intermediate   
    private void Bt_gen_inter_Click(object sender, EventArgs e)
    {
        try
        {
            int PrivateBits = int.Parse(cb_int_priv_bits.Text);
            int InterDuration = int.Parse(tb_int_pub_dura.Text);

            Result<RSA> inter = Utils.Certs.GenCertPair(PrivateBits);

            if (inter.IsSuccess)
            {
                Result<SQLTable> table = SqlTable();
                if (table.IsSuccess)
                {
                    byte[] InterRSAPrivate = inter.Value.ExportRSAPrivateKey();
                    byte[] InterRSAPublic = inter.Value.ExportRSAPublicKey();
                    Result<int> insertInto = Utils.Sql.InsertInto(Global.database, table.Value, tb_int_name.Text, InterRSAPrivate, InterRSAPublic, PrivateBits, InterDuration);
                }
                else
                {
                    MessageBox.Show(table.Reasons[0].Message.ToString());
                }
            }
            else
            {
                MessageBox.Show(inter.Reasons[0].Message.ToString());
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString(), sender.ToString());
        }
    }
    private void Bt_int_gen_csr_Click(object sender, EventArgs e)
    {
        try
        {

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString(), sender.ToString());
        }
    }
    #endregion

    #region Destingusted Names
    private void bt_wrt_dest_names_Click(object sender, EventArgs e)
    {
        try
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
        catch (Exception ex)
        {

        }
    }
    private void Bt_read_Dest_names_Click(object sender, EventArgs e)
    {
        try
        {
            Result<SQLTable> resTable = SqlTable();
            if (resTable.IsSuccess)
            {
                Result<List<object>> resWhere = Utils.Sql.SqlSelectObject(Global.database, "*", resTable.Value);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString(), sender.ToString());
        }
    }
    #endregion

    #region Parameter
    private void Bt_wrt_param_Click(object sender, EventArgs e)
    {
        try
        {
            bool isCa = cb_isCa.Checked;
            bool noPaLen = cb_notPathlen.Checked;
            int depth = Convert.ToInt16(cb_depth.Text);
            bool isCert = cb_issueCert.Checked;
            Result<SQLTable> table = SqlTable();
            string serverSelect = lb_server_certs.SelectedItem.ToString();

            Result<int> resUpdateParam = Utils.Sql.Update(Global.database, table.Value, serverSelect, isCa, noPaLen, depth, isCert);
        }
        catch (Exception ex)
        { MessageBox.Show(ex.Message.ToString()); }
    }
    #endregion







}

