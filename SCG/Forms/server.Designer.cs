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
        lb_server_certs = new ListBox();
        cb_priv_bits = new ComboBox();
        lbl_priv_bits = new Label();
        tb_pub_dura = new TextBox();
        lbl_pub_duration = new Label();
        cb_new_server = new CheckBox();
        rb_ca = new RadioButton();
        rb_intermediate = new RadioButton();
        rb_server = new RadioButton();
        panel1 = new Panel();
        rb_user = new RadioButton();
        Bt_gen_ca_priv = new Button();
        saveFileDialog1 = new SaveFileDialog();
        bt_gen_pub_key = new Button();
        cb_isCa = new CheckBox();
        cb_notPathlen = new CheckBox();
        cb_issueCert = new CheckBox();
        cb_depth = new ComboBox();
        lbl_unlimDepth = new Label();
        panel2 = new Panel();
        Bt_wrt_param = new Button();
        lb_inter_certs = new ListBox();
        Bt_gen_inter = new Button();
        lbl_int_bit = new Label();
        cb_int_priv_bits = new ComboBox();
        tb_int_pub_dura = new TextBox();
        lbl_int_pub_duration = new Label();
        tb_int_name = new TextBox();
        lbl_int_name = new Label();
        checkBox1 = new CheckBox();
        Bt_int_gen_csr = new Button();
        Bt_gen_ca_pub = new Button();
        Bt_ca_selfSigned = new Button();
        gb_default_disti_names.SuspendLayout();
        panel1.SuspendLayout();
        panel2.SuspendLayout();
        SuspendLayout();
        // 
        // tb_ca_name
        // 
        tb_ca_name.Location = new Point(147, 240);
        tb_ca_name.Margin = new Padding(5, 6, 5, 6);
        tb_ca_name.Name = "tb_ca_name";
        tb_ca_name.Size = new Size(169, 35);
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
        gb_default_disti_names.Location = new Point(951, 24);
        gb_default_disti_names.Margin = new Padding(5, 6, 5, 6);
        gb_default_disti_names.Name = "gb_default_disti_names";
        gb_default_disti_names.Padding = new Padding(5, 6, 5, 6);
        gb_default_disti_names.Size = new Size(393, 478);
        gb_default_disti_names.TabIndex = 11;
        gb_default_disti_names.TabStop = false;
        gb_default_disti_names.Text = "Default Distinguished Names";
        // 
        // Bt_read_Dest_names
        // 
        Bt_read_Dest_names.Location = new Point(235, 416);
        Bt_read_Dest_names.Margin = new Padding(5, 6, 5, 6);
        Bt_read_Dest_names.Name = "Bt_read_Dest_names";
        Bt_read_Dest_names.Size = new Size(130, 52);
        Bt_read_Dest_names.TabIndex = 26;
        Bt_read_Dest_names.Text = "Read";
        Bt_read_Dest_names.UseVisualStyleBackColor = true;
        Bt_read_Dest_names.Click += Bt_read_Dest_names_Click;
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
        bt_wrt_dest_names.Location = new Point(24, 416);
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
        tb_sub_c.Location = new Point(194, 60);
        tb_sub_c.Margin = new Padding(5, 6, 5, 6);
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
        lbl_ca_name.Location = new Point(5, 244);
        lbl_ca_name.Margin = new Padding(5, 0, 5, 0);
        lbl_ca_name.Name = "lbl_ca_name";
        lbl_ca_name.Size = new Size(137, 30);
        lbl_ca_name.TabIndex = 10;
        lbl_ca_name.Text = "Server Name:";
        // 
        // lb_server_certs
        // 
        lb_server_certs.FormattingEnabled = true;
        lb_server_certs.ItemHeight = 30;
        lb_server_certs.Location = new Point(106, 10);
        lb_server_certs.Margin = new Padding(3, 4, 3, 4);
        lb_server_certs.Name = "lb_server_certs";
        lb_server_certs.Size = new Size(210, 154);
        lb_server_certs.TabIndex = 14;
        // 
        // cb_priv_bits
        // 
        cb_priv_bits.FormattingEnabled = true;
        cb_priv_bits.Items.AddRange(new object[] { "2048", "4096", "8192" });
        cb_priv_bits.Location = new Point(147, 296);
        cb_priv_bits.Margin = new Padding(5, 6, 5, 6);
        cb_priv_bits.Name = "cb_priv_bits";
        cb_priv_bits.Size = new Size(169, 38);
        cb_priv_bits.TabIndex = 24;
        cb_priv_bits.Text = "4096";
        // 
        // lbl_priv_bits
        // 
        lbl_priv_bits.AutoSize = true;
        lbl_priv_bits.Location = new Point(93, 304);
        lbl_priv_bits.Margin = new Padding(5, 0, 5, 0);
        lbl_priv_bits.Name = "lbl_priv_bits";
        lbl_priv_bits.Size = new Size(46, 30);
        lbl_priv_bits.TabIndex = 0;
        lbl_priv_bits.Text = "Bits";
        // 
        // tb_pub_dura
        // 
        tb_pub_dura.Location = new Point(147, 356);
        tb_pub_dura.Margin = new Padding(5, 6, 5, 6);
        tb_pub_dura.Name = "tb_pub_dura";
        tb_pub_dura.Size = new Size(169, 35);
        tb_pub_dura.TabIndex = 4;
        tb_pub_dura.Text = "12";
        // 
        // lbl_pub_duration
        // 
        lbl_pub_duration.AutoSize = true;
        lbl_pub_duration.Location = new Point(46, 364);
        lbl_pub_duration.Margin = new Padding(5, 0, 5, 0);
        lbl_pub_duration.Name = "lbl_pub_duration";
        lbl_pub_duration.Size = new Size(94, 30);
        lbl_pub_duration.TabIndex = 0;
        lbl_pub_duration.Text = "Duration";
        // 
        // cb_new_server
        // 
        cb_new_server.AutoSize = true;
        cb_new_server.Location = new Point(173, 188);
        cb_new_server.Margin = new Padding(5, 6, 5, 6);
        cb_new_server.Name = "cb_new_server";
        cb_new_server.Size = new Size(144, 34);
        cb_new_server.TabIndex = 17;
        cb_new_server.Text = "New Server";
        cb_new_server.UseVisualStyleBackColor = true;
        cb_new_server.CheckedChanged += cb_new_server_CheckedChanged;
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
        panel1.Location = new Point(348, 24);
        panel1.Margin = new Padding(5, 6, 5, 6);
        panel1.Name = "panel1";
        panel1.Size = new Size(161, 226);
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
        Bt_gen_ca_priv.Location = new Point(5, 420);
        Bt_gen_ca_priv.Margin = new Padding(3, 4, 3, 4);
        Bt_gen_ca_priv.Name = "Bt_gen_ca_priv";
        Bt_gen_ca_priv.Size = new Size(130, 94);
        Bt_gen_ca_priv.TabIndex = 23;
        Bt_gen_ca_priv.Text = "1. Generate Private Key";
        Bt_gen_ca_priv.UseVisualStyleBackColor = true;
        Bt_gen_ca_priv.Click += Bt_gen_ca_priv_onClick;
        // 
        // bt_gen_pub_key
        // 
        bt_gen_pub_key.Location = new Point(5, 524);
        bt_gen_pub_key.Margin = new Padding(5, 6, 5, 6);
        bt_gen_pub_key.Name = "bt_gen_pub_key";
        bt_gen_pub_key.Size = new Size(130, 94);
        bt_gen_pub_key.TabIndex = 24;
        bt_gen_pub_key.Text = "5. Generate CSR";
        bt_gen_pub_key.UseVisualStyleBackColor = true;
        bt_gen_pub_key.Click += bt_gen_csr_Click;
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
        cb_notPathlen.Location = new Point(10, 60);
        cb_notPathlen.Margin = new Padding(3, 4, 3, 4);
        cb_notPathlen.Name = "cb_notPathlen";
        cb_notPathlen.Size = new Size(146, 34);
        cb_notPathlen.TabIndex = 27;
        cb_notPathlen.Text = "not pathlen";
        cb_notPathlen.UseVisualStyleBackColor = true;
        // 
        // cb_issueCert
        // 
        cb_issueCert.AutoSize = true;
        cb_issueCert.Location = new Point(10, 164);
        cb_issueCert.Margin = new Padding(3, 4, 3, 4);
        cb_issueCert.Name = "cb_issueCert";
        cb_issueCert.Size = new Size(138, 34);
        cb_issueCert.TabIndex = 28;
        cb_issueCert.Text = "issue Cert?";
        cb_issueCert.UseVisualStyleBackColor = true;
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
        panel2.Controls.Add(Bt_wrt_param);
        panel2.Controls.Add(cb_notPathlen);
        panel2.Controls.Add(cb_isCa);
        panel2.Controls.Add(cb_depth);
        panel2.Controls.Add(lbl_unlimDepth);
        panel2.Controls.Add(cb_issueCert);
        panel2.Location = new Point(519, 80);
        panel2.Margin = new Padding(5, 6, 5, 6);
        panel2.Name = "panel2";
        panel2.Size = new Size(175, 280);
        panel2.TabIndex = 31;
        // 
        // Bt_wrt_param
        // 
        Bt_wrt_param.Location = new Point(14, 220);
        Bt_wrt_param.Margin = new Padding(5, 6, 5, 6);
        Bt_wrt_param.Name = "Bt_wrt_param";
        Bt_wrt_param.Size = new Size(129, 46);
        Bt_wrt_param.TabIndex = 31;
        Bt_wrt_param.Text = "4. Write Param";
        Bt_wrt_param.UseVisualStyleBackColor = true;
        Bt_wrt_param.Click += Bt_wrt_param_Click;
        // 
        // lb_inter_certs
        // 
        lb_inter_certs.FormattingEnabled = true;
        lb_inter_certs.ItemHeight = 30;
        lb_inter_certs.Location = new Point(430, 488);
        lb_inter_certs.Margin = new Padding(5, 6, 5, 6);
        lb_inter_certs.Name = "lb_inter_certs";
        lb_inter_certs.Size = new Size(203, 154);
        lb_inter_certs.TabIndex = 32;
        // 
        // Bt_gen_inter
        // 
        Bt_gen_inter.Location = new Point(465, 940);
        Bt_gen_inter.Margin = new Padding(5, 6, 5, 6);
        Bt_gen_inter.Name = "Bt_gen_inter";
        Bt_gen_inter.Size = new Size(129, 94);
        Bt_gen_inter.TabIndex = 33;
        Bt_gen_inter.Text = "Generate keypair";
        Bt_gen_inter.UseVisualStyleBackColor = true;
        Bt_gen_inter.Click += Bt_gen_inter_Click;
        // 
        // lbl_int_bit
        // 
        lbl_int_bit.AutoSize = true;
        lbl_int_bit.Location = new Point(410, 802);
        lbl_int_bit.Margin = new Padding(5, 0, 5, 0);
        lbl_int_bit.Name = "lbl_int_bit";
        lbl_int_bit.Size = new Size(46, 30);
        lbl_int_bit.TabIndex = 34;
        lbl_int_bit.Text = "Bits";
        // 
        // cb_int_priv_bits
        // 
        cb_int_priv_bits.FormattingEnabled = true;
        cb_int_priv_bits.Items.AddRange(new object[] { "2048", "4096", "8192" });
        cb_int_priv_bits.Location = new Point(465, 796);
        cb_int_priv_bits.Margin = new Padding(5, 6, 5, 6);
        cb_int_priv_bits.Name = "cb_int_priv_bits";
        cb_int_priv_bits.Size = new Size(169, 38);
        cb_int_priv_bits.TabIndex = 37;
        cb_int_priv_bits.Text = "4096";
        // 
        // tb_int_pub_dura
        // 
        tb_int_pub_dura.Location = new Point(465, 856);
        tb_int_pub_dura.Margin = new Padding(5, 6, 5, 6);
        tb_int_pub_dura.Name = "tb_int_pub_dura";
        tb_int_pub_dura.Size = new Size(169, 35);
        tb_int_pub_dura.TabIndex = 36;
        tb_int_pub_dura.Text = "12";
        // 
        // lbl_int_pub_duration
        // 
        lbl_int_pub_duration.AutoSize = true;
        lbl_int_pub_duration.Location = new Point(363, 862);
        lbl_int_pub_duration.Margin = new Padding(5, 0, 5, 0);
        lbl_int_pub_duration.Name = "lbl_int_pub_duration";
        lbl_int_pub_duration.Size = new Size(94, 30);
        lbl_int_pub_duration.TabIndex = 35;
        lbl_int_pub_duration.Text = "Duration";
        // 
        // tb_int_name
        // 
        tb_int_name.Location = new Point(465, 738);
        tb_int_name.Margin = new Padding(5, 6, 5, 6);
        tb_int_name.Name = "tb_int_name";
        tb_int_name.Size = new Size(169, 35);
        tb_int_name.TabIndex = 39;
        // 
        // lbl_int_name
        // 
        lbl_int_name.AutoSize = true;
        lbl_int_name.Location = new Point(257, 728);
        lbl_int_name.Margin = new Padding(5, 0, 5, 0);
        lbl_int_name.Name = "lbl_int_name";
        lbl_int_name.Size = new Size(198, 30);
        lbl_int_name.TabIndex = 38;
        lbl_int_name.Text = "Intermediate Name:";
        // 
        // checkBox1
        // 
        checkBox1.AutoSize = true;
        checkBox1.Location = new Point(430, 688);
        checkBox1.Margin = new Padding(5, 6, 5, 6);
        checkBox1.Name = "checkBox1";
        checkBox1.Size = new Size(205, 34);
        checkBox1.TabIndex = 40;
        checkBox1.Text = "New Intermediate";
        checkBox1.UseVisualStyleBackColor = true;
        // 
        // Bt_int_gen_csr
        // 
        Bt_int_gen_csr.Location = new Point(465, 1076);
        Bt_int_gen_csr.Margin = new Padding(5, 6, 5, 6);
        Bt_int_gen_csr.Name = "Bt_int_gen_csr";
        Bt_int_gen_csr.Size = new Size(129, 94);
        Bt_int_gen_csr.TabIndex = 41;
        Bt_int_gen_csr.Text = "Generate Inter CSR";
        Bt_int_gen_csr.UseVisualStyleBackColor = true;
        Bt_int_gen_csr.Click += Bt_int_gen_csr_Click;
        // 
        // Bt_gen_ca_pub
        // 
        Bt_gen_ca_pub.Location = new Point(147, 420);
        Bt_gen_ca_pub.Margin = new Padding(3, 4, 3, 4);
        Bt_gen_ca_pub.Name = "Bt_gen_ca_pub";
        Bt_gen_ca_pub.Size = new Size(130, 94);
        Bt_gen_ca_pub.TabIndex = 42;
        Bt_gen_ca_pub.Text = "2. Generate Public Key";
        Bt_gen_ca_pub.UseVisualStyleBackColor = true;
        Bt_gen_ca_pub.Click += Bt_gen_ca_pub_onClick;
        // 
        // Bt_ca_selfSigned
        // 
        Bt_ca_selfSigned.Location = new Point(146, 524);
        Bt_ca_selfSigned.Margin = new Padding(5, 6, 5, 6);
        Bt_ca_selfSigned.Name = "Bt_ca_selfSigned";
        Bt_ca_selfSigned.Size = new Size(130, 94);
        Bt_ca_selfSigned.TabIndex = 43;
        Bt_ca_selfSigned.Text = "6. Generate Selfsigned";
        Bt_ca_selfSigned.UseVisualStyleBackColor = true;
        Bt_ca_selfSigned.Click += Bt_ca_selfSigned_Click;
        // 
        // Server
        // 
        AutoScaleDimensions = new SizeF(12F, 30F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1365, 1420);
        Controls.Add(Bt_ca_selfSigned);
        Controls.Add(Bt_gen_ca_pub);
        Controls.Add(Bt_int_gen_csr);
        Controls.Add(checkBox1);
        Controls.Add(tb_int_name);
        Controls.Add(lbl_int_name);
        Controls.Add(lbl_int_bit);
        Controls.Add(cb_int_priv_bits);
        Controls.Add(tb_int_pub_dura);
        Controls.Add(lbl_int_pub_duration);
        Controls.Add(Bt_gen_inter);
        Controls.Add(lb_inter_certs);
        Controls.Add(panel2);
        Controls.Add(lbl_priv_bits);
        Controls.Add(cb_priv_bits);
        Controls.Add(tb_pub_dura);
        Controls.Add(lbl_pub_duration);
        Controls.Add(bt_gen_pub_key);
        Controls.Add(Bt_gen_ca_priv);
        Controls.Add(panel1);
        Controls.Add(cb_new_server);
        Controls.Add(lb_server_certs);
        Controls.Add(tb_ca_name);
        Controls.Add(gb_default_disti_names);
        Controls.Add(lbl_ca_name);
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
    private ListBox lb_server_certs;
    private Label lbl_priv_bits;
    private TextBox tb_pub_dura;
    private Label lbl_pub_duration;
    private CheckBox cb_new_server;
    private RadioButton rb_ca;
    private RadioButton rb_intermediate;
    private RadioButton rb_server;
    private Panel panel1;
    private Button Bt_gen_ca_priv;
    private ComboBox cb_priv_bits;
    private RadioButton rb_user;
    private SaveFileDialog saveFileDialog1;
    private Button bt_gen_pub_key;
    private Button bt_wrt_dest_names;
    private CheckBox cb_isCa;
    private CheckBox cb_notPathlen;
    private CheckBox cb_issueCert;
    private ComboBox cb_depth;
    private Label lbl_unlimDepth;
    private Panel panel2;
    private ListBox lb_inter_certs;
    private Button Bt_gen_inter;
    private Label lbl_int_bit;
    private ComboBox cb_int_priv_bits;
    private TextBox tb_int_pub_dura;
    private Label lbl_int_pub_duration;
    private TextBox tb_int_name;
    private Label lbl_int_name;
    private CheckBox checkBox1;
    private Button Bt_int_gen_csr;
    private Button Bt_read_Dest_names;
    private Button Bt_gen_ca_pub;
    private Button Bt_wrt_param;
    private Button Bt_ca_selfSigned;
}
