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

namespace PL;
public class Utils
{
    public class test
    {

    }
    public class Sql
    {
        /// <summary>
        /// Performs a SQL INSERT INTO into the given table
        /// </summary>
        /// <param name="database">The SQLite database which shall be used</param>
        /// <param name="table">The corresponding table, depending on the type</param>
        /// <param name="Name">An unique application/server name</param>
        /// <param name="Privpass">Password for the private key</param>
        /// <param name="Privkey">The private key, as a PEM format string</param>
        /// <param name="Privbits">Default 4096, the same as on CreatePrivKey. Make sure thats the same parameter </param>
        /// <returns>Returns the amount of entries that written to the SQL database</returns>
        public static Result<int> InsertInto(string database, SQLTable table, string Name, byte[] RSAPrivate, byte[] RSAPublic, int Privbits, int duration)
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
                string sql = $"INSERT INTO {_table} (name, private_bits, private_content, private_createDT, public_duration, public_csr, public_createDT) VALUES (@_Name, @_priv_bits, @_priv_content, @_priv_createDT, @_public_duration, @_public_csr, @_public_createDT)";
                using var command = new SqliteCommand(sql, connection);
                command.Parameters.AddWithValue("@_Name", Name);
                command.Parameters.AddWithValue("@_priv_bits", Privbits);
                command.Parameters.AddWithValue("@_priv_content", RSAPrivate);
                command.Parameters.AddWithValue("@_priv_createDT", DateTime.Now.ToString());
                command.Parameters.AddWithValue("@_public_duration", duration);
                command.Parameters.AddWithValue("@_public_csr", RSAPublic);
                command.Parameters.AddWithValue("@_public_createDT", DateTime.Now.ToString());
                
                int rowInserted = command.ExecuteNonQuery();

                return Result.Ok(rowInserted);
            }
            catch (Exception ex)
            {
                return Result.Fail(ex.Message);
            }

        }
        public static Result<int> InsertInto(string database, SQLTable table, string Name, string Privpass, byte[] Privkey, int Privbits = 4096)
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

                string sql = $"INSERT INTO {_table} (name, private_bits, private_pass, private_content, private_createDT) VALUES (@_Name, @priv_bits, @priv_pass, @priv_content, @priv_createDT)";

                using var command = new SqliteCommand(sql, connection);
                command.Parameters.AddWithValue("@_Name", Name);
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
        public static Result<byte[]> SelectWhere(string database, string column, SQLTable table, string searchColumn, string searchValue)
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
                var sql = $"SELECT {column} FROM {table} WHERE {searchColumn}=@_searchValue"; // geht nicht 
                using var command = new SqliteCommand(sql, connection);

                command.Parameters.AddWithValue("@_searchValue", searchValue);
                using var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        byte[] privKey = Convert.FromBase64String(reader.GetString(0));
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
        /// <param name="database">Defines the target database</param>
        /// <param name="table">Defines the table inside the database</param>
        /// <param name="publicDuration">Set the duration of the public certificate in month</param>
        /// <param name="publicKey">The publicKey that shall be written into the database</param>
        /// <param name="searchTerm">Select the server</param>
        /// <param name="addTime">Adds the time for the time column</param>
        /// <returns></returns>
        //public static Result<int> Update(string database, SQLTable table, int publicDuration, byte[] publicKey, string searchTerm, string addTime = null)
        //{
        //    try
        //    {
        //        SqliteConnectionStringBuilder _connectionString = new SqliteConnectionStringBuilder();
        //        _connectionString.Mode = SqliteOpenMode.ReadWriteCreate;
        //        _connectionString.DataSource = database;
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
        public static Result<int> Update(string database, SQLTable table, byte[] privateKey, byte[] publicKey, string searchTerm, string subj_country, string subj_state, string subj_location,
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
                _connectionString.DataSource = database;
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
        /// <summary>
        /// Performs a SQL Update statement
        /// </summary>
        /// <param name="database">Defines the target database</param>
        /// <param name="table">Defines the table inside the database</param>
        /// <param name="publicDuration">Set the duration of the public certificate in month</param>
        /// <param name="publicKey">The publicKey that shall be written into the database</param>
        /// <param name="searchTerm">Select the server</param>
        /// <param name="subj_country"></param>
        /// <param name="subj_state"></param>
        /// <param name="subj_location"></param>
        /// <param name="subj_orgaunit"></param>
        /// <param name="subj_commonname"></param>
        /// <param name="subj_email"></param>
        /// <returns>The number if updated rows</returns>
        public static Result<int> Update(string database, SQLTable table, string searchTerm, string subj_country, string subj_state, string subj_location,
                                         string subj_organisation, string subj_orgaunit, string subj_commonname, string subj_email)
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

                string sql = "";

                if (table == SQLTable.ca)
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
                command.Parameters.AddWithValue("@_sub_organisation", subj_organisation);
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
    }
    public class Certs
    {

        public static Result<RSA> GenCertPair(int keyPair)
        {
           
            RSA rsa = RSA.Create(keyPair); // Using a larger key size for a CA (e.g., 4096 bits)
           
                rsa.ExportRSAPrivateKey();
                rsa.ExportRSAPublicKey();
            

                return Result.Ok(rsa);
        }
        /// <summary>
        /// Generating the private key
        /// </summary>
        /// <param name="KeySize">Default = 4096; Represents the size, in bits, of the key modulus used by the asymmetric algorithm.</param>
        /// <returns>The privatekey in PEM format as String</returns>
        public static byte[] CreatePrivKey(int KeySize = 4096)
        {
            RSA rsa = RSA.Create(KeySize);
            var Privkey = rsa.ExportRSAPrivateKey();
            return Privkey;
        }

        /// <summary>
        /// Generate the public key
        /// </summary>
        /// <returns>Returns the public key in PEM format</returns>
        public static byte[] CreatePubKey(int duration, byte[] privateKey)
        {
            RSA PubKey = RSA.Create();
            PubKey.ImportRSAPrivateKey(privateKey, out int _);

            byte[] pubKey = PubKey.ExportRSAPublicKey();

            return pubKey;
        }
        public void CertificateRequest(int keySize, string privKey, string[] subjects, string pubKey, HashAlgorithmName hash, RSASignaturePadding RSASigPad)
        {
            
            RSA rsa = RSA.Create(keySize);
            rsa.ImportFromPem(privKey.ToCharArray());
            
            string subject = "CN=My Certificate Authority, O=My Org, C=US";
            var request = new CertificateRequest(subject, rsa, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
        }
    }

    public void SelfSigned()
    {
    }
}
