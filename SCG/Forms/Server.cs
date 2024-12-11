//#define writeFile
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
using static PL.Utils.Certs;
using static PL.Utils.Sql;
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
    #region Private members
    private readonly bool writeFile = true;
    private readonly string c_privateKeyPath = "c_privateKey.pem";
    private readonly string c_publicKeyPath = "c_publicKey.pem";
    private readonly string c_selfsignedKeyPath = "c_selfSignedKey";
    private readonly string i_privateKeyPath = "i_privateKey.pem";
    private readonly string i_publicKeyPath = "i_publicKey.pem";
    private readonly string i_signedKeyPath = "i_selfSignedKey";
    #endregion

    private void server_onLoad(object sender, EventArgs e)
    {
        lbl_ca_name.Visible = false;
        tb_ca_name.Visible = false;
        lbl_int_name.Visible = false;
        tb_int_name.Visible = false;


        lb_server_certs.Items.Clear();
        ReadServers(lb_server_certs, SQLTable.ca);
        lb_server_certs.Sorted = true;

        lb_inter_certs.Items.Clear();
        ReadServers(lb_inter_certs, SQLTable.intermediate);
        lb_inter_certs.Sorted = true;

        string SqlTable = panel1.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).Text;
        if (SqlTable == "CA")
        {
            cb_isCa.Checked = true;
            cb_issueCert.Checked = true;
        }
    }

    public Result<List<string>> ReadServers(dynamic control, SQLTable table)
    {
        try
        {
            Result<SQLTable> result = SqlTable();
            List<string> serverList = new List<string>();
            Result<List<string>> result2 = Utils.Sql.SqlSelect("name", table);

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
            MessageBox.Show(ex.Message);
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
        if (cb_new_server.Checked)
        { tb_ca_name.Visible = true; lbl_ca_name.Visible = true; }
        else
        { tb_ca_name.Visible = false; lbl_ca_name.Visible = false; }
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
            int keySize = int.Parse(cb_priv_bits.Text);
            Result<SQLTable> table = SqlTable();

            Result<byte[]> privKeyByte = Utils.Certs.CreatePrivKey(keySize);
            if (privKeyByte.IsSuccess)
            {
                string privKeyStri = Convert.ToBase64String(privKeyByte.Value);

                Result<int> resInsert = Utils.Sql.InsertInto(table.Value, tb_ca_name.Text, privKeyStri, keySize);

                if (resInsert.IsSuccess)
                {
                    if (writeFile)
                    {
                        //Convert private key into PEM format
                        string privateKeyPem = ConvertToPem(privKeyByte.Value, "RSA PRIVATE KEY");
                        File.WriteAllText(c_privateKeyPath, privateKeyPem);
                    }
                    MessageBox.Show($"Private key saved in {Global.database}.");
                    lb_server_certs.Items.Clear();
                    ReadServers(lb_server_certs, SQLTable.ca);
                    lb_server_certs.Sorted = true;
                }
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
            Result<SQLTable> resTable = SqlTable();

            Result<List<object>> resWhere = Utils.Sql.SelectWhereObject(["private_bits", "private_content"], resTable.Value, "name", serverSelect);
            if (resWhere.IsSuccess)
            {
                //Read privatekey from SQL
                string privateKeyFromSql = Convert.ToString(resWhere.Value[1]);
                byte[] privateKeyBytes = Convert.FromBase64String(privateKeyFromSql);

                Result<byte[]> publicKeyBytes = Utils.Certs.CreatePubKey(Convert.ToInt16(resWhere.Value[0]), privateKeyBytes);
                if (publicKeyBytes.IsSuccess)
                {
                    if (writeFile)
                    {
                        // Convert public key into PEM format
                        string publicKeyPem = ConvertToPem(publicKeyBytes.Value, "PUBLIC KEY");
                        File.WriteAllText(c_publicKeyPath, publicKeyPem);
                    }
                    string publicKeyStri = Convert.ToBase64String(publicKeyBytes.Value);

                    Result<int> resUpdate = Utils.Sql.Update(resTable.Value, publicKeyStri, serverSelect, "name");
                    if (resUpdate.IsSuccess)
                    {
                        MessageBox.Show($"Public key saved in {Global.database}.");
                    }
                    lb_server_certs.SelectedItem = serverSelect;
                }
            }
        }
        catch (Exception ex)
        { MessageBox.Show(ex.Message.ToString()); }
    }
    /// <summary>
    /// Button click "Generate CSR" > generates a Certificate sign request file incl Self signed for CA
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Bt_gen_selfSigned_key_Click(object sender, EventArgs e)
    {
        try
        {
            string serverSelect = Convert.ToString(lb_server_certs.SelectedItem);

            Result<SQLTable> resTable = SqlTable();                          //0                 1            2              3          4           5        6         7
            Result<List<object>> resWhere = Utils.Sql.SelectWhereObject(["private_bits", "private_content", "public_cert", "isCa", "not_pathlen", "depth", "canIssue", "id"], resTable.Value, "name", serverSelect);

            //Result<List<object>> resWhere2 = Utils.Sql.SelectWhereObject(["subj_country", "subj_state", "subj_location", "subj_organisation", "subj_orgaunit", "subj_commonname", "subj_email"], resTable.Value, "name", serverSelect);
            //List<string> list = Utils.Tools.ObjectToString(resWhere2.Value);

            int keySize = Convert.ToInt16(resWhere.Value[0]);
            //Read private key
            string privateKeyFromSql = Convert.ToString(resWhere.Value[1]);
            byte[] privateKeyBytes = Convert.FromBase64String(privateKeyFromSql);

            //Read public key
            string publicKeyFromSql = Convert.ToString(resWhere.Value[2]);
            byte[] publicKeyBytes = Convert.FromBase64String(publicKeyFromSql);

            bool isCaFromSql = Convert.ToBoolean(resWhere.Value[3]);
            bool notPathFromSql = Convert.ToBoolean(resWhere.Value[4]);
            int depthFromSql = Convert.ToInt16(resWhere.Value[5]);
            bool canIssueFromSql = Convert.ToBoolean(resWhere.Value[6]); //not necessary?
            int serial = Convert.ToInt32(resWhere.Value[7]); //not necessary?
            int pubDura = Convert.ToInt16(tb_pub_dura.Text);

            Result<X500DistinguishedName> destName = DNBuilder(tb_sub_c.Text, tb_sub_st.Text, tb_sub_loc.Text, tb_sub_orga.Text, tb_sub_ou.Text, tb_sub_cn.Text, tb_sub_email.Text);
            if (destName.IsSuccess)
            {
                Result<byte[]> certBytes = Utils.Certs.CreateSSCert(SQLTable.ca, keySize, destName.Value, privateKeyBytes, publicKeyBytes, isCaFromSql, notPathFromSql, depthFromSql, canIssueFromSql, pubDura, serial);
                if (certBytes.IsSuccess)
                {
                    if (writeFile)
                    {
                        File.WriteAllBytes(c_selfsignedKeyPath + ".pem", certBytes.Value);
                    }

                    string certStri = Convert.ToBase64String(certBytes.Value);
                    Result<int> resUpdate = Utils.Sql.Update(resTable.Value, serverSelect, certStri, pubDura);
                    if (resUpdate.IsSuccess && resUpdate.ValueOrDefault != 0)
                    {
                        MessageBox.Show($"{resUpdate.Reasons[0].Message} succeded for {resUpdate.Value} row(s) in the database", "SQL Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //MessageBox.Show($"Selfsigned certificate for {serverSelect} saved in {Global.database}");
                    }
                    else
                    { MessageBox.Show($"Update failed:{resUpdate.Errors[0].Message}"); }
                }
            }
        }
        catch (Exception ex)
        { MessageBox.Show(ex.ToString()); }
    }
    #endregion
    #region intermediate   
    private void Bt_gen_inter_priv_Click(object sender, EventArgs e)
    {
        try
        {
            int keySize = int.Parse(cb_priv_bits.Text);
            Result<SQLTable> table = SqlTable();

            Result<byte[]> privKeyByte = Utils.Certs.CreatePrivKey(keySize);
            string privKeyStri = Convert.ToBase64String(privKeyByte.Value);

            Result<int> resInsert = Utils.Sql.InsertInto(SQLTable.intermediate, tb_int_name.Text, privKeyStri, keySize);

            if (resInsert.IsSuccess)
            {
                if (writeFile)
                {
                    //Convert private key into PEM format
                    string privateKeyPem = ConvertToPem(privKeyByte.Value, "RSA PRIVATE KEY");
                    File.WriteAllText(i_privateKeyPath, privateKeyPem);
                }
                MessageBox.Show($"Private key saved in {Global.database}.");
                lb_inter_certs.Items.Clear();
                ReadServers(lb_inter_certs, SQLTable.intermediate);
                lb_inter_certs.Sorted = true;
            }
            else
            {
                MessageBox.Show(Convert.ToString(resInsert.Reasons[0].Message));
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString(), sender.ToString());
        }
    }
    private void Bt_gen_int_pub_Click(object sender, EventArgs e)
    {
        string serverSelect = Convert.ToString(lb_inter_certs.SelectedItem);
        Result<SQLTable> resTable = SqlTable();

        Result<List<object>> resWhere = Utils.Sql.SelectWhereObject(["private_bits", "private_content"], SQLTable.intermediate, "name", serverSelect);
        //Read privatekey from SQL
        if (resWhere.IsSuccess)
        {
            string privateKeyFromSql = Convert.ToString(resWhere.Value[1]);
            byte[] privateKeyBytes = Convert.FromBase64String(privateKeyFromSql);
            Result<byte[]> publicKeyBytes = Utils.Certs.CreatePubKey(Convert.ToInt16(resWhere.Value[0]), privateKeyBytes);

            if (publicKeyBytes.IsSuccess)
            {
                if (writeFile)
                {
                    // Convert public key into PEM format
                    string publicKeyPem = ConvertToPem(publicKeyBytes.Value, "PUBLIC KEY");
                    File.WriteAllText(i_publicKeyPath, publicKeyPem);
                }
                string publicKeyStri = Convert.ToBase64String(publicKeyBytes.Value);

                Result<int> resUpdate = Utils.Sql.Update(SQLTable.intermediate, publicKeyStri, serverSelect, "name");
                if (resUpdate.IsSuccess)
                {
                    MessageBox.Show($"Public key saved in {Global.database}.");
                }
                lb_inter_certs.SelectedItem = serverSelect;
            }
        }
    }
    private void Bt_inter_selfSigned_key_Click(object sender, EventArgs e)
    {
        try
        {
            string serverSelect = Convert.ToString(lb_inter_certs.SelectedItem);
                                                                            //0             1                   2             3         4           5           6        7
            Result<List<object>> resWhere = Utils.Sql.SelectWhereObject(["private_bits", "private_content", "public_cert", "isCa", "not_pathlen", "depth", "canIssue", "id"], SQLTable.intermediate, "name", serverSelect);
            Result<List<object>> resWhere2 = Utils.Sql.SelectWhereObject(["subj_country", "subj_state", "subj_location", "subj_organisation", "subj_orgaunit", "subj_commonname", "subj_email"], SQLTable.intermediate, "name", serverSelect);

            List<string> list = Utils.Tools.ObjectToString(resWhere2.Value);
            Result<X500DistinguishedName> destName = DNBuilder(list[0], list[1], list[2], list[3], list[4], list[5], list[6]);

            int keySize = Convert.ToInt16(resWhere.Value[0]);
            //Read private key
            string privateKeyFromSql = Convert.ToString(resWhere.Value[1]);
            byte[] privateKeyBytes = Convert.FromBase64String(privateKeyFromSql);

            //Read public key
            string publicKeyFromSql = Convert.ToString(resWhere.Value[2]);
            byte[] publicKeyBytes = Convert.FromBase64String(publicKeyFromSql);

            bool isCaFromSql = Convert.ToBoolean(resWhere.Value[3]);
            bool notPathFromSql = Convert.ToBoolean(resWhere.Value[4]);
            int depthFromSql = Convert.ToInt16(resWhere.Value[5]);
            bool canIssueFromSql = Convert.ToBoolean(resWhere.Value[6]); //not necessary?
            int pubDuraFromSql = Convert.ToInt16(tb_pub_dura.Text);
            int serialnumber = Convert.ToInt32((int)resWhere.Value[7]);

            Result<byte[]> certBytes = Utils.Certs.CreateSSCert(SQLTable.intermediate, keySize, destName.Value, privateKeyBytes, publicKeyBytes, isCaFromSql, notPathFromSql, depthFromSql, canIssueFromSql, pubDuraFromSql, serialnumber);
            if (certBytes.IsSuccess)
            {
                string certStri = Convert.ToBase64String(certBytes.Value);
                if (writeFile)
                {
                    File.WriteAllBytes(i_signedKeyPath, certBytes.Value);
                }
                Result<int> resUpdate = Utils.Sql.Update(SQLTable.intermediate, serverSelect, certStri, pubDuraFromSql);
                if (resUpdate.IsSuccess && resUpdate.ValueOrDefault != 0)
                {
                    MessageBox.Show($"{resUpdate.Reasons[0].Message} succeded for {resUpdate.Value} row(s) in the database", "SQL Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                { MessageBox.Show($"Update failed:{resUpdate.Errors[0].Message}"); }
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
    private void Bt_sign_int_cert_Click(object sender, EventArgs e)
    {
        try
        {
            string serverSelect = Convert.ToString(lb_server_certs.SelectedItem);
            string interSelect = Convert.ToString(lb_inter_certs.SelectedItem);
            Result<List<object>> caCert = SelectWhereObject(["private_content", "private_bits", "name"], SQLTable.ca, "name", serverSelect);
            //Read private key
            string privateCaKeyFromSql = Convert.ToString(caCert.Value[0]);
            byte[] privateCaKeyBytes = Convert.FromBase64String(privateCaKeyFromSql);
            int keySizeCa = Convert.ToInt32(caCert.Value[1]);


            Result<List<object>> resWhere = Utils.Sql.SelectWhereObject(["private_bits", "private_content", "public_cert", "isCa", "not_pathlen", "depth", "canIssue", "id"], SQLTable.intermediate, "name", interSelect);
            //Result<List<object>> resSubj = Utils.Sql.SelectWhereObject(["subj_country", "subj_state", "subj_location", "subj_organisation", "subj_orgaunit", "subj_commonname", "subj_email"], SQLTable.intermediate, "name", interSelect);
            //List<string> list = Utils.Tools.ObjectToString(resSubj.Value);
            Result<X500DistinguishedName> destName = DNBuilder(tb_sub_c.Text, tb_sub_st.Text, tb_sub_loc.Text, tb_sub_orga.Text, tb_sub_ou.Text, tb_sub_cn.Text, tb_sub_email.Text);

            int keySize = Convert.ToInt16(resWhere.Value[0]);
            //Read private key
            string privateKeyFromSql = Convert.ToString(resWhere.Value[1]);
            byte[] privateKeyBytes = Convert.FromBase64String(privateKeyFromSql);

            //Read public key
            string publicKeyFromSql = Convert.ToString(resWhere.Value[2]);
            byte[] publicKeyBytes = Convert.FromBase64String(publicKeyFromSql);

            bool isCaFromSql = Convert.ToBoolean(resWhere.Value[3]);
            bool notPathFromSql = Convert.ToBoolean(resWhere.Value[4]);
            int depthFromSql = Convert.ToInt16(resWhere.Value[5]);
            bool canIssueFromSql = Convert.ToBoolean(resWhere.Value[6]); //not necessary?
            int serialnumber = Convert.ToInt32(resWhere.Value[7]);
            int pubDura = Convert.ToInt16(tb_int_pub_dura.Text);



            //if (caCert.IsSuccess && resSubj.IsSuccess && destName.IsSuccess)
            //{
            //    string ss_certString = Convert.ToString(caCert.Value[0]);
            //    byte[] ss_certbyte = Convert.FromBase64String(ss_certString);
            //    // CA-Zertifikat und Schlüssel laden
            //    var caCertificate = new X509Certificate2(ss_certbyte, "", X509KeyStorageFlags.Exportable);

            //    Result<byte[]> signedCert = CreateCaSignCert(SQLTable.intermediate, caCertificate, keySize, destName.Value, isCaFromSql, notPathFromSql, depthFromSql, canIssueFromSql, pubDura, serialnumber);
            //    if (signedCert.IsSuccess )
            //    {
            //        if (writeFile)
            //        {
            //            File.WriteAllBytes(i_signedKeyPath, signedCert.Value);
            //        }
            //        string certStri = Convert.ToBase64String(signedCert.Value);
            //        Result<int> resUpdate = Utils.Sql.Update(SQLTable.intermediate, interSelect, certStri, pubDura);
            //        if (resUpdate.IsSuccess && resUpdate.ValueOrDefault != 0)
            //        {

            //            MessageBox.Show($"{resUpdate.Reasons[0].Message} succeded for {resUpdate.Value} row(s) in the database", "SQL Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        }
            //        else
            //        { MessageBox.Show($"Update failed:{resUpdate.Errors[0].Message}"); }
            //    }

            //}

            //privateKeyBytes
            // CA-Zertifikat laden
            string caCertPath = "MyTestCA.pfx";
            string caPassword = "securepassword";
            //var caCertificate = new X509Certificate2(caCertPath, caPassword, X509KeyStorageFlags.Exportable);
            var caCertificate = new X509Certificate2("c_selfSignedKey1.pem");

            // RSA-Schlüssel für das Intermediate-Zertifikat generieren
            using (RSA intermediateKey = RSA.Create(keySize))
            {
                intermediateKey.ImportRSAPrivateKey(privateKeyBytes, out _);
                // Zertifikatsanfrage für das Intermediate-Zertifikat erstellen
                var request = new CertificateRequest(
                    destName.Value,
                    intermediateKey,
                    HashAlgorithmName.SHA256,
                    RSASignaturePadding.Pkcs1);

                // Erweiterungen für eine Intermediate CA hinzufügen
                request.CertificateExtensions.Add(new X509BasicConstraintsExtension(isCaFromSql, notPathFromSql, depthFromSql, canIssueFromSql)); // CA: true
                request.CertificateExtensions.Add(new X509KeyUsageExtension(
                    X509KeyUsageFlags.KeyCertSign | X509KeyUsageFlags.CrlSign,
                    true)); // Signatur- und CRL-Rechte
                request.CertificateExtensions.Add(new X509SubjectKeyIdentifierExtension(request.PublicKey, false));

                using (RSA caPriv = RSA.Create(keySizeCa))
                {
                    caPriv.ImportRSAPrivateKey(privateCaKeyBytes, out _);

                    // Intermediate-Zertifikat von der Root-CA signieren (5 Jahre Gültigkeit)
                    var intermediateCertificate = request.Create(
                        caCertificate,
                        DateTimeOffset.UtcNow.AddDays(-1), // Gültig ab
                        DateTimeOffset.UtcNow.AddYears(20), // Gültig bis
                        new byte[] { 1, 0, 0, 0 }); // Serial Number (eindeutig)

                }
                // Intermediate-Zertifikat als Datei speichern
                string intermediateCertPath = "MyIntermediateCA.pfx";
                string intermediatePassword = "intermediatepassword";
                var pfxBytes = intermediateCertificate.Export(X509ContentType.Pfx, intermediatePassword);
                var certBytes = intermediateCertificate.Export(X509ContentType.Cert);
                System.IO.File.WriteAllBytes(intermediateCertPath, pfxBytes);
                System.IO.File.WriteAllBytes(i_signedKeyPath, certBytes);


            }
        }
        catch (Exception)
        {
            throw;
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

            Result<SQLTable> sqlTable = SqlTable();
            string serverSelect = string.Empty;

            if (sqlTable.IsSuccess)
            {
                if (sqlTable.Value == SQLTable.ca)
                { serverSelect = Convert.ToString(lb_server_certs.SelectedItem); }
                else if (sqlTable.Value == SQLTable.intermediate)
                { serverSelect = Convert.ToString(lb_inter_certs.SelectedItem); }

                Result<int> result2 = Utils.Sql.Update(sqlTable.Value, serverSelect, sub_c, sub_s, sub_l, sub_o, sub_ou, sub_n, sub_e);
                if (result2.IsSuccess && result2.Value != 0)
                {
                    MessageBox.Show($"Updated {result2.Value} row(s) in the database", "SQL Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(result2.Reasons[0].Message.ToString(), "Update failed!");
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(Convert.ToString(ex), "Update failed!");
        }
    }
    private void Bt_read_Dest_names_Click(object sender, EventArgs e)
    {
        try
        {
            string serverSelect = string.Empty;
            SQLTable table = SQLTable.undefined;
            Button btn = (Button)sender;

            if (btn.AccessibleName == "ca")
            {
                table = SQLTable.ca;
                serverSelect = Convert.ToString(lb_server_certs.SelectedItem);
            }
            else if (btn.AccessibleName == "int")
            {
                table = SQLTable.intermediate;
                serverSelect = Convert.ToString(lb_inter_certs.SelectedItem);
            }
            else
                throw new Exception("Fehler");




            Result<List<object>> resWhere = Utils.Sql.SelectWhereObject(["subj_country", "subj_state", "subj_location", "subj_organisation", "subj_orgaunit", "subj_commonname", "subj_email"], table, "name", serverSelect);
            string subject = $"C={resWhere.Value[0]}, ST={resWhere.Value[1]}, L={resWhere.Value[2]}, O={resWhere.Value[3]}, OU={resWhere.Value[4]}, CN={resWhere.Value[5]}, Email={resWhere.Value[6]}";
            List<string> list = Utils.Tools.ObjectToString(resWhere.Value);

            tb_sub_c.Text = list[0];
            tb_sub_st.Text = list[1];
            tb_sub_loc.Text = list[2];
            tb_sub_orga.Text = list[3];
            tb_sub_ou.Text = list[4];
            tb_sub_cn.Text = list[5];
            tb_sub_email.Text = list[6];


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

            Result<SQLTable> sqlTable = SqlTable();
            string serverSelect = string.Empty;
            if (sqlTable.Value == SQLTable.ca)
            { serverSelect = Convert.ToString(lb_server_certs.SelectedItem); }
            else if (sqlTable.Value == SQLTable.intermediate)
            { serverSelect = Convert.ToString(lb_inter_certs.SelectedItem); }

            Result<int> resUpdateParam = Utils.Sql.Update(sqlTable.Value, serverSelect, isCa, noPaLen, depth, isCert);
        }
        catch (Exception ex)
        { MessageBox.Show(ex.Message.ToString()); }
    }

    #endregion

    /// <summary>
    /// Enables the Generate Private Key button
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void cb_new_inter_CheckedChanged(object sender, EventArgs e)
    {
        if (cb_new_inter.Checked)
        { tb_int_name.Visible = true; lbl_int_name.Visible = true; }
        else
        { tb_int_name.Visible = false; lbl_int_name.Visible = false; }
    }

    private void Bt_read_ca_subj_Click(object sender, EventArgs e)
    {

    }
}

