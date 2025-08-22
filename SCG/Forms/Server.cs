using System.Diagnostics;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using FluentResults;
using Microsoft.Data.Sqlite;
using PL.Certificate;
using Renci.SshNet.Messages;
using static PL.Utils;
using static PL.Utils.Tools;
using static SCG.CustomMessageBox;

namespace SCG.Forms;

public partial class Server : Form
{
    private PL.Certificate.Certificate _cert;

    #region Private members

    private readonly bool _writeFile = false;
    private readonly bool _certVerify = true;
    private readonly string c_selfsignedPasswordPfx = "";
    public static SqliteConnection sqlconnection;
    private readonly string _masterPassword = "test";
    private TreeNode clickedNode;

    #endregion
    public Server()
    {
        InitializeComponent();
        _cert = new();
       
    }


    private void server_onLoad(object sender, EventArgs e)
    {
        //open SQL connection
        var db = DatabaseConnection.GetInstance();
        sqlconnection = db.GetConnection();
        #region !Visible Boxes
        //lbl_ca_name.Visible = false;
        //tb_ca_name.Visible = false;
        //lb_ca_certs.Items.Clear();
        //read(lb_ca_certs, serverType.ca);
        //lb_ca_certs.Sorted = true;

        //lbl_int_name.Visible = false;
        //tb_int_name.Visible = false;
        //lb_int_certs.Items.Clear();
        //read(lb_int_certs, serverType.intermediate);
        //lb_int_certs.Sorted = true;

        //tb_server_name.Visible = false;
        //lbl_server_name.Visible = false;
        //lb_server_certs.Items.Clear();
        //read(lb_server_certs, serverType.server);
        //lb_server_certs.Sorted = true;

        //tb_user_name.Visible = false;
        //lbl_user_name.Visible = false;

        //lb_user_certs.Items.Clear();
        //read(lb_user_certs, serverType.user);
        //lb_user_certs.Sorted = true;
        #endregion
        SetupImageList();        
        LoadTreeView();
    }
    private void SetupImageList()
    {
        CertificateTreeImages.Images.Add("ca", Properties.Resources.ca);
        CertificateTreeImages.Images.Add("intermediate", Properties.Resources.intermediate);
        CertificateTreeImages.Images.Add("server", Properties.Resources.server);
        CertificateTreeImages.Images.Add("user", Properties.Resources.user);
    }
    void LoadTreeView()
    {
        CertificateTree.Nodes.Clear();
        List<Certificate> cas = PL.Utils.Sql.LoadCerts("ca");
        List<Certificate> intermediates = PL.Utils.Sql.LoadCerts("intermediate");
        List<Certificate> servers = PL.Utils.Sql.LoadCerts("server");
        List<Certificate> users = PL.Utils.Sql.LoadCerts("user");

        foreach (Certificate ca in cas)
        {
            TreeNode caNode = new TreeNode(ca.name/* + "-" + ca.id*/)
            {
                Tag = new TreeCertWrapper { ServerType = serverType.ca, Cert = ca },
                ImageKey = "ca",
                SelectedImageKey = "ca"
            };
            foreach (Certificate intermediate in intermediates)
            {
                if (intermediate.signed_against == ca.id.ToString())
                {
                    TreeNode interNode = new TreeNode(intermediate.name)
                    {
                        Tag = new TreeCertWrapper { ServerType = serverType.intermediate, Cert = intermediate },
                        ImageKey = "intermediate",
                        SelectedImageKey = "intermediate"
                    };
                    foreach (Certificate server in servers)
                    {
                        if (server.signed_against == intermediate.id.ToString())
                        {
                            TreeNode serverNode = new TreeNode(server.name)
                            {
                                Tag = new TreeCertWrapper { ServerType = serverType.server, Cert = server },
                                ImageKey = "server",
                                SelectedImageKey = "server"
                            };
                            interNode.Nodes.Add(serverNode);
                        }
                    }
                    foreach (Certificate user in users)
                    {
                        if (user.signed_against == intermediate.id.ToString())
                        {
                            TreeNode userNode = new TreeNode(user.name)
                            {
                                Tag = new TreeCertWrapper { ServerType = serverType.user, Cert = user },
                                ImageKey = "user",
                                SelectedImageKey = "user"
                            };
                            interNode.Nodes.Add(userNode);
                        }
                    }
                    caNode.Nodes.Add(interNode);
                }
            }
            CertificateTree.Nodes.Add(caNode);
        }
    }

