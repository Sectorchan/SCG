using FluentResults;
using Microsoft.Data.Sqlite;
using static secrets.Secrets;
using PL;
using static PL.Utils.Certs;
using static PL.Utils.Sql;
using RadioButton = System.Windows.Forms.RadioButton;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using static PL.Utils;
using static PL.Utils.Tools;
using System.Text;
using WinFormsApp1;
using System.Diagnostics.Eventing.Reader;


namespace SCG.Forms;

public partial class Server : Form
{
    public Server() { InitializeComponent(); }

    #region Private members
    //private readonly bool _writeFile = Global.saveToDisk;
    private readonly bool _writeFile = true;
    private readonly bool _certVerify = true;
    private readonly string[] _fqdn = ["subj_country", "subj_state", "subj_location", "subj_organisation", "subj_orgaunit", "subj_commonname", "subj_email"];
    private readonly string[] _idSql = ["id"];
    private readonly string[] _sshCred = ["host_username", "host_password", "hostname"];
    private readonly string[] _sshlocs = ["cert_filename", "cert_priv_ext", "cert_pub_ext", "cert_path"];


    private readonly string c_selfsignedPasswordPfx = "";
    private readonly string i_selfsignedPasswordPfx = "";
    private readonly string s_selfsignedPasswordPfx = "";
    private readonly string _u_selfsignedPasswordPfx = "";

    private const string CertPFX = "PFX files(*.pfx)|*.pfx";
    private const string CertPEM = "PEM files(*.pem)|*.pem";
    private const string CertDER = "DER files(*.der)|*.der";
    private const string CertCRT = "CRT files(*.crt)|*.crt";
    private const string CertCER = "CER files(*.cer)|*.cer";

    public static SqliteConnection sqlconnection;
    #endregion

    private void server_onLoad(object sender, EventArgs e)
    {
        //open SQL connection
        var db = DatabaseConnection.GetInstance();
        sqlconnection = db.GetConnection();

        #region !Visible Boxes
        lbl_ca_name.Visible = false;
        tb_ca_name.Visible = false;
        lb_ca_certs.Items.Clear();
        ReadServers(lb_ca_certs, serverType.ca);
        lb_ca_certs.Sorted = true;

        lbl_int_name.Visible = false;
        tb_int_name.Visible = false;
        lb_int_certs.Items.Clear();
        ReadServers(lb_int_certs, serverType.intermediate);
        lb_int_certs.Sorted = true;

        tb_server_name.Visible = false;
        lbl_server_name.Visible = false;
        lb_server_certs.Items.Clear();
        ReadServers(lb_server_certs, serverType.server);
        lb_server_certs.Sorted = true;

        tb_user_name.Visible = false;
        lbl_user_name.Visible = false;
        lb_user_certs.Items.Clear();
        ReadServers(lb_user_certs, serverType.user);
        lb_user_certs.Sorted = true;
        #endregion
        string SqlTable = panel1.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).Text;
        if (SqlTable == "CA")
        {
            cb_isCa.Checked = true;
            cb_critical.Checked = true;
        }

