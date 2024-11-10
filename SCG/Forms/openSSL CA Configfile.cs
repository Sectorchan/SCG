using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WinFormsApp1.Forms;
public partial class openSSL_CA_Configfile : Form
{
    public string opensslCaCnfPath
    {
        get { return tb_ca_cnf_path.Text; }
        
    }
   
    public openSSL_CA_Configfile()
    {
        InitializeComponent();
        
        
    }

    private void button1_Click(object sender, EventArgs e)
    {
        DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
        if (result == DialogResult.OK) // Test result.
        {
            string file = openFileDialog1.FileName;
            tb_ca_cnf_path.Text = file;
        }
    }

    private void bt_form2_close_Click(object sender, EventArgs e)
    {



        //string debug = tb_ca_name.Text;
        Close();
    }
}
