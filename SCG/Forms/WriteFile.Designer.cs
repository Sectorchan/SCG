namespace SCG.Forms;

partial class WriteFile
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
        Cb_cert_ext = new ComboBox();
        Bt_write_cert = new Button();
        saveCertDialog = new SaveFileDialog();
        Lb_cert_ext = new Label();
        SuspendLayout();
        // 
        // Cb_cert_ext
        // 
        Cb_cert_ext.FormattingEnabled = true;
        Cb_cert_ext.Location = new Point(12, 27);
        Cb_cert_ext.Name = "Cb_cert_ext";
        Cb_cert_ext.Size = new Size(157, 23);
        Cb_cert_ext.TabIndex = 0;
        // 
        // Bt_write_cert
        // 
        Bt_write_cert.Location = new Point(175, 27);
        Bt_write_cert.Name = "Bt_write_cert";
        Bt_write_cert.Size = new Size(75, 23);
        Bt_write_cert.TabIndex = 1;
        Bt_write_cert.Text = "Write Cert";
        Bt_write_cert.UseVisualStyleBackColor = true;
        Bt_write_cert.Click += Bt_write_cert_Click;
        // 
        // Lb_cert_ext
        // 
        Lb_cert_ext.AutoSize = true;
        Lb_cert_ext.Location = new Point(12, 9);
        Lb_cert_ext.Name = "Lb_cert_ext";
        Lb_cert_ext.Size = new Size(113, 15);
        Lb_cert_ext.TabIndex = 2;
        Lb_cert_ext.Text = "Select file Extention:";
        // 
        // WriteFile
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(262, 143);
        Controls.Add(Lb_cert_ext);
        Controls.Add(Bt_write_cert);
        Controls.Add(Cb_cert_ext);
        Name = "WriteFile";
        Text = "WriteFile2";
        Load += WriteFile_Load;
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion
    public ComboBox Cb_cert_ext;
    private Button Bt_write_cert;
    private SaveFileDialog saveCertDialog;
    private Label Lb_cert_ext;
}
