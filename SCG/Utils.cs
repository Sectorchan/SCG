using System.Data;
using System.Reflection;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using FluentResults;
using Microsoft.Data.Sqlite;
using Renci.SshNet;
using SCG.Forms;
using static PL.Utils.Tools;
using static SCG.Forms.Server;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;


namespace PL;

public class Utils
{
    private const string serverAuth2 = "1.3.6.1.5.5.7.3.1";
    private const string clientAuth2 = "1.3.6.1.5.5.7.3.2";

    static SqliteConnection _connection = Server.sqlconnection;

    private const int KeySize = 32; // 256 Bit
    private const int SaltSize = 16;
    private const int IvSize = 16;
    private const int Iterations = 100_000;
    private const string FilePath = "encrypted.dat";


    public class ssh
    {
        /// <summary>
        /// Uploads privateKey in PEM format
        /// </summary>
        /// <param name="host">hostname or IP address</param>
        /// <param name="username">username of the server</param>
        /// <param name="password">corresponding password to the username</param>
        /// <param name="privateKeyInPem">The privateKey in PEM format</param>
        /// <param name="remoteFilePath">the path of the certificate file, including filename and extension</param>
        public static void UploadCert(string host, string username, string password, string privateKeyInPem, string remoteFilePath)
        {
            try
            {
                using (var sftp = new SftpClient(host, username, password))
                {
                    sftp.Connect();
                    using (var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(privateKeyInPem)))
                    { sftp.UploadFile(memoryStream, remoteFilePath); }
                    sftp.Disconnect();
                }
            }
            catch (Exception ex)
            { MessageBox.Show(Convert.ToString(ex)); }
        }
        /// <summary>
        /// Uploads public key
        /// </summary>
        /// <param name="host"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="localCertificate"></param>
        /// <param name="remoteFilePath"></param>
        public static void UploadCert(string host, string username, string password, byte[] localCertificate, string remoteFilePath)
        {
            try
            {
                using (var sftp = new SftpClient(host, username, password))
                {
                    sftp.Connect();
                    using (var memoryStream = new MemoryStream(localCertificate))
                    { sftp.UploadFile(memoryStream, remoteFilePath); }
                    sftp.Disconnect();
                }
            }
            catch (Exception ex)
            { MessageBox.Show(Convert.ToString(ex)); }
        }

