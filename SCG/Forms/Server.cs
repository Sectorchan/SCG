
using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using FluentResults;
using Microsoft.Data.Sqlite;
using PL;
using static PL.Utils;
using static PL.Utils.Certs;
using static PL.Utils.Sql;
using static PL.Utils.Tools;
using RadioButton = System.Windows.Forms.RadioButton;


namespace SCG.Forms;

public partial class Server : Form
{
    public Server()
    {
        InitializeComponent();
    }

    #region Private members

    private readonly bool _writeFile = true;
    private readonly bool _certVerify = true;
    private readonly string[] _fqdn = ["subj_country", "subj_state", "subj_location", "subj_organisation", "subj_orgaunit", "subj_commonname", "subj_email"];
    private readonly string[] _idSql = ["id"];
    private readonly string[] _sshCred = ["host_username", "host_password", "hostname"];
    private readonly string[] _sshlocs = ["cert_filename", "cert_priv_ext", "cert_pub_ext", "cert_path"];


    private readonly string c_selfsignedPasswordPfx = "";
    private readonly string i_selfsignedPasswordPfx = "";
    private readonly string s_selfsignedPasswordPfx = "";
    private readonly string _u_selfsignedPasswordPfx = "";

    private const string CertPFX = "PFX files(*.pfx)|*.pfx";
    private const string CertPEM = "PEM files(*.pem)|*.pem";
    private const string CertDER = "DER files(*.der)|*.der";
    private const string CertCRT = "CRT files(*.crt)|*.crt";
    private const string CertCER = "CER files(*.cer)|*.cer";

    public static SqliteConnection sqlconnection;
    private readonly string _masterPassword = "test";

    byte[] key = new byte[32];

    #endregion

    private void server_onLoad(object sender, EventArgs e)
    {
        //open SQL connection
        var db = DatabaseConnection.GetInstance();
        sqlconnection = db.GetConnection();
        PL.Certs cert = new PL.Certs();
        #region !Visible Boxes
        lbl_ca_name.Visible = false;
        tb_ca_name.Visible = false;
        lb_ca_certs.Items.Clear();
        read(lb_ca_certs, serverType.ca);
        lb_ca_certs.Sorted = true;

        lbl_int_name.Visible = false;
        tb_int_name.Visible = false;
        lb_int_certs.Items.Clear();
        read(lb_int_certs, serverType.intermediate);
        lb_int_certs.Sorted = true;

        tb_server_name.Visible = false;
        lbl_server_name.Visible = false;
        lb_server_certs.Items.Clear();
        read(lb_server_certs, serverType.server);
        lb_server_certs.Sorted = true;

        tb_user_name.Visible = false;
        lbl_user_name.Visible = false;

        lb_user_certs.Items.Clear();
        read(lb_user_certs, serverType.user);
        lb_user_certs.Sorted = true;
        #endregion


        ImageList imageList = new ImageList();
        Image original = Image.FromFile(@"images\ca.png");
        Image resized = new Bitmap(original, new Size(16, 16));
        imageList.Images.Add("ca", resized);
        original = Image.FromFile(@"images\intermediate.jpg");
        resized = new Bitmap(original, new Size(16, 16));
        imageList.Images.Add("intermediate", resized);
        original = Image.FromFile(@"images\server.png");
        resized = new Bitmap(original, new Size(16, 16));
        imageList.Images.Add("server", resized);
        original = Image.FromFile(@"images\user.png");
        resized = new Bitmap(original, new Size(16, 16));
        imageList.Images.Add("user", resized);

        treeView1.ImageList = imageList;

        TreeNode rootNode = new TreeNode($"ca", 0, 0);
        rootNode.ImageKey = "root";
        rootNode.SelectedImageKey = "root";
        treeView1.Nodes.Add(rootNode);
        rootNode = new TreeNode($"ca2", 0, 0);
        rootNode.ImageKey = "root";
        rootNode.SelectedImageKey = "root";
        treeView1.Nodes.Add(rootNode);


        #region tbd
        //Result<List<object>> result = Utils.Sql.SelectWhereObject(serverType.ca, ["name", "id"], "name", string.Empty);
        //if (result.IsSuccess)
        //{
        //    if (result.Value != null)
        //    {
        //        foreach (var item in result.Value)
        //        {
        //            TreeNode tree = new TreeNode(Convert.ToString(item));
        //            tree.Tag = "Hey";
        //            treeView1.Nodes.Add(tree);
        //        }
        //    }
        //}
        //Utils.Sql.SelectWhereObject(serverType.intermediate, _idSql, "", "*");
        //treeView1.Sort();
        #endregion
    }

