using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.Data.Sqlite;
using WinFormsApp1;

namespace SCG;
public class Ssql
{
    public string update;
    public string select;
    public string where;
    public string sql;
    public string delete;

    public string Name { get; set; }

    public string Priv_bits { get; set; }
    public string Priv_pass { get; set; }
    public string Pub_duration { get; set; }
    public string Pub_pass { get; set; }
    public string Cnf { get; set; }
    public string Subj_country { get; set; }
    public string Subj_state { get; set; }
    public string Subj_location { get; set; }
    public string Subj_orgaunit { get; set; }
    public string Subj_commonname { get; set; }
    public string Subj_email { get; set; }
    public int Count { get; }
    public SQLTable SSL_Type { get; set; }
    public SQLOption SQL_Option { get; set; }

    public enum SQLTable
    {
        ca,
        intermediate,
        server,
        user
    }
    public enum SQLOption
    {
        INSERT_INTO,
        UPDATE,
        DELETE
    }

    /// <summary>
    /// Execute SQL Statement
    /// </summary>
    /// <param name="database">Path to the database file</param>
    /// <param name="option">SQL Statement</param>
    /// <param name="table">table select ion</param>
    /// <param name="CaName">CA Name</param>
    /// <param name="Privbits">The size of the private key to generate in bits</param>
    /// <param name="Privpass">The password that shall be used for encryption</param>
    /// <param name="Privkey">Teh private key of rsa.ExportRSAPrivateKeyPem()</param>
    public static void Ssqlc(string database, SQLOption option, SQLTable table, string CaName, int Privbits, string Privpass, string Privkey)
    {

        var PrivCreateDT = DateTime.Now.ToString();

        var sql = "INSERT INTO ca (name, private_bits, private_pass, private_content, private_createDT) VALUES (@Ca_Name, @priv_bits, @priv_pass, @priv_content, @priv_createDT)";
        using var connection = new SqliteConnection(database);
        connection.Open();

        using var command = new SqliteCommand(sql, connection);
        command.Parameters.AddWithValue("@Ca_Name", CaName);
        command.Parameters.AddWithValue("@priv_bits", Privbits);
        command.Parameters.AddWithValue("@priv_pass", Privpass);
        command.Parameters.AddWithValue("@priv_content", Privkey);
        command.Parameters.AddWithValue("@priv_createDT", PrivCreateDT);
        switch (option)
        {
            case (SQLOption.INSERT_INTO):
                var _option = "INSERT INTO";
                command.Parameters.AddWithValue("@sqloption", _option);
                break;
            case (SQLOption.UPDATE):
                command.Parameters.AddWithValue("@sqloption", "UPDATE");
                break;
            case (SQLOption.DELETE):
                command.Parameters.AddWithValue("@sqloption", "DELETE"); ;
                break;

        }
        switch (table)
        {
            case (SQLTable.ca):
                var _table = "ca";
                command.Parameters.AddWithValue("@table", _table);
                break;
            case (SQLTable.intermediate):
                command.Parameters.AddWithValue("@table", "intermediate");
                break;
            case (SQLTable.server):
                command.Parameters.AddWithValue("@table", "server");
                break;
            case (SQLTable.user):
                command.Parameters.AddWithValue("@table", "user");
                break;
        }


        var rowInserted = command.ExecuteNonQuery();

    }

    public int GetEntryCount()
    {
        return Count;
    }


}
