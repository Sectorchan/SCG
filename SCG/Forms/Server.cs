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
using WinFormsApp1;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static SCG.Ssql;
using RadioButton = System.Windows.Forms.RadioButton;
using System.Threading.Tasks.Dataflow;
using static System.Runtime.InteropServices.JavaScript.JSType;


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
        Result<List<string>> result = Utils.Sql.SqlSelect(Global.database, "name", SQLTable.ca);

        if (result.IsSuccess)
        {
            if (result.Value == null)
            {
                result = Result.Fail("Empty List");
                return;
            }
            else
            {
                foreach (var item in result.Value)
                {
                    lb_server_certs.Items.Add(item);
                }
                lb_server_certs.Sorted = true;
            }
        }
        else
        {
            MessageBox.Show(result.Value.ToString(), "Error on Query SQL database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
    }

    private Result<SQLTable> SqlTable()
    {
        string SqlTable = panel1.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).Text;
        SQLTable Table = SQLTable.undefined;
        switch (SqlTable)
        {
            case "CA":
                Table = SQLTable.ca;
                break;
            case "Intermediate":
                Table = SQLTable.intermediate;
                break;
            case "Server":
                Table = SQLTable.server;
                break;
            case "User":
                Table = SQLTable.user;
                break;
        }
        return Result.Ok(Table);
    }
    /// <summary>
    /// Query the selection of the RadioButton
    /// </summary>
    /// <returns>Returns the visible text of the selected RadioButton</returns>
    private Result<SQLTable> CertType()
    {
        string serverType = panel1.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).Text;
        SQLTable Table = SQLTable.undefined;
        switch (serverType)
        {
            case "CA":
                Table = SQLTable.ca;
                break;
            case "Intermediate":
                Table = SQLTable.intermediate;
                break;
            case "Server":
                Table = SQLTable.server;
                break;
            case "User":
                Table = SQLTable.user;
                break;
        }
        return Result.Ok(Table);
    }

    /// <summary>
    /// Button click "Generate Private Key" > generates a private key and store it on the SQLite database.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Bt_gen_priv_onClick(object sender, EventArgs e)
    {
        try
        {
            int PrivateBits = int.Parse(cb_priv_bits.Text);
            string PrivKey = Utils.Certs.CreatePrivKey(PrivateBits);
            Result<SQLTable> result = SqlTable();
            if (result.IsSuccess)
            {
                Result<int> result1 = Utils.Sql.InsertInto(Global.database, result.Value, tb_ca_name.Text, tb_priv_passwd.Text, PrivKey, PrivateBits);
                if (result1.IsSuccess)
                {
                    MessageBox.Show($"Added {result1.Value} entries to the database", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(result1.Reasons[0].Message.ToString());
                }
            }
            Result<List<string>> result2 = Utils.Sql.SqlSelect(Global.database, "name", SQLTable.ca);

            if (result2.IsSuccess)
            {
                if (result2.Value == null)
                {
                    result2 = Result.Fail("Empty List");
                    return;
                }
                else
                {
                    lb_server_certs.Items.Clear();
                    foreach (var item in result2.Value)
                    {
                        lb_server_certs.Items.Add(item);
                    }
                    lb_server_certs.Sorted = true;
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString(), sender.ToString());
        }
    }

    /// <summary>
    /// Enables the Generate Private Key button
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void cb_new_server_CheckedChanged(object sender, EventArgs e)
    {
        if (cb_new_server.Checked && (lb_priv_bits.Text != "") && tb_ca_name.Text != "")
        {
            Bt_gen_priv.Enabled = true;
        }
        else
        {
            Bt_gen_priv.Enabled = false;
        }
    }

    /// <summary>
    /// Generates the public key, corresponding to the matching name of the private key
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void bt_gen_pub_key_Click(object sender, EventArgs e)
    {
        int pubDura = Convert.ToInt16(tb_pub_dura.Text);
        string pubPasswd = tb_pub_passwd.Text;
        string pubConfig = tb_pub_cnf.Text;
        string serverSelect = lb_server_certs.SelectedItem.ToString();
        Result<SQLTable> table = SqlTable();

        Result<string> privateKey = Utils.Sql.SelectWhere(Global.database, "private_content", table.Value, "name", serverSelect);
        if (privateKey.IsSuccess)
        {

            string publicKey = Utils.Certs.CreatePubKey(pubDura, pubConfig, privateKey.Value);
            Result<int> result = Utils.Sql.Update(Global.database, SQLTable.ca, pubDura, publicKey, serverSelect, pubPasswd, DateTime.Now.ToString());

            if (result.IsSuccess)
            {
                MessageBox.Show($"Updated {result.Value} row(s) in the database", "SQL Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(result.Reasons[0].Message.ToString());
            }
        }

        //string result = lb_server_certs.SelectedItem.ToString();
        //MessageBox.Show(privateKey);
    }

    private void bt_upd_dest_names_Click(object sender, EventArgs e)
    {

    }
}


