namespace SCG.Forms;

partial class Server
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        tb_ca_name = new TextBox();
        lbl_ca_name = new Label();
        lb_ca_certs = new ListBox();
        cb_ca_keySize = new ComboBox();
        lbl_ca_keySize = new Label();
        tb_ca_dura = new TextBox();
        lbl_ca_duration = new Label();
        cb_new_ca = new CheckBox();
        lb_int_certs = new ListBox();
        lbl_int_keySize = new Label();
        cb_int_keySize = new ComboBox();
        tb_int_dura = new TextBox();
        lbl_int_duration = new Label();
        tb_int_name = new TextBox();
        lbl_int_name = new Label();
        cb_new_int = new CheckBox();
        cb_new_server = new CheckBox();
        tb_server_name = new TextBox();
        lbl_server_name = new Label();
        lbl_server_keySize = new Label();
        cb_server_keySize = new ComboBox();
        tb_server_dura = new TextBox();
        lbl_server_duration = new Label();
        lb_server_certs = new ListBox();
        cb_new_user = new CheckBox();
        tb_user_name = new TextBox();
        lbl_user_name = new Label();
        lbl_user_keySize = new Label();
        cb_user_keySize = new ComboBox();
        tb_user_dura = new TextBox();
        lbl_user_duration = new Label();
        lb_user_certs = new ListBox();
        Tb_priv_filename = new TextBox();
        Lbl_filename_priv = new Label();
        Lbl_fileExtension_priv = new Label();
        Cb_priv_fileext = new ComboBox();
        Lbl_fileExtension_pub = new Label();
        Cb_pub_fileext = new ComboBox();
        Tb_pub_remPath = new TextBox();
        menuStrip1 = new MenuStrip();
        editToolStripMenuItem = new ToolStripMenuItem();
        ms_edit_config = new ToolStripMenuItem();
        testFormToolStripMenuItem = new ToolStripMenuItem();
        Lb_cert_remotePath = new Label();
        Lbl_remotePath_pub = new GroupBox();
        Tb_pub_filename = new TextBox();
        Lbl_filename_pub = new Label();
        Lbl_remotePath_priv = new Label();
        Tb_priv_remPath = new TextBox();
        saveFileDialog1 = new SaveFileDialog();
        Gb_serverCredentials = new GroupBox();
        Cb_autoUpload = new CheckBox();
        Tb_password_nd = new TextBox();
        Tb_password_st = new TextBox();
        Tb_username = new TextBox();
        Tb_hostname = new TextBox();
        Lb_password = new Label();
        Lb_username = new Label();
        Lb_hostname = new Label();
        CertificateTree = new TreeView();
        CertificateTreeImages = new ImageList(components);
        contextMenuStrip = new ContextMenuStrip(components);
        createMenu = new ToolStripMenuItem();
        create_private_key = new ExtendedToolStripMenuItem();
        toolStripSeparator1 = new ToolStripSeparator();
        create_public_key = new ExtendedToolStripMenuItem();
        create_selfSign = new ToolStripMenuItem();
        create_sign = new ToolStripMenuItem();
        create_new = new ToolStripMenuItem();
        create_new_ca = new ExtendedToolStripTextBox();
        create_new_intermediate = new ToolStripTextBox();
        create_new_server = new ToolStripTextBox();
        create_new_user = new ToolStripMenuItem();
        viewToolStripMenuItem = new ToolStripMenuItem();
        view_private_key = new ToolStripMenuItem();
        view_public_key = new ToolStripMenuItem();
        view_fqdn = new ToolStripMenuItem();
        view_san = new ToolStripMenuItem();
        view_self_signed = new ToolStripMenuItem();
        certificateInformationMenuItem1 = new ToolStripMenuItem();
        dNToolStripMenuItem = new ToolStripMenuItem();
        readToolStripMenuItem = new ToolStripMenuItem();
        writeToolStripMenuItem = new ToolStripMenuItem();
        bindingSource1 = new BindingSource(components);
        customButton1 = new CustomButton();
        menuStrip1.SuspendLayout();
        Lbl_remotePath_pub.SuspendLayout();
        Gb_serverCredentials.SuspendLayout();
        contextMenuStrip.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
        SuspendLayout();


        // 
        // tb_ca_name
        // 
        tb_ca_name.Location = new Point(90, 138);
        tb_ca_name.Name = "tb_ca_name";
        tb_ca_name.Size = new Size(100, 23);
        tb_ca_name.TabIndex = 12;
        // 
        // lbl_ca_name
        // 
        lbl_ca_name.AutoSize = true;
        lbl_ca_name.Location = new Point(7, 140);
        lbl_ca_name.Name = "lbl_ca_name";
        lbl_ca_name.Size = new Size(77, 15);
        lbl_ca_name.TabIndex = 10;
        lbl_ca_name.Text = "Server Name:";
        // 
        // lb_ca_certs
        // 
        lb_ca_certs.FormattingEnabled = true;
        lb_ca_certs.ItemHeight = 15;
        lb_ca_certs.Location = new Point(66, 26);
        lb_ca_certs.Margin = new Padding(2);
        lb_ca_certs.Name = "lb_ca_certs";
        lb_ca_certs.Size = new Size(124, 79);
        lb_ca_certs.TabIndex = 14;
        // 
        // cb_ca_keySize
        // 
        cb_ca_keySize.FormattingEnabled = true;
        cb_ca_keySize.Items.AddRange(new object[] { "2048", "4096", "8192" });
        cb_ca_keySize.Location = new Point(90, 166);
        cb_ca_keySize.Name = "cb_ca_keySize";
        cb_ca_keySize.Size = new Size(100, 23);
        cb_ca_keySize.TabIndex = 24;
        cb_ca_keySize.Text = "4096";
        // 
        // lbl_ca_keySize
        // 
        lbl_ca_keySize.AutoSize = true;
        lbl_ca_keySize.Location = new Point(39, 169);
        lbl_ca_keySize.Name = "lbl_ca_keySize";
        lbl_ca_keySize.Size = new Size(45, 15);
        lbl_ca_keySize.TabIndex = 0;
        lbl_ca_keySize.Text = "Keysize";
        lbl_ca_keySize.TextAlign = ContentAlignment.TopRight;
        // 
        // tb_ca_dura
        // 
        tb_ca_dura.Location = new Point(90, 196);
        tb_ca_dura.Name = "tb_ca_dura";
        tb_ca_dura.Size = new Size(100, 23);
        tb_ca_dura.TabIndex = 4;
        tb_ca_dura.Text = "120";
        // 
        // lbl_ca_duration
        // 
        lbl_ca_duration.AutoSize = true;
        lbl_ca_duration.Location = new Point(31, 200);
        lbl_ca_duration.Name = "lbl_ca_duration";
        lbl_ca_duration.Size = new Size(53, 15);
        lbl_ca_duration.TabIndex = 0;
        lbl_ca_duration.Text = "Duration";
        // 
        // cb_new_ca
        // 
        cb_new_ca.AutoSize = true;
        cb_new_ca.Location = new Point(90, 113);
        cb_new_ca.Name = "cb_new_ca";
        cb_new_ca.Size = new Size(85, 19);
        cb_new_ca.TabIndex = 17;
        cb_new_ca.Text = "New Server";
        cb_new_ca.UseVisualStyleBackColor = true;
        cb_new_ca.CheckedChanged += cb_new_ca_CheckedChanged;
        // 
        // lb_int_certs
        // 
        lb_int_certs.FormattingEnabled = true;
        lb_int_certs.ItemHeight = 15;
        lb_int_certs.Location = new Point(320, 26);
        lb_int_certs.Name = "lb_int_certs";
        lb_int_certs.Size = new Size(120, 79);
        lb_int_certs.TabIndex = 32;
        // 
        // lbl_int_keySize
        // 
        lbl_int_keySize.AutoSize = true;
        lbl_int_keySize.Location = new Point(289, 168);
        lbl_int_keySize.Name = "lbl_int_keySize";
        lbl_int_keySize.Size = new Size(45, 15);
        lbl_int_keySize.TabIndex = 34;
        lbl_int_keySize.Text = "Keysize";
        // 
        // cb_int_keySize
        // 
        cb_int_keySize.FormattingEnabled = true;
        cb_int_keySize.Items.AddRange(new object[] { "2048", "4096", "8192" });
        cb_int_keySize.Location = new Point(340, 166);
        cb_int_keySize.Name = "cb_int_keySize";
        cb_int_keySize.Size = new Size(100, 23);
        cb_int_keySize.TabIndex = 37;
        cb_int_keySize.Text = "4096";
        // 
        // tb_int_dura
        // 
        tb_int_dura.Location = new Point(340, 195);
        tb_int_dura.Name = "tb_int_dura";
        tb_int_dura.Size = new Size(100, 23);
        tb_int_dura.TabIndex = 36;
        tb_int_dura.Text = "60";
        // 
        // lbl_int_duration
        // 
        lbl_int_duration.AutoSize = true;
        lbl_int_duration.Location = new Point(281, 200);
        lbl_int_duration.Name = "lbl_int_duration";
        lbl_int_duration.Size = new Size(53, 15);
        lbl_int_duration.TabIndex = 35;
        lbl_int_duration.Text = "Duration";
        // 
        // tb_int_name
        // 
        tb_int_name.Location = new Point(340, 138);
        tb_int_name.Name = "tb_int_name";
        tb_int_name.Size = new Size(100, 23);
        tb_int_name.TabIndex = 39;
        // 
        // lbl_int_name
        // 
        lbl_int_name.AutoSize = true;
        lbl_int_name.Location = new Point(222, 140);
        lbl_int_name.Name = "lbl_int_name";
        lbl_int_name.Size = new Size(112, 15);
        lbl_int_name.TabIndex = 38;
        lbl_int_name.Text = "Intermediate Name:";
        // 
        // cb_new_int
        // 
        cb_new_int.AutoSize = true;
        cb_new_int.Location = new Point(320, 113);
        cb_new_int.Name = "cb_new_int";
        cb_new_int.Size = new Size(120, 19);
        cb_new_int.TabIndex = 40;
        cb_new_int.Text = "New Intermediate";
        cb_new_int.UseVisualStyleBackColor = true;
        cb_new_int.CheckedChanged += cb_new_inter_CheckedChanged;
        // 
        // cb_new_server
        // 
        cb_new_server.AutoSize = true;
        cb_new_server.Location = new Point(550, 113);
        cb_new_server.Name = "cb_new_server";
        cb_new_server.Size = new Size(85, 19);
        cb_new_server.TabIndex = 55;
        cb_new_server.Text = "New Server";
        cb_new_server.TextAlign = ContentAlignment.MiddleRight;
        cb_new_server.UseVisualStyleBackColor = true;
        cb_new_server.CheckedChanged += cb_new_server_CheckedChanged;
        // 
        // tb_server_name
        // 
        tb_server_name.Location = new Point(570, 138);
        tb_server_name.Name = "tb_server_name";
        tb_server_name.Size = new Size(100, 23);
        tb_server_name.TabIndex = 54;
        // 
        // lbl_server_name
        // 
        lbl_server_name.AutoSize = true;
        lbl_server_name.Location = new Point(487, 141);
        lbl_server_name.Name = "lbl_server_name";
        lbl_server_name.Size = new Size(77, 15);
        lbl_server_name.TabIndex = 53;
        lbl_server_name.Text = "Server Name:";
        // 
        // lbl_server_keySize
        // 
        lbl_server_keySize.AutoSize = true;
        lbl_server_keySize.Location = new Point(519, 169);
        lbl_server_keySize.Name = "lbl_server_keySize";
        lbl_server_keySize.Size = new Size(45, 15);
        lbl_server_keySize.TabIndex = 49;
        lbl_server_keySize.Text = "Keysize";
        // 
        // cb_server_keySize
        // 
        cb_server_keySize.FormattingEnabled = true;
        cb_server_keySize.Items.AddRange(new object[] { "2048", "4096", "8192" });
        cb_server_keySize.Location = new Point(570, 166);
        cb_server_keySize.Name = "cb_server_keySize";
        cb_server_keySize.Size = new Size(100, 23);
        cb_server_keySize.TabIndex = 52;
        cb_server_keySize.Text = "4096";
        // 
        // tb_server_dura
        // 
        tb_server_dura.Location = new Point(570, 195);
        tb_server_dura.Name = "tb_server_dura";
        tb_server_dura.Size = new Size(100, 23);
        tb_server_dura.TabIndex = 51;
        tb_server_dura.Text = "30";
        // 
        // lbl_server_duration
        // 
        lbl_server_duration.AutoSize = true;
        lbl_server_duration.Location = new Point(511, 200);
        lbl_server_duration.Name = "lbl_server_duration";
        lbl_server_duration.Size = new Size(53, 15);
        lbl_server_duration.TabIndex = 50;
        lbl_server_duration.Text = "Duration";
        // 
        // lb_server_certs
        // 
        lb_server_certs.FormattingEnabled = true;
        lb_server_certs.ItemHeight = 15;
        lb_server_certs.Location = new Point(550, 26);
        lb_server_certs.Name = "lb_server_certs";
        lb_server_certs.Size = new Size(120, 79);
        lb_server_certs.TabIndex = 47;
        // 
        // cb_new_user
        // 
        cb_new_user.AutoSize = true;
        cb_new_user.Location = new Point(764, 113);
        cb_new_user.Name = "cb_new_user";
        cb_new_user.Size = new Size(76, 19);
        cb_new_user.TabIndex = 67;
        cb_new_user.Text = "New User";
        cb_new_user.TextAlign = ContentAlignment.MiddleRight;
        cb_new_user.UseVisualStyleBackColor = true;
        cb_new_user.CheckedChanged += cb_new_user_CheckedChanged;
        // 
        // tb_user_name
        // 
        tb_user_name.Location = new Point(784, 138);
        tb_user_name.Name = "tb_user_name";
        tb_user_name.Size = new Size(100, 23);
        tb_user_name.TabIndex = 66;
        // 
        // lbl_user_name
        // 
        lbl_user_name.AutoSize = true;
        lbl_user_name.Location = new Point(710, 141);
        lbl_user_name.Name = "lbl_user_name";
        lbl_user_name.Size = new Size(68, 15);
        lbl_user_name.TabIndex = 65;
        lbl_user_name.Text = "User Name:";
        lbl_user_name.TextAlign = ContentAlignment.TopRight;
        // 
        // lbl_user_keySize
        // 
        lbl_user_keySize.AutoSize = true;
        lbl_user_keySize.Location = new Point(733, 169);
        lbl_user_keySize.Name = "lbl_user_keySize";
        lbl_user_keySize.Size = new Size(45, 15);
        lbl_user_keySize.TabIndex = 61;
        lbl_user_keySize.Text = "Keysize";
        // 
        // cb_user_keySize
        // 
        cb_user_keySize.FormattingEnabled = true;
        cb_user_keySize.Items.AddRange(new object[] { "2048", "4096", "8192" });
        cb_user_keySize.Location = new Point(784, 166);
        cb_user_keySize.Name = "cb_user_keySize";
        cb_user_keySize.Size = new Size(100, 23);
        cb_user_keySize.TabIndex = 64;
        cb_user_keySize.Text = "4096";
        // 
        // tb_user_dura
        // 
        tb_user_dura.Location = new Point(784, 195);
        tb_user_dura.Name = "tb_user_dura";
        tb_user_dura.Size = new Size(100, 23);
        tb_user_dura.TabIndex = 63;
        tb_user_dura.Text = "30";
        // 
        // lbl_user_duration
        // 
        lbl_user_duration.AutoSize = true;
        lbl_user_duration.Location = new Point(725, 200);
        lbl_user_duration.Name = "lbl_user_duration";
        lbl_user_duration.Size = new Size(53, 15);
        lbl_user_duration.TabIndex = 62;
        lbl_user_duration.Text = "Duration";
        // 
        // lb_user_certs
        // 
        lb_user_certs.FormattingEnabled = true;
        lb_user_certs.ItemHeight = 15;
        lb_user_certs.Location = new Point(764, 26);
        lb_user_certs.Name = "lb_user_certs";
        lb_user_certs.Size = new Size(120, 79);
        lb_user_certs.TabIndex = 59;
        // 
        // Tb_priv_filename
        // 
        Tb_priv_filename.Location = new Point(121, 22);
        Tb_priv_filename.Name = "Tb_priv_filename";
        Tb_priv_filename.Size = new Size(102, 23);
        Tb_priv_filename.TabIndex = 86;
        // 
        // Lbl_filename_priv
        // 
        Lbl_filename_priv.AutoSize = true;
        Lbl_filename_priv.Location = new Point(60, 25);
        Lbl_filename_priv.Name = "Lbl_filename_priv";
        Lbl_filename_priv.Size = new Size(55, 15);
        Lbl_filename_priv.TabIndex = 87;
        Lbl_filename_priv.Text = "Filename";
        // 
        // Lbl_fileExtension_priv
        // 
        Lbl_fileExtension_priv.AutoSize = true;
        Lbl_fileExtension_priv.Location = new Point(48, 57);
        Lbl_fileExtension_priv.Name = "Lbl_fileExtension_priv";
        Lbl_fileExtension_priv.Size = new Size(67, 15);
        Lbl_fileExtension_priv.TabIndex = 88;
        Lbl_fileExtension_priv.Text = "File Ext Priv";
        // 
        // Cb_priv_fileext
        // 
        Cb_priv_fileext.FormattingEnabled = true;
        Cb_priv_fileext.Items.AddRange(new object[] { "pfx", "pem", "crt", "cer", "der", "" });
        Cb_priv_fileext.Location = new Point(121, 54);
        Cb_priv_fileext.Name = "Cb_priv_fileext";
        Cb_priv_fileext.Size = new Size(102, 23);
        Cb_priv_fileext.TabIndex = 89;
        // 
        // Lbl_fileExtension_pub
        // 
        Lbl_fileExtension_pub.AutoSize = true;
        Lbl_fileExtension_pub.Location = new Point(40, 154);
        Lbl_fileExtension_pub.Name = "Lbl_fileExtension_pub";
        Lbl_fileExtension_pub.Size = new Size(80, 15);
        Lbl_fileExtension_pub.TabIndex = 90;
        Lbl_fileExtension_pub.Text = "File Ext Public";
        // 
        // Cb_pub_fileext
        // 
        Cb_pub_fileext.FormattingEnabled = true;
        Cb_pub_fileext.Items.AddRange(new object[] { "cer", "der", "crt" });
        Cb_pub_fileext.Location = new Point(121, 151);
        Cb_pub_fileext.Name = "Cb_pub_fileext";
        Cb_pub_fileext.Size = new Size(101, 23);
        Cb_pub_fileext.TabIndex = 91;
        // 
        // Tb_pub_remPath
        // 
        Tb_pub_remPath.Location = new Point(121, 180);
        Tb_pub_remPath.Name = "Tb_pub_remPath";
        Tb_pub_remPath.Size = new Size(102, 23);
        Tb_pub_remPath.TabIndex = 92;
        // 
        // menuStrip1
        // 
        menuStrip1.ImageScalingSize = new Size(28, 28);
        menuStrip1.Items.AddRange(new ToolStripItem[] { editToolStripMenuItem });
        menuStrip1.Location = new Point(0, 0);
        menuStrip1.Name = "menuStrip1";
        menuStrip1.Size = new Size(1197, 24);
        menuStrip1.TabIndex = 94;
        menuStrip1.Text = "menuStrip1";
        // 
        // editToolStripMenuItem
        // 
        editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ms_edit_config, testFormToolStripMenuItem });
        editToolStripMenuItem.Name = "editToolStripMenuItem";
        editToolStripMenuItem.Size = new Size(39, 20);
        editToolStripMenuItem.Text = "Edit";
        // 
        // ms_edit_config
        // 
        ms_edit_config.Name = "ms_edit_config";
        ms_edit_config.Size = new Size(121, 22);
        ms_edit_config.Text = "Config";
        ms_edit_config.Click += edit_config_load;
        // 
        // testFormToolStripMenuItem
        // 
        testFormToolStripMenuItem.Name = "testFormToolStripMenuItem";
        testFormToolStripMenuItem.Size = new Size(121, 22);
        testFormToolStripMenuItem.Text = "testForm";
        testFormToolStripMenuItem.Click += testFormToolStripMenuItem_Click;
        // 
        // Lb_cert_remotePath
        // 
        Lb_cert_remotePath.AutoSize = true;
        Lb_cert_remotePath.Location = new Point(43, 183);
        Lb_cert_remotePath.Name = "Lb_cert_remotePath";
        Lb_cert_remotePath.Size = new Size(75, 15);
        Lb_cert_remotePath.TabIndex = 95;
        Lb_cert_remotePath.Text = "Remote Path";
        // 
        // Lbl_remotePath_pub
        // 
        Lbl_remotePath_pub.Controls.Add(Tb_pub_filename);
        Lbl_remotePath_pub.Controls.Add(Lbl_filename_pub);
        Lbl_remotePath_pub.Controls.Add(Lbl_remotePath_priv);
        Lbl_remotePath_pub.Controls.Add(Tb_priv_remPath);
        Lbl_remotePath_pub.Controls.Add(Tb_priv_filename);
        Lbl_remotePath_pub.Controls.Add(Lbl_filename_priv);
        Lbl_remotePath_pub.Controls.Add(Lbl_fileExtension_priv);
        Lbl_remotePath_pub.Controls.Add(Lb_cert_remotePath);
        Lbl_remotePath_pub.Controls.Add(Cb_priv_fileext);
        Lbl_remotePath_pub.Controls.Add(Lbl_fileExtension_pub);
        Lbl_remotePath_pub.Controls.Add(Tb_pub_remPath);
        Lbl_remotePath_pub.Controls.Add(Cb_pub_fileext);
        Lbl_remotePath_pub.ImeMode = ImeMode.KatakanaHalf;
        Lbl_remotePath_pub.Location = new Point(12, 359);
        Lbl_remotePath_pub.Name = "Lbl_remotePath_pub";
        Lbl_remotePath_pub.Size = new Size(229, 219);
        Lbl_remotePath_pub.TabIndex = 98;
        Lbl_remotePath_pub.TabStop = false;
        Lbl_remotePath_pub.Text = "Certificate information";
        // 
        // Tb_pub_filename
        // 
        Tb_pub_filename.Location = new Point(121, 122);
        Tb_pub_filename.Name = "Tb_pub_filename";
        Tb_pub_filename.Size = new Size(102, 23);
        Tb_pub_filename.TabIndex = 99;
        // 
        // Lbl_filename_pub
        // 
        Lbl_filename_pub.AutoSize = true;
        Lbl_filename_pub.Location = new Point(60, 125);
        Lbl_filename_pub.Name = "Lbl_filename_pub";
        Lbl_filename_pub.Size = new Size(55, 15);
        Lbl_filename_pub.TabIndex = 100;
        Lbl_filename_pub.Text = "Filename";
        // 
        // Lbl_remotePath_priv
        // 
        Lbl_remotePath_priv.AutoSize = true;
        Lbl_remotePath_priv.Location = new Point(40, 87);
        Lbl_remotePath_priv.Name = "Lbl_remotePath_priv";
        Lbl_remotePath_priv.Size = new Size(75, 15);
        Lbl_remotePath_priv.TabIndex = 98;
        Lbl_remotePath_priv.Text = "Remote Path";
        // 
        // Tb_priv_remPath
        // 
        Tb_priv_remPath.Location = new Point(121, 82);
        Tb_priv_remPath.Name = "Tb_priv_remPath";
        Tb_priv_remPath.Size = new Size(102, 23);
        Tb_priv_remPath.TabIndex = 97;
        // 
        // Gb_serverCredentials
        // 
        Gb_serverCredentials.Controls.Add(Cb_autoUpload);
        Gb_serverCredentials.Controls.Add(Tb_password_nd);
        Gb_serverCredentials.Controls.Add(Tb_password_st);
        Gb_serverCredentials.Controls.Add(Tb_username);
        Gb_serverCredentials.Controls.Add(Tb_hostname);
        Gb_serverCredentials.Controls.Add(Lb_password);
        Gb_serverCredentials.Controls.Add(Lb_username);
        Gb_serverCredentials.Controls.Add(Lb_hostname);
        Gb_serverCredentials.Location = new Point(27, 584);
        Gb_serverCredentials.Name = "Gb_serverCredentials";
        Gb_serverCredentials.Size = new Size(200, 175);
        Gb_serverCredentials.TabIndex = 133;
        Gb_serverCredentials.TabStop = false;
        Gb_serverCredentials.Text = "Server Credentials";
        // 
        // Cb_autoUpload
        // 
        Cb_autoUpload.AutoSize = true;
        Cb_autoUpload.CheckAlign = ContentAlignment.MiddleRight;
        Cb_autoUpload.Location = new Point(6, 146);
        Cb_autoUpload.Name = "Cb_autoUpload";
        Cb_autoUpload.Size = new Size(96, 19);
        Cb_autoUpload.TabIndex = 136;
        Cb_autoUpload.Text = "Auto Upload:";
        Cb_autoUpload.TextAlign = ContentAlignment.MiddleRight;
        Cb_autoUpload.TextImageRelation = TextImageRelation.TextBeforeImage;
        Cb_autoUpload.UseVisualStyleBackColor = true;
        // 
        // Tb_password_nd
        // 
        Tb_password_nd.Location = new Point(85, 114);
        Tb_password_nd.MaxLength = 100;
        Tb_password_nd.Name = "Tb_password_nd";
        Tb_password_nd.Size = new Size(100, 23);
        Tb_password_nd.TabIndex = 135;
        Tb_password_nd.UseSystemPasswordChar = true;
        // 
        // Tb_password_st
        // 
        Tb_password_st.Location = new Point(85, 85);
        Tb_password_st.MaxLength = 100;
        Tb_password_st.Name = "Tb_password_st";
        Tb_password_st.Size = new Size(100, 23);
        Tb_password_st.TabIndex = 134;
        Tb_password_st.UseSystemPasswordChar = true;
        // 
        // Tb_username
        // 
        Tb_username.Location = new Point(85, 56);
        Tb_username.Name = "Tb_username";
        Tb_username.Size = new Size(100, 23);
        Tb_username.TabIndex = 4;
        // 
        // Tb_hostname
        // 
        Tb_hostname.Location = new Point(85, 27);
        Tb_hostname.Name = "Tb_hostname";
        Tb_hostname.Size = new Size(100, 23);
        Tb_hostname.TabIndex = 3;
        // 
        // Lb_password
        // 
        Lb_password.AutoSize = true;
        Lb_password.Location = new Point(14, 93);
        Lb_password.Name = "Lb_password";
        Lb_password.Size = new Size(60, 15);
        Lb_password.TabIndex = 2;
        Lb_password.Text = "Password:";
        Lb_password.TextAlign = ContentAlignment.TopRight;
        // 
        // Lb_username
        // 
        Lb_username.AutoSize = true;
        Lb_username.Location = new Point(11, 64);
        Lb_username.Name = "Lb_username";
        Lb_username.Size = new Size(63, 15);
        Lb_username.TabIndex = 1;
        Lb_username.Text = "Username:";
        Lb_username.TextAlign = ContentAlignment.TopRight;
        // 
        // Lb_hostname
        // 
        Lb_hostname.AutoSize = true;
        Lb_hostname.Location = new Point(9, 35);
        Lb_hostname.Name = "Lb_hostname";
        Lb_hostname.Size = new Size(65, 15);
        Lb_hostname.TabIndex = 0;
        Lb_hostname.Text = "Hostname:";
        Lb_hostname.TextAlign = ContentAlignment.TopRight;
        // 
        // CertificateTree
        // 
        CertificateTree.Font = new Font("Segoe UI", 20F);
        CertificateTree.ImageIndex = 0;
        CertificateTree.ImageList = CertificateTreeImages;
        CertificateTree.Location = new Point(800, 367);
        CertificateTree.Name = "CertificateTree";
        CertificateTree.SelectedImageIndex = 0;
        CertificateTree.Size = new Size(385, 296);
        CertificateTree.TabIndex = 137;
        CertificateTree.MouseUp += contextMenuStrip_MouseUp;
        // 
        // CertificateTreeImages
        // 
        CertificateTreeImages.ColorDepth = ColorDepth.Depth32Bit;
        CertificateTreeImages.ImageSize = new Size(50, 50);
        CertificateTreeImages.TransparentColor = Color.Transparent;
        // 
        // contextMenuStrip
        // 
        contextMenuStrip.ImageScalingSize = new Size(20, 20);
        contextMenuStrip.Items.AddRange(new ToolStripItem[] { createMenu, viewToolStripMenuItem, certificateInformationMenuItem1 });
        contextMenuStrip.Name = "CAcontextMenuStrip";
        contextMenuStrip.Size = new Size(195, 70);
        // 
        // createMenu
        // 
        createMenu.DropDownItems.AddRange(new ToolStripItem[] { create_private_key, toolStripSeparator1, create_public_key, create_selfSign, create_sign, create_new });
        createMenu.Name = "createMenu";
        createMenu.Size = new Size(194, 22);
        createMenu.Text = "Create";
        // 
        // create_private_key
        // 
        create_private_key.Name = "create_private_key";
        create_private_key.serverType = PL.Utils.Tools.serverType.ca;
        create_private_key.Size = new Size(132, 22);
        create_private_key.Text = "Private Key";
        create_private_key.Click += ToolStripClick;
        // 
        // toolStripSeparator1
        // 
        toolStripSeparator1.Name = "toolStripSeparator1";
        toolStripSeparator1.Size = new Size(129, 6);
        // 
        // create_public_key
        // 
        create_public_key.Name = "create_public_key";
        create_public_key.serverType = PL.Utils.Tools.serverType.ca;
        create_public_key.Size = new Size(132, 22);
        create_public_key.Text = "Public Key";
        create_public_key.Click += ToolStripClick;
        // 
        // create_selfSign
        // 
        create_selfSign.Name = "create_selfSign";
        create_selfSign.Size = new Size(132, 22);
        create_selfSign.Text = "Self Sign";
        create_selfSign.Click += ToolStripClick;
        // 
        // create_sign
        // 
        create_sign.Name = "create_sign";
        create_sign.Size = new Size(132, 22);
        create_sign.Text = "Sign";
        create_sign.Click += ToolStripClick;
        // 
        // create_new
        // 
        create_new.DropDownItems.AddRange(new ToolStripItem[] { create_new_ca, create_new_intermediate, create_new_server, create_new_user });
        create_new.Name = "create_new";
        create_new.Size = new Size(132, 22);
        create_new.Text = "New";
        // 
        // create_new_ca
        // 
        create_new_ca.Name = "create_new_ca";
        create_new_ca.serverType = PL.Utils.Tools.serverType.ca;
        create_new_ca.Size = new Size(360, 23);
        create_new_ca.Text = "CA";
        create_new_ca.KeyDown += create_new_ca_KeyDown;
        create_new_ca.MouseUp += create_new_ca_MouseUp;
        // 
        // create_new_intermediate
        // 
        create_new_intermediate.Name = "create_new_intermediate";
        create_new_intermediate.Size = new Size(240, 23);
        create_new_intermediate.Text = "Intermediate";
        // 
        // create_new_server
        // 
        create_new_server.Name = "create_new_server";
        create_new_server.Size = new Size(300, 23);
        create_new_server.Text = "Server";
        // 
        // create_new_user
        // 
        create_new_user.Name = "create_new_user";
        create_new_user.Size = new Size(420, 22);
        create_new_user.Text = "User";
        // 
        // viewToolStripMenuItem
        // 
        viewToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { view_private_key, view_public_key, view_fqdn, view_san, view_self_signed });
        viewToolStripMenuItem.Name = "viewToolStripMenuItem";
        viewToolStripMenuItem.Size = new Size(194, 22);
        viewToolStripMenuItem.Text = "View";
        // 
        // view_private_key
        // 
        view_private_key.Name = "view_private_key";
        view_private_key.Size = new Size(134, 22);
        view_private_key.Text = "Private Key";
        view_private_key.Click += View_Keys;
        // 
        // view_public_key
        // 
        view_public_key.Name = "view_public_key";
        view_public_key.Size = new Size(134, 22);
        view_public_key.Text = "Public Key";
        view_public_key.Click += View_Keys;
        // 
        // view_fqdn
        // 
        view_fqdn.Name = "view_fqdn";
        view_fqdn.Size = new Size(134, 22);
        view_fqdn.Text = "FQDN";
        view_fqdn.Click += View_Keys;
        // 
        // view_san
        // 
        view_san.Name = "view_san";
        view_san.Size = new Size(134, 22);
        view_san.Text = "SAN";
        view_san.Click += View_Keys;
        // 
        // view_self_signed
        // 
        view_self_signed.Name = "view_self_signed";
        view_self_signed.Size = new Size(134, 22);
        view_self_signed.Text = "Self-Signed";
        view_self_signed.Click += View_Keys;
        // 
        // certificateInformationMenuItem1
        // 
        certificateInformationMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { dNToolStripMenuItem });
        certificateInformationMenuItem1.Name = "certificateInformationMenuItem1";
        certificateInformationMenuItem1.Size = new Size(194, 22);
        certificateInformationMenuItem1.Text = "Certificate Information";
        // 
        // dNToolStripMenuItem
        // 
        dNToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { readToolStripMenuItem, writeToolStripMenuItem });
        dNToolStripMenuItem.Name = "dNToolStripMenuItem";
        dNToolStripMenuItem.Size = new Size(91, 22);
        dNToolStripMenuItem.Text = "DN";
        // 
        // readToolStripMenuItem
        // 
        readToolStripMenuItem.Name = "readToolStripMenuItem";
        readToolStripMenuItem.Size = new Size(102, 22);
        readToolStripMenuItem.Text = "Read";
        // 
        // writeToolStripMenuItem
        // 
        writeToolStripMenuItem.Name = "writeToolStripMenuItem";
        writeToolStripMenuItem.Size = new Size(102, 22);
        writeToolStripMenuItem.Text = "Write";
        // 
        // customButton1
        // 
        customButton1._certInfo = PL.Utils.Tools.info.CertInfoWrite;
        customButton1._certType = PL.Utils.Tools.certType.priv;
        customButton1._fqdnType = PL.Utils.Tools.fdqnType.write;
        customButton1._serverType = PL.Utils.Tools.serverType.ca;
        customButton1.Location = new Point(500, 400);
        customButton1.Name = "customButton1";
        customButton1.Size = new Size(75, 23);
        customButton1.TabIndex = 138;
        customButton1.Text = "customButton1";
        customButton1.UseVisualStyleBackColor = true;
        // 
        // Server
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1197, 710);
        Controls.Add(customButton1);
        Controls.Add(CertificateTree);
        Controls.Add(Gb_serverCredentials);
        Controls.Add(Lbl_remotePath_pub);
        Controls.Add(menuStrip1);
        Controls.Add(cb_new_user);
        Controls.Add(tb_user_name);
        Controls.Add(lbl_user_name);
        Controls.Add(lbl_user_keySize);
        Controls.Add(cb_user_keySize);
        Controls.Add(tb_user_dura);
        Controls.Add(lbl_user_duration);
        Controls.Add(lb_user_certs);
        Controls.Add(cb_new_server);
        Controls.Add(tb_server_name);
        Controls.Add(lbl_server_name);
        Controls.Add(lbl_server_keySize);
        Controls.Add(cb_server_keySize);
        Controls.Add(tb_server_dura);
        Controls.Add(lbl_server_duration);
        Controls.Add(lb_server_certs);
        Controls.Add(cb_new_int);
        Controls.Add(tb_int_name);
        Controls.Add(lbl_int_name);
        Controls.Add(lbl_int_keySize);
        Controls.Add(cb_int_keySize);
        Controls.Add(tb_int_dura);
        Controls.Add(lbl_int_duration);
        Controls.Add(lb_int_certs);
        Controls.Add(lbl_ca_keySize);
        Controls.Add(cb_ca_keySize);
        Controls.Add(tb_ca_dura);
        Controls.Add(lbl_ca_duration);
        Controls.Add(cb_new_ca);
        Controls.Add(lb_ca_certs);
        Controls.Add(tb_ca_name);
        Controls.Add(lbl_ca_name);
        MainMenuStrip = menuStrip1;
        Margin = new Padding(2);
        Name = "Server";
        Text = "server";
        Load += server_onLoad;
        menuStrip1.ResumeLayout(false);
        menuStrip1.PerformLayout();
        Lbl_remotePath_pub.ResumeLayout(false);
        Lbl_remotePath_pub.PerformLayout();
        Gb_serverCredentials.ResumeLayout(false);
        Gb_serverCredentials.PerformLayout();
        contextMenuStrip.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion
    public CustomButton cB;
    public TextBox tb_ca_name;
    private Label lbl_ca_name;
    private Label lbl_ca_keySize;
    public TextBox tb_ca_dura;
    private Label lbl_ca_duration;
    public CheckBox cb_new_ca;
    public ComboBox cb_ca_keySize;
    public ListBox lb_int_certs;
    private Label lbl_int_keySize;
    public ComboBox cb_int_keySize;
    public TextBox tb_int_dura;
    private Label lbl_int_duration;
    public TextBox tb_int_name;
    private Label lbl_int_name;
    public CheckBox cb_new_int;
    public CheckBox cb_new_server;
    public TextBox tb_server_name;
    private Label lbl_server_name;
    private Label lbl_server_keySize;
    public ComboBox cb_server_keySize;
    public TextBox tb_server_dura;
    private Label lbl_server_duration;
    public ListBox lb_server_certs;
    private CheckBox cb_new_user;
    public TextBox tb_user_name;
    private Label lbl_user_name;
    private Label lbl_user_keySize;
    public ComboBox cb_user_keySize;
    public TextBox tb_user_dura;
    private Label lbl_user_duration;
    public ListBox lb_user_certs;
    public TextBox Tb_priv_filename;
    private Label Lbl_filename_priv;
    private Label Lbl_fileExtension_priv;
    private ComboBox Cb_priv_fileext;
    private Label Lbl_fileExtension_pub;
    private ComboBox Cb_pub_fileext;
    public TextBox Tb_pub_remPath;
    public ListBox lb_ca_certs;
    private MenuStrip menuStrip1;
    private ToolStripMenuItem editToolStripMenuItem;
    private ToolStripMenuItem ms_edit_config;
    private Label Lb_cert_remotePath;
    private GroupBox Lbl_remotePath_pub;
    private SaveFileDialog saveFileDialog1;
    private Label Lbl_remotePath_priv;
    public TextBox Tb_priv_remPath;
    public TextBox Tb_pub_filename;
    private Label Lbl_filename_pub;
    private GroupBox Gb_serverCredentials;
    private Label Lb_password;
    private Label Lb_username;
    private Label Lb_hostname;
    private TextBox Tb_password_nd;
    private TextBox Tb_password_st;
    private TextBox Tb_username;
    private TextBox Tb_hostname;
    private CheckBox Cb_autoUpload;
    private TreeView CertificateTree;
    private ImageList CertificateTreeImages;
    private ContextMenuStrip contextMenuStrip;
    private ToolStripMenuItem createMenu;
    private ToolStripSeparator toolStripSeparator1;
    private ToolStripMenuItem create_selfSign;
    private ToolStripMenuItem certificateInformationMenuItem1;
    private ToolStripMenuItem dNToolStripMenuItem;
    private ToolStripMenuItem readToolStripMenuItem;
    private ToolStripMenuItem writeToolStripMenuItem;
    private ToolStripMenuItem create_sign;
    private ToolStripMenuItem viewToolStripMenuItem;
    private ToolStripMenuItem view_private_key;
    private ToolStripMenuItem view_public_key;
    private ToolStripMenuItem view_fqdn;
    private ToolStripMenuItem view_san;
    private ToolStripMenuItem create_new;
    private ToolStripMenuItem create_new_user;
    private ToolStripMenuItem view_self_signed;
    private ToolStripTextBox create_new_intermediate;
    private ToolStripTextBox create_new_server;
    private ExtendedToolStripTextBox create_new_ca;
    private ExtendedToolStripMenuItem create_private_key;
    private ExtendedToolStripMenuItem create_public_key;
    private ToolStripMenuItem testFormToolStripMenuItem;
    private BindingSource bindingSource1;
    private CustomButton customButton1;
}
