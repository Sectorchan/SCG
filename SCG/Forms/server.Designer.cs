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
        cb_priv_bits = new ComboBox();
        tb_priv_filename = new TextBox();
        tb_priv_passwd = new TextBox();
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
        cb_new_server = new CheckBox();
        rb_ca = new RadioButton();
        rb_intermediate = new RadioButton();
        rb_server = new RadioButton();
        panel1 = new Panel();
        rb_user = new RadioButton();
        Bt_gen_priv = new Button();
        saveFileDialog1 = new SaveFileDialog();
        bt_gen_pub_key = new Button();
        gb_default_disti_names.SuspendLayout();
        gb_private.SuspendLayout();
        gb_public.SuspendLayout();
        panel1.SuspendLayout();
        SuspendLayout();
        // 
        // bt_form2_close
        // 
        bt_form2_close.Location = new Point(656, 393);
        bt_form2_close.Name = "bt_form2_close";
        bt_form2_close.Size = new Size(128, 23);
        bt_form2_close.TabIndex = 13;
        bt_form2_close.Text = "save n close";
        bt_form2_close.UseVisualStyleBackColor = true;
        // 
        // tb_ca_name
        // 
        tb_ca_name.Location = new Point(95, 155);
        tb_ca_name.Name = "tb_ca_name";
        tb_ca_name.Size = new Size(100, 23);
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
        gb_default_disti_names.Location = new Point(448, 139);
        gb_default_disti_names.Name = "gb_default_disti_names";
        gb_default_disti_names.Size = new Size(229, 239);
        gb_default_disti_names.TabIndex = 11;
        gb_default_disti_names.TabStop = false;
        gb_default_disti_names.Text = "Default Distinguished Names";
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
        // textBox6
        // 
        textBox6.Location = new Point(113, 130);
        textBox6.Name = "textBox6";
        textBox6.Size = new Size(100, 23);
        textBox6.TabIndex = 11;
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
        // tb_sub_c
        // 
        tb_sub_c.Location = new Point(113, 30);
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
        lbl_def_organisationUnit.Location = new Point(69, 138);
        lbl_def_organisationUnit.Name = "lbl_def_organisationUnit";
        lbl_def_organisationUnit.Size = new Size(38, 15);
        lbl_def_organisationUnit.TabIndex = 4;
        lbl_def_organisationUnit.Text = "label5";
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
        lbl_ca_name.Location = new Point(12, 158);
        lbl_ca_name.Name = "lbl_ca_name";
        lbl_ca_name.Size = new Size(77, 15);
        lbl_ca_name.TabIndex = 10;
        lbl_ca_name.Text = "Server Name:";
        // 
        // bt_ca_cnf_search
        // 
        bt_ca_cnf_search.Location = new Point(405, 12);
        bt_ca_cnf_search.Name = "bt_ca_cnf_search";
        bt_ca_cnf_search.Size = new Size(75, 23);
        bt_ca_cnf_search.TabIndex = 9;
        bt_ca_cnf_search.Text = "search";
        bt_ca_cnf_search.UseVisualStyleBackColor = true;
        // 
        // lbl_loc_cnf_ca
        // 
        lbl_loc_cnf_ca.AutoSize = true;
        lbl_loc_cnf_ca.Location = new Point(12, 14);
        lbl_loc_cnf_ca.Name = "lbl_loc_cnf_ca";
        lbl_loc_cnf_ca.Size = new Size(56, 15);
        lbl_loc_cnf_ca.TabIndex = 8;
        lbl_loc_cnf_ca.Text = "Location:";
        // 
        // tb_ca_cnf_path
        // 
        tb_ca_cnf_path.Location = new Point(73, 12);
        tb_ca_cnf_path.Name = "tb_ca_cnf_path";
        tb_ca_cnf_path.Size = new Size(326, 23);
        tb_ca_cnf_path.TabIndex = 7;
        // 
        // lb_server_certs
        // 
        lb_server_certs.FormattingEnabled = true;
        lb_server_certs.ItemHeight = 15;
        lb_server_certs.Location = new Point(12, 41);
        lb_server_certs.Margin = new Padding(2, 2, 2, 2);
        lb_server_certs.Name = "lb_server_certs";
        lb_server_certs.Size = new Size(124, 79);
        lb_server_certs.TabIndex = 14;
        // 
        // gb_private
        // 
        gb_private.Controls.Add(cb_priv_bits);
        gb_private.Controls.Add(tb_priv_filename);
        gb_private.Controls.Add(tb_priv_passwd);
        gb_private.Controls.Add(lb_priv_filename);
        gb_private.Controls.Add(lb_priv_pass);
        gb_private.Controls.Add(lb_priv_bits);
        gb_private.Location = new Point(12, 206);
        gb_private.Name = "gb_private";
        gb_private.Size = new Size(180, 119);
        gb_private.TabIndex = 15;
        gb_private.TabStop = false;
        gb_private.Text = "Private";
        // 
        // cb_priv_bits
        // 
        cb_priv_bits.FormattingEnabled = true;
        cb_priv_bits.Items.AddRange(new object[] { "2048", "4096", "8192" });
        cb_priv_bits.Location = new Point(59, 22);
        cb_priv_bits.Name = "cb_priv_bits";
        cb_priv_bits.Size = new Size(102, 23);
        cb_priv_bits.TabIndex = 24;
        cb_priv_bits.Text = "4096";
        // 
        // tb_priv_filename
        // 
        tb_priv_filename.Location = new Point(61, 83);
        tb_priv_filename.Name = "tb_priv_filename";
        tb_priv_filename.Size = new Size(100, 23);
        tb_priv_filename.TabIndex = 5;
        // 
        // tb_priv_passwd
        // 
        tb_priv_passwd.Location = new Point(61, 53);
        tb_priv_passwd.Name = "tb_priv_passwd";
        tb_priv_passwd.Size = new Size(100, 23);
        tb_priv_passwd.TabIndex = 4;
        // 
        // lb_priv_filename
        // 
        lb_priv_filename.AutoSize = true;
        lb_priv_filename.Location = new Point(6, 86);
        lb_priv_filename.Name = "lb_priv_filename";
        lb_priv_filename.Size = new Size(55, 15);
        lb_priv_filename.TabIndex = 2;
        lb_priv_filename.Text = "Filename";
        // 
        // lb_priv_pass
        // 
        lb_priv_pass.AutoSize = true;
        lb_priv_pass.Location = new Point(6, 56);
        lb_priv_pass.Name = "lb_priv_pass";
        lb_priv_pass.Size = new Size(57, 15);
        lb_priv_pass.TabIndex = 1;
        lb_priv_pass.Text = "Password";
        // 
        // lb_priv_bits
        // 
        lb_priv_bits.AutoSize = true;
        lb_priv_bits.Location = new Point(35, 27);
        lb_priv_bits.Name = "lb_priv_bits";
        lb_priv_bits.Size = new Size(26, 15);
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
        gb_public.Location = new Point(215, 206);
        gb_public.Name = "gb_public";
        gb_public.Size = new Size(190, 119);
        gb_public.TabIndex = 16;
        gb_public.TabStop = false;
        gb_public.Text = "Public";
        // 
        // tb_pub_cnf
        // 
        tb_pub_cnf.Location = new Point(73, 83);
        tb_pub_cnf.Name = "tb_pub_cnf";
        tb_pub_cnf.Size = new Size(100, 23);
        tb_pub_cnf.TabIndex = 6;
        // 
        // tb_pub_passwd
        // 
        tb_pub_passwd.Location = new Point(73, 54);
        tb_pub_passwd.Name = "tb_pub_passwd";
        tb_pub_passwd.Size = new Size(100, 23);
        tb_pub_passwd.TabIndex = 5;
        // 
        // tb_pub_dura
        // 
        tb_pub_dura.Location = new Point(73, 22);
        tb_pub_dura.Name = "tb_pub_dura";
        tb_pub_dura.Size = new Size(100, 23);
        tb_pub_dura.TabIndex = 4;
        // 
        // lb_pub_conffile
        // 
        lb_pub_conffile.AutoSize = true;
        lb_pub_conffile.Location = new Point(28, 88);
        lb_pub_conffile.Name = "lb_pub_conffile";
        lb_pub_conffile.Size = new Size(43, 15);
        lb_pub_conffile.TabIndex = 2;
        lb_pub_conffile.Text = "Config";
        // 
        // lb_pub_passwd
        // 
        lb_pub_passwd.AutoSize = true;
        lb_pub_passwd.Location = new Point(18, 56);
        lb_pub_passwd.Name = "lb_pub_passwd";
        lb_pub_passwd.Size = new Size(57, 15);
        lb_pub_passwd.TabIndex = 1;
        lb_pub_passwd.Text = "Password";
        // 
        // lb_pub_duration
        // 
        lb_pub_duration.AutoSize = true;
        lb_pub_duration.Location = new Point(18, 27);
        lb_pub_duration.Name = "lb_pub_duration";
        lb_pub_duration.Size = new Size(53, 15);
        lb_pub_duration.TabIndex = 0;
        lb_pub_duration.Text = "Duration";
        // 
        // cb_new_server
        // 
        cb_new_server.AutoSize = true;
        cb_new_server.Location = new Point(153, 45);
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
        // 
        // panel1
        // 
        panel1.Controls.Add(rb_user);
        panel1.Controls.Add(rb_ca);
        panel1.Controls.Add(rb_server);
        panel1.Controls.Add(rb_intermediate);
        panel1.Location = new Point(215, 96);
        panel1.Name = "panel1";
        panel1.Size = new Size(94, 113);
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
        // 
        // Bt_gen_priv
        // 
        Bt_gen_priv.Location = new Point(24, 344);
        Bt_gen_priv.Margin = new Padding(2, 2, 2, 2);
        Bt_gen_priv.Name = "Bt_gen_priv";
        Bt_gen_priv.Size = new Size(76, 47);
        Bt_gen_priv.TabIndex = 23;
        Bt_gen_priv.Text = "Generate Private Key";
        Bt_gen_priv.UseVisualStyleBackColor = true;
        Bt_gen_priv.Click += Bt_gen_priv_onClick;
        // 
        // bt_gen_pub_key
        // 
        bt_gen_pub_key.Location = new Point(264, 344);
        bt_gen_pub_key.Name = "bt_gen_pub_key";
        bt_gen_pub_key.Size = new Size(75, 47);
        bt_gen_pub_key.TabIndex = 24;
        bt_gen_pub_key.Text = "Generate Public Key";
        bt_gen_pub_key.UseVisualStyleBackColor = true;
        bt_gen_pub_key.Click += bt_gen_pub_key_Click;
        // 
        // Server
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(796, 428);
        Controls.Add(bt_gen_pub_key);
        Controls.Add(Bt_gen_priv);
        Controls.Add(panel1);
        Controls.Add(cb_new_server);
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
        Margin = new Padding(2, 2, 2, 2);
        Name = "Server";
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
    private Label lb_priv_filename;
    private Label lb_priv_pass;
    private GroupBox gb_public;
    private TextBox tb_pub_cnf;
    private TextBox tb_pub_passwd;
    private TextBox tb_pub_dura;
    private Label lb_pub_conffile;
    private Label lb_pub_passwd;
    private Label lb_pub_duration;
    private CheckBox cb_new_server;
    private RadioButton rb_ca;
    private RadioButton rb_intermediate;
    private RadioButton rb_server;
    private Panel panel1;
    private Button Bt_gen_priv;
    private ComboBox cb_priv_bits;
    private RadioButton rb_user;
    private SaveFileDialog saveFileDialog1;
    private Button bt_gen_pub_key;
}
