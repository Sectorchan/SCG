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
        tb_ca_name = new TextBox();
        gb_default_disti_names = new GroupBox();
        Tb_san4 = new TextBox();
        Tb_san3 = new TextBox();
        Tb_san2 = new TextBox();
        Tb_san1 = new TextBox();
        Cb_san4 = new ComboBox();
        Cb_san3 = new ComboBox();
        Cb_san2 = new ComboBox();
        Cb_san1 = new ComboBox();
        tb_sub_email = new TextBox();
        tb_sub_cn = new TextBox();
        tb_sub_orga = new TextBox();
        tb_sub_ou = new TextBox();
        tb_sub_loc = new TextBox();
        tb_sub_st = new TextBox();
        tb_sub_c = new TextBox();
        lbl_def_email = new Label();
        lbl_def_commonName = new Label();
        lbl_def_organisationUnit = new Label();
        lbl_def_organisation = new Label();
        lbl_def_location = new Label();
        lbl_def_state = new Label();
        lbl_def_country = new Label();
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
        Lb_cert_remotePath = new Label();
        treeView1 = new TreeView();
        Lbl_remotePath_pub = new GroupBox();
        Tb_pub_filename = new TextBox();
        Lbl_filename_pub = new Label();
        Lbl_remotePath_priv = new Label();
        Tb_priv_remPath = new TextBox();
        saveFileDialog1 = new SaveFileDialog();
        customButton1 = new CustomButton();
        customButton2 = new CustomButton();
        Bt_ca_pub = new CustomButton();
        bt_ca_selfSigned = new CustomButton();
        bt_int_pub = new CustomButton();
        bt_int_signCA = new CustomButton();
        Bt_int_rd_fqdn = new CustomButton();
        Bt_int_wr_fqdn = new CustomButton();
        Bt_ca_fqdn_write = new CustomButton();
        Bt_ca_fqdn_read = new CustomButton();
        Bt_server_wr_fqdn = new CustomButton();
        Bt_server_rd_fqdn = new CustomButton();
        Bt_user_wr_fqdn = new CustomButton();
        Bt_user_rd_fqdn = new CustomButton();
        customButton4 = new CustomButton();
        customButton5 = new CustomButton();
        Bt_server_ = new CustomButton();
        customButton6 = new CustomButton();
        customButton7 = new CustomButton();
        customButton8 = new CustomButton();
        customButton3 = new CustomButton();
        customButton9 = new CustomButton();
        customButton10 = new CustomButton();
        customButton11 = new CustomButton();
        customButton12 = new CustomButton();
        customButton13 = new CustomButton();
        customButton14 = new CustomButton();
        customButton15 = new CustomButton();
        Gb_serverCredentials = new GroupBox();
        Cb_autoUpload = new CheckBox();
        Tb_password_nd = new TextBox();
        Tb_password_st = new TextBox();
        Tb_username = new TextBox();
        Tb_hostname = new TextBox();
        Lb_password = new Label();
        Lb_username = new Label();
        Lb_hostname = new Label();
        Bt_ca_ServerCred = new CustomButton();
        Bt_int_ServerCred = new CustomButton();
        Bt_server_ServerCred = new CustomButton();
        gb_default_disti_names.SuspendLayout();
        menuStrip1.SuspendLayout();
        Lbl_remotePath_pub.SuspendLayout();
        Gb_serverCredentials.SuspendLayout();
        SuspendLayout();
        // 
        // tb_ca_name
        // 
        tb_ca_name.Location = new Point(103, 184);
        tb_ca_name.Margin = new Padding(3, 4, 3, 4);
        tb_ca_name.Name = "tb_ca_name";
        tb_ca_name.Size = new Size(114, 27);
        tb_ca_name.TabIndex = 12;
        // 
        // gb_default_disti_names
        // 
        gb_default_disti_names.Controls.Add(Tb_san4);
        gb_default_disti_names.Controls.Add(Tb_san3);
        gb_default_disti_names.Controls.Add(Tb_san2);
        gb_default_disti_names.Controls.Add(Tb_san1);
        gb_default_disti_names.Controls.Add(Cb_san4);
        gb_default_disti_names.Controls.Add(Cb_san3);
        gb_default_disti_names.Controls.Add(Cb_san2);
        gb_default_disti_names.Controls.Add(Cb_san1);
        gb_default_disti_names.Controls.Add(tb_sub_email);
        gb_default_disti_names.Controls.Add(tb_sub_cn);
        gb_default_disti_names.Controls.Add(tb_sub_orga);
        gb_default_disti_names.Controls.Add(tb_sub_ou);
        gb_default_disti_names.Controls.Add(tb_sub_loc);
        gb_default_disti_names.Controls.Add(tb_sub_st);
        gb_default_disti_names.Controls.Add(tb_sub_c);
        gb_default_disti_names.Controls.Add(lbl_def_email);
        gb_default_disti_names.Controls.Add(lbl_def_commonName);
        gb_default_disti_names.Controls.Add(lbl_def_organisationUnit);
        gb_default_disti_names.Controls.Add(lbl_def_organisation);
        gb_default_disti_names.Controls.Add(lbl_def_location);
        gb_default_disti_names.Controls.Add(lbl_def_state);
        gb_default_disti_names.Controls.Add(lbl_def_country);
        gb_default_disti_names.Location = new Point(318, 479);
        gb_default_disti_names.Margin = new Padding(3, 4, 3, 4);
        gb_default_disti_names.Name = "gb_default_disti_names";
        gb_default_disti_names.Padding = new Padding(3, 4, 3, 4);
        gb_default_disti_names.Size = new Size(571, 292);
        gb_default_disti_names.TabIndex = 11;
        gb_default_disti_names.TabStop = false;
        gb_default_disti_names.Text = "Default Distinguished Names";
        // 
        // Tb_san4
        // 
        Tb_san4.Location = new Point(367, 160);
        Tb_san4.Margin = new Padding(3, 4, 3, 4);
        Tb_san4.Name = "Tb_san4";
        Tb_san4.Size = new Size(189, 27);
        Tb_san4.TabIndex = 22;
        // 
        // Tb_san3
        // 
        Tb_san3.Location = new Point(367, 121);
        Tb_san3.Margin = new Padding(3, 4, 3, 4);
        Tb_san3.Name = "Tb_san3";
        Tb_san3.Size = new Size(189, 27);
        Tb_san3.TabIndex = 21;
        // 
        // Tb_san2
        // 
        Tb_san2.Location = new Point(367, 83);
        Tb_san2.Margin = new Padding(3, 4, 3, 4);
        Tb_san2.Name = "Tb_san2";
        Tb_san2.Size = new Size(189, 27);
        Tb_san2.TabIndex = 20;
        // 
        // Tb_san1
        // 
        Tb_san1.Location = new Point(367, 44);
        Tb_san1.Margin = new Padding(3, 4, 3, 4);
        Tb_san1.Name = "Tb_san1";
        Tb_san1.Size = new Size(189, 27);
        Tb_san1.TabIndex = 19;
        // 
        // Cb_san4
        // 
        Cb_san4.FormattingEnabled = true;
        Cb_san4.Items.AddRange(new object[] { "IP", "DNS" });
        Cb_san4.Location = new Point(279, 160);
        Cb_san4.Margin = new Padding(3, 4, 3, 4);
        Cb_san4.Name = "Cb_san4";
        Cb_san4.Size = new Size(81, 28);
        Cb_san4.TabIndex = 18;
        // 
        // Cb_san3
        // 
        Cb_san3.FormattingEnabled = true;
        Cb_san3.Items.AddRange(new object[] { "IP", "DNS" });
        Cb_san3.Location = new Point(279, 121);
        Cb_san3.Margin = new Padding(3, 4, 3, 4);
        Cb_san3.Name = "Cb_san3";
        Cb_san3.Size = new Size(81, 28);
        Cb_san3.TabIndex = 17;
        // 
        // Cb_san2
        // 
        Cb_san2.FormattingEnabled = true;
        Cb_san2.Items.AddRange(new object[] { "IP", "DNS" });
        Cb_san2.Location = new Point(279, 83);
        Cb_san2.Margin = new Padding(3, 4, 3, 4);
        Cb_san2.Name = "Cb_san2";
        Cb_san2.Size = new Size(81, 28);
        Cb_san2.TabIndex = 16;
        // 
        // Cb_san1
        // 
        Cb_san1.FormattingEnabled = true;
        Cb_san1.Items.AddRange(new object[] { "IP", "DNS" });
        Cb_san1.Location = new Point(279, 44);
        Cb_san1.Margin = new Padding(3, 4, 3, 4);
        Cb_san1.Name = "Cb_san1";
        Cb_san1.Size = new Size(81, 28);
        Cb_san1.TabIndex = 15;
        // 
        // tb_sub_email
        // 
        tb_sub_email.Location = new Point(129, 240);
        tb_sub_email.Margin = new Padding(3, 4, 3, 4);
        tb_sub_email.Name = "tb_sub_email";
        tb_sub_email.Size = new Size(114, 27);
        tb_sub_email.TabIndex = 13;
        // 
        // tb_sub_cn
        // 
        tb_sub_cn.Location = new Point(129, 205);
        tb_sub_cn.Margin = new Padding(3, 4, 3, 4);
        tb_sub_cn.Name = "tb_sub_cn";
        tb_sub_cn.Size = new Size(114, 27);
        tb_sub_cn.TabIndex = 12;
        // 
        // tb_sub_orga
        // 
        tb_sub_orga.Location = new Point(129, 173);
        tb_sub_orga.Margin = new Padding(3, 4, 3, 4);
        tb_sub_orga.Name = "tb_sub_orga";
        tb_sub_orga.Size = new Size(114, 27);
        tb_sub_orga.TabIndex = 11;
        // 
        // tb_sub_ou
        // 
        tb_sub_ou.Location = new Point(129, 141);
        tb_sub_ou.Margin = new Padding(3, 4, 3, 4);
        tb_sub_ou.Name = "tb_sub_ou";
        tb_sub_ou.Size = new Size(114, 27);
        tb_sub_ou.TabIndex = 10;
        // 
        // tb_sub_loc
        // 
        tb_sub_loc.Location = new Point(129, 108);
        tb_sub_loc.Margin = new Padding(3, 4, 3, 4);
        tb_sub_loc.Name = "tb_sub_loc";
        tb_sub_loc.Size = new Size(114, 27);
        tb_sub_loc.TabIndex = 9;
        // 
        // tb_sub_st
        // 
        tb_sub_st.Location = new Point(129, 75);
        tb_sub_st.Margin = new Padding(3, 4, 3, 4);
        tb_sub_st.Name = "tb_sub_st";
        tb_sub_st.Size = new Size(114, 27);
        tb_sub_st.TabIndex = 8;
        // 
        // tb_sub_c
        // 
        tb_sub_c.AutoCompleteCustomSource.AddRange(new string[] { "AF", "EG", "AX", "AL", "DZ", "AS", "AD", "AO", "AI", "AQ", "AG", "GQ", "AR", "AM", "AW", "AZ", "ET", "AU", "BS", "BH", "BD", "BB", "BY", "BE", "BZ", "BJ", "BM", "BT", "BO", "BA", "BW", "BV", "BR", "IO", "BN", "BG", "BF", "BI", "CL", "CN", "CK", "CR", "CW", "DK", "CD", "DE", "DM", "DO", "DJ", "EC", "SV", "CI", "ER", "EE", "SZ", "FK", "FO", "FJ", "FI", "FM", "FR", "GF", "PF", "TF", "MC", "GA", "GM", "GE", "GH", "GI", "GD", "GR", "GL", "GP", "GU", "GT", "GG", "GN", "GW", "GY", "HT", "HM", "HN", "HK", "IN", "ID", "IM", "IQ", "IR", "IE", "IS", "IL", "IT", "JM", "JP", "YE", "JE", "JO", "VG", "VI", "KY", "KH", "CM", "CA", "CV", "BQ", "KZ", "QA", "KE", "KG", "KI", "UM", "CC", "CO", "KM", "XK", "HR", "CU", "KW", "LA", "LS", "LV", "LB", "LR", "LY", "LI", "LT", "LU", "MO", "MG", "MW", "MY", "MV", "ML", "MT", "MA", "MH", "MQ", "MR", "MU", "YT", "MX", "MD", "MN", "ME", "MS", "MZ", "MM", "NA", "NR", "NP", "NC", "NZ", "NI", "NL", "NE", "NG", "NU", "KP", "MP", "MK", "NF", "NO", "OM", "AT", "TL", "PK", "PS", "PW", "PA", "PG", "PY", "PE", "PH", "PN", "PL", "PT", "PR", "CG", "RE", "RW", "RO", "RU", "MF", "SB", "ZM", "WS", "SM", "BL", "ST", "SA", "SE", "CH", "SN", "RS", "SC", "SL", "ZW", "SG", "SX", "SK", "SI", "SO", "ES", "LK", "SH", "KN", "LC", "PM", "VC", "ZA", "SD", "GS", "KR", "SS", "SR", "SJ", "SY", "TJ", "TW", "TZ", "TH", "TG", "TK", "TO", "TT", "TD", "CZ", "TN", "TR", "TM", "TC", "TV", "UG", "UA", "HU", "UY", "UZ", "VU", "VA", "VE", "AE", "US", "GB", "VN", "WF", "CX", "EH", "CF", "CY" });
        tb_sub_c.CharacterCasing = CharacterCasing.Upper;
        tb_sub_c.Location = new Point(129, 40);
        tb_sub_c.Margin = new Padding(3, 4, 3, 4);
        tb_sub_c.MaxLength = 2;
        tb_sub_c.Name = "tb_sub_c";
        tb_sub_c.Size = new Size(114, 27);
        tb_sub_c.TabIndex = 7;
        // 
        // lbl_def_email
        // 
        lbl_def_email.AutoSize = true;
        lbl_def_email.Location = new Point(75, 244);
        lbl_def_email.Name = "lbl_def_email";
        lbl_def_email.Size = new Size(52, 20);
        lbl_def_email.TabIndex = 6;
        lbl_def_email.Text = "E-Mail";
        // 
        // lbl_def_commonName
        // 
        lbl_def_commonName.AutoSize = true;
        lbl_def_commonName.Location = new Point(16, 216);
        lbl_def_commonName.Name = "lbl_def_commonName";
        lbl_def_commonName.Size = new Size(114, 20);
        lbl_def_commonName.TabIndex = 5;
        lbl_def_commonName.Text = "Common Name";
        // 
        // lbl_def_organisationUnit
        // 
        lbl_def_organisationUnit.AutoSize = true;
        lbl_def_organisationUnit.Location = new Point(34, 173);
        lbl_def_organisationUnit.Name = "lbl_def_organisationUnit";
        lbl_def_organisationUnit.Size = new Size(94, 20);
        lbl_def_organisationUnit.TabIndex = 4;
        lbl_def_organisationUnit.Text = "Organisation";
        // 
        // lbl_def_organisation
        // 
        lbl_def_organisation.AutoSize = true;
        lbl_def_organisation.Location = new Point(53, 145);
        lbl_def_organisation.Name = "lbl_def_organisation";
        lbl_def_organisation.Size = new Size(76, 20);
        lbl_def_organisation.TabIndex = 3;
        lbl_def_organisation.Text = "Orga. Unit";
        // 
        // lbl_def_location
        // 
        lbl_def_location.AutoSize = true;
        lbl_def_location.Location = new Point(62, 112);
        lbl_def_location.Name = "lbl_def_location";
        lbl_def_location.Size = new Size(66, 20);
        lbl_def_location.TabIndex = 2;
        lbl_def_location.Text = "Location";
        // 
        // lbl_def_state
        // 
        lbl_def_state.AutoSize = true;
        lbl_def_state.Location = new Point(85, 75);
        lbl_def_state.Name = "lbl_def_state";
        lbl_def_state.Size = new Size(43, 20);
        lbl_def_state.TabIndex = 1;
        lbl_def_state.Text = "State";
        // 
        // lbl_def_country
        // 
        lbl_def_country.AutoSize = true;
        lbl_def_country.Location = new Point(65, 44);
        lbl_def_country.Name = "lbl_def_country";
        lbl_def_country.Size = new Size(60, 20);
        lbl_def_country.TabIndex = 0;
        lbl_def_country.Text = "Country";
        // 
        // lbl_ca_name
        // 
        lbl_ca_name.AutoSize = true;
        lbl_ca_name.Location = new Point(8, 187);
        lbl_ca_name.Name = "lbl_ca_name";
        lbl_ca_name.Size = new Size(97, 20);
        lbl_ca_name.TabIndex = 10;
        lbl_ca_name.Text = "Server Name:";
        // 
        // lb_ca_certs
        // 
        lb_ca_certs.FormattingEnabled = true;
        lb_ca_certs.Location = new Point(75, 35);
        lb_ca_certs.Margin = new Padding(2, 3, 2, 3);
        lb_ca_certs.Name = "lb_ca_certs";
        lb_ca_certs.Size = new Size(141, 104);
        lb_ca_certs.TabIndex = 14;
        // 
        // cb_ca_keySize
        // 
        cb_ca_keySize.FormattingEnabled = true;
        cb_ca_keySize.Items.AddRange(new object[] { "2048", "4096", "8192" });
        cb_ca_keySize.Location = new Point(103, 221);
        cb_ca_keySize.Margin = new Padding(3, 4, 3, 4);
        cb_ca_keySize.Name = "cb_ca_keySize";
        cb_ca_keySize.Size = new Size(114, 28);
        cb_ca_keySize.TabIndex = 24;
        cb_ca_keySize.Text = "4096";
        // 
        // lbl_ca_keySize
        // 
        lbl_ca_keySize.AutoSize = true;
        lbl_ca_keySize.Location = new Point(45, 225);
        lbl_ca_keySize.Name = "lbl_ca_keySize";
        lbl_ca_keySize.Size = new Size(58, 20);
        lbl_ca_keySize.TabIndex = 0;
        lbl_ca_keySize.Text = "Keysize";
        lbl_ca_keySize.TextAlign = ContentAlignment.TopRight;
        // 
        // tb_ca_dura
        // 
        tb_ca_dura.Location = new Point(103, 261);
        tb_ca_dura.Margin = new Padding(3, 4, 3, 4);
        tb_ca_dura.Name = "tb_ca_dura";
        tb_ca_dura.Size = new Size(114, 27);
        tb_ca_dura.TabIndex = 4;
        tb_ca_dura.Text = "120";
        // 
        // lbl_ca_duration
        // 
        lbl_ca_duration.AutoSize = true;
        lbl_ca_duration.Location = new Point(35, 267);
        lbl_ca_duration.Name = "lbl_ca_duration";
        lbl_ca_duration.Size = new Size(67, 20);
        lbl_ca_duration.TabIndex = 0;
        lbl_ca_duration.Text = "Duration";
        // 
        // cb_new_ca
        // 
        cb_new_ca.AutoSize = true;
        cb_new_ca.Location = new Point(103, 151);
        cb_new_ca.Margin = new Padding(3, 4, 3, 4);
        cb_new_ca.Name = "cb_new_ca";
        cb_new_ca.Size = new Size(106, 24);
        cb_new_ca.TabIndex = 17;
        cb_new_ca.Text = "New Server";
        cb_new_ca.UseVisualStyleBackColor = true;
        cb_new_ca.CheckedChanged += cb_new_ca_CheckedChanged;
        // 
        // lb_int_certs
        // 
        lb_int_certs.FormattingEnabled = true;
        lb_int_certs.Location = new Point(366, 35);
        lb_int_certs.Margin = new Padding(3, 4, 3, 4);
        lb_int_certs.Name = "lb_int_certs";
        lb_int_certs.Size = new Size(137, 104);
        lb_int_certs.TabIndex = 32;
        // 
        // lbl_int_keySize
        // 
        lbl_int_keySize.AutoSize = true;
        lbl_int_keySize.Location = new Point(330, 224);
        lbl_int_keySize.Name = "lbl_int_keySize";
        lbl_int_keySize.Size = new Size(58, 20);
        lbl_int_keySize.TabIndex = 34;
        lbl_int_keySize.Text = "Keysize";
        // 
        // cb_int_keySize
        // 
        cb_int_keySize.FormattingEnabled = true;
        cb_int_keySize.Items.AddRange(new object[] { "2048", "4096", "8192" });
        cb_int_keySize.Location = new Point(389, 221);
        cb_int_keySize.Margin = new Padding(3, 4, 3, 4);
        cb_int_keySize.Name = "cb_int_keySize";
        cb_int_keySize.Size = new Size(114, 28);
        cb_int_keySize.TabIndex = 37;
        cb_int_keySize.Text = "4096";
        // 
        // tb_int_dura
        // 
        tb_int_dura.Location = new Point(389, 260);
        tb_int_dura.Margin = new Padding(3, 4, 3, 4);
        tb_int_dura.Name = "tb_int_dura";
        tb_int_dura.Size = new Size(114, 27);
        tb_int_dura.TabIndex = 36;
        tb_int_dura.Text = "60";
        // 
        // lbl_int_duration
        // 
        lbl_int_duration.AutoSize = true;
        lbl_int_duration.Location = new Point(321, 267);
        lbl_int_duration.Name = "lbl_int_duration";
        lbl_int_duration.Size = new Size(67, 20);
        lbl_int_duration.TabIndex = 35;
        lbl_int_duration.Text = "Duration";
        // 
        // tb_int_name
        // 
        tb_int_name.Location = new Point(389, 184);
        tb_int_name.Margin = new Padding(3, 4, 3, 4);
        tb_int_name.Name = "tb_int_name";
        tb_int_name.Size = new Size(114, 27);
        tb_int_name.TabIndex = 39;
        // 
        // lbl_int_name
        // 
        lbl_int_name.AutoSize = true;
        lbl_int_name.Location = new Point(254, 187);
        lbl_int_name.Name = "lbl_int_name";
        lbl_int_name.Size = new Size(141, 20);
        lbl_int_name.TabIndex = 38;
        lbl_int_name.Text = "Intermediate Name:";
        // 
        // cb_new_int
        // 
        cb_new_int.AutoSize = true;
        cb_new_int.Location = new Point(366, 151);
        cb_new_int.Margin = new Padding(3, 4, 3, 4);
        cb_new_int.Name = "cb_new_int";
        cb_new_int.Size = new Size(150, 24);
        cb_new_int.TabIndex = 40;
        cb_new_int.Text = "New Intermediate";
        cb_new_int.UseVisualStyleBackColor = true;
        cb_new_int.CheckedChanged += cb_new_inter_CheckedChanged;
        // 
        // cb_new_server
        // 
        cb_new_server.AutoSize = true;
        cb_new_server.Location = new Point(629, 151);
        cb_new_server.Margin = new Padding(3, 4, 3, 4);
        cb_new_server.Name = "cb_new_server";
        cb_new_server.Size = new Size(106, 24);
        cb_new_server.TabIndex = 55;
        cb_new_server.Text = "New Server";
        cb_new_server.TextAlign = ContentAlignment.MiddleRight;
        cb_new_server.UseVisualStyleBackColor = true;
        cb_new_server.CheckedChanged += cb_new_server_CheckedChanged;
        // 
        // tb_server_name
        // 
        tb_server_name.Location = new Point(651, 184);
        tb_server_name.Margin = new Padding(3, 4, 3, 4);
        tb_server_name.Name = "tb_server_name";
        tb_server_name.Size = new Size(114, 27);
        tb_server_name.TabIndex = 54;
        // 
        // lbl_server_name
        // 
        lbl_server_name.AutoSize = true;
        lbl_server_name.Location = new Point(557, 188);
        lbl_server_name.Name = "lbl_server_name";
        lbl_server_name.Size = new Size(97, 20);
        lbl_server_name.TabIndex = 53;
        lbl_server_name.Text = "Server Name:";
        // 
        // lbl_server_keySize
        // 
        lbl_server_keySize.AutoSize = true;
        lbl_server_keySize.Location = new Point(593, 225);
        lbl_server_keySize.Name = "lbl_server_keySize";
        lbl_server_keySize.Size = new Size(58, 20);
        lbl_server_keySize.TabIndex = 49;
        lbl_server_keySize.Text = "Keysize";
        // 
        // cb_server_keySize
        // 
        cb_server_keySize.FormattingEnabled = true;
        cb_server_keySize.Items.AddRange(new object[] { "2048", "4096", "8192" });
        cb_server_keySize.Location = new Point(651, 221);
        cb_server_keySize.Margin = new Padding(3, 4, 3, 4);
        cb_server_keySize.Name = "cb_server_keySize";
        cb_server_keySize.Size = new Size(114, 28);
        cb_server_keySize.TabIndex = 52;
        cb_server_keySize.Text = "4096";
        // 
        // tb_server_dura
        // 
        tb_server_dura.Location = new Point(651, 260);
        tb_server_dura.Margin = new Padding(3, 4, 3, 4);
        tb_server_dura.Name = "tb_server_dura";
        tb_server_dura.Size = new Size(114, 27);
        tb_server_dura.TabIndex = 51;
        tb_server_dura.Text = "30";
        // 
        // lbl_server_duration
        // 
        lbl_server_duration.AutoSize = true;
        lbl_server_duration.Location = new Point(584, 267);
        lbl_server_duration.Name = "lbl_server_duration";
        lbl_server_duration.Size = new Size(67, 20);
        lbl_server_duration.TabIndex = 50;
        lbl_server_duration.Text = "Duration";
        // 
        // lb_server_certs
        // 
        lb_server_certs.FormattingEnabled = true;
        lb_server_certs.Location = new Point(629, 35);
        lb_server_certs.Margin = new Padding(3, 4, 3, 4);
        lb_server_certs.Name = "lb_server_certs";
        lb_server_certs.Size = new Size(137, 104);
        lb_server_certs.TabIndex = 47;
        // 
        // cb_new_user
        // 
        cb_new_user.AutoSize = true;
        cb_new_user.Location = new Point(873, 151);
        cb_new_user.Margin = new Padding(3, 4, 3, 4);
        cb_new_user.Name = "cb_new_user";
        cb_new_user.Size = new Size(94, 24);
        cb_new_user.TabIndex = 67;
        cb_new_user.Text = "New User";
        cb_new_user.TextAlign = ContentAlignment.MiddleRight;
        cb_new_user.UseVisualStyleBackColor = true;
        cb_new_user.CheckedChanged += cb_new_user_CheckedChanged;
        // 
        // tb_user_name
        // 
        tb_user_name.Location = new Point(896, 184);
        tb_user_name.Margin = new Padding(3, 4, 3, 4);
        tb_user_name.Name = "tb_user_name";
        tb_user_name.Size = new Size(114, 27);
        tb_user_name.TabIndex = 66;
        // 
        // lbl_user_name
        // 
        lbl_user_name.AutoSize = true;
        lbl_user_name.Location = new Point(811, 188);
        lbl_user_name.Name = "lbl_user_name";
        lbl_user_name.Size = new Size(85, 20);
        lbl_user_name.TabIndex = 65;
        lbl_user_name.Text = "User Name:";
        lbl_user_name.TextAlign = ContentAlignment.TopRight;
        // 
        // lbl_user_keySize
        // 
        lbl_user_keySize.AutoSize = true;
        lbl_user_keySize.Location = new Point(838, 225);
        lbl_user_keySize.Name = "lbl_user_keySize";
        lbl_user_keySize.Size = new Size(58, 20);
        lbl_user_keySize.TabIndex = 61;
        lbl_user_keySize.Text = "Keysize";
        // 
        // cb_user_keySize
        // 
        cb_user_keySize.FormattingEnabled = true;
        cb_user_keySize.Items.AddRange(new object[] { "2048", "4096", "8192" });
        cb_user_keySize.Location = new Point(896, 221);
        cb_user_keySize.Margin = new Padding(3, 4, 3, 4);
        cb_user_keySize.Name = "cb_user_keySize";
        cb_user_keySize.Size = new Size(114, 28);
        cb_user_keySize.TabIndex = 64;
        cb_user_keySize.Text = "4096";
        // 
        // tb_user_dura
        // 
        tb_user_dura.Location = new Point(896, 260);
        tb_user_dura.Margin = new Padding(3, 4, 3, 4);
        tb_user_dura.Name = "tb_user_dura";
        tb_user_dura.Size = new Size(114, 27);
        tb_user_dura.TabIndex = 63;
        tb_user_dura.Text = "30";
        // 
        // lbl_user_duration
        // 
        lbl_user_duration.AutoSize = true;
        lbl_user_duration.Location = new Point(829, 267);
        lbl_user_duration.Name = "lbl_user_duration";
        lbl_user_duration.Size = new Size(67, 20);
        lbl_user_duration.TabIndex = 62;
        lbl_user_duration.Text = "Duration";
        // 
        // lb_user_certs
        // 
        lb_user_certs.FormattingEnabled = true;
        lb_user_certs.Location = new Point(873, 35);
        lb_user_certs.Margin = new Padding(3, 4, 3, 4);
        lb_user_certs.Name = "lb_user_certs";
        lb_user_certs.Size = new Size(137, 104);
        lb_user_certs.TabIndex = 59;
        // 
        // Tb_priv_filename
        // 
        Tb_priv_filename.Location = new Point(138, 29);
        Tb_priv_filename.Margin = new Padding(3, 4, 3, 4);
        Tb_priv_filename.Name = "Tb_priv_filename";
        Tb_priv_filename.Size = new Size(116, 27);
        Tb_priv_filename.TabIndex = 86;
        // 
        // Lbl_filename_priv
        // 
        Lbl_filename_priv.AutoSize = true;
        Lbl_filename_priv.Location = new Point(69, 33);
        Lbl_filename_priv.Name = "Lbl_filename_priv";
        Lbl_filename_priv.Size = new Size(69, 20);
        Lbl_filename_priv.TabIndex = 87;
        Lbl_filename_priv.Text = "Filename";
        // 
        // Lbl_fileExtension_priv
        // 
        Lbl_fileExtension_priv.AutoSize = true;
        Lbl_fileExtension_priv.Location = new Point(55, 76);
        Lbl_fileExtension_priv.Name = "Lbl_fileExtension_priv";
        Lbl_fileExtension_priv.Size = new Size(84, 20);
        Lbl_fileExtension_priv.TabIndex = 88;
        Lbl_fileExtension_priv.Text = "File Ext Priv";
        // 
        // Cb_priv_fileext
        // 
        Cb_priv_fileext.FormattingEnabled = true;
        Cb_priv_fileext.Items.AddRange(new object[] { "pfx", "pem", "crt", "cer", "der", "" });
        Cb_priv_fileext.Location = new Point(138, 72);
        Cb_priv_fileext.Margin = new Padding(3, 4, 3, 4);
        Cb_priv_fileext.Name = "Cb_priv_fileext";
        Cb_priv_fileext.Size = new Size(116, 28);
        Cb_priv_fileext.TabIndex = 89;
        // 
        // Lbl_fileExtension_pub
        // 
        Lbl_fileExtension_pub.AutoSize = true;
        Lbl_fileExtension_pub.Location = new Point(46, 205);
        Lbl_fileExtension_pub.Name = "Lbl_fileExtension_pub";
        Lbl_fileExtension_pub.Size = new Size(100, 20);
        Lbl_fileExtension_pub.TabIndex = 90;
        Lbl_fileExtension_pub.Text = "File Ext Public";
        // 
        // Cb_pub_fileext
        // 
        Cb_pub_fileext.FormattingEnabled = true;
        Cb_pub_fileext.Items.AddRange(new object[] { "cer", "der", "crt" });
        Cb_pub_fileext.Location = new Point(138, 201);
        Cb_pub_fileext.Margin = new Padding(3, 4, 3, 4);
        Cb_pub_fileext.Name = "Cb_pub_fileext";
        Cb_pub_fileext.Size = new Size(115, 28);
        Cb_pub_fileext.TabIndex = 91;
        // 
        // Tb_pub_remPath
        // 
        Tb_pub_remPath.Location = new Point(138, 240);
        Tb_pub_remPath.Margin = new Padding(3, 4, 3, 4);
        Tb_pub_remPath.Name = "Tb_pub_remPath";
        Tb_pub_remPath.Size = new Size(116, 27);
        Tb_pub_remPath.TabIndex = 92;
        // 
        // menuStrip1
        // 
        menuStrip1.ImageScalingSize = new Size(28, 28);
        menuStrip1.Items.AddRange(new ToolStripItem[] { editToolStripMenuItem });
        menuStrip1.Location = new Point(0, 0);
        menuStrip1.Name = "menuStrip1";
        menuStrip1.Padding = new Padding(7, 3, 0, 3);
        menuStrip1.Size = new Size(1058, 30);
        menuStrip1.TabIndex = 94;
        menuStrip1.Text = "menuStrip1";
        // 
        // editToolStripMenuItem
        // 
        editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ms_edit_config });
        editToolStripMenuItem.Name = "editToolStripMenuItem";
        editToolStripMenuItem.Size = new Size(49, 24);
        editToolStripMenuItem.Text = "Edit";
        // 
        // ms_edit_config
        // 
        ms_edit_config.Name = "ms_edit_config";
        ms_edit_config.Size = new Size(136, 26);
        ms_edit_config.Text = "Config";
        ms_edit_config.Click += edit_config_load;
        // 
        // Lb_cert_remotePath
        // 
        Lb_cert_remotePath.AutoSize = true;
        Lb_cert_remotePath.Location = new Point(49, 244);
        Lb_cert_remotePath.Name = "Lb_cert_remotePath";
        Lb_cert_remotePath.Size = new Size(93, 20);
        Lb_cert_remotePath.TabIndex = 95;
        Lb_cert_remotePath.Text = "Remote Path";
        // 
        // treeView1
        // 
        treeView1.Location = new Point(707, 815);
        treeView1.Margin = new Padding(3, 4, 3, 4);
        treeView1.MaximumSize = new Size(100, 100);
        treeView1.Name = "treeView1";
        treeView1.Size = new Size(100, 100);
        treeView1.TabIndex = 97;
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
        Lbl_remotePath_pub.Location = new Point(14, 479);
        Lbl_remotePath_pub.Margin = new Padding(3, 4, 3, 4);
        Lbl_remotePath_pub.Name = "Lbl_remotePath_pub";
        Lbl_remotePath_pub.Padding = new Padding(3, 4, 3, 4);
        Lbl_remotePath_pub.Size = new Size(262, 292);
        Lbl_remotePath_pub.TabIndex = 98;
        Lbl_remotePath_pub.TabStop = false;
        Lbl_remotePath_pub.Text = "Certificate information";
        // 
        // Tb_pub_filename
        // 
        Tb_pub_filename.Location = new Point(138, 163);
        Tb_pub_filename.Margin = new Padding(3, 4, 3, 4);
        Tb_pub_filename.Name = "Tb_pub_filename";
        Tb_pub_filename.Size = new Size(116, 27);
        Tb_pub_filename.TabIndex = 99;
        // 
        // Lbl_filename_pub
        // 
        Lbl_filename_pub.AutoSize = true;
        Lbl_filename_pub.Location = new Point(69, 167);
        Lbl_filename_pub.Name = "Lbl_filename_pub";
        Lbl_filename_pub.Size = new Size(69, 20);
        Lbl_filename_pub.TabIndex = 100;
        Lbl_filename_pub.Text = "Filename";
        // 
        // Lbl_remotePath_priv
        // 
        Lbl_remotePath_priv.AutoSize = true;
        Lbl_remotePath_priv.Location = new Point(46, 116);
        Lbl_remotePath_priv.Name = "Lbl_remotePath_priv";
        Lbl_remotePath_priv.Size = new Size(93, 20);
        Lbl_remotePath_priv.TabIndex = 98;
        Lbl_remotePath_priv.Text = "Remote Path";
        // 
        // Tb_priv_remPath
        // 
        Tb_priv_remPath.Location = new Point(138, 109);
        Tb_priv_remPath.Margin = new Padding(3, 4, 3, 4);
        Tb_priv_remPath.Name = "Tb_priv_remPath";
        Tb_priv_remPath.Size = new Size(116, 27);
        Tb_priv_remPath.TabIndex = 97;
        // 
        // customButton1
        // 
        customButton1._certInfo = PL.Utils.Tools.info.CertInfoWrite;
        customButton1._certType = PL.Utils.Tools.certType.priv;
        customButton1._fqdnType = PL.Utils.Tools.fdqnType.write;
        customButton1._serverType = PL.Utils.Tools.serverType.ca;
        customButton1.Location = new Point(31, 319);
        customButton1.Margin = new Padding(3, 4, 3, 4);
        customButton1.Name = "customButton1";
        customButton1.Size = new Size(86, 31);
        customButton1.TabIndex = 104;
        customButton1.Text = "privTest";
        customButton1.UseVisualStyleBackColor = true;
        customButton1.CustomClick += CustomButton2_CustomClick;
        // 
        // customButton2
        // 
        customButton2._certInfo = PL.Utils.Tools.info.CertInfoWrite;
        customButton2._certType = PL.Utils.Tools.certType.priv;
        customButton2._fqdnType = PL.Utils.Tools.fdqnType.write;
        customButton2._serverType = PL.Utils.Tools.serverType.intermediate;
        customButton2.Location = new Point(336, 319);
        customButton2.Margin = new Padding(3, 4, 3, 4);
        customButton2.Name = "customButton2";
        customButton2.Size = new Size(86, 31);
        customButton2.TabIndex = 105;
        customButton2.Text = "privTest";
        customButton2.UseVisualStyleBackColor = true;
        customButton2.CustomClick += CustomButton2_CustomClick;
        // 
        // Bt_ca_pub
        // 
        Bt_ca_pub._certInfo = PL.Utils.Tools.info.CertInfoWrite;
        Bt_ca_pub._certType = PL.Utils.Tools.certType.pub;
        Bt_ca_pub._fqdnType = PL.Utils.Tools.fdqnType.write;
        Bt_ca_pub._serverType = PL.Utils.Tools.serverType.ca;
        Bt_ca_pub.Location = new Point(129, 319);
        Bt_ca_pub.Margin = new Padding(3, 4, 3, 4);
        Bt_ca_pub.Name = "Bt_ca_pub";
        Bt_ca_pub.Size = new Size(86, 31);
        Bt_ca_pub.TabIndex = 106;
        Bt_ca_pub.Text = "pubTest";
        Bt_ca_pub.UseVisualStyleBackColor = true;
        Bt_ca_pub.CustomClick += CustomButton2_CustomClick;
        // 
        // bt_ca_selfSigned
        // 
        bt_ca_selfSigned._certInfo = PL.Utils.Tools.info.CertInfoWrite;
        bt_ca_selfSigned._certType = PL.Utils.Tools.certType.selfSigned;
        bt_ca_selfSigned._fqdnType = PL.Utils.Tools.fdqnType.write;
        bt_ca_selfSigned._serverType = PL.Utils.Tools.serverType.ca;
        bt_ca_selfSigned.Location = new Point(31, 357);
        bt_ca_selfSigned.Margin = new Padding(3, 4, 3, 4);
        bt_ca_selfSigned.Name = "bt_ca_selfSigned";
        bt_ca_selfSigned.Size = new Size(86, 31);
        bt_ca_selfSigned.TabIndex = 108;
        bt_ca_selfSigned.Text = "ssTest";
        bt_ca_selfSigned.UseVisualStyleBackColor = true;
        bt_ca_selfSigned.CustomClick += CustomButton2_CustomClick;
        // 
        // bt_int_pub
        // 
        bt_int_pub._certInfo = PL.Utils.Tools.info.CertInfoWrite;
        bt_int_pub._certType = PL.Utils.Tools.certType.pub;
        bt_int_pub._fqdnType = PL.Utils.Tools.fdqnType.write;
        bt_int_pub._serverType = PL.Utils.Tools.serverType.intermediate;
        bt_int_pub.Location = new Point(429, 319);
        bt_int_pub.Margin = new Padding(3, 4, 3, 4);
        bt_int_pub.Name = "bt_int_pub";
        bt_int_pub.Size = new Size(86, 31);
        bt_int_pub.TabIndex = 109;
        bt_int_pub.Text = "pubTest";
        bt_int_pub.UseVisualStyleBackColor = true;
        bt_int_pub.CustomClick += CustomButton2_CustomClick;
        // 
        // bt_int_signCA
        // 
        bt_int_signCA._certInfo = PL.Utils.Tools.info.CertInfoWrite;
        bt_int_signCA._certType = PL.Utils.Tools.certType.signed;
        bt_int_signCA._fqdnType = PL.Utils.Tools.fdqnType.write;
        bt_int_signCA._serverType = PL.Utils.Tools.serverType.intermediate;
        bt_int_signCA.Location = new Point(336, 357);
        bt_int_signCA.Margin = new Padding(3, 4, 3, 4);
        bt_int_signCA.Name = "bt_int_signCA";
        bt_int_signCA.Size = new Size(86, 31);
        bt_int_signCA.TabIndex = 110;
        bt_int_signCA.Text = "signTest";
        bt_int_signCA.UseVisualStyleBackColor = true;
        bt_int_signCA.CustomClick += CustomButton2_CustomClick;
        // 
        // Bt_int_rd_fqdn
        // 
        Bt_int_rd_fqdn._certInfo = PL.Utils.Tools.info.CertInfoWrite;
        Bt_int_rd_fqdn._certType = PL.Utils.Tools.certType.priv;
        Bt_int_rd_fqdn._fqdnType = PL.Utils.Tools.fdqnType.read;
        Bt_int_rd_fqdn._serverType = PL.Utils.Tools.serverType.intermediate;
        Bt_int_rd_fqdn.Location = new Point(336, 396);
        Bt_int_rd_fqdn.Margin = new Padding(3, 4, 3, 4);
        Bt_int_rd_fqdn.Name = "Bt_int_rd_fqdn";
        Bt_int_rd_fqdn.Size = new Size(86, 31);
        Bt_int_rd_fqdn.TabIndex = 111;
        Bt_int_rd_fqdn.Text = "rd fqdn";
        Bt_int_rd_fqdn.UseVisualStyleBackColor = true;
        Bt_int_rd_fqdn.CustomClick += CustomButton1_CustomClick;
        // 
        // Bt_int_wr_fqdn
        // 
        Bt_int_wr_fqdn._certInfo = PL.Utils.Tools.info.CertInfoWrite;
        Bt_int_wr_fqdn._certType = PL.Utils.Tools.certType.priv;
        Bt_int_wr_fqdn._fqdnType = PL.Utils.Tools.fdqnType.write;
        Bt_int_wr_fqdn._serverType = PL.Utils.Tools.serverType.intermediate;
        Bt_int_wr_fqdn.Location = new Point(432, 396);
        Bt_int_wr_fqdn.Margin = new Padding(3, 4, 3, 4);
        Bt_int_wr_fqdn.Name = "Bt_int_wr_fqdn";
        Bt_int_wr_fqdn.Size = new Size(86, 31);
        Bt_int_wr_fqdn.TabIndex = 112;
        Bt_int_wr_fqdn.Text = "wr fqdn";
        Bt_int_wr_fqdn.UseVisualStyleBackColor = true;
        Bt_int_wr_fqdn.CustomClick += CustomButton1_CustomClick;
        // 
        // Bt_ca_fqdn_write
        // 
        Bt_ca_fqdn_write._certInfo = PL.Utils.Tools.info.CertInfoWrite;
        Bt_ca_fqdn_write._certType = PL.Utils.Tools.certType.priv;
        Bt_ca_fqdn_write._fqdnType = PL.Utils.Tools.fdqnType.write;
        Bt_ca_fqdn_write._serverType = PL.Utils.Tools.serverType.ca;
        Bt_ca_fqdn_write.Location = new Point(127, 396);
        Bt_ca_fqdn_write.Margin = new Padding(3, 4, 3, 4);
        Bt_ca_fqdn_write.Name = "Bt_ca_fqdn_write";
        Bt_ca_fqdn_write.Size = new Size(86, 31);
        Bt_ca_fqdn_write.TabIndex = 114;
        Bt_ca_fqdn_write.Text = "wr fqdn";
        Bt_ca_fqdn_write.UseVisualStyleBackColor = true;
        Bt_ca_fqdn_write.CustomClick += CustomButton1_CustomClick;
        // 
        // Bt_ca_fqdn_read
        // 
        Bt_ca_fqdn_read._certInfo = PL.Utils.Tools.info.CertInfoWrite;
        Bt_ca_fqdn_read._certType = PL.Utils.Tools.certType.priv;
        Bt_ca_fqdn_read._fqdnType = PL.Utils.Tools.fdqnType.read;
        Bt_ca_fqdn_read._serverType = PL.Utils.Tools.serverType.ca;
        Bt_ca_fqdn_read.Location = new Point(31, 396);
        Bt_ca_fqdn_read.Margin = new Padding(3, 4, 3, 4);
        Bt_ca_fqdn_read.Name = "Bt_ca_fqdn_read";
        Bt_ca_fqdn_read.Size = new Size(86, 31);
        Bt_ca_fqdn_read.TabIndex = 113;
        Bt_ca_fqdn_read.Text = "rd fqdn";
        Bt_ca_fqdn_read.UseVisualStyleBackColor = true;
        Bt_ca_fqdn_read.CustomClick += CustomButton1_CustomClick;
        // 
        // Bt_server_wr_fqdn
        // 
        Bt_server_wr_fqdn._certInfo = PL.Utils.Tools.info.CertInfoWrite;
        Bt_server_wr_fqdn._certType = PL.Utils.Tools.certType.priv;
        Bt_server_wr_fqdn._fqdnType = PL.Utils.Tools.fdqnType.write;
        Bt_server_wr_fqdn._serverType = PL.Utils.Tools.serverType.server;
        Bt_server_wr_fqdn.Location = new Point(725, 396);
        Bt_server_wr_fqdn.Margin = new Padding(3, 4, 3, 4);
        Bt_server_wr_fqdn.Name = "Bt_server_wr_fqdn";
        Bt_server_wr_fqdn.Size = new Size(86, 31);
        Bt_server_wr_fqdn.TabIndex = 116;
        Bt_server_wr_fqdn.Text = "wr fqdn";
        Bt_server_wr_fqdn.UseVisualStyleBackColor = true;
        Bt_server_wr_fqdn.CustomClick += CustomButton1_CustomClick;
        // 
        // Bt_server_rd_fqdn
        // 
        Bt_server_rd_fqdn._certInfo = PL.Utils.Tools.info.CertInfoWrite;
        Bt_server_rd_fqdn._certType = PL.Utils.Tools.certType.priv;
        Bt_server_rd_fqdn._fqdnType = PL.Utils.Tools.fdqnType.read;
        Bt_server_rd_fqdn._serverType = PL.Utils.Tools.serverType.server;
        Bt_server_rd_fqdn.Location = new Point(629, 396);
        Bt_server_rd_fqdn.Margin = new Padding(3, 4, 3, 4);
        Bt_server_rd_fqdn.Name = "Bt_server_rd_fqdn";
        Bt_server_rd_fqdn.Size = new Size(86, 31);
        Bt_server_rd_fqdn.TabIndex = 115;
        Bt_server_rd_fqdn.Text = "rd fqdn";
        Bt_server_rd_fqdn.UseVisualStyleBackColor = true;
        Bt_server_rd_fqdn.CustomClick += CustomButton1_CustomClick;
        // 
        // Bt_user_wr_fqdn
        // 
        Bt_user_wr_fqdn._certInfo = PL.Utils.Tools.info.CertInfoWrite;
        Bt_user_wr_fqdn._certType = PL.Utils.Tools.certType.priv;
        Bt_user_wr_fqdn._fqdnType = PL.Utils.Tools.fdqnType.write;
        Bt_user_wr_fqdn._serverType = PL.Utils.Tools.serverType.user;
        Bt_user_wr_fqdn.Location = new Point(967, 396);
        Bt_user_wr_fqdn.Margin = new Padding(3, 4, 3, 4);
        Bt_user_wr_fqdn.Name = "Bt_user_wr_fqdn";
        Bt_user_wr_fqdn.Size = new Size(86, 31);
        Bt_user_wr_fqdn.TabIndex = 118;
        Bt_user_wr_fqdn.Text = "wr fqdn";
        Bt_user_wr_fqdn.UseVisualStyleBackColor = true;
        Bt_user_wr_fqdn.CustomClick += CustomButton1_CustomClick;
        // 
        // Bt_user_rd_fqdn
        // 
        Bt_user_rd_fqdn._certInfo = PL.Utils.Tools.info.CertInfoWrite;
        Bt_user_rd_fqdn._certType = PL.Utils.Tools.certType.priv;
        Bt_user_rd_fqdn._fqdnType = PL.Utils.Tools.fdqnType.read;
        Bt_user_rd_fqdn._serverType = PL.Utils.Tools.serverType.user;
        Bt_user_rd_fqdn.Location = new Point(867, 396);
        Bt_user_rd_fqdn.Margin = new Padding(3, 4, 3, 4);
        Bt_user_rd_fqdn.Name = "Bt_user_rd_fqdn";
        Bt_user_rd_fqdn.Size = new Size(86, 31);
        Bt_user_rd_fqdn.TabIndex = 117;
        Bt_user_rd_fqdn.Text = "rd fqdn";
        Bt_user_rd_fqdn.UseVisualStyleBackColor = true;
        Bt_user_rd_fqdn.CustomClick += CustomButton1_CustomClick;
        // 
        // customButton4
        // 
        customButton4._certInfo = PL.Utils.Tools.info.CertInfoWrite;
        customButton4._certType = PL.Utils.Tools.certType.signed;
        customButton4._fqdnType = PL.Utils.Tools.fdqnType.write;
        customButton4._serverType = PL.Utils.Tools.serverType.server;
        customButton4.Location = new Point(629, 357);
        customButton4.Margin = new Padding(3, 4, 3, 4);
        customButton4.Name = "customButton4";
        customButton4.Size = new Size(86, 31);
        customButton4.TabIndex = 121;
        customButton4.Text = "signTest";
        customButton4.UseVisualStyleBackColor = true;
        customButton4.CustomClick += CustomButton2_CustomClick;
        // 
        // customButton5
        // 
        customButton5._certInfo = PL.Utils.Tools.info.CertInfoWrite;
        customButton5._certType = PL.Utils.Tools.certType.pub;
        customButton5._fqdnType = PL.Utils.Tools.fdqnType.write;
        customButton5._serverType = PL.Utils.Tools.serverType.server;
        customButton5.Location = new Point(721, 319);
        customButton5.Margin = new Padding(3, 4, 3, 4);
        customButton5.Name = "customButton5";
        customButton5.Size = new Size(86, 31);
        customButton5.TabIndex = 120;
        customButton5.Text = "pubTest";
        customButton5.UseVisualStyleBackColor = true;
        customButton5.CustomClick += CustomButton2_CustomClick;
        // 
        // Bt_server_
        // 
        Bt_server_._certInfo = PL.Utils.Tools.info.CertInfoWrite;
        Bt_server_._certType = PL.Utils.Tools.certType.priv;
        Bt_server_._fqdnType = PL.Utils.Tools.fdqnType.write;
        Bt_server_._serverType = PL.Utils.Tools.serverType.server;
        Bt_server_.Location = new Point(629, 319);
        Bt_server_.Margin = new Padding(3, 4, 3, 4);
        Bt_server_.Name = "Bt_server_";
        Bt_server_.Size = new Size(86, 31);
        Bt_server_.TabIndex = 119;
        Bt_server_.Text = "privTest";
        Bt_server_.UseVisualStyleBackColor = true;
        Bt_server_.CustomClick += CustomButton2_CustomClick;
        // 
        // customButton6
        // 
        customButton6._certInfo = PL.Utils.Tools.info.CertInfoWrite;
        customButton6._certType = PL.Utils.Tools.certType.signed;
        customButton6._fqdnType = PL.Utils.Tools.fdqnType.write;
        customButton6._serverType = PL.Utils.Tools.serverType.user;
        customButton6.Location = new Point(867, 357);
        customButton6.Margin = new Padding(3, 4, 3, 4);
        customButton6.Name = "customButton6";
        customButton6.Size = new Size(86, 31);
        customButton6.TabIndex = 124;
        customButton6.Text = "signTest";
        customButton6.UseVisualStyleBackColor = true;
        customButton6.CustomClick += CustomButton2_CustomClick;
        // 
        // customButton7
        // 
        customButton7._certInfo = PL.Utils.Tools.info.CertInfoWrite;
        customButton7._certType = PL.Utils.Tools.certType.pub;
        customButton7._fqdnType = PL.Utils.Tools.fdqnType.write;
        customButton7._serverType = PL.Utils.Tools.serverType.user;
        customButton7.Location = new Point(967, 319);
        customButton7.Margin = new Padding(3, 4, 3, 4);
        customButton7.Name = "customButton7";
        customButton7.Size = new Size(86, 31);
        customButton7.TabIndex = 123;
        customButton7.Text = "pubTest";
        customButton7.UseVisualStyleBackColor = true;
        customButton7.CustomClick += CustomButton2_CustomClick;
        // 
        // customButton8
        // 
        customButton8._certInfo = PL.Utils.Tools.info.CertInfoWrite;
        customButton8._certType = PL.Utils.Tools.certType.priv;
        customButton8._fqdnType = PL.Utils.Tools.fdqnType.write;
        customButton8._serverType = PL.Utils.Tools.serverType.user;
        customButton8.Location = new Point(867, 319);
        customButton8.Margin = new Padding(3, 4, 3, 4);
        customButton8.Name = "customButton8";
        customButton8.Size = new Size(86, 31);
        customButton8.TabIndex = 122;
        customButton8.Text = "privTest";
        customButton8.UseVisualStyleBackColor = true;
        customButton8.CustomClick += CustomButton2_CustomClick;
        // 
        // customButton3
        // 
        customButton3._certInfo = PL.Utils.Tools.info.CertInfoWrite;
        customButton3._certType = PL.Utils.Tools.certType.priv;
        customButton3._fqdnType = PL.Utils.Tools.fdqnType.write;
        customButton3._serverType = PL.Utils.Tools.serverType.ca;
        customButton3.Location = new Point(31, 435);
        customButton3.Margin = new Padding(3, 4, 3, 4);
        customButton3.Name = "customButton3";
        customButton3.Size = new Size(86, 31);
        customButton3.TabIndex = 125;
        customButton3.Text = "rdCertInfo";
        customButton3.UseVisualStyleBackColor = true;
        customButton3.CustomClick += certificateInfo_CustomClick;
        // 
        // customButton9
        // 
        customButton9._certInfo = PL.Utils.Tools.info.CertInfoWrite;
        customButton9._certType = PL.Utils.Tools.certType.priv;
        customButton9._fqdnType = PL.Utils.Tools.fdqnType.write;
        customButton9._serverType = PL.Utils.Tools.serverType.ca;
        customButton9.Location = new Point(127, 435);
        customButton9.Margin = new Padding(3, 4, 3, 4);
        customButton9.Name = "customButton9";
        customButton9.Size = new Size(86, 31);
        customButton9.TabIndex = 126;
        customButton9.Text = "wrCertInfo";
        customButton9.UseVisualStyleBackColor = true;
        customButton9.CustomClick += certificateInfo_CustomClick;
        // 
        // customButton10
        // 
        customButton10._certInfo = PL.Utils.Tools.info.CertInfoWrite;
        customButton10._certType = PL.Utils.Tools.certType.priv;
        customButton10._fqdnType = PL.Utils.Tools.fdqnType.write;
        customButton10._serverType = PL.Utils.Tools.serverType.intermediate;
        customButton10.Location = new Point(432, 435);
        customButton10.Margin = new Padding(3, 4, 3, 4);
        customButton10.Name = "customButton10";
        customButton10.Size = new Size(86, 31);
        customButton10.TabIndex = 128;
        customButton10.Text = "wrCertInfo";
        customButton10.UseVisualStyleBackColor = true;
        customButton10.CustomClick += certificateInfo_CustomClick;
        // 
        // customButton11
        // 
        customButton11._certInfo = PL.Utils.Tools.info.CertInfoWrite;
        customButton11._certType = PL.Utils.Tools.certType.priv;
        customButton11._fqdnType = PL.Utils.Tools.fdqnType.write;
        customButton11._serverType = PL.Utils.Tools.serverType.intermediate;
        customButton11.Location = new Point(336, 435);
        customButton11.Margin = new Padding(3, 4, 3, 4);
        customButton11.Name = "customButton11";
        customButton11.Size = new Size(86, 31);
        customButton11.TabIndex = 127;
        customButton11.Text = "rdCertInfo";
        customButton11.UseVisualStyleBackColor = true;
        customButton11.CustomClick += certificateInfo_CustomClick;
        // 
        // customButton12
        // 
        customButton12._certInfo = PL.Utils.Tools.info.CertInfoWrite;
        customButton12._certType = PL.Utils.Tools.certType.priv;
        customButton12._fqdnType = PL.Utils.Tools.fdqnType.write;
        customButton12._serverType = PL.Utils.Tools.serverType.server;
        customButton12.Location = new Point(725, 435);
        customButton12.Margin = new Padding(3, 4, 3, 4);
        customButton12.Name = "customButton12";
        customButton12.Size = new Size(86, 31);
        customButton12.TabIndex = 130;
        customButton12.Text = "wrCertInfo";
        customButton12.UseVisualStyleBackColor = true;
        customButton12.CustomClick += certificateInfo_CustomClick;
        // 
        // customButton13
        // 
        customButton13._certInfo = PL.Utils.Tools.info.CertInfoWrite;
        customButton13._certType = PL.Utils.Tools.certType.priv;
        customButton13._fqdnType = PL.Utils.Tools.fdqnType.write;
        customButton13._serverType = PL.Utils.Tools.serverType.server;
        customButton13.Location = new Point(629, 435);
        customButton13.Margin = new Padding(3, 4, 3, 4);
        customButton13.Name = "customButton13";
        customButton13.Size = new Size(86, 31);
        customButton13.TabIndex = 129;
        customButton13.Text = "rdCertInfo";
        customButton13.UseVisualStyleBackColor = true;
        customButton13.CustomClick += certificateInfo_CustomClick;
        // 
        // customButton14
        // 
        customButton14._certInfo = PL.Utils.Tools.info.CertInfoWrite;
        customButton14._certType = PL.Utils.Tools.certType.priv;
        customButton14._fqdnType = PL.Utils.Tools.fdqnType.write;
        customButton14._serverType = PL.Utils.Tools.serverType.user;
        customButton14.Location = new Point(967, 435);
        customButton14.Margin = new Padding(3, 4, 3, 4);
        customButton14.Name = "customButton14";
        customButton14.Size = new Size(86, 31);
        customButton14.TabIndex = 132;
        customButton14.Text = "wrCertInfo";
        customButton14.UseVisualStyleBackColor = true;
        customButton14.CustomClick += certificateInfo_CustomClick;
        // 
        // customButton15
        // 
        customButton15._certInfo = PL.Utils.Tools.info.CertInfoWrite;
        customButton15._certType = PL.Utils.Tools.certType.priv;
        customButton15._fqdnType = PL.Utils.Tools.fdqnType.write;
        customButton15._serverType = PL.Utils.Tools.serverType.user;
        customButton15.Location = new Point(871, 435);
        customButton15.Margin = new Padding(3, 4, 3, 4);
        customButton15.Name = "customButton15";
        customButton15.Size = new Size(86, 31);
        customButton15.TabIndex = 131;
        customButton15.Text = "rdCertInfo";
        customButton15.UseVisualStyleBackColor = true;
        customButton15.CustomClick += certificateInfo_CustomClick;
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
        Gb_serverCredentials.Location = new Point(31, 779);
        Gb_serverCredentials.Margin = new Padding(3, 4, 3, 4);
        Gb_serverCredentials.Name = "Gb_serverCredentials";
        Gb_serverCredentials.Padding = new Padding(3, 4, 3, 4);
        Gb_serverCredentials.Size = new Size(229, 233);
        Gb_serverCredentials.TabIndex = 133;
        Gb_serverCredentials.TabStop = false;
        Gb_serverCredentials.Text = "Server Credentials";
        // 
        // Cb_autoUpload
        // 
        Cb_autoUpload.AutoSize = true;
        Cb_autoUpload.CheckAlign = ContentAlignment.MiddleRight;
        Cb_autoUpload.Location = new Point(7, 195);
        Cb_autoUpload.Margin = new Padding(3, 4, 3, 4);
        Cb_autoUpload.Name = "Cb_autoUpload";
        Cb_autoUpload.Size = new Size(119, 24);
        Cb_autoUpload.TabIndex = 136;
        Cb_autoUpload.Text = "Auto Upload:";
        Cb_autoUpload.TextAlign = ContentAlignment.MiddleRight;
        Cb_autoUpload.TextImageRelation = TextImageRelation.TextBeforeImage;
        Cb_autoUpload.UseVisualStyleBackColor = true;
        // 
        // Tb_password_nd
        // 
        Tb_password_nd.Location = new Point(97, 152);
        Tb_password_nd.Margin = new Padding(3, 4, 3, 4);
        Tb_password_nd.MaxLength = 100;
        Tb_password_nd.Name = "Tb_password_nd";
        Tb_password_nd.Size = new Size(114, 27);
        Tb_password_nd.TabIndex = 135;
        Tb_password_nd.UseSystemPasswordChar = true;
        // 
        // Tb_password_st
        // 
        Tb_password_st.Location = new Point(97, 113);
        Tb_password_st.Margin = new Padding(3, 4, 3, 4);
        Tb_password_st.MaxLength = 100;
        Tb_password_st.Name = "Tb_password_st";
        Tb_password_st.Size = new Size(114, 27);
        Tb_password_st.TabIndex = 134;
        Tb_password_st.UseSystemPasswordChar = true;
        // 
        // Tb_username
        // 
        Tb_username.Location = new Point(97, 75);
        Tb_username.Margin = new Padding(3, 4, 3, 4);
        Tb_username.Name = "Tb_username";
        Tb_username.Size = new Size(114, 27);
        Tb_username.TabIndex = 4;
        // 
        // Tb_hostname
        // 
        Tb_hostname.Location = new Point(97, 36);
        Tb_hostname.Margin = new Padding(3, 4, 3, 4);
        Tb_hostname.Name = "Tb_hostname";
        Tb_hostname.Size = new Size(114, 27);
        Tb_hostname.TabIndex = 3;
        // 
        // Lb_password
        // 
        Lb_password.AutoSize = true;
        Lb_password.Location = new Point(16, 124);
        Lb_password.Name = "Lb_password";
        Lb_password.Size = new Size(73, 20);
        Lb_password.TabIndex = 2;
        Lb_password.Text = "Password:";
        Lb_password.TextAlign = ContentAlignment.TopRight;
        // 
        // Lb_username
        // 
        Lb_username.AutoSize = true;
        Lb_username.Location = new Point(13, 85);
        Lb_username.Name = "Lb_username";
        Lb_username.Size = new Size(78, 20);
        Lb_username.TabIndex = 1;
        Lb_username.Text = "Username:";
        Lb_username.TextAlign = ContentAlignment.TopRight;
        // 
        // Lb_hostname
        // 
        Lb_hostname.AutoSize = true;
        Lb_hostname.Location = new Point(10, 47);
        Lb_hostname.Name = "Lb_hostname";
        Lb_hostname.Size = new Size(80, 20);
        Lb_hostname.TabIndex = 0;
        Lb_hostname.Text = "Hostname:";
        Lb_hostname.TextAlign = ContentAlignment.TopRight;
        // 
        // Bt_ca_ServerCred
        // 
        Bt_ca_ServerCred._certInfo = PL.Utils.Tools.info.ServerCredentialWrite;
        Bt_ca_ServerCred._certType = PL.Utils.Tools.certType.priv;
        Bt_ca_ServerCred._fqdnType = PL.Utils.Tools.fdqnType.write;
        Bt_ca_ServerCred._serverType = PL.Utils.Tools.serverType.ca;
        Bt_ca_ServerCred.Location = new Point(129, 357);
        Bt_ca_ServerCred.Margin = new Padding(3, 4, 3, 4);
        Bt_ca_ServerCred.Name = "Bt_ca_ServerCred";
        Bt_ca_ServerCred.Size = new Size(86, 31);
        Bt_ca_ServerCred.TabIndex = 134;
        Bt_ca_ServerCred.Text = "Server";
        Bt_ca_ServerCred.UseVisualStyleBackColor = true;
        Bt_ca_ServerCred.CustomClick += ServerCredential;
        // 
        // Bt_int_ServerCred
        // 
        Bt_int_ServerCred._certInfo = PL.Utils.Tools.info.ServerCredentialWrite;
        Bt_int_ServerCred._certType = PL.Utils.Tools.certType.priv;
        Bt_int_ServerCred._fqdnType = PL.Utils.Tools.fdqnType.write;
        Bt_int_ServerCred._serverType = PL.Utils.Tools.serverType.intermediate;
        Bt_int_ServerCred.Location = new Point(432, 357);
        Bt_int_ServerCred.Margin = new Padding(3, 4, 3, 4);
        Bt_int_ServerCred.Name = "Bt_int_ServerCred";
        Bt_int_ServerCred.Size = new Size(86, 31);
        Bt_int_ServerCred.TabIndex = 135;
        Bt_int_ServerCred.Text = "Server";
        Bt_int_ServerCred.UseVisualStyleBackColor = true;
        Bt_int_ServerCred.CustomClick += ServerCredential;
        // 
        // Bt_server_ServerCred
        // 
        Bt_server_ServerCred._certInfo = PL.Utils.Tools.info.ServerCredentialWrite;
        Bt_server_ServerCred._certType = PL.Utils.Tools.certType.priv;
        Bt_server_ServerCred._fqdnType = PL.Utils.Tools.fdqnType.write;
        Bt_server_ServerCred._serverType = PL.Utils.Tools.serverType.server;
        Bt_server_ServerCred.Location = new Point(721, 357);
        Bt_server_ServerCred.Margin = new Padding(3, 4, 3, 4);
        Bt_server_ServerCred.Name = "Bt_server_ServerCred";
        Bt_server_ServerCred.Size = new Size(86, 31);
        Bt_server_ServerCred.TabIndex = 136;
        Bt_server_ServerCred.Text = "Server";
        Bt_server_ServerCred.UseVisualStyleBackColor = true;
        // 
        // Server
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1058, 1015);
        Controls.Add(Bt_server_ServerCred);
        Controls.Add(Bt_int_ServerCred);
        Controls.Add(Bt_ca_ServerCred);
        Controls.Add(Gb_serverCredentials);
        Controls.Add(customButton14);
        Controls.Add(customButton15);
        Controls.Add(customButton12);
        Controls.Add(customButton13);
        Controls.Add(customButton10);
        Controls.Add(customButton11);
        Controls.Add(customButton9);
        Controls.Add(customButton3);
        Controls.Add(customButton6);
        Controls.Add(customButton7);
        Controls.Add(customButton8);
        Controls.Add(customButton4);
        Controls.Add(customButton5);
        Controls.Add(Bt_server_);
        Controls.Add(Bt_user_wr_fqdn);
        Controls.Add(Bt_user_rd_fqdn);
        Controls.Add(Bt_server_wr_fqdn);
        Controls.Add(Bt_server_rd_fqdn);
        Controls.Add(Bt_ca_fqdn_write);
        Controls.Add(Bt_ca_fqdn_read);
        Controls.Add(Bt_int_wr_fqdn);
        Controls.Add(Bt_int_rd_fqdn);
        Controls.Add(bt_int_signCA);
        Controls.Add(bt_int_pub);
        Controls.Add(bt_ca_selfSigned);
        Controls.Add(Bt_ca_pub);
        Controls.Add(customButton2);
        Controls.Add(customButton1);
        Controls.Add(Lbl_remotePath_pub);
        Controls.Add(treeView1);
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
        Controls.Add(gb_default_disti_names);
        Controls.Add(lbl_ca_name);
        MainMenuStrip = menuStrip1;
        Margin = new Padding(2, 3, 2, 3);
        Name = "Server";
        Text = "server";
        Load += server_onLoad;
        gb_default_disti_names.ResumeLayout(false);
        gb_default_disti_names.PerformLayout();
        menuStrip1.ResumeLayout(false);
        menuStrip1.PerformLayout();
        Lbl_remotePath_pub.ResumeLayout(false);
        Lbl_remotePath_pub.PerformLayout();
        Gb_serverCredentials.ResumeLayout(false);
        Gb_serverCredentials.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion
    public TextBox tb_ca_name;
    private GroupBox gb_default_disti_names;
    private TextBox tb_sub_email;
    private TextBox tb_sub_cn;
    private TextBox tb_sub_orga;
    private TextBox tb_sub_ou;
    private TextBox tb_sub_loc;
    private TextBox tb_sub_st;
    private TextBox tb_sub_c;
    private Label lbl_def_email;
    private Label lbl_def_commonName;
    private Label lbl_def_organisationUnit;
    private Label lbl_def_organisation;
    private Label lbl_def_location;
    private Label lbl_def_state;
    private Label lbl_def_country;
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
    private TreeView treeView1;
    private GroupBox Lbl_remotePath_pub;
    private SaveFileDialog saveFileDialog1;
    private Button button_custom;
    private CustomButton customButton1;
    private CustomButton customButton2;
    private CustomButton Bt_ca_pub;
    private CustomButton bt_ca_selfSigned;
    private CustomButton bt_int_pub;
    private CustomButton bt_int_signCA;
    private CustomButton Bt_int_rd_fqdn;
    private CustomButton Bt_int_wr_fqdn;
    private CustomButton Bt_ca_fqdn_write;
    private CustomButton Bt_ca_fqdn_read;
    private CustomButton Bt_server_wr_fqdn;
    private CustomButton Bt_server_rd_fqdn;
    private CustomButton Bt_user_wr_fqdn;
    private CustomButton Bt_user_rd_fqdn;
    private CustomButton customButton4;
    private CustomButton customButton5;
    private CustomButton Bt_server_;
    private CustomButton customButton6;
    private CustomButton customButton7;
    private CustomButton customButton8;
    private Label Lbl_remotePath_priv;
    public TextBox Tb_priv_remPath;
    public TextBox Tb_pub_filename;
    private Label Lbl_filename_pub;
    private CustomButton customButton3;
    private CustomButton customButton9;
    private CustomButton customButton10;
    private CustomButton customButton11;
    private CustomButton customButton12;
    private CustomButton customButton13;
    private CustomButton customButton14;
    private CustomButton customButton15;
    private TextBox Tb_san4;
    private TextBox Tb_san3;
    private TextBox Tb_san2;
    private TextBox Tb_san1;
    private ComboBox Cb_san4;
    private ComboBox Cb_san3;
    private ComboBox Cb_san2;
    private ComboBox Cb_san1;
    private GroupBox Gb_serverCredentials;
    private Label Lb_password;
    private Label Lb_username;
    private Label Lb_hostname;
    private TextBox Tb_password_nd;
    private TextBox Tb_password_st;
    private TextBox Tb_username;
    private TextBox Tb_hostname;
    private CustomButton Bt_ca_ServerCred;
    private CustomButton Bt_int_ServerCred;
    private CustomButton Bt_server_ServerCred;
    private CheckBox Cb_autoUpload;
}
