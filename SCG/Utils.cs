using FluentResults;
using Microsoft.Data.Sqlite;
using Renci.SshNet;
using SCG;
using SCG.Forms;
using System.Buffers;
using System.Data;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using static PL.Utils.Tools;
using static SCG.Forms.Server;


namespace PL;

public class Utils
{
    private const string serverAuth2 = "1.3.6.1.5.5.7.3.1";
    private const string clientAuth2 = "1.3.6.1.5.5.7.3.2";
    private static readonly string[] s_pubCert = ["public_cert", "public_createDT"];
    private static readonly string[] s_ssCert = ["ss_cert", "ss_createDT", "ss_duration"];
    private static readonly string[] s_destNames = ["subj_country", "subj_state", "subj_location", "subj_organisation", "subj_orgaunit", "subj_commonname", "subj_email"];




    private static readonly Dictionary<string, string> s_certDetails = new Dictionary<string, string>
                {
                    { "cert_filename", string.Empty },
                    { "cert_priv_ext", string.Empty },
                    { "cert_pub_ext", string.Empty },
                    { "cert_path", string.Empty }
                };
    private static Dictionary<string, string> _serverDetails = new Dictionary<string, string>
                {
                    { "host_name", string.Empty },
                    { "host_username", string.Empty },
                    { "host_password", string.Empty }

                };
    static SqliteConnection _connection = Server.sqlconnection;
    private static readonly string[] s_sqlColumns = ["id", "name", "keySize", "private_key", "private_createDT", "public_cert", "public_createDT", "signed_against", "signed_createDT", "certsign_req", "certsign_req_createDT", "ss_cert", "ss_createDT", "ss_duration", "subj_country", "subj_state", "subj_location", "subj_organisation", "subj_orgaunit", "subj_commonname", "subj_email", "serialNumber", "host_name", "host_username", "host_password", "cert_filename", "cert_priv_ext", "cert_pub_ext", "cert_path", "cert_autoupload"];