        public static void DownloadCert(string host, string localFilePath, string remoteFilePath)
        {
            try
            { }
            catch (Exception ex)
            { MessageBox.Show(Convert.ToString(ex)); }
        }
    }
    public class Sql
    {
        public static SqliteConnection openConnection()
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
                return connection;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }


        public static string GetPrivateKey(serverType table, string serverName)
        {
            try
            {
                string result = string.Empty;
                SqliteConnectionStringBuilder _connectionString = new SqliteConnectionStringBuilder();
                _connectionString.Mode = SqliteOpenMode.ReadWriteCreate;
                _connectionString.DataSource = Global.database;
                _connectionString.Password = null;
                string connectionString = _connectionString.ToString();
                using var connection = new SqliteConnection(connectionString);
                connection.Open();

                var sql = $"SELECT private_key FROM {table} WHERE name=@_searchValue"; // geht nicht 
                using var command = new SqliteCommand(sql, connection);

                command.Parameters.AddWithValue("@_searchValue", serverName);
                using var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        result = reader.GetString("private_key");
                    }
                }


                return result;
            }
            catch
            {
                return "0";
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="table">The corresponding table, depending on the type</param>
        /// <param name="name">An unique application/server name</param>
        /// <param name="privKey">The privateKey in PEM format</param>
        /// <param name="privbits">Default 4096, the same as on CreatePrivKey. Make sure thats the same parameter</param>
        /// <returns>Returns the amount of entries that written to the SQL database.</returns>
        ///
        public static Result<int> InsertInto(serverType table, string _name, PL.Certs cert)
        {
            try
            {

                string sql = $"INSERT INTO {table} (name, keySize, private_key, private_createDT) VALUES (@_name, @_keySize, @_private_key, @_priv_createDT)";

                using var command = new SqliteCommand(sql, _connection);
                command.Parameters.AddWithValue("@_name", cert.name);
                command.Parameters.AddWithValue("@_keySize", cert.keySize);
                command.Parameters.AddWithValue("@_private_key", cert.private_key);
                command.Parameters.AddWithValue("@_priv_createDT", DateTime.Now.ToString());

                return Result.Ok(command.ExecuteNonQuery());

            }
            catch (Exception ex)
            {
                if (ex == null)
                { return Result.Fail("Possible wrong SQL credentials"); }
                else
                { return Result.Fail(ex.Message); }
            }
        }



        public static void SeSelect(serverType serverType, dynamic control)
        {
            try
            {
                string items = string.Empty;

                string sql = $"SELECT * FROM {serverType}";

                using var command = new SqliteCommand(sql, _connection);
                using var reader = command.ExecuteReader();


                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        byte[] ss_cert = null;
                        int i_ss_cert = reader.GetOrdinal("ss_cert");
                        long size = reader.GetBytes(i_ss_cert, 0, null, 0, 0); // Größe ermitteln
                        ss_cert = new byte[size];
                        reader.GetBytes(i_ss_cert, 0, ss_cert, 0, (int)size);  // Daten einlesen

                        var item = new PL.Certs
                        {
                            id = reader.GetInt32(reader.GetOrdinal("id")),
                            name = reader.GetString(reader.GetOrdinal("name")),
                            keySize = reader.GetInt32(reader.GetOrdinal("keySize")),
                            private_key = reader.GetString(reader.GetOrdinal("private_key")),
                            private_createDT = reader.GetInt32(reader.GetOrdinal("private_createDT")),
                            public_cert = reader.GetString(reader.GetOrdinal("public_cert")),
                            public_createDT = reader.GetString(reader.GetOrdinal("public_createDT")),
                            ss_cert = ss_cert,
                            ss_createDT = reader.GetString(reader.GetOrdinal("ss_createDT")),
                            ss_duration = reader.GetInt32(reader.GetOrdinal("ss_duration")),
                            subj_country = reader.GetString(reader.GetOrdinal("subj_country")),
                            subj_state = reader.GetString(reader.GetOrdinal("subj_state")),
                            subj_location = reader.GetString(reader.GetOrdinal("subj_location")),
                            subj_organisation = reader.GetString(reader.GetOrdinal("subj_organisation")),
                            subj_orgaunit = reader.GetString(reader.GetOrdinal("subj_orgaunit")),
                            subj_commonname = reader.GetString(reader.GetOrdinal("subj_commonname")),
                            subj_email = reader.GetString(reader.GetOrdinal("subj_email")),
                            serialNumber = reader.GetInt64(reader.GetOrdinal("serialNumber")),
                            host_name = reader.GetString(reader.GetOrdinal("host_name")),
                            host_username = reader.GetString(reader.GetOrdinal("host_username")),
                            host_password = reader.GetString(reader.GetOrdinal("host_password")),

                            signed_against = reader.GetString(reader.GetOrdinal("signed_against")),
                            signed_createDT = reader.GetString(reader.GetOrdinal("signed_createDT")),

                            cert_priv_filename = reader.GetString(reader.GetOrdinal("cert_priv_filename")),
                            cert_priv_fileext = reader.GetString(reader.GetOrdinal("cert_priv_fileext")),
                            cert_priv_path = reader.GetString(reader.GetOrdinal("cert_priv_path")),
                            cert_pub_filename = reader.GetString(reader.GetOrdinal("cert_pub_filename")),
                            cert_pub_fileext = reader.GetString(reader.GetOrdinal("cert_pub_fileext")),
                            cert_pub_path = reader.GetString(reader.GetOrdinal("cert_pub_path")),
                            cert_signed_filename = reader.GetString(reader.GetOrdinal("cert_signed_filename")),
                            cert_signed_fileext = reader.GetString(reader.GetOrdinal("cert_signed_fileext")),
                            cert_signed_path = reader.GetString(reader.GetOrdinal("cert_signed_path")),

                            cert_autoupload = reader.GetInt32(reader.GetOrdinal("cert_autoupload")),
                            san1 = reader.GetString(reader.GetOrdinal("san1")),
                            san2 = reader.GetString(reader.GetOrdinal("san2")),
                            san3 = reader.GetString(reader.GetOrdinal("san3")),
                            san4 = reader.GetString(reader.GetOrdinal("san4"))

                        };

                        control.Items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        /// <summary>
        /// Performs a SQL SELECT statement
        /// </summary>
        /// <param name="column">Which column should be searched for</param>
        /// <param name="table">Defines the table inside the database</param>
        /// <returns>Result<List<string>></returns>
        public static List<string> SqlSelect(string column, serverType table)
        {
            var sql = $"SELECT {column} FROM {table}";

            using var command = new SqliteCommand(sql, _connection);
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
                        columns.Add(reader.GetString("keySize"));
                        columns.Add(reader.GetString("private_key"));
                        columns.Add(reader.GetString("private_createDT"));
                        columns.Add(reader.GetString("public_cert"));
                        columns.Add(reader.GetString("public_createDT"));
                        columns.Add(reader.GetString("ss_cert"));
                        columns.Add(reader.GetString("ss_createDT"));
                        columns.Add(reader.GetString("ss_duration"));
                        columns.Add(reader.GetString("subj_country"));
                        columns.Add(reader.GetString("subj_state"));
                        columns.Add(reader.GetString("subj_location"));
                        columns.Add(reader.GetString("subj_organisation"));
                        columns.Add(reader.GetString("subj_orgaunit"));
                        columns.Add(reader.GetString("subj_commonname"));
                        columns.Add(reader.GetString("subj_email"));
                        columns.Add(reader.GetString("serialNumber"));
                        columns.Add(reader.GetString("host_name"));
                        columns.Add(reader.GetString("host_username"));
                        columns.Add(reader.GetString("host_password"));
                        columns.Add(reader.GetString("cert_filename"));
                        columns.Add(reader.GetString("cert_priv_ext"));
                        columns.Add(reader.GetString("cert_pub_ext"));
                        columns.Add(reader.GetString("cert_path"));
                        columns.Add(reader.GetString("cert_autoupload"));
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
        /// Reads the whole SQL Line and stores it in the "dict<certType>Details" dictionary.
        /// </summary>
        /// <param name="table">Select the table which should be read</param>
        /// <param name="serverName">Specify the servername which parameter you want to read.</param>
        /// <returns></returns>


        public static string SelectWhereString(serverType table, string resultColumn, string searchColumn, string searchValue)
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

        public static byte[] SelectSsCert(serverType table, string column, string searchColumn, string searchValue)
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
                        // `byte_column` auslesen //PL
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
        public static Result<List<object>> SelectWhereObject(string[] column1, serverType table, string searchColumn, string searchValue)
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
                return Result.Fail(Convert.ToString(ex));
            }

        }

        public static List<object> SelectWhereObject(serverType table, string[] returnValues, string searchColumn, string searchValue)
        {
            try
            {
                string sql = string.Empty;
                List<object> columns = new List<object>();

                SqliteConnectionStringBuilder _connectionString = new SqliteConnectionStringBuilder();
                _connectionString.Mode = SqliteOpenMode.ReadWriteCreate;
                _connectionString.DataSource = Global.database;
                _connectionString.Password = null;
                string connectionString = _connectionString.ToString();
                using var connection = new SqliteConnection(connectionString);
                connection.Open();

                string column = string.Join(",", returnValues); // adds a comma after each element, except the last one for the SQL query
                if (searchValue == string.Empty)
                {
                    sql = $"SELECT {column} FROM {table}";
                }
                else
                {
                    sql = $"SELECT {column} FROM {table} WHERE {searchColumn}=@_searchValue";
                }


                using var command = new SqliteCommand(sql, connection);
                command.Parameters.AddWithValue("@_searchValue", searchValue);
                using var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    //List<object> columns = new List<object>();
                    while (reader.Read())
                    {
                        foreach (string row in returnValues)
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
            catch (Exception)
            {
                return null;
            }


        }
        public static int Update(serverType table, string publicKey, string searchTerm, string searchColumn)
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
            catch (Exception)
            {
                return 0;
            }
        }
        public static Result<int> Update(serverType table, string searchTerm, string subj_country, string subj_state, string subj_location,
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

                string sql = $"UPDATE {table} SET subj_country = @_subj_country, subj_state = @_subj_state, subj_location = @_subj_location, subj_organisation = @_subj_organisation, subj_orgaunit = @_subj_orgaunit, subj_commonname = @_subj_commonname, subj_email = @_subj_email WHERE name = @_searchTerm";

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
        public static Result<int> Update(serverType table, PL.Certs cert, PL.Certs issuerCert, string[] columns)
        {
            try
            {
                int rowIns = 0;
                using (var command = _connection.CreateCommand())
                {
                    foreach (var column in columns)
                    {
                        if (column is "public_createDT" or "private_createDT" or "ss_createDT" or "signed_createDT")
                        {
                            PropertyInfo property = typeof(PL.Certs).GetProperty(column);
                            if (property != null && property.CanWrite)
                            {
                                property.SetValue(cert, Convert.ToString(DateTime.Now));
                            }
                        }
                        if (column is "signed_against")
                        {
                            PropertyInfo property = typeof(PL.Certs).GetProperty(column);
                            if (property != null && property.CanWrite)
                            {
                                property.SetValue(cert, Convert.ToString(issuerCert.id));
                            }
                        }

                        command.Parameters.Clear();
                        command.CommandText = $"UPDATE {table} SET {column} = @_value WHERE name = @_searchTerm";

                        var prop = typeof(PL.Certs).GetProperty(column);

                        if (prop != null)
                        {
                            object value = prop.GetValue(cert) ?? DBNull.Value;
                            command.Parameters.AddWithValue("@_value", value);
                        }

                        command.Parameters.AddWithValue("@_searchTerm", cert.name);

                        int rowInserted = command.ExecuteNonQuery();
                        rowIns += rowInserted;

                    }
                }
                return Result.Ok(rowIns);
            }
            catch (Exception ex)
            {
                return Result.Fail(ex.ToString());
            }
        }


        public static int UpdateBasicConstraints(serverType table, string searchTerm, bool isCa, bool noPaLen, int depth, bool critical)
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
        public static void WriteCertFileInfo(serverType table, string fileName, string privExt, string pubExt, string remotePath, string searchTerm)
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
                string sql = $"UPDATE {table} SET cert_filename = @_cert_filename, cert_priv_Ext = @_cert_priv_Ext, cert_pub_ext = @_cert_pub_Ext, cert_path = @_remotePath WHERE name = @_searchTerm";
                using var command = new SqliteCommand(sql, connection);
                command.Parameters.AddWithValue("@_cert_filename", fileName);
                command.Parameters.AddWithValue("@_cert_priv_Ext", privExt);
                command.Parameters.AddWithValue("@_cert_pub_Ext", pubExt);
                command.Parameters.AddWithValue("@_remotePath", remotePath);

                command.Parameters.AddWithValue("@_searchTerm", searchTerm);

                int rowInserted = command.ExecuteNonQuery();
                //return rowInserted;
            }
            catch (Exception)
            {

                throw;
            }
        }
        //Server.cs 305
        public static Result<int> UpdateSelfSigned(serverType table, string searchTerm, byte[] selfSignedCert, int duration, int serialNumber)
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
                return Result.Ok(rowInserted);

            }
            catch (Exception ex)
            {
                return Result.Fail(ex.Message);
            }
        }
        public static int UpdateSelfSigned(serverType table, string searchTerm, byte[] selfSignedCert, int idSignedCa, int duration, int serialNumber)
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
            catch (Exception)
            {
                return 0;
            }
        }
    }


    public class Certs
    {
        public static Result<string> GeneratePrivateKey(int keySize)
        {
            try
            {
                if (keySize != 0)
                {
                    using (RSA rsa = RSA.Create(keySize))
                    { return Result.Ok(rsa.ExportRSAPrivateKeyPem()); }
                }
                else
                { return Result.Fail("Keysize is 0"); }
            }
            catch (Exception ex)
            { return Result.Fail($"Exceptionmessage {Convert.ToString(ex)}"); }
        }

        public static Result<string> GeneratePublicKey(string serverName, string privateKey)
        {
            try
            {
                using (RSA rsa = RSA.Create())
                {
                    rsa.ImportFromPem(privateKey);
                    //dictCaDetails["public_cert"] = rsa.ExportRSAPublicKeyPem();

                    return Result.Ok(rsa.ExportRSAPublicKeyPem());
                }

            }
            catch (Exception ex)
            {
                return Result.Fail($"Exceptionmessage {Convert.ToString(ex)}");
            }
        }
        public static Result<X509Certificate2> GenerateSelfsigned(serverType serverType, PL.Certs certs)
        {
            try
            {
                CertificateRequest request;
                X509Certificate2 selfSignedCertificate;
                Result<X500DistinguishedName> DNresult = DNBuilder(certs);
                if (!DNresult.IsSuccess)
                    return Result.Fail("DNBuilder failed");

                using (RSA rsa = RSA.Create())
                {
                    rsa.ImportFromPem(certs.private_key);
                    request = new CertificateRequest(DNresult.Value, rsa, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);

                    if (serverType == serverType.ca)
                    {
                        request.CertificateExtensions.Add(Global.caBasicConstraint);
                        request.CertificateExtensions.Add(Global.caKeyUsageExtension);
                        request.CertificateExtensions.Add(new X509SubjectKeyIdentifierExtension(request.PublicKey, false));
                    }
                    if (serverType == serverType.ca)
                    {
                        #region Create serialnumber
                        int cTempSerialNumber = Convert.ToInt32(certs.serialNumber);
                        cTempSerialNumber++;
                        string time = DateTime.Now.ToString("ddMMyyyy");
                        long serialNumber = long.Parse($"{cTempSerialNumber}{time}");
                        #endregion
                        int month = certs.ss_duration;
                        selfSignedCertificate = request.CreateSelfSigned(DateTimeOffset.Now, DateTimeOffset.Now.AddMonths(month));

                        if (!selfSignedCertificate.Extensions.OfType<X509BasicConstraintsExtension>().Any())
                        {
                            throw new ArgumentException("The issuer certificate does not have a Basic Constraints extension.");
                        }

                        return Result.Ok(selfSignedCertificate);
                    }
                    return Result.Fail("failed");
                }
            }
            catch (Exception ex)
            { return Result.Fail(Convert.ToString(ex)); }
        }
        public static Result<X509Certificate2> GenerateSigned(serverType serverType, PL.Certs issuer, PL.Certs requester)
        {
            X509Certificate2 issuerCertificate = new X509Certificate2(issuer.ss_cert);
            using RSA issuerPrivateKey = issuerCertificate.GetRSAPrivateKey();

            if (requester.ss_duration < 1)
            {
                return Result.Fail($"Certificate Duration <=1 month");
            }

            Result<X500DistinguishedName> DNresult = DNBuilder(requester);
            if (!DNresult.IsSuccess) return Result.Fail($"{DNresult.Reasons[0].Message}");

            using (RSA requesterKey = RSA.Create())
            {
                requesterKey.ImportFromPem(requester.private_key);

                var req = new CertificateRequest(
                    DNresult.Value,
                    requesterKey,
                    HashAlgorithmName.SHA256,
                    RSASignaturePadding.Pkcs1);

                req.CertificateExtensions.Add(Global.caBasicConstraint);
                req.CertificateExtensions.Add(Global.caKeyUsageExtension);
                req.CertificateExtensions.Add(new X509SubjectKeyIdentifierExtension(req.PublicKey, false));

                DateTimeOffset notBefore = DateTimeOffset.UtcNow.AddDays(-1);
                DateTimeOffset notAfter = notBefore.AddMonths(requester.ss_duration);

                X509Certificate2 requesterCertificate = req.Create(issuerCertificate, notBefore, notAfter, Utils.Tools.GenerateSerialnumber(requester));
                X509Certificate2 certWithKey = requesterCertificate.CopyWithPrivateKey(requesterKey);

                return certWithKey;
            }
        }

        public static Result<X509Certificate2> CreateCertificate(serverType table, string requestPrivKey, X500DistinguishedName distinguishedName, byte[] issuerCert, string issuerPasswd, int requesterDuration, long requesterSerialNumber)
        {
            byte[] sN = BitConverter.GetBytes(requesterSerialNumber);
            X509Certificate2 caCertificate;
            CertificateRequest intermediateRequest;
            X509Certificate2 signedCertificate;

            using (RSA rsa = RSA.Create())
            {
                rsa.ImportFromPem(requestPrivKey);

                intermediateRequest = new CertificateRequest(distinguishedName, rsa, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
                if (table == serverType.ca)
                {
                    intermediateRequest.CertificateExtensions.Add(Global.caBasicConstraint);
                    intermediateRequest.CertificateExtensions.Add(Global.caKeyUsageExtension);
                    intermediateRequest.CertificateExtensions.Add(new X509SubjectKeyIdentifierExtension(intermediateRequest.PublicKey, false));
                }
                else if (table == serverType.intermediate)
                {
                    intermediateRequest.CertificateExtensions.Add(Global.caBasicConstraint);
                    intermediateRequest.CertificateExtensions.Add(new X509KeyUsageExtension(X509KeyUsageFlags.KeyCertSign | X509KeyUsageFlags.CrlSign, true));
                }
                else if (table == serverType.server)
                {
                    intermediateRequest.CertificateExtensions.Add(new X509BasicConstraintsExtension(false, false, 0, true));
                    intermediateRequest.CertificateExtensions.Add(new X509KeyUsageExtension(X509KeyUsageFlags.DigitalSignature | X509KeyUsageFlags.KeyEncipherment, true));
                    intermediateRequest.CertificateExtensions.Add(new X509EnhancedKeyUsageExtension(new OidCollection { new Oid(serverAuth2) }, false));
                }
                else if (table == serverType.user)
                {
                    intermediateRequest.CertificateExtensions.Add(new X509BasicConstraintsExtension(false, false, 0, true));
                    intermediateRequest.CertificateExtensions.Add(new X509KeyUsageExtension(X509KeyUsageFlags.DataEncipherment | X509KeyUsageFlags.NonRepudiation | X509KeyUsageFlags.DigitalSignature | X509KeyUsageFlags.KeyEncipherment, true));
                    intermediateRequest.CertificateExtensions.Add(new X509EnhancedKeyUsageExtension(new OidCollection { new Oid(clientAuth2) }, false));
                }
                if (table == serverType.ca)
                {
                    signedCertificate = intermediateRequest.CreateSelfSigned(DateTimeOffset.Now, DateTimeOffset.Now.AddMonths(requesterDuration));

                    return Result.Ok(signedCertificate);
                }
                else
                {
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
        public static X509Certificate2Collection ChainCaIntCerts(X509Certificate2 signedInterCert, X509Certificate2 signedCaCert)
        {
            X509Certificate2Collection chain = new X509Certificate2Collection();
            chain.Add(signedInterCert);
            chain.Add(signedCaCert);

            return chain;
        }
        public static Result<X500DistinguishedName> DNBuilder(PL.Certs certs)
        {
            try
            {
                X500DistinguishedNameBuilder DNs = new X500DistinguishedNameBuilder();
                DNs.AddCountryOrRegion(certs.subj_country);
                DNs.AddStateOrProvinceName(certs.subj_state);
                DNs.AddLocalityName(certs.subj_location);
                DNs.AddOrganizationName(certs.subj_organisation);
                DNs.AddOrganizationalUnitName(certs.subj_orgaunit);
                DNs.AddCommonName(certs.subj_commonname);
                DNs.AddEmailAddress(certs.subj_email);

                return Result.Ok(DNs.Build());
            }
            catch (Exception ex)
            { return Result.Fail($"{ex.Message}"); }
        }


        public static void CheckPrivateKey(X509Certificate2 caCertificate)
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
        public static string GetServerName(Server form, serverType type)
        {
            return type switch
            {
                serverType.ca => (string)form.lb_ca_certs.SelectedItem,
                serverType.intermediate => (string)form.lb_int_certs.SelectedItem,
                serverType.server => (string)form.lb_server_certs.SelectedItem,
                serverType.user => (string)form.lb_user_certs.SelectedItem,
                _ => string.Empty
            };
        }
        public static int GetDuration(Server form, serverType type)
        {
            return type switch
            {
                serverType.ca => Convert.ToInt32(form.tb_ca_dura.Text),
                serverType.intermediate => Convert.ToInt32(form.tb_int_dura.Text),
                serverType.server => Convert.ToInt32(form.tb_server_dura.Text),
                serverType.user => Convert.ToInt32(form.tb_user_dura.Text),
                _ => 0
            };
        }
        public static object GetServerList(Server form, serverType type)
        {
            return type switch
            {
                serverType.ca => form.lb_ca_certs,
                serverType.intermediate => form.lb_int_certs,
                serverType.server => form.lb_server_certs,
                serverType.user => form.lb_user_certs,
                _ => null
            };
        }
        public static int GetKeySize(Server form, serverType type)
        {
            return type switch
            {
                serverType.ca => Convert.ToInt32(form.cb_ca_keySize.SelectedItem),
                serverType.intermediate => Convert.ToInt32(form.cb_int_keySize.SelectedItem),
                serverType.server => Convert.ToInt32(form.cb_server_keySize.SelectedItem),
                serverType.user => Convert.ToInt32(form.cb_user_keySize.SelectedItem),
                _ => 0
            };
        }

        public static void UpdateCertList(Server form, serverType type, string selectedName)
        {
            var listBox = type switch
            {
                serverType.ca => form.lb_ca_certs,
                serverType.intermediate => form.lb_int_certs,
                serverType.server => form.lb_server_certs,
                serverType.user => form.lb_user_certs,
                _ => null
            };

            if (listBox != null)
            {
                listBox.Items.Clear();
                //Server.ReadServers(listBox, type);
                Server.read(listBox, type);
                listBox.Sorted = true;
                listBox.SelectedItem = selectedName;
            }
        }
        public static Result SaveFile(string defaultFileName, string filter, string content)
        {
            try
            {
                using (SaveFileDialog SaveFile = new SaveFileDialog())
                {
                    SaveFile.FileName = defaultFileName;
                    SaveFile.Filter = filter;
                    SaveFile.AddExtension = true;
                    SaveFile.RestoreDirectory = true;

                    if (SaveFile.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = SaveFile.FileName;
                        if (!string.IsNullOrEmpty(filePath))
                        {
                            File.WriteAllText(filePath, content);
                            return Result.Ok();
                        }
                        else
                        {
                            return Result.Fail("No Filename given");
                        }
                    }
                    return Result.Ok();
                }
            }
            catch (Exception ex)
            {
                return Result.Fail(Convert.ToString(ex));
            }
        }
        public static Result SaveFile(string defaultFileName, string fileExtension, string filter, string content)
        {
            try
            {
                using (SaveFileDialog SaveFile = new SaveFileDialog())
                {
                    SaveFile.FileName = defaultFileName + fileExtension;
                    SaveFile.Filter = filter;
                    SaveFile.AddExtension = true;
                    SaveFile.RestoreDirectory = true;

                    if (SaveFile.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = SaveFile.FileName;
                        if (!string.IsNullOrEmpty(filePath))
                        {
                            File.WriteAllText(filePath, content);
                            return Result.Ok();
                        }
                        else
                        {
                            return Result.Fail("No Filename given");
                        }
                    }
                    return Result.Ok();
                }
            }
            catch (Exception ex)
            {
                return Result.Fail(Convert.ToString(ex));
            }
        }
        public static byte[] GenerateSerialnumber(PL.Certs cert)
        {
            int cTempSerialNumber = Convert.ToInt32(cert.serialNumber);
            cTempSerialNumber++;
            string time = DateTime.Now.ToString("ddMMyyyy");
            long serialNumber = long.Parse($"{cTempSerialNumber}{time}");
            byte[] bSerialNumber = BitConverter.GetBytes(serialNumber);
            cert.serialNumber = cTempSerialNumber;
            return bSerialNumber;
        }
        public static void SavePassword(string plainPassword, string masterPassword)
        {
            // 1. Salt und IV generieren
            byte[] salt = GenerateRandomBytes(SaltSize);
            byte[] iv = GenerateRandomBytes(IvSize);

            // 2. Schlüssel aus Masterpasswort + Salt ableiten
            byte[] key = DeriveKey(masterPassword, salt);

            // 3. Passwort verschlüsseln
            byte[] encrypted = EncryptStringToBytes_Aes(plainPassword, key, iv);

            // 4. Salt + IV + verschlüsselte Daten speichern (Base64 getrennt mit :)
            string output = $"{Convert.ToBase64String(salt)}:{Convert.ToBase64String(iv)}:{Convert.ToBase64String(encrypted)}";
            File.WriteAllText(FilePath, output);
        }
        // Passwort entschlüsseln
        public static string LoadPassword(string masterPassword)
        {
            if (!File.Exists(FilePath))
                throw new FileNotFoundException("Verschlüsselte Datei nicht gefunden.");

            string input = File.ReadAllText(FilePath);
            var parts = input.Split(':');
            if (parts.Length != 3)
                throw new FormatException("Dateiformat ungültig.");

            byte[] salt = Convert.FromBase64String(parts[0]);
            byte[] iv = Convert.FromBase64String(parts[1]);
            byte[] cipherText = Convert.FromBase64String(parts[2]);

            byte[] key = DeriveKey(masterPassword, salt);
            return DecryptStringFromBytes_Aes(cipherText, key, iv);
        }
        // Schlüssel ableiten
        private static byte[] DeriveKey(string password, byte[] salt)
        {
            using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256);
            return pbkdf2.GetBytes(KeySize);
        }

        // Verschlüsselung
        private static byte[] EncryptStringToBytes_Aes(string plainText, byte[] key, byte[] iv)
        {
            using var aes = Aes.Create();
            aes.Key = key;
            aes.IV = iv;

            using var encryptor = aes.CreateEncryptor();
            using var ms = new MemoryStream();
            using var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write);
            using var sw = new StreamWriter(cs);
            sw.Write(plainText);
            sw.Close();
            return ms.ToArray();
        }

        // Entschlüsselung
        private static string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] key, byte[] iv)
        {
            using var aes = Aes.Create();
            aes.Key = key;
            aes.IV = iv;

            using var decryptor = aes.CreateDecryptor();
            using var ms = new MemoryStream(cipherText);
            using var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
            using var sr = new StreamReader(cs);
            return sr.ReadToEnd();
        }

        private static byte[] GenerateRandomBytes(int length)
        {
            byte[] data = new byte[length];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(data);
            return data;
        }

        public static byte[] GenerateRandomSerialNumber(int byteLength)
        {
            if (byteLength < 1)
                throw new ArgumentException("Die Länge der Seriennummer muss mindestens 1 Byte sein.", nameof(byteLength));

            byte[] serialNumber = new byte[byteLength];
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(serialNumber);
            }
            serialNumber[0] &= 0x7F;

            return serialNumber;
        }

        public enum serverType
        {
            ca,
            intermediate,
            server,
            user
        }
        public enum certType
        {
            priv,
            pub,
            selfSigned,
            csr,
            signed
        }
        public enum fdqnType
        {
            write,
            read
        }
        public enum columnType
        {
            name,
            id
        }
        public enum info
        {
            CertInfoWrite,
            CertInfoRead,
            ServerCredentialWrite
        }
    }
}
