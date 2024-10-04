using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SCG.Forms;
public partial class openSSL_CA_Configfile : Form
{
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
            textBox1.Text = file;
        }
    }
}
