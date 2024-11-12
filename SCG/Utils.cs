using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using FluentResults;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using SCG;
using WinFormsApp1;
using static SCG.Ssql;
using System.Diagnostics.Contracts;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics;
using Microsoft.VisualBasic;
using static PL.Utils;
using System.Xml.Linq;

namespace PL;
public class Utils
{
    public class Sql
    {


        /// <summary>
        /// Performs a SQL INSERT INTO into the given table
        /// </summary>
        /// <param name="database">The SQLite database which shall be used</param>
        /// <param name="table">The corresponding table, depending on the type</param>
        /// <param name="CaName">An unique application/server name</param>
        /// <param name="Privpass">Password for the private key</param>
        /// <param name="Privkey">The private key, as a PEM format string</param>
        /// <param name="Privbits">Default 4096, the same as on CreatePrivKey. Make sure thats the same parameter </param>
        /// <returns>Returns the amount of entries that written to the SQL database</returns>
        public static Result<int> InsertInto(string database, SQLTable table, string CaName, string Privpass, string Privkey, int Privbits = 4096)
        {
            try
            {
                string _table = "";

                var _connectionString = new SqliteConnectionStringBuilder();
                _connectionString.Mode = SqliteOpenMode.ReadWriteCreate;
                _connectionString.DataSource = database;
                _connectionString.Password = null;
                string connectionString = _connectionString.ToString();
                using var connection = new SqliteConnection(connectionString);
                connection.Open();

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

                string sql = $"INSERT INTO {_table} (name, private_bits, private_pass, private_content, private_createDT) VALUES (@Ca_Name, @priv_bits, @priv_pass, @priv_content, @priv_createDT)";

                using var command = new SqliteCommand(sql, connection);
                command.Parameters.AddWithValue("@Ca_Name", CaName);
                command.Parameters.AddWithValue("@priv_bits", Privbits);
                command.Parameters.AddWithValue("@priv_pass", Privpass);
                command.Parameters.AddWithValue("@priv_content", Privkey);
                command.Parameters.AddWithValue("@priv_createDT", DateTime.Now.ToString());
                int rowInserted = command.ExecuteNonQuery();

                return Result.Ok(rowInserted);
            }
            catch (Exception ex)
            {
                if (ex == null)
                {
                    return Result.Fail("Possible wrong SQL credentials");
                }
                else
                {
                    return Result.Fail(ex.Message);
                }
            }
        }

        /// <summary>
        /// Performs a SQL SELECT statement
        /// </summary>
        /// <param name="database">Defines the target database</param>
        /// <param name="column">Which column should be searched for</param>
        /// <param name="table">Defines the table inside the database</param>
        /// <returns>Result<List<string>></returns>
        public static List<string> SqlSelect(string database, string column, SQLTable table)
        {

            SqliteConnectionStringBuilder _connectionString = new SqliteConnectionStringBuilder();
            _connectionString.Mode = SqliteOpenMode.ReadWriteCreate;
            _connectionString.DataSource = database;
            _connectionString.Password = null;
            string connectionString = _connectionString.ToString();
            using var connection = new SqliteConnection(connectionString);
            connection.Open();

            var sql = $"SELECT {column} FROM {table}";

            using var command = new SqliteCommand(sql, connection);
            using SqliteDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                List<string> columns = new List<string>();
                while (reader.Read())
                {
                    columns.Add(reader.GetString(0));
                }
                return columns;
            }
            else
            {
                MessageBox.Show("No Server found", "", MessageBoxButtons.OK);
                return null;
            }
        }