    public static void read(dynamic control, serverType table)
    {
        try
        {
            PL.Utils.Sql.SeSelect(table, control);
        }
        catch (Exception)
        {
            throw;
        }
    }

    #region CA
    /// <summary>
    /// Button click "Generate Private Key" > generates a private key and store it on the SQLite database.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>

    private void customButton16_CustomClick(object sender, CustomClickEventArgs e)
    {
        serverType serverType = e.ServerType;
        Certificate selectedCert = Certificate.GetSelectedCert(this, serverType);
        if (selectedCert != null)
        {
            string pwd = PL.Password.SecurePasswordStore.LoadPassword(selectedCert.host_password, _masterPassword);
            return;
        }
    }
    private void generateEntry(TreeCertWrapper wrapper)
    {
        try
        {
            if (wrapper is TreeCertWrapper)
            { _cert = wrapper.Cert; }
            Result<int> insertRow = PL.Utils.Sql.InsertInto(wrapper.ServerType, _cert.name, _cert);
            LoadTreeView();
        }
        catch (Exception)
        { throw; }

    }
    private void CustomButton2_CustomClick(TreeCertWrapper wrapper) //CustomClickEventArgs e
    {
        try
        {
            certType certType = certType.priv;
            serverType serverType = wrapper.ServerType;

            if (wrapper is TreeCertWrapper)
            { _cert = wrapper.Cert; }

            if (certType == certType.priv)
            {
                if (Global.useDefault)
                { _cert.keySize = 4096; }
                else
                {
                    createEntry enter = new createEntry(_cert, serverType, createEntry.configType.keySize);

                    DialogResult result = enter.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        //_cert.name = enter.Return;
                        Result<string> privateKeyPem = PL.Utils.Certs.GeneratePrivateKey(_cert.keySize);
                        _cert.private_key = privateKeyPem.Value;
                        if (privateKeyPem.IsSuccess)
                        {
                            Result<int> insertRow = PL.Utils.Sql.Update(serverType, _cert, null, ["keySize", "private_key", "private_createDT"]);
                            if (insertRow.IsSuccess)
                            {
                                if (_writeFile)
                                {
                                    Form writeFileForm = new WriteFile(serverType, _cert.name, certType, _cert);
                                    writeFileForm.ShowDialog();
                                }
                                MessageBox.Show($"Successfully inserted {insertRow} row(s) into the database and saved to the Harddisk");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Cancelled");
                        return;
                    }
                }
            }
            else if (certType == certType.pub)
            {
                Certificate selectedCaCert = Certificate.GetSelectedCert(this, serverType);
                Result<string> publicCert = PL.Utils.Certs.GeneratePublicKey(selectedCaCert.name, selectedCaCert.private_key);
                selectedCaCert.public_cert = publicCert.Value;

                Result<int> insertRow = PL.Utils.Sql.Update(serverType, selectedCaCert, null, ["public_cert", "public_createDT"]);
                if (!insertRow.IsSuccess) return;

                if (!_writeFile) return;
                Form writeFileForm = new WriteFile(serverType, _cert.name, certType, selectedCaCert);
                writeFileForm.ShowDialog();

                PL.Utils.Tools.UpdateCertList(this, serverType, _cert.name); //load servers from SQL
                MessageBox.Show($"Successfully handled public key for {serverType} and saved to database and disk.");
            }
            else if (certType == certType.selfSigned)
            {
                Certificate selectedCaCert = Certificate.GetSelectedCert(this, serverType);
                selectedCaCert.ss_duration = Convert.ToInt32(tb_ca_dura.Text);
                Result<X509Certificate2> selfSigned = PL.Utils.Certs.GenerateSelfsigned(serverType.ca, selectedCaCert);
                if (selfSigned.IsSuccess)
                {
                    selectedCaCert.ss_cert = selfSigned.Value.Export(X509ContentType.Pfx, c_selfsignedPasswordPfx);
                    Result<int> insertRow = PL.Utils.Sql.Update(serverType, selectedCaCert, null, ["ss_cert", "ss_createDT", "serialNumber", "ss_duration"]);

                    if (!_writeFile) return;
                    Form writeFileForm = new WriteFile(serverType, _cert.name, certType, selectedCaCert);
                    writeFileForm.ShowDialog();

                    if (_certVerify) PL.Utils.Certs.CheckPrivateKey(selfSigned.Value);
                }
            }
            else if (certType == certType.signed)
            {
                Certificate issuerCert = null;
                if (serverType == serverType.intermediate)
                {
                    issuerCert = Certificate.GetSelectedCert(this, serverType.ca);
                }
                else if (serverType == serverType.server || serverType == serverType.user)
                {
                    issuerCert = Certificate.GetSelectedCert(this, serverType.intermediate);
                }
                if (issuerCert == null)
                {
                    MessageBox.Show("No issuer certificate selected.");
                    return;
                }
                Certificate requesterCert = Certificate.GetSelectedCert(this, serverType);
                requesterCert.ss_duration = PL.Utils.Tools.GetDuration(this, serverType);

                Result<X509Certificate2> signedCert = PL.Utils.Certs.GenerateSigned(serverType, issuerCert, requesterCert);
                if (signedCert.IsSuccess)
                {
                    Result<int> insertRow = PL.Utils.Sql.Update(serverType, requesterCert, issuerCert, ["ss_cert", "ss_duration", "signed_createDT", "signed_against", "serialNumber"]);

                    if (!_writeFile) return;
                    Form writeFileForm = new WriteFile(serverType, _cert.name, certType, requesterCert);
                    writeFileForm.ShowDialog();
                    if (_certVerify) PL.Utils.Certs.CheckPrivateKey(signedCert.Value);
                }
                else
                {
                    MessageBox.Show($"{signedCert.Reasons[0].Message}", $"GenerateSigned", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

            LoadTreeView();
            return;

        }
        catch (Exception)
        {
            throw;
        }
    }

    #endregion
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

    private void edit_config_load(object sender, EventArgs e)
    {
        edit_config editConfig = new edit_config();
        editConfig.ShowDialog();
    }
    #endregion


    public static class Global
    {

        public static readonly string database = SCG.Properties.Settings.Default.databasePath;
        public static readonly bool autoUpload = SCG.Properties.Settings.Default.autoUpload;
        public static readonly bool saveToDisk = SCG.Properties.Settings.Default.saveToDisk;
        public static readonly bool useDefault = true;

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
    public static class DefaultValues
    {
        public static readonly int _keySize = 4096;

        public static Dictionary<string, CustomMessageBox.CustomDialogResult> OkCan_buttons = new Dictionary<string, CustomDialogResult>
        {
            { "OK", CustomDialogResult.OK },
            { "Cancel", CustomDialogResult.Cancel }
        };
        public static Dictionary<string, CustomMessageBox.CustomDialogResult> ConBackCan_buttons = new Dictionary<string, CustomDialogResult>
        {
            { "Continue", CustomDialogResult.Continue },
            { "Back", CustomDialogResult.Back },
            { "Cancel", CustomDialogResult.Cancel }
        };
    }

    private void ShowDynamicContextMenu(TreeNode node, Point location)
    {

        createMenu.Visible = false;
        toolStripSeparator1.Visible = false;
        viewToolStripMenuItem.Visible = false;


        create_private_key.Visible = false;
        create_public_key.Visible = false;
        create_selfSign.Visible = false;
        create_sign.Visible = false;
        create_new_ca.Visible = false;
        create_new_intermediate.Visible = false;
        create_new_server.Visible = false;
        create_new_user.Visible = false;

        certificateInformationMenuItem1.Visible = false;

        if (node != null && (node.Tag is TreeCertWrapper wrapper))
        {
            serverType type = wrapper.ServerType;
            switch (type)
            {
                case serverType.ca:
                    createMenu.Visible = true;
                    create_private_key.Visible = true;
                    if (wrapper.Cert.private_key != null)
                    {
                        create_public_key.Visible = true;
                    }
                    if (wrapper.Cert.public_cert != null)
                    {
                        create_selfSign.Visible = true;
                    }

                    viewToolStripMenuItem.Visible = true;
                    break;
                case serverType.intermediate:
                    create_sign.Visible = true;
                    break;
                case serverType.server:
                    create_sign.Visible = true;
                    break;
                case serverType.user:
                    create_sign.Visible = true;
                    break;
            }
        }
        else
        {
            createMenu.Visible = true;
            create_new_ca.Visible = true;
            create_new_intermediate.Visible = true;

        }
        contextMenuStrip.Show(CertificateTree, location);
    }
    private void contextMenuStrip_MouseUp(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Right)
        {
            clickedNode = CertificateTree.GetNodeAt(e.X, e.Y);
            ShowDynamicContextMenu(clickedNode, e.Location);
        }
    }
    private void View_Keys(object sender, EventArgs e)
    {
        TreeCertWrapper wrapper = (TreeCertWrapper)CertificateTree.SelectedNode.Tag;
        if (wrapper != null)
        {
            string title = string.Empty;
            string message = string.Empty;
            if (sender is ToolStripMenuItem menuItem)
            {
                switch (menuItem.Name)
                {
                    case "view_private_key":
                        title = "Private Key";
                        message = wrapper.Cert.private_key;
                        break;
                    case "view_public_key":
                        title = "Public Key";
                        message = wrapper.Cert.public_cert;
                        break;
                    case "view_self_signed":
                        title = "Self-Signed Certificate";
                        if (wrapper.Cert.ss_cert != null)
                        {
                            X509Certificate2 signed = new X509Certificate2(wrapper.Cert.ss_cert);
                            message =
                                $"Issuer: {signed.Issuer}\n" +
                                $"Subject: {signed.Subject}\n" +
                                $"Serial Number: {signed.SerialNumber}\n" +
                                $"Not Before: {signed.NotBefore}\n" +
                                $"Not After: {signed.NotAfter}\n" +
                                $"Thumbprint: {signed.Thumbprint}\n" +
                                $"Signature Algorithm: {signed.SignatureAlgorithm.FriendlyName}\n" +
                                $"Public Key: {signed.PublicKey.Oid.FriendlyName}\n" +
                                $"Public Key Length: {signed.PublicKey.GetRSAPublicKey().KeySize} bits\n";
                        }
                        else
                        {
                            message = "No self-signed certificate available.";
                        }
                        break;
                    case "view_fqdn":
                        title = "View FQDN";
                        message = $"C:{wrapper.Cert.subj_country}\n" +
                            $"ST:{wrapper.Cert.subj_state}\n" +
                            $"L:{wrapper.Cert.subj_location}\n" +
                            $"O:{wrapper.Cert.subj_organisation}\n" +
                            $"OU:{wrapper.Cert.subj_orgaunit}\n" +
                            $"CN:{wrapper.Cert.subj_commonname}\n" +
                            $"E-Mail:{wrapper.Cert.subj_email}";
                        break;
                    case "view_san":
                        title = "View SANs";
                        message = Convert.ToString(wrapper.Cert.ss_cert);
                        break;
                }
            }
            MessageBox.Show($"{message}", $"{title} - CTRL+C to copy", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
    /// <summary>
    /// Actions for the clicks on the TreeView context menu items.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ToolStripClick(object sender, EventArgs e)
    {
        TreeCertWrapper wrapper = (TreeCertWrapper)CertificateTree.SelectedNode.Tag;
        if (wrapper != null)
        {
            _ = wrapper.ServerType;
            certType certType = certType.priv;
            if (sender is ToolStripMenuItem menuItem)
            {
                switch (menuItem.Name)
                {
                    case "create_private_key":
                        certType = certType.priv;
                        break;
                    case "create_public_key":
                        certType = certType.pub;
                        break;
                    case "create_selfSign":
                        certType = certType.selfSigned;
                        break;
                    case "create_sign":
                        certType = certType.signed;
                        break;
                }
            }
            TreeViewClick(sender, certType, wrapper);
        }
    }
    private void TreeViewClick(object sender, certType certType, TreeCertWrapper wrapper) //CustomClickEventArgs e
    {
        try
        {
            serverType serverType = wrapper.ServerType;
            string serverName = string.Empty;

            if (serverType == serverType.ca || serverType == serverType.intermediate || serverType == serverType.server || serverType == serverType.user)
            {
                PL.Certificate.Certificate cert = new PL.Certificate.Certificate();
                if (wrapper is TreeCertWrapper)
                { _cert = wrapper.Cert; }
                else
                {
                    MessageBox.Show("No certificate selected.");
                    return;
                }
                if (certType == certType.priv)
                {
                    _cert.keySize = DefaultValues._keySize;
                    if (Global.useDefault || (!Global.useDefault && new createEntry(_cert, serverType, createEntry.configType.keySize).ShowDialog() == DialogResult.OK))
                    {
                        Result<string> privateKeyPem = PL.Utils.Certs.GeneratePrivateKey(_cert.keySize);
                        if (privateKeyPem.IsSuccess)
                        {
                            _cert.private_key = privateKeyPem.Value;
                            if (!_writeFile || (_writeFile && new WriteFile(serverType, serverName, certType, wrapper.Cert).ShowDialog() == DialogResult.OK))
                            {
                                Result<int> insertRow = PL.Utils.Sql.Update(serverType, _cert, null, ["keySize", "private_key", "private_createDT"]);
                                if (insertRow.IsSuccess)
                                {
                                    LoadTreeView();
                                    MessageBox.Show($"Successfully inserted {insertRow} row(s) into the database and saved to the harddisk.");
                                }
                            }
                        }
                    }
                    else
                    { return; }
                }
                else if (certType == certType.pub)
                {
                    Result<string> publicCert = PL.Utils.Certs.GeneratePublicKey(_cert.name, _cert.private_key);
                    if (publicCert.IsSuccess)
                    {
                        _cert.public_cert = publicCert.Value;

                        if (!_writeFile || (_writeFile && new WriteFile(serverType, serverName, certType, wrapper.Cert).ShowDialog() == DialogResult.OK))
                        {
                            Result<int> insertRow = PL.Utils.Sql.Update(serverType, _cert, null, ["public_cert", "public_createDT"]);
                            if (insertRow.IsSuccess)
                            {
                                //PL.Utils.Tools.UpdateCertList(this, serverType, serverName); //load servers from SQL
                                LoadTreeView();
                                MessageBox.Show($"Successfully handled public key for {serverType} and saved to database and disk.");
                            }
                        }
                    }
                }
                else if (certType == certType.selfSigned)
                {
                    createEntry createEntry = new createEntry(_cert, serverType, createEntry.configType.selfSigned);
                    DialogResult dialogResult = createEntry.ShowDialog();
                    if (dialogResult != DialogResult.OK)
                    {
                        string s = string.Empty;
                    }
                    //Certificate selectedCaCert = Certificate.GetSelectedCert(this, serverType);
                    //selectedCaCert.ss_duration = Convert.ToInt32(tb_ca_dura.Text);
                    //Result<X509Certificate2> selfSigned = PL.Utils.Certs.GenerateSelfsigned(serverType.ca, selectedCaCert);
                    //if (selfSigned.IsSuccess)
                    //{
                    //    selectedCaCert.ss_cert = selfSigned.Value.Export(X509ContentType.Pfx, c_selfsignedPasswordPfx);
                    //    Result<int> insertRow = PL.Utils.Sql.Update(serverType, selectedCaCert, null, ["ss_cert", "ss_createDT", "serialNumber", "ss_duration"]);

                    //    if (!_writeFile) return;
                    //    Form writeFileForm = new WriteFile(serverType, serverName, certType, selectedCaCert);
                    //    writeFileForm.ShowDialog();

                    //    if (_certVerify) PL.Utils.Certs.CheckPrivateKey(selfSigned.Value);
                    //}
                }
                else if (certType == certType.signed)
                {
                    Certificate issuerCert = null;
                    if (serverType == serverType.intermediate)
                    {
                        issuerCert = Certificate.GetSelectedCert(this, serverType.ca);
                    }
                    else if (serverType == serverType.server || serverType == serverType.user)
                    {
                        issuerCert = Certificate.GetSelectedCert(this, serverType.intermediate);
                    }
                    if (issuerCert == null)
                    {
                        MessageBox.Show("No issuer certificate selected.");
                        return;
                    }
                    Certificate requesterCert = Certificate.GetSelectedCert(this, serverType);
                    requesterCert.ss_duration = PL.Utils.Tools.GetDuration(this, serverType);

                    Result<X509Certificate2> signedCert = PL.Utils.Certs.GenerateSigned(serverType, issuerCert, requesterCert);
                    if (signedCert.IsSuccess)
                    {
                        Result<int> insertRow = PL.Utils.Sql.Update(serverType, requesterCert, issuerCert, ["ss_cert", "ss_duration", "signed_createDT", "signed_against", "serialNumber"]);

                        if (!_writeFile) return;
                        Form writeFileForm = new WriteFile(serverType, serverName, certType, requesterCert);
                        writeFileForm.ShowDialog();
                        if (_certVerify) PL.Utils.Certs.CheckPrivateKey(signedCert.Value);
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
        { throw; }
    }

    #region contextMenuStrips
    #region contextMenuStrip new CA
    private void create_new_ca_MouseUp(object sender, MouseEventArgs e)
    {
        create_new_ca.Text = "";
        create_new_ca.Focus();
    }
    private void create_new_ca_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            TreeCertWrapper _treeCertWrapper = new TreeCertWrapper() { ServerType = create_new_ca.serverType, Cert = _cert };

            _treeCertWrapper.Cert.name = create_new_ca.Text.Trim();
            contextMenuStrip.Close();
            generateEntry(_treeCertWrapper);
            e.SuppressKeyPress = true;
            create_new_ca.Text = "CA";
        }
    }
    private void create_new_ca_FocusLost(object sender, EventArgs e)
    {
        create_new_ca.Text = "CA";
    }
    #endregion
    #region contextMenuStrip new intermediate

    #endregion
    #region contextMenuStrip new Server

    #endregion
    #region contextMenuStrip new User

    #endregion
    #endregion
    public class TreeCertWrapper
    {
        public serverType ServerType { get; set; }
        public Certificate Cert { get; set; }
    }

    private void testFormToolStripMenuItem_Click(object sender, EventArgs e)
    {
        // Einfacher OK-Dialog
        ////CustomMessageBox.Show("Alles erfolgreich gespeichert!", "OK");

        // Zwei Buttons (Ja / Nein)
        ////var res = CustomMessageBox.Show("Wollen Sie fortfahren?", MessageBoxIcon.Question, "Ja", "Nein");
        ////if (res == DialogResult.OK) MessageBox.Show("JA gedrückt");
        ////else MessageBox.Show("NEIN gedrückt");

        //// Drei Buttons
        //CustomMessageBox.Show("Welche Option möchten Sie?", MessageBoxIcon.Information, "Option 1", "Option 2", "Abbrechen");
        //eigener test

        //Dictionary<string, DialogResult> buttons = new Dictionary<string, DialogResult>
        //{
        //    { "Option 11", DialogResult.OK },
        //    { "Option 22", DialogResult.Cancel },
        //    { "Abbrechen33", DialogResult.Abort }
        //};
        Dictionary<string, CustomMessageBox.CustomDialogResult> buttons = new Dictionary<string, CustomMessageBox.CustomDialogResult>
        {
            { "Option 11", CustomMessageBox.CustomDialogResult.OK },
            { "Option 22", CustomMessageBox.CustomDialogResult.Cancel },
            { "Abbrechen33", CustomMessageBox.CustomDialogResult.SomethingElse }
        };
        //DialogResult dialog = CustomMessageBox.Show("Message string", MessageBoxIcon.Information, buttons);
        // MessageBox.Show($"{dialog}");
       string s = "Das ist string ";
        for (int i = 0; i < 2; i++)
        {
            s = s + s;
        }
					                
        CustomMessageBox.CustomDialogResult res = CustomMessageBox.Show($"{s}", $"title message", DefaultValues.ConBackCan_buttons);
       
    }
}


