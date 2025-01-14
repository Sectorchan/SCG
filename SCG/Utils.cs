﻿using FluentResults;
using Microsoft.Data.Sqlite;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Net.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using WinFormsApp1;
using static PL.Utils.Tools;
using static SCG.Ssql;

namespace PL;

public class Utils
{
    private const string serverAuth2 = "1.3.6.1.5.5.7.3.1";
    private const string clientAuth2 = "1.3.6.1.5.5.7.3.2";

    public class Sql
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="table">The corresponding table, depending on the type</param>
        /// <param name="name">An unique application/server name</param>
        /// <param name="privKey">The privateKey in PEM format</param>
        /// <param name="privbits">Default 4096, the same as on CreatePrivKey. Make sure thats the same parameter</param>
        /// <returns>Returns the amount of entries that written to the SQL database.</returns>
        public static int InsertInto(certType table, string name, string privKey, int keySize)
        {
            try
            {
                string _table = string.Empty;
                var _connectionString = new SqliteConnectionStringBuilder();
                _connectionString.Mode = SqliteOpenMode.ReadWriteCreate;
                _connectionString.DataSource = Global.database;
                _connectionString.Password = null;
                string connectionString = _connectionString.ToString();
                using var connection = new SqliteConnection(connectionString);
                connection.Open();

                switch (table)
                {
                    case (certType.ca):
                        _table = "ca";
                        break;
                    case (certType.intermediate):
                        _table = "intermediate";
                        break;
                    case (certType.server):
                        _table = "server";
                        break;
                    case (certType.user):
                        _table = "user";
                        break;
                }

                string sql = $"INSERT INTO {_table} (name, keySize, private_key, private_createDT) VALUES (@_name, @_keySize, @_private_key, @_priv_createDT)";

                using var command = new SqliteCommand(sql, connection);
                command.Parameters.AddWithValue("@_name", name);
                command.Parameters.AddWithValue("@_keySize", keySize);
                command.Parameters.AddWithValue("@_private_key", privKey);
                command.Parameters.AddWithValue("@_priv_createDT", DateTime.Now.ToString());
                int rowInserted = command.ExecuteNonQuery();

                return rowInserted;
            }
            catch (Exception ex)
            {
                if (ex == null)
                {
                    return 0; // Result.Fail("Possible wrong SQL credentials");
                }
                else
                {
                    return 0; // Result.Fail(ex.Message);
                }
            }
        }

