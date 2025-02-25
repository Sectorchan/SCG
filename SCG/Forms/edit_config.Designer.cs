namespace SCG.Forms;

partial class edit_config
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
        Cb_cert_auto_upload = new CheckBox();
        Tb_db_path = new TextBox();
        Diag_Database = new OpenFileDialog();
        Lb_database = new Label();
        Bt_db_path_select = new Button();
        Cb_save_to_disk = new CheckBox();
        SuspendLayout();
        // 
        // Cb_cert_auto_upload
        // 
        Cb_cert_auto_upload.AutoSize = true;
        Cb_cert_auto_upload.Location = new Point(12, 12);
        Cb_cert_auto_upload.Name = "Cb_cert_auto_upload";
        Cb_cert_auto_upload.Size = new Size(179, 19);
        Cb_cert_auto_upload.TabIndex = 0;
        Cb_cert_auto_upload.Text = "Automatic Certificate upload";
        Cb_cert_auto_upload.UseVisualStyleBackColor = true;
        Cb_cert_auto_upload.CheckedChanged += cb_autoUpload_checkedChanged;
        // 
        // Tb_db_path
        // 
        Tb_db_path.Location = new Point(83, 58);
        Tb_db_path.Name = "Tb_db_path";
        Tb_db_path.Size = new Size(271, 23);
        Tb_db_path.TabIndex = 1;
        // 
        // Diag_Database
        // 
        Diag_Database.DefaultExt = "db";
        Diag_Database.FileName = "Database";
        Diag_Database.Filter = "SQLite (*.db)|*.*";
        // 
        // Lb_database
        // 
        Lb_database.AutoSize = true;
        Lb_database.Location = new Point(12, 62);
        Lb_database.Name = "Lb_database";
        Lb_database.Size = new Size(55, 15);
        Lb_database.TabIndex = 2;
        Lb_database.Text = "Database";
        // 
        // Bt_db_path_select
        // 
        Bt_db_path_select.Location = new Point(360, 58);
        Bt_db_path_select.Name = "Bt_db_path_select";
        Bt_db_path_select.Size = new Size(75, 23);
        Bt_db_path_select.TabIndex = 3;
        Bt_db_path_select.Text = "Select";
        Bt_db_path_select.UseVisualStyleBackColor = true;
        Bt_db_path_select.Click += Bt_db_path_select_onClick;
        // 
        // Cb_save_to_disk
        // 
        Cb_save_to_disk.AutoSize = true;
        Cb_save_to_disk.Location = new Point(12, 33);
        Cb_save_to_disk.Name = "Cb_save_to_disk";
        Cb_save_to_disk.Size = new Size(143, 19);
        Cb_save_to_disk.TabIndex = 4;
        Cb_save_to_disk.Text = "Save certificate to disk";
        Cb_save_to_disk.UseVisualStyleBackColor = true;
        Cb_save_to_disk.CheckedChanged += Cb_save_to_disk_CheckedChanged;
        // 
        // edit_config
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(Cb_save_to_disk);
        Controls.Add(Bt_db_path_select);
        Controls.Add(Lb_database);
        Controls.Add(Tb_db_path);
        Controls.Add(Cb_cert_auto_upload);
        Name = "edit_config";
        Text = "edit_config";
        FormClosing += edit_config_FormClosing;
        Load += edit_config_onLoad;
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private CheckBox Cb_cert_auto_upload;
    private TextBox Tb_db_path;
    private OpenFileDialog Diag_Database;
    private Label Lb_database;
    private Button Bt_db_path_select;
    private CheckBox Cb_save_to_disk;
}
