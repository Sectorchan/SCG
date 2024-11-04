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
        bt_form2_close = new Button();
        tb_ca_name = new TextBox();
        gb_default_disti_names = new GroupBox();
        tb_sub_email = new TextBox();
        tb_sub_cn = new TextBox();
        textBox6 = new TextBox();
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
        bt_ca_cnf_search = new Button();
        lbl_loc_cnf_ca = new Label();
        tb_ca_cnf_path = new TextBox();
        lb_server_certs = new ListBox();
        gb_private = new GroupBox();
        tb_priv_filename = new TextBox();
        tb_priv_passwd = new TextBox();
        tb_priv_bits = new TextBox();
        lb_priv_filename = new Label();
        lb_priv_pass = new Label();
        lb_priv_bits = new Label();
        gb_public = new GroupBox();
        tb_pub_cnf = new TextBox();
        tb_pub_passwd = new TextBox();
        tb_pub_dura = new TextBox();
        lb_pub_conffile = new Label();
        lb_pub_passwd = new Label();
        lb_pub_duration = new Label();
        cb_new_entry = new CheckBox();
        rb_ca = new RadioButton();
        rb_intermediate = new RadioButton();
        rb_server = new RadioButton();
        panel1 = new Panel();
        bt_add_server = new Button();
        button1 = new Button();
        gb_default_disti_names.SuspendLayout();
        gb_private.SuspendLayout();
        gb_public.SuspendLayout();
        panel1.SuspendLayout();
        SuspendLayout();
        // 
        // bt_form2_close
        // 
        bt_form2_close.Location = new Point(1125, 786);
        bt_form2_close.Margin = new Padding(5, 6, 5, 6);
        bt_form2_close.Name = "bt_form2_close";
        bt_form2_close.Size = new Size(219, 46);
        bt_form2_close.TabIndex = 13;
        bt_form2_close.Text = "save n close";
        bt_form2_close.UseVisualStyleBackColor = true;
        // 
        // tb_ca_name
        // 
        tb_ca_name.Location = new Point(222, 278);
        tb_ca_name.Margin = new Padding(5, 6, 5, 6);
        tb_ca_name.Name = "tb_ca_name";
        tb_ca_name.Size = new Size(169, 35);
        tb_ca_name.TabIndex = 12;
        // 
        // gb_default_disti_names
        // 
        gb_default_disti_names.Controls.Add(tb_sub_email);
        gb_default_disti_names.Controls.Add(tb_sub_cn);
        gb_default_disti_names.Controls.Add(textBox6);
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
        gb_default_disti_names.Location = new Point(768, 278);
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
        // textBox6
        // 
        textBox6.Location = new Point(194, 260);
        textBox6.Margin = new Padding(5, 6, 5, 6);
        textBox6.Name = "textBox6";
        textBox6.Size = new Size(169, 35);
        textBox6.TabIndex = 11;
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
        lbl_def_organisationUnit.Location = new Point(118, 276);
        lbl_def_organisationUnit.Margin = new Padding(5, 0, 5, 0);
        lbl_def_organisationUnit.Name = "lbl_def_organisationUnit";
        lbl_def_organisationUnit.Size = new Size(68, 30);
        lbl_def_organisationUnit.TabIndex = 4;
        lbl_def_organisationUnit.Text = "label5";
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
        lbl_ca_name.Location = new Point(54, 278);
        lbl_ca_name.Margin = new Padding(5, 0, 5, 0);
        lbl_ca_name.Name = "lbl_ca_name";
        lbl_ca_name.Size = new Size(137, 30);
        lbl_ca_name.TabIndex = 10;
        lbl_ca_name.Text = "Server Name:";
        // 
        // bt_ca_cnf_search
        // 
        bt_ca_cnf_search.Location = new Point(694, 24);
        bt_ca_cnf_search.Margin = new Padding(5, 6, 5, 6);
        bt_ca_cnf_search.Name = "bt_ca_cnf_search";
        bt_ca_cnf_search.Size = new Size(129, 46);
        bt_ca_cnf_search.TabIndex = 9;
        bt_ca_cnf_search.Text = "search";
        bt_ca_cnf_search.UseVisualStyleBackColor = true;
        // 
        // lbl_loc_cnf_ca
        // 
        lbl_loc_cnf_ca.AutoSize = true;
        lbl_loc_cnf_ca.Location = new Point(21, 28);
        lbl_loc_cnf_ca.Margin = new Padding(5, 0, 5, 0);
        lbl_loc_cnf_ca.Name = "lbl_loc_cnf_ca";
        lbl_loc_cnf_ca.Size = new Size(97, 30);
        lbl_loc_cnf_ca.TabIndex = 8;
        lbl_loc_cnf_ca.Text = "Location:";
        // 
        // tb_ca_cnf_path
        // 
        tb_ca_cnf_path.Location = new Point(125, 24);
        tb_ca_cnf_path.Margin = new Padding(5, 6, 5, 6);
        tb_ca_cnf_path.Name = "tb_ca_cnf_path";
        tb_ca_cnf_path.Size = new Size(556, 35);
        tb_ca_cnf_path.TabIndex = 7;
        // 
        // lb_server_certs
        // 
        lb_server_certs.FormattingEnabled = true;
        lb_server_certs.ItemHeight = 30;
        lb_server_certs.Location = new Point(21, 82);
        lb_server_certs.Margin = new Padding(3, 4, 3, 4);
        lb_server_certs.Name = "lb_server_certs";
        lb_server_certs.Size = new Size(210, 154);
        lb_server_certs.TabIndex = 14;
        // 
        // gb_private
        // 
        gb_private.Controls.Add(tb_priv_filename);
        gb_private.Controls.Add(tb_priv_passwd);
        gb_private.Controls.Add(tb_priv_bits);
        gb_private.Controls.Add(lb_priv_filename);
        gb_private.Controls.Add(lb_priv_pass);
        gb_private.Controls.Add(lb_priv_bits);
        gb_private.Location = new Point(21, 412);
        gb_private.Margin = new Padding(5, 6, 5, 6);
        gb_private.Name = "gb_private";
        gb_private.Padding = new Padding(5, 6, 5, 6);
        gb_private.Size = new Size(309, 238);
        gb_private.TabIndex = 15;
        gb_private.TabStop = false;
        gb_private.Text = "Private";
        // 
        // tb_priv_filename
        // 
        tb_priv_filename.Location = new Point(105, 166);
        tb_priv_filename.Margin = new Padding(5, 6, 5, 6);
        tb_priv_filename.Name = "tb_priv_filename";
        tb_priv_filename.Size = new Size(169, 35);
        tb_priv_filename.TabIndex = 5;
        // 
        // tb_priv_passwd
        // 
        tb_priv_passwd.Location = new Point(105, 106);
        tb_priv_passwd.Margin = new Padding(5, 6, 5, 6);
        tb_priv_passwd.Name = "tb_priv_passwd";
        tb_priv_passwd.Size = new Size(169, 35);
        tb_priv_passwd.TabIndex = 4;
        // 
        // tb_priv_bits
        // 
        tb_priv_bits.Location = new Point(105, 42);
        tb_priv_bits.Margin = new Padding(5, 6, 5, 6);
        tb_priv_bits.Name = "tb_priv_bits";
        tb_priv_bits.Size = new Size(169, 35);
        tb_priv_bits.TabIndex = 3;
        // 
        // lb_priv_filename
        // 
        lb_priv_filename.AutoSize = true;
        lb_priv_filename.Location = new Point(10, 172);
        lb_priv_filename.Margin = new Padding(5, 0, 5, 0);
        lb_priv_filename.Name = "lb_priv_filename";
        lb_priv_filename.Size = new Size(96, 30);
        lb_priv_filename.TabIndex = 2;
        lb_priv_filename.Text = "Filename";
        // 
        // lb_priv_pass
        // 
        lb_priv_pass.AutoSize = true;
        lb_priv_pass.Location = new Point(10, 112);
        lb_priv_pass.Margin = new Padding(5, 0, 5, 0);
        lb_priv_pass.Name = "lb_priv_pass";
        lb_priv_pass.Size = new Size(99, 30);
        lb_priv_pass.TabIndex = 1;
        lb_priv_pass.Text = "Password";
        // 
        // lb_priv_bits
        // 
        lb_priv_bits.AutoSize = true;
        lb_priv_bits.Location = new Point(60, 54);
        lb_priv_bits.Margin = new Padding(5, 0, 5, 0);
        lb_priv_bits.Name = "lb_priv_bits";
        lb_priv_bits.Size = new Size(46, 30);
        lb_priv_bits.TabIndex = 0;
        lb_priv_bits.Text = "Bits";
        // 
        // gb_public
        // 
        gb_public.Controls.Add(tb_pub_cnf);
        gb_public.Controls.Add(tb_pub_passwd);
        gb_public.Controls.Add(tb_pub_dura);
        gb_public.Controls.Add(lb_pub_conffile);
        gb_public.Controls.Add(lb_pub_passwd);
        gb_public.Controls.Add(lb_pub_duration);
        gb_public.Location = new Point(369, 412);
        gb_public.Margin = new Padding(5, 6, 5, 6);
        gb_public.Name = "gb_public";
        gb_public.Padding = new Padding(5, 6, 5, 6);
        gb_public.Size = new Size(326, 238);
        gb_public.TabIndex = 16;
        gb_public.TabStop = false;
        gb_public.Text = "Public";
        // 
        // tb_pub_cnf
        // 
        tb_pub_cnf.Location = new Point(125, 166);
        tb_pub_cnf.Margin = new Padding(5, 6, 5, 6);
        tb_pub_cnf.Name = "tb_pub_cnf";
        tb_pub_cnf.Size = new Size(169, 35);
        tb_pub_cnf.TabIndex = 6;
        // 
        // tb_pub_passwd
        // 
        tb_pub_passwd.Location = new Point(125, 108);
        tb_pub_passwd.Margin = new Padding(5, 6, 5, 6);
        tb_pub_passwd.Name = "tb_pub_passwd";
        tb_pub_passwd.Size = new Size(169, 35);
        tb_pub_passwd.TabIndex = 5;
        // 
        // tb_pub_dura
        // 
        tb_pub_dura.Location = new Point(125, 44);
        tb_pub_dura.Margin = new Padding(5, 6, 5, 6);
        tb_pub_dura.Name = "tb_pub_dura";
        tb_pub_dura.Size = new Size(169, 35);
        tb_pub_dura.TabIndex = 4;
        // 
        // lb_pub_conffile
        // 
        lb_pub_conffile.AutoSize = true;
        lb_pub_conffile.Location = new Point(48, 176);
        lb_pub_conffile.Margin = new Padding(5, 0, 5, 0);
        lb_pub_conffile.Name = "lb_pub_conffile";
        lb_pub_conffile.Size = new Size(74, 30);
        lb_pub_conffile.TabIndex = 2;
        lb_pub_conffile.Text = "Config";
        // 
        // lb_pub_passwd
        // 
        lb_pub_passwd.AutoSize = true;
        lb_pub_passwd.Location = new Point(31, 112);
        lb_pub_passwd.Margin = new Padding(5, 0, 5, 0);
        lb_pub_passwd.Name = "lb_pub_passwd";
        lb_pub_passwd.Size = new Size(99, 30);
        lb_pub_passwd.TabIndex = 1;
        lb_pub_passwd.Text = "Password";
        // 
        // lb_pub_duration
        // 
        lb_pub_duration.AutoSize = true;
        lb_pub_duration.Location = new Point(31, 54);
        lb_pub_duration.Margin = new Padding(5, 0, 5, 0);
        lb_pub_duration.Name = "lb_pub_duration";
        lb_pub_duration.Size = new Size(94, 30);
        lb_pub_duration.TabIndex = 0;
        lb_pub_duration.Text = "Duration";
        // 
        // cb_new_entry
        // 
        cb_new_entry.AutoSize = true;
        cb_new_entry.Location = new Point(262, 90);
        cb_new_entry.Margin = new Padding(5, 6, 5, 6);
        cb_new_entry.Name = "cb_new_entry";
        cb_new_entry.Size = new Size(144, 34);
        cb_new_entry.TabIndex = 17;
        cb_new_entry.Text = "New Server";
        cb_new_entry.UseVisualStyleBackColor = true;
        // 
        // rb_ca
        // 
        rb_ca.AutoSize = true;
        rb_ca.Location = new Point(9, 6);
        rb_ca.Margin = new Padding(5, 6, 5, 6);
        rb_ca.Name = "rb_ca";
        rb_ca.Size = new Size(65, 34);
        rb_ca.TabIndex = 18;
        rb_ca.TabStop = true;
        rb_ca.Text = "CA";
        rb_ca.UseVisualStyleBackColor = true;
        // 
        // rb_intermediate
        // 
        rb_intermediate.AutoSize = true;
        rb_intermediate.Location = new Point(5, 56);
        rb_intermediate.Margin = new Padding(5, 6, 5, 6);
        rb_intermediate.Name = "rb_intermediate";
        rb_intermediate.Size = new Size(156, 34);
        rb_intermediate.TabIndex = 19;
        rb_intermediate.TabStop = true;
        rb_intermediate.Text = "Intermediate";
        rb_intermediate.UseVisualStyleBackColor = true;
        // 
        // rb_server
        // 
        rb_server.AutoSize = true;
        rb_server.Location = new Point(5, 106);
        rb_server.Margin = new Padding(5, 6, 5, 6);
        rb_server.Name = "rb_server";
        rb_server.Size = new Size(95, 34);
        rb_server.TabIndex = 20;
        rb_server.TabStop = true;
        rb_server.Text = "Server";
        rb_server.UseVisualStyleBackColor = true;
        // 
        // panel1
        // 
        panel1.Controls.Add(rb_ca);
        panel1.Controls.Add(rb_server);
        panel1.Controls.Add(rb_intermediate);
        panel1.Location = new Point(929, 90);
        panel1.Margin = new Padding(5, 6, 5, 6);
        panel1.Name = "panel1";
        panel1.Size = new Size(161, 146);
        panel1.TabIndex = 21;
        // 
        // bt_add_server
        // 
        bt_add_server.Location = new Point(262, 134);
        bt_add_server.Margin = new Padding(5, 6, 5, 6);
        bt_add_server.Name = "bt_add_server";
        bt_add_server.Size = new Size(129, 46);
        bt_add_server.TabIndex = 22;
        bt_add_server.Text = "Add";
        bt_add_server.UseVisualStyleBackColor = true;
        bt_add_server.Click += bt_add_server_Click;
        // 
        // button1
        // 
        button1.Location = new Point(42, 688);
        button1.Name = "button1";
        button1.Size = new Size(131, 68);
        button1.TabIndex = 23;
        button1.Text = "Generate Private Key";
        button1.UseVisualStyleBackColor = true;
        // 
        // server
        // 
        AutoScaleDimensions = new SizeF(12F, 30F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1365, 856);
        Controls.Add(button1);
        Controls.Add(bt_add_server);
        Controls.Add(panel1);
        Controls.Add(cb_new_entry);
        Controls.Add(gb_public);
        Controls.Add(gb_private);
        Controls.Add(lb_server_certs);
        Controls.Add(bt_form2_close);
        Controls.Add(tb_ca_name);
        Controls.Add(gb_default_disti_names);
        Controls.Add(lbl_ca_name);
        Controls.Add(bt_ca_cnf_search);
        Controls.Add(lbl_loc_cnf_ca);
        Controls.Add(tb_ca_cnf_path);
        Margin = new Padding(3, 4, 3, 4);
        Name = "server";
        Text = "server";
        Load += server_onLoad;
        gb_default_disti_names.ResumeLayout(false);
        gb_default_disti_names.PerformLayout();
        gb_private.ResumeLayout(false);
        gb_private.PerformLayout();
        gb_public.ResumeLayout(false);
        gb_public.PerformLayout();
        panel1.ResumeLayout(false);
        panel1.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Button bt_form2_close;
    private TextBox tb_ca_name;
    private GroupBox gb_default_disti_names;
    private TextBox tb_sub_email;
    private TextBox tb_sub_cn;
    private TextBox textBox6;
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
    private Button bt_ca_cnf_search;
    private Label lbl_loc_cnf_ca;
    private TextBox tb_ca_cnf_path;
    private ListBox lb_server_certs;
    private GroupBox gb_private;
    private Label lb_priv_bits;
    private TextBox tb_priv_filename;
    private TextBox tb_priv_passwd;
    private TextBox tb_priv_bits;
    private Label lb_priv_filename;
    private Label lb_priv_pass;
    private GroupBox gb_public;
    private TextBox tb_pub_cnf;
    private TextBox tb_pub_passwd;
    private TextBox tb_pub_dura;
    private Label lb_pub_conffile;
    private Label lb_pub_passwd;
    private Label lb_pub_duration;
    private CheckBox cb_new_entry;
    private RadioButton rb_ca;
    private RadioButton rb_intermediate;
    private RadioButton rb_server;
    private Panel panel1;
    private Button bt_add_server;
    private Button button1;
}
