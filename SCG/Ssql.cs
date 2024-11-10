using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.Data.Sqlite;
using PL;
using WinFormsApp1;

namespace SCG;
public class Ssql
{
    #region properties
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
    #endregion
    #region enum
    public enum SQLTable
    {
        undefined,
        ca,
        intermediate,
        server,
        user
    }
    public enum SQLOption
    {
        INSERT_INTO,
        UPDATE,
        DELETE,
        SELECT
    }
    #endregion

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
        var _option = "";
        var _table = "";
        var PrivCreateDT = DateTime.Now.ToString();
        
        using var connection = new SqliteConnection(database);
        connection.Open();

        switch (option)
        {
            case (SQLOption.INSERT_INTO):
                _option = "INSERT INTO";
                break;
            case (SQLOption.UPDATE):
                _option = "UPDATE";
                break;
            case (SQLOption.DELETE):
                _option = "DELETE";
                break;
            case (SQLOption.SELECT):
                _option = "SELECT";
                break;
        }
        switch (table)
        {
            case (SQLTable.ca):
                _table = "ca";
                break;
            case (SQLTable.intermediate):
                _table = "intermediate";
                break;
            case (SQLTable.server):
                _table = "server";
                break;
            case (SQLTable.user):
                _table = "user";
                break;
        }
        var sql = $"{_option} {_table} (name, private_bits, private_pass, private_content, private_createDT) VALUES (@Ca_Name, @priv_bits, @priv_pass, @priv_content, @priv_createDT)";
        //SELECT CustomerName, City FROM Customers;
        //var sql = "SELECT name FROM ca";
        using var command = new SqliteCommand(sql, connection);
        command.Parameters.AddWithValue("@Ca_Name", CaName);
        command.Parameters.AddWithValue("@priv_bits", Privbits);
        command.Parameters.AddWithValue("@priv_pass", Privpass);
        command.Parameters.AddWithValue("@priv_content", Privkey);
        command.Parameters.AddWithValue("@priv_createDT", PrivCreateDT);
        var rowInserted = command.ExecuteNonQuery();
        
    }


    public int GetEntryCount()
    {
        return Count;
      
    }

    public static string CreatePrivKey2(int KeySize)
    {
        RSA rsa = RSA.Create();
        rsa.KeySize = KeySize;
        var Privkey = rsa.ExportRSAPrivateKeyPem();

        return Privkey;
    }


}
