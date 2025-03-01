using FluentResults;
using Microsoft.Data.Sqlite;
using Renci.SshNet;
using SCG.Forms;
using System;
using System.Buffers;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using WinFormsApp1;
using static PL.Utils.Tools;
using static System.Net.Mime.MediaTypeNames;

namespace PL;

public class Utils
{
    private const string serverAuth2 = "1.3.6.1.5.5.7.3.1";
    private const string clientAuth2 = "1.3.6.1.5.5.7.3.2";
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
    public readonly static string[] s_sqlColumns = ["id", "name", "keySize", "private_key", "private_createDT", "public_cert", "public_createDT", "ss_cert", "ss_createDT", "ss_duration", "subj_country", "subj_state", "subj_location", "subj_organisation", "subj_orgaunit", "subj_commonname", "subj_email", "serialNumber", "host_name", "host_username", "host_password", "cert_filename", "cert_priv_ext", "cert_pub_ext", "cert_path"];
    public static Dictionary<string, string> dictCaDetails = new Dictionary<string, string>
                {
                    { "id", string.Empty },
                    { "name", string.Empty },
                    { "keySize", string.Empty },
                    { "private_key", string.Empty },
                    { "private_createDT", string.Empty },
                    { "public_cert", string.Empty },
                    { "public_createDT", string.Empty },
                    { "ss_cert", string.Empty },
                    { "ss_createDT", string.Empty },
                    { "ss_duration", string.Empty },
                    { "subj_country", string.Empty },
                    { "subj_state", string.Empty },
                    { "subj_location", string.Empty },
                    { "subj_organisation", string.Empty },
                    { "subj_orgaunit", string.Empty },
                    { "subj_commonname", string.Empty },
                    { "subj_email", string.Empty },
                    { "serialNumber", string.Empty },
                    { "host_name", string.Empty },
                    { "host_username", string.Empty },
                    { "host_password", string.Empty },
                    { "cert_filename", string.Empty },
                    { "cert_priv_ext", string.Empty },
                    { "cert_pub_ext", string.Empty },
                    { "cert_path", string.Empty }


                };
    public static Dictionary<string, string> dictInterDetails = new Dictionary<string, string>
                {
                    { "id", string.Empty },
                    { "name", string.Empty },
                    { "keySize", string.Empty },
                    { "private_key", string.Empty },
                    { "private_createDT", string.Empty },
                    { "public_cert", string.Empty },
                    { "public_createDT", string.Empty },
                    { "ss_cert", string.Empty },
                    { "ss_createDT", string.Empty },
                    { "ss_duration", string.Empty },
                    { "subj_country", string.Empty },
                    { "subj_state", string.Empty },
                    { "subj_location", string.Empty },
                    { "subj_organisation", string.Empty },
                    { "subj_orgaunit", string.Empty },
                    { "subj_commonname", string.Empty },
                    { "subj_email", string.Empty },
                    { "serialNumber", string.Empty },
                    { "host_name", string.Empty },
                    { "host_username", string.Empty },
                    { "host_password", string.Empty },
                    { "cert_filename", string.Empty },
                    { "cert_priv_ext", string.Empty },
                    { "cert_pub_ext", string.Empty },
                    { "cert_path", string.Empty }
                };
    public static Dictionary<string, string> dictServerDetails = new Dictionary<string, string>
                {
                    { "id", string.Empty },
                    { "name", string.Empty },
                    { "keySize", string.Empty },
                    { "private_key", string.Empty },
                    { "private_createDT", string.Empty },
                    { "public_cert", string.Empty },
                    { "public_createDT", string.Empty },
                    { "ss_cert", string.Empty },
                    { "ss_createDT", string.Empty },
                    { "ss_duration", string.Empty },
                    { "subj_country", string.Empty },
                    { "subj_state", string.Empty },
                    { "subj_location", string.Empty },
                    { "subj_organisation", string.Empty },
                    { "subj_orgaunit", string.Empty },
                    { "subj_commonname", string.Empty },
                    { "subj_email", string.Empty },
                    { "serialNumber", string.Empty },
                    { "host_name", string.Empty },
                    { "host_username", string.Empty },
                    { "host_password", string.Empty },
                    { "cert_filename", string.Empty },
                    { "cert_priv_ext", string.Empty },
                    { "cert_pub_ext", string.Empty },
                    { "cert_path", string.Empty }
                };
    public static Dictionary<string, string> dictUserDetails = new Dictionary<string, string>
                {
                    { "id", string.Empty },
                    { "name", string.Empty },
                    { "keySize", string.Empty },
                    { "private_key", string.Empty },
                    { "private_createDT", string.Empty },
                    { "public_cert", string.Empty },
                    { "public_createDT", string.Empty },
                    { "ss_cert", string.Empty },
                    { "ss_createDT", string.Empty },
                    { "ss_duration", string.Empty },
                    { "subj_country", string.Empty },
                    { "subj_state", string.Empty },
                    { "subj_location", string.Empty },
                    { "subj_organisation", string.Empty },
                    { "subj_orgaunit", string.Empty },
                    { "subj_commonname", string.Empty },
                    { "subj_email", string.Empty },
                    { "serialNumber", string.Empty },
                    { "host_name", string.Empty },
                    { "host_username", string.Empty },
                    { "host_password", string.Empty },
                    { "cert_filename", string.Empty },
                    { "cert_priv_ext", string.Empty },
                    { "cert_pub_ext", string.Empty },
                    { "cert_path", string.Empty }
                };
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
        public static string[] GetServerDetails(certType table, string serverName)
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
        public static string[] GetCertDetails(certType table, string serverName)
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

