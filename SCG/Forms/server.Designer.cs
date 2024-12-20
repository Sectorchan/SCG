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
        Bt_read_Dest_names = new Button();
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
        lbl_keySize = new Label();
        tb_ca_dura = new TextBox();
        lbl_pub_duration = new Label();
        cb_new_server = new CheckBox();
        rb_ca = new RadioButton();
        rb_intermediate = new RadioButton();
        rb_server = new RadioButton();
        panel1 = new Panel();
        rb_user = new RadioButton();
        Bt_gen_ca_priv = new Button();
        Bt_gen_ca_selfSigned_key = new Button();
        cb_isCa = new CheckBox();
        cb_notPathlen = new CheckBox();
        cb_issueCert = new CheckBox();
        cb_depth = new ComboBox();
        lbl_unlimDepth = new Label();
        panel2 = new Panel();
        Bt_wrt_param = new Button();
        lb_inter_certs = new ListBox();
        Bt_gen_int_priv = new Button();
        lbl_int_bit = new Label();
        cb_int_keySize = new ComboBox();
        tb_int_pub_dura = new TextBox();
        lbl_int_pub_duration = new Label();
        tb_int_name = new TextBox();
        lbl_int_name = new Label();
        cb_new_inter = new CheckBox();
        Bt_gen_int_pub = new Button();
        Bt_gen_ca_pub = new Button();
        Bt_gen_int_selfSigned_key = new Button();
        Bt_sign_int_cert = new Button();
        Bt_read_ca_subj = new Button();
        Bt_read_int_subj = new Button();
        Bt_read_server_subj = new Button();
        Bt_gen_server_selfSigned_key = new Button();
        Bt_gen_server_pub = new Button();
        checkBox1 = new CheckBox();
        textBox1 = new TextBox();
        label1 = new Label();
        label2 = new Label();
        comboBox1 = new ComboBox();
        textBox2 = new TextBox();
        label3 = new Label();
        Bt_gen_server_priv = new Button();
        lb_server_certs = new ListBox();
        Bt_read_user_subj = new Button();
        Bt_gen_user_selfSigned_key = new Button();
        Bt_gen_user_pub = new Button();
        checkBox2 = new CheckBox();
        textBox3 = new TextBox();
        label4 = new Label();
        label5 = new Label();
        comboBox2 = new ComboBox();
        textBox4 = new TextBox();
        label6 = new Label();
        Bt_gen_user_priv = new Button();
        lb_user_certs = new ListBox();
        gb_default_disti_names.SuspendLayout();
        panel1.SuspendLayout();
        panel2.SuspendLayout();
        SuspendLayout();
        // 
        // tb_ca_name
        // 
        tb_ca_name.Location = new Point(86, 117);
        tb_ca_name.Name = "tb_ca_name";
        tb_ca_name.Size = new Size(100, 23);
        tb_ca_name.TabIndex = 12;
        // 
        // gb_default_disti_names
        // 
        gb_default_disti_names.Controls.Add(Bt_read_Dest_names);
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
        gb_default_disti_names.Location = new Point(69, 607);
        gb_default_disti_names.Name = "gb_default_disti_names";
        gb_default_disti_names.Size = new Size(229, 239);
        gb_default_disti_names.TabIndex = 11;
        gb_default_disti_names.TabStop = false;
        gb_default_disti_names.Text = "Default Distinguished Names";
        // 
        // Bt_read_Dest_names
        // 
        Bt_read_Dest_names.Location = new Point(137, 208);
        Bt_read_Dest_names.Name = "Bt_read_Dest_names";
        Bt_read_Dest_names.Size = new Size(76, 26);
        Bt_read_Dest_names.TabIndex = 26;
        Bt_read_Dest_names.Text = "Read";
        Bt_read_Dest_names.UseVisualStyleBackColor = true;
        Bt_read_Dest_names.Click += Bt_read_Dest_names_Click;
        // 
        // tb_sub_email
        // 
        tb_sub_email.Location = new Point(113, 180);
        tb_sub_email.Name = "tb_sub_email";
        tb_sub_email.Size = new Size(100, 23);
        tb_sub_email.TabIndex = 13;
        // 
        // tb_sub_cn
        // 
        tb_sub_cn.Location = new Point(113, 154);
        tb_sub_cn.Name = "tb_sub_cn";
        tb_sub_cn.Size = new Size(100, 23);
        tb_sub_cn.TabIndex = 12;
        // 
        // tb_sub_orga
        // 
        tb_sub_orga.Location = new Point(113, 130);
        tb_sub_orga.Name = "tb_sub_orga";
        tb_sub_orga.Size = new Size(100, 23);
        tb_sub_orga.TabIndex = 11;
        // 
        // tb_sub_ou
        // 
        tb_sub_ou.Location = new Point(113, 106);
        tb_sub_ou.Name = "tb_sub_ou";
        tb_sub_ou.Size = new Size(100, 23);
        tb_sub_ou.TabIndex = 10;
        // 
        // tb_sub_loc
        // 
        tb_sub_loc.Location = new Point(113, 81);
        tb_sub_loc.Name = "tb_sub_loc";
        tb_sub_loc.Size = new Size(100, 23);
        tb_sub_loc.TabIndex = 9;
        // 
        // tb_sub_st
        // 
        tb_sub_st.Location = new Point(113, 56);
        tb_sub_st.Name = "tb_sub_st";
        tb_sub_st.Size = new Size(100, 23);
        tb_sub_st.TabIndex = 8;
        // 
        // bt_wrt_dest_names
        // 
        bt_wrt_dest_names.Location = new Point(14, 208);
        bt_wrt_dest_names.Margin = new Padding(2);
        bt_wrt_dest_names.Name = "bt_wrt_dest_names";
        bt_wrt_dest_names.Size = new Size(76, 26);
        bt_wrt_dest_names.TabIndex = 25;
        bt_wrt_dest_names.Text = "3. Write Dest";
        bt_wrt_dest_names.UseVisualStyleBackColor = true;
        bt_wrt_dest_names.Click += bt_wrt_dest_names_Click;
        // 
        // tb_sub_c
        // 
        tb_sub_c.AutoCompleteCustomSource.AddRange(new string[] { "AF", "EG", "AX", "AL", "DZ", "AS", "AD", "AO", "AI", "AQ", "AG", "GQ", "AR", "AM", "AW", "AZ", "ET", "AU", "BS", "BH", "BD", "BB", "BY", "BE", "BZ", "BJ", "BM", "BT", "BO", "BA", "BW", "BV", "BR", "IO", "BN", "BG", "BF", "BI", "CL", "CN", "CK", "CR", "CW", "DK", "CD", "DE", "DM", "DO", "DJ", "EC", "SV", "CI", "ER", "EE", "SZ", "FK", "FO", "FJ", "FI", "FM", "FR", "GF", "PF", "TF", "MC", "GA", "GM", "GE", "GH", "GI", "GD", "GR", "GL", "GP", "GU", "GT", "GG", "GN", "GW", "GY", "HT", "HM", "HN", "HK", "IN", "ID", "IM", "IQ", "IR", "IE", "IS", "IL", "IT", "JM", "JP", "YE", "JE", "JO", "VG", "VI", "KY", "KH", "CM", "CA", "CV", "BQ", "KZ", "QA", "KE", "KG", "KI", "UM", "CC", "CO", "KM", "XK", "HR", "CU", "KW", "LA", "LS", "LV", "LB", "LR", "LY", "LI", "LT", "LU", "MO", "MG", "MW", "MY", "MV", "ML", "MT", "MA", "MH", "MQ", "MR", "MU", "YT", "MX", "MD", "MN", "ME", "MS", "MZ", "MM", "NA", "NR", "NP", "NC", "NZ", "NI", "NL", "NE", "NG", "NU", "KP", "MP", "MK", "NF", "NO", "OM", "AT", "TL", "PK", "PS", "PW", "PA", "PG", "PY", "PE", "PH", "PN", "PL", "PT", "PR", "CG", "RE", "RW", "RO", "RU", "MF", "SB", "ZM", "WS", "SM", "BL", "ST", "SA", "SE", "CH", "SN", "RS", "SC", "SL", "ZW", "SG", "SX", "SK", "SI", "SO", "ES", "LK", "SH", "KN", "LC", "PM", "VC", "ZA", "SD", "GS", "KR", "SS", "SR", "SJ", "SY", "TJ", "TW", "TZ", "TH", "TG", "TK", "TO", "TT", "TD", "CZ", "TN", "TR", "TM", "TC", "TV", "UG", "UA", "HU", "UY", "UZ", "VU", "VA", "VE", "AE", "US", "GB", "VN", "WF", "CX", "EH", "CF", "CY" });
        tb_sub_c.CharacterCasing = CharacterCasing.Upper;
        tb_sub_c.Location = new Point(113, 30);
        tb_sub_c.MaxLength = 2;
        tb_sub_c.Name = "tb_sub_c";
        tb_sub_c.Size = new Size(100, 23);
        tb_sub_c.TabIndex = 7;
        // 
        // lbl_def_email
        // 
        lbl_def_email.AutoSize = true;
        lbl_def_email.Location = new Point(66, 183);
        lbl_def_email.Name = "lbl_def_email";
        lbl_def_email.Size = new Size(41, 15);
        lbl_def_email.TabIndex = 6;
        lbl_def_email.Text = "E-Mail";
        // 
        // lbl_def_commonName
        // 
        lbl_def_commonName.AutoSize = true;
        lbl_def_commonName.Location = new Point(14, 162);
        lbl_def_commonName.Name = "lbl_def_commonName";
        lbl_def_commonName.Size = new Size(93, 15);
        lbl_def_commonName.TabIndex = 5;
        lbl_def_commonName.Text = "Common Name";
        // 
        // lbl_def_organisationUnit
        // 
        lbl_def_organisationUnit.AutoSize = true;
        lbl_def_organisationUnit.Location = new Point(30, 130);
        lbl_def_organisationUnit.Name = "lbl_def_organisationUnit";
        lbl_def_organisationUnit.Size = new Size(75, 15);
        lbl_def_organisationUnit.TabIndex = 4;
        lbl_def_organisationUnit.Text = "Organisation";
        // 
        // lbl_def_organisation
        // 
        lbl_def_organisation.AutoSize = true;
        lbl_def_organisation.Location = new Point(46, 109);
        lbl_def_organisation.Name = "lbl_def_organisation";
        lbl_def_organisation.Size = new Size(61, 15);
        lbl_def_organisation.TabIndex = 3;
        lbl_def_organisation.Text = "Orga. Unit";
        // 
        // lbl_def_location
        // 
        lbl_def_location.AutoSize = true;
        lbl_def_location.Location = new Point(54, 84);
        lbl_def_location.Name = "lbl_def_location";
        lbl_def_location.Size = new Size(53, 15);
        lbl_def_location.TabIndex = 2;
        lbl_def_location.Text = "Location";
        // 
        // lbl_def_state
        // 
        lbl_def_state.AutoSize = true;
        lbl_def_state.Location = new Point(74, 56);
        lbl_def_state.Name = "lbl_def_state";
        lbl_def_state.Size = new Size(33, 15);
        lbl_def_state.TabIndex = 1;
        lbl_def_state.Text = "State";
        // 
        // lbl_def_country
        // 
        lbl_def_country.AutoSize = true;
        lbl_def_country.Location = new Point(57, 33);
        lbl_def_country.Name = "lbl_def_country";
        lbl_def_country.Size = new Size(50, 15);
        lbl_def_country.TabIndex = 0;
        lbl_def_country.Text = "Country";
        // 
        // lbl_ca_name
        // 
        lbl_ca_name.AutoSize = true;
        lbl_ca_name.Location = new Point(3, 119);
        lbl_ca_name.Name = "lbl_ca_name";
        lbl_ca_name.Size = new Size(77, 15);
        lbl_ca_name.TabIndex = 10;
        lbl_ca_name.Text = "Server Name:";
        // 
        // lb_ca_certs
        // 
        lb_ca_certs.FormattingEnabled = true;
        lb_ca_certs.ItemHeight = 15;
        lb_ca_certs.Location = new Point(62, 5);
        lb_ca_certs.Margin = new Padding(2);
        lb_ca_certs.Name = "lb_ca_certs";
        lb_ca_certs.Size = new Size(124, 79);
        lb_ca_certs.TabIndex = 14;
        // 
        // cb_ca_keySize
        // 
        cb_ca_keySize.FormattingEnabled = true;
        cb_ca_keySize.Items.AddRange(new object[] { "2048", "4096", "8192" });
        cb_ca_keySize.Location = new Point(86, 145);
        cb_ca_keySize.Name = "cb_ca_keySize";
        cb_ca_keySize.Size = new Size(100, 23);
        cb_ca_keySize.TabIndex = 24;
        cb_ca_keySize.Text = "4096";
        // 
        // lbl_keySize
        // 
        lbl_keySize.AutoSize = true;
        lbl_keySize.Location = new Point(54, 149);
        lbl_keySize.Name = "lbl_keySize";
        lbl_keySize.Size = new Size(26, 15);
        lbl_keySize.TabIndex = 0;
        lbl_keySize.Text = "Bits";
        // 
        // tb_ca_dura
        // 
        tb_ca_dura.Location = new Point(86, 175);
        tb_ca_dura.Name = "tb_ca_dura";
        tb_ca_dura.Size = new Size(100, 23);
        tb_ca_dura.TabIndex = 4;
        tb_ca_dura.Text = "120";
        // 
        // lbl_pub_duration
        // 
        lbl_pub_duration.AutoSize = true;
        lbl_pub_duration.Location = new Point(27, 179);
        lbl_pub_duration.Name = "lbl_pub_duration";
        lbl_pub_duration.Size = new Size(53, 15);
        lbl_pub_duration.TabIndex = 0;
        lbl_pub_duration.Text = "Duration";
        // 
        // cb_new_server
        // 
        cb_new_server.AutoSize = true;
        cb_new_server.Location = new Point(86, 92);
        cb_new_server.Name = "cb_new_server";
        cb_new_server.Size = new Size(85, 19);
        cb_new_server.TabIndex = 17;
        cb_new_server.Text = "New Server";
        cb_new_server.UseVisualStyleBackColor = true;
        cb_new_server.CheckedChanged += cb_new_server_CheckedChanged;
        // 
        // rb_ca
        // 
        rb_ca.AutoSize = true;
        rb_ca.Checked = true;
        rb_ca.Location = new Point(3, 3);
        rb_ca.Name = "rb_ca";
        rb_ca.Size = new Size(41, 19);
        rb_ca.TabIndex = 18;
        rb_ca.TabStop = true;
        rb_ca.Text = "CA";
        rb_ca.UseVisualStyleBackColor = true;
        rb_ca.CheckedChanged += radioButtons_CheckedChanged;
        // 
        // rb_intermediate
        // 
        rb_intermediate.AutoSize = true;
        rb_intermediate.Location = new Point(3, 28);
        rb_intermediate.Name = "rb_intermediate";
        rb_intermediate.Size = new Size(92, 19);
        rb_intermediate.TabIndex = 19;
        rb_intermediate.Text = "Intermediate";
        rb_intermediate.UseVisualStyleBackColor = true;
        rb_intermediate.CheckedChanged += radioButtons_CheckedChanged;
        // 
        // rb_server
        // 
        rb_server.AutoSize = true;
        rb_server.Location = new Point(3, 53);
        rb_server.Name = "rb_server";
        rb_server.Size = new Size(57, 19);
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
        panel1.Location = new Point(69, 461);
        panel1.Name = "panel1";
        panel1.Size = new Size(102, 113);
        panel1.TabIndex = 21;
        // 
        // rb_user
        // 
        rb_user.AutoSize = true;
        rb_user.Location = new Point(3, 76);
        rb_user.Name = "rb_user";
        rb_user.Size = new Size(48, 19);
        rb_user.TabIndex = 21;
        rb_user.Text = "User";
        rb_user.UseVisualStyleBackColor = true;
        rb_user.CheckedChanged += radioButtons_CheckedChanged;
        // 
        // Bt_gen_ca_priv
        // 
        Bt_gen_ca_priv.Location = new Point(85, 208);
        Bt_gen_ca_priv.Margin = new Padding(2);
        Bt_gen_ca_priv.Name = "Bt_gen_ca_priv";
        Bt_gen_ca_priv.Size = new Size(76, 47);
        Bt_gen_ca_priv.TabIndex = 23;
        Bt_gen_ca_priv.Text = "1. Generate Private Key";
        Bt_gen_ca_priv.UseVisualStyleBackColor = true;
        Bt_gen_ca_priv.Click += Bt_gen_ca_priv_onClick;
        // 
        // Bt_gen_ca_selfSigned_key
        // 
        Bt_gen_ca_selfSigned_key.Location = new Point(85, 369);
        Bt_gen_ca_selfSigned_key.Name = "Bt_gen_ca_selfSigned_key";
        Bt_gen_ca_selfSigned_key.Size = new Size(76, 47);
        Bt_gen_ca_selfSigned_key.TabIndex = 24;
        Bt_gen_ca_selfSigned_key.Text = "5. Generate CSR";
        Bt_gen_ca_selfSigned_key.UseVisualStyleBackColor = true;
        Bt_gen_ca_selfSigned_key.Click += Bt_gen_ca_selfSigned_key_Click;
        // 
        // cb_isCa
        // 
        cb_isCa.AutoSize = true;
        cb_isCa.Enabled = false;
        cb_isCa.Location = new Point(6, 9);
        cb_isCa.Margin = new Padding(2);
        cb_isCa.Name = "cb_isCa";
        cb_isCa.Size = new Size(58, 19);
        cb_isCa.TabIndex = 26;
        cb_isCa.Text = "is CA?";
        cb_isCa.UseVisualStyleBackColor = true;
        // 
        // cb_notPathlen
        // 
        cb_notPathlen.AutoSize = true;
        cb_notPathlen.Location = new Point(6, 32);
        cb_notPathlen.Margin = new Padding(2);
        cb_notPathlen.Name = "cb_notPathlen";
        cb_notPathlen.Size = new Size(87, 19);
        cb_notPathlen.TabIndex = 27;
        cb_notPathlen.Text = "not pathlen";
        cb_notPathlen.UseVisualStyleBackColor = true;
        // 
        // cb_issueCert
        // 
        cb_issueCert.AutoSize = true;
        cb_issueCert.Location = new Point(6, 82);
        cb_issueCert.Margin = new Padding(2);
        cb_issueCert.Name = "cb_issueCert";
        cb_issueCert.Size = new Size(82, 19);
        cb_issueCert.TabIndex = 28;
        cb_issueCert.Text = "issue Cert?";
        cb_issueCert.UseVisualStyleBackColor = true;
        // 
        // cb_depth
        // 
        cb_depth.FormattingEnabled = true;
        cb_depth.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" });
        cb_depth.Location = new Point(6, 55);
        cb_depth.Margin = new Padding(2);
        cb_depth.Name = "cb_depth";
        cb_depth.RightToLeft = RightToLeft.No;
        cb_depth.Size = new Size(32, 23);
        cb_depth.TabIndex = 29;
        cb_depth.Text = "0";
        // 
        // lbl_unlimDepth
        // 
        lbl_unlimDepth.AutoSize = true;
        lbl_unlimDepth.Location = new Point(45, 58);
        lbl_unlimDepth.Margin = new Padding(2, 0, 2, 0);
        lbl_unlimDepth.Name = "lbl_unlimDepth";
        lbl_unlimDepth.Size = new Size(38, 15);
        lbl_unlimDepth.TabIndex = 30;
        lbl_unlimDepth.Text = "depth";
        // 
        // panel2
        // 
        panel2.Controls.Add(Bt_wrt_param);
        panel2.Controls.Add(cb_notPathlen);
        panel2.Controls.Add(cb_isCa);
        panel2.Controls.Add(cb_depth);
        panel2.Controls.Add(lbl_unlimDepth);
        panel2.Controls.Add(cb_issueCert);
        panel2.Location = new Point(196, 461);
        panel2.Name = "panel2";
        panel2.Size = new Size(102, 140);
        panel2.TabIndex = 31;
        // 
        // Bt_wrt_param
        // 
        Bt_wrt_param.Location = new Point(8, 110);
        Bt_wrt_param.Name = "Bt_wrt_param";
        Bt_wrt_param.Size = new Size(75, 23);
        Bt_wrt_param.TabIndex = 31;
        Bt_wrt_param.Text = "4. Write Param";
        Bt_wrt_param.UseVisualStyleBackColor = true;
        Bt_wrt_param.Click += Bt_wrt_param_Click;
        // 
        // lb_inter_certs
        // 
        lb_inter_certs.FormattingEnabled = true;
        lb_inter_certs.ItemHeight = 15;
        lb_inter_certs.Location = new Point(292, 5);
        lb_inter_certs.Name = "lb_inter_certs";
        lb_inter_certs.Size = new Size(120, 79);
        lb_inter_certs.TabIndex = 32;
        // 
        // Bt_gen_int_priv
        // 
        Bt_gen_int_priv.Location = new Point(329, 208);
        Bt_gen_int_priv.Name = "Bt_gen_int_priv";
        Bt_gen_int_priv.Size = new Size(75, 47);
        Bt_gen_int_priv.TabIndex = 33;
        Bt_gen_int_priv.Text = "1. Generate Private Key";
        Bt_gen_int_priv.UseVisualStyleBackColor = true;
        Bt_gen_int_priv.Click += Bt_gen_int_priv_Click;
        // 
        // lbl_int_bit
        // 
        lbl_int_bit.AutoSize = true;
        lbl_int_bit.Location = new Point(280, 149);
        lbl_int_bit.Name = "lbl_int_bit";
        lbl_int_bit.Size = new Size(26, 15);
        lbl_int_bit.TabIndex = 34;
        lbl_int_bit.Text = "Bits";
        // 
        // cb_int_keySize
        // 
        cb_int_keySize.FormattingEnabled = true;
        cb_int_keySize.Items.AddRange(new object[] { "2048", "4096", "8192" });
        cb_int_keySize.Location = new Point(312, 145);
        cb_int_keySize.Name = "cb_int_keySize";
        cb_int_keySize.Size = new Size(100, 23);
        cb_int_keySize.TabIndex = 37;
        cb_int_keySize.Text = "4096";
        // 
        // tb_int_pub_dura
        // 
        tb_int_pub_dura.Location = new Point(312, 174);
        tb_int_pub_dura.Name = "tb_int_pub_dura";
        tb_int_pub_dura.Size = new Size(100, 23);
        tb_int_pub_dura.TabIndex = 36;
        tb_int_pub_dura.Text = "60";
        // 
        // lbl_int_pub_duration
        // 
        lbl_int_pub_duration.AutoSize = true;
        lbl_int_pub_duration.Location = new Point(253, 179);
        lbl_int_pub_duration.Name = "lbl_int_pub_duration";
        lbl_int_pub_duration.Size = new Size(53, 15);
        lbl_int_pub_duration.TabIndex = 35;
        lbl_int_pub_duration.Text = "Duration";
        // 
        // tb_int_name
        // 
        tb_int_name.Location = new Point(312, 117);
        tb_int_name.Name = "tb_int_name";
        tb_int_name.Size = new Size(100, 23);
        tb_int_name.TabIndex = 39;
        // 
        // lbl_int_name
        // 
        lbl_int_name.AutoSize = true;
        lbl_int_name.Location = new Point(194, 119);
        lbl_int_name.Name = "lbl_int_name";
        lbl_int_name.Size = new Size(112, 15);
        lbl_int_name.TabIndex = 38;
        lbl_int_name.Text = "Intermediate Name:";
        // 
        // cb_new_inter
        // 
        cb_new_inter.AutoSize = true;
        cb_new_inter.Location = new Point(292, 92);
        cb_new_inter.Name = "cb_new_inter";
        cb_new_inter.Size = new Size(120, 19);
        cb_new_inter.TabIndex = 40;
        cb_new_inter.Text = "New Intermediate";
        cb_new_inter.UseVisualStyleBackColor = true;
        cb_new_inter.CheckedChanged += cb_new_inter_CheckedChanged;
        // 
        // Bt_gen_int_pub
        // 
        Bt_gen_int_pub.Location = new Point(328, 260);
        Bt_gen_int_pub.Name = "Bt_gen_int_pub";
        Bt_gen_int_pub.Size = new Size(75, 47);
        Bt_gen_int_pub.TabIndex = 41;
        Bt_gen_int_pub.Text = "2. Generate Public Key";
        Bt_gen_int_pub.UseVisualStyleBackColor = true;
        Bt_gen_int_pub.Click += Bt_gen_int_pub_Click;
        // 
        // Bt_gen_ca_pub
        // 
        Bt_gen_ca_pub.Location = new Point(85, 260);
        Bt_gen_ca_pub.Margin = new Padding(2);
        Bt_gen_ca_pub.Name = "Bt_gen_ca_pub";
        Bt_gen_ca_pub.Size = new Size(76, 47);
        Bt_gen_ca_pub.TabIndex = 42;
        Bt_gen_ca_pub.Text = "2. Generate Public Key";
        Bt_gen_ca_pub.UseVisualStyleBackColor = true;
        Bt_gen_ca_pub.Click += Bt_gen_ca_pub_onClick;
        // 
        // Bt_gen_int_selfSigned_key
        // 
        Bt_gen_int_selfSigned_key.Location = new Point(326, 370);
        Bt_gen_int_selfSigned_key.Name = "Bt_gen_int_selfSigned_key";
        Bt_gen_int_selfSigned_key.Size = new Size(76, 47);
        Bt_gen_int_selfSigned_key.TabIndex = 43;
        Bt_gen_int_selfSigned_key.Text = "5. Generate CSR";
        Bt_gen_int_selfSigned_key.UseVisualStyleBackColor = true;
        Bt_gen_int_selfSigned_key.Click += Bt_gen_int_selfSigned_key_Click;
        // 
        // Bt_sign_int_cert
        // 
        Bt_sign_int_cert.Location = new Point(231, 351);
        Bt_sign_int_cert.Name = "Bt_sign_int_cert";
        Bt_sign_int_cert.Size = new Size(75, 44);
        Bt_sign_int_cert.TabIndex = 44;
        Bt_sign_int_cert.Text = "6. Sign Certificate";
        Bt_sign_int_cert.UseVisualStyleBackColor = true;
        Bt_sign_int_cert.Visible = false;
        // 
        // Bt_read_ca_subj
        // 
        Bt_read_ca_subj.AccessibleName = "ca";
        Bt_read_ca_subj.AccessibleRole = AccessibleRole.None;
        Bt_read_ca_subj.Location = new Point(86, 312);
        Bt_read_ca_subj.Name = "Bt_read_ca_subj";
        Bt_read_ca_subj.Size = new Size(75, 51);
        Bt_read_ca_subj.TabIndex = 45;
        Bt_read_ca_subj.Text = "Read Subjects";
        Bt_read_ca_subj.UseVisualStyleBackColor = true;
        Bt_read_ca_subj.Click += Bt_read_Dest_names_Click;
        // 
        // Bt_read_int_subj
        // 
        Bt_read_int_subj.AccessibleName = "int";
        Bt_read_int_subj.AccessibleRole = AccessibleRole.None;
        Bt_read_int_subj.Location = new Point(328, 313);
        Bt_read_int_subj.Name = "Bt_read_int_subj";
        Bt_read_int_subj.Size = new Size(75, 51);
        Bt_read_int_subj.TabIndex = 46;
        Bt_read_int_subj.Text = "Read Subjects";
        Bt_read_int_subj.UseVisualStyleBackColor = true;
        Bt_read_int_subj.Click += Bt_read_Dest_names_Click;
        // 
        // Bt_read_server_subj
        // 
        Bt_read_server_subj.AccessibleName = "int";
        Bt_read_server_subj.AccessibleRole = AccessibleRole.None;
        Bt_read_server_subj.Location = new Point(518, 313);
        Bt_read_server_subj.Name = "Bt_read_server_subj";
        Bt_read_server_subj.Size = new Size(75, 51);
        Bt_read_server_subj.TabIndex = 58;
        Bt_read_server_subj.Text = "Read Subjects";
        Bt_read_server_subj.UseVisualStyleBackColor = true;
        // 
        // Bt_gen_server_selfSigned_key
        // 
        Bt_gen_server_selfSigned_key.Location = new Point(516, 370);
        Bt_gen_server_selfSigned_key.Name = "Bt_gen_server_selfSigned_key";
        Bt_gen_server_selfSigned_key.Size = new Size(76, 47);
        Bt_gen_server_selfSigned_key.TabIndex = 57;
        Bt_gen_server_selfSigned_key.Text = "5. Generate CSR";
        Bt_gen_server_selfSigned_key.UseVisualStyleBackColor = true;
        // 
        // Bt_gen_server_pub
        // 
        Bt_gen_server_pub.Location = new Point(518, 260);
        Bt_gen_server_pub.Name = "Bt_gen_server_pub";
        Bt_gen_server_pub.Size = new Size(75, 47);
        Bt_gen_server_pub.TabIndex = 56;
        Bt_gen_server_pub.Text = "2. Generate Public Key";
        Bt_gen_server_pub.UseVisualStyleBackColor = true;
        // 
        // checkBox1
        // 
        checkBox1.AutoSize = true;
        checkBox1.Location = new Point(482, 92);
        checkBox1.Name = "checkBox1";
        checkBox1.Size = new Size(85, 19);
        checkBox1.TabIndex = 55;
        checkBox1.Text = "New Server";
        checkBox1.TextAlign = ContentAlignment.MiddleRight;
        checkBox1.UseVisualStyleBackColor = true;
        // 
        // textBox1
        // 
        textBox1.Location = new Point(502, 117);
        textBox1.Name = "textBox1";
        textBox1.Size = new Size(100, 23);
        textBox1.TabIndex = 54;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(419, 120);
        label1.Name = "label1";
        label1.Size = new Size(77, 15);
        label1.TabIndex = 53;
        label1.Text = "Server Name:";
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(451, 148);
        label2.Name = "label2";
        label2.Size = new Size(45, 15);
        label2.TabIndex = 49;
        label2.Text = "Keysize";
        // 
        // comboBox1
        // 
        comboBox1.FormattingEnabled = true;
        comboBox1.Items.AddRange(new object[] { "2048", "4096", "8192" });
        comboBox1.Location = new Point(502, 145);
        comboBox1.Name = "comboBox1";
        comboBox1.Size = new Size(100, 23);
        comboBox1.TabIndex = 52;
        comboBox1.Text = "4096";
        // 
        // textBox2
        // 
        textBox2.Location = new Point(502, 174);
        textBox2.Name = "textBox2";
        textBox2.Size = new Size(100, 23);
        textBox2.TabIndex = 51;
        textBox2.Text = "60";
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Location = new Point(443, 179);
        label3.Name = "label3";
        label3.Size = new Size(53, 15);
        label3.TabIndex = 50;
        label3.Text = "Duration";
        // 
        // Bt_gen_server_priv
        // 
        Bt_gen_server_priv.Location = new Point(519, 208);
        Bt_gen_server_priv.Name = "Bt_gen_server_priv";
        Bt_gen_server_priv.Size = new Size(75, 47);
        Bt_gen_server_priv.TabIndex = 48;
        Bt_gen_server_priv.Text = "1. Generate Private Key";
        Bt_gen_server_priv.UseVisualStyleBackColor = true;
        // 
        // lb_server_certs
        // 
        lb_server_certs.FormattingEnabled = true;
        lb_server_certs.ItemHeight = 15;
        lb_server_certs.Location = new Point(482, 5);
        lb_server_certs.Name = "lb_server_certs";
        lb_server_certs.Size = new Size(120, 79);
        lb_server_certs.TabIndex = 47;
        // 
        // Bt_read_user_subj
        // 
        Bt_read_user_subj.AccessibleName = "int";
        Bt_read_user_subj.AccessibleRole = AccessibleRole.None;
        Bt_read_user_subj.Location = new Point(701, 313);
        Bt_read_user_subj.Name = "Bt_read_user_subj";
        Bt_read_user_subj.Size = new Size(75, 51);
        Bt_read_user_subj.TabIndex = 70;
        Bt_read_user_subj.Text = "Read Subjects";
        Bt_read_user_subj.UseVisualStyleBackColor = true;
        // 
        // Bt_gen_user_selfSigned_key
        // 
        Bt_gen_user_selfSigned_key.Location = new Point(699, 370);
        Bt_gen_user_selfSigned_key.Name = "Bt_gen_user_selfSigned_key";
        Bt_gen_user_selfSigned_key.Size = new Size(76, 47);
        Bt_gen_user_selfSigned_key.TabIndex = 69;
        Bt_gen_user_selfSigned_key.Text = "5. Generate CSR";
        Bt_gen_user_selfSigned_key.UseVisualStyleBackColor = true;
        // 
        // Bt_gen_user_pub
        // 
        Bt_gen_user_pub.Location = new Point(701, 260);
        Bt_gen_user_pub.Name = "Bt_gen_user_pub";
        Bt_gen_user_pub.Size = new Size(75, 47);
        Bt_gen_user_pub.TabIndex = 68;
        Bt_gen_user_pub.Text = "2. Generate Public Key";
        Bt_gen_user_pub.UseVisualStyleBackColor = true;
        // 
        // checkBox2
        // 
        checkBox2.AutoSize = true;
        checkBox2.Location = new Point(665, 92);
        checkBox2.Name = "checkBox2";
        checkBox2.Size = new Size(76, 19);
        checkBox2.TabIndex = 67;
        checkBox2.Text = "New User";
        checkBox2.TextAlign = ContentAlignment.MiddleRight;
        checkBox2.UseVisualStyleBackColor = true;
        // 
        // textBox3
        // 
        textBox3.Location = new Point(685, 117);
        textBox3.Name = "textBox3";
        textBox3.Size = new Size(100, 23);
        textBox3.TabIndex = 66;
        // 
        // label4
        // 
        label4.AutoSize = true;
        label4.Location = new Point(611, 120);
        label4.Name = "label4";
        label4.Size = new Size(68, 15);
        label4.TabIndex = 65;
        label4.Text = "User Name:";
        label4.TextAlign = ContentAlignment.TopRight;
        // 
        // label5
        // 
        label5.AutoSize = true;
        label5.Location = new Point(634, 148);
        label5.Name = "label5";
        label5.Size = new Size(45, 15);
        label5.TabIndex = 61;
        label5.Text = "Keysize";
        // 
        // comboBox2
        // 
        comboBox2.FormattingEnabled = true;
        comboBox2.Items.AddRange(new object[] { "2048", "4096", "8192" });
        comboBox2.Location = new Point(685, 145);
        comboBox2.Name = "comboBox2";
        comboBox2.Size = new Size(100, 23);
        comboBox2.TabIndex = 64;
        comboBox2.Text = "4096";
        // 
        // textBox4
        // 
        textBox4.Location = new Point(685, 174);
        textBox4.Name = "textBox4";
        textBox4.Size = new Size(100, 23);
        textBox4.TabIndex = 63;
        textBox4.Text = "60";
        // 
        // label6
        // 
        label6.AutoSize = true;
        label6.Location = new Point(626, 179);
        label6.Name = "label6";
        label6.Size = new Size(53, 15);
        label6.TabIndex = 62;
        label6.Text = "Duration";
        // 
        // Bt_gen_user_priv
        // 
        Bt_gen_user_priv.Location = new Point(702, 208);
        Bt_gen_user_priv.Name = "Bt_gen_user_priv";
        Bt_gen_user_priv.Size = new Size(75, 47);
        Bt_gen_user_priv.TabIndex = 60;
        Bt_gen_user_priv.Text = "1. Generate Private Key";
        Bt_gen_user_priv.UseVisualStyleBackColor = true;
        // 
        // lb_user_certs
        // 
        lb_user_certs.FormattingEnabled = true;
        lb_user_certs.ItemHeight = 15;
        lb_user_certs.Location = new Point(665, 5);
        lb_user_certs.Name = "lb_user_certs";
        lb_user_certs.Size = new Size(120, 79);
        lb_user_certs.TabIndex = 59;
        // 
        // Server
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(797, 915);
        Controls.Add(Bt_read_user_subj);
        Controls.Add(Bt_gen_user_selfSigned_key);
        Controls.Add(Bt_gen_user_pub);
        Controls.Add(checkBox2);
        Controls.Add(textBox3);
        Controls.Add(label4);
        Controls.Add(label5);
        Controls.Add(comboBox2);
        Controls.Add(textBox4);
        Controls.Add(label6);
        Controls.Add(Bt_gen_user_priv);
        Controls.Add(lb_user_certs);
        Controls.Add(Bt_read_server_subj);
        Controls.Add(Bt_gen_server_selfSigned_key);
        Controls.Add(Bt_gen_server_pub);
        Controls.Add(checkBox1);
        Controls.Add(textBox1);
        Controls.Add(label1);
        Controls.Add(label2);
        Controls.Add(comboBox1);
        Controls.Add(textBox2);
        Controls.Add(label3);
        Controls.Add(Bt_gen_server_priv);
        Controls.Add(lb_server_certs);
        Controls.Add(Bt_read_int_subj);
        Controls.Add(Bt_read_ca_subj);
        Controls.Add(Bt_sign_int_cert);
        Controls.Add(Bt_gen_int_selfSigned_key);
        Controls.Add(Bt_gen_ca_pub);
        Controls.Add(Bt_gen_int_pub);
        Controls.Add(cb_new_inter);
        Controls.Add(tb_int_name);
        Controls.Add(lbl_int_name);
        Controls.Add(lbl_int_bit);
        Controls.Add(cb_int_keySize);
        Controls.Add(tb_int_pub_dura);
        Controls.Add(lbl_int_pub_duration);
        Controls.Add(Bt_gen_int_priv);
        Controls.Add(lb_inter_certs);
        Controls.Add(panel2);
        Controls.Add(lbl_keySize);
        Controls.Add(cb_ca_keySize);
        Controls.Add(tb_ca_dura);
        Controls.Add(lbl_pub_duration);
        Controls.Add(Bt_gen_ca_selfSigned_key);
        Controls.Add(Bt_gen_ca_priv);
        Controls.Add(panel1);
        Controls.Add(cb_new_server);
        Controls.Add(lb_ca_certs);
        Controls.Add(tb_ca_name);
        Controls.Add(gb_default_disti_names);
        Controls.Add(lbl_ca_name);
        Margin = new Padding(2);
        Name = "Server";
        Text = "server";
        Load += server_onLoad;
        gb_default_disti_names.ResumeLayout(false);
        gb_default_disti_names.PerformLayout();
        panel1.ResumeLayout(false);
        panel1.PerformLayout();
        panel2.ResumeLayout(false);
        panel2.PerformLayout();
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
    private ListBox lb_ca_certs;
    private Label lbl_keySize;
    private TextBox tb_ca_dura;
    private Label lbl_pub_duration;
    private CheckBox cb_new_server;
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
    private CheckBox cb_issueCert;
    private ComboBox cb_depth;
    private Label lbl_unlimDepth;
    private Panel panel2;
    private ListBox lb_inter_certs;
    private Button Bt_gen_int_priv;
    private Label lbl_int_bit;
    private ComboBox cb_int_keySize;
    private TextBox tb_int_pub_dura;
    private Label lbl_int_pub_duration;
    private TextBox tb_int_name;
    private Label lbl_int_name;
    private CheckBox cb_new_inter;
    private Button Bt_gen_int_pub;
    private Button Bt_read_Dest_names;
    private Button Bt_gen_ca_pub;
    private Button Bt_wrt_param;
    private Button Bt_gen_int_selfSigned_key;
    private Button Bt_sign_int_cert;
    private Button Bt_read_ca_subj;
    private Button Bt_read_int_subj;
    private Button Bt_read_server_subj;
    private Button Bt_gen_server_selfSigned_key;
    private Button Bt_gen_server_pub;
    private CheckBox checkBox1;
    private TextBox textBox1;
    private Label label1;
    private Label label2;
    private ComboBox comboBox1;
    private TextBox textBox2;
    private Label label3;
    private Button Bt_gen_server_priv;
    private ListBox lb_server_certs;
    private Button Bt_read_user_subj;
    private Button Bt_gen_user_selfSigned_key;
    private Button Bt_gen_user_pub;
    private CheckBox checkBox2;
    private TextBox textBox3;
    private Label label4;
    private Label label5;
    private ComboBox comboBox2;
    private TextBox textBox4;
    private Label label6;
    private Button Bt_gen_user_priv;
    private ListBox lb_user_certs;
}
