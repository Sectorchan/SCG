using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Microsoft.Data.Sqlite;
using WinFormsApp1;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using RadioButton = System.Windows.Forms.RadioButton;

namespace SCG.Forms;
public partial class Server : Form
{
    //string database = @"Data Source=database.db";
    string xml = @"certificates\ca\xml.xml";

    public Server()
    {
        InitializeComponent();
    }

    private void server_onLoad(object sender, EventArgs e)
    {
        var sql = "SELECT * FROM ca";
        try
        {
            using var connection = new SqliteConnection(Global.database);
            connection.Open();
            using var command = new SqliteCommand(sql, connection);
            using var reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var Name = reader.GetString(1);
                }
            }
            else
            {
                MessageBox.Show("No entries yet");
            }
        }
        catch (SqliteException ex)
        {
            MessageBox.Show(ex.Message);
        }

        //Searches in a folder and list all files in a listBox
        //DirectoryInfo d = new DirectoryInfo(@"./certificates/server/private");
        //foreach (var file in d.GetFiles("*.*"))
        //{
        //    lb_server_certs.Items.Add(file.Name);
        //}



    }

    public void Cblist_read(bool refreshList)
    {

        XDocument doc = XDocument.Load(xml);
        //IEnumerable<XElement> ca = doc.Descendants(tmpselection);
        lb_server_certs.Sorted = true;
    }

    //private void rb_changed(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        RadioButton rb = sender as RadioButton;

    //        if (rb == null)
    //        {
    //            MessageBox.Show("Sender is not a RadioButton");
    //            return;
    //        }
    //        // Ensure that the RadioButton.Checked property
    //        // changed to true.
    //        if (rb.Checked)
    //        {
    //            // Keep track of the selected RadioButton by saving a reference
    //            // to it.
    //            //MessageBox.Show(rb.Text);

    //            //XDocument doc = XDocument.Load(xml);
    //            //IEnumerable<XElement> ca = doc.Descendants(rb.Text);
    //            //foreach (XElement cas in ca)
    //            //{
    //            //    lb_server_certs.Items.Add(cas.Element("name").Value);
    //            //    lb_server_certs.Sorted = true;
    //            //}
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        MessageBox.Show(ex.Message);
    //        return;
    //    }
    //}

    private void bt_add_server_Click(object sender, EventArgs e)
    {
        var serverType = panel1.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).Name;

        string[] array = [
            serverType.ToString(),
            tb_ca_name.Text,
            tb_priv_bits.Text, tb_priv_passwd.Text];

        //int i = int.Parse(array[1]);
        //int ii = i + 19;
        //MessageBox.Show($"id: " + ii.ToString());

    }
}
