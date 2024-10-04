namespace SCG.Forms;

partial class openSSL_CA_Configfile
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
        Label lbl_loc_cnf_ca;
        textBox1 = new TextBox();
        openFileDialog1 = new OpenFileDialog();
        button1 = new Button();
        lbl_ca_name = new Label();
        gb_default_disti_names = new GroupBox();
        tb_ca_name = new TextBox();
        lbl_def_country = new Label();
        lbl_def_state = new Label();
        lbl_def_location = new Label();
        lbl_def_organisation = new Label();
        lbl_def_organisationUnit = new Label();
        lbl_def_commonName = new Label();
        lbl_def_email = new Label();
        textBox2 = new TextBox();
        textBox3 = new TextBox();
        textBox4 = new TextBox();
        textBox5 = new TextBox();
        textBox6 = new TextBox();
        textBox7 = new TextBox();
        textBox8 = new TextBox();
        lbl_loc_cnf_ca = new Label();
        gb_default_disti_names.SuspendLayout();
        SuspendLayout();
        // 
        // lbl_loc_cnf_ca
        // 
        lbl_loc_cnf_ca.AutoSize = true;
        lbl_loc_cnf_ca.Location = new Point(12, 9);
        lbl_loc_cnf_ca.Name = "lbl_loc_cnf_ca";
        lbl_loc_cnf_ca.Size = new Size(56, 15);
        lbl_loc_cnf_ca.TabIndex = 1;
        lbl_loc_cnf_ca.Text = "Location:";
        // 
        // textBox1
        // 
        textBox1.Location = new Point(74, 6);
        textBox1.Name = "textBox1";
        textBox1.Size = new Size(326, 23);
        textBox1.TabIndex = 0;
        // 
        // openFileDialog1
        // 
        openFileDialog1.FileName = "openFileDialog1";
        openFileDialog1.InitialDirectory = ".\\";
        // 
        // button1
        // 
        button1.Location = new Point(406, 6);
        button1.Name = "button1";
        button1.Size = new Size(75, 23);
        button1.TabIndex = 2;
        button1.Text = "search";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click;
        // 
        // lbl_ca_name
        // 
        lbl_ca_name.AutoSize = true;
        lbl_ca_name.Location = new Point(17, 64);
        lbl_ca_name.Name = "lbl_ca_name";
        lbl_ca_name.Size = new Size(61, 15);
        lbl_ca_name.TabIndex = 3;
        lbl_ca_name.Text = "CA Name:";
        // 
        // gb_default_disti_names
        // 
        gb_default_disti_names.Controls.Add(textBox8);
        gb_default_disti_names.Controls.Add(textBox7);
        gb_default_disti_names.Controls.Add(textBox6);
        gb_default_disti_names.Controls.Add(textBox5);
        gb_default_disti_names.Controls.Add(textBox4);
        gb_default_disti_names.Controls.Add(textBox3);
        gb_default_disti_names.Controls.Add(textBox2);
        gb_default_disti_names.Controls.Add(lbl_def_email);
        gb_default_disti_names.Controls.Add(lbl_def_commonName);
        gb_default_disti_names.Controls.Add(lbl_def_organisationUnit);
        gb_default_disti_names.Controls.Add(lbl_def_organisation);
        gb_default_disti_names.Controls.Add(lbl_def_location);
        gb_default_disti_names.Controls.Add(lbl_def_state);
        gb_default_disti_names.Controls.Add(lbl_def_country);
        gb_default_disti_names.Location = new Point(17, 101);
        gb_default_disti_names.Name = "gb_default_disti_names";
        gb_default_disti_names.Size = new Size(571, 239);
        gb_default_disti_names.TabIndex = 4;
        gb_default_disti_names.TabStop = false;
        gb_default_disti_names.Text = "Default Distinguished Names";
        // 
        // tb_ca_name
        // 
        tb_ca_name.Location = new Point(84, 61);
        tb_ca_name.Name = "tb_ca_name";
        tb_ca_name.Size = new Size(100, 23);
        tb_ca_name.TabIndex = 5;
        // 
        // lbl_def_country
        // 
        lbl_def_country.AutoSize = true;
        lbl_def_country.Location = new Point(13, 28);
        lbl_def_country.Name = "lbl_def_country";
        lbl_def_country.Size = new Size(38, 15);
        lbl_def_country.TabIndex = 0;
        lbl_def_country.Text = "label1";
        // 
        // lbl_def_state
        // 
        lbl_def_state.AutoSize = true;
        lbl_def_state.Location = new Point(13, 54);
        lbl_def_state.Name = "lbl_def_state";
        lbl_def_state.Size = new Size(38, 15);
        lbl_def_state.TabIndex = 1;
        lbl_def_state.Text = "label2";
        // 
        // lbl_def_location
        // 
        lbl_def_location.AutoSize = true;
        lbl_def_location.Location = new Point(13, 82);
        lbl_def_location.Name = "lbl_def_location";
        lbl_def_location.Size = new Size(38, 15);
        lbl_def_location.TabIndex = 2;
        lbl_def_location.Text = "label3";
        // 
        // lbl_def_organisation
        // 
        lbl_def_organisation.AutoSize = true;
        lbl_def_organisation.Location = new Point(13, 112);
        lbl_def_organisation.Name = "lbl_def_organisation";
        lbl_def_organisation.Size = new Size(38, 15);
        lbl_def_organisation.TabIndex = 3;
        lbl_def_organisation.Text = "label4";
        // 
        // lbl_def_organisationUnit
        // 
        lbl_def_organisationUnit.AutoSize = true;
        lbl_def_organisationUnit.Location = new Point(13, 144);
        lbl_def_organisationUnit.Name = "lbl_def_organisationUnit";
        lbl_def_organisationUnit.Size = new Size(38, 15);
        lbl_def_organisationUnit.TabIndex = 4;
        lbl_def_organisationUnit.Text = "label5";
        // 
        // lbl_def_commonName
        // 
        lbl_def_commonName.AutoSize = true;
        lbl_def_commonName.Location = new Point(13, 178);
        lbl_def_commonName.Name = "lbl_def_commonName";
        lbl_def_commonName.Size = new Size(43, 15);
        lbl_def_commonName.TabIndex = 5;
        lbl_def_commonName.Text = "dasdas";
        // 
        // lbl_def_email
        // 
        lbl_def_email.AutoSize = true;
        lbl_def_email.Location = new Point(13, 206);
        lbl_def_email.Name = "lbl_def_email";
        lbl_def_email.Size = new Size(38, 15);
        lbl_def_email.TabIndex = 6;
        lbl_def_email.Text = "label7";
        // 
        // textBox2
        // 
        textBox2.Location = new Point(67, 22);
        textBox2.Name = "textBox2";
        textBox2.Size = new Size(100, 23);
        textBox2.TabIndex = 7;
        // 
        // textBox3
        // 
        textBox3.Location = new Point(67, 54);
        textBox3.Name = "textBox3";
        textBox3.Size = new Size(100, 23);
        textBox3.TabIndex = 8;
        // 
        // textBox4
        // 
        textBox4.Location = new Point(67, 79);
        textBox4.Name = "textBox4";
        textBox4.Size = new Size(100, 23);
        textBox4.TabIndex = 9;
        // 
        // textBox5
        // 
        textBox5.Location = new Point(67, 112);
        textBox5.Name = "textBox5";
        textBox5.Size = new Size(100, 23);
        textBox5.TabIndex = 10;
        // 
        // textBox6
        // 
        textBox6.Location = new Point(67, 141);
        textBox6.Name = "textBox6";
        textBox6.Size = new Size(100, 23);
        textBox6.TabIndex = 11;
        // 
        // textBox7
        // 
        textBox7.Location = new Point(67, 178);
        textBox7.Name = "textBox7";
        textBox7.Size = new Size(100, 23);
        textBox7.TabIndex = 12;
        // 
        // textBox8
        // 
        textBox8.Location = new Point(67, 206);
        textBox8.Name = "textBox8";
        textBox8.Size = new Size(100, 23);
        textBox8.TabIndex = 13;
        // 
        // openSSL_CA_Configfile
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(tb_ca_name);
        Controls.Add(gb_default_disti_names);
        Controls.Add(lbl_ca_name);
        Controls.Add(button1);
        Controls.Add(lbl_loc_cnf_ca);
        Controls.Add(textBox1);
        Name = "openSSL_CA_Configfile";
        Text = "openssl Configfile";
        gb_default_disti_names.ResumeLayout(false);
        gb_default_disti_names.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private TextBox textBox1;
    private Label lbl_loc_cnf_ca;
    private OpenFileDialog openFileDialog1;
    private Button button1;
    private Label lbl_ca_name;
    private GroupBox gb_default_disti_names;
    private TextBox tb_ca_name;
    private TextBox textBox8;
    private TextBox textBox7;
    private TextBox textBox6;
    private TextBox textBox5;
    private TextBox textBox4;
    private TextBox textBox3;
    private TextBox textBox2;
    private Label lbl_def_email;
    private Label lbl_def_commonName;
    private Label lbl_def_organisationUnit;
    private Label lbl_def_organisation;
    private Label lbl_def_location;
    private Label lbl_def_state;
    private Label lbl_def_country;
}