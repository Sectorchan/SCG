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
using PL;
using WinFormsApp1;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static SCG.Ssql;
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
        Bt_gen_priv.Enabled = false;
        foreach (var item in Utils.Sql.SqlSelect(Global.database, "name", Ssql.SQLTable.ca))
        {
            lb_server_certs.Items.Add(item);
        }
        lb_server_certs.Sorted = true;
    }
    //Nutzlos? TBD
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

    private Ssql.SQLTable CertType()
    {
Ssql.SQLTable Table = Ssql.SQLTable.undefined;
        string serverType = panel1.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).Text;
        
        switch (serverType)
        {
            case "CA":
                Table = Ssql.SQLTable.ca;
                break;
            case "Intermediate":
                Table = Ssql.SQLTable.intermediate;
                break;
            case "Server":
                Table = Ssql.SQLTable.server;
                break;
            case "User":
                Table = Ssql.SQLTable.user;
                break;
            case "undefined":
                MessageBox.Show("UNDEFINED CHECKBOX", "ERROR", MessageBoxButtons.CancelTryContinue, MessageBoxIcon.Warning) ;
                return Table = 0;
        }
        return Table;
    }

    //Nutzlos? TBD
    private void bt_add_server_Click(object sender, EventArgs e)
    {
        string serverType = panel1.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).Name;
        serverType.ToLower();

        //string[] array = [
        //    serverType.ToString(),
        //    tb_ca_name.Text,
        //    //tb_priv_bits.Text,
        //    tb_priv_passwd.Text];

        //int i = int.Parse(array[1]);
        //int ii = i + 19;
        //MessageBox.Show($"id: " + ii.ToString());

    }

    private void Bt_gen_priv_onClick(object sender, EventArgs e)
    {
        int PrivateBits = int.Parse(cb_priv_bits.Text);
        string PrivKey = Utils.Certs.CreatePrivKey(PrivateBits);
        Ssql.SQLTable Certtype = CertType();
        if (Certtype != Ssql.SQLTable.undefined)
        {
            Utils.Sql.InsertInto(Global.database, Certtype, tb_ca_name.Text, tb_priv_passwd.Text, PrivKey, PrivateBits);
        }
    }

    private void Cb_new_server_CheckedChanged(object sender, EventArgs e)
    {
        if (cb_new_server.Checked && (lb_priv_bits.Text != ""))
        {
            Bt_gen_priv.Enabled = true;
        }
        else
        {
            Bt_gen_priv.Enabled = false;
        }
    }


}