        public static string GetPrivateKey(certType table, string serverName)
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
        public static int InsertInto(certType table, string name, string privKey, int keySize)
        {
            try
            {
                string sql = $"INSERT INTO {table} (name, keySize, private_key, private_createDT) VALUES (@_name, @_keySize, @_private_key, @_priv_createDT)";

                using var command = new SqliteCommand(sql, _connection);
                command.Parameters.AddWithValue("@_name", name);
                command.Parameters.AddWithValue("@_keySize", keySize);
                command.Parameters.AddWithValue("@_private_key", privKey);
                command.Parameters.AddWithValue("@_priv_createDT", DateTime.Now.ToString());

                return command.ExecuteNonQuery();
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
        /// Performs a SQL SELECT statement
        /// </summary>
        /// <param name="column">Which column should be searched for</param>
        /// <param name="table">Defines the table inside the database</param>
        /// <returns>Result<List<string>></returns>
        public static List<string> SqlSelect(string column, certType table)
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
        public static void Select(certType table, string serverName)
        {
            var sql = $"SELECT * FROM {table} WHERE name=@serverName";

            using var command = new SqliteCommand(sql, _connection);
            command.Parameters.AddWithValue("@serverName", serverName);
            using var reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    foreach (string item in s_sqlColumns)
                    {
                        dictCaDetails[item] = reader.GetString(item);
                    }
                }
            }
            else
            {
                MessageBox.Show("No Server found", string.Empty, MessageBoxButtons.OK);
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

        public static List<object> SelectWhereObject(certType table, string[] returnValues, string searchColumn, string searchValue)
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
            catch (Exception ex)
            {
                return null;
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
        public static Result<int> Update(certType table, string serverName, string[] columns)
        {
            int rowIns = 0;
            try
            {
                using (var command = _connection.CreateCommand())
                {
                    foreach (var column in columns)
                    {
                        if (column == "public_createDT" || column == "private_createDT")
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
                }
                return Result.Ok(rowIns);
            }
            catch (Exception ex)
            {
                Result.Fail(ex.Message);
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
        public static void WriteCertFileInfo(certType table, string fileName, string privExt, string pubExt, string remotePath, string searchTerm)
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
    }


    public class Certs
    {
        private readonly bool writeFile = true;
        private readonly string privateKeyPath = "privateKey.pem";
        private readonly string[] basicConstraint = []; //bool certificateAuthority, bool hasPathLengthConstraint, int pathLengthConstraint, bool critical);


        public static string GeneratePrivateKey(int keySize)
        {
            using (RSA rsa = RSA.Create(keySize))
            {
                return rsa.ExportRSAPrivateKeyPem();
            }
        }
        public static string GeneratePublicKey(string privateKey)
        {
            try
            {
                using (RSA rsa = RSA.Create())
                {
                    rsa.ImportFromPem(dictCaDetails["private_key"]);
                    dictCaDetails["public_cert"] = rsa.ExportRSAPublicKeyPem();
                    return rsa.ExportRSAPublicKeyPem();
                }
            }
            catch
            {
                return "failed";
            }
        }
        public static X509Certificate2 CreateCertificate(string requestPrivKey, X500DistinguishedName distinguishedName, byte[] issuerCert, string issuerPasswd, int requesterDuration, int requesterSerialNumber, certType certType)
        {
            byte[] sN = { Convert.ToByte(requesterSerialNumber) };
            X509Certificate2 caCertificate;
            CertificateRequest intermediateRequest;
            X509Certificate2 signedCertificate;

            using (RSA rsa = RSA.Create())
            {
                rsa.ImportFromPem(requestPrivKey);

                intermediateRequest = new CertificateRequest(distinguishedName, rsa, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
                if (certType == certType.ca)
                {
                    intermediateRequest.CertificateExtensions.Add(Global.caBasicConstraint);
                    intermediateRequest.CertificateExtensions.Add(Global.caKeyUsageExtension);
                    intermediateRequest.CertificateExtensions.Add(new X509SubjectKeyIdentifierExtension(intermediateRequest.PublicKey, false));
                }
                else if (certType == certType.intermediate)
                {
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
        public void SaveCertToFile(X509Certificate2 cert, X509ContentType type, string fileName)
        {
            try
            {
                SaveFileDialog file = new SaveFileDialog();
                file.DefaultExt = "pfx";
                file.Filter = "PFX files (*.pfx)|*.pfx";
                file.ShowDialog();

                if (file.FileName != "")
                {
                    //File.WriteAllBytes(file.FileName, certToSend); //includes public and private
                }

            }
            catch (Exception)
            {

                throw;
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