        /// <summary>
        /// Performs a SQL INSERT INTO into the given table
        /// </summary>        
        /// <param name="table">The corresponding table, depending on the type</param>
        /// <param name="name">An unique application/server name</param>
        /// <param name="privpass">Password for the private key</param>
        /// <param name="privkey">The private key, as a PEM format string</param>
        /// <param name="keySize">Default 4096, the same as on CreatePrivKey. Make sure thats the same parameter </param>
        /// <returns>Returns the amount of entries that written to the SQL database</returns>
        public static Result<int> InsertInto(SQLTable table, string name, byte[] RSAPrivate, byte[] RSAPublic, int keySize, int duration)
        {
            try
            {
                string _table = string.Empty;

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
                string sql = $"INSERT INTO {_table} (name, private_bits, private_key, private_createDT, ss_duration, csr_cert, public_createDT) VALUES (@_Name, @_keySize, @_private_key, @_priv_createDT, @_ss_duration, @_csr_cert, @_public_createDT)";
                using var command = new SqliteCommand(sql, connection);
                command.Parameters.AddWithValue("@_Name", name);
                command.Parameters.AddWithValue("@_keySize", keySize);
                command.Parameters.AddWithValue("@_private_key", RSAPrivate);
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

        /// <summary>
        /// Performs a SQL SELECT statement
        /// </summary>
        /// <param name="column">Which column should be searched for</param>
        /// <param name="table">Defines the table inside the database</param>
        /// <returns>Result<List<string>></returns>
        public static List<string> SqlSelect(string column, certType table)
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
                        columns.Add(reader.GetString("private_key"));
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
                        columns.Add(reader.GetString("critical"));
                    }
                }
                return columns;
            }
            else
            {
                MessageBox.Show("No Server found", string.Empty, MessageBoxButtons.OK);
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
                    columns.Add(reader["private_key"]);
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
                    columns.Add(reader["critical"]);
                }
                return columns;
            }
            else
            {
                MessageBox.Show("No Server found", string.Empty, MessageBoxButtons.OK);
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
        public static byte[] SelectWhereByte(string column, certType table, string searchColumn, string searchValue)
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
                        case "private_key":
                            while (reader.Read())
                            {
                                byte[] privKey = reader[column] as byte[];
                                return privKey;
                            }
                            break;
                        case "ss_cert":
                            while (reader.Read())
                            {
                                byte[] privKey = reader[column] as byte[];
                                return privKey;
                            }
                            break;
                    }
                    return null;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

        }
        public static string SelectWhereString(certType table, string resultColumn, string searchColumn, string searchValue)
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
                var sql = $"SELECT {resultColumn} FROM {table} WHERE {searchColumn}=@_searchValue"; // geht nicht 
                using var command = new SqliteCommand(sql, connection);

                command.Parameters.AddWithValue("@_searchValue", searchValue);
                using var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    string readString = string.Empty;
                    while (reader.Read())
                    {
                        readString = reader.GetString(0);

                    }
                    connection.Close();
                    return readString;
                }
                else
                {
                    connection.Close();
                    return sql;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return ex.Message;
            }

        }
        public static string SelectBasicConstraints(certType table, string resultColumn, string searchColumn, string searchValue)
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
                var sql = $"SELECT {resultColumn} FROM {table} WHERE {searchColumn}=@_searchValue"; // geht nicht 
                using var command = new SqliteCommand(sql, connection);

                command.Parameters.AddWithValue("@_searchValue", searchValue);
                using var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    string readString = string.Empty;
                    while (reader.Read())
                    {
                        readString = reader.GetString(0);

                    }
                    connection.Close();
                    return readString;
                }
                else
                {
                    connection.Close();
                    return sql;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return ex.Message;
            }

        }
        public static byte[] SelectSsCert(certType table, string column, string searchColumn, string searchValue)
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

                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // `byte_column` auslesen
                        byte[] byteArray = (byte[])reader["ss_cert"];

                        return byteArray;
                    }
                }
                return null;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

        }

        public static List<object> SelectWhereObject(certType table, string[] column1, string searchColumn, string searchValue)
        {
            try
            {
                List<object> columns = new List<object>();
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
                    //List<object> columns = new List<object>();
                    while (reader.Read())
                    {
                        foreach (string row in column1)
                        {
                            columns.Add(reader[row]);
                        }
                    }
                    return columns;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public static Result<List<object>> SelectWhereObject(string[] column1, certType table, string searchColumn, string searchValue)
        {
            try
            {
                List<object> columns = new List<object>();
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
                    //List<object> columns = new List<object>();
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
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
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
        public static Result<int> Update(certType table, byte[] privateKey, byte[] publicKey, string searchTerm, string subj_country, string subj_state, string subj_location,
                string subj_organisation, string subj_orgaunit, string subj_commonname, string subj_email, bool isCa, bool pathLen, int depth, bool critical, bool updateTimePub)
        {
            try
            {
                int iIsCa = Convert.ToInt16(isCa);
                int ipathLen = Convert.ToInt16(pathLen);
                int icritical = Convert.ToInt16(critical);
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
                    $", not_pathlen = @_pathLen, depth = @_depth, critical = @_Icritical WHERE name = @_searchTerm";
                }
                else
                {
                    sql = $"UPDATE {table} SET subj_country = @_subj_country, subj_state = @_subj_state, subj_location = @_subj_location, subj_organisation = @_subj_organisation, subj_orgaunit = @_subj_orgaunit, subj_commonname = @_subj_commonname, subj_email = @_subj_email, isCa = @_isCa" +
                    $", not_pathlen = @_pathLen, depth = @_depth, critical = @_Icritical, public_createDT = @_public_createDT WHERE name = @_searchTerm";
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
                command.Parameters.AddWithValue("@_Icritical", icritical);
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
        public static int Update(certType table, string publicKey, string searchTerm, string searchColumn)
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

                return rowUpdated;
            }
            catch (Exception ex)
            {
                return 0;

            }
        }
        public static Result<int> Update(certType table, string searchTerm, string subj_country, string subj_state, string subj_location,
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

                //string sql = "";
                //if (table == SQLTable.ca)
                //{
                string sql = $"UPDATE {table} SET subj_country = @_subj_country, subj_state = @_subj_state, subj_location = @_subj_location, subj_organisation = @_subj_organisation, subj_orgaunit = @_subj_orgaunit, subj_commonname = @_subj_commonname, subj_email = @_subj_email WHERE name = @_searchTerm";

                //}
                //else if (table == SQLTable.intermediate)
                //{
                //    sql = $"UPDATE {table} SET subj_country = @_subj_country, subj_state = @_subj_state, subj_location = @_subj_location, subj_organisation = @_subj_organisation, subj_orgaunit = @_subj_orgaunit, subj_commonname = @_subj_commonname, subj_email = @_subj_email WHERE name = @_searchTerm";

                //}
                //else
                //{
                //    sql = $"UPDATE {table} SET subj_country = @_subj_country, subj_state = @_subj_state, subj_location = @_subj_location, subj_orgaunit = @_subj_orgaunit, subj_commonname = @_subj_commonname, subj_email = @_subj_email WHERE name = @_searchTerm";
                //}

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
        public static int UpdateBasicConstraints(certType table, string searchTerm, bool isCa, bool noPaLen, int depth, bool critical)
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
                string sql = $"UPDATE {table} SET isCa = @_isCa, not_pathlen = @_not_pathLen, depth = @_depth, critical = @_critical WHERE name = @_searchTerm";
                using var command = new SqliteCommand(sql, connection);
                command.Parameters.AddWithValue("@_isCa", Convert.ToString(isCa));
                command.Parameters.AddWithValue("@_not_pathLen", Convert.ToString(noPaLen));
                command.Parameters.AddWithValue("@_depth", depth);
                command.Parameters.AddWithValue("@_critical", Convert.ToString(critical));

                command.Parameters.AddWithValue("@_searchTerm", searchTerm);

                int rowInserted = command.ExecuteNonQuery();
                return rowInserted;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }
        public static int UpdateSelfSigned(certType table, string searchTerm, byte[] selfSignedCert, int duration, int serialNumber)
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

                string sql = $"UPDATE {table} SET ss_cert = @_ss_cert, ss_createDT = @_ss_createDT, ss_duration = @_ss_duration, serialNumber = @_serialNumber WHERE name = @_searchTerm";
                using var command = new SqliteCommand(sql, connection);
                command.Parameters.AddWithValue("@_ss_cert", selfSignedCert);
                command.Parameters.AddWithValue("@_ss_createDT", Convert.ToString(DateTime.Now));
                command.Parameters.AddWithValue("@_searchTerm", searchTerm);
                command.Parameters.AddWithValue("@_ss_duration", duration);
                command.Parameters.AddWithValue("@_serialNumber", serialNumber);

                int rowInserted = command.ExecuteNonQuery();
                connection.Close();
                return rowInserted;

            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public static int UpdateSelfSigned(certType table, string searchTerm, byte[] selfSignedCert, int idSignedCa, int duration, int serialNumber)
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

                string sql = $"UPDATE {table} SET ss_cert = @_ss_cert, signed_against = @_signed_against, signed_createDT = @_signed_createDT, ss_createDT = @_ss_createDT, ss_duration = @_ss_duration, serialNumber = @_serialNumber WHERE name = @_searchTerm";
                using var command = new SqliteCommand(sql, connection);
                command.Parameters.AddWithValue("@_signed_against", idSignedCa); 
                command.Parameters.AddWithValue("@_signed_createDT", Convert.ToString(DateTime.Now));
                command.Parameters.AddWithValue("@_ss_cert", selfSignedCert);
                command.Parameters.AddWithValue("@_ss_createDT", Convert.ToString(DateTime.Now));
                command.Parameters.AddWithValue("@_searchTerm", searchTerm);
                command.Parameters.AddWithValue("@_ss_duration", duration); 
                command.Parameters.AddWithValue("@_serialNumber", serialNumber);

                int rowInserted = command.ExecuteNonQuery();
                connection.Close();
                return rowInserted;

            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public static Result<int> UpdateCert(SQLTable table, string searchTerm, X509Certificate2 cert)
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

                string sql = $"UPDATE {table} SET csr_createDT = @_csr_cert, csr_createDT = @_csr_createDT WHERE name = @_searchTerm";
                using var command = new SqliteCommand(sql, connection);
                command.Parameters.AddWithValue("@_csr_cert", cert);
                command.Parameters.AddWithValue("@_csr_createDT", Convert.ToString(DateTime.Now));
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
        private readonly bool writeFile = true;
        private readonly string privateKeyPath = "privateKey.pem";
        private readonly string[] basicConstraint = []; //bool certificateAuthority, bool hasPathLengthConstraint, int pathLengthConstraint, bool critical);


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
        public static Result<string> CreatePrivKey(int keySize)
        {
            using (RSA rsa = RSA.Create(keySize))
            {
                string privateKeyPem = rsa.ExportRSAPrivateKeyPem();
                return Result.Ok(privateKeyPem);
            }
        }

        public static string CreatePrivateKey3(int keySize, string filePath)
        {
            using (RSA rsa = RSA.Create(keySize))
            {
                string privateKeyPem = rsa.ExportRSAPrivateKeyPem();
                return privateKeyPem;
            }

        }

        /// <summary>
        /// Generate the public key (obsolete?)
        /// </summary>
        /// <returns>Returns the public key in PEM format</returns>
        public static Result<string> CreatePubKey(string privateKey)
        {
            using (RSA rsa = RSA.Create())
            {
                rsa.ImportFromPem(privateKey);
                string publicKeyPem = rsa.ExportRSAPublicKeyPem();
                return Result.Ok(publicKeyPem);
            }

        }
        public static string CreatePubKey3(string privateKey/*, string publicKey*/)
        {
            try
            {
                using (RSA rsa = RSA.Create())
                {
                    rsa.ImportFromPem(privateKey);
                    string publicKeyPem = rsa.ExportRSAPublicKeyPem();
                    return publicKeyPem;
                }
            }
            catch
            {
                return "failed";
            }
        }
        public static byte[] CreateSelfSigned3(string privateKeyPath, string publicKeyPath, string pfxPath, string password)
        {
            string privateKeyPem = File.ReadAllText(privateKeyPath);
            string publicKeyPem = File.ReadAllText(publicKeyPath);

            using (RSA rsa = RSA.Create())
            {
                rsa.ImportFromPem(privateKeyPem);
                var request = new CertificateRequest("CN=SelfSignedCertificate", rsa, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
                var certificate = request.CreateSelfSigned(DateTimeOffset.Now, DateTimeOffset.Now.AddYears(1));

                byte[] selfSignedCert = certificate.Export(X509ContentType.Pfx, password);
                //File.WriteAllBytes(pfxPath, certificate.Export(X509ContentType.Pfx, password));
                Console.WriteLine($"Self-signed Zertifikat in {pfxPath} gespeichert.");
                MessageBox.Show($"Self-signed Zertifikat in {pfxPath} gespeichert.");
                return selfSignedCert;
            }
        }
        public static X509Certificate2 CreateSelfSigned4(string privateKeyPath, string serverName, string[] fqdn, string pfxPath, string password, int duration)
        {

            List<object> fqdnRes = Sql.SelectWhereObject(certType.ca, fqdn, "name", serverName);
            X500DistinguishedName destName = DNBuilder(Convert.ToString(fqdnRes[0]), Convert.ToString(fqdnRes[1]), Convert.ToString(fqdnRes[2]), Convert.ToString(fqdnRes[3]), Convert.ToString(fqdnRes[4]), Convert.ToString(fqdnRes[5]), Convert.ToString(fqdnRes[6]));

            using (RSA rsa = RSA.Create())
            {
                rsa.ImportFromPem(privateKeyPath);
                // Zertifikatsanfrage erstellen
                var request = new CertificateRequest(destName, rsa, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
                // Erweiterungen für eine CA hinzufügen
                request.CertificateExtensions.Add(new X509BasicConstraintsExtension(true, true, 0, true)); // CA: true, keine Pfadlänge
                request.CertificateExtensions.Add(new X509KeyUsageExtension(X509KeyUsageFlags.KeyCertSign | X509KeyUsageFlags.DigitalSignature | X509KeyUsageFlags.CrlSign, true)); // Signatur- und CRL-Rechte
                request.CertificateExtensions.Add(new X509SubjectKeyIdentifierExtension(request.PublicKey, false));

                var certificate = request.CreateSelfSigned(DateTimeOffset.Now, DateTimeOffset.Now.AddMonths(duration));

                byte[] selfSignedCert = certificate.Export(X509ContentType.Pfx, password);
                Console.WriteLine($"Self-signed Zertifikat in {pfxPath} gespeichert.");
                MessageBox.Show($"Self-signed Zertifikat in {pfxPath} gespeichert.");
                return certificate;
            }
        }
        public static X509Certificate2 CreateSelfSigned4(string privateKeyPath, string serverName, X500DistinguishedName distinguishedName, string pfxPath, string password, int duration)
        {

            //List<object> fqdnRes = Sql.SelectWhereObject(certType.ca, fqdn, "name", serverName);
            //X500DistinguishedName destName = DNBuilder(Convert.ToString(fqdnRes[0]), Convert.ToString(fqdnRes[1]), Convert.ToString(fqdnRes[2]), Convert.ToString(fqdnRes[3]), Convert.ToString(fqdnRes[4]), Convert.ToString(fqdnRes[5]), Convert.ToString(fqdnRes[6]));

            using (RSA rsa = RSA.Create())
            {
                rsa.ImportFromPem(privateKeyPath);
                // Zertifikatsanfrage erstellen
                var request = new CertificateRequest(distinguishedName, rsa, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
                // Erweiterungen für eine CA hinzufügen
                request.CertificateExtensions.Add(new X509BasicConstraintsExtension(true, true, 0, true)); // CA: true, keine Pfadlänge
                request.CertificateExtensions.Add(new X509KeyUsageExtension(X509KeyUsageFlags.KeyCertSign | X509KeyUsageFlags.DigitalSignature | X509KeyUsageFlags.CrlSign, true)); // Signatur- und CRL-Rechte
                request.CertificateExtensions.Add(new X509SubjectKeyIdentifierExtension(request.PublicKey, false));

                var certificate = request.CreateSelfSigned(DateTimeOffset.Now, DateTimeOffset.Now.AddMonths(duration));

                byte[] selfSignedCert = certificate.Export(X509ContentType.Pfx, password);
                Console.WriteLine($"Self-signed Zertifikat in {pfxPath} gespeichert.");
                MessageBox.Show($"Self-signed Zertifikat in {pfxPath} gespeichert.");
                return certificate;
            }
        }

        public static X509Certificate2 CreateInterCertificate(
            string interName,
            string intPrivateKey,
            string[] fqdn,
            string caCertPath,
            string caPassword,
            int duration)
        {
            List<object> fqdnRes = Sql.SelectWhereObject(certType.intermediate, fqdn, "name", interName);
            X500DistinguishedName destName = DNBuilder(Convert.ToString(fqdnRes[0]), Convert.ToString(fqdnRes[1]), Convert.ToString(fqdnRes[2]), Convert.ToString(fqdnRes[3]), Convert.ToString(fqdnRes[4]), Convert.ToString(fqdnRes[5]), Convert.ToString(fqdnRes[6]));

            int serialnumber = 1;
            byte[] serialNumber = { Convert.ToByte(serialnumber) };
            using (RSA rsa = RSA.Create())
            {
                rsa.ImportFromPem(intPrivateKey);

                var intermediateRequest = new CertificateRequest(destName, rsa, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
                intermediateRequest.CertificateExtensions.Add(new X509BasicConstraintsExtension(true, false, 0, true));

                intermediateRequest.CertificateExtensions
                    .Add(new X509KeyUsageExtension(X509KeyUsageFlags.KeyCertSign | X509KeyUsageFlags.CrlSign, true));

                var caCertificate = new X509Certificate2(caCertPath, caPassword, X509KeyStorageFlags.Exportable);
                // Ensure the CA certificate has a Basic Constraints extension
                if (!caCertificate.Extensions.OfType<X509BasicConstraintsExtension>().Any())
                {
                    throw new ArgumentException("The issuer certificate does not have a Basic Constraints extension.");
                }
                var signedCertificate = intermediateRequest.Create(caCertificate, DateTimeOffset.Now, DateTimeOffset.Now
                    .AddMonths(duration), serialNumber);
                X509Certificate2 signedCertificateWithKey = signedCertificate.CopyWithPrivateKey(rsa);

                return signedCertificateWithKey;
            }
        }
        public static X509Certificate2 CreateInterCertificate2(string requestPrivKey, X500DistinguishedName distinguishedName, byte[] issuerCert, string issuerPasswd, int requesterDuration, int requesterSerialNumber, certType certType)
        {
            byte[] sN = { Convert.ToByte(requesterSerialNumber) };
            X509Certificate2 caCertificate;
            CertificateRequest intermediateRequest;
            X509Certificate2 signedCertificate;

            using (RSA rsa = RSA.Create())
            {
                rsa.ImportFromPem(requestPrivKey);

                intermediateRequest = new CertificateRequest(distinguishedName, rsa, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
                if (certType == certType.ca )
                {
                    //intermediateRequest.CertificateExtensions.Add(new X509BasicConstraintsExtension(true, false, 0, true));
                    intermediateRequest.CertificateExtensions.Add(Global.caBasicConstraint);
                    intermediateRequest.CertificateExtensions.Add(Global.caKeyUsageExtension);
                    //intermediateRequest.CertificateExtensions.Add(new X509KeyUsageExtension(X509KeyUsageFlags.KeyCertSign | X509KeyUsageFlags.DigitalSignature | X509KeyUsageFlags.CrlSign, true));
                    intermediateRequest.CertificateExtensions.Add(new X509SubjectKeyIdentifierExtension(intermediateRequest.PublicKey, false));
                }
                else if(certType == certType.intermediate)
                {
                    //intermediateRequest.CertificateExtensions.Add(new X509BasicConstraintsExtension(true, false, 0, true));
                    intermediateRequest.CertificateExtensions.Add(Global.caBasicConstraint);
                    intermediateRequest.CertificateExtensions.Add(new X509KeyUsageExtension(X509KeyUsageFlags.KeyCertSign | X509KeyUsageFlags.CrlSign, true));
                }
                else if (certType == certType.server)
                {
                    intermediateRequest.CertificateExtensions.Add(new X509BasicConstraintsExtension(false, false, 0, true));
                    intermediateRequest.CertificateExtensions.Add(new X509KeyUsageExtension(X509KeyUsageFlags.DigitalSignature | X509KeyUsageFlags.KeyEncipherment, true));
                    intermediateRequest.CertificateExtensions.Add(new X509EnhancedKeyUsageExtension(new OidCollection { new Oid(serverAuth2) }, false));
                }
                else if (certType == certType.user)
                {
                    intermediateRequest.CertificateExtensions.Add(new X509BasicConstraintsExtension(false, false, 0, true)); 
                    intermediateRequest.CertificateExtensions.Add(new X509KeyUsageExtension(X509KeyUsageFlags.DataEncipherment | X509KeyUsageFlags.NonRepudiation | X509KeyUsageFlags.DigitalSignature | X509KeyUsageFlags.KeyEncipherment, true));
                    intermediateRequest.CertificateExtensions.Add(new X509EnhancedKeyUsageExtension(new OidCollection { new Oid(clientAuth2) }, false));
                }
                if (certType == certType.ca)
                {
                    signedCertificate = intermediateRequest.CreateSelfSigned(DateTimeOffset.Now, DateTimeOffset.Now.AddMonths(requesterDuration));
                    return signedCertificate;
                }
                else { 
                    caCertificate = new X509Certificate2(issuerCert, issuerPasswd, X509KeyStorageFlags.Exportable);
                    signedCertificate = intermediateRequest.Create(caCertificate, DateTimeOffset.Now, DateTimeOffset.Now.AddMonths(requesterDuration), sN);
                    if (!caCertificate.Extensions.OfType<X509BasicConstraintsExtension>().Any())
                    {
                        throw new ArgumentException("The issuer certificate does not have a Basic Constraints extension.");
                    }
                    X509Certificate2 signedCertificateWithKey = signedCertificate.CopyWithPrivateKey(rsa);
                    return signedCertificateWithKey;
                }
            }
        }
        public static X509Certificate2 CreateServerCertificate(string serverName, string intPrivateKey, string[] fqdn, byte[] intCertPath, string intPassword, int duration)
        {
            List<object> fqdnRes = Sql.SelectWhereObject(certType.server, fqdn, "name", serverName);
            X500DistinguishedName destName = DNBuilder(Convert.ToString(fqdnRes[0]), Convert.ToString(fqdnRes[1]), Convert.ToString(fqdnRes[2]), Convert.ToString(fqdnRes[3]), Convert.ToString(fqdnRes[4]), Convert.ToString(fqdnRes[5]), Convert.ToString(fqdnRes[6]));

            int serialnumber = 1;
            byte[] serialNumber = { Convert.ToByte(serialnumber) };
            using (RSA rsa = RSA.Create())
            {
                rsa.ImportFromPem(intPrivateKey);

                var serverRequest = new CertificateRequest(destName, rsa, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
                serverRequest.CertificateExtensions.Add(new X509BasicConstraintsExtension(false, false, 0, false));
                serverRequest.CertificateExtensions.Add(new X509KeyUsageExtension(X509KeyUsageFlags.DigitalSignature | X509KeyUsageFlags.KeyEncipherment, true));
                serverRequest.CertificateExtensions.Add(new X509EnhancedKeyUsageExtension(new OidCollection { new Oid("1.3.6.1.5.5.7.3.1") }, true));

                var intCertificate = new X509Certificate2(intCertPath, intPassword, X509KeyStorageFlags.Exportable);
                // Ensure the CA certificate has a Basic Constraints extension
                if (!intCertificate.Extensions.OfType<X509BasicConstraintsExtension>().Any())
                {
                    throw new ArgumentException("The issuer certificate does not have a Basic Constraints extension.");
                }
                var signedCertificate = serverRequest.Create(intCertificate, DateTimeOffset.Now, DateTimeOffset.Now.AddMonths(duration), serialNumber);
                X509Certificate2 signedCertificateWithKey = signedCertificate.CopyWithPrivateKey(rsa);

                return signedCertificateWithKey;
            }
        }


        public static X509Certificate2 CreateServerCertificate(string serverName, string intPrivateKey, string[] fqdn, string certPath, string password, int duration)
        {
            List<object> fqdnRes = Sql.SelectWhereObject(certType.server, fqdn, "name", serverName);
            X500DistinguishedName destName = DNBuilder(Convert.ToString(fqdnRes[0]), Convert.ToString(fqdnRes[1]), Convert.ToString(fqdnRes[2]), Convert.ToString(fqdnRes[3]), Convert.ToString(fqdnRes[4]), Convert.ToString(fqdnRes[5]), Convert.ToString(fqdnRes[6]));

            int serialnumber = 1;
            byte[] serialNumber = { Convert.ToByte(serialnumber) };
            using (RSA rsa = RSA.Create())
            {
                rsa.ImportFromPem(intPrivateKey);

                var intermediateRequest = new CertificateRequest(destName, rsa, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
                intermediateRequest.CertificateExtensions.Add(new X509BasicConstraintsExtension(true, false, 0, true));
                intermediateRequest.CertificateExtensions.Add(new X509KeyUsageExtension(X509KeyUsageFlags.KeyCertSign | X509KeyUsageFlags.CrlSign, true));

                var caCertificate = new X509Certificate2(certPath, password, X509KeyStorageFlags.Exportable);
                // Ensure the CA certificate has a Basic Constraints extension
                if (!caCertificate.Extensions.OfType<X509BasicConstraintsExtension>().Any())
                {
                    throw new ArgumentException("The issuer certificate does not have a Basic Constraints extension.");
                }
                var signedCertificate = intermediateRequest.Create(caCertificate, DateTimeOffset.Now, DateTimeOffset.Now.AddMonths(duration), serialNumber);
                X509Certificate2 signedCertificateWithKey = signedCertificate.CopyWithPrivateKey(rsa);

                return signedCertificateWithKey;
            }
        }
        public static X509Certificate2Collection ChainCaIntCerts(X509Certificate2 signedInterCert, X509Certificate2 signedCaCert)
        {
            X509Certificate2Collection chain = new X509Certificate2Collection();
            chain.Add(signedInterCert);
            chain.Add(signedCaCert);

            return chain;
        }


        /// <summary>
        /// Generates the self signed file
        /// </summary>
        /// <param name="keySize">Keysize in bits</param>
        /// <param name="privKey">The privatekey as byte[]</param>
        /// <param name="subjects">Distingused name as string</param>
        /// <param name="pubKey">The publickey as byte[]</param>
        public static Result<X509Certificate2> CreateSSCert(SQLTable table, X500DistinguishedName subject, string privKey, string pubKey, bool isCa, bool not_pathlen, int depth, bool critical, int duration, int serialnumber)
        {
            try
            {
                using (RSA rsa = RSA.Create())
                {
                    rsa.ImportFromPem(privKey);

                    var request = new CertificateRequest(subject, rsa, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
                    request.CertificateExtensions.Add(new X509BasicConstraintsExtension(isCa, not_pathlen, depth, true));
                    request.CertificateExtensions.Add(new X509KeyUsageExtension(X509KeyUsageFlags.KeyCertSign | X509KeyUsageFlags.CrlSign | X509KeyUsageFlags.DigitalSignature, true)); // Signatur- und CRL rights
                    request.CertificateExtensions.Add(new X509SubjectKeyIdentifierExtension(request.PublicKey, false));

                    byte[] serialNumber = { Convert.ToByte(serialnumber) };
                    // Zertifikat erstellen und signieren
                    DateTimeOffset notBefore = DateTimeOffset.UtcNow;
                    DateTimeOffset notAfter = notBefore.AddMonths(duration);

                    X509Certificate2 certificate = request.Create(
                        subject,
                        X509SignatureGenerator.CreateForRSA(rsa, RSASignaturePadding.Pkcs1),
                        notBefore,
                        notAfter,
                        serialNumber);

                    //X509Certificate2 certificate = request.CreateSelfSigned(notBefore, notAfter);
                    //byte[] export = certificate.Export(X509ContentType.Cert);
                    //byte[] export2 = certificate.Export(X509ContentType.Pfx, "test");

                    return Result.Ok(certificate);

                }
            }
            catch (Exception ex)
            {
                return Result.Fail($"Fehler test: {ex}").WithError("Test");
            }
        }
        public static Result<byte[]> CreateSSCertb(SQLTable table, X500DistinguishedName subject, string privKey, string pubKey, bool isCa, bool not_pathlen, int depth, bool critical, int duration, int serialnumber)
        {
            try
            {
                using (RSA rsa = RSA.Create())
                {
                    rsa.ImportFromPem(privKey);

                    var request = new CertificateRequest(subject, rsa, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
                    request.CertificateExtensions.Add(new X509BasicConstraintsExtension(isCa, not_pathlen, depth, true));
                    request.CertificateExtensions.Add(new X509KeyUsageExtension(X509KeyUsageFlags.KeyCertSign | X509KeyUsageFlags.CrlSign | X509KeyUsageFlags.DigitalSignature, true)); // Signatur- und CRL rights
                    request.CertificateExtensions.Add(new X509SubjectKeyIdentifierExtension(request.PublicKey, false));


                    byte[] serialNumber = { Convert.ToByte(serialnumber) };
                    // Zertifikat erstellen und signieren
                    DateTimeOffset notBefore = DateTimeOffset.UtcNow;
                    DateTimeOffset notAfter = notBefore.AddMonths(duration);

                    X509Certificate2 certificate = request.Create(
                        subject,
                        X509SignatureGenerator.CreateForRSA(rsa, RSASignaturePadding.Pkcs1),
                        notBefore,
                        notAfter,
                        serialNumber);

                    X509Certificate2 certificatex = request.CreateSelfSigned(notBefore, notAfter);

                    //byte[] export = certificate.Export(X509ContentType.Cert);
                    byte[] export = certificate.Export(X509ContentType.Pfx, "test");

                    return Result.Ok(export);

                }
            }
            catch (Exception ex)
            {
                return Result.Fail($"Fehler test: {ex}").WithError("Test");
            }
        }

        public static Result<X509Certificate2> CreateSSCert2(SQLTable table, int keySize, X500DistinguishedName subject, byte[] privKey, byte[] pubKey, bool isCa, bool not_pathlen, int depth, bool critical, int duration, int serialnumber)
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
                    byte[] export2 = certificate.Export(X509ContentType.Pfx, "test");
                    string certPath = "c_selfsignedKeyPfx.pfx";
                    string password = "test"; // Passwort für den PFX-Schutz
                    var pfxBytes = certificate.Export(X509ContentType.Pfx, password);
                    //System.IO.File.WriteAllBytes(certPath, pfxBytes);

                    return Result.Ok(certificate);

                }
            }
            catch (Exception ex)
            {
                return Result.Fail($"Fehler test: {ex}").WithError("Test");
            }
        }
        public static Result<byte[]> CreateSSCert2b(SQLTable table, X500DistinguishedName subject, string privKey, string pubKey, bool isCa, bool not_pathlen, int depth, bool critical, int duration, int serialnumber)
        {
            try
            {
                using (RSA rsa = RSA.Create())
                {
                    rsa.ImportFromPem(privKey);
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
                    byte[] export2 = certificate.Export(X509ContentType.Pfx, "test");
                    string certPath = "c_selfsignedKeyPfx.pfx";
                    string password = "test"; // Passwort für den PFX-Schutz
                    byte[] pfxBytes = certificate.Export(X509ContentType.Pfx, password);
                    //System.IO.File.WriteAllBytes(certPath, pfxBytes);

                    return Result.Ok(pfxBytes);

                }
            }
            catch (Exception ex)
            {
                return Result.Fail($"Fehler test: {ex}").WithError("Test");
            }
        }

        public static Result<byte[]> CreateCaSignCert(SQLTable table, X509Certificate2 caCert, int keySize, X500DistinguishedName subject, bool isCa, bool not_pathlen, int depth, bool critical, int duration, int serialnumber)
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
        public static X500DistinguishedName DNBuilder(string twoLetterCode, string stateOrProvinceName, string localityName, string organizationName, string organizationalUnitName, string commonName, string emailAddress)
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

                return build;
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
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
        public static void checkPrivKey(X509Certificate2 caCertificate)
        {
            if (!caCertificate.HasPrivateKey)
            {
                Console.WriteLine("Das CA-Zertifikat hat keinen privaten Schlüssel.");
                MessageBox.Show("Das CA - Zertifikat hat keinen privaten Schlüssel.");
            }
            else
            {
                Console.WriteLine("Das CA-Zertifikat hat einen privaten Schlüssel.");
                MessageBox.Show("Das CA-Zertifikat hat einen privaten Schlüssel.");
            }
        }
    }
    public class Tools
    {
        public enum certType
        {
            ca,
            intermediate,
            server,
            user
        }

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
