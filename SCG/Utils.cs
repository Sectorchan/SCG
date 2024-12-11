using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
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
using System.Collections;
using System.Runtime.InteropServices.JavaScript;
using SCG.Forms;
using System.Data;
using System.Xml;
using System.Data.Common;
using System.Reflection.Metadata.Ecma335;
using System.Security.AccessControl;

namespace PL;

public class Utils
{

    public class Sql
    {
        /// <summary>
        /// Performs a SQL INSERT INTO into the given table
        /// </summary>        
        /// <param name="table">The corresponding table, depending on the type</param>
        /// <param name="Name">An unique application/server name</param>
        /// <param name="Privpass">Password for the private key</param>
        /// <param name="Privkey">The private key, as a PEM format string</param>
        /// <param name="Privbits">Default 4096, the same as on CreatePrivKey. Make sure thats the same parameter </param>
        /// <returns>Returns the amount of entries that written to the SQL database</returns>
        public static Result<int> InsertInto(SQLTable table, string Name, byte[] RSAPrivate, byte[] RSAPublic, int Privbits, int duration)
        {
            try
            {
                string _table = "";

                var _connectionString = new SqliteConnectionStringBuilder();
                _connectionString.Mode = SqliteOpenMode.ReadWriteCreate;
                _connectionString.DataSource = Global.database;
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
                string sql = $"INSERT INTO {_table} (name, private_bits, private_content, private_createDT, ss_duration, csr_cert, public_createDT) VALUES (@_Name, @_priv_bits, @_priv_content, @_priv_createDT, @_ss_duration, @_csr_cert, @_public_createDT)";
                using var command = new SqliteCommand(sql, connection);
                command.Parameters.AddWithValue("@_Name", Name);
                command.Parameters.AddWithValue("@_priv_bits", Privbits);
                command.Parameters.AddWithValue("@_priv_content", RSAPrivate);
                command.Parameters.AddWithValue("@_priv_createDT", DateTime.Now.ToString());
                command.Parameters.AddWithValue("@_ss_duration", duration);
                command.Parameters.AddWithValue("@_csr_cert", RSAPublic);
                command.Parameters.AddWithValue("@_public_createDT", DateTime.Now.ToString());

                int rowInserted = command.ExecuteNonQuery();

                return Result.Ok(rowInserted);
            }
            catch (Exception ex)
            {
                return Result.Fail(ex.Message);
            }

        }
        public static Result<int> InsertInto(SQLTable table, string Name, string Privkey, int Privbits)
        {
            try
            {
                string _table = "";
                var _connectionString = new SqliteConnectionStringBuilder();
                _connectionString.Mode = SqliteOpenMode.ReadWriteCreate;
                _connectionString.DataSource = Global.database;
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

                string sql = $"INSERT INTO {_table} (name, private_bits, private_content, private_createDT) VALUES (@_Name, @priv_bits, @priv_content, @priv_createDT)";

                using var command = new SqliteCommand(sql, connection);
                command.Parameters.AddWithValue("@_Name", Name);
                command.Parameters.AddWithValue("@priv_bits", Privbits);
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
        /// <param name="column">Which column should be searched for</param>
        /// <param name="table">Defines the table inside the database</param>
        /// <returns>Result<List<string>></returns>
        public static List<string> SqlSelect(string column, SQLTable table)
        {

            SqliteConnectionStringBuilder _connectionString = new SqliteConnectionStringBuilder();
            _connectionString.Mode = SqliteOpenMode.ReadWriteCreate;
            _connectionString.DataSource = Global.database;
            _connectionString.Password = null;
            string connectionString = _connectionString.ToString();
            using var connection = new SqliteConnection(connectionString);
            connection.Open();

            var sql = $"SELECT {column} FROM {table}";

            using var command = new SqliteCommand(sql, connection);
            using var reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                List<string> columns = new List<string>();
                if (column != "*")
                {
                    while (reader.Read())
                    {
                        columns.Add(reader.GetString(0));
                    }
                }
                else if (column == "*")
                {
                    while (reader.Read())
                    {
                        columns.Add(reader.GetString("id"));
                        columns.Add(reader.GetString("name"));
                        columns.Add(reader.GetString("private_bits"));
                        columns.Add(reader.GetString("private_content"));
                        columns.Add(reader.GetString("private_createDT"));
                        columns.Add(reader.GetString("ss_duration"));
                        columns.Add(reader.GetString("csr_cert"));
                        columns.Add(reader.GetString("public_cert"));
                        columns.Add(reader.GetString("public_createDT"));
                        columns.Add(reader.GetString("subj_country"));
                        columns.Add(reader.GetString("subj_state"));
                        columns.Add(reader.GetString("subj_location"));
                        columns.Add(reader.GetString("subj_organisation"));
                        columns.Add(reader.GetString("subj_orgaunit"));
                        columns.Add(reader.GetString("subj_commonname"));
                        columns.Add(reader.GetString("subj_email"));
                        columns.Add(reader.GetString("isCa"));
                        columns.Add(reader.GetString("not_pathlen"));
                        columns.Add(reader.GetString("depth"));
                        columns.Add(reader.GetString("canIssue"));
                    }
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
        /// Performs a SQL Select statement with objects as List type
        /// </summary>
        /// <param name="column">The selection what it should be queried.</param>
        /// <param name="table">The corresponding table, depending on the type</param>
        /// <returns>Returns the statement elements as a List with objects</returns>
        public static List<object> SqlSelectObject(string column, SQLTable table)
        {
            SqliteConnectionStringBuilder _connectionString = new SqliteConnectionStringBuilder();
            _connectionString.Mode = SqliteOpenMode.ReadWriteCreate;
            _connectionString.DataSource = Global.database;
            _connectionString.Password = null;
            string connectionString = _connectionString.ToString();
            using var connection = new SqliteConnection(connectionString);
            connection.Open();

            var sql = $"SELECT {column} FROM {table}";

            using var command = new SqliteCommand(sql, connection);
            using var reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                List<object> columns = new List<object>();
                while (reader.Read())
                {
                    columns.Add(reader["id"]);
                    columns.Add(reader["name"]);
                    columns.Add(reader["private_bits"]);
                    columns.Add(reader["private_content"]);
                    columns.Add(reader["private_createDT"]);
                    columns.Add(reader["ss_duration"]);
                    columns.Add(reader["csr_cert"]);
                    columns.Add(reader["public_cert"]);
                    columns.Add(reader["public_createDT"]);
                    columns.Add(reader["subj_country"]);
                    columns.Add(reader["subj_state"]);
                    columns.Add(reader["subj_location"]);
                    columns.Add(reader["subj_organisation"]);
                    columns.Add(reader["subj_orgaunit"]);
                    columns.Add(reader["subj_commonname"]);
                    columns.Add(reader["subj_email"]);
                    columns.Add(reader["isCa"]);
                    columns.Add(reader["not_pathlen"]);
                    columns.Add(reader["depth"]);
                    columns.Add(reader["canIssue"]);
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
        /// <param name="column">Which column should be searched for</param>
        /// <param name="table">Defines the table inside the database</param>
        /// <param name="searchColumn">In which column should be searched</param>
        /// <param name="searchValue">The Value that should be searched for in the searchColumn</param>
        /// <returns>Returns the string if found</returns>
        public static Result<byte[]> SelectWhereByte(string column, SQLTable table, string searchColumn, string searchValue)
        {
            try
            {
                SqliteConnectionStringBuilder _connectionString = new SqliteConnectionStringBuilder();
                _connectionString.Mode = SqliteOpenMode.ReadWriteCreate;
                _connectionString.DataSource = Global.database;
                _connectionString.Password = null;
                string connectionString = _connectionString.ToString();
                using var connection = new SqliteConnection(connectionString);
                connection.Open();
                var sql = $"SELECT {column} FROM {table} WHERE {searchColumn}=@_searchValue"; // geht nicht 
                using var command = new SqliteCommand(sql, connection);

                command.Parameters.AddWithValue("@_searchValue", searchValue);
                using var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    switch (column)
                    {
                        case "private_content":
                            while (reader.Read())
                            {
                                byte[] privKey = reader[column] as byte[];
                                return Result.Ok(privKey);
                            }
                            break;
                    }
                    return Result.Fail("No Case selected");
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
        public static Result<string> SelectWhereString(string column, SQLTable table, string searchColumn, string searchValue)
        {
            try
            {
                SqliteConnectionStringBuilder _connectionString = new SqliteConnectionStringBuilder();
                _connectionString.Mode = SqliteOpenMode.ReadWriteCreate;
                _connectionString.DataSource = Global.database;
                _connectionString.Password = null;
                string connectionString = _connectionString.ToString();
                using var connection = new SqliteConnection(connectionString);
                connection.Open();
                var sql = $"SELECT {column} FROM {table} WHERE {searchColumn}=@_searchValue"; // geht nicht 
                using var command = new SqliteCommand(sql, connection);

                command.Parameters.AddWithValue("@_searchValue", searchValue);
                using var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    string readString = "";
                    while (reader.Read())
                    {
                        readString = reader.GetString(0);

                    }
                    return Result.Ok(readString);
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

        public static Result<List<object>> SelectWhereObject(string[] column1, SQLTable table, string searchColumn, string searchValue)
        {
            try
            {
                SqliteConnectionStringBuilder _connectionString = new SqliteConnectionStringBuilder();
                _connectionString.Mode = SqliteOpenMode.ReadWriteCreate;
                _connectionString.DataSource = Global.database;
                _connectionString.Password = null;
                string connectionString = _connectionString.ToString();
                using var connection = new SqliteConnection(connectionString);
                connection.Open();

                string column = string.Join(",", column1); // adds a comma after each element, except the last one for the SQL query
                string sql = $"SELECT {column} FROM {table} WHERE {searchColumn}=@_searchValue";

                using var command = new SqliteCommand(sql, connection);
                command.Parameters.AddWithValue("@_searchValue", searchValue);
                using var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    List<object> columns = new List<object>();
                    while (reader.Read())
                    {
                        foreach (string row in column1)
                        {
                            columns.Add(reader[row]);
                        }
                    }
                    return Result.Ok(columns);
                }
                else
                {
                    return Result.Fail("No Server found");
                }
            }
            catch (Exception ex)
            {
                return Result.Fail(ex.ToString());
            }

        }

        /// <summary>
        /// Performs a SQL Update statement
        /// </summary>
        /// <param name="table">Defines the table inside the database</param>
        /// <param name="publicDuration">Set the duration of the public certificate in month</param>
        /// <param name="publicKey">The publicKey that shall be written into the database</param>
        /// <param name="searchTerm">Select the server</param>
        /// <param name="addTime">Adds the time for the time column</param>
        /// <returns></returns>
        //public static Result<int> Update(SQLTable table, int publicDuration, byte[] publicKey, string searchTerm, string addTime = null)
        //{
        //    try
        //    {
        //        SqliteConnectionStringBuilder _connectionString = new SqliteConnectionStringBuilder();
        //        _connectionString.Mode = SqliteOpenMode.ReadWriteCreate;
        //        _connectionString.DataSource = Global.database;
        //        _connectionString.Password = null;
        //        string connectionString = _connectionString.ToString();
        //        using var connection = new SqliteConnection(connectionString);
        //        connection.Open();

        //        int rowInserted;

        //        if (addTime == null)
        //        {
        //            string sql = $"UPDATE {table} SET public_duration = @_publicDuration, public_content = @_publicKey WHERE name = @_searchTerm";

        //            using var command = new SqliteCommand(sql, connection);
        //            command.Parameters.AddWithValue("@_publicDuration", publicDuration);
        //            command.Parameters.AddWithValue("@_publicKey", publicKey);
        //            command.Parameters.AddWithValue("@_searchTerm", searchTerm);
        //            rowInserted = command.ExecuteNonQuery();
        //        }
        //        else
        //        {
        //            string sql = $"UPDATE {table} SET public_duration = @_publicDuration, public_content = @_publicKey, public_createDT = @_addTime WHERE name = @_searchTerm";

        //            using var command = new SqliteCommand(sql, connection);
        //            command.Parameters.AddWithValue("@_publicDuration", publicDuration);
        //            command.Parameters.AddWithValue("@_publicKey", publicKey);
        //            command.Parameters.AddWithValue("@_addTime", addTime);
        //            command.Parameters.AddWithValue("@_searchTerm", searchTerm);
        //            rowInserted = command.ExecuteNonQuery();
        //        }
        //        return Result.Ok(rowInserted);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Result.Fail(ex.Message);
        //    }
        //}
        public static Result<int> Update(SQLTable table, byte[] privateKey, byte[] publicKey, string searchTerm, string subj_country, string subj_state, string subj_location,
                string subj_organisation, string subj_orgaunit, string subj_commonname, string subj_email, bool isCa, bool pathLen, int depth, bool canIssue, bool updateTimePub)
        {
            try
            {
                int iIsCa = Convert.ToInt16(isCa);
                int ipathLen = Convert.ToInt16(pathLen);
                int iCanIssue = Convert.ToInt16(canIssue);
                string sql;

                SqliteConnectionStringBuilder _connectionString = new SqliteConnectionStringBuilder();
                _connectionString.Mode = SqliteOpenMode.ReadWriteCreate;
                _connectionString.DataSource = Global.database;
                _connectionString.Password = null;
                string connectionString = _connectionString.ToString();
                using var connection = new SqliteConnection(connectionString);
                connection.Open();
                if (!updateTimePub)
                {
                    sql = $"UPDATE {table} SET subj_country = @_subj_country, subj_state = @_subj_state, subj_location = @_subj_location, subj_organisation = @_subj_organisation, subj_orgaunit = @_subj_orgaunit, subj_commonname = @_subj_commonname, subj_email = @_subj_email, isCa = @_isCa" +
                    $", not_pathlen = @_pathLen, depth = @_depth, canIssue = @_ICanIssue WHERE name = @_searchTerm";
                }
                else
                {
                    sql = $"UPDATE {table} SET subj_country = @_subj_country, subj_state = @_subj_state, subj_location = @_subj_location, subj_organisation = @_subj_organisation, subj_orgaunit = @_subj_orgaunit, subj_commonname = @_subj_commonname, subj_email = @_subj_email, isCa = @_isCa" +
                    $", not_pathlen = @_pathLen, depth = @_depth, canIssue = @_ICanIssue, public_createDT = @_public_createDT WHERE name = @_searchTerm";
                }
                using var command = new SqliteCommand(sql, connection);
                command.Parameters.AddWithValue("@_subj_country", subj_country);
                command.Parameters.AddWithValue("@_subj_state", subj_state);
                command.Parameters.AddWithValue("@_subj_location", subj_location);
                command.Parameters.AddWithValue("@_subj_organisation", subj_organisation);
                command.Parameters.AddWithValue("@_subj_orgaunit", subj_orgaunit);
                command.Parameters.AddWithValue("@_subj_commonname", subj_commonname);
                command.Parameters.AddWithValue("@_subj_email", subj_email);
                command.Parameters.AddWithValue("@_isCa", iIsCa);
                command.Parameters.AddWithValue("@_pathLen", ipathLen);
                command.Parameters.AddWithValue("@_depth", depth);
                command.Parameters.AddWithValue("@_ICanIssue", iCanIssue);
                if (updateTimePub)
                {
                    command.Parameters.AddWithValue("@_public_createDT", DateTime.Now.ToString());
                }
                command.Parameters.AddWithValue("@_searchTerm", searchTerm);
                int rowInserted = command.ExecuteNonQuery();

                return Result.Ok(rowInserted);
            }
            catch (Exception ex)
            {
                return Result.Fail(ex.Message);
            }
        }
        public static Result<int> Update(SQLTable table, string publicKey, string searchTerm, string searchColumn)
        {
            try
            {
                SqliteConnectionStringBuilder _connectionString = new SqliteConnectionStringBuilder();
                _connectionString.Mode = SqliteOpenMode.ReadWrite;
                _connectionString.DataSource = Global.database;
                _connectionString.Password = null;
                string connectionString = _connectionString.ToString();
                using var connection = new SqliteConnection(connectionString);
                connection.Open();

                string sql = $"UPDATE {table} SET public_cert = @_publicKey, public_createDT = @_public_createDT WHERE {searchColumn} = @_searchTerm";

                string public_createDT = DateTime.Now.ToString();
                using var command = new SqliteCommand(sql, connection);
                command.Parameters.AddWithValue("@_publicKey", publicKey);
                command.Parameters.AddWithValue("@_public_createDT", public_createDT);
                command.Parameters.AddWithValue("@_searchTerm", searchTerm);

                int rowUpdated = command.ExecuteNonQuery();

                return Result.Ok(rowUpdated);
            }
            catch (Exception ex)
            {
                return Result.Fail(ex.ToString());

            }
        }
        public static Result<int> Update(SQLTable table, string searchTerm, string subj_country, string subj_state, string subj_location,
                                         string subj_organisation, string subj_orgaunit, string subj_commonname, string subj_email)
        {
            try
            {
                SqliteConnectionStringBuilder _connectionString = new SqliteConnectionStringBuilder();
                _connectionString.Mode = SqliteOpenMode.ReadWriteCreate;
                _connectionString.DataSource = Global.database;
                _connectionString.Password = null;
                string connectionString = _connectionString.ToString();
                using var connection = new SqliteConnection(connectionString);
                connection.Open();

                string sql = "";
                if (table == SQLTable.ca)
                {
                    sql = $"UPDATE {table} SET subj_country = @_subj_country, subj_state = @_subj_state, subj_location = @_subj_location, subj_organisation = @_subj_organisation, subj_orgaunit = @_subj_orgaunit, subj_commonname = @_subj_commonname, subj_email = @_subj_email WHERE name = @_searchTerm";

                }
                else if (table == SQLTable.intermediate)
                {
                    sql = $"UPDATE {table} SET subj_country = @_subj_country, subj_state = @_subj_state, subj_location = @_subj_location, subj_organisation = @_subj_organisation, subj_orgaunit = @_subj_orgaunit, subj_commonname = @_subj_commonname, subj_email = @_subj_email WHERE name = @_searchTerm";

                }
                else
                {
                    sql = $"UPDATE {table} SET subj_country = @_subj_country, subj_state = @_subj_state, subj_location = @_subj_location, subj_orgaunit = @_subj_orgaunit, subj_commonname = @_subj_commonname, subj_email = @_subj_email WHERE name = @_searchTerm";
                }

                using var command = new SqliteCommand(sql, connection);
                command.Parameters.AddWithValue("@_subj_country", subj_country);
                command.Parameters.AddWithValue("@_subj_state", subj_state);
                command.Parameters.AddWithValue("@_subj_location", subj_location);
                command.Parameters.AddWithValue("@_subj_organisation", subj_organisation);
                command.Parameters.AddWithValue("@_subj_orgaunit", subj_orgaunit);
                command.Parameters.AddWithValue("@_subj_commonname", subj_commonname);
                command.Parameters.AddWithValue("@_subj_email", subj_email);
                command.Parameters.AddWithValue("@_searchTerm", searchTerm);

                int rowInserted = command.ExecuteNonQuery();
                return Result.Ok(rowInserted);
            }
            catch (Exception ex)
            {
                return Result.Fail(ex.Message);
            }
        }
        public static Result<int> Update(SQLTable table, string searchTerm, bool isCa, bool noPaLen, int depth, bool canIssue)
        {
            try
            {
                SqliteConnectionStringBuilder _connectionString = new SqliteConnectionStringBuilder();
                _connectionString.Mode = SqliteOpenMode.ReadWriteCreate;
                _connectionString.DataSource = Global.database;
                _connectionString.Password = null;
                string connectionString = _connectionString.ToString();
                using var connection = new SqliteConnection(connectionString);
                connection.Open();
                string sql = $"UPDATE {table} SET isCa = @_isCa, not_pathlen = @_not_pathLen, depth = @_depth, canIssue = @_canIssue WHERE name = @_searchTerm";
                using var command = new SqliteCommand(sql, connection);
                command.Parameters.AddWithValue("@_isCa", isCa);
                command.Parameters.AddWithValue("@_not_pathLen", noPaLen);
                command.Parameters.AddWithValue("@_depth", depth);
                command.Parameters.AddWithValue("@_canIssue", canIssue);

                command.Parameters.AddWithValue("@_searchTerm", searchTerm);

                int rowInserted = command.ExecuteNonQuery();
                return Result.Ok(rowInserted);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return Result.Fail(ex.Message);
            }
        }

        public static Result<int> Update(SQLTable table, string searchTerm, string selfSignedCert, int duration)
        {
            try
            {
                SqliteConnectionStringBuilder _connectionString = new SqliteConnectionStringBuilder();
                _connectionString.Mode = SqliteOpenMode.ReadWriteCreate;
                _connectionString.DataSource = Global.database;
                _connectionString.Password = null;
                string connectionString = _connectionString.ToString();
                using var connection = new SqliteConnection(connectionString);
                connection.Open();

                string sql = $"UPDATE {table} SET ss_cert = @_ss_cert, ss_createDT = @_ss_createDT, ss_duration = @_ss_duration WHERE name = @_searchTerm";
                using var command = new SqliteCommand(sql, connection);
                command.Parameters.AddWithValue("@_ss_cert", selfSignedCert);
                command.Parameters.AddWithValue("@_ss_createDT", Convert.ToString(DateTime.Now));
                command.Parameters.AddWithValue("@_searchTerm", searchTerm);
                command.Parameters.AddWithValue("@_ss_duration", duration);

                int rowInserted = command.ExecuteNonQuery();
                return Result.Ok(rowInserted).WithSuccess("Update");

            }
            catch (Exception ex)
            {
                return Result.Fail(ex.Message);
            }
        }
    }


    public class Certs
    {
        private readonly bool writeFile = true;
        private readonly string privateKeyPath = "privateKey.pem";

        public static string ConvertToPem(byte[] keyBytes, string header)
        {
            string base64Key = Convert.ToBase64String(keyBytes);
            string pem = $"-----BEGIN {header}-----\n";

            // Füge Zeilenumbrüche nach jeweils 64 Zeichen ein
            for (int i = 0; i < base64Key.Length; i += 64)
            {
                pem += base64Key.Substring(i, Math.Min(64, base64Key.Length - i)) + "\n";
            }

            pem += $"-----END {header}-----";
            return pem;
        }

        /// <summary>
        /// Generates the Public- and Privatekey
        /// </summary>
        /// <param name="keyPair">Keysize in bits</param>
        /// <returns>The Public and Privatekey</returns>
        public static Result<RSA> GenCertPair(int keySize)
        {
            using (RSA rsa = RSA.Create(keySize))
            {
                rsa.KeySize = keySize;
                rsa.ExportRSAPrivateKey();
                rsa.ExportRSAPublicKey();
                return Result.Ok(rsa);
            }
        }

        /// <summary>
        /// Generating the private key 
        /// </summary>
        /// <param name="KeySize">Default = 4096; Represents the size, in bits, of the key modulus used by the asymmetric algorithm.</param>
        /// <returns>The privatekey in PEM format as String</returns>
        public static Result<byte[]> CreatePrivKey(int keySize)
        {
            using (RSA rsa = RSA.Create(keySize))
            {
                byte[] privateKey = rsa.ExportRSAPrivateKey();

                return Result.Ok(privateKey);
            }
        }
        /// <summary>
        /// Generate the public key (obsolete?)
        /// </summary>
        /// <returns>Returns the public key in PEM format</returns>
        public static Result<byte[]> CreatePubKey(int keySize, byte[] privateKey)
        {
            using (RSA rsa = RSA.Create(keySize))
            {
                rsa.ImportRSAPrivateKey(privateKey, out _);
                byte[] publicKey = rsa.ExportRSAPublicKey();


                return Result.Ok(publicKey);
            }
        }
        /// <summary>
        /// Generates the self signed file
        /// </summary>
        /// <param name="keySize">Keysize in bits</param>
        /// <param name="privKey">The privatekey as byte[]</param>
        /// <param name="subjects">Distingused name as string</param>
        /// <param name="pubKey">The publickey as byte[]</param>
        public static Result<byte[]> CreateSSCert(SQLTable table, int keySize, X500DistinguishedName subject, byte[] privKey, byte[] pubKey, bool isCa, bool not_pathlen, int depth, bool canIssue, int duration, int serialnumber)
        {
            try
            {
                using (RSA rsa = RSA.Create(keySize))
                {
                    rsa.ImportRSAPrivateKey(privKey, out _);
                    //rsa.ImportRSAPublicKey(pubKey, out _);  
                    var request = new CertificateRequest(subject, rsa, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
                    request.CertificateExtensions.Add(new X509BasicConstraintsExtension(isCa, not_pathlen, depth, true));
                    request.CertificateExtensions.Add(new X509KeyUsageExtension(X509KeyUsageFlags.KeyCertSign | X509KeyUsageFlags.CrlSign | X509KeyUsageFlags.DigitalSignature, true)); // Signatur- und CRL rights
                    request.CertificateExtensions.Add(new X509SubjectKeyIdentifierExtension(request.PublicKey, false));
                    byte[] serialNumber = { Convert.ToByte(serialnumber) };

                    // Zertifikat erstellen und signieren
                    DateTimeOffset notBefore = DateTimeOffset.UtcNow;
                    DateTimeOffset notAfter = notBefore.AddMonths(duration);

                    var certificate = request.Create(
                        subject,
                        X509SignatureGenerator.CreateForRSA(rsa, RSASignaturePadding.Pkcs1),
                        notBefore,
                        notAfter,
                        serialNumber);

                    //X509Certificate2 certificate = request.CreateSelfSigned(notBefore, notAfter);
                    byte[] export = certificate.Export(X509ContentType.Cert);
                    //byte[] export = certificate.Export(X509ContentType.Pfx, "test");


                    return Result.Ok(export);
                }
            }
            catch (Exception ex)
            {
                return Result.Fail($"Fehler test: {ex}").WithError("Test");
            }
        }
        public static Result<byte[]> CreateCaSignCert(SQLTable table, X509Certificate2 caCert, int keySize, X500DistinguishedName subject, bool isCa, bool not_pathlen, int depth, bool canIssue, int duration, int serialnumber)
        {
            try
            {

                using (RSA caPrivateKey = caCert.GetRSAPrivateKey())
                {
                    // RSA-Schlüssel für das Intermediate-Zertifikat generieren
                    using (RSA intermediateKey = RSA.Create(keySize))
                    {
                        // Zertifikatsanfrage für das Intermediate-Zertifikat erstellen
                        var intermediateRequest = new CertificateRequest(
                            subject,
                            intermediateKey,
                            HashAlgorithmName.SHA256,
                            RSASignaturePadding.Pkcs1);

                        // Erweiterungen für das Intermediate-Zertifikat hinzufügen
                        intermediateRequest.CertificateExtensions.Add(new X509BasicConstraintsExtension(isCa, not_pathlen, depth, true)); // CA: true
                        intermediateRequest.CertificateExtensions.Add(new X509KeyUsageExtension(X509KeyUsageFlags.KeyCertSign | X509KeyUsageFlags.CrlSign, true)); // Signatur- und CRL-Rechte
                        intermediateRequest.CertificateExtensions.Add(new X509SubjectKeyIdentifierExtension(intermediateRequest.PublicKey, false));

                        // Intermediate-Zertifikat mit der CA signieren (5 Jahre Gültigkeit)
                        var intermediateCertificate = intermediateRequest.Create(
                            caCert,
                            DateTimeOffset.UtcNow.AddDays(-1), // Gültig ab
                            DateTimeOffset.UtcNow.AddMonths(duration), // Gültig bis
                            new byte[] { Convert.ToByte(serialnumber) }); // Seriennummer (kann beliebig sein)

                        byte[] export = intermediateCertificate.Export(X509ContentType.Cert);

                        return Result.Ok(export);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static Result<X500DistinguishedName> DNBuilder(string twoLetterCode, string stateOrProvinceName, string localityName, string organizationName, string organizationalUnitName, string commonName, string emailAddress)
        {
            try
            {
                X500DistinguishedNameBuilder DNs = new X500DistinguishedNameBuilder();

                DNs.AddCountryOrRegion(Convert.ToString(twoLetterCode));
                DNs.AddStateOrProvinceName(Convert.ToString(stateOrProvinceName));
                DNs.AddLocalityName(Convert.ToString(localityName));
                DNs.AddOrganizationName(Convert.ToString(organizationName));
                DNs.AddOrganizationalUnitName(Convert.ToString(organizationalUnitName));
                DNs.AddCommonName(Convert.ToString(commonName));
                DNs.AddEmailAddress(Convert.ToString(emailAddress));
                var build = DNs.Build();

                return Result.Ok(build).WithSuccess("DNBuilder");
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex), "DNBuilder failed!");
                return null;
            }
        }
        private byte[] GenerateRandomSerialNumber(int byteLength)
        {
            if (byteLength < 1)
                throw new ArgumentException("Die Länge der Seriennummer muss mindestens 1 Byte sein.", nameof(byteLength));

            byte[] serialNumber = new byte[byteLength];
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(serialNumber);
            }

            // Sicherstellen, dass das höchste Bit nicht gesetzt ist (positiv)
            serialNumber[0] &= 0x7F;

            return serialNumber;
        }
    }
    public class Tools
    {
        public static List<string> ObjectToString(List<object> obj)
        {
            List<string> list = new List<string>();

            foreach (object o in obj)
            {
                list.Add(Convert.ToString(o));
            }

            return list;
        }
    }

}

