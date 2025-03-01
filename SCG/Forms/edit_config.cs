using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SCG.Forms;
public partial class edit_config : Form
{
    public edit_config()
    {
        InitializeComponent();
    }

    private void edit_config_onLoad(object sender, EventArgs e)
    {
        Cb_cert_auto_upload.Checked = Global.autoUpload;
        Tb_db_path.Text = Global.database;
    }

    private void cb_autoUpload_checkedChanged(object sender, EventArgs e)
    {
        Properties.Settings.Default.autoUpload = Cb_cert_auto_upload.Checked;
    }

    private void edit_config_FormClosing(object sender, FormClosingEventArgs e)
    {
        Properties.Settings.Default.Save();
    }

    private void Bt_db_path_select_onClick(object sender, EventArgs e)
    {
        if (Diag_Database.ShowDialog() == DialogResult.OK)
        {
            try
            {
                Properties.Settings.Default.databasePath = Diag_Database.FileName;
                Tb_db_path.Text = Properties.Settings.Default.databasePath;
            }
            catch (SecurityException ex)
            {
                MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                $"Details:\n\n{ex.StackTrace}");
            }
        }
    }

    private void Cb_save_to_disk_CheckedChanged(object sender, EventArgs e)
    {
        Properties.Settings.Default.CertToDisk = Cb_cert_auto_upload.Checked;
    }
}
