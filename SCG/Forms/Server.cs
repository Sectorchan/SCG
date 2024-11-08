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
using FluentResults;
using Microsoft.Data.Sqlite;
using PL;
using FluentResults;
using WinFormsApp1;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static SCG.Ssql;
using RadioButton = System.Windows.Forms.RadioButton;
using System.Threading.Tasks.Dataflow;


namespace SCG.Forms;
public partial class Server : Form
{
     public Server()
    {
        InitializeComponent();
    }

    private void server_onLoad(object sender, EventArgs e)
    {
        Bt_gen_priv.Enabled = false;
        Result<List<string>> result = Utils.Sql.SqlSelect(Global.database, "name", Ssql.SQLTable.ca);
       
        // get all reasons why result object indicates success or failure. 
        // contains Error and Success messages
        //IEnumerable<IReason> reasons = result.Reasons;
        // get all Error messages
        //IEnumerable<IError> errors = result.Errors;
        // get all Success messages
        //IEnumerable<ISuccess> successes = result.Successes;

        if (result.IsSuccess)
        {
            foreach (var item in result.Value)
            {
                lb_server_certs.Items.Add(item);
            }
            lb_server_certs.Sorted = true;
        }
        else
        {
            MessageBox.Show(result.Value.ToString(), "Error on Query SQL database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
    }

    /// <summary>
    /// Query the selection of the RadioButton
    /// </summary>
    /// <returns>Returns the visible text of the selected RadioButton</returns>
    private Ssql.SQLTable CertType()
    {
        string serverType = panel1.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).Text;
        Ssql.SQLTable Table = Ssql.SQLTable.undefined;
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
        }
        return Table;
    }

    private void Bt_gen_priv_onClick(object sender, EventArgs e)
    {
        try
        {
            int PrivateBits = int.Parse(cb_priv_bits.Text);
            var PrivKey = Utils.Certs.CreatePrivKey(PrivateBits);
            Ssql.SQLTable Certtype = CertType();
            Utils.Sql.InsertInto(Global.database, Certtype, tb_ca_name.Text, tb_priv_passwd.Text, PrivKey, PrivateBits);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString(), sender.ToString());
        }
    }

    private void cb_new_server_CheckedChanged(object sender, EventArgs e)
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