        /// <summary>
        /// Performs a SQL SELECT WHERE statement
        /// </summary>
        /// <param name="database">Defines the target database</param>
        /// <param name="column">Which column should be searched for</param>
        /// <param name="table">Defines the table inside the database</param>
        /// <param name="searchColumn">In which column should be searched</param>
        /// <param name="searchValue">The Value that should be searched for in the searchColumn</param>
        /// <returns>Returns the string if found</returns>
        public static Result<string> SelectWhere(string database, string column, SQLTable table, string searchColumn, string searchValue)
        {
            try
            {
                SqliteConnectionStringBuilder _connectionString = new SqliteConnectionStringBuilder();
                _connectionString.Mode = SqliteOpenMode.ReadWriteCreate;
                _connectionString.DataSource = database;
                _connectionString.Password = null;
                string connectionString = _connectionString.ToString();
                using var connection = new SqliteConnection(connectionString);
                connection.Open();

                //string sql = "SELECT private_content FROM ca WHERE name=111"; //geht
                //var sql = $"SELECT private_content FROM ca WHERE name = @_searchValue"; //geht
                //var sql = $"SELECT {column} FROM ca WHERE name = @_searchValue"; // geht
                var sql = $"SELECT {column} FROM {table} WHERE name = @_searchValue";
                

                using var command = new SqliteCommand(sql, connection);
                command.Parameters.AddWithValue("@_column", column);
                command.Parameters.AddWithValue("@_table", table);
                command.Parameters.AddWithValue("@_searchColumn", searchColumn);
                command.Parameters.AddWithValue("@_searchValue", searchValue);

                using var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string privKey = reader.GetString(0);
                        return Result.Ok(privKey);
                    }
                    return Result.Fail(sql);
                }
                else
                {
                    return Result.Fail(sql);
                }
              

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return Result.Fail(ex.Message);
            }

        }

        /// <summary>
        /// Performs a SQL Update statement
        /// </summary>
        /// <returns></returns>
        public static Result<int> Update(string database, SQLTable table, int publicDuration, string publicKey, string searchTerm, string publicPasswd,string addTime = null)
        { 
            try
            {
                SqliteConnectionStringBuilder _connectionString = new SqliteConnectionStringBuilder();
                _connectionString.Mode = SqliteOpenMode.ReadWriteCreate;
                _connectionString.DataSource = database;
                _connectionString.Password = null;
                string connectionString = _connectionString.ToString();
                using var connection = new SqliteConnection(connectionString);
                connection.Open();

                string sql = $"UPDATE {table} SET public_duration = @_publicDuration, public_pass = @_publicPasswd, public_content = @_publicKey, public_createDT = @_addTime WHERE name = @_searchTerm";

                using var command = new SqliteCommand(sql, connection);

                command.Parameters.AddWithValue("@_publicDuration", publicDuration);
                command.Parameters.AddWithValue("@_publicPasswd", publicPasswd);
                command.Parameters.AddWithValue("@_publicKey", publicKey);
                command.Parameters.AddWithValue("@_addTime", addTime);
                command.Parameters.AddWithValue("@_searchTerm", searchTerm);
                
                int rowInserted = command.ExecuteNonQuery();

                return Result.Ok(rowInserted);
            }
            catch (Exception ex)
            {
                return Result.Fail(ex.Message);
            }
        }

        public void ReadCaList(object sender)
        {
            MessageBox.Show(sender.ToString());
        }


    }
    public class Certs
    {
        /// <summary>
        /// Generating the private key
        /// </summary>
        /// <param name="KeySize">Default = 4096; Represents the size, in bits, of the key modulus used by the asymmetric algorithm.</param>
        /// <returns>The privatekey in PEM format as String</returns>
        public static string CreatePrivKey(int KeySize = 4096)
        {
            RSA rsa = RSA.Create();
            rsa.KeySize = KeySize;
            var Privkey = rsa.ExportRSAPrivateKeyPem();
            return Privkey;
        }

        /// <summary>
        /// Generate the public key
        /// </summary>
        /// <returns></returns>
        public static string CreatePubKey(int duration, string configFile, string privateKey, string privatePassword = null)
        {
            RSA PubKey = RSA.Create();
            PubKey.ImportFromPem(privateKey.ToCharArray());
            string pubKeyPem = PubKey.ExportRSAPublicKeyPem();

            return pubKeyPem;
        }
    }
}