    public static void read(dynamic control, serverType table)
    {
        try
        {
            Utils.Sql.SeSelect(table, control);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public static void ReadServers(dynamic control, serverType table)
    {
        try
        {
            Result<List<string>> result = Utils.Sql.SqlSelect("name", table);

            if (result.IsSuccess)
            {
                if (result.Value != null)
                {
                    foreach (var item in result.Value)
                    {
                        control.Items.Add(item);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    #region CA
    /// <summary>
    /// Button click "Generate Private Key" > generates a private key and store it on the SQLite database.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>

    private void CustomButton1_CustomClick(object? sender, CustomClickEventArgs e)
    {
        try
        {
            fdqnType fqdnType = e.FqdnType;
            serverType serverType = e.ServerType;

            PL.Certs selectedCert = PL.Certs.GetSelectedCert(this, serverType);
            if (selectedCert == null)
            {
                MessageBox.Show("No certificate selected.");
                return;
            }
            if (fqdnType == fdqnType.read)
            {
                tb_sub_c.Text = selectedCert.subj_country;
                tb_sub_st.Text = selectedCert.subj_state;
                tb_sub_loc.Text = selectedCert.subj_location;
                tb_sub_orga.Text = selectedCert.subj_organisation;
                tb_sub_ou.Text = selectedCert.subj_orgaunit;
                tb_sub_cn.Text = selectedCert.subj_commonname;
                tb_sub_email.Text = selectedCert.subj_email;
            }
            else if (fqdnType == fdqnType.write)
            {
                selectedCert.subj_country = tb_sub_c.Text;
                selectedCert.subj_state = tb_sub_st.Text;
                selectedCert.subj_location = tb_sub_loc.Text;
                selectedCert.subj_organisation = tb_sub_orga.Text;
                selectedCert.subj_orgaunit = tb_sub_ou.Text;
                selectedCert.subj_commonname = tb_sub_cn.Text;
                selectedCert.subj_email = tb_sub_email.Text;
                Result<int> updateRow = Utils.Sql.Update(serverType, selectedCert, null, ["subj_country", "subj_state", "subj_location", "subj_organisation", "subj_orgaunit", "subj_commonname", "subj_email"]);
                if (updateRow.IsSuccess)
                {
                    MessageBox.Show($"Successfully updated {updateRow.Value} row(s) in the database");
                    Utils.Tools.UpdateCertList(this, serverType, selectedCert.name); //load servers from SQL
                }
            }


        }
        catch (Exception ex)
        { MessageBox.Show($"{ex}"); }
    }
    private void customButton16_CustomClick(object sender, CustomClickEventArgs e)
    {
        serverType serverType = e.ServerType;

        PL.Certs selectedCert = PL.Certs.GetSelectedCert(this, serverType);
        if (selectedCert != null)
        {
            string pwd = SecurePasswordStore.LoadPassword(selectedCert.host_password, _masterPassword);

            return;
        }
    }
    private void CustomButton2_CustomClick(object sender, CustomClickEventArgs e)
    {
        // 25.06.2025: covers the following certs: CA-priv,pub,selfSigned
        // 14.07.2025: intermediate full
        try
        {
            certType certType = e.CertType;
            serverType serverType = e.ServerType;
            string serverName = string.Empty;

            if (serverType == serverType.ca || serverType == serverType.intermediate || serverType == serverType.server || serverType == serverType.user)
            {
                PL.Certs cert = new PL.Certs();

                if (certType == certType.priv)
                {
                    #region checkbox new server
                    if (cb_new_ca.Checked)
                    {
                        serverName = tb_ca_name.Text;
                    }
                    else if (cb_new_int.Checked)
                    {
                        serverName = tb_int_name.Text;
                    }
                    else if (cb_new_server.Checked)
                    {
                        serverName = tb_server_name.Text;
                    }
                    else if (cb_new_user.Checked)
                    {
                        serverName = tb_user_name.Text;
                    }
                    #endregion
                    if (serverName == string.Empty)
                    {
                        MessageBox.Show("Empty Servername");
                        return;
                    }
                    cert.name = serverName;

                    cert.keySize = Utils.Tools.GetKeySize(this, serverType);

                    Result<string> privateKeyPem = Utils.Certs.GeneratePrivateKey(cert.keySize);
                    cert.private_key = privateKeyPem.Value;

                    if (!privateKeyPem.IsSuccess) return;

                    Result<int> insertRow = Utils.Sql.InsertInto(serverType, serverName, cert);
                    if (!insertRow.IsSuccess) return;

                    if (!_writeFile) return;
                    Form writeFileForm = new WriteFile(serverType, serverName, certType, cert);
                    writeFileForm.ShowDialog();

                    Utils.Tools.UpdateCertList(this, serverType, serverName); //load servers from SQL

                    MessageBox.Show($"Successfully inserted {insertRow} row(s) into the database and saved to the Harddisk");
                }
                else if (certType == certType.pub)
                {
                    PL.Certs selectedCaCert = PL.Certs.GetSelectedCert(this, serverType);
                    Result<string> publicCert = Utils.Certs.GeneratePublicKey(selectedCaCert.name, selectedCaCert.private_key);
                    selectedCaCert.public_cert = publicCert.Value;

                    Result<int> insertRow = Utils.Sql.Update(serverType, selectedCaCert, null, ["public_cert", "public_createDT"]);
                    if (!insertRow.IsSuccess) return;

                    if (!_writeFile) return;
                    Form writeFileForm = new WriteFile(serverType, serverName, certType, selectedCaCert);
                    writeFileForm.ShowDialog();

                    Utils.Tools.UpdateCertList(this, serverType, serverName); //load servers from SQL

                    MessageBox.Show($"Successfully handled public key for {serverType} and saved to database and disk.");
                }
                else if (certType == certType.selfSigned)
                {
                    PL.Certs selectedCaCert = PL.Certs.GetSelectedCert(this, serverType);
                    selectedCaCert.ss_duration = Convert.ToInt32(tb_ca_dura.Text);
                    Result<X509Certificate2> selfSigned = Utils.Certs.GenerateSelfsigned(serverType.ca, selectedCaCert);
                    if (selfSigned.IsSuccess)
                    {
                        selectedCaCert.ss_cert = selfSigned.Value.Export(X509ContentType.Pfx, c_selfsignedPasswordPfx);
                        Result<int> insertRow = Utils.Sql.Update(serverType, selectedCaCert, null, ["ss_cert", "ss_createDT", "serialNumber", "ss_duration"]);

                        if (!_writeFile) return;
                        Form writeFileForm = new WriteFile(serverType, serverName, certType, selectedCaCert);
                        writeFileForm.ShowDialog();

                        if (_certVerify) Utils.Certs.CheckPrivateKey(selfSigned.Value);
                    }
                }
                else if (certType == certType.signed)
                {
                    PL.Certs issuerCert = null;
                    if (serverType == serverType.intermediate)
                    {
                        issuerCert = PL.Certs.GetSelectedCert(this, serverType.ca);
                    }
                    else if (serverType == serverType.server || serverType == serverType.user)
                    {
                        issuerCert = PL.Certs.GetSelectedCert(this, serverType.intermediate);
                    }
                    if (issuerCert == null)
                    {
                        MessageBox.Show("No issuer certificate selected.");
                        return;
                    }
                    PL.Certs requesterCert = PL.Certs.GetSelectedCert(this, serverType);
                    requesterCert.ss_duration = Utils.Tools.GetDuration(this, serverType);

                    Result<X509Certificate2> signedCert = Utils.Certs.GenerateSigned(serverType, issuerCert, requesterCert);
                    if (signedCert.IsSuccess)
                    {
                        Result<int> insertRow = Utils.Sql.Update(serverType, requesterCert, issuerCert, ["ss_cert", "ss_duration", "signed_createDT", "signed_against", "serialNumber"]);

                        if (!_writeFile) return;
                        Form writeFileForm = new WriteFile(serverType, serverName, certType, requesterCert);
                        writeFileForm.ShowDialog();
                        if (_certVerify) Utils.Certs.CheckPrivateKey(signedCert.Value);
                    }
                    else
                    {
                        MessageBox.Show($"{signedCert.Reasons[0].Message}", $"GenerateSigned", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
            return;

        }
        catch (Exception)
        {
            throw;
        }
    }
    #endregion
    private void ServerCredential(object sender, CustomClickEventArgs e)
    {
        serverType serverType = e.ServerType;
        certType certType = e.CertType;
        bool autoUpload = Cb_autoUpload.Checked;

        if (string.IsNullOrWhiteSpace(Tb_hostname.Text) || string.IsNullOrWhiteSpace(Tb_username.Text) || string.IsNullOrWhiteSpace(Tb_password_st.Text) || string.IsNullOrWhiteSpace(Tb_password_nd.Text) || string.IsNullOrWhiteSpace(Tb_hostname.Text))
        {
            MessageBox.Show("All fields must be filled");
            return;
        }
        if (Tb_password_st.Text != Tb_password_nd.Text)
        {
            MessageBox.Show("Passwords dont match!");
            return;
        }

        PL.Certs selectedCaCert = PL.Certs.GetSelectedCert(this, serverType);
        selectedCaCert.host_name = Tb_hostname.Text;

        selectedCaCert.host_username = Tb_username.Text;
        selectedCaCert.host_password = SecurePasswordStore.SavePassword(Tb_password_st.Text, _masterPassword);
        //selectedCaCert.host_password = Tb_password_st.Text;
        selectedCaCert.cert_autoupload = autoUpload ? 1 : 0;

        Result<int> insertRow = Utils.Sql.Update(serverType, selectedCaCert, null, ["host_name", "host_username", "host_password", "cert_autoupload"]);
        if (!insertRow.IsSuccess) return;
        MessageBox.Show($"{insertRow} in SQL");

    }
    #region sonstiges
    /// <summary>
    /// Enables the Generate Private Key button
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void cb_new_ca_CheckedChanged(object sender, EventArgs e)
    {
        if (cb_new_ca.Checked)
        { tb_ca_name.Visible = true; lbl_ca_name.Visible = true; }
        else
        { tb_ca_name.Visible = false; lbl_ca_name.Visible = false; }
    }
    private void cb_new_inter_CheckedChanged(object sender, EventArgs e)
    {
        if (cb_new_int.Checked)
        { tb_int_name.Visible = true; lbl_int_name.Visible = true; }
        else
        { tb_int_name.Visible = false; lbl_int_name.Visible = false; }
    }

    private void cb_new_server_CheckedChanged(object sender, EventArgs e)
    {
        if (cb_new_server.Checked)
        { tb_server_name.Visible = true; lbl_server_name.Visible = true; }
        else
        { tb_server_name.Visible = false; lbl_server_name.Visible = false; }
    }

    private void cb_new_user_CheckedChanged(object sender, EventArgs e)
    {
        if (cb_new_user.Checked)
        { lbl_user_name.Visible = true; tb_user_name.Visible = true; }
        else
        { lbl_user_name.Visible = false; tb_user_name.Visible = false; }
    }

    private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
    {
        MessageBox.Show($"Knoten ausgewählt:\nID: {e.Node.Text}\nBeschreibung: {e.Node.Tag}");
    }

    private void edit_config_load(object sender, EventArgs e)
    {
        edit_config editConfig = new edit_config();
        editConfig.ShowDialog();
    }
    #endregion


    private void certificateInfo_CustomClick(object sender, CustomClickEventArgs e)
    {
        info certInfo = e.CertInfo;
        serverType serverType = e.ServerType;
        PL.Certs selectedCaCert = PL.Certs.GetSelectedCert(this, serverType);

        ComboBox[] comboBoxes = new[] { Cb_san1, Cb_san2, Cb_san3, Cb_san4 };
        TextBox[] textBoxes = new[] { Tb_san1, Tb_san2, Tb_san3, Tb_san4 };
        var selectedCaCertSan = new[] { selectedCaCert.san1, selectedCaCert.san2, selectedCaCert.san3, selectedCaCert.san4 };

        if (selectedCaCert != null)
        {
            if (certInfo == info.CertInfoWrite)
            {
                selectedCaCert.cert_priv_filename = Tb_priv_filename.Text;
                selectedCaCert.cert_priv_fileext = Cb_priv_fileext.Text;
                selectedCaCert.cert_priv_path = Tb_priv_remPath.Text;

                selectedCaCert.cert_pub_filename = Tb_pub_filename.Text;
                selectedCaCert.cert_pub_fileext = Cb_pub_fileext.Text;
                selectedCaCert.cert_pub_path = Tb_pub_remPath.Text;
                int del = 0;
                if (!string.IsNullOrWhiteSpace(Cb_san1.Text) && !string.IsNullOrWhiteSpace(Tb_san1.Text))
                { selectedCaCert.san1 = $"{Cb_san1.Text}:{Tb_san1.Text}"; }
                else
                { del++; }
                if (!string.IsNullOrWhiteSpace(Cb_san2.Text) && !string.IsNullOrWhiteSpace(Tb_san2.Text))
                    selectedCaCert.san2 = $"{Cb_san2.Text}:{Tb_san2.Text}";
                else
                { del++; }
                if (!string.IsNullOrWhiteSpace(Cb_san3.Text) && !string.IsNullOrWhiteSpace(Tb_san3.Text))
                    selectedCaCert.san3 = $"{Cb_san3.Text}:{Tb_san3.Text}";
                else
                { del++; }
                if (!string.IsNullOrWhiteSpace(Cb_san4.Text) && !string.IsNullOrWhiteSpace(Tb_san4.Text))
                    selectedCaCert.san4 = $"{Cb_san4.Text}:{Tb_san4.Text}";
                else
                { del++; }
                if (del == 4)
                {
                    DialogResult dialogResult = MessageBox.Show("Do you want to delete all SANs?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        selectedCaCert.san1 = string.Empty;
                        selectedCaCert.san2 = string.Empty;
                        selectedCaCert.san3 = string.Empty;
                        selectedCaCert.san4 = string.Empty;
                    }
                }
                Result<int> insertRow = Utils.Sql.Update(serverType, selectedCaCert, null,
                    ["cert_priv_filename", "cert_priv_fileext", "cert_priv_path", "cert_pub_filename", "cert_pub_fileext", "cert_pub_path",
                    "san1", "san2", "san3", "san4"]
                    );
                if (insertRow.IsSuccess)
                {
                    MessageBox.Show($"Sucessfully inserted {insertRow.Value} Certificatefile informations");
                }
                else
                {
                    MessageBox.Show($"Error inserting Certificatefile informations: {insertRow.Reasons[0].Message}");
                }
            }
            else if (certInfo == info.CertInfoRead)
            {
                string san = string.Empty;

                Tb_priv_filename.Text = selectedCaCert.cert_priv_filename;
                Cb_priv_fileext.Text = selectedCaCert.cert_priv_fileext;
                Tb_priv_remPath.Text = selectedCaCert.cert_priv_path;
                Tb_pub_filename.Text = selectedCaCert.cert_pub_filename;
                Cb_pub_fileext.Text = selectedCaCert.cert_pub_fileext;
                Tb_pub_remPath.Text = selectedCaCert.cert_pub_path;

                for (int i = 0; i < selectedCaCertSan.Length; i++)
                {
                    if (!string.IsNullOrWhiteSpace(selectedCaCertSan[i]))
                    {
                        textBoxes[i].Text = selectedCaCertSan[i].Substring(selectedCaCertSan[i].IndexOf(':') + 1);
                        comboBoxes[i].Text = selectedCaCertSan[i].Substring(0, selectedCaCertSan[i].IndexOf(':'));
                    }
                }

                //    if (selectedCaCert.san1.Length > 1)
                //{
                //    Tb_san1.Text = selectedCaCert.san1.Substring(selectedCaCert.san1.IndexOf(':') + 1);
                //    Cb_san1.Text = selectedCaCert.san1.Substring(0, selectedCaCert.san1.IndexOf(':'));
                //}
                //if (selectedCaCert.san2.Length > 1)
                //{
                //    Tb_san2.Text = selectedCaCert.san2.Substring(selectedCaCert.san2.IndexOf(':') + 1);
                //    Cb_san2.Text = selectedCaCert.san2.Substring(0, selectedCaCert.san2.IndexOf(':'));
                //}

                //if (selectedCaCert.san3.Length > 1)
                //{
                //    Tb_san3.Text = selectedCaCert.san3.Substring(selectedCaCert.san3.IndexOf(':') + 1);
                //    Cb_san3.Text = selectedCaCert.san3.Substring(0, selectedCaCert.san3.IndexOf(':'));
                //}
                //if (selectedCaCert.san4.Length > 1)
                //{
                //    Tb_san4.Text = selectedCaCert.san4.Substring(selectedCaCert.san4.IndexOf(':') + 1);
                //    Cb_san4.Text = selectedCaCert.san4.Substring(0, selectedCaCert.san4.IndexOf(':'));
                //}
            }
        }
        else
        {
            MessageBox.Show($"No Certificate loaded");
        }
    }

    public static class Global
    {

        public static readonly string database = SCG.Properties.Settings.Default.databasePath;
        public static readonly bool autoUpload = SCG.Properties.Settings.Default.autoUpload;
        public static readonly bool saveToDisk = SCG.Properties.Settings.Default.saveToDisk;

        //public static readonly string[] caBasicConstraint = ["true","",null, "true"];
        public static readonly string[] caKeyUsage = ["critical", "digitalSignature", "cRLSign", "keyCertSign"]; //critical, digitalSignature, cRLSign, keyCertSign
        public static readonly X509BasicConstraintsExtension caBasicConstraint = new X509BasicConstraintsExtension(true, false, 0, true);
        public static readonly X509KeyUsageExtension caKeyUsageExtension = new X509KeyUsageExtension(X509KeyUsageFlags.KeyCertSign | X509KeyUsageFlags.DigitalSignature | X509KeyUsageFlags.CrlSign, true);
        public static readonly string[] intBasicConstraint = ["true", "", "0", "true"];
        public static readonly string[] intKeyUsage = ["critical", "digitalSignature", "cRLSign", "keyCertSign"]; //critical, digitalSignature, cRLSign, keyCertSign

        public static readonly string[] serBasicConstraint = ["false", "", null, "false"];
        public static readonly string[] serKeyUsage = ["critical", "digitalSignature", "keyEncipherment"]; //critical, digitalSignature, keyEncipherment
        public static readonly string[] serExtKeyUsage2 = ["serverAuth"]; //extendedKeyUsage = serverAuth
        public static readonly OidCollection serverAuth = new OidCollection { new Oid("1.3.6.1.5.5.7.3.1") }; //extendedKeyUsage = serverAuth new OidCollection { new Oid("1.3.6.1.5.5.7.3.1") } 

        public static readonly string[] usrBasicConstraint = ["false", "", null, "false"];
        public static readonly string[] usrKeyUsage = ["critical", "nonRepudiation", "digitalSignature", "keyEncipherment"]; //critical, nonRepudiation, digitalSignature, keyEncipherment
        public static readonly string[] usrExtKeyUsage = ["clientAuth", "emailProtection"]; //extendedKeyUsage = clientAuth, emailProtection
        public static readonly OidCollection clientAuth = new OidCollection { new Oid("1.3.6.1.5.5.7.3.2") }; //extendedKeyUsage = clientAuth new OidCollection { new Oid("1.3.6.1.5.5.7.3.2") }
        public static readonly OidCollection secureEmail = new OidCollection { new Oid("1.3.6.1.5.5.7.3.4") }; //extendedKeyUsage = secureEmail new OidCollection { new Oid("1.3.6.1.5.5.7.3.4") }
    }


}


