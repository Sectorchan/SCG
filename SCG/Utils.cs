using FluentResults;
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
    }


    public class Certs
    {
        private readonly bool writeFile = true;
        private readonly string privateKeyPath = "privateKey.pem";
        private readonly string[] basicConstraint = []; //bool certificateAuthority, bool hasPathLengthConstraint, int pathLengthConstraint, bool critical);


        public static string GeneratePrivateKey(int keySize, string filePath)
        {
            using (RSA rsa = RSA.Create(keySize))
            {
                string privateKey = rsa.ExportRSAPrivateKeyPem();
                return privateKey;
            }
        }
        public static string GeneratePublicKey(string privateKey)
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
                if (certType == certType.ca )
                {
                    intermediateRequest.CertificateExtensions.Add(Global.caBasicConstraint);
                    intermediateRequest.CertificateExtensions.Add(Global.caKeyUsageExtension);
                    intermediateRequest.CertificateExtensions.Add(new X509SubjectKeyIdentifierExtension(intermediateRequest.PublicKey, false));
                }
                else if(certType == certType.intermediate)
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