        Result<List<object>> result = Utils.Sql.SelectWhereObject(serverType.ca, ["name", "id"], "name", string.Empty);
        if (result.IsSuccess)
        {
            if (result.Value != null)
            {
                foreach (var item in result.Value)
                {
                    TreeNode tree = new TreeNode(Convert.ToString(item));
                    tree.Tag = "Hey";
                    treeView1.Nodes.Add(tree);

                }
            }
        }
        Utils.Sql.SelectWhereObject(serverType.intermediate, _idSql, "", "*");
        treeView1.Sort();
    }


    public Result<List<string>> ReadServers(dynamic control, serverType table)
    {
        try
        {
            List<string> serverList = new List<string>();
            Result<List<string>> result = Utils.Sql.SqlSelect("name", table);

            if (result.IsSuccess)
            {
                if (result.Value != null)
                {
                    foreach (var item in result.Value)
                    {
                        control.Items.Add(item);
                    }
                    return Result.Ok(serverList);
                }
                else
                {
                    return Result.Fail("Empty List");
                }
            }
            else
            {
                return Result.Fail("Fehler");
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
            return Result.Fail(ex.Message);
        }
    }

    public Result<serverType> SqlTable()
    {
        string SqlTable = panel1.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).Text;
        serverType Table = serverType.ca;
        switch (SqlTable)
        {
            case "CA":
                Table = serverType.ca;
                break;
            case "Intermediate":
                Table = serverType.intermediate;
                break;
            case "Server":
                Table = serverType.server;
                break;
            case "User":
                Table = serverType.user;
                break;
        }
        return Result.Ok(Table);
    }

    /// <summary>
    /// Enables the Generate Private Key button
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>


    /// <summary>
    /// Generates the public key, corresponding to the matching name of the private key
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void radioButtons_CheckedChanged(object sender, EventArgs e)
    {
        string SqlTable = panel1.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).Text;
        if (SqlTable == "CA")
        {
            cb_isCa.Checked = true;
            cb_critical.Checked = true;
        }
        else if (SqlTable == "Intermediate")
        {
            cb_isCa.Checked = false;
            cb_critical.Checked = false;
        }
        else if (SqlTable == "Server")
        {
            cb_isCa.Checked = false;
            cb_critical.Checked = false;
        }
        else if (SqlTable == "User")
        {
            cb_isCa.Checked = false;
            cb_critical.Checked = false;
        }
    }

    #region CA
    /// <summary>
    /// Button click "Generate Private Key" > generates a private key and store it on the SQLite database.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>

    private void Bt_gen_ca_priv_onClick(object sender, EventArgs e)
    {
        try
        {
            int keySize = Convert.ToInt32(cb_ca_keySize.SelectedItem);
            Utils.dictCaDetails.Clear();
            Utils.dictCaDetails["name"] = tb_ca_name.Text;
            Result<string> privateKeyPem = Utils.Certs.GeneratePrivateKey(keySize);

            if (privateKeyPem.IsSuccess)
            {
                Result<int> insertRow = Utils.Sql.InsertInto(serverType.ca, (string)Utils.dictCaDetails["name"]);
                if (_writeFile && insertRow.IsSuccess)
                {
                    Form writeFileForm = new WriteFile(serverType.ca, (string)Utils.dictCaDetails["name"], certType.priv);
                    writeFileForm.ShowDialog();
                }
                MessageBox.Show($"Successfully inserted {insertRow} row(s) into the database");
            }
            else
            {
                MessageBox.Show($"Generate PrivateKEy failed with: {privateKeyPem.Reasons}");
            }
            lb_ca_certs.Items.Clear();
            ReadServers(lb_ca_certs, serverType.ca);
            lb_ca_certs.Sorted = true;
            lb_ca_certs.SelectedItem = Utils.dictCaDetails["name"];
        }
        catch (Exception ex)
        { MessageBox.Show(ex.ToString(), sender.ToString()); }
    }
    /// <summary>
    /// Button click "Generate Public Key"
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Bt_gen_ca_pub_onClick(object sender, EventArgs e)
    {
        try
        {
            string serverName = Convert.ToString(lb_ca_certs.SelectedItem);
            Result<bool> result = Utils.Sql.Select(serverType.ca, serverName);
            Result<string> publicKey = Utils.Certs.GeneratePublicKey(serverName);

            if (publicKey.IsSuccess)
            {
                Result<int> columnsUpdated = Utils.Sql.Update(serverType.ca, serverName, ["public_cert", "public_createDT"], 1);
                if (_writeFile && columnsUpdated.IsSuccess)
                {
                    Form writeFileForm = new WriteFile(serverType.ca, (string)Utils.dictCaDetails["name"], certType.pub);
                    writeFileForm.ShowDialog();
                }
                else
                {
                    MessageBox.Show($"Database Update failed with: {columnsUpdated.Reasons}");
                }
                MessageBox.Show($"Successfully inserted {columnsUpdated.Value} row(s) into the database");
            }
            else
            {
                MessageBox.Show($"Generate PublicKey failed with: {publicKey.Value}");
            }
        }
        catch (Exception ex)
        { MessageBox.Show(ex.Message.ToString()); }
    }
    /// <summary>
    /// Button click "Generate CSR" > generates a Certificate sign request file incl Self signed for CA
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Bt_gen_ca_selfSigned_key_Click(object sender, EventArgs e)
    {
        try
        {
            string serverName = Convert.ToString(lb_ca_certs.SelectedItem);
            Result<bool> result = Utils.Sql.Select(serverType.ca, serverName);
            string fileExtension = "pfx";

            dictCaDetails["ss_duration"] = tb_ca_dura.Text;
            int duration = Convert.ToInt32(dictCaDetails["ss_duration"]);
            string privateKeyPem = (string)dictCaDetails["private_key"];

            int cTempSerialNumber = Convert.ToInt32(dictCaDetails["serialNumber"]);
            cTempSerialNumber++;
            string time = DateTime.Now.ToString("ddMMyyyy");
            long serialNumber = long.Parse($"{cTempSerialNumber}{time}");

            if (result.IsSuccess)
            {
                Result<X500DistinguishedName> distinguishedName = DNBuilder(serverType.ca, serverName);
                if (distinguishedName.IsSuccess)
                {
                    Result<X509Certificate2> certificate = Utils.Certs.CreateCertificate(serverType.ca, privateKeyPem, distinguishedName.Value, null, null, duration, serialNumber);  // 0 = Serialnumber

                    if (certificate.IsSuccess)
                    {
                        byte[] selfSignedCert = certificate.Value.Export(X509ContentType.Pfx, c_selfsignedPasswordPfx);
                        File.WriteAllBytes("C:\\Users\\Patri\\Downloads\\Ca-S1.pfx", selfSignedCert);
                        Utils.Sql.Select(serverType.ca, serverName);
                        string s = Convert.ToString(Utils.dictCaDetails["ss_cert"]);

                        return;
                        //write selfSignedCert as Byte[] into the database
                        Result<int> sqlWrite = Utils.Sql.UpdateSelfSigned(serverType.ca, serverName, selfSignedCert, duration, cTempSerialNumber);


                        //write selfSignedCert to file
                        Utils.Sql.Select(serverType.ca, serverName);

                        if (sqlWrite.IsSuccess)
                        {
                            if (_writeFile)
                            {
                                Form writeFileForm = new WriteFile(serverType.ca, (string)Utils.dictCaDetails["name"], certType.selfSigned, null);
                                writeFileForm.ShowDialog();

                            }
                            if (_certVerify)
                            {
                                // load selfsigned certificate from database to verify the content
                                CheckPrivateKey(certificate.Value);
                            }   


                            X509Certificate2 sqlSelfSigned = new X509Certificate2(selfSignedCert, c_selfsignedPasswordPfx, X509KeyStorageFlags.Exportable);
                            CheckPrivateKey(sqlSelfSigned);
                        }
                        else if (_writeFile)
                        {
                           

                            File.WriteAllBytes($"{serverName}.{fileExtension}", selfSignedCert);
                            MessageBox.Show($"Intermediate-Zertifikat in \"ca_\" + caName + \"_ss.pfx\" gespeichert.");
                        }
                        else
                        { MessageBox.Show($"sqlWrite to file failed with: {sqlWrite.Reasons}"); }
                    }
                    else
                    { MessageBox.Show($"CreateCertificate failed with: {certificate.Reasons}"); }
                }
                else
                { MessageBox.Show($"X500DistinguishedName failed with: {distinguishedName.Reasons}"); }
            }
        }
        catch (Exception ex)
        { MessageBox.Show(ex.ToString()); }
    }
    private void Bt_reCreate_ca_selfSigned_key_Click(object sender, EventArgs e)
    {
        string serverName = Convert.ToString(lb_ca_certs.SelectedItem);
        Result<bool> result = Utils.Sql.Select(serverType.ca, serverName);

        byte[] selfSignedSqlCert = (byte[])dictCaDetails["ss_cert"];

        X509Certificate2 sqlSelfSigned = new X509Certificate2(selfSignedSqlCert, c_selfsignedPasswordPfx, X509KeyStorageFlags.Exportable);
        byte[] certToSend = sqlSelfSigned.Export(X509ContentType.Pfx, c_selfsignedPasswordPfx);

        Result<List<object>> list = Utils.Sql.SelectWhereObject(_sshCred, serverType.ca, "name", serverName);





        //Utils.ssh.UploadCert(Convert.ToString(list.Value[2]), Convert.ToString(list.Value[0]), Convert.ToString(list.Value[1]), certToSend, _remoteFilePath);

        File.WriteAllBytes("ca_" + serverName + "_reCreate_ss.pfx", sqlSelfSigned.Export(X509ContentType.Pfx, c_selfsignedPasswordPfx)); //includes public and private
        File.WriteAllBytes("ca_" + serverName + "_reCreate_ss.cer", sqlSelfSigned.Export(X509ContentType.Cert));//includes only public
    }

    private void Bt_ca_uploadCert_Click(object sender, EventArgs e)
    {
        string serverName = Convert.ToString(lb_ca_certs.SelectedItem);

        byte[] intSsCertSql = Utils.Sql.SelectSsCert(serverType.ca, "ss_cert", "name", serverName);
        X509Certificate2 sqlSelfSigned = new X509Certificate2(intSsCertSql, c_selfsignedPasswordPfx, X509KeyStorageFlags.Exportable);
        byte[] certToSend = sqlSelfSigned.Export(X509ContentType.Cert);
        string privCert = GetPrivateKey(serverType.ca, serverName);

        Result<List<object>> list = Utils.Sql.SelectWhereObject(serverType.ca, _sshlocs, "name", serverName);


        string[] certDetails = GetCertDetails(serverType.ca, serverName);
        string[] serverDetails = GetServerDetails(serverType.ca, serverName);

        Utils.ssh.UploadCert(serverDetails[0], serverDetails[1], serverDetails[2], certToSend, certDetails[3]);
        Utils.ssh.UploadCert(serverDetails[0], serverDetails[1], serverDetails[2], privCert, certDetails[2]);

    }
    #endregion

    #region intermediate   
    private void Bt_gen_int_priv_Click(object sender, EventArgs e)
    {
        try
        {
            int keySize = Convert.ToInt32(cb_int_keySize.SelectedItem);
            string interName = tb_int_name.Text;
            //generate privatekey
            Result<string> privateKeyPem = Utils.Certs.GeneratePrivateKey(keySize);
            //write to sql
            Result<int> insertRow = Utils.Sql.InsertInto(serverType.intermediate, interName, privateKeyPem.Value, keySize);
            //write to file
            if (_writeFile)
            {
                File.WriteAllText("ci_" + interName + "_priv.pem", privateKeyPem.Value);
            }
            MessageBox.Show($"Successfully inserted {insertRow.Value} row(s) into the database");

            lb_int_certs.Items.Clear();
            ReadServers(lb_int_certs, serverType.intermediate);
            lb_int_certs.Sorted = true;
            lb_int_certs.SelectedItem = interName;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString(), sender.ToString());
        }
    }
    private void Bt_gen_int_pub_Click(object sender, EventArgs e)
    {
        string interName = Convert.ToString(lb_int_certs.SelectedItem);
        //read private key
        string i_privateKeyPath = Utils.Sql.SelectWhereString(serverType.intermediate, "private_key", "name", interName);
        //generate public key with passed private key
        Result<string> publicKeyPem = Utils.Certs.GeneratePublicKey(i_privateKeyPath);
        //write to sql
        Result<int> insertRow = Utils.Sql.Update(serverType.intermediate, publicKeyPem.Value, interName, "name");
        //write to file
        File.WriteAllText("ci_" + interName + "_pub.pem", publicKeyPem.Value);
        //return result
        MessageBox.Show($"Successfully inserted {insertRow.Value} row(s) into the database");

    }
    /// <summary>
    /// Button 5. Generate CSR
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Bt_gen_int_selfSigned_key_Click(object sender, EventArgs e)
    {
        try
        {
            string interName = Convert.ToString(lb_int_certs.SelectedItem);
            //which CA shall sign the intermediate
            string serverName = Convert.ToString(lb_ca_certs.SelectedItem);
            int duration = Convert.ToInt32(tb_int_dura.Text);

            //load CA certificate from file
            string caSsCertFile = "ca_" + serverName + "_ss.pfx";
            string caPassword = "";
            //read CA certificate pfx from SQL
            byte[] caSsCertSql = Utils.Sql.SelectSsCert(serverType.ca, "ss_cert", "name", serverName);
            string caIndex = Utils.Sql.SelectWhereString(serverType.ca, "id", "name", serverName);

            string i_privateKeyPath = Utils.Sql.SelectWhereString(serverType.intermediate, "private_key", "name", interName);
            int i_privateKeySn = Convert.ToInt32(Utils.Sql.SelectWhereString(serverType.intermediate, "serialNumber", "name", interName));
            i_privateKeySn++;

            //generate destName
            List<object> fqdnRes = Sql.SelectWhereObject(serverType.intermediate, _fqdn, "name", interName);
            //X500DistinguishedName distinguishedName = DNBuilder(Convert.ToString(fqdnRes[0]), Convert.ToString(fqdnRes[1]), Convert.ToString(fqdnRes[2]), Convert.ToString(fqdnRes[3]), Convert.ToString(fqdnRes[4]), Convert.ToString(fqdnRes[5]), Convert.ToString(fqdnRes[6]));
            //X500DistinguishedName distinguishedName = DNBuilder(certType.intermediate, interName);
            Result<X500DistinguishedName> distinguishedName = DNBuilder(serverType.intermediate, interName);

            //generate from SQL
            Result<X509Certificate2> interCertSql = Utils.Certs.CreateCertificate(serverType.intermediate, i_privateKeyPath, distinguishedName.Value, null, null, duration, i_privateKeySn);

            if (_writeFile)
            {
                //write signed certificate to file
                File.WriteAllBytes("ci_" + interName + "_ss.pfx", interCertSql.Value.Export(X509ContentType.Pfx, i_selfsignedPasswordPfx)); //includes public and private
                File.WriteAllBytes("ci_" + interName + "_ss.cer", interCertSql.Value.Export(X509ContentType.Cert));//includes only public
            }
            //write signed certificate to sql database
            Utils.Sql.UpdateSelfSigned(serverType.intermediate, interName, interCertSql.Value.Export(X509ContentType.Pfx, i_selfsignedPasswordPfx), Convert.ToInt32(caIndex), duration, i_privateKeySn);

            if (_certVerify)
            {
                // load selfsigned certificate from database to verify the content
                byte[] intSsCertSql = Utils.Sql.SelectSsCert(serverType.intermediate, "ss_cert", "name", interName);
                var sqlSelfSigned = new X509Certificate2(intSsCertSql, i_selfsignedPasswordPfx, X509KeyStorageFlags.Exportable);
                CheckPrivateKey(sqlSelfSigned);
            }

            //information message
            Console.WriteLine($"Intermediate-Zertifikat in \"ci_\" + interName + \"_ss.pfx\" gespeichert.");
            MessageBox.Show($"Intermediate-Zertifikat in \"ci_\" + interName + \"_ss.pfx\" gespeichert.");
        }
        catch (Exception)
        {
            throw;
        }
    }

    private void Bt_int_uploadCert_Click(object sender, EventArgs e)
    {
        string serverName = Convert.ToString(lb_int_certs.SelectedItem);

        byte[] intSsCertSql = Utils.Sql.SelectSsCert(serverType.intermediate, "ss_cert", "name", serverName);
        X509Certificate2 sqlSelfSigned = new X509Certificate2(intSsCertSql, c_selfsignedPasswordPfx, X509KeyStorageFlags.Exportable);
        byte[] certToSend = sqlSelfSigned.Export(X509ContentType.Cert);
        string privCert = GetPrivateKey(serverType.intermediate, serverName);

        Result<List<object>> list = Utils.Sql.SelectWhereObject(serverType.intermediate, _sshlocs, "name", serverName);


        string[] certDetails = GetCertDetails(serverType.intermediate, serverName);
        string[] serverDetails = GetServerDetails(serverType.intermediate, serverName);

        Utils.ssh.UploadCert(serverDetails[0], serverDetails[1], serverDetails[2], certToSend, certDetails[3]);
        Utils.ssh.UploadCert(serverDetails[0], serverDetails[1], serverDetails[2], privCert, certDetails[2]);
    }

    #endregion

    #region server
    private void Bt_gen_server_priv_Click(object sender, EventArgs e)
    {
        int keySize = Convert.ToInt32(cb_server_keySize.SelectedItem);
        string serverName = tb_server_name.Text;
        //generate privatekey
        Result<string> privateKeyPem = Utils.Certs.GeneratePrivateKey(keySize);
        //write to sql
        Result<int> insertRow = Utils.Sql.InsertInto(serverType.server, serverName, privateKeyPem.Value, keySize);
        if (_writeFile)
        {
            SaveFile(serverName, privateKeyPem.Value, CertPEM);
            //write to file
            File.WriteAllText("cs_" + serverName + "_priv.pem", privateKeyPem.Value);
        }
        MessageBox.Show($"Successfully inserted {insertRow.Value} row(s) into the database");

        lb_server_certs.Items.Clear();
        ReadServers(lb_server_certs, serverType.server);
        lb_server_certs.Sorted = true;
        lb_server_certs.SelectedItem = serverName;
    }
    private void Bt_gen_server_pub_Click(object sender, EventArgs e)
    {
        string serverName = Convert.ToString(lb_server_certs.SelectedItem);
        //read private key
        string s_privateKeyPath = Utils.Sql.SelectWhereString(serverType.server, "private_key", "name", serverName);
        //generate public key with passed private key
        Result<string> publicKeyPem = Utils.Certs.GeneratePublicKey(s_privateKeyPath);
        //write to sql
        int insertRow = Utils.Sql.Update(serverType.server, publicKeyPem.Value, serverName, "name");
        //write to file
        File.WriteAllText("cs_" + serverName + "_pub.pem", publicKeyPem.Value);
        //return result
        MessageBox.Show($"Successfully inserted {insertRow} row(s) into the database");
    }


    private void Bt_gen_server_selfSigned_key_Click(object sender, EventArgs e)
    {
        try
        {
            string serverName = Convert.ToString(lb_server_certs.SelectedItem);
            //which intermediate shall sign the server
            string interName = Convert.ToString(lb_int_certs.SelectedItem);
            int duration = Convert.ToInt32(tb_server_dura.Text);
            // load intermediate certificate from file
            string intSsCertFile = "ci_" + interName + "_ss.pfx";
            string intPassword = "";
            //read intermediate certificate pfx from SQL
            byte[] intSsCertSql = Utils.Sql.SelectSsCert(serverType.intermediate, "ss_cert", "name", interName);
            string intIndex = Utils.Sql.SelectWhereString(serverType.intermediate, "id", "name", interName);
            //read server certificate from SQL
            string s_privateKeyPath = Utils.Sql.SelectWhereString(serverType.server, "private_key", "name", serverName);
            int s_privateKeySn = Convert.ToInt32(Utils.Sql.SelectWhereString(serverType.server, "serialNumber", "name", serverName));

            // generate DistinguishedName
            List<object> fqdnRes = Sql.SelectWhereObject(serverType.server, _fqdn, "name", serverName);
            //X500DistinguishedName distinguishedName = DNBuilder(certType.server, serverName);
            Result<X500DistinguishedName> distinguishedName = DNBuilder(serverType.server, serverName);
            s_privateKeySn++;

            //generate from SQL
            Result<X509Certificate2> serverCertSql = Utils.Certs.CreateCertificate(serverType.server, s_privateKeyPath, distinguishedName.Value, null, null, duration, s_privateKeySn);


            if (_writeFile)
            {
                //write signed certificate to file
                File.WriteAllBytes("cs_" + serverName + "_ss.pfx", serverCertSql.Value.Export(X509ContentType.Pfx, s_selfsignedPasswordPfx)); //includes public and private
                File.WriteAllBytes("cs_" + serverName + "_ss.cer", serverCertSql.Value.Export(X509ContentType.Cert));//includes only public
            }
            //write signed certificate to sql database
            Utils.Sql.UpdateSelfSigned(serverType.server, serverName, serverCertSql.Value.Export(X509ContentType.Pfx, s_selfsignedPasswordPfx), Convert.ToInt32(intIndex), duration, s_privateKeySn);
            if (_certVerify)
            {
                // load selfsigned certificate from database to verify the content
                byte[] servSsCertSql = Utils.Sql.SelectSsCert(serverType.server, "ss_cert", "name", serverName);
                var sqlSelfSigned = new X509Certificate2(servSsCertSql, s_selfsignedPasswordPfx, X509KeyStorageFlags.Exportable);
                CheckPrivateKey(sqlSelfSigned);
            }
            //information message
            Console.WriteLine($"Intermediate-Zertifikat in \"cs_\" + serverName + \"_ss.pfx\" gespeichert.");
            MessageBox.Show($"Intermediate-Zertifikat in \"cs_\" + serverName + \"_ss.pfx\" gespeichert.");
        }
        catch (Exception)
        {
            throw;
        }
    }
    private void Bt_server_uploadCert_Click(object sender, EventArgs e)
    {
        string serverName = Convert.ToString(lb_server_certs.SelectedItem);

        byte[] intSsCertSql = Utils.Sql.SelectSsCert(serverType.server, "ss_cert", "name", serverName);
        X509Certificate2 sqlSelfSigned = new X509Certificate2(intSsCertSql, c_selfsignedPasswordPfx, X509KeyStorageFlags.Exportable);
        byte[] certToSend = sqlSelfSigned.Export(X509ContentType.Cert);
        string privCert = GetPrivateKey(serverType.server, serverName);

        Result<List<object>> list = Utils.Sql.SelectWhereObject(serverType.server, _sshlocs, "name", serverName);


        string[] certDetails = GetCertDetails(serverType.server, serverName);
        string[] serverDetails = GetServerDetails(serverType.server, serverName);

        Utils.ssh.UploadCert(serverDetails[0], serverDetails[1], serverDetails[2], certToSend, certDetails[3]);
        Utils.ssh.UploadCert(serverDetails[0], serverDetails[1], serverDetails[2], privCert, certDetails[2]);
    }
    #endregion

    #region user
    private void Bt_gen_user_priv_Click(object sender, EventArgs e)
    {
        int keySize = Convert.ToInt32(cb_user_keySize.SelectedItem);
        string userName = tb_user_name.Text;
        //generate privatekey
        Result<string> privateKeyPem = Utils.Certs.GeneratePrivateKey(keySize);
        //write to sql
        Result<int> insertRow = Utils.Sql.InsertInto(serverType.user, userName, privateKeyPem.Value, keySize);
        if (_writeFile)
        {
            //write to file
            File.WriteAllText("cu_" + userName + "_priv.pem", privateKeyPem.Value);
        }
        MessageBox.Show($"Successfully inserted {insertRow.Value} row(s) into the database");

        lb_user_certs.Items.Clear();
        ReadServers(lb_user_certs, serverType.user);
        lb_user_certs.Sorted = true;
        lb_user_certs.SelectedItem = userName;
    }
    private void Bt_gen_user_pub_Click(object sender, EventArgs e)
    {
        string userName = Convert.ToString(lb_user_certs.SelectedItem);
        //read private key
        string s_privateKeyPath = Utils.Sql.SelectWhereString(serverType.user, "private_key", "name", userName);
        //generate public key with passed private key
        Result<string> publicKeyPem = Utils.Certs.GeneratePublicKey(s_privateKeyPath);
        //write to sql
        int insertRow = Utils.Sql.Update(serverType.user, publicKeyPem.Value, userName, "name");
        //write to file
        File.WriteAllText("cu_" + userName + "_pub.pem", publicKeyPem.Value);
        //return result
        MessageBox.Show($"Successfully inserted {insertRow} row(s) into the database");
    }
    private void Bt_read_user_subj_Click(object sender, EventArgs e)
    {

    }
    private void Bt_gen_user_selfSigned_key_Click(object sender, EventArgs e)
    {
        try
        {
            string userName = Convert.ToString(lb_user_certs.SelectedItem);
            //which intermediate shall sign the server
            string interName = Convert.ToString(lb_int_certs.SelectedItem);
            int duration = Convert.ToInt32(tb_user_dura.Text);
            // load intermediate certificate from file
            string intSsCertFile = "ci_" + interName + "_ss.pfx";
            string intPassword = "";
            //read intermediate certificate pfx from SQL
            byte[] intSsCertSql = Utils.Sql.SelectSsCert(serverType.intermediate, "ss_cert", "name", interName);
            string intIndex = Utils.Sql.SelectWhereString(serverType.intermediate, "id", "name", interName);
            //read user certificate from SQL
            string u_privateKeyPath = Utils.Sql.SelectWhereString(serverType.user, "private_key", "name", userName);
            int u_privateKeySn = Convert.ToInt32(Utils.Sql.SelectWhereString(serverType.user, "serialNumber", "name", userName));
            u_privateKeySn++;

            // generate DistinguishedName
            List<object> fqdnRes = Sql.SelectWhereObject(serverType.user, _fqdn, "name", userName);
            //X500DistinguishedName distinguishedName = DNBuilder(certType.user, userName);
            Result<X500DistinguishedName> distinguishedName = DNBuilder(serverType.user, userName);

            //generate from SQL
            Result<X509Certificate2> userCertSql = Utils.Certs.CreateCertificate(serverType.user, u_privateKeyPath, distinguishedName.Value, null, null, duration, u_privateKeySn);

            if (_writeFile)
            {
                //write signed certificate to file
                File.WriteAllBytes("cu_" + userName + "_ss.pfx", userCertSql.Value.Export(X509ContentType.Pfx, _u_selfsignedPasswordPfx)); //includes public and private
                File.WriteAllBytes("cu_" + userName + "_ss.cer", userCertSql.Value.Export(X509ContentType.Cert));//includes only public
            }
            //write signed certificate to sql database
            Utils.Sql.UpdateSelfSigned(serverType.user, userName, userCertSql.Value.Export(X509ContentType.Pfx, _u_selfsignedPasswordPfx), Convert.ToInt32(intIndex), duration, u_privateKeySn);
            if (_certVerify)
            {
                // load selfsigned certificate from database to verify the content
                byte[] userSsCertSql = Utils.Sql.SelectSsCert(serverType.user, "ss_cert", "name", userName);
                var sqlSelfSigned = new X509Certificate2(userSsCertSql, _u_selfsignedPasswordPfx, X509KeyStorageFlags.Exportable);
                CheckPrivateKey(sqlSelfSigned);
            }
            //information message
            Console.WriteLine($"Intermediate-Zertifikat in \"cu_\" + userName + \"_ss.pfx\" gespeichert.");
            MessageBox.Show($"Intermediate-Zertifikat in \"cu_\" + userName + \"_ss.pfx\" gespeichert.");
        }
        catch (Exception)
        {
            throw;
        }
    }
    private void Bt_user_uploadCert_Click(object sender, EventArgs e)
    {

    }
    #endregion

    #region testfunction
    static void GenerateRsaPrivateKey(string filePath)
    {
        using (RSA rsa = RSA.Create(2048))
        {
            string privateKeyPem = rsa.ExportRSAPrivateKeyPem();
            File.WriteAllText(filePath, privateKeyPem);
            Console.WriteLine($"Private Key in {filePath} gespeichert.");
            MessageBox.Show($"Private Key in {filePath} gespeichert.");
        }
    }

    static void GenerateRsaPublicKeyFromPrivateKey(string privateKeyPath, string publicKeyPath)
    {
        string privateKeyPem = File.ReadAllText(privateKeyPath);
        using (RSA rsa = RSA.Create())
        {
            rsa.ImportFromPem(privateKeyPem);
            string publicKeyPem = rsa.ExportRSAPublicKeyPem();

            File.WriteAllText(publicKeyPath, publicKeyPem);
            Console.WriteLine($"Public Key in {publicKeyPath} gespeichert.");
            MessageBox.Show($"Public Key in {publicKeyPath} gespeichert.");
        }
    }

    static void CreateSelfSignedCertificate2(string privateKeyPath, string publicKeyPath, string pfxPath, string password)
    {
        string privateKeyPem = File.ReadAllText(privateKeyPath);
        string publicKeyPem = File.ReadAllText(publicKeyPath);

        using (RSA rsa = RSA.Create())
        {
            rsa.ImportFromPem(privateKeyPem);
            var request = new CertificateRequest("CN=SelfSignedCertificate", rsa, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
            var certificate = request.CreateSelfSigned(DateTimeOffset.Now, DateTimeOffset.Now.AddYears(1));

            File.WriteAllBytes(pfxPath, certificate.Export(X509ContentType.Pfx, password));
            //Console.WriteLine($"Self-signed Zertifikat in {pfxPath} gespeichert.");
            //MessageBox.Show($"Self-signed Zertifikat in {pfxPath} gespeichert.");


        }
    }
    #endregion

    #region Destingusted Names
    private void bt_wrt_dest_names_Click(object sender, EventArgs e)
    {
        try
        {

            string sub_c = tb_sub_c.Text;
            string sub_s = tb_sub_st.Text;
            string sub_l = tb_sub_loc.Text;
            string sub_o = tb_sub_orga.Text;
            string sub_ou = tb_sub_ou.Text;
            string sub_n = tb_sub_cn.Text;
            string sub_e = tb_sub_email.Text;

            Result<serverType> sqlTable = SqlTable();
            string serverName = string.Empty;

            if (sqlTable.IsSuccess)
            {
                if (sqlTable.Value == serverType.ca)
                {
                    serverName = Convert.ToString(lb_ca_certs.SelectedItem);
                Pos1:
                    if (dictCaDetails["name"].Equals(serverName))
                    {
                        dictCaDetails["subj_country"] = tb_sub_c.Text;
                        dictCaDetails["subj_state"] = tb_sub_st.Text;
                        dictCaDetails["subj_location"] = tb_sub_loc.Text;
                        dictCaDetails["subj_organisation"] = tb_sub_orga.Text;
                        dictCaDetails["subj_orgaunit"] = tb_sub_ou.Text;
                        dictCaDetails["subj_commonname"] = tb_sub_cn.Text;
                        dictCaDetails["subj_email"] = tb_sub_email.Text;

                    }
                    else
                    {
                        Utils.Sql.Select(serverType.ca, serverName);
                        goto Pos1;
                    }
                }
                else if (sqlTable.Value == serverType.intermediate)
                {
                    serverName = Convert.ToString(lb_int_certs.SelectedItem);
                Pos2:
                    if (dictInterDetails["name"].Equals(serverName))
                    {
                        dictInterDetails["subj_country"] = tb_sub_c.Text;
                        dictInterDetails["subj_state"] = tb_sub_st.Text;
                        dictInterDetails["subj_location"] = tb_sub_loc.Text;
                        dictInterDetails["subj_organisation"] = tb_sub_orga.Text;
                        dictInterDetails["subj_orgaunit"] = tb_sub_ou.Text;
                        dictInterDetails["subj_commonname"] = tb_sub_cn.Text;
                        dictInterDetails["subj_email"] = tb_sub_email.Text;

                    }
                    else
                    {
                        Utils.Sql.Select(serverType.intermediate, serverName);
                        goto Pos2;
                    }
                }
                else if (sqlTable.Value == serverType.server)
                {
                    serverName = Convert.ToString(lb_server_certs.SelectedItem);
                Pos3:
                    if (dictServerDetails["name"].Equals(serverName))
                    {
                        dictServerDetails["subj_country"] = tb_sub_c.Text;
                        dictServerDetails["subj_state"] = tb_sub_st.Text;
                        dictServerDetails["subj_location"] = tb_sub_loc.Text;
                        dictServerDetails["subj_organisation"] = tb_sub_orga.Text;
                        dictServerDetails["subj_orgaunit"] = tb_sub_ou.Text;
                        dictServerDetails["subj_commonname"] = tb_sub_cn.Text;
                        dictServerDetails["subj_email"] = tb_sub_email.Text;

                    }
                    else
                    {
                        Utils.Sql.Select(serverType.server, serverName);
                        goto Pos3;
                    }
                }
                else if (sqlTable.Value == serverType.user)
                {
                    serverName = Convert.ToString(lb_user_certs.SelectedItem);
                Pos4:
                    if (dictUserDetails["name"].Equals(serverName))
                    {
                        dictUserDetails["subj_country"] = tb_sub_c.Text;
                        dictUserDetails["subj_state"] = tb_sub_st.Text;
                        dictUserDetails["subj_location"] = tb_sub_loc.Text;
                        dictUserDetails["subj_organisation"] = tb_sub_orga.Text;
                        dictUserDetails["subj_orgaunit"] = tb_sub_ou.Text;
                        dictUserDetails["subj_commonname"] = tb_sub_cn.Text;
                        dictUserDetails["subj_email"] = tb_sub_email.Text;

                    }
                    else
                    {
                        Utils.Sql.Select(serverType.user, serverName);
                        goto Pos4;
                    }
                }

                Result<int> result = Utils.Sql.Update(sqlTable.Value, serverName, ["public_cert", "public_createDT"], 2);
                //Result<int> result2 = Utils.Sql.Update(sqlTable.Value, serverName, sub_c, sub_s, sub_l, sub_o, sub_ou, sub_n, sub_e);
                if (result.IsSuccess && result.Value != 0)
                {
                    MessageBox.Show($"Updated {result.Value} entry(s) in the database", "SQL Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(result.Reasons[0].Message.ToString(), "Update failed!");
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(Convert.ToString(ex), "Update failed!");
        }
    }
    private void Bt_read_Dest_names_Click(object sender, EventArgs e)
    {
        try
        {
            string serverSelect = string.Empty;
            serverType table = serverType.ca;
            Button btn = (Button)sender;

            if (btn.AccessibleName == "ca")
            {
                table = serverType.ca;
                serverSelect = Convert.ToString(lb_ca_certs.SelectedItem);
            }
            else if (btn.AccessibleName == "int")
            {
                table = serverType.intermediate;
                serverSelect = Convert.ToString(lb_int_certs.SelectedItem);
            }
            else if (btn.AccessibleName == "server")
            {
                table = serverType.server;
                serverSelect = Convert.ToString(lb_server_certs.SelectedItem);
            }
            else if (btn.AccessibleName == "user")
            {
                table = serverType.user;
                serverSelect = Convert.ToString(lb_user_certs.SelectedItem);
            }
            else
            {
                throw new Exception("Fehler");
            }



            Result<List<object>> resWhere = Utils.Sql.SelectWhereObject(["subj_country", "subj_state", "subj_location", "subj_organisation", "subj_orgaunit", "subj_commonname", "subj_email"], table, "name", serverSelect);
            string subject = $"C={resWhere.Value[0]}, ST={resWhere.Value[1]}, L={resWhere.Value[2]}, O={resWhere.Value[3]}, OU={resWhere.Value[4]}, CN={resWhere.Value[5]}, Email={resWhere.Value[6]}";
            List<string> list = Utils.Tools.ObjectToString(resWhere.Value);

            tb_sub_c.Text = list[0];
            tb_sub_st.Text = list[1];
            tb_sub_loc.Text = list[2];
            tb_sub_orga.Text = list[3];
            tb_sub_ou.Text = list[4];
            tb_sub_cn.Text = list[5];
            tb_sub_email.Text = list[6];
            tb_ca_sn.Text = Utils.Sql.SelectWhereString(serverType.ca, "serialNumber", "name", serverSelect);



        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString(), sender.ToString());
        }
    }
    #endregion

    #region Parameter
    private void Bt_wrt_param_Click(object sender, EventArgs e)
    {
        try
        {
            bool isCa = cb_isCa.Checked;
            bool noPaLen = cb_notPathlen.Checked;
            int depth = Convert.ToInt16(cb_depth.Text);
            bool critical = cb_critical.Checked;

            Result<serverType> sqlTable = SqlTable();
            string serverSelect = string.Empty;
            if (sqlTable.Value == serverType.ca)
            { serverSelect = Convert.ToString(lb_ca_certs.SelectedItem); }
            else if (sqlTable.Value == serverType.intermediate)
            { serverSelect = Convert.ToString(lb_int_certs.SelectedItem); }
            else if (sqlTable.Value == serverType.server)
            { serverSelect = Convert.ToString(lb_server_certs.SelectedItem); }
            else if (sqlTable.Value == serverType.user)
            { serverSelect = Convert.ToString(lb_user_certs.SelectedItem); }

            Utils.Sql.UpdateBasicConstraints(sqlTable.Value, serverSelect, isCa, noPaLen, depth, critical);
        }
        catch (Exception ex)
        { MessageBox.Show(ex.Message.ToString()); }
    }
    private void Bt_wr_cert_path_Click(object sender, EventArgs e)
    {
        try
        {
            Result<serverType> sqlTable = SqlTable();
            string serverSelect = string.Empty;
            if (sqlTable.Value == serverType.ca)
            { serverSelect = Convert.ToString(lb_ca_certs.SelectedItem); }
            else if (sqlTable.Value == serverType.intermediate)
            { serverSelect = Convert.ToString(lb_int_certs.SelectedItem); }
            else if (sqlTable.Value == serverType.server)
            { serverSelect = Convert.ToString(lb_server_certs.SelectedItem); }
            else if (sqlTable.Value == serverType.user)
            { serverSelect = Convert.ToString(lb_user_certs.SelectedItem); }

            Utils.Sql.WriteCertFileInfo(sqlTable.Value, Tb_cert_filename.Text, Convert.ToString(Cb_file_priv_ext.SelectedItem), Convert.ToString(Cb_file_pub_ext.SelectedItem), Tb_cert_remote_path.Text, serverSelect);

        }
        catch (Exception ex)
        { MessageBox.Show(ex.Message.ToString()); }
    }

    #endregion

    /// <summary>
    /// Enables the Generate Private Key button
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void cb_new_ca_CheckedChanged(object sender, EventArgs e)
    {
        if (cb_new_ca.Checked)
        { tb_ca_name.Visible = true; lbl_ca_name.Visible = true; }
        else
        { tb_ca_name.Visible = false; lbl_ca_name.Visible = false; }
    }
    private void cb_new_inter_CheckedChanged(object sender, EventArgs e)
    {
        if (cb_new_int.Checked)
        { tb_int_name.Visible = true; lbl_int_name.Visible = true; }
        else
        { tb_int_name.Visible = false; lbl_int_name.Visible = false; }
    }

    private void cb_new_server_CheckedChanged(object sender, EventArgs e)
    {
        if (cb_new_server.Checked)
        { tb_server_name.Visible = true; lbl_server_name.Visible = true; }
        else
        { tb_server_name.Visible = false; lbl_server_name.Visible = false; }
    }

    private void cb_new_user_CheckedChanged(object sender, EventArgs e)
    {
        if (cb_new_user.Checked)
        { lbl_user_name.Visible = true; tb_user_name.Visible = true; }
        else
        { lbl_user_name.Visible = false; tb_user_name.Visible = false; }
    }

    private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
    {

        MessageBox.Show($"Knoten ausgewählt:\nID: {e.Node.Text}\nBeschreibung: {e.Node.Tag}");
    }

    private void edit_config_load(object sender, EventArgs e)
    {
        edit_config editConfig = new edit_config();
        editConfig.ShowDialog();
    }

    private void Bt_read_Dest_names_Click_1(object sender, EventArgs e)
    {

    }

    private void Bt_sign_int_cert_Click(object sender, EventArgs e)
    {

    }

    private void button5_Click(object sender, EventArgs e)
    {
        //string pem = "232";
        //byte[] bytes = Encoding.UTF8.GetBytes(pem);

        //Form writeFileForm = new WriteFile("serverName", bytes);
        //writeFileForm.Text = "Exporting Private Key";

        //writeFileForm.ShowDialog();

    }


}

