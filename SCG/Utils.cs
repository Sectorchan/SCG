using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using FluentResults;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using static SCG.Ssql;
using System.Diagnostics.Contracts;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        /// <returns></returns>
        public static int InsertInto(string database, SQLTable table, string CaName, string Privpass, string Privkey, int Privbits = 4096)
        {
            try
            {
                string _table = "";
                using var connection = new SqliteConnection(database);
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
                var sql = $"INSERT INTO {_table} (name, private_bits, private_pass, private_content, private_createDT) VALUES (@Ca_Name, @priv_bits, @priv_pass, @priv_content, @priv_createDT)";

                using var command = new SqliteCommand(sql, connection);
                command.Parameters.AddWithValue("@Ca_Name", CaName);
                command.Parameters.AddWithValue("@priv_bits", Privbits);
                command.Parameters.AddWithValue("@priv_pass", Privpass);
                command.Parameters.AddWithValue("@priv_content", Privkey);
                command.Parameters.AddWithValue("@priv_createDT", DateTime.Now.ToString());
                int rowInserted = command.ExecuteNonQuery();

                return rowInserted;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "EXCEPTION", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 666;
            }
        }

        /// <summary>
        /// Performs a SQL SELECT statement
        /// </summary>
        /// <param name="database"></param>
        /// <param name="column"></param>
        /// <param name="table"></param>
        /// <returns>Result<List<string>></returns>
        public static List<string> SqlSelect(string database, string column, SQLTable table)
        {
            using var connection = new SqliteConnection(database);
            string _table = "ca";
            connection.Open();
            var sql = $"SELECT {column} FROM {_table}";
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
    }
}
