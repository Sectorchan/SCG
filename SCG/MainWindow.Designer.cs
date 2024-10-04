namespace WinFormsApp1
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            GroupBox gB_intermediate;
            bt_inter_sign_ca_name = new Button();
            xx = new Label();
            tb_inter_sign_ca_name = new TextBox();
            cb_inter_sign = new CheckBox();
            tb_inter_cert_days = new TextBox();
            lbl_inter_cert_days = new Label();
            tb_inter_sign_ca_key_in = new TextBox();
            bt_inter_csr_gen = new Button();
            bt_inter_key_gen = new Button();
            tb_inter_key_pw2 = new TextBox();
            tb_inter_key_pw1 = new TextBox();
            tb_inter_priv_name = new TextBox();
            tb_inter_cert_name = new TextBox();
            label8 = new Label();
            label9 = new Label();
            tb_appl_csr_name = new TextBox();
            bt_ca_key_gen = new Button();
            tb_ca_priv_name = new TextBox();
            label1 = new Label();
            menuStrip1 = new MenuStrip();
            mainToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripMenuItem();
            toolStripMenuItem3 = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            opensslCnfCa = new ToolStripMenuItem();
            opensslCnfInt = new ToolStripMenuItem();
            copyToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem5 = new ToolStripMenuItem();
            toolStripMenuItem7 = new ToolStripMenuItem();
            tb_ca_key_pw1 = new TextBox();
            tb_ca_key_pw2 = new TextBox();
            label2 = new Label();
            tb_ca_cert_name = new TextBox();
            tb_ca_cert_days = new TextBox();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            lbl_ca_cert_days = new Label();
            bt_ca_cert_gen = new Button();
            tb_ca_key_pw_in = new TextBox();
            label7 = new Label();
            gB_Ca = new GroupBox();
            Concantinate = new GroupBox();
            bt_cat_gen = new Button();
            tb_cat_res_name = new TextBox();
            lbl_cat_out_name = new Label();
            lbl_cat_inter_name = new Label();
            lbl_cat_ca_name = new Label();
            tb_cat_inter_name = new TextBox();
            tb_cat_ca_name = new TextBox();
            tb_debugoutput = new TextBox();
            gb_application = new GroupBox();
            tb_appl_sign_inter_name = new TextBox();
            label11 = new Label();
            tb_appl_cert_days = new TextBox();
            lbl_appl_cert_days = new Label();
            tb_appl_key_pw_in = new TextBox();
            bt_appl_sign_inter_name = new Button();
            cb_appl_sign = new CheckBox();
            bt_appl_csr_gen = new Button();
            bt_appl_priv_gen2 = new Button();
            tb_appl_key_pw2 = new TextBox();
            tb_appl_priv_name = new TextBox();
            tb_appl_key_pw1 = new TextBox();
            label10 = new Label();
            label6 = new Label();
            pageSetupDialog1 = new PageSetupDialog();
            gB_intermediate = new GroupBox();
            gB_intermediate.SuspendLayout();
            menuStrip1.SuspendLayout();
            gB_Ca.SuspendLayout();
            Concantinate.SuspendLayout();
            gb_application.SuspendLayout();
            SuspendLayout();
            // 
            // gB_intermediate
            // 
            gB_intermediate.Controls.Add(bt_inter_sign_ca_name);
            gB_intermediate.Controls.Add(xx);
            gB_intermediate.Controls.Add(tb_inter_sign_ca_name);
            gB_intermediate.Controls.Add(cb_inter_sign);
            gB_intermediate.Controls.Add(tb_inter_cert_days);
            gB_intermediate.Controls.Add(lbl_inter_cert_days);
            gB_intermediate.Controls.Add(tb_inter_sign_ca_key_in);
            gB_intermediate.Controls.Add(bt_inter_csr_gen);
            gB_intermediate.Controls.Add(bt_inter_key_gen);
            gB_intermediate.Controls.Add(tb_inter_key_pw2);
            gB_intermediate.Controls.Add(tb_inter_key_pw1);
            gB_intermediate.Controls.Add(tb_inter_priv_name);
            gB_intermediate.Controls.Add(tb_inter_cert_name);
            gB_intermediate.Controls.Add(label8);
            gB_intermediate.Controls.Add(label9);
            gB_intermediate.Location = new Point(12, 158);
            gB_intermediate.Name = "gB_intermediate";
            gB_intermediate.Size = new Size(705, 118);
            gB_intermediate.TabIndex = 19;
            gB_intermediate.TabStop = false;
            gB_intermediate.Text = "Intermediate";
            // 
            // bt_inter_sign_ca_name
            // 
            bt_inter_sign_ca_name.Enabled = false;
            bt_inter_sign_ca_name.Location = new Point(630, 77);
            bt_inter_sign_ca_name.Name = "bt_inter_sign_ca_name";
            bt_inter_sign_ca_name.Size = new Size(75, 23);
            bt_inter_sign_ca_name.TabIndex = 29;
            bt_inter_sign_ca_name.Text = "Generate";
            bt_inter_sign_ca_name.UseVisualStyleBackColor = true;
            bt_inter_sign_ca_name.Click += bt_inter_sign_ca_name_Click;
            // 
            // xx
            // 
            xx.AutoSize = true;
            xx.Location = new Point(434, 76);
            xx.Name = "xx";
            xx.Size = new Size(69, 15);
            xx.TabIndex = 28;
            xx.Text = "Against CA:";
            // 
            // tb_inter_sign_ca_name
            // 
            tb_inter_sign_ca_name.Location = new Point(509, 73);
            tb_inter_sign_ca_name.Name = "tb_inter_sign_ca_name";
            tb_inter_sign_ca_name.Size = new Size(100, 23);
            tb_inter_sign_ca_name.TabIndex = 27;
            tb_inter_sign_ca_name.Text = "ca";
            // 
            // cb_inter_sign
            // 
            cb_inter_sign.AutoSize = true;
            cb_inter_sign.Location = new Point(54, 75);
            cb_inter_sign.Name = "cb_inter_sign";
            cb_inter_sign.Size = new Size(119, 19);
            cb_inter_sign.TabIndex = 26;
            cb_inter_sign.Text = "Sign Intermediate";
            cb_inter_sign.UseVisualStyleBackColor = true;
            cb_inter_sign.CheckStateChanged += cb_inter_sign_CheckStateChanged;
            // 
            // tb_inter_cert_days
            // 
            tb_inter_cert_days.Location = new Point(378, 76);
            tb_inter_cert_days.Name = "tb_inter_cert_days";
            tb_inter_cert_days.Size = new Size(50, 23);
            tb_inter_cert_days.TabIndex = 25;
            tb_inter_cert_days.Text = "3650";
            // 
            // lbl_inter_cert_days
            // 
            lbl_inter_cert_days.AutoSize = true;
            lbl_inter_cert_days.Location = new Point(331, 79);
            lbl_inter_cert_days.Name = "lbl_inter_cert_days";
            lbl_inter_cert_days.Size = new Size(56, 15);
            lbl_inter_cert_days.TabIndex = 18;
            lbl_inter_cert_days.Text = "Duration:";
            // 
            // tb_inter_sign_ca_key_in
            // 
            tb_inter_sign_ca_key_in.Location = new Point(175, 75);
            tb_inter_sign_ca_key_in.Name = "tb_inter_sign_ca_key_in";
            tb_inter_sign_ca_key_in.Size = new Size(100, 23);
            tb_inter_sign_ca_key_in.TabIndex = 24;
            tb_inter_sign_ca_key_in.Text = "test";
            // 
            // bt_inter_csr_gen
            // 
            bt_inter_csr_gen.Location = new Point(630, 46);
            bt_inter_csr_gen.Name = "bt_inter_csr_gen";
            bt_inter_csr_gen.Size = new Size(75, 23);
            bt_inter_csr_gen.TabIndex = 23;
            bt_inter_csr_gen.Text = "Generate";
            bt_inter_csr_gen.UseVisualStyleBackColor = true;
            bt_inter_csr_gen.Click += bt_inter_csr_gen_Click;
            // 
            // bt_inter_key_gen
            // 
            bt_inter_key_gen.Location = new Point(630, 16);
            bt_inter_key_gen.Name = "bt_inter_key_gen";
            bt_inter_key_gen.Size = new Size(75, 23);
            bt_inter_key_gen.TabIndex = 22;
            bt_inter_key_gen.Text = "Generate";
            bt_inter_key_gen.UseVisualStyleBackColor = true;
            bt_inter_key_gen.Click += bt_inter_key_gen_Click;
            // 
            // tb_inter_key_pw2
            // 
            tb_inter_key_pw2.Location = new Point(392, 17);
            tb_inter_key_pw2.Name = "tb_inter_key_pw2";
            tb_inter_key_pw2.Size = new Size(209, 23);
            tb_inter_key_pw2.TabIndex = 21;
            tb_inter_key_pw2.Text = "test2";
            // 
            // tb_inter_key_pw1
            // 
            tb_inter_key_pw1.Location = new Point(177, 17);
            tb_inter_key_pw1.Name = "tb_inter_key_pw1";
            tb_inter_key_pw1.Size = new Size(209, 23);
            tb_inter_key_pw1.TabIndex = 20;
            tb_inter_key_pw1.Text = "test2";
            // 
            // tb_inter_priv_name
            // 
            tb_inter_priv_name.Location = new Point(54, 17);
            tb_inter_priv_name.Name = "tb_inter_priv_name";
            tb_inter_priv_name.Size = new Size(100, 23);
            tb_inter_priv_name.TabIndex = 18;
            tb_inter_priv_name.Text = "int";
            // 
            // tb_inter_cert_name
            // 
            tb_inter_cert_name.Location = new Point(54, 43);
            tb_inter_cert_name.Name = "tb_inter_cert_name";
            tb_inter_cert_name.Size = new Size(100, 23);
            tb_inter_cert_name.TabIndex = 19;
            tb_inter_cert_name.Text = "int";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(6, 20);
            label8.Name = "label8";
            label8.Size = new Size(29, 15);
            label8.TabIndex = 18;
            label8.Text = "Key:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(6, 46);
            label9.Name = "label9";
            label9.Size = new Size(28, 15);
            label9.TabIndex = 19;
            label9.Text = "CSR";
            // 
            // tb_appl_csr_name
            // 
            tb_appl_csr_name.Location = new Point(44, 45);
            tb_appl_csr_name.Name = "tb_appl_csr_name";
            tb_appl_csr_name.Size = new Size(100, 23);
            tb_appl_csr_name.TabIndex = 22;
            tb_appl_csr_name.Text = "grafana";
            // 
            // bt_ca_key_gen
            // 
            bt_ca_key_gen.Location = new Point(630, 15);
            bt_ca_key_gen.Name = "bt_ca_key_gen";
            bt_ca_key_gen.Size = new Size(75, 23);
            bt_ca_key_gen.TabIndex = 0;
            bt_ca_key_gen.Text = "Generate";
            bt_ca_key_gen.UseVisualStyleBackColor = true;
            bt_ca_key_gen.Click += ca_priv_key_gen_click;
            // 
            // tb_ca_priv_name
            // 
            tb_ca_priv_name.Location = new Point(54, 16);
            tb_ca_priv_name.Name = "tb_ca_priv_name";
            tb_ca_priv_name.Size = new Size(100, 23);
            tb_ca_priv_name.TabIndex = 1;
            tb_ca_priv_name.Text = "ca";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 19);
            label1.Name = "label1";
            label1.Size = new Size(29, 15);
            label1.TabIndex = 2;
            label1.Text = "Key:";
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { mainToolStripMenuItem, editToolStripMenuItem, copyToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 5;
            menuStrip1.Text = "menuStrip1";
            // 
            // mainToolStripMenuItem
            // 
            mainToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem2, toolStripMenuItem3 });
            mainToolStripMenuItem.Name = "mainToolStripMenuItem";
            mainToolStripMenuItem.Size = new Size(46, 20);
            mainToolStripMenuItem.Text = "Main";
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(86, 22);
            toolStripMenuItem2.Text = "1";
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new Size(86, 22);
            toolStripMenuItem3.Text = "22";
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { opensslCnfCa, opensslCnfInt });
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(86, 20);
            editToolStripMenuItem.Text = "configssl.cnf";
            // 
            // opensslCnfCa
            // 
            opensslCnfCa.Name = "opensslCnfCa";
            opensslCnfCa.Size = new Size(180, 22);
            opensslCnfCa.Text = "CA";
            opensslCnfCa.Click += opensslCnfCa_click;
            // 
            // opensslCnfInt
            // 
            opensslCnfInt.Name = "opensslCnfInt";
            opensslCnfInt.Size = new Size(180, 22);
            opensslCnfInt.Text = "Intermediate";
            opensslCnfInt.Click += opensslCnfInt_click;
            // 
            // copyToolStripMenuItem
            // 
            copyToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem5, toolStripMenuItem7 });
            copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            copyToolStripMenuItem.Size = new Size(47, 20);
            copyToolStripMenuItem.Text = "Copy";
            // 
            // toolStripMenuItem5
            // 
            toolStripMenuItem5.Name = "toolStripMenuItem5";
            toolStripMenuItem5.Size = new Size(116, 22);
            toolStripMenuItem5.Text = "4";
            // 
            // toolStripMenuItem7
            // 
            toolStripMenuItem7.Name = "toolStripMenuItem7";
            toolStripMenuItem7.Size = new Size(116, 22);
            toolStripMenuItem7.Text = "6666666";
            // 
            // tb_ca_key_pw1
            // 
            tb_ca_key_pw1.Location = new Point(172, 16);
            tb_ca_key_pw1.Name = "tb_ca_key_pw1";
            tb_ca_key_pw1.Size = new Size(209, 23);
            tb_ca_key_pw1.TabIndex = 6;
            tb_ca_key_pw1.Text = "test";
            // 
            // tb_ca_key_pw2
            // 
            tb_ca_key_pw2.Location = new Point(392, 16);
            tb_ca_key_pw2.Name = "tb_ca_key_pw2";
            tb_ca_key_pw2.Size = new Size(217, 23);
            tb_ca_key_pw2.TabIndex = 7;
            tb_ca_key_pw2.Text = "test";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 45);
            label2.Name = "label2";
            label2.Size = new Size(32, 15);
            label2.TabIndex = 8;
            label2.Text = "Cert:";
            // 
            // tb_ca_cert_name
            // 
            tb_ca_cert_name.Location = new Point(54, 42);
            tb_ca_cert_name.Name = "tb_ca_cert_name";
            tb_ca_cert_name.Size = new Size(100, 23);
            tb_ca_cert_name.TabIndex = 9;
            tb_ca_cert_name.Text = "ca";
            // 
            // tb_ca_cert_days
            // 
            tb_ca_cert_days.Location = new Point(331, 45);
            tb_ca_cert_days.Name = "tb_ca_cert_days";
            tb_ca_cert_days.Size = new Size(158, 23);
            tb_ca_cert_days.TabIndex = 10;
            tb_ca_cert_days.Text = "7300";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(78, 34);
            label3.Name = "label3";
            label3.Size = new Size(39, 15);
            label3.TabIndex = 11;
            label3.Text = "Name";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(182, 28);
            label4.Name = "label4";
            label4.Size = new Size(54, 15);
            label4.TabIndex = 12;
            label4.Text = "Passwort";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(404, 27);
            label5.Name = "label5";
            label5.Size = new Size(112, 15);
            label5.TabIndex = 13;
            label5.Text = "Passwort Bestätigen";
            // 
            // lbl_ca_cert_days
            // 
            lbl_ca_cert_days.AutoSize = true;
            lbl_ca_cert_days.Location = new Point(294, 48);
            lbl_ca_cert_days.Name = "lbl_ca_cert_days";
            lbl_ca_cert_days.Size = new Size(31, 15);
            lbl_ca_cert_days.TabIndex = 14;
            lbl_ca_cert_days.Text = "Tage";
            // 
            // bt_ca_cert_gen
            // 
            bt_ca_cert_gen.Location = new Point(630, 45);
            bt_ca_cert_gen.Name = "bt_ca_cert_gen";
            bt_ca_cert_gen.Size = new Size(75, 23);
            bt_ca_cert_gen.TabIndex = 15;
            bt_ca_cert_gen.Text = "Generate";
            bt_ca_cert_gen.UseVisualStyleBackColor = true;
            bt_ca_cert_gen.Click += ca_cert_key_gen_Click;
            // 
            // tb_ca_key_pw_in
            // 
            tb_ca_key_pw_in.Location = new Point(172, 45);
            tb_ca_key_pw_in.Name = "tb_ca_key_pw_in";
            tb_ca_key_pw_in.Size = new Size(100, 23);
            tb_ca_key_pw_in.TabIndex = 16;
            tb_ca_key_pw_in.Text = "test";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(172, 82);
            label7.Name = "label7";
            label7.Size = new Size(54, 15);
            label7.TabIndex = 17;
            label7.Text = "Passwort";
            // 
            // gB_Ca
            // 
            gB_Ca.Controls.Add(label1);
            gB_Ca.Controls.Add(label2);
            gB_Ca.Controls.Add(label7);
            gB_Ca.Controls.Add(tb_ca_priv_name);
            gB_Ca.Controls.Add(bt_ca_cert_gen);
            gB_Ca.Controls.Add(tb_ca_key_pw_in);
            gB_Ca.Controls.Add(bt_ca_key_gen);
            gB_Ca.Controls.Add(lbl_ca_cert_days);
            gB_Ca.Controls.Add(tb_ca_cert_name);
            gB_Ca.Controls.Add(tb_ca_cert_days);
            gB_Ca.Controls.Add(tb_ca_key_pw1);
            gB_Ca.Controls.Add(tb_ca_key_pw2);
            gB_Ca.Location = new Point(12, 52);
            gB_Ca.Name = "gB_Ca";
            gB_Ca.Size = new Size(711, 100);
            gB_Ca.TabIndex = 18;
            gB_Ca.TabStop = false;
            gB_Ca.Text = "CA";
            // 
            // Concantinate
            // 
            Concantinate.Controls.Add(bt_cat_gen);
            Concantinate.Controls.Add(tb_cat_res_name);
            Concantinate.Controls.Add(lbl_cat_out_name);
            Concantinate.Controls.Add(lbl_cat_inter_name);
            Concantinate.Controls.Add(lbl_cat_ca_name);
            Concantinate.Controls.Add(tb_cat_inter_name);
            Concantinate.Controls.Add(tb_cat_ca_name);
            Concantinate.Location = new Point(12, 282);
            Concantinate.Name = "Concantinate";
            Concantinate.Size = new Size(705, 104);
            Concantinate.TabIndex = 20;
            Concantinate.TabStop = false;
            Concantinate.Text = "Concat CA with Intemediate";
            // 
            // bt_cat_gen
            // 
            bt_cat_gen.BackColor = Color.Red;
            bt_cat_gen.Enabled = false;
            bt_cat_gen.Location = new Point(502, 28);
            bt_cat_gen.Name = "bt_cat_gen";
            bt_cat_gen.Size = new Size(75, 23);
            bt_cat_gen.TabIndex = 6;
            bt_cat_gen.Text = "Concatinate";
            bt_cat_gen.UseVisualStyleBackColor = false;
            // 
            // tb_cat_res_name
            // 
            tb_cat_res_name.Location = new Point(382, 29);
            tb_cat_res_name.Name = "tb_cat_res_name";
            tb_cat_res_name.Size = new Size(100, 23);
            tb_cat_res_name.TabIndex = 5;
            // 
            // lbl_cat_out_name
            // 
            lbl_cat_out_name.AutoSize = true;
            lbl_cat_out_name.Location = new Point(331, 29);
            lbl_cat_out_name.Name = "lbl_cat_out_name";
            lbl_cat_out_name.Size = new Size(45, 15);
            lbl_cat_out_name.TabIndex = 4;
            lbl_cat_out_name.Text = "Output";
            // 
            // lbl_cat_inter_name
            // 
            lbl_cat_inter_name.AutoSize = true;
            lbl_cat_inter_name.Location = new Point(141, 29);
            lbl_cat_inter_name.Name = "lbl_cat_inter_name";
            lbl_cat_inter_name.Size = new Size(70, 15);
            lbl_cat_inter_name.TabIndex = 3;
            lbl_cat_inter_name.Text = "Intemediate";
            // 
            // lbl_cat_ca_name
            // 
            lbl_cat_ca_name.AutoSize = true;
            lbl_cat_ca_name.Location = new Point(6, 29);
            lbl_cat_ca_name.Name = "lbl_cat_ca_name";
            lbl_cat_ca_name.Size = new Size(23, 15);
            lbl_cat_ca_name.TabIndex = 2;
            lbl_cat_ca_name.Text = "CA";
            // 
            // tb_cat_inter_name
            // 
            tb_cat_inter_name.Location = new Point(217, 26);
            tb_cat_inter_name.Name = "tb_cat_inter_name";
            tb_cat_inter_name.Size = new Size(100, 23);
            tb_cat_inter_name.TabIndex = 1;
            // 
            // tb_cat_ca_name
            // 
            tb_cat_ca_name.Location = new Point(35, 26);
            tb_cat_ca_name.Name = "tb_cat_ca_name";
            tb_cat_ca_name.Size = new Size(100, 23);
            tb_cat_ca_name.TabIndex = 0;
            // 
            // tb_debugoutput
            // 
            tb_debugoutput.ImeMode = ImeMode.NoControl;
            tb_debugoutput.Location = new Point(75, 536);
            tb_debugoutput.MaxLength = 2000000000;
            tb_debugoutput.Multiline = true;
            tb_debugoutput.Name = "tb_debugoutput";
            tb_debugoutput.Size = new Size(630, 55);
            tb_debugoutput.TabIndex = 21;
            tb_debugoutput.UseWaitCursor = true;
            // 
            // gb_application
            // 
            gb_application.Controls.Add(tb_appl_sign_inter_name);
            gb_application.Controls.Add(label11);
            gb_application.Controls.Add(tb_appl_cert_days);
            gb_application.Controls.Add(lbl_appl_cert_days);
            gb_application.Controls.Add(tb_appl_key_pw_in);
            gb_application.Controls.Add(bt_appl_sign_inter_name);
            gb_application.Controls.Add(cb_appl_sign);
            gb_application.Controls.Add(bt_appl_csr_gen);
            gb_application.Controls.Add(bt_appl_priv_gen2);
            gb_application.Controls.Add(tb_appl_key_pw2);
            gb_application.Controls.Add(tb_appl_priv_name);
            gb_application.Controls.Add(tb_appl_key_pw1);
            gb_application.Controls.Add(tb_appl_csr_name);
            gb_application.Controls.Add(label10);
            gb_application.Controls.Add(label6);
            gb_application.Location = new Point(11, 393);
            gb_application.Name = "gb_application";
            gb_application.Size = new Size(711, 138);
            gb_application.TabIndex = 22;
            gb_application.TabStop = false;
            // 
            // tb_appl_sign_inter_name
            // 
            tb_appl_sign_inter_name.Location = new Point(488, 87);
            tb_appl_sign_inter_name.Name = "tb_appl_sign_inter_name";
            tb_appl_sign_inter_name.Size = new Size(100, 23);
            tb_appl_sign_inter_name.TabIndex = 40;
            tb_appl_sign_inter_name.Text = "int";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(408, 90);
            label11.Name = "label11";
            label11.Size = new Size(74, 15);
            label11.TabIndex = 39;
            label11.Text = "Against Inter";
            // 
            // tb_appl_cert_days
            // 
            tb_appl_cert_days.Location = new Point(341, 88);
            tb_appl_cert_days.Name = "tb_appl_cert_days";
            tb_appl_cert_days.Size = new Size(56, 23);
            tb_appl_cert_days.TabIndex = 38;
            tb_appl_cert_days.Text = "365";
            // 
            // lbl_appl_cert_days
            // 
            lbl_appl_cert_days.AutoSize = true;
            lbl_appl_cert_days.Location = new Point(279, 92);
            lbl_appl_cert_days.Name = "lbl_appl_cert_days";
            lbl_appl_cert_days.Size = new Size(56, 15);
            lbl_appl_cert_days.TabIndex = 37;
            lbl_appl_cert_days.Text = "Duration:";
            // 
            // tb_appl_key_pw_in
            // 
            tb_appl_key_pw_in.Location = new Point(163, 92);
            tb_appl_key_pw_in.Name = "tb_appl_key_pw_in";
            tb_appl_key_pw_in.Size = new Size(100, 23);
            tb_appl_key_pw_in.TabIndex = 36;
            tb_appl_key_pw_in.Text = "test2";
            // 
            // bt_appl_sign_inter_name
            // 
            bt_appl_sign_inter_name.Location = new Point(618, 90);
            bt_appl_sign_inter_name.Name = "bt_appl_sign_inter_name";
            bt_appl_sign_inter_name.Size = new Size(75, 23);
            bt_appl_sign_inter_name.TabIndex = 35;
            bt_appl_sign_inter_name.Text = "Generate";
            bt_appl_sign_inter_name.UseVisualStyleBackColor = true;
            bt_appl_sign_inter_name.Click += bt_appl_sign_inter_name_Click;
            // 
            // cb_appl_sign
            // 
            cb_appl_sign.AutoSize = true;
            cb_appl_sign.Location = new Point(44, 94);
            cb_appl_sign.Name = "cb_appl_sign";
            cb_appl_sign.Size = new Size(113, 19);
            cb_appl_sign.TabIndex = 34;
            cb_appl_sign.Text = "Sign Application";
            cb_appl_sign.UseVisualStyleBackColor = true;
            // 
            // bt_appl_csr_gen
            // 
            bt_appl_csr_gen.Location = new Point(618, 51);
            bt_appl_csr_gen.Name = "bt_appl_csr_gen";
            bt_appl_csr_gen.Size = new Size(75, 23);
            bt_appl_csr_gen.TabIndex = 33;
            bt_appl_csr_gen.Text = "Generate";
            bt_appl_csr_gen.UseVisualStyleBackColor = true;
            bt_appl_csr_gen.Click += bt_appl_csr_gen_click;
            // 
            // bt_appl_priv_gen2
            // 
            bt_appl_priv_gen2.Location = new Point(618, 22);
            bt_appl_priv_gen2.Name = "bt_appl_priv_gen2";
            bt_appl_priv_gen2.Size = new Size(75, 23);
            bt_appl_priv_gen2.TabIndex = 32;
            bt_appl_priv_gen2.Text = "Generate";
            bt_appl_priv_gen2.UseVisualStyleBackColor = true;
            bt_appl_priv_gen2.Click += bt_appl_priv_gen_click;
            // 
            // tb_appl_key_pw2
            // 
            tb_appl_key_pw2.Location = new Point(368, 19);
            tb_appl_key_pw2.Name = "tb_appl_key_pw2";
            tb_appl_key_pw2.Size = new Size(209, 23);
            tb_appl_key_pw2.TabIndex = 31;
            tb_appl_key_pw2.Text = "test3";
            // 
            // tb_appl_priv_name
            // 
            tb_appl_priv_name.Location = new Point(44, 19);
            tb_appl_priv_name.Name = "tb_appl_priv_name";
            tb_appl_priv_name.Size = new Size(100, 23);
            tb_appl_priv_name.TabIndex = 21;
            tb_appl_priv_name.Text = "grafana";
            // 
            // tb_appl_key_pw1
            // 
            tb_appl_key_pw1.Location = new Point(153, 19);
            tb_appl_key_pw1.Name = "tb_appl_key_pw1";
            tb_appl_key_pw1.Size = new Size(209, 23);
            tb_appl_key_pw1.TabIndex = 30;
            tb_appl_key_pw1.Text = "test3";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(10, 46);
            label10.Name = "label10";
            label10.Size = new Size(28, 15);
            label10.TabIndex = 20;
            label10.Text = "CSR";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(9, 19);
            label6.Name = "label6";
            label6.Size = new Size(29, 15);
            label6.TabIndex = 19;
            label6.Text = "Key:";
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 658);
            Controls.Add(gb_application);
            Controls.Add(tb_debugoutput);
            Controls.Add(Concantinate);
            Controls.Add(gB_intermediate);
            Controls.Add(label3);
            Controls.Add(gB_Ca);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainWindow";
            Text = "Form1";
            gB_intermediate.ResumeLayout(false);
            gB_intermediate.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            gB_Ca.ResumeLayout(false);
            gB_Ca.PerformLayout();
            Concantinate.ResumeLayout(false);
            Concantinate.PerformLayout();
            gb_application.ResumeLayout(false);
            gb_application.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button bt_ca_key_gen;
        private TextBox tb_ca_priv_name;
        private Label label1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem mainToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem copyToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripMenuItem opensslCnfCa;
        private ToolStripMenuItem opensslCnfInt;
        private ToolStripMenuItem toolStripMenuItem5;
        private ToolStripMenuItem toolStripMenuItem7;
        private TextBox tb_ca_key_pw1;
        private TextBox tb_ca_key_pw2;
        private Label label2;
        private TextBox tb_ca_cert_name;
        private TextBox tb_ca_cert_days;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label lbl_ca_cert_days;
        private Button bt_ca_cert_gen;
        private TextBox tb_ca_key_pw_in;
        private Label label7;
        private GroupBox gB_Ca;
        private TextBox tb_inter_priv_name;
        private Label label8;
        private Label label9;
        private TextBox tb_inter_key_pw1;
        private TextBox tb_inter_key_pw2;
        private Button bt_inter_key_gen;
        private TextBox tb_inter_cert_days;
        private Label lbl_inter_cert_days;
        private TextBox tb_inter_sign_ca_key_in;
        private Button bt_inter_csr_gen;
        private GroupBox Concantinate;
        private Label lbl_cat_inter_name;
        private Label lbl_cat_ca_name;
        private TextBox tb_cat_inter_name;
        private TextBox tb_cat_ca_name;
        private Label lbl_cat_out_name;
        private TextBox tb_cat_res_name;
        private Button bt_cat_gen;
        private CheckBox cb_inter_sign;
        private Label xx;
        private TextBox tb_inter_sign_ca_name;
        private Button bt_inter_sign_ca_name;
        private TextBox tb_debugoutput;
        private GroupBox gb_application;
        private Label label6;
        private TextBox tb_appl_key_pw2;
        private TextBox tb_appl_priv_name;
        private TextBox tb_appl_key_pw1;
        private TextBox tb_appl_csr_name;
        private Label label10;
        private Button bt_appl_priv_gen2;
        private Button bt_appl_csr_gen;
        private TextBox tb_appl_key_pw_in;
        private Button bt_appl_sign_inter_name;
        private CheckBox cb_appl_sign;
        private TextBox tb_appl_cert_days;
        private Label lbl_appl_cert_days;
        private Label label11;
        private TextBox tb_appl_sign_inter_name;
        private TextBox tb_inter_cert_name;
        private PageSetupDialog pageSetupDialog1;
    }
}