    public static Dictionary<string, object> dictCaDetails = new Dictionary<string, object>();
    //{
    //    { "id", null },
    //    { "name", null },
    //    { "keySize", null },
    //    { "private_key", null },
    //    { "private_createDT", null },
    //    { "public_cert", null },
    //    { "public_createDT", null },
    //    { "ss_cert", null },
    //    { "ss_createDT", null },
    //    { "ss_duration", null },
    //    { "subj_country", null },
    //    { "subj_state", null },
    //    { "subj_location", null },
    //    { "subj_organisation", null },
    //    { "subj_orgaunit", null },
    //    { "subj_commonname", null },
    //    { "subj_email", null},
    //    { "serialNumber", null },
    //    { "host_name", null },
    //    { "host_username", null },
    //    { "host_password", null },
    //    { "cert_filename", null },
    //    { "cert_priv_ext", null },
    //    { "cert_pub_ext", null },
    //    { "cert_path", null },
    //    { "cert_autoupload", null }
    //};
    public static Dictionary<string, object> dictInterDetails = new Dictionary<string, object>();
    //{
    //    { "id", string.Empty },
    //    { "name", string.Empty },
    //    { "keySize", string.Empty },
    //    { "private_key", string.Empty },
    //    { "private_createDT", string.Empty },
    //    { "public_cert", string.Empty },
    //    { "public_createDT", string.Empty },
    //    { "ss_cert", string.Empty },
    //    { "ss_createDT", string.Empty },
    //    { "ss_duration", string.Empty },
    //    { "subj_country", string.Empty },
    //    { "subj_state", string.Empty },
    //    { "subj_location", string.Empty },
    //    { "subj_organisation", string.Empty },
    //    { "subj_orgaunit", string.Empty },
    //    { "subj_commonname", string.Empty },
    //    { "subj_email", string.Empty },
    //    { "serialNumber", string.Empty },
    //    { "host_name", string.Empty },
    //    { "host_username", string.Empty },
    //    { "host_password", string.Empty },
    //    { "cert_filename", string.Empty },
    //    { "cert_priv_ext", string.Empty },
    //    { "cert_pub_ext", string.Empty },
    //    { "cert_path", string.Empty },
    //    { "cert_autoupload", string.Empty }
    //};
    public static Dictionary<string, object> dictServerDetails = new Dictionary<string, object>();
    //    {
    //        { "id", string.Empty
    //},
    //        { "name", string.Empty },
    //        { "keySize", string.Empty },
    //        { "private_key", string.Empty },
    //        { "private_createDT", string.Empty },
    //        { "public_cert", string.Empty },
    //        { "public_createDT", string.Empty },
    //        { "ss_cert", string.Empty },
    //        { "ss_createDT", string.Empty },
    //        { "ss_duration", string.Empty },
    //        { "subj_country", string.Empty },
    //        { "subj_state", string.Empty },
    //        { "subj_location", string.Empty },
    //        { "subj_organisation", string.Empty },
    //        { "subj_orgaunit", string.Empty },
    //        { "subj_commonname", string.Empty },
    //        { "subj_email", string.Empty },
    //        { "serialNumber", string.Empty },
    //        { "host_name", string.Empty },
    //        { "host_username", string.Empty },
    //        { "host_password", string.Empty },
    //        { "cert_filename", string.Empty },
    //        { "cert_priv_ext", string.Empty },
    //        { "cert_pub_ext", string.Empty },
    //        { "cert_path", string.Empty },
    //        { "cert_autoupload", string.Empty }
    //    };
    public static Dictionary<string, object> targetDict = new Dictionary<string, object>();
    public static Dictionary<string, object> signerDict = new Dictionary<string, object>();
    public static Dictionary<string, object> dictUserDetails = new Dictionary<string, object>();
    //{
    //    { "id", string.Empty },
    //    { "name", string.Empty },
    //    { "keySize", string.Empty },
    //    { "private_key", string.Empty },
    //    { "private_createDT", string.Empty },
    //    { "public_cert", string.Empty },
    //    { "public_createDT", string.Empty },
    //    { "ss_cert", string.Empty },
    //    { "ss_createDT", string.Empty },
    //    { "ss_duration", string.Empty },
    //    { "subj_country", string.Empty },
    //    { "subj_state", string.Empty },
    //    { "subj_location", string.Empty },
    //    { "subj_organisation", string.Empty },
    //    { "subj_orgaunit", string.Empty },
    //    { "subj_commonname", string.Empty },
    //    { "subj_email", string.Empty },
    //    { "serialNumber", string.Empty },
    //    { "host_name", string.Empty },
    //    { "host_username", string.Empty },
    //    { "host_password", string.Empty },
    //    { "cert_filename", string.Empty },
    //    { "cert_priv_ext", string.Empty },
    //    { "cert_pub_ext", string.Empty },
    //    { "cert_path", string.Empty },
    //    { "cert_autoupload", string.Empty }
    //};
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
                    {
                        sftp.UploadFile(memoryStream, remoteFilePath);
                    }
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
                    {
                        sftp.UploadFile(memoryStream, remoteFilePath);
                    }
                    sftp.Disconnect();
                }
            }
            catch (Exception ex)
            { MessageBox.Show(Convert.ToString(ex)); }
        }

        public static void DownloadCert(string host, string localFilePath, string remoteFilePath)
        {
            try
            {

            }
            catch (Exception ex)

            {
                MessageBox.Show(Convert.ToString(ex));
            }
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
        public static string[] GetServerDetails(serverType table, string serverName)
        {
            try
            {
                string[] str = new string[3];

                SqliteConnectionStringBuilder _connectionString = new SqliteConnectionStringBuilder();
                _connectionString.Mode = SqliteOpenMode.ReadWriteCreate;
                _connectionString.DataSource = Global.database;
                _connectionString.Password = null;
                string connectionString = _connectionString.ToString();
                using var connection = new SqliteConnection(connectionString);
                connection.Open();

                string column = string.Join(",", _serverDetails.Keys);
                var sql = $"SELECT {column} FROM {table} WHERE name=@_searchValue"; // geht nicht 
                using var command = new SqliteCommand(sql, connection);

                command.Parameters.AddWithValue("@_searchValue", serverName);
                using var reader = command.ExecuteReader();
                int i = 0;
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        foreach (string key in _serverDetails.Keys)
                        {
                            str[i] = reader[key]?.ToString();
                            i++;
                        }
                    }
                }
                connection.Close();
                return str;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static string[] GetCaServerDetails(string serverName)
        {
            try
            {
                int i = 0;
                string[] str = new string[3];

                string column = string.Join(",", _serverDetails.Keys);
                var sql = $"SELECT {column} FROM ca WHERE name=@_searchValue";

                using var command = new SqliteCommand(sql, DatabaseConnection.GetInstance().GetConnection());

                command.Parameters.AddWithValue("@_searchValue", serverName);
                using var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        foreach (string key in _serverDetails.Keys)
                        {
                            str[i] = reader[key]?.ToString();
                            i++;
                        }
                    }
                }
                //connection.Close();
                return str;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        /// <param name="serverName"></param>
        /// <returns>privatekey,publickey, remotePathPrivateKey, remotePathPublicKey</returns>
        public static string[] GetCertDetails(serverType table, string serverName)
        {
            try
            {
                string[] str = new string[4];

                SqliteConnectionStringBuilder _connectionString = new SqliteConnectionStringBuilder();
                _connectionString.Mode = SqliteOpenMode.ReadWriteCreate;
                _connectionString.DataSource = Global.database;
                _connectionString.Password = null;
                string connectionString = _connectionString.ToString();
                using var connection = new SqliteConnection(connectionString);
                connection.Open();

                string column = string.Join(",", s_certDetails.Keys);
                var sql = $"SELECT {column} FROM {table} WHERE name=@_searchValue"; // geht nicht 
                using var command = new SqliteCommand(sql, connection);

                command.Parameters.AddWithValue("@_searchValue", serverName);
                using var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        foreach (string key in s_certDetails.Keys)
                        {
                            s_certDetails[key] = reader[key]?.ToString();
                        }
                    }
                }
                connection.Close();
                str[0] = s_certDetails["cert_filename"] + "." + s_certDetails["cert_priv_ext"];
                str[1] = s_certDetails["cert_filename"] + "." + s_certDetails["cert_pub_ext"];
                str[2] = s_certDetails["cert_path"] + str[0];
                str[3] = s_certDetails["cert_path"] + str[1];


                return str;
            }
            catch (Exception)
            {

                throw;
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
        public static Result<int> InsertInto(serverType table, string _name, string privKey, int _keySize)
        {
            try
            {
                string name = (string)dictCaDetails["name"];
                string keySize = (string)dictCaDetails["keySize"];
                string private_key = (string)dictCaDetails["private_key"];
                string sql = $"INSERT INTO {table} (name, keySize, private_key, private_createDT) VALUES (@_name, @_keySize, @_private_key, @_priv_createDT)";

                using var command = new SqliteCommand(sql, _connection);
                command.Parameters.AddWithValue("@_name", name);
                command.Parameters.AddWithValue("@_keySize", keySize);
                command.Parameters.AddWithValue("@_private_key", private_key);
                command.Parameters.AddWithValue("@_priv_createDT", DateTime.Now.ToString());

                return command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                if (ex == null)
                {
                    //return 0; //
                    return Result.Fail("Possible wrong SQL credentials");
                }
                else
                {
                    //return 0; //
                    return Result.Fail(ex.Message);
                }
            }
        }
        /// <summary>
        /// Create and insert first row of this server to the SQL table
        /// </summary>
        /// <param name="table"></param>
        /// <param name="_name"></param>
        /// <returns></returns>
        public static Result<int> InsertInto(serverType table, string _name)
        {
            try
            {
                switch (table)
                {
                    case serverType.ca:
                        if (_name == (string)targetDict["name"])
                        {
                            string name = (string)targetDict["name"];
                            long keySize = (long)targetDict["keySize"];
                            string private_key = (string)targetDict["private_key"];
                            string sql = $"INSERT INTO {table} (name, keySize, private_key, private_createDT) VALUES (@_name, @_keySize, @_private_key, @_priv_createDT)";

                            using var command = new SqliteCommand(sql, _connection);
                            command.Parameters.AddWithValue("@_name", name);
                            command.Parameters.AddWithValue("@_keySize", keySize);
                            command.Parameters.AddWithValue("@_private_key", private_key);
                            command.Parameters.AddWithValue("@_priv_createDT", DateTime.Now.ToString());

                            return Result.Ok(command.ExecuteNonQuery());
                        }
                        return Result.Fail("Servername is different");
                    case serverType.intermediate:
                        if (_name == (string)targetDict["name"])
                        {
                            string name = (string)targetDict["name"];
                            long keySize = (long)targetDict["keySize"];
                            string private_key = (string)targetDict["private_key"];
                            string sql = $"INSERT INTO {table} (name, keySize, private_key, private_createDT) VALUES (@_name, @_keySize, @_private_key, @_priv_createDT)";

                            using var command = new SqliteCommand(sql, _connection);
                            command.Parameters.AddWithValue("@_name", name);
                            command.Parameters.AddWithValue("@_keySize", keySize);
                            command.Parameters.AddWithValue("@_private_key", private_key);
                            command.Parameters.AddWithValue("@_priv_createDT", DateTime.Now.ToString());

                            return Result.Ok(command.ExecuteNonQuery());
                        }
                        return Result.Fail("Servername is different");


                        //if (_name == (string)dictInterDetails["name"])
                        //{
                        //    string name = (string)dictInterDetails["name"];
                        //    string keySize = (string)dictInterDetails["keySize"];
                        //    string private_key = (string)dictInterDetails["private_key"];
                        //    string sql = $"INSERT INTO {table} (name, keySize, private_key, private_createDT) VALUES (@_name, @_keySize, @_private_key, @_priv_createDT)";

                        //    using var command = new SqliteCommand(sql, _connection);
                        //    command.Parameters.AddWithValue("@_name", name);
                        //    command.Parameters.AddWithValue("@_keySize", keySize);
                        //    command.Parameters.AddWithValue("@_private_key", private_key);
                        //    command.Parameters.AddWithValue("@_priv_createDT", DateTime.Now.ToString());

                        //    return Result.Ok(command.ExecuteNonQuery());
                        //}

                        return Result.Fail($"Not implemented");
                    case serverType.server:
                        if (_name == (string)dictServerDetails["name"])
                        {
                            string name = (string)dictServerDetails["name"];
                            string keySize = (string)dictServerDetails["keySize"];
                            string private_key = (string)dictServerDetails["private_key"];
                            string sql = $"INSERT INTO {table} (name, keySize, private_key, private_createDT) VALUES (@_name, @_keySize, @_private_key, @_priv_createDT)";

                            using var command = new SqliteCommand(sql, _connection);
                            command.Parameters.AddWithValue("@_name", name);
                            command.Parameters.AddWithValue("@_keySize", keySize);
                            command.Parameters.AddWithValue("@_private_key", private_key);
                            command.Parameters.AddWithValue("@_priv_createDT", DateTime.Now.ToString());

                            return Result.Ok(command.ExecuteNonQuery());
                        }
                        return Result.Fail("Servername is different");
                    case serverType.user:
                        return Result.Fail($"Not implemented");

                }
                return Result.Fail(SqlSelect("*", table).ToString());
            }
            catch (Exception ex)
            {
                if (ex == null)
                {
                    //return 0; //
                    return Result.Fail("Possible wrong SQL credentials");
                }
                else
                {
                    //return 0; //
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
        public static Result<bool> Select(serverType table, string serverName)
        {

                string sql = $"SELECT * FROM {table} WHERE name=@serverName";
                using var command = new SqliteCommand(sql, _connection);
                command.Parameters.AddWithValue("@serverName", serverName);

                using var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    string item = string.Empty;
                    while (reader.Read())
                    {
                        for (int j = 0; j < reader.FieldCount; j++)
                        {
                            item = reader.GetName(j);
                            if (!reader.IsDBNull(0))
                            {
                                switch (reader.GetFieldType(item).Name.ToString())
                                {
                                    case "String":
                                        //dictCaDetails[item] = reader.GetString(item);
                                        DictWriter.setValue(targetDict, item, reader.GetString(item));
                                    break;
                                    case "Int64":
                                        //dictCaDetails[item] = reader.GetInt64(item);
                                        DictWriter.setValue(targetDict, item, reader.GetInt64(item));
                                    break;
                                    case "Byte[]":
                                        long length = reader.GetBytes(item, 0, null, 0, 0); // BLOB-Größe ermitteln
                                        byte[] buffer = new byte[length];
                                        reader.GetBytes(7, 0, buffer, 0, buffer.Length);
                                        //dictCaDetails[item] = (byte[])reader[item];
                                    DictWriter.setValue(targetDict, item, (byte[])reader[item]);
                                    break;
                                    default:
                                        return Result.Fail($"Unknown Datatype from SQLite database received! On column: {item}, with the DataType: {reader.GetFieldType(item).Name.ToString()}");
                                }
                            }
                            else
                            { return Result.Fail($"Column {item} is NULL"); }
                        }
                    }
                    return true;
                }
                return Result.Fail("Nothing to read");
        }

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
        public static Result<int> Update(serverType table, string serverName, string[] columns)
        {
            try
            {
                int rowIns = 0;
                using (var command = _connection.CreateCommand())
                {
                    foreach (var column in columns)
                    {
                        if (column == "public_createDT" || column == "private_createDT" || column == "ss_createDT" || column == "certsign_req_createDT")
                        {
                            if (table == serverType.ca)
                            { dictCaDetails[column] = DateTime.Now.ToString(); }
                            else if (table == serverType.intermediate)
                            { dictInterDetails[column] = DateTime.Now.ToString(); }
                            else if (table == serverType.server)
                            { dictServerDetails[column] = DateTime.Now.ToString(); }
                            else if (table == serverType.user)
                            { dictUserDetails[column] = DateTime.Now.ToString(); }
                        }


                        command.Parameters.Clear();
                        command.CommandText = $"UPDATE {table} SET {column} = @_value WHERE name = @_searchTerm";

                        if (table == serverType.ca)
                        { command.Parameters.AddWithValue("@_value", dictCaDetails[column]); }
                        else if (table == serverType.intermediate)
                        { command.Parameters.AddWithValue("@_value", dictInterDetails[column]); }
                        else if (table == serverType.server)
                        { command.Parameters.AddWithValue("@_value", dictServerDetails[column]); }
                        else if (table == serverType.user)
                        { command.Parameters.AddWithValue("@_value", dictUserDetails[column]); }


                        command.Parameters.AddWithValue("@_searchTerm", serverName);

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
        public static Result<int>
            Update(serverType table, string serverName, string[] columns, int type)
        {
            try
            {
                int rowIns = 0;
                using (var command = _connection.CreateCommand())
                {
                    switch (type)
                    {
                        case 0:
                            {
                                return Result.Fail("Not implemented");
                            }
                        case 1: //Public Cert
                            {
                                foreach (string column in s_pubCert)
                                {
                                    if (column.Equals("public_createDT"))
                                    {
                                        //dictCaDetails[column] = DateTime.Now.ToString();
                                        if (table == serverType.ca)
                                        {
                                            dictCaDetails[column] = DateTime.Now.ToString();
                                        }
                                        else if (table == serverType.intermediate)
                                        {
                                            dictInterDetails[column] = DateTime.Now.ToString();
                                        }
                                        else if (table == serverType.server)
                                        {
                                            dictServerDetails[column] = DateTime.Now.ToString();
                                        }
                                        else if (table == serverType.user)
                                        {
                                            dictUserDetails[column] = DateTime.Now.ToString();
                                        }
                                    }
                                    command.Parameters.Clear();
                                    command.CommandText = $"UPDATE {table} SET {column} = @_value WHERE name = @_searchTerm";

                                    if (table == serverType.ca)
                                    {
                                        command.Parameters.AddWithValue("@_value", dictCaDetails[column]);
                                    }
                                    else if (table == serverType.intermediate)
                                    {
                                        command.Parameters.AddWithValue("@_value", dictInterDetails[column]);
                                    }
                                    else if (table == serverType.server)
                                    {
                                        command.Parameters.AddWithValue("@_value", dictServerDetails[column]);
                                    }
                                    else if (table == serverType.user)
                                    {
                                        command.Parameters.AddWithValue("@_value", dictUserDetails[column]);
                                    }

                                    command.Parameters.AddWithValue("@_searchTerm", serverName);

                                    int rowInserted = command.ExecuteNonQuery();
                                    rowIns += rowInserted;
                                }
                                return Result.Ok(rowIns);
                            }
                        case 2: // Dest Names
                            {
                                foreach (var column in s_destNames)
                                {
                                    command.Parameters.Clear();
                                    command.CommandText = $"UPDATE {table} SET {column} = @_value WHERE name = @_searchTerm";

                                    if (table == serverType.ca)
                                    {
                                        command.Parameters.AddWithValue("@_value", dictCaDetails[column]);
                                    }
                                    else if (table == serverType.intermediate)
                                    {
                                        command.Parameters.AddWithValue("@_value", dictInterDetails[column]);
                                    }
                                    else if (table == serverType.server)
                                    {
                                        command.Parameters.AddWithValue("@_value", dictServerDetails[column]);
                                    }
                                    else if (table == serverType.user)
                                    {
                                        command.Parameters.AddWithValue("@_value", dictUserDetails[column]);
                                    }

                                    command.Parameters.AddWithValue("@_searchTerm", serverName);

                                    int rowInserted = command.ExecuteNonQuery();
                                    rowIns += rowInserted;

                                }
                                return Result.Ok(rowIns);
                            }
                        case 3: // selfSigned Update
                            {
                                foreach (var column in s_ssCert)
                                {
                                    if (column == "ss_createDT")
                                    {
                                        dictCaDetails[column] = DateTime.Now.ToString();
                                    }
                                    command.Parameters.Clear();
                                    command.CommandText = $"UPDATE {table} SET {column} = @_value WHERE name = @_searchTerm";

                                    command.Parameters.AddWithValue("@_value", dictCaDetails[column]);
                                    command.Parameters.AddWithValue("@_searchTerm", serverName);

                                    int rowInserted = command.ExecuteNonQuery();
                                    rowIns += rowInserted;
                                }
                                return Result.Ok(rowIns);
                            }
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
        public static Result<X509Certificate2> CreateSelfSignedCertificate1(serverType serverType, string serverName)
        {
            try
            {
                X509Certificate2 caCertificate;
                CertificateRequest request;
                X509Certificate2 selfSignedCertificate;
                Result<X500DistinguishedName> DNresult = DNBuilder(serverType, serverName);
                if (!DNresult.IsSuccess) return Result.Fail("DNBuilder failed");

                using (RSA rsa = RSA.Create())
                {
                    rsa.ImportFromPem((string)targetDict["private_key"]);
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
                        int cTempSerialNumber = Convert.ToInt32(targetDict["serialNumber"]);
                        cTempSerialNumber++;
                        string time = DateTime.Now.ToString("ddMMyyyy");
                        long serialNumber = long.Parse($"{cTempSerialNumber}{time}");
                        #endregion
                        int month = (int)targetDict["ss_duration"];
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
        public static Result<X509Certificate2> CreateCertSigningRequest(serverType table, string serverName)
        {
            try
            {
                //X500DistinguishedName distinguishedName = DNBuilder(table, serverName).Value;
                Result<X500DistinguishedName> DNresult = DNBuilder(table, serverName);
                CertificateRequest intermediateRequest;
                X509Certificate2 signedCertificate;

                #region test
                //using (RSA rsa = RSA.Create())
                //{
                //    rsa.ImportFromPem(dictCaDetails["private_key"]);
                //    CertificateRequest request = new CertificateRequest(new X500DistinguishedName(dictCaDetails["subj_country"], dictCaDetails["subj_state"], dictCaDetails["subj_location"], dictCaDetails["subj_organisation"], dictCaDetails["subj_orgaunit"], dictCaDetails["subj_commonname"], dictCaDetails["subj_email"]), rsa, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
                //    request.CertificateExtensions.Add(new X509BasicConstraintsExtension(true, false, 0, true));
                //    request.CertificateExtensions.Add(new X509KeyUsageExtension(X509KeyUsageFlags.KeyCertSign | X509KeyUsageFlags.CrlSign, true));
                //    request.CertificateExtensions.Add(new X509SubjectKeyIdentifierExtension(request.PublicKey, false));
                //    Certificate = request.CreateSelfSigned(DateTimeOffset.Now, DateTimeOffset.Now.AddMonths(12));
                //    sN = Certificate.GetSerialNumber();
                //    dictCaDetails["serialNumber"] = sN.ToString();
                //    dictCaDetails["ss_cert"] = Certificate.Export(X509ContentType.Cert).ToString();
                //    dictCaDetails["ss_createDT"] = DateTime.Now.ToString();
                //    dictCaDetails["ss_duration"] = "12";
                //    dictCaDetails["public_cert"] = Certificate.Export(X509ContentType.Cert).ToString();
                //    dictCaDetails["public_createDT"] = DateTime.Now.ToString();
                //    dictCaDetails["ss_cert"] = Certificate.Export(X509ContentType.Cert).ToString();
                //    dictCaDetails["ss_createDT"] = DateTime.Now.ToString();
                //    dictCaDetails["ss_duration"] = "12";
                //    dictCaDetails["public_cert"] = Certificate.Export(X509ContentType.Cert).ToString();
                //    dictCaDetails["public_createDT"] = DateTime.Now.ToString();
                //    dictCaDetails["ss_cert"] = Certificate.Export(X509ContentType.Cert).ToString();
                //    dictCaDetails["ss_createDT"] = DateTime.Now.ToString();
                //    dictCaDetails["ss_duration"] = "12";
                //    dictCaDetails["public_cert"] = Certificate.Export(X509ContentType.Cert).ToString();
                //    dictCaDetails["public_createDT"] = DateTime.Now.ToString();
                //    dictCaDetails["ss_cert"] = Certificate.Export(X509ContentType.Cert).ToString();
                //    dictCaDetails["ss_createDT"] = DateTime.Now.ToString();
                //    dictCaDetails["ss_duration"] = "
                #endregion
                if (DNresult.IsSuccess)
                {
                     using (RSA rsa = RSA.Create())
                    {
                        intermediateRequest = new CertificateRequest(DNresult.Value, rsa, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);

                        switch (table)
                        {
                            case serverType.ca:
                                rsa.ImportFromPem((string)dictCaDetails["private_key"]);
                                intermediateRequest.CertificateExtensions.Add(Global.caBasicConstraint);
                                intermediateRequest.CertificateExtensions.Add(Global.caKeyUsageExtension);
                                intermediateRequest.CertificateExtensions
                                    .Add(new X509SubjectKeyIdentifierExtension(intermediateRequest.PublicKey, false));
                                signedCertificate = intermediateRequest.CreateSelfSigned(DateTimeOffset.Now, DateTimeOffset.Now
                                    .AddMonths(Convert.ToInt32(dictCaDetails["ss_duration"])));
                                return signedCertificate;

                            case serverType.intermediate:
                                rsa.ImportFromPem((string)dictInterDetails["private_key"]);
                                intermediateRequest.CertificateExtensions.Add(Global.caBasicConstraint);
                                intermediateRequest.CertificateExtensions
                                    .Add(new X509KeyUsageExtension(X509KeyUsageFlags.KeyCertSign |
                                        X509KeyUsageFlags.CrlSign, true));
                                break;
                            case serverType.server:
                                rsa.ImportFromPem((string)dictServerDetails["private_key"]);
                                intermediateRequest.CertificateExtensions
                                    .Add(new X509BasicConstraintsExtension(false, false, 0, true));
                                intermediateRequest.CertificateExtensions
                                    .Add(new X509KeyUsageExtension(X509KeyUsageFlags.DigitalSignature |
                                        X509KeyUsageFlags.KeyEncipherment, true));
                                intermediateRequest.CertificateExtensions
                                    .Add(new X509EnhancedKeyUsageExtension(new OidCollection { new Oid(serverAuth2) }, false));
                                break;

                            case serverType.user:
                                rsa.ImportFromPem((string)dictUserDetails["private_key"]);
                                intermediateRequest.CertificateExtensions
                                    .Add(new X509BasicConstraintsExtension(false, false, 0, true));
                                intermediateRequest.CertificateExtensions
                                    .Add(new X509KeyUsageExtension(X509KeyUsageFlags.DataEncipherment |
                                        X509KeyUsageFlags.NonRepudiation |
                                        X509KeyUsageFlags.DigitalSignature |
                                        X509KeyUsageFlags.KeyEncipherment, true));
                                intermediateRequest.CertificateExtensions
                                    .Add(new X509EnhancedKeyUsageExtension(new OidCollection { new Oid(clientAuth2) }, false));
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            return null;
        }

        //public static void CreateCSR(serverType table, string serverName)
        public static Result<string> CreateCSR(serverType table, string serverName)
        {
            string privateKeyPem = string.Empty;
            string csrKeyPem = string.Empty;
            if (table == serverType.ca)
            { privateKeyPem = (string)dictCaDetails["private_key"]; }
            else if (table == serverType.intermediate)
            { privateKeyPem = (string)dictInterDetails["private_key"]; }
            else if (table == serverType.server)
            { privateKeyPem = (string)dictServerDetails["private_key"]; }
            else if (table == serverType.user)
            { privateKeyPem = (string)dictUserDetails["private_key"]; }
            try
            {
                using (RSA rsa = RSA.Create())
                {
                    rsa.ImportFromPem(privateKeyPem);
                    Result<X500DistinguishedName> DNresult = DNBuilder(table, serverName);

                    var request = new CertificateRequest(DNresult.Value, rsa, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
                    if (table == serverType.intermediate)
                    {
                        request.CertificateExtensions.Add(Global.caBasicConstraint);
                        request.CertificateExtensions.Add(new X509KeyUsageExtension(X509KeyUsageFlags.KeyCertSign | X509KeyUsageFlags.CrlSign, true));
                    }
                    else if (table == serverType.server)
                    {
                        request.CertificateExtensions.Add(new X509BasicConstraintsExtension(false, false, 0, false));
                        //request.CertificateExtensions.Add(new X509BasicConstraintsExtension(false, false, 0, true));
                        request.CertificateExtensions.Add(new X509KeyUsageExtension(X509KeyUsageFlags.DigitalSignature | X509KeyUsageFlags.KeyEncipherment, true));
                        request.CertificateExtensions.Add(new X509EnhancedKeyUsageExtension(new OidCollection { new Oid("1.3.6.1.5.5.7.3.1") }, false));
                        //request.CertificateExtensions.Add(new X509EnhancedKeyUsageExtension(new OidCollection { new Oid(serverAuth2) }, false));
                    }
                    else if (table == serverType.user)
                    {
                        request.CertificateExtensions.Add(new X509BasicConstraintsExtension(false, false, 0, true));
                        request.CertificateExtensions.Add(new X509KeyUsageExtension(X509KeyUsageFlags.DataEncipherment | X509KeyUsageFlags.NonRepudiation | X509KeyUsageFlags.DigitalSignature | X509KeyUsageFlags.KeyEncipherment, true));
                        request.CertificateExtensions.Add(new X509EnhancedKeyUsageExtension(new OidCollection { new Oid(clientAuth2) }, false));
                    }
                    if (table == serverType.ca)
                    { dictCaDetails["certsign_req"] = request.CreateSigningRequestPem(); }
                    else if (table == serverType.intermediate)
                    { dictInterDetails["certsign_req"] = request.CreateSigningRequestPem(); }
                    else if (table == serverType.server)
                    { dictServerDetails["certsign_req"] = request.CreateSigningRequestPem(); }
                    else if (table == serverType.user)
                    { dictUserDetails["certsign_req"] = request.CreateSigningRequestPem(); }

                    return Result.Ok(request.CreateSigningRequestPem());
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public static Result<X509Certificate2> CreateSignedCertificate(serverType table, string serverName, string signerName)
        {
            Result<X500DistinguishedName> DNresult = DNBuilder(table, serverName);
            CertificateRequest certRequestCSR;
            if (table == serverType.intermediate)
            {
                Sql.Select(serverType.ca, )
            }

            if (DNresult.IsSuccess)
            {

                using (RSA rsa = RSA.Create())
                {
                    rsa.ImportFromPem((string)targetDict["private_key"]);

                    certRequestCSR = new CertificateRequest(DNresult.Value, rsa, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);

                    // var caCert = new X509Certificate2("ca.pfx", "deinPasswort", X509KeyStorageFlags.Exportable | X509KeyStorageFlags.PersistKeySet);
                    var caCert = new X509Certificate2((byte[])targetDict["ss_cert"], (string)targetDict["ss_passwd"], X509KeyStorageFlags.Exportable | X509KeyStorageFlags.PersistKeySet);

                }
                return Result.Ok();
            }
            return Result.Fail("false");
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
        //public static X500DistinguishedName DNBuilder(string twoLetterCode, string stateOrProvinceName, string localityName, string organizationName, string organizationalUnitName, string commonName, string emailAddress)
        public static Result<X500DistinguishedName> DNBuilder(serverType serverType, string serverName)
        {
            Result<bool> result = Result.Ok();
            if (result.IsSuccess)
            {
                string CountryOrRegion = string.Empty;
                string StateOrProvinceName = string.Empty;
                string LocalityName = string.Empty;
                string OrganizationName = string.Empty;
                string OrganizationalUnitName = string.Empty;
                string CommonName = string.Empty;
                string EmailAddress = string.Empty;

                if (serverType == serverType.ca)
                {
                    CountryOrRegion = (string)dictCaDetails["subj_country"];
                    StateOrProvinceName = (string)dictCaDetails["subj_state"];
                    LocalityName = (string)dictCaDetails["subj_location"];
                    OrganizationName = (string)dictCaDetails["subj_organisation"];
                    OrganizationalUnitName = (string)dictCaDetails["subj_orgaunit"];
                    CommonName = (string)dictCaDetails["subj_commonname"];
                    EmailAddress = (string)dictCaDetails["subj_email"];
                }
                else if (serverType == serverType.intermediate)
                {
                    CountryOrRegion = (string)dictInterDetails["subj_country"];
                    StateOrProvinceName = (string)dictInterDetails["subj_state"];
                    LocalityName = (string)dictInterDetails["subj_location"];
                    OrganizationName = (string)dictInterDetails["subj_organisation"];
                    OrganizationalUnitName = (string)dictInterDetails["subj_orgaunit"];
                    CommonName = (string)dictInterDetails["subj_commonname"];
                    EmailAddress = (string)dictInterDetails["subj_email"];
                }
                else if (serverType == serverType.server)
                {
                    CountryOrRegion = (string)dictServerDetails["subj_country"];
                    StateOrProvinceName = (string)dictServerDetails["subj_state"];
                    LocalityName = (string)dictServerDetails["subj_location"];
                    OrganizationName = (string)dictServerDetails["subj_organisation"];
                    OrganizationalUnitName = (string)dictServerDetails["subj_orgaunit"];
                    CommonName = (string)dictServerDetails["subj_commonname"];
                    EmailAddress = (string)dictServerDetails["subj_email"];
                }
                else if (serverType == serverType.user)
                {
                    CountryOrRegion = (string)dictUserDetails["subj_country"];
                    StateOrProvinceName = (string)dictUserDetails["subj_state"];
                    LocalityName = (string)dictUserDetails["subj_location"];
                    OrganizationName = (string)dictUserDetails["subj_organisation"];
                    OrganizationalUnitName = (string)dictUserDetails["subj_orgaunit"];
                    CommonName = (string)dictUserDetails["subj_commonname"];
                    EmailAddress = (string)dictUserDetails["subj_email"];
                }

                X500DistinguishedNameBuilder DNs = new X500DistinguishedNameBuilder();
                DNs.AddCountryOrRegion(CountryOrRegion);
                DNs.AddStateOrProvinceName(StateOrProvinceName);
                DNs.AddLocalityName(LocalityName);
                DNs.AddOrganizationName(OrganizationName);
                DNs.AddOrganizationalUnitName(OrganizationalUnitName);
                DNs.AddCommonName(CommonName);
                DNs.AddEmailAddress(EmailAddress);

                return Result.Ok(DNs.Build());
            }
            return Result.Fail("Failed to build DN");

            //try
            //{
            //    X500DistinguishedNameBuilder DNs = new X500DistinguishedNameBuilder();

            //    switch (table)
            //    {
            //        case serverType.ca:
            //        Pos1:
            //            if (serverName.Equals(dictCaDetails["name"]))
            //            {
            //                DNs.AddCountryOrRegion(CountryOrRegion);
            //                DNs.AddStateOrProvinceName((string)dictCaDetails["subj_state"]);
            //                DNs.AddLocalityName((string)dictCaDetails["subj_location"]);
            //                DNs.AddOrganizationName((string)dictCaDetails["subj_organisation"]);
            //                DNs.AddOrganizationalUnitName((string)dictCaDetails["subj_orgaunit"]);
            //                DNs.AddCommonName((string)dictCaDetails["subj_commonname"]);
            //                DNs.AddEmailAddress((string)dictCaDetails["subj_email"]);

            //                X500DistinguishedName dn = DNs.Build();

            //                return Result.Ok(DNs.Build());
            //            }
            //            else
            //            {
            //                Utils.Sql.Select(serverType.ca, serverName);
            //                goto Pos1;
            //            }
            //        case serverType.intermediate:
            //        Pos2:
            //            if (serverName.Equals((string)dictInterDetails["name"]))
            //            {
            //                DNs.AddCountryOrRegion((string)dictInterDetails["subj_country"]);
            //                DNs.AddStateOrProvinceName((string)dictInterDetails["subj_state"]);
            //                DNs.AddLocalityName((string)dictInterDetails["subj_location"]);
            //                DNs.AddOrganizationName((string)dictInterDetails["subj_organisation"]);
            //                DNs.AddOrganizationalUnitName((string)dictInterDetails["subj_orgaunit"]);
            //                DNs.AddCommonName((string)dictInterDetails["subj_commonname"]);
            //                DNs.AddEmailAddress((string)dictInterDetails["subj_email"]);
            //            }
            //            else
            //            {
            //                Utils.Sql.Select(serverType.intermediate, serverName);
            //                goto Pos2;
            //            }
            //            break;
            //        case serverType.server:
            //        Pos3:
            //            if (serverName.Equals((string)dictServerDetails["name"]))
            //            {
            //                DNs.AddCountryOrRegion((string)dictServerDetails["subj_country"]);
            //                DNs.AddStateOrProvinceName((string)dictServerDetails["subj_state"]);
            //                DNs.AddLocalityName((string)dictServerDetails["subj_location"]);
            //                DNs.AddOrganizationName((string)dictServerDetails["subj_organisation"]);
            //                DNs.AddOrganizationalUnitName((string)dictServerDetails["subj_orgaunit"]);
            //                DNs.AddCommonName((string)dictServerDetails["subj_commonname"]);
            //                DNs.AddEmailAddress((string)dictServerDetails["subj_email"]);
            //            }
            //            else
            //            {
            //                Utils.Sql.Select(serverType.server, serverName);
            //                goto Pos3;
            //            }
            //            break;
            //        case serverType.user:
            //        Pos4:
            //            if (serverName.Equals((string)dictUserDetails["name"]))
            //            {
            //                DNs.AddCountryOrRegion((string)dictUserDetails["subj_country"]);
            //                DNs.AddStateOrProvinceName((string)dictUserDetails["subj_state"]);
            //                DNs.AddLocalityName((string)dictUserDetails["subj_location"]);
            //                DNs.AddOrganizationName((string)dictUserDetails["subj_organisation"]);
            //                DNs.AddOrganizationalUnitName((string)dictUserDetails["subj_orgaunit"]);
            //                DNs.AddCommonName((string)dictUserDetails["subj_commonname"]);
            //                DNs.AddEmailAddress((string)dictUserDetails["subj_email"]);
            //            }
            //            else
            //            {
            //                Utils.Sql.Select(serverType.user, serverName);
            //                goto Pos4;
            //            }
            //            break;
            //    }
            //    var build = DNs.Build();

            //    return build;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(Convert.ToString(ex));
            //    return null;
            //}
        }
        public static byte[] ConvertPemToCsrBytes(string pem)
        {
            var lines = pem.Split('\n')
                           .Where(line => !line.StartsWith("-----") && !string.IsNullOrWhiteSpace(line))
                           .ToArray();

            string base64 = string.Join("", lines);
            return Convert.FromBase64String(base64);
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

        public static Dictionary<string, object>? GetTargetDict(serverType type)
        {
            return type switch
            {
                serverType.ca => dictCaDetails,
                serverType.intermediate => dictInterDetails,
                serverType.server => dictServerDetails,
                serverType.user => dictUserDetails,
                _ => null
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
                Server.ReadServers(listBox, type);
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

        private static byte[] GenerateRandomSerialNumber(int byteLength)
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
