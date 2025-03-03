﻿namespace SCG.Forms;

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
        tb_sub_email = new TextBox();
        tb_sub_cn = new TextBox();
        tb_sub_orga = new TextBox();
        tb_sub_ou = new TextBox();
        tb_sub_loc = new TextBox();
        tb_sub_st = new TextBox();
        bt_wrt_dest_names = new Button();
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
        rb_ca = new RadioButton();
        rb_intermediate = new RadioButton();
        rb_server = new RadioButton();
        panel1 = new Panel();
        rb_user = new RadioButton();
        Bt_gen_ca_priv = new Button();
        Bt_gen_ca_selfSigned_key = new Button();
        cb_isCa = new CheckBox();
        cb_notPathlen = new CheckBox();
        cb_critical = new CheckBox();
        cb_depth = new ComboBox();
        lbl_unlimDepth = new Label();
        panel2 = new Panel();
        Bt_wrt_param = new Button();
        lb_int_certs = new ListBox();
        Bt_gen_int_priv = new Button();
        lbl_int_keySize = new Label();
        cb_int_keySize = new ComboBox();
        tb_int_dura = new TextBox();
        lbl_int_duration = new Label();
        tb_int_name = new TextBox();
        lbl_int_name = new Label();
        cb_new_int = new CheckBox();
        Bt_gen_int_pub = new Button();
        Bt_gen_ca_pub = new Button();
        Bt_gen_int_selfSigned_key = new Button();
        Bt_read_ca_subj = new Button();
        Bt_read_int_subj = new Button();
        Bt_read_server_subj = new Button();
        Bt_gen_server_selfSigned_key = new Button();
        Bt_gen_server_pub = new Button();
        cb_new_server = new CheckBox();
        tb_server_name = new TextBox();
        lbl_server_name = new Label();
        lbl_server_keySize = new Label();
        cb_server_keySize = new ComboBox();
        tb_server_dura = new TextBox();
        lbl_server_duration = new Label();
        Bt_gen_server_priv = new Button();
        lb_server_certs = new ListBox();
        Bt_read_user_subj = new Button();
        Bt_gen_user_selfSigned_key = new Button();
        Bt_gen_user_pub = new Button();
        cb_new_user = new CheckBox();
        tb_user_name = new TextBox();
        lbl_user_name = new Label();
        lbl_user_keySize = new Label();
        cb_user_keySize = new ComboBox();
        tb_user_dura = new TextBox();
        lbl_user_duration = new Label();
        Bt_gen_user_priv = new Button();
        lb_user_certs = new ListBox();
        lb_ca_sn = new Label();
        lb_int_sn = new Label();
        lb_serv_sn = new Label();
        lb_user_sn = new Label();
        tb_ca_sn = new TextBox();
        textBox1 = new TextBox();
        textBox2 = new TextBox();
        textBox3 = new TextBox();
        Bt_reCreate_ca_selfSigned_key = new Button();
        button1 = new Button();
        button2 = new Button();
        button3 = new Button();
        button4 = new Button();
        Bt_ca_uploadCert = new Button();
        Tb_cert_filename = new TextBox();
        Lbl_ca_filename_cert = new Label();
        Lbl_ca_fileExtension_Priv = new Label();
        Cb_file_priv_ext = new ComboBox();
        Lbl_ca_fileExtension_Pub = new Label();
        Cb_file_pub_ext = new ComboBox();
        Tb_cert_remote_path = new TextBox();
        menuStrip1 = new MenuStrip();
        editToolStripMenuItem = new ToolStripMenuItem();
        ms_edit_config = new ToolStripMenuItem();
        Lb_cert_remotePath = new Label();
        Bt_wr_cert_path = new Button();
        treeView1 = new TreeView();
        Gb_cert_details = new GroupBox();
        saveFileDialog1 = new SaveFileDialog();
        Bt_int_uploadCert = new Button();
        Bt_server_uploadCert = new Button();
        button5 = new Button();
        gb_default_disti_names.SuspendLayout();
        panel1.SuspendLayout();
        panel2.SuspendLayout();
        menuStrip1.SuspendLayout();
        Gb_cert_details.SuspendLayout();
        SuspendLayout();
        // 
        // tb_ca_name
        // 
        tb_ca_name.Location = new Point(151, 340);
        tb_ca_name.Margin = new Padding(5, 6, 5, 6);
        tb_ca_name.Name = "tb_ca_name";
        tb_ca_name.Size = new Size(169, 35);
        tb_ca_name.TabIndex = 12;
        // 
        // gb_default_disti_names
        // 
        gb_default_disti_names.Controls.Add(tb_sub_email);
        gb_default_disti_names.Controls.Add(tb_sub_cn);
        gb_default_disti_names.Controls.Add(tb_sub_orga);
        gb_default_disti_names.Controls.Add(tb_sub_ou);
        gb_default_disti_names.Controls.Add(tb_sub_loc);
        gb_default_disti_names.Controls.Add(tb_sub_st);
        gb_default_disti_names.Controls.Add(bt_wrt_dest_names);
        gb_default_disti_names.Controls.Add(tb_sub_c);
        gb_default_disti_names.Controls.Add(lbl_def_email);
        gb_default_disti_names.Controls.Add(lbl_def_commonName);
        gb_default_disti_names.Controls.Add(lbl_def_organisationUnit);
        gb_default_disti_names.Controls.Add(lbl_def_organisation);
        gb_default_disti_names.Controls.Add(lbl_def_location);
        gb_default_disti_names.Controls.Add(lbl_def_state);
        gb_default_disti_names.Controls.Add(lbl_def_country);
        gb_default_disti_names.Location = new Point(826, 1234);
        gb_default_disti_names.Margin = new Padding(5, 6, 5, 6);
        gb_default_disti_names.Name = "gb_default_disti_names";
        gb_default_disti_names.Padding = new Padding(5, 6, 5, 6);
        gb_default_disti_names.Size = new Size(393, 478);
        gb_default_disti_names.TabIndex = 11;
        gb_default_disti_names.TabStop = false;
        gb_default_disti_names.Text = "Default Distinguished Names";
        // 
        // tb_sub_email
        // 
        tb_sub_email.Location = new Point(194, 360);
        tb_sub_email.Margin = new Padding(5, 6, 5, 6);
        tb_sub_email.Name = "tb_sub_email";
        tb_sub_email.Size = new Size(169, 35);
        tb_sub_email.TabIndex = 13;
        // 
        // tb_sub_cn
        // 
        tb_sub_cn.Location = new Point(194, 308);
        tb_sub_cn.Margin = new Padding(5, 6, 5, 6);
        tb_sub_cn.Name = "tb_sub_cn";
        tb_sub_cn.Size = new Size(169, 35);
        tb_sub_cn.TabIndex = 12;
        // 
        // tb_sub_orga
        // 
        tb_sub_orga.Location = new Point(194, 260);
        tb_sub_orga.Margin = new Padding(5, 6, 5, 6);
        tb_sub_orga.Name = "tb_sub_orga";
        tb_sub_orga.Size = new Size(169, 35);
        tb_sub_orga.TabIndex = 11;
        // 
        // tb_sub_ou
        // 
        tb_sub_ou.Location = new Point(194, 212);
        tb_sub_ou.Margin = new Padding(5, 6, 5, 6);
        tb_sub_ou.Name = "tb_sub_ou";
        tb_sub_ou.Size = new Size(169, 35);
        tb_sub_ou.TabIndex = 10;
        // 
        // tb_sub_loc
        // 
        tb_sub_loc.Location = new Point(194, 162);
        tb_sub_loc.Margin = new Padding(5, 6, 5, 6);
        tb_sub_loc.Name = "tb_sub_loc";
        tb_sub_loc.Size = new Size(169, 35);
        tb_sub_loc.TabIndex = 9;
        // 
        // tb_sub_st
        // 
        tb_sub_st.Location = new Point(194, 112);
        tb_sub_st.Margin = new Padding(5, 6, 5, 6);
        tb_sub_st.Name = "tb_sub_st";
        tb_sub_st.Size = new Size(169, 35);
        tb_sub_st.TabIndex = 8;
        // 
        // bt_wrt_dest_names
        // 
        bt_wrt_dest_names.Location = new Point(127, 400);
        bt_wrt_dest_names.Margin = new Padding(3, 4, 3, 4);
        bt_wrt_dest_names.Name = "bt_wrt_dest_names";
        bt_wrt_dest_names.Size = new Size(130, 52);
        bt_wrt_dest_names.TabIndex = 25;
        bt_wrt_dest_names.Text = "3. Write Dest";
        bt_wrt_dest_names.UseVisualStyleBackColor = true;
        bt_wrt_dest_names.Click += bt_wrt_dest_names_Click;
        // 
        // tb_sub_c
        // 
        tb_sub_c.AutoCompleteCustomSource.AddRange(new string[] { "AF", "EG", "AX", "AL", "DZ", "AS", "AD", "AO", "AI", "AQ", "AG", "GQ", "AR", "AM", "AW", "AZ", "ET", "AU", "BS", "BH", "BD", "BB", "BY", "BE", "BZ", "BJ", "BM", "BT", "BO", "BA", "BW", "BV", "BR", "IO", "BN", "BG", "BF", "BI", "CL", "CN", "CK", "CR", "CW", "DK", "CD", "DE", "DM", "DO", "DJ", "EC", "SV", "CI", "ER", "EE", "SZ", "FK", "FO", "FJ", "FI", "FM", "FR", "GF", "PF", "TF", "MC", "GA", "GM", "GE", "GH", "GI", "GD", "GR", "GL", "GP", "GU", "GT", "GG", "GN", "GW", "GY", "HT", "HM", "HN", "HK", "IN", "ID", "IM", "IQ", "IR", "IE", "IS", "IL", "IT", "JM", "JP", "YE", "JE", "JO", "VG", "VI", "KY", "KH", "CM", "CA", "CV", "BQ", "KZ", "QA", "KE", "KG", "KI", "UM", "CC", "CO", "KM", "XK", "HR", "CU", "KW", "LA", "LS", "LV", "LB", "LR", "LY", "LI", "LT", "LU", "MO", "MG", "MW", "MY", "MV", "ML", "MT", "MA", "MH", "MQ", "MR", "MU", "YT", "MX", "MD", "MN", "ME", "MS", "MZ", "MM", "NA", "NR", "NP", "NC", "NZ", "NI", "NL", "NE", "NG", "NU", "KP", "MP", "MK", "NF", "NO", "OM", "AT", "TL", "PK", "PS", "PW", "PA", "PG", "PY", "PE", "PH", "PN", "PL", "PT", "PR", "CG", "RE", "RW", "RO", "RU", "MF", "SB", "ZM", "WS", "SM", "BL", "ST", "SA", "SE", "CH", "SN", "RS", "SC", "SL", "ZW", "SG", "SX", "SK", "SI", "SO", "ES", "LK", "SH", "KN", "LC", "PM", "VC", "ZA", "SD", "GS", "KR", "SS", "SR", "SJ", "SY", "TJ", "TW", "TZ", "TH", "TG", "TK", "TO", "TT", "TD", "CZ", "TN", "TR", "TM", "TC", "TV", "UG", "UA", "HU", "UY", "UZ", "VU", "VA", "VE", "AE", "US", "GB", "VN", "WF", "CX", "EH", "CF", "CY" });
        tb_sub_c.CharacterCasing = CharacterCasing.Upper;
        tb_sub_c.Location = new Point(194, 60);
        tb_sub_c.Margin = new Padding(5, 6, 5, 6);
        tb_sub_c.MaxLength = 2;
        tb_sub_c.Name = "tb_sub_c";
        tb_sub_c.Size = new Size(169, 35);
        tb_sub_c.TabIndex = 7;
        // 
        // lbl_def_email
        // 
        lbl_def_email.AutoSize = true;
        lbl_def_email.Location = new Point(113, 366);
        lbl_def_email.Margin = new Padding(5, 0, 5, 0);
        lbl_def_email.Name = "lbl_def_email";
        lbl_def_email.Size = new Size(72, 30);
        lbl_def_email.TabIndex = 6;
        lbl_def_email.Text = "E-Mail";
        // 
        // lbl_def_commonName
        // 
        lbl_def_commonName.AutoSize = true;
        lbl_def_commonName.Location = new Point(24, 324);
        lbl_def_commonName.Margin = new Padding(5, 0, 5, 0);
        lbl_def_commonName.Name = "lbl_def_commonName";
        lbl_def_commonName.Size = new Size(160, 30);
        lbl_def_commonName.TabIndex = 5;
        lbl_def_commonName.Text = "Common Name";
        // 
        // lbl_def_organisationUnit
        // 
        lbl_def_organisationUnit.AutoSize = true;
        lbl_def_organisationUnit.Location = new Point(51, 260);
        lbl_def_organisationUnit.Margin = new Padding(5, 0, 5, 0);
        lbl_def_organisationUnit.Name = "lbl_def_organisationUnit";
        lbl_def_organisationUnit.Size = new Size(132, 30);
        lbl_def_organisationUnit.TabIndex = 4;
        lbl_def_organisationUnit.Text = "Organisation";
        // 
        // lbl_def_organisation
        // 
        lbl_def_organisation.AutoSize = true;
        lbl_def_organisation.Location = new Point(79, 218);
        lbl_def_organisation.Margin = new Padding(5, 0, 5, 0);
        lbl_def_organisation.Name = "lbl_def_organisation";
        lbl_def_organisation.Size = new Size(108, 30);
        lbl_def_organisation.TabIndex = 3;
        lbl_def_organisation.Text = "Orga. Unit";
        // 
        // lbl_def_location
        // 
        lbl_def_location.AutoSize = true;
        lbl_def_location.Location = new Point(93, 168);
        lbl_def_location.Margin = new Padding(5, 0, 5, 0);
        lbl_def_location.Name = "lbl_def_location";
        lbl_def_location.Size = new Size(92, 30);
        lbl_def_location.TabIndex = 2;
        lbl_def_location.Text = "Location";
        // 
        // lbl_def_state
        // 
        lbl_def_state.AutoSize = true;
        lbl_def_state.Location = new Point(127, 112);
        lbl_def_state.Margin = new Padding(5, 0, 5, 0);
        lbl_def_state.Name = "lbl_def_state";
        lbl_def_state.Size = new Size(59, 30);
        lbl_def_state.TabIndex = 1;
        lbl_def_state.Text = "State";
        // 
        // lbl_def_country
        // 
        lbl_def_country.AutoSize = true;
        lbl_def_country.Location = new Point(98, 66);
        lbl_def_country.Margin = new Padding(5, 0, 5, 0);
        lbl_def_country.Name = "lbl_def_country";
        lbl_def_country.Size = new Size(86, 30);
        lbl_def_country.TabIndex = 0;
        lbl_def_country.Text = "Country";
        // 
        // lbl_ca_name
        // 
        lbl_ca_name.AutoSize = true;
        lbl_ca_name.Location = new Point(9, 344);
        lbl_ca_name.Margin = new Padding(5, 0, 5, 0);
        lbl_ca_name.Name = "lbl_ca_name";
        lbl_ca_name.Size = new Size(137, 30);
        lbl_ca_name.TabIndex = 10;
        lbl_ca_name.Text = "Server Name:";
        // 
        // lb_ca_certs
        // 
        lb_ca_certs.FormattingEnabled = true;
        lb_ca_certs.ItemHeight = 30;
        lb_ca_certs.Location = new Point(110, 116);
        lb_ca_certs.Margin = new Padding(3, 4, 3, 4);
        lb_ca_certs.Name = "lb_ca_certs";
        lb_ca_certs.Size = new Size(210, 154);
        lb_ca_certs.TabIndex = 14;
        // 
        // cb_ca_keySize
        // 
        cb_ca_keySize.FormattingEnabled = true;
        cb_ca_keySize.Items.AddRange(new object[] { "2048", "4096", "8192" });
        cb_ca_keySize.Location = new Point(151, 396);
        cb_ca_keySize.Margin = new Padding(5, 6, 5, 6);
        cb_ca_keySize.Name = "cb_ca_keySize";
        cb_ca_keySize.Size = new Size(169, 38);
        cb_ca_keySize.TabIndex = 24;
        cb_ca_keySize.Text = "4096";
        // 
        // lbl_ca_keySize
        // 
        lbl_ca_keySize.AutoSize = true;
        lbl_ca_keySize.Location = new Point(63, 402);
        lbl_ca_keySize.Margin = new Padding(5, 0, 5, 0);
        lbl_ca_keySize.Name = "lbl_ca_keySize";
        lbl_ca_keySize.Size = new Size(81, 30);
        lbl_ca_keySize.TabIndex = 0;
        lbl_ca_keySize.Text = "Keysize";
        lbl_ca_keySize.TextAlign = ContentAlignment.TopRight;
        // 
        // tb_ca_dura
        // 
        tb_ca_dura.Location = new Point(151, 456);
        tb_ca_dura.Margin = new Padding(5, 6, 5, 6);
        tb_ca_dura.Name = "tb_ca_dura";
        tb_ca_dura.Size = new Size(169, 35);
        tb_ca_dura.TabIndex = 4;
        tb_ca_dura.Text = "120";
        // 
        // lbl_ca_duration
        // 
        lbl_ca_duration.AutoSize = true;
        lbl_ca_duration.Location = new Point(50, 464);
        lbl_ca_duration.Margin = new Padding(5, 0, 5, 0);
        lbl_ca_duration.Name = "lbl_ca_duration";
        lbl_ca_duration.Size = new Size(94, 30);
        lbl_ca_duration.TabIndex = 0;
        lbl_ca_duration.Text = "Duration";
        // 
        // cb_new_ca
        // 
        cb_new_ca.AutoSize = true;
        cb_new_ca.Location = new Point(151, 290);
        cb_new_ca.Margin = new Padding(5, 6, 5, 6);
        cb_new_ca.Name = "cb_new_ca";
        cb_new_ca.Size = new Size(144, 34);
        cb_new_ca.TabIndex = 17;
        cb_new_ca.Text = "New Server";
        cb_new_ca.UseVisualStyleBackColor = true;
        cb_new_ca.CheckedChanged += cb_new_ca_CheckedChanged;
        // 
        // rb_ca
        // 
        rb_ca.AutoSize = true;
        rb_ca.Checked = true;
        rb_ca.Location = new Point(5, 6);
        rb_ca.Margin = new Padding(5, 6, 5, 6);
        rb_ca.Name = "rb_ca";
        rb_ca.Size = new Size(65, 34);
        rb_ca.TabIndex = 18;
        rb_ca.TabStop = true;
        rb_ca.Text = "CA";
        rb_ca.UseVisualStyleBackColor = true;
        rb_ca.CheckedChanged += radioButtons_CheckedChanged;
        // 
        // rb_intermediate
        // 
        rb_intermediate.AutoSize = true;
        rb_intermediate.Location = new Point(5, 56);
        rb_intermediate.Margin = new Padding(5, 6, 5, 6);
        rb_intermediate.Name = "rb_intermediate";
        rb_intermediate.Size = new Size(156, 34);
        rb_intermediate.TabIndex = 19;
        rb_intermediate.Text = "Intermediate";
        rb_intermediate.UseVisualStyleBackColor = true;
        rb_intermediate.CheckedChanged += radioButtons_CheckedChanged;
        // 
        // rb_server
        // 
        rb_server.AutoSize = true;
        rb_server.Location = new Point(5, 106);
        rb_server.Margin = new Padding(5, 6, 5, 6);
        rb_server.Name = "rb_server";
        rb_server.Size = new Size(95, 34);
        rb_server.TabIndex = 20;
        rb_server.Text = "Server";
        rb_server.UseVisualStyleBackColor = true;
        rb_server.CheckedChanged += radioButtons_CheckedChanged;
        // 
        // panel1
        // 
        panel1.Controls.Add(rb_user);
        panel1.Controls.Add(rb_ca);
        panel1.Controls.Add(rb_server);
        panel1.Controls.Add(rb_intermediate);
        panel1.Location = new Point(545, 938);
        panel1.Margin = new Padding(5, 6, 5, 6);
        panel1.Name = "panel1";
        panel1.Size = new Size(175, 202);
        panel1.TabIndex = 21;
        // 
        // rb_user
        // 
        rb_user.AutoSize = true;
        rb_user.Location = new Point(5, 152);
        rb_user.Margin = new Padding(5, 6, 5, 6);
        rb_user.Name = "rb_user";
        rb_user.Size = new Size(79, 34);
        rb_user.TabIndex = 21;
        rb_user.Text = "User";
        rb_user.UseVisualStyleBackColor = true;
        rb_user.CheckedChanged += radioButtons_CheckedChanged;
        // 
        // Bt_gen_ca_priv
        // 
        Bt_gen_ca_priv.Location = new Point(51, 520);
        Bt_gen_ca_priv.Margin = new Padding(3, 4, 3, 4);
        Bt_gen_ca_priv.Name = "Bt_gen_ca_priv";
        Bt_gen_ca_priv.Size = new Size(130, 94);
        Bt_gen_ca_priv.TabIndex = 23;
        Bt_gen_ca_priv.Text = "1. Generate Private Key";
        Bt_gen_ca_priv.UseVisualStyleBackColor = true;
        Bt_gen_ca_priv.Click += Bt_gen_ca_priv_onClick;
        // 
        // Bt_gen_ca_selfSigned_key
        // 
        Bt_gen_ca_selfSigned_key.Location = new Point(192, 684);
        Bt_gen_ca_selfSigned_key.Margin = new Padding(5, 6, 5, 6);
        Bt_gen_ca_selfSigned_key.Name = "Bt_gen_ca_selfSigned_key";
        Bt_gen_ca_selfSigned_key.Size = new Size(130, 94);
        Bt_gen_ca_selfSigned_key.TabIndex = 24;
        Bt_gen_ca_selfSigned_key.Text = "5. Generate CSR";
        Bt_gen_ca_selfSigned_key.UseVisualStyleBackColor = true;
        Bt_gen_ca_selfSigned_key.Click += Bt_gen_ca_selfSigned_key_Click;
        // 
        // cb_isCa
        // 
        cb_isCa.AutoSize = true;
        cb_isCa.Enabled = false;
        cb_isCa.Location = new Point(10, 18);
        cb_isCa.Margin = new Padding(3, 4, 3, 4);
        cb_isCa.Name = "cb_isCa";
        cb_isCa.Size = new Size(95, 34);
        cb_isCa.TabIndex = 26;
        cb_isCa.Text = "is CA?";
        cb_isCa.UseVisualStyleBackColor = true;
        // 
        // cb_notPathlen
        // 
        cb_notPathlen.AutoSize = true;
        cb_notPathlen.Location = new Point(10, 64);
        cb_notPathlen.Margin = new Padding(3, 4, 3, 4);
        cb_notPathlen.Name = "cb_notPathlen";
        cb_notPathlen.Size = new Size(146, 34);
        cb_notPathlen.TabIndex = 27;
        cb_notPathlen.Text = "not pathlen";
        cb_notPathlen.UseVisualStyleBackColor = true;
        // 
        // cb_critical
        // 
        cb_critical.AutoSize = true;
        cb_critical.Location = new Point(10, 164);
        cb_critical.Margin = new Padding(3, 4, 3, 4);
        cb_critical.Name = "cb_critical";
        cb_critical.Size = new Size(99, 34);
        cb_critical.TabIndex = 28;
        cb_critical.Text = "critical";
        cb_critical.UseVisualStyleBackColor = true;
        // 
        // cb_depth
        // 
        cb_depth.FormattingEnabled = true;
        cb_depth.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" });
        cb_depth.Location = new Point(10, 110);
        cb_depth.Margin = new Padding(3, 4, 3, 4);
        cb_depth.Name = "cb_depth";
        cb_depth.RightToLeft = RightToLeft.No;
        cb_depth.Size = new Size(52, 38);
        cb_depth.TabIndex = 29;
        cb_depth.Text = "0";
        // 
        // lbl_unlimDepth
        // 
        lbl_unlimDepth.AutoSize = true;
        lbl_unlimDepth.Location = new Point(77, 116);
        lbl_unlimDepth.Name = "lbl_unlimDepth";
        lbl_unlimDepth.Size = new Size(67, 30);
        lbl_unlimDepth.TabIndex = 30;
        lbl_unlimDepth.Text = "depth";
        // 
        // panel2
        // 
        panel2.Controls.Add(cb_notPathlen);
        panel2.Controls.Add(cb_isCa);
        panel2.Controls.Add(Bt_wrt_param);
        panel2.Controls.Add(cb_depth);
        panel2.Controls.Add(lbl_unlimDepth);
        panel2.Controls.Add(cb_critical);
        panel2.Location = new Point(1447, 1084);
        panel2.Margin = new Padding(5, 6, 5, 6);
        panel2.Name = "panel2";
        panel2.Size = new Size(175, 280);
        panel2.TabIndex = 31;
        // 
        // Bt_wrt_param
        // 
        Bt_wrt_param.Location = new Point(14, 222);
        Bt_wrt_param.Margin = new Padding(5, 6, 5, 6);
        Bt_wrt_param.Name = "Bt_wrt_param";
        Bt_wrt_param.Size = new Size(129, 46);
        Bt_wrt_param.TabIndex = 31;
        Bt_wrt_param.Text = "4. Write Param";
        Bt_wrt_param.UseVisualStyleBackColor = true;
        Bt_wrt_param.Click += Bt_wrt_param_Click;
        // 
        // lb_int_certs
        // 
        lb_int_certs.FormattingEnabled = true;
        lb_int_certs.ItemHeight = 30;
        lb_int_certs.Location = new Point(545, 116);
        lb_int_certs.Margin = new Padding(5, 6, 5, 6);
        lb_int_certs.Name = "lb_int_certs";
        lb_int_certs.Size = new Size(203, 154);
        lb_int_certs.TabIndex = 32;
        // 
        // Bt_gen_int_priv
        // 
        Bt_gen_int_priv.Location = new Point(478, 520);
        Bt_gen_int_priv.Margin = new Padding(5, 6, 5, 6);
        Bt_gen_int_priv.Name = "Bt_gen_int_priv";
        Bt_gen_int_priv.Size = new Size(129, 94);
        Bt_gen_int_priv.TabIndex = 33;
        Bt_gen_int_priv.Text = "1. Generate Private Key";
        Bt_gen_int_priv.UseVisualStyleBackColor = true;
        Bt_gen_int_priv.Click += Bt_gen_int_priv_Click;
        // 
        // lbl_int_keySize
        // 
        lbl_int_keySize.AutoSize = true;
        lbl_int_keySize.Location = new Point(492, 400);
        lbl_int_keySize.Margin = new Padding(5, 0, 5, 0);
        lbl_int_keySize.Name = "lbl_int_keySize";
        lbl_int_keySize.Size = new Size(81, 30);
        lbl_int_keySize.TabIndex = 34;
        lbl_int_keySize.Text = "Keysize";
        // 
        // cb_int_keySize
        // 
        cb_int_keySize.FormattingEnabled = true;
        cb_int_keySize.Items.AddRange(new object[] { "2048", "4096", "8192" });
        cb_int_keySize.Location = new Point(579, 396);
        cb_int_keySize.Margin = new Padding(5, 6, 5, 6);
        cb_int_keySize.Name = "cb_int_keySize";
        cb_int_keySize.Size = new Size(169, 38);
        cb_int_keySize.TabIndex = 37;
        cb_int_keySize.Text = "4096";
        // 
        // tb_int_dura
        // 
        tb_int_dura.Location = new Point(579, 454);
        tb_int_dura.Margin = new Padding(5, 6, 5, 6);
        tb_int_dura.Name = "tb_int_dura";
        tb_int_dura.Size = new Size(169, 35);
        tb_int_dura.TabIndex = 36;
        tb_int_dura.Text = "60";
        // 
        // lbl_int_duration
        // 
        lbl_int_duration.AutoSize = true;
        lbl_int_duration.Location = new Point(478, 464);
        lbl_int_duration.Margin = new Padding(5, 0, 5, 0);
        lbl_int_duration.Name = "lbl_int_duration";
        lbl_int_duration.Size = new Size(94, 30);
        lbl_int_duration.TabIndex = 35;
        lbl_int_duration.Text = "Duration";
        // 
        // tb_int_name
        // 
        tb_int_name.Location = new Point(579, 340);
        tb_int_name.Margin = new Padding(5, 6, 5, 6);
        tb_int_name.Name = "tb_int_name";
        tb_int_name.Size = new Size(169, 35);
        tb_int_name.TabIndex = 39;
        // 
        // lbl_int_name
        // 
        lbl_int_name.AutoSize = true;
        lbl_int_name.Location = new Point(377, 344);
        lbl_int_name.Margin = new Padding(5, 0, 5, 0);
        lbl_int_name.Name = "lbl_int_name";
        lbl_int_name.Size = new Size(198, 30);
        lbl_int_name.TabIndex = 38;
        lbl_int_name.Text = "Intermediate Name:";
        // 
        // cb_new_int
        // 
        cb_new_int.AutoSize = true;
        cb_new_int.Location = new Point(545, 290);
        cb_new_int.Margin = new Padding(5, 6, 5, 6);
        cb_new_int.Name = "cb_new_int";
        cb_new_int.Size = new Size(205, 34);
        cb_new_int.TabIndex = 40;
        cb_new_int.Text = "New Intermediate";
        cb_new_int.UseVisualStyleBackColor = true;
        cb_new_int.CheckedChanged += cb_new_inter_CheckedChanged;
        // 
        // Bt_gen_int_pub
        // 
        Bt_gen_int_pub.Location = new Point(622, 522);
        Bt_gen_int_pub.Margin = new Padding(5, 6, 5, 6);
        Bt_gen_int_pub.Name = "Bt_gen_int_pub";
        Bt_gen_int_pub.Size = new Size(129, 94);
        Bt_gen_int_pub.TabIndex = 41;
        Bt_gen_int_pub.Text = "2. Generate Public Key";
        Bt_gen_int_pub.UseVisualStyleBackColor = true;
        Bt_gen_int_pub.Click += Bt_gen_int_pub_Click;
        // 
        // Bt_gen_ca_pub
        // 
        Bt_gen_ca_pub.Location = new Point(192, 520);
        Bt_gen_ca_pub.Margin = new Padding(3, 4, 3, 4);
        Bt_gen_ca_pub.Name = "Bt_gen_ca_pub";
        Bt_gen_ca_pub.Size = new Size(130, 94);
        Bt_gen_ca_pub.TabIndex = 42;
        Bt_gen_ca_pub.Text = "2. Generate Public Key";
        Bt_gen_ca_pub.UseVisualStyleBackColor = true;
        Bt_gen_ca_pub.Click += Bt_gen_ca_pub_onClick;
        // 
        // Bt_gen_int_selfSigned_key
        // 
        Bt_gen_int_selfSigned_key.Location = new Point(545, 684);
        Bt_gen_int_selfSigned_key.Margin = new Padding(5, 6, 5, 6);
        Bt_gen_int_selfSigned_key.Name = "Bt_gen_int_selfSigned_key";
        Bt_gen_int_selfSigned_key.Size = new Size(130, 94);
        Bt_gen_int_selfSigned_key.TabIndex = 43;
        Bt_gen_int_selfSigned_key.Text = "5. Generate CSR";
        Bt_gen_int_selfSigned_key.UseVisualStyleBackColor = true;
        Bt_gen_int_selfSigned_key.Click += Bt_gen_int_selfSigned_key_Click;
        // 
        // Bt_read_ca_subj
        // 
        Bt_read_ca_subj.AccessibleName = "ca";
        Bt_read_ca_subj.AccessibleRole = AccessibleRole.None;
        Bt_read_ca_subj.Location = new Point(10, 626);
        Bt_read_ca_subj.Margin = new Padding(5, 6, 5, 6);
        Bt_read_ca_subj.Name = "Bt_read_ca_subj";
        Bt_read_ca_subj.Size = new Size(165, 42);
        Bt_read_ca_subj.TabIndex = 45;
        Bt_read_ca_subj.Text = "Read Subjects";
        Bt_read_ca_subj.UseVisualStyleBackColor = true;
        Bt_read_ca_subj.Click += Bt_read_Dest_names_Click;
        // 
        // Bt_read_int_subj
        // 
        Bt_read_int_subj.AccessibleName = "int";
        Bt_read_int_subj.AccessibleRole = AccessibleRole.None;
        Bt_read_int_subj.Location = new Point(454, 626);
        Bt_read_int_subj.Margin = new Padding(5, 6, 5, 6);
        Bt_read_int_subj.Name = "Bt_read_int_subj";
        Bt_read_int_subj.Size = new Size(153, 42);
        Bt_read_int_subj.TabIndex = 46;
        Bt_read_int_subj.Text = "Read Subjects";
        Bt_read_int_subj.UseVisualStyleBackColor = true;
        Bt_read_int_subj.Click += Bt_read_Dest_names_Click;
        // 
        // Bt_read_server_subj
        // 
        Bt_read_server_subj.AccessibleName = "server";
        Bt_read_server_subj.AccessibleRole = AccessibleRole.None;
        Bt_read_server_subj.Location = new Point(861, 630);
        Bt_read_server_subj.Margin = new Padding(5, 6, 5, 6);
        Bt_read_server_subj.Name = "Bt_read_server_subj";
        Bt_read_server_subj.Size = new Size(154, 40);
        Bt_read_server_subj.TabIndex = 58;
        Bt_read_server_subj.Text = "Read Subjects";
        Bt_read_server_subj.UseVisualStyleBackColor = true;
        Bt_read_server_subj.Click += Bt_read_Dest_names_Click;
        // 
        // Bt_gen_server_selfSigned_key
        // 
        Bt_gen_server_selfSigned_key.Location = new Point(963, 684);
        Bt_gen_server_selfSigned_key.Margin = new Padding(5, 6, 5, 6);
        Bt_gen_server_selfSigned_key.Name = "Bt_gen_server_selfSigned_key";
        Bt_gen_server_selfSigned_key.Size = new Size(130, 94);
        Bt_gen_server_selfSigned_key.TabIndex = 57;
        Bt_gen_server_selfSigned_key.Text = "5. Generate CSR";
        Bt_gen_server_selfSigned_key.UseVisualStyleBackColor = true;
        Bt_gen_server_selfSigned_key.Click += Bt_gen_server_selfSigned_key_Click;
        // 
        // Bt_gen_server_pub
        // 
        Bt_gen_server_pub.Location = new Point(1018, 524);
        Bt_gen_server_pub.Margin = new Padding(5, 6, 5, 6);
        Bt_gen_server_pub.Name = "Bt_gen_server_pub";
        Bt_gen_server_pub.Size = new Size(129, 94);
        Bt_gen_server_pub.TabIndex = 56;
        Bt_gen_server_pub.Text = "2. Generate Public Key";
        Bt_gen_server_pub.UseVisualStyleBackColor = true;
        Bt_gen_server_pub.Click += Bt_gen_server_pub_Click;
        // 
        // cb_new_server
        // 
        cb_new_server.AutoSize = true;
        cb_new_server.Location = new Point(939, 290);
        cb_new_server.Margin = new Padding(5, 6, 5, 6);
        cb_new_server.Name = "cb_new_server";
        cb_new_server.Size = new Size(144, 34);
        cb_new_server.TabIndex = 55;
        cb_new_server.Text = "New Server";
        cb_new_server.TextAlign = ContentAlignment.MiddleRight;
        cb_new_server.UseVisualStyleBackColor = true;
        cb_new_server.CheckedChanged += cb_new_server_CheckedChanged;
        // 
        // tb_server_name
        // 
        tb_server_name.Location = new Point(974, 340);
        tb_server_name.Margin = new Padding(5, 6, 5, 6);
        tb_server_name.Name = "tb_server_name";
        tb_server_name.Size = new Size(169, 35);
        tb_server_name.TabIndex = 54;
        // 
        // lbl_server_name
        // 
        lbl_server_name.AutoSize = true;
        lbl_server_name.Location = new Point(831, 346);
        lbl_server_name.Margin = new Padding(5, 0, 5, 0);
        lbl_server_name.Name = "lbl_server_name";
        lbl_server_name.Size = new Size(137, 30);
        lbl_server_name.TabIndex = 53;
        lbl_server_name.Text = "Server Name:";
        // 
        // lbl_server_keySize
        // 
        lbl_server_keySize.AutoSize = true;
        lbl_server_keySize.Location = new Point(886, 402);
        lbl_server_keySize.Margin = new Padding(5, 0, 5, 0);
        lbl_server_keySize.Name = "lbl_server_keySize";
        lbl_server_keySize.Size = new Size(81, 30);
        lbl_server_keySize.TabIndex = 49;
        lbl_server_keySize.Text = "Keysize";
        // 
        // cb_server_keySize
        // 
        cb_server_keySize.FormattingEnabled = true;
        cb_server_keySize.Items.AddRange(new object[] { "2048", "4096", "8192" });
        cb_server_keySize.Location = new Point(974, 396);
        cb_server_keySize.Margin = new Padding(5, 6, 5, 6);
        cb_server_keySize.Name = "cb_server_keySize";
        cb_server_keySize.Size = new Size(169, 38);
        cb_server_keySize.TabIndex = 52;
        cb_server_keySize.Text = "4096";
        // 
        // tb_server_dura
        // 
        tb_server_dura.Location = new Point(974, 454);
        tb_server_dura.Margin = new Padding(5, 6, 5, 6);
        tb_server_dura.Name = "tb_server_dura";
        tb_server_dura.Size = new Size(169, 35);
        tb_server_dura.TabIndex = 51;
        tb_server_dura.Text = "30";
        // 
        // lbl_server_duration
        // 
        lbl_server_duration.AutoSize = true;
        lbl_server_duration.Location = new Point(873, 464);
        lbl_server_duration.Margin = new Padding(5, 0, 5, 0);
        lbl_server_duration.Name = "lbl_server_duration";
        lbl_server_duration.Size = new Size(94, 30);
        lbl_server_duration.TabIndex = 50;
        lbl_server_duration.Text = "Duration";
        // 
        // Bt_gen_server_priv
        // 
        Bt_gen_server_priv.Location = new Point(886, 522);
        Bt_gen_server_priv.Margin = new Padding(5, 6, 5, 6);
        Bt_gen_server_priv.Name = "Bt_gen_server_priv";
        Bt_gen_server_priv.Size = new Size(129, 94);
        Bt_gen_server_priv.TabIndex = 48;
        Bt_gen_server_priv.Text = "1. Generate Private Key";
        Bt_gen_server_priv.UseVisualStyleBackColor = true;
        Bt_gen_server_priv.Click += Bt_gen_server_priv_Click;
        // 
        // lb_server_certs
        // 
        lb_server_certs.FormattingEnabled = true;
        lb_server_certs.ItemHeight = 30;
        lb_server_certs.Location = new Point(939, 116);
        lb_server_certs.Margin = new Padding(5, 6, 5, 6);
        lb_server_certs.Name = "lb_server_certs";
        lb_server_certs.Size = new Size(203, 154);
        lb_server_certs.TabIndex = 47;
        // 
        // Bt_read_user_subj
        // 
        Bt_read_user_subj.AccessibleName = "user";
        Bt_read_user_subj.AccessibleRole = AccessibleRole.None;
        Bt_read_user_subj.Location = new Point(1239, 630);
        Bt_read_user_subj.Margin = new Padding(5, 6, 5, 6);
        Bt_read_user_subj.Name = "Bt_read_user_subj";
        Bt_read_user_subj.Size = new Size(170, 42);
        Bt_read_user_subj.TabIndex = 70;
        Bt_read_user_subj.Text = "Read Subjects";
        Bt_read_user_subj.UseVisualStyleBackColor = true;
        Bt_read_user_subj.Click += Bt_read_user_subj_Click;
        // 
        // Bt_gen_user_selfSigned_key
        // 
        Bt_gen_user_selfSigned_key.Location = new Point(1339, 684);
        Bt_gen_user_selfSigned_key.Margin = new Padding(5, 6, 5, 6);
        Bt_gen_user_selfSigned_key.Name = "Bt_gen_user_selfSigned_key";
        Bt_gen_user_selfSigned_key.Size = new Size(130, 94);
        Bt_gen_user_selfSigned_key.TabIndex = 69;
        Bt_gen_user_selfSigned_key.Text = "5. Generate CSR";
        Bt_gen_user_selfSigned_key.UseVisualStyleBackColor = true;
        Bt_gen_user_selfSigned_key.Click += Bt_gen_user_selfSigned_key_Click;
        // 
        // Bt_gen_user_pub
        // 
        Bt_gen_user_pub.Location = new Point(1395, 520);
        Bt_gen_user_pub.Margin = new Padding(5, 6, 5, 6);
        Bt_gen_user_pub.Name = "Bt_gen_user_pub";
        Bt_gen_user_pub.Size = new Size(129, 94);
        Bt_gen_user_pub.TabIndex = 68;
        Bt_gen_user_pub.Text = "2. Generate Public Key";
        Bt_gen_user_pub.UseVisualStyleBackColor = true;
        Bt_gen_user_pub.Click += Bt_gen_user_pub_Click;
        // 
        // cb_new_user
        // 
        cb_new_user.AutoSize = true;
        cb_new_user.Location = new Point(1306, 290);
        cb_new_user.Margin = new Padding(5, 6, 5, 6);
        cb_new_user.Name = "cb_new_user";
        cb_new_user.Size = new Size(128, 34);
        cb_new_user.TabIndex = 67;
        cb_new_user.Text = "New User";
        cb_new_user.TextAlign = ContentAlignment.MiddleRight;
        cb_new_user.UseVisualStyleBackColor = true;
        cb_new_user.CheckedChanged += cb_new_user_CheckedChanged;
        // 
        // tb_user_name
        // 
        tb_user_name.Location = new Point(1341, 340);
        tb_user_name.Margin = new Padding(5, 6, 5, 6);
        tb_user_name.Name = "tb_user_name";
        tb_user_name.Size = new Size(169, 35);
        tb_user_name.TabIndex = 66;
        // 
        // lbl_user_name
        // 
        lbl_user_name.AutoSize = true;
        lbl_user_name.Location = new Point(1214, 346);
        lbl_user_name.Margin = new Padding(5, 0, 5, 0);
        lbl_user_name.Name = "lbl_user_name";
        lbl_user_name.Size = new Size(121, 30);
        lbl_user_name.TabIndex = 65;
        lbl_user_name.Text = "User Name:";
        lbl_user_name.TextAlign = ContentAlignment.TopRight;
        // 
        // lbl_user_keySize
        // 
        lbl_user_keySize.AutoSize = true;
        lbl_user_keySize.Location = new Point(1253, 402);
        lbl_user_keySize.Margin = new Padding(5, 0, 5, 0);
        lbl_user_keySize.Name = "lbl_user_keySize";
        lbl_user_keySize.Size = new Size(81, 30);
        lbl_user_keySize.TabIndex = 61;
        lbl_user_keySize.Text = "Keysize";
        // 
        // cb_user_keySize
        // 
        cb_user_keySize.FormattingEnabled = true;
        cb_user_keySize.Items.AddRange(new object[] { "2048", "4096", "8192" });
        cb_user_keySize.Location = new Point(1341, 396);
        cb_user_keySize.Margin = new Padding(5, 6, 5, 6);
        cb_user_keySize.Name = "cb_user_keySize";
        cb_user_keySize.Size = new Size(169, 38);
        cb_user_keySize.TabIndex = 64;
        cb_user_keySize.Text = "4096";
        // 
        // tb_user_dura
        // 
        tb_user_dura.Location = new Point(1341, 454);
        tb_user_dura.Margin = new Padding(5, 6, 5, 6);
        tb_user_dura.Name = "tb_user_dura";
        tb_user_dura.Size = new Size(169, 35);
        tb_user_dura.TabIndex = 63;
        tb_user_dura.Text = "30";
        // 
        // lbl_user_duration
        // 
        lbl_user_duration.AutoSize = true;
        lbl_user_duration.Location = new Point(1239, 464);
        lbl_user_duration.Margin = new Padding(5, 0, 5, 0);
        lbl_user_duration.Name = "lbl_user_duration";
        lbl_user_duration.Size = new Size(94, 30);
        lbl_user_duration.TabIndex = 62;
        lbl_user_duration.Text = "Duration";
        // 
        // Bt_gen_user_priv
        // 
        Bt_gen_user_priv.Location = new Point(1257, 522);
        Bt_gen_user_priv.Margin = new Padding(5, 6, 5, 6);
        Bt_gen_user_priv.Name = "Bt_gen_user_priv";
        Bt_gen_user_priv.Size = new Size(129, 94);
        Bt_gen_user_priv.TabIndex = 60;
        Bt_gen_user_priv.Text = "1. Generate Private Key";
        Bt_gen_user_priv.UseVisualStyleBackColor = true;
        Bt_gen_user_priv.Click += Bt_gen_user_priv_Click;
        // 
        // lb_user_certs
        // 
        lb_user_certs.FormattingEnabled = true;
        lb_user_certs.ItemHeight = 30;
        lb_user_certs.Location = new Point(1306, 116);
        lb_user_certs.Margin = new Padding(5, 6, 5, 6);
        lb_user_certs.Name = "lb_user_certs";
        lb_user_certs.Size = new Size(203, 154);
        lb_user_certs.TabIndex = 59;
        // 
        // lb_ca_sn
        // 
        lb_ca_sn.AutoSize = true;
        lb_ca_sn.Location = new Point(38, 806);
        lb_ca_sn.Margin = new Padding(5, 0, 5, 0);
        lb_ca_sn.Name = "lb_ca_sn";
        lb_ca_sn.Size = new Size(140, 30);
        lb_ca_sn.TabIndex = 71;
        lb_ca_sn.Text = "Serialnumber:";
        // 
        // lb_int_sn
        // 
        lb_int_sn.AutoSize = true;
        lb_int_sn.Location = new Point(470, 802);
        lb_int_sn.Margin = new Padding(5, 0, 5, 0);
        lb_int_sn.Name = "lb_int_sn";
        lb_int_sn.Size = new Size(140, 30);
        lb_int_sn.TabIndex = 72;
        lb_int_sn.Text = "Serialnumber:";
        // 
        // lb_serv_sn
        // 
        lb_serv_sn.AutoSize = true;
        lb_serv_sn.Location = new Point(871, 822);
        lb_serv_sn.Margin = new Padding(5, 0, 5, 0);
        lb_serv_sn.Name = "lb_serv_sn";
        lb_serv_sn.Size = new Size(140, 30);
        lb_serv_sn.TabIndex = 73;
        lb_serv_sn.Text = "Serialnumber:";
        // 
        // lb_user_sn
        // 
        lb_user_sn.AutoSize = true;
        lb_user_sn.Location = new Point(1248, 822);
        lb_user_sn.Margin = new Padding(5, 0, 5, 0);
        lb_user_sn.Name = "lb_user_sn";
        lb_user_sn.Size = new Size(140, 30);
        lb_user_sn.TabIndex = 74;
        lb_user_sn.Text = "Serialnumber:";
        // 
        // tb_ca_sn
        // 
        tb_ca_sn.ImeMode = ImeMode.NoControl;
        tb_ca_sn.Location = new Point(192, 790);
        tb_ca_sn.Margin = new Padding(5, 6, 5, 6);
        tb_ca_sn.Name = "tb_ca_sn";
        tb_ca_sn.ReadOnly = true;
        tb_ca_sn.Size = new Size(126, 35);
        tb_ca_sn.TabIndex = 75;
        // 
        // textBox1
        // 
        textBox1.Enabled = false;
        textBox1.Location = new Point(617, 790);
        textBox1.Margin = new Padding(5, 6, 5, 6);
        textBox1.Name = "textBox1";
        textBox1.ReadOnly = true;
        textBox1.Size = new Size(126, 35);
        textBox1.TabIndex = 76;
        // 
        // textBox2
        // 
        textBox2.Enabled = false;
        textBox2.Location = new Point(1018, 806);
        textBox2.Margin = new Padding(5, 6, 5, 6);
        textBox2.Name = "textBox2";
        textBox2.ReadOnly = true;
        textBox2.Size = new Size(124, 35);
        textBox2.TabIndex = 77;
        // 
        // textBox3
        // 
        textBox3.Enabled = false;
        textBox3.Location = new Point(1395, 816);
        textBox3.Margin = new Padding(5, 6, 5, 6);
        textBox3.Name = "textBox3";
        textBox3.ReadOnly = true;
        textBox3.Size = new Size(126, 35);
        textBox3.TabIndex = 78;
        // 
        // Bt_reCreate_ca_selfSigned_key
        // 
        Bt_reCreate_ca_selfSigned_key.Location = new Point(53, 684);
        Bt_reCreate_ca_selfSigned_key.Margin = new Padding(5, 6, 5, 6);
        Bt_reCreate_ca_selfSigned_key.Name = "Bt_reCreate_ca_selfSigned_key";
        Bt_reCreate_ca_selfSigned_key.Size = new Size(129, 94);
        Bt_reCreate_ca_selfSigned_key.TabIndex = 79;
        Bt_reCreate_ca_selfSigned_key.Text = "Re-Create";
        Bt_reCreate_ca_selfSigned_key.UseVisualStyleBackColor = true;
        Bt_reCreate_ca_selfSigned_key.Click += Bt_reCreate_ca_selfSigned_key_Click;
        // 
        // button1
        // 
        button1.AccessibleName = "ca";
        button1.AccessibleRole = AccessibleRole.None;
        button1.Location = new Point(185, 626);
        button1.Margin = new Padding(5, 6, 5, 6);
        button1.Name = "button1";
        button1.Size = new Size(165, 42);
        button1.TabIndex = 80;
        button1.Text = "Read Cert Inf";
        button1.UseVisualStyleBackColor = true;
        // 
        // button2
        // 
        button2.AccessibleName = "ca";
        button2.AccessibleRole = AccessibleRole.None;
        button2.Location = new Point(617, 628);
        button2.Margin = new Padding(5, 6, 5, 6);
        button2.Name = "button2";
        button2.Size = new Size(151, 42);
        button2.TabIndex = 81;
        button2.Text = "Read Cert Inf";
        button2.UseVisualStyleBackColor = true;
        // 
        // button3
        // 
        button3.AccessibleName = "ca";
        button3.AccessibleRole = AccessibleRole.None;
        button3.Location = new Point(1032, 630);
        button3.Margin = new Padding(5, 6, 5, 6);
        button3.Name = "button3";
        button3.Size = new Size(156, 42);
        button3.TabIndex = 82;
        button3.Text = "Read Cert Inf";
        button3.UseVisualStyleBackColor = true;
        // 
        // button4
        // 
        button4.AccessibleName = "ca";
        button4.AccessibleRole = AccessibleRole.None;
        button4.Location = new Point(1419, 630);
        button4.Margin = new Padding(5, 6, 5, 6);
        button4.Name = "button4";
        button4.Size = new Size(170, 42);
        button4.TabIndex = 83;
        button4.Text = "Read Cert Inf";
        button4.UseVisualStyleBackColor = true;
        // 
        // Bt_ca_uploadCert
        // 
        Bt_ca_uploadCert.Location = new Point(110, 848);
        Bt_ca_uploadCert.Margin = new Padding(5, 6, 5, 6);
        Bt_ca_uploadCert.Name = "Bt_ca_uploadCert";
        Bt_ca_uploadCert.Size = new Size(129, 46);
        Bt_ca_uploadCert.TabIndex = 85;
        Bt_ca_uploadCert.Text = "Upload Cert";
        Bt_ca_uploadCert.UseVisualStyleBackColor = true;
        Bt_ca_uploadCert.Click += Bt_ca_uploadCert_Click;
        // 
        // Tb_cert_filename
        // 
        Tb_cert_filename.Location = new Point(134, 44);
        Tb_cert_filename.Margin = new Padding(5, 6, 5, 6);
        Tb_cert_filename.Name = "Tb_cert_filename";
        Tb_cert_filename.Size = new Size(169, 35);
        Tb_cert_filename.TabIndex = 86;
        // 
        // Lbl_ca_filename_cert
        // 
        Lbl_ca_filename_cert.AutoSize = true;
        Lbl_ca_filename_cert.Location = new Point(36, 54);
        Lbl_ca_filename_cert.Margin = new Padding(5, 0, 5, 0);
        Lbl_ca_filename_cert.Name = "Lbl_ca_filename_cert";
        Lbl_ca_filename_cert.Size = new Size(96, 30);
        Lbl_ca_filename_cert.TabIndex = 87;
        Lbl_ca_filename_cert.Text = "Filename";
        // 
        // Lbl_ca_fileExtension_Priv
        // 
        Lbl_ca_fileExtension_Priv.AutoSize = true;
        Lbl_ca_fileExtension_Priv.Location = new Point(10, 108);
        Lbl_ca_fileExtension_Priv.Margin = new Padding(5, 0, 5, 0);
        Lbl_ca_fileExtension_Priv.Name = "Lbl_ca_fileExtension_Priv";
        Lbl_ca_fileExtension_Priv.Size = new Size(118, 30);
        Lbl_ca_fileExtension_Priv.TabIndex = 88;
        Lbl_ca_fileExtension_Priv.Text = "File Ext Priv";
        // 
        // Cb_file_priv_ext
        // 
        Cb_file_priv_ext.FormattingEnabled = true;
        Cb_file_priv_ext.Items.AddRange(new object[] { "pfx", "pem", "crt", "cer", "der", "" });
        Cb_file_priv_ext.Location = new Point(132, 102);
        Cb_file_priv_ext.Margin = new Padding(5, 6, 5, 6);
        Cb_file_priv_ext.Name = "Cb_file_priv_ext";
        Cb_file_priv_ext.Size = new Size(170, 38);
        Cb_file_priv_ext.TabIndex = 89;
        // 
        // Lbl_ca_fileExtension_Pub
        // 
        Lbl_ca_fileExtension_Pub.AutoSize = true;
        Lbl_ca_fileExtension_Pub.Location = new Point(-7, 162);
        Lbl_ca_fileExtension_Pub.Margin = new Padding(5, 0, 5, 0);
        Lbl_ca_fileExtension_Pub.Name = "Lbl_ca_fileExtension_Pub";
        Lbl_ca_fileExtension_Pub.Size = new Size(140, 30);
        Lbl_ca_fileExtension_Pub.TabIndex = 90;
        Lbl_ca_fileExtension_Pub.Text = "File Ext Public";
        // 
        // Cb_file_pub_ext
        // 
        Cb_file_pub_ext.FormattingEnabled = true;
        Cb_file_pub_ext.Items.AddRange(new object[] { "cer", "der", "crt" });
        Cb_file_pub_ext.Location = new Point(132, 156);
        Cb_file_pub_ext.Margin = new Padding(5, 6, 5, 6);
        Cb_file_pub_ext.Name = "Cb_file_pub_ext";
        Cb_file_pub_ext.Size = new Size(170, 38);
        Cb_file_pub_ext.TabIndex = 91;
        // 
        // Tb_cert_remote_path
        // 
        Tb_cert_remote_path.Location = new Point(130, 214);
        Tb_cert_remote_path.Margin = new Padding(5, 6, 5, 6);
        Tb_cert_remote_path.Name = "Tb_cert_remote_path";
        Tb_cert_remote_path.Size = new Size(172, 35);
        Tb_cert_remote_path.TabIndex = 92;
        // 
        // menuStrip1
        // 
        menuStrip1.ImageScalingSize = new Size(28, 28);
        menuStrip1.Items.AddRange(new ToolStripItem[] { editToolStripMenuItem });
        menuStrip1.Location = new Point(0, 0);
        menuStrip1.Name = "menuStrip1";
        menuStrip1.Padding = new Padding(10, 4, 0, 4);
        menuStrip1.Size = new Size(1788, 42);
        menuStrip1.TabIndex = 94;
        menuStrip1.Text = "menuStrip1";
        // 
        // editToolStripMenuItem
        // 
        editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ms_edit_config });
        editToolStripMenuItem.Name = "editToolStripMenuItem";
        editToolStripMenuItem.Size = new Size(66, 34);
        editToolStripMenuItem.Text = "Edit";
        // 
        // ms_edit_config
        // 
        ms_edit_config.Name = "ms_edit_config";
        ms_edit_config.Size = new Size(192, 40);
        ms_edit_config.Text = "Config";
        ms_edit_config.Click += edit_config_load;
        // 
        // Lb_cert_remotePath
        // 
        Lb_cert_remotePath.AutoSize = true;
        Lb_cert_remotePath.Location = new Point(-3, 220);
        Lb_cert_remotePath.Margin = new Padding(5, 0, 5, 0);
        Lb_cert_remotePath.Name = "Lb_cert_remotePath";
        Lb_cert_remotePath.Size = new Size(131, 30);
        Lb_cert_remotePath.TabIndex = 95;
        Lb_cert_remotePath.Text = "Remote Path";
        // 
        // Bt_wr_cert_path
        // 
        Bt_wr_cert_path.Location = new Point(142, 304);
        Bt_wr_cert_path.Margin = new Padding(5, 6, 5, 6);
        Bt_wr_cert_path.Name = "Bt_wr_cert_path";
        Bt_wr_cert_path.Size = new Size(129, 46);
        Bt_wr_cert_path.TabIndex = 96;
        Bt_wr_cert_path.Text = "Write";
        Bt_wr_cert_path.UseVisualStyleBackColor = true;
        Bt_wr_cert_path.Click += Bt_wr_cert_path_Click;
        // 
        // treeView1
        // 
        treeView1.Location = new Point(1414, 1422);
        treeView1.Margin = new Padding(5, 6, 5, 6);
        treeView1.Name = "treeView1";
        treeView1.Size = new Size(205, 190);
        treeView1.TabIndex = 97;
        // 
        // Gb_cert_details
        // 
        Gb_cert_details.Controls.Add(Tb_cert_filename);
        Gb_cert_details.Controls.Add(Lbl_ca_filename_cert);
        Gb_cert_details.Controls.Add(Bt_wr_cert_path);
        Gb_cert_details.Controls.Add(Lbl_ca_fileExtension_Priv);
        Gb_cert_details.Controls.Add(Lb_cert_remotePath);
        Gb_cert_details.Controls.Add(Cb_file_priv_ext);
        Gb_cert_details.Controls.Add(Lbl_ca_fileExtension_Pub);
        Gb_cert_details.Controls.Add(Tb_cert_remote_path);
        Gb_cert_details.Controls.Add(Cb_file_pub_ext);
        Gb_cert_details.ImeMode = ImeMode.KatakanaHalf;
        Gb_cert_details.Location = new Point(147, 1234);
        Gb_cert_details.Margin = new Padding(5, 6, 5, 6);
        Gb_cert_details.Name = "Gb_cert_details";
        Gb_cert_details.Padding = new Padding(5, 6, 5, 6);
        Gb_cert_details.Size = new Size(343, 504);
        Gb_cert_details.TabIndex = 98;
        Gb_cert_details.TabStop = false;
        Gb_cert_details.Text = "Certificate information";
        // 
        // saveFileDialog1
        // 
        saveFileDialog1.FileOk += saveFileDialog1_FileOk_1;
        // 
        // Bt_int_uploadCert
        // 
        Bt_int_uploadCert.Location = new Point(579, 848);
        Bt_int_uploadCert.Margin = new Padding(5, 6, 5, 6);
        Bt_int_uploadCert.Name = "Bt_int_uploadCert";
        Bt_int_uploadCert.Size = new Size(129, 46);
        Bt_int_uploadCert.TabIndex = 99;
        Bt_int_uploadCert.Text = "Upload Cert";
        Bt_int_uploadCert.UseVisualStyleBackColor = true;
        Bt_int_uploadCert.Click += Bt_int_uploadCert_Click;
        // 
        // Bt_server_uploadCert
        // 
        Bt_server_uploadCert.Location = new Point(965, 864);
        Bt_server_uploadCert.Margin = new Padding(5, 6, 5, 6);
        Bt_server_uploadCert.Name = "Bt_server_uploadCert";
        Bt_server_uploadCert.Size = new Size(129, 46);
        Bt_server_uploadCert.TabIndex = 100;
        Bt_server_uploadCert.Text = "Upload Cert";
        Bt_server_uploadCert.UseVisualStyleBackColor = true;
        Bt_server_uploadCert.Click += Bt_server_uploadCert_Click;
        // 
        // button5
        // 
        button5.Location = new Point(1119, 1074);
        button5.Margin = new Padding(5, 6, 5, 6);
        button5.Name = "button5";
        button5.Size = new Size(129, 46);
        button5.TabIndex = 101;
        button5.Text = "button5";
        button5.UseVisualStyleBackColor = true;
        button5.Click += button5_Click;
        // 
        // Server
        // 
        AutoScaleDimensions = new SizeF(12F, 30F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1788, 1884);
        Controls.Add(button5);
        Controls.Add(Bt_server_uploadCert);
        Controls.Add(Bt_int_uploadCert);
        Controls.Add(Gb_cert_details);
        Controls.Add(treeView1);
        Controls.Add(menuStrip1);
        Controls.Add(Bt_ca_uploadCert);
        Controls.Add(button4);
        Controls.Add(button3);
        Controls.Add(button2);
        Controls.Add(button1);
        Controls.Add(Bt_reCreate_ca_selfSigned_key);
        Controls.Add(textBox3);
        Controls.Add(textBox2);
        Controls.Add(textBox1);
        Controls.Add(tb_ca_sn);
        Controls.Add(lb_user_sn);
        Controls.Add(lb_serv_sn);
        Controls.Add(lb_int_sn);
        Controls.Add(lb_ca_sn);
        Controls.Add(Bt_read_user_subj);
        Controls.Add(Bt_gen_user_selfSigned_key);
        Controls.Add(Bt_gen_user_pub);
        Controls.Add(cb_new_user);
        Controls.Add(tb_user_name);
        Controls.Add(lbl_user_name);
        Controls.Add(lbl_user_keySize);
        Controls.Add(cb_user_keySize);
        Controls.Add(tb_user_dura);
        Controls.Add(lbl_user_duration);
        Controls.Add(Bt_gen_user_priv);
        Controls.Add(lb_user_certs);
        Controls.Add(Bt_read_server_subj);
        Controls.Add(Bt_gen_server_selfSigned_key);
        Controls.Add(Bt_gen_server_pub);
        Controls.Add(cb_new_server);
        Controls.Add(tb_server_name);
        Controls.Add(lbl_server_name);
        Controls.Add(lbl_server_keySize);
        Controls.Add(cb_server_keySize);
        Controls.Add(tb_server_dura);
        Controls.Add(lbl_server_duration);
        Controls.Add(Bt_gen_server_priv);
        Controls.Add(lb_server_certs);
        Controls.Add(Bt_read_int_subj);
        Controls.Add(Bt_read_ca_subj);
        Controls.Add(Bt_gen_int_selfSigned_key);
        Controls.Add(Bt_gen_ca_pub);
        Controls.Add(Bt_gen_int_pub);
        Controls.Add(cb_new_int);
        Controls.Add(tb_int_name);
        Controls.Add(lbl_int_name);
        Controls.Add(lbl_int_keySize);
        Controls.Add(cb_int_keySize);
        Controls.Add(tb_int_dura);
        Controls.Add(lbl_int_duration);
        Controls.Add(Bt_gen_int_priv);
        Controls.Add(lb_int_certs);
        Controls.Add(panel2);
        Controls.Add(lbl_ca_keySize);
        Controls.Add(cb_ca_keySize);
        Controls.Add(tb_ca_dura);
        Controls.Add(lbl_ca_duration);
        Controls.Add(Bt_gen_ca_selfSigned_key);
        Controls.Add(Bt_gen_ca_priv);
        Controls.Add(panel1);
        Controls.Add(cb_new_ca);
        Controls.Add(lb_ca_certs);
        Controls.Add(tb_ca_name);
        Controls.Add(gb_default_disti_names);
        Controls.Add(lbl_ca_name);
        MainMenuStrip = menuStrip1;
        Margin = new Padding(3, 4, 3, 4);
        Name = "Server";
        Text = "server";
        Load += server_onLoad;
        gb_default_disti_names.ResumeLayout(false);
        gb_default_disti_names.PerformLayout();
        panel1.ResumeLayout(false);
        panel1.PerformLayout();
        panel2.ResumeLayout(false);
        panel2.PerformLayout();
        menuStrip1.ResumeLayout(false);
        menuStrip1.PerformLayout();
        Gb_cert_details.ResumeLayout(false);
        Gb_cert_details.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion
    private TextBox tb_ca_name;
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
    private TextBox tb_ca_dura;
    private Label lbl_ca_duration;
    private CheckBox cb_new_ca;
    private RadioButton rb_ca;
    private RadioButton rb_intermediate;
    private RadioButton rb_server;
    private Panel panel1;
    private Button Bt_gen_ca_priv;
    private ComboBox cb_ca_keySize;
    private RadioButton rb_user;
    private Button Bt_gen_ca_selfSigned_key;
    private Button bt_wrt_dest_names;
    private CheckBox cb_isCa;
    private CheckBox cb_notPathlen;
    private CheckBox cb_critical;
    private ComboBox cb_depth;
    private Label lbl_unlimDepth;
    private Panel panel2;
    private ListBox lb_int_certs;
    private Button Bt_gen_int_priv;
    private Label lbl_int_keySize;
    private ComboBox cb_int_keySize;
    private TextBox tb_int_dura;
    private Label lbl_int_duration;
    private TextBox tb_int_name;
    private Label lbl_int_name;
    private CheckBox cb_new_int;
    private Button Bt_gen_int_pub;
    private Button Bt_gen_ca_pub;
    private Button Bt_wrt_param;
    private Button Bt_gen_int_selfSigned_key;
    private Button Bt_read_ca_subj;
    private Button Bt_read_int_subj;
    private Button Bt_read_server_subj;
    private Button Bt_gen_server_selfSigned_key;
    private Button Bt_gen_server_pub;
    private CheckBox cb_new_server;
    private TextBox tb_server_name;
    private Label lbl_server_name;
    private Label lbl_server_keySize;
    private ComboBox cb_server_keySize;
    private TextBox tb_server_dura;
    private Label lbl_server_duration;
    private Button Bt_gen_server_priv;
    private ListBox lb_server_certs;
    private Button Bt_read_user_subj;
    private Button Bt_gen_user_selfSigned_key;
    private Button Bt_gen_user_pub;
    private CheckBox cb_new_user;
    private TextBox tb_user_name;
    private Label lbl_user_name;
    private Label lbl_user_keySize;
    private ComboBox cb_user_keySize;
    private TextBox tb_user_dura;
    private Label lbl_user_duration;
    private Button Bt_gen_user_priv;
    private ListBox lb_user_certs;
    private Label lb_ca_sn;
    private Label lb_int_sn;
    private Label lb_serv_sn;
    private Label lb_user_sn;
    private TextBox tb_ca_sn;
    private TextBox textBox1;
    private TextBox textBox2;
    private TextBox textBox3;
    private Button Bt_reCreate_ca_selfSigned_key;
    private Button button1;
    private Button button2;
    private Button button3;
    private Button button4;
    private Button Bt_ca_uploadCert;
    private TextBox Tb_cert_filename;
    private Label Lbl_ca_filename_cert;
    private Label Lbl_ca_fileExtension_Priv;
    private ComboBox Cb_file_priv_ext;
    private Label Lbl_ca_fileExtension_Pub;
    private ComboBox Cb_file_pub_ext;
    private TextBox Tb_cert_remote_path;
    public ListBox lb_ca_certs;
    private MenuStrip menuStrip1;
    private ToolStripMenuItem editToolStripMenuItem;
    private ToolStripMenuItem ms_edit_config;
    private Label Lb_cert_remotePath;
    private Button Bt_wr_cert_path;
    private TreeView treeView1;
    private GroupBox Gb_cert_details;
    private SaveFileDialog saveFileDialog1;
    private Button Bt_int_uploadCert;
    private Button Bt_server_uploadCert;
    private Button button5;
}
