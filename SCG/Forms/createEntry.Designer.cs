namespace SCG.Forms;

partial class createEntry
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
        Lb_label = new Label();
        Tb_entries = new TextBox();
        Bt_new = new Button();
        Cb_keySize = new ComboBox();
        flowControl = new FlowLayoutPanel();
        Bt_Cancel = new Button();
        Bt_Panel = new FlowLayoutPanel();
        gb_dn = new GroupBox();
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
        customButton1 = new CustomButton();
        gb_dn.SuspendLayout();
        SuspendLayout();
        // 
        // Lb_label
        // 
        Lb_label.AutoSize = true;
        Lb_label.Location = new Point(57, 48);
        Lb_label.Name = "Lb_label";
        Lb_label.Size = new Size(32, 15);
        Lb_label.TabIndex = 0;
        Lb_label.Text = "label";
        // 
        // Tb_entries
        // 
        Tb_entries.Location = new Point(57, 66);
        Tb_entries.Name = "Tb_entries";
        Tb_entries.Size = new Size(178, 23);
        Tb_entries.TabIndex = 1;
        Tb_entries.Visible = false;
        // 
        // Bt_new
        // 
        Bt_new.Location = new Point(57, 122);
        Bt_new.Name = "Bt_new";
        Bt_new.Size = new Size(75, 23);
        Bt_new.TabIndex = 2;
        Bt_new.Text = "Ok";
        Bt_new.UseVisualStyleBackColor = true;
        Bt_new.Click += Bt_new_onClick;
        // 
        // Cb_keySize
        // 
        Cb_keySize.FormattingEnabled = true;
        Cb_keySize.Items.AddRange(new object[] { "2048", "4096", "8192" });
        Cb_keySize.Location = new Point(57, 65);
        Cb_keySize.Margin = new Padding(3, 2, 3, 2);
        Cb_keySize.Name = "Cb_keySize";
        Cb_keySize.Size = new Size(133, 23);
        Cb_keySize.TabIndex = 3;
        Cb_keySize.Visible = false;
        // 
        // flowControl
        // 
        flowControl.AutoSize = true;
        flowControl.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        flowControl.FlowDirection = FlowDirection.TopDown;
        flowControl.Location = new Point(12, 12);
        flowControl.Name = "flowControl";
        flowControl.Size = new Size(0, 0);
        flowControl.TabIndex = 5;
        // 
        // Bt_Cancel
        // 
        Bt_Cancel.Location = new Point(153, 123);
        Bt_Cancel.Name = "Bt_Cancel";
        Bt_Cancel.Size = new Size(75, 23);
        Bt_Cancel.TabIndex = 6;
        Bt_Cancel.Text = "Cancel";
        Bt_Cancel.UseVisualStyleBackColor = true;
        Bt_Cancel.Click += Bt_Cancel_Click;
        // 
        // Bt_Panel
        // 
        Bt_Panel.AutoSize = true;
        Bt_Panel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        Bt_Panel.Location = new Point(12, 151);
        Bt_Panel.Name = "Bt_Panel";
        Bt_Panel.Size = new Size(0, 0);
        Bt_Panel.TabIndex = 7;
        // 
        // gb_dn
        // 
        gb_dn.Controls.Add(Tb_san4);
        gb_dn.Controls.Add(Tb_san3);
        gb_dn.Controls.Add(Tb_san2);
        gb_dn.Controls.Add(Tb_san1);
        gb_dn.Controls.Add(Cb_san4);
        gb_dn.Controls.Add(Cb_san3);
        gb_dn.Controls.Add(Cb_san2);
        gb_dn.Controls.Add(Cb_san1);
        gb_dn.Controls.Add(tb_sub_email);
        gb_dn.Controls.Add(tb_sub_cn);
        gb_dn.Controls.Add(tb_sub_orga);
        gb_dn.Controls.Add(tb_sub_ou);
        gb_dn.Controls.Add(tb_sub_loc);
        gb_dn.Controls.Add(tb_sub_st);
        gb_dn.Controls.Add(tb_sub_c);
        gb_dn.Controls.Add(lbl_def_email);
        gb_dn.Controls.Add(lbl_def_commonName);
        gb_dn.Controls.Add(lbl_def_organisationUnit);
        gb_dn.Controls.Add(lbl_def_organisation);
        gb_dn.Controls.Add(lbl_def_location);
        gb_dn.Controls.Add(lbl_def_state);
        gb_dn.Controls.Add(lbl_def_country);
        gb_dn.Location = new Point(284, 10);
        gb_dn.Name = "gb_dn";
        gb_dn.Size = new Size(500, 219);
        gb_dn.TabIndex = 12;
        gb_dn.TabStop = false;
        gb_dn.Text = "Default Distinguished Names";
        // 
        // Tb_san4
        // 
        Tb_san4.Location = new Point(321, 120);
        Tb_san4.Name = "Tb_san4";
        Tb_san4.Size = new Size(166, 23);
        Tb_san4.TabIndex = 22;
        // 
        // Tb_san3
        // 
        Tb_san3.Location = new Point(321, 91);
        Tb_san3.Name = "Tb_san3";
        Tb_san3.Size = new Size(166, 23);
        Tb_san3.TabIndex = 21;
        // 
        // Tb_san2
        // 
        Tb_san2.Location = new Point(321, 62);
        Tb_san2.Name = "Tb_san2";
        Tb_san2.Size = new Size(166, 23);
        Tb_san2.TabIndex = 20;
        // 
        // Tb_san1
        // 
        Tb_san1.Location = new Point(321, 33);
        Tb_san1.Name = "Tb_san1";
        Tb_san1.Size = new Size(166, 23);
        Tb_san1.TabIndex = 19;
        // 
        // Cb_san4
        // 
        Cb_san4.FormattingEnabled = true;
        Cb_san4.Items.AddRange(new object[] { "IP", "DNS" });
        Cb_san4.Location = new Point(244, 120);
        Cb_san4.Name = "Cb_san4";
        Cb_san4.Size = new Size(71, 23);
        Cb_san4.TabIndex = 18;
        // 
        // Cb_san3
        // 
        Cb_san3.FormattingEnabled = true;
        Cb_san3.Items.AddRange(new object[] { "IP", "DNS" });
        Cb_san3.Location = new Point(244, 91);
        Cb_san3.Name = "Cb_san3";
        Cb_san3.Size = new Size(71, 23);
        Cb_san3.TabIndex = 17;
        // 
        // Cb_san2
        // 
        Cb_san2.FormattingEnabled = true;
        Cb_san2.Items.AddRange(new object[] { "IP", "DNS" });
        Cb_san2.Location = new Point(244, 62);
        Cb_san2.Name = "Cb_san2";
        Cb_san2.Size = new Size(71, 23);
        Cb_san2.TabIndex = 16;
        // 
        // Cb_san1
        // 
        Cb_san1.FormattingEnabled = true;
        Cb_san1.Items.AddRange(new object[] { "IP", "DNS" });
        Cb_san1.Location = new Point(244, 33);
        Cb_san1.Name = "Cb_san1";
        Cb_san1.Size = new Size(71, 23);
        Cb_san1.TabIndex = 15;
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
        lbl_def_email.Location = new Point(66, 184);
        lbl_def_email.Name = "lbl_def_email";
        lbl_def_email.Size = new Size(41, 15);
        lbl_def_email.TabIndex = 6;
        lbl_def_email.Text = "E-Mail";
        // 
        // lbl_def_commonName
        // 
        lbl_def_commonName.AutoSize = true;
        lbl_def_commonName.Location = new Point(14, 163);
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
        lbl_def_organisation.Location = new Point(46, 110);
        lbl_def_organisation.Name = "lbl_def_organisation";
        lbl_def_organisation.Size = new Size(61, 15);
        lbl_def_organisation.TabIndex = 3;
        lbl_def_organisation.Text = "Orga. Unit";
        // 
        // lbl_def_location
        // 
        lbl_def_location.AutoSize = true;
        lbl_def_location.Location = new Point(54, 85);
        lbl_def_location.Name = "lbl_def_location";
        lbl_def_location.Size = new Size(53, 15);
        lbl_def_location.TabIndex = 2;
        lbl_def_location.Text = "Location";
        // 
        // lbl_def_state
        // 
        lbl_def_state.AutoSize = true;
        lbl_def_state.Location = new Point(74, 57);
        lbl_def_state.Name = "lbl_def_state";
        lbl_def_state.Size = new Size(33, 15);
        lbl_def_state.TabIndex = 1;
        lbl_def_state.Text = "State";
        // 
        // lbl_def_country
        // 
        lbl_def_country.AutoSize = true;
        lbl_def_country.Location = new Point(57, 34);
        lbl_def_country.Name = "lbl_def_country";
        lbl_def_country.Size = new Size(50, 15);
        lbl_def_country.TabIndex = 0;
        lbl_def_country.Text = "Country";
        // 
        // customButton1
        // 
        customButton1._certInfo = PL.Utils.Tools.info.CertInfoWrite;
        customButton1._certType = PL.Utils.Tools.certType.priv;
        customButton1._fqdnType = PL.Utils.Tools.fdqnType.write;
        customButton1._serverType = PL.Utils.Tools.serverType.ca;
        customButton1.Location = new Point(360, 332);
        customButton1.Name = "customButton1";
        customButton1.Size = new Size(75, 23);
        customButton1.TabIndex = 13;
        customButton1.Text = "customButton1";
        customButton1.UseVisualStyleBackColor = true;
        // 
        // createEntry
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        AutoSize = true;
        AutoSizeMode = AutoSizeMode.GrowAndShrink;
        ClientSize = new Size(745, 504);
        Controls.Add(customButton1);
        Controls.Add(gb_dn);
        Controls.Add(Bt_Panel);
        Controls.Add(Bt_Cancel);
        Controls.Add(flowControl);
        Controls.Add(Cb_keySize);
        Controls.Add(Bt_new);
        Controls.Add(Tb_entries);
        Controls.Add(Lb_label);
        Name = "createEntry";
        Text = "createEntry";
        FormClosing += createEntry_FormClosing;
        Load += createEntry_Load;
        gb_dn.ResumeLayout(false);
        gb_dn.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label Lb_label;
    private TextBox Tb_entries;
    private ComboBox Cb_keySize;
    private FlowLayoutPanel flowControl;
    private Button Bt_Cancel;
    private FlowLayoutPanel Bt_Panel;
    private Button Bt_new;
    private GroupBox gb_dn;
    private TextBox Tb_san4;
    private TextBox Tb_san3;
    private TextBox Tb_san2;
    private TextBox Tb_san1;
    private ComboBox Cb_san4;
    private ComboBox Cb_san3;
    private ComboBox Cb_san2;
    private ComboBox Cb_san1;
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
    private CustomButton customButton1;
}
