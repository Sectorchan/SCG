//#define writeFile
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using FluentResults;
using Microsoft.Data.Sqlite;
using static secrets.Secrets;
using PL;
using static PL.Utils.Certs;
using static PL.Utils.Sql;
using WinFormsApp1;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
//using static SCG.Ssql;
using RadioButton = System.Windows.Forms.RadioButton;
using System.Threading.Tasks.Dataflow;
using System.Runtime.InteropServices.JavaScript;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.ConstrainedExecution;
using System.Net;
using static PL.Utils;
using static PL.Utils.Tools;
using Renci.SshNet;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Net.Mime.MediaTypeNames;
using SCG.Properties;


namespace SCG.Forms;

public partial class Server : Form
{
    public Server() { InitializeComponent(); }

    #region Private members
    private readonly bool writeFile = true;
    private readonly bool certVerify = true;
    private readonly string[] fqdn = ["subj_country", "subj_state", "subj_location", "subj_organisation", "subj_orgaunit", "subj_commonname", "subj_email"];
    private readonly string[] idSql = ["id"];
    private readonly string[] sshCred = ["host_username", "host_password", "hostname"];
    private readonly string[] sshlocs = ["cert_filename", "cert_priv_ext", "cert_pub_ext", "cert_path"];


    private readonly string c_selfsignedPasswordPfx = "";

    private readonly string i_selfsignedPasswordPfx = "";
    private readonly string s_selfsignedPasswordPfx = "";
    private readonly string u_selfsignedPasswordPfx = "";
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
        ReadServers(lb_ca_certs, certType.ca);
        lb_ca_certs.Sorted = true;

        lbl_int_name.Visible = false;
        tb_int_name.Visible = false;
        lb_int_certs.Items.Clear();
        ReadServers(lb_int_certs, certType.intermediate);
        lb_int_certs.Sorted = true;

        tb_server_name.Visible = false;
        lbl_server_name.Visible = false;
        lb_server_certs.Items.Clear();
        ReadServers(lb_server_certs, certType.server);
        lb_server_certs.Sorted = true;

        tb_user_name.Visible = false;
        lbl_user_name.Visible = false;
        lb_user_certs.Items.Clear();
        ReadServers(lb_user_certs, certType.user);
        lb_user_certs.Sorted = true;
        #endregion
        string SqlTable = panel1.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).Text;
        if (SqlTable == "CA")
        {
            cb_isCa.Checked = true;
            cb_critical.Checked = true;
        }

        Result<List<object>> result = Utils.Sql.SelectWhereObject(certType.ca, ["name", "id"], "name", string.Empty);
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
        Utils.Sql.SelectWhereObject(certType.intermediate, idSql, "", "*");
        treeView1.Sort();
    }


    public Result<List<string>> ReadServers(dynamic control, certType table)
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

    public Result<certType> SqlTable()
    {
        string SqlTable = panel1.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).Text;
        certType Table = certType.ca;
        switch (SqlTable)
        {
            case "CA":
                Table = certType.ca;
                break;
            case "Intermediate":
                Table = certType.intermediate;
                break;
            case "Server":
                Table = certType.server;
                break;
            case "User":
                Table = certType.user;
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
            string serverName = tb_ca_name.Text;
            //generate privatekey
            string privateKeyPem = Utils.Certs.GeneratePrivateKey(keySize);
            //write to sql
            int insertRow = Utils.Sql.InsertInto(certType.ca, serverName, privateKeyPem, keySize);
            //write to file
            if (writeFile)
            {
                File.WriteAllText("ca_" + serverName + "_priv.pem", privateKeyPem);
            }
            if (Properties.Settings.Default.autoUpload)
            {

            }
            MessageBox.Show($"Successfully inserted {insertRow} row(s) into the database");

            lb_ca_certs.Items.Clear();
            ReadServers(lb_ca_certs, certType.ca);
            lb_ca_certs.Sorted = true;
            lb_ca_certs.SelectedItem = serverName;
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
            Utils.Sql.Select(certType.ca, serverName);
            string publicKeyPem = Utils.Certs.GeneratePublicKey(serverName);
            Result<int> columnsUpdated = Utils.Sql.Update(certType.ca, serverName, ["public_cert", "public_createDT"]);

            if (columnsUpdated.IsSuccess)
            {
                MessageBox.Show($"Successfully inserted {columnsUpdated.Value} row(s) into the database");
            }
            else
            {
                MessageBox.Show($"Failed with: {columnsUpdated.Value}");
            }
            if (writeFile)
            {

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
            string caName = Convert.ToString(lb_ca_certs.SelectedItem);
            int duration = Convert.ToInt32(tb_ca_dura.Text);

            string c_privateKeyPath = Utils.Sql.SelectWhereString(certType.ca, "private_key", "name", caName);
            int c_privateKeySn = Convert.ToInt32(Utils.Sql.SelectWhereString(certType.ca, "serialNumber", "name", caName));
            c_privateKeySn++;

            //generate destName
            List<object> fqdnRes = Sql.SelectWhereObject(certType.ca, fqdn, "name", caName);
            X500DistinguishedName distinguishedName = DNBuilder(Convert.ToString(fqdnRes[0]), Convert.ToString(fqdnRes[1]), Convert.ToString(fqdnRes[2]), Convert.ToString(fqdnRes[3]), Convert.ToString(fqdnRes[4]), Convert.ToString(fqdnRes[5]), Convert.ToString(fqdnRes[6]));
            X509Certificate2 interCertSql = Utils.Certs.CreateCertificate(c_privateKeyPath, distinguishedName, null, null, duration, 0, certType.ca);  // 0 = Serialnumber

            if (writeFile)
            {

                //write signed certificate to file
                File.WriteAllBytes("ca_" + caName + "_ss.pfx", interCertSql.Export(X509ContentType.Pfx, i_selfsignedPasswordPfx)); //includes public and private
                File.WriteAllBytes("ca_" + caName + "_ss.cer", interCertSql.Export(X509ContentType.Cert));//includes only public
            }
            byte[] ssCert = interCertSql.Export(X509ContentType.Pfx, c_selfsignedPasswordPfx);
            //write signed certificate to sql database
            Utils.Sql.UpdateSelfSigned(certType.ca, caName, ssCert, duration, c_privateKeySn);

            if (certVerify)
            {
                // load selfsigned certificate from database to verify the content
                byte[] intSsCertSql = Utils.Sql.SelectSsCert(certType.ca, "ss_cert", "name", caName);
                var sqlSelfSigned = new X509Certificate2(intSsCertSql, c_selfsignedPasswordPfx, X509KeyStorageFlags.Exportable);
                CheckPrivateKey(sqlSelfSigned);
            }

            //information message
            Console.WriteLine($"Intermediate-Zertifikat in \"ca_\" + caName + \"_ss.pfx\" gespeichert.");
            MessageBox.Show($"Intermediate-Zertifikat in \"ca_\" + caName + \"_ss.pfx\" gespeichert.");
        }
        catch (Exception ex)
        { MessageBox.Show(ex.ToString()); }
    }
    private void Bt_reCreate_ca_selfSigned_key_Click(object sender, EventArgs e)
    {
        string caName = Convert.ToString(lb_ca_certs.SelectedItem);
        byte[] intSsCertSql = Utils.Sql.SelectSsCert(certType.ca, "ss_cert", "name", caName);
        X509Certificate2 sqlSelfSigned = new X509Certificate2(intSsCertSql, c_selfsignedPasswordPfx, X509KeyStorageFlags.Exportable);
        byte[] certToSend = sqlSelfSigned.Export(X509ContentType.Pfx, c_selfsignedPasswordPfx);

        Result<List<object>> list = Utils.Sql.SelectWhereObject(sshCred, certType.ca, "name", caName);




        //SaveFileDialog saveFileDialog1 = new SaveFileDialog();
        //saveFileDialog1.InitialDirectory = System.Reflection.Assembly.GetExecutingAssembly().Location;
        //saveFileDialog1.RestoreDirectory = true;
        //saveFileDialog1.Title = "Save certificate";

        //saveFileDialog1.AddExtension = true;
        //saveFileDialog1.CheckFileExists = true;
        //saveFileDialog1.FileName = "ca_" + caName + "_reCreate_ss";
        //saveFileDialog1.ShowDialog();


        //Utils.ssh.UploadCert(Convert.ToString(list.Value[2]), Convert.ToString(list.Value[0]), Convert.ToString(list.Value[1]), certToSend, _remoteFilePath);

        File.WriteAllBytes("ca_" + caName + "_reCreate_ss.pfx", sqlSelfSigned.Export(X509ContentType.Pfx, c_selfsignedPasswordPfx)); //includes public and private
        File.WriteAllBytes("ca_" + caName + "_reCreate_ss.cer", sqlSelfSigned.Export(X509ContentType.Cert));//includes only public
    }

    private void Bt_ca_uploadCert_Click(object sender, EventArgs e)
    {
        string serverName = Convert.ToString(lb_ca_certs.SelectedItem);

        byte[] intSsCertSql = Utils.Sql.SelectSsCert(certType.ca, "ss_cert", "name", serverName);
        X509Certificate2 sqlSelfSigned = new X509Certificate2(intSsCertSql, c_selfsignedPasswordPfx, X509KeyStorageFlags.Exportable);
        byte[] certToSend = sqlSelfSigned.Export(X509ContentType.Cert);
        string privCert = GetPrivateKey(certType.ca, serverName);

        Result<List<object>> list = Utils.Sql.SelectWhereObject(certType.ca, sshlocs, "name", serverName);


        string[] certDetails = GetCertDetails(certType.ca, serverName);
        string[] serverDetails = GetServerDetails(certType.ca, serverName);

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
            string privateKeyPem = Utils.Certs.GeneratePrivateKey(keySize);
            //write to sql
            int insertRow = Utils.Sql.InsertInto(certType.intermediate, interName, privateKeyPem, keySize);
            //write to file
            if (writeFile)
            {
                File.WriteAllText("ci_" + interName + "_priv.pem", privateKeyPem);
            }
            MessageBox.Show($"Successfully inserted {insertRow} row(s) into the database");

            lb_int_certs.Items.Clear();
            ReadServers(lb_int_certs, certType.intermediate);
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
        string i_privateKeyPath = Utils.Sql.SelectWhereString(certType.intermediate, "private_key", "name", interName);
        //generate public key with passed private key
        string publicKeyPem = Utils.Certs.GeneratePublicKey(i_privateKeyPath);
        //write to sql
        int insertRow = Utils.Sql.Update(certType.intermediate, publicKeyPem, interName, "name");
        //write to file
        File.WriteAllText("ci_" + interName + "_pub.pem", publicKeyPem);
        //return result
        MessageBox.Show($"Successfully inserted {insertRow} row(s) into the database");

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
            byte[] caSsCertSql = Utils.Sql.SelectSsCert(certType.ca, "ss_cert", "name", serverName);
            string caIndex = Utils.Sql.SelectWhereString(certType.ca, "id", "name", serverName);

            string i_privateKeyPath = Utils.Sql.SelectWhereString(certType.intermediate, "private_key", "name", interName);
            int i_privateKeySn = Convert.ToInt32(Utils.Sql.SelectWhereString(certType.intermediate, "serialNumber", "name", interName));
            i_privateKeySn++;

            //generate destName
            List<object> fqdnRes = Sql.SelectWhereObject(certType.intermediate, fqdn, "name", interName);
            X500DistinguishedName distinguishedName = DNBuilder(Convert.ToString(fqdnRes[0]), Convert.ToString(fqdnRes[1]), Convert.ToString(fqdnRes[2]), Convert.ToString(fqdnRes[3]), Convert.ToString(fqdnRes[4]), Convert.ToString(fqdnRes[5]), Convert.ToString(fqdnRes[6]));

            //generate from SQL
            X509Certificate2 interCertSql = Utils.Certs.CreateCertificate(i_privateKeyPath, distinguishedName, caSsCertSql, caPassword, duration, i_privateKeySn, certType.intermediate);

            if (writeFile)
            {
                //write signed certificate to file
                File.WriteAllBytes("ci_" + interName + "_ss.pfx", interCertSql.Export(X509ContentType.Pfx, i_selfsignedPasswordPfx)); //includes public and private
                File.WriteAllBytes("ci_" + interName + "_ss.cer", interCertSql.Export(X509ContentType.Cert));//includes only public
            }
            //write signed certificate to sql database
            Utils.Sql.UpdateSelfSigned(certType.intermediate, interName, interCertSql.Export(X509ContentType.Pfx, i_selfsignedPasswordPfx), Convert.ToInt32(caIndex), duration, i_privateKeySn);

            if (certVerify)
            {
                // load selfsigned certificate from database to verify the content
                byte[] intSsCertSql = Utils.Sql.SelectSsCert(certType.intermediate, "ss_cert", "name", interName);
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

        byte[] intSsCertSql = Utils.Sql.SelectSsCert(certType.intermediate, "ss_cert", "name", serverName);
        X509Certificate2 sqlSelfSigned = new X509Certificate2(intSsCertSql, c_selfsignedPasswordPfx, X509KeyStorageFlags.Exportable);
        byte[] certToSend = sqlSelfSigned.Export(X509ContentType.Cert);
        string privCert = GetPrivateKey(certType.intermediate, serverName);

        Result<List<object>> list = Utils.Sql.SelectWhereObject(certType.intermediate, sshlocs, "name", serverName);


        string[] certDetails = GetCertDetails(certType.intermediate, serverName);
        string[] serverDetails = GetServerDetails(certType.intermediate, serverName);

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
        string privateKeyPem = Utils.Certs.GeneratePrivateKey(keySize);
        //write to sql
        int insertRow = Utils.Sql.InsertInto(certType.server, serverName, privateKeyPem, keySize);
        if (writeFile)
        {
            //write to file
            File.WriteAllText("cs_" + serverName + "_priv.pem", privateKeyPem);
        }
        MessageBox.Show($"Successfully inserted {insertRow} row(s) into the database");

        lb_server_certs.Items.Clear();
        ReadServers(lb_server_certs, certType.server);
        lb_server_certs.Sorted = true;
        lb_server_certs.SelectedItem = serverName;
    }
    private void Bt_gen_server_pub_Click(object sender, EventArgs e)
    {
        string serverName = Convert.ToString(lb_server_certs.SelectedItem);
        //read private key
        string s_privateKeyPath = Utils.Sql.SelectWhereString(certType.server, "private_key", "name", serverName);
        //generate public key with passed private key
        string publicKeyPem = Utils.Certs.GeneratePublicKey(s_privateKeyPath);
        //write to sql
        int insertRow = Utils.Sql.Update(certType.server, publicKeyPem, serverName, "name");
        //write to file
        File.WriteAllText("cs_" + serverName + "_pub.pem", publicKeyPem);
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
            byte[] intSsCertSql = Utils.Sql.SelectSsCert(certType.intermediate, "ss_cert", "name", interName);
            string intIndex = Utils.Sql.SelectWhereString(certType.intermediate, "id", "name", interName);
            //read server certificate from SQL
            string s_privateKeyPath = Utils.Sql.SelectWhereString(certType.server, "private_key", "name", serverName);
            int s_privateKeySn = Convert.ToInt32(Utils.Sql.SelectWhereString(certType.server, "serialNumber", "name", serverName));

            // generate DistinguishedName
            List<object> fqdnRes = Sql.SelectWhereObject(certType.server, fqdn, "name", serverName);
            X500DistinguishedName distinguishedName = DNBuilder(Convert.ToString(fqdnRes[0]), Convert.ToString(fqdnRes[1]), Convert.ToString(fqdnRes[2]), Convert.ToString(fqdnRes[3]), Convert.ToString(fqdnRes[4]), Convert.ToString(fqdnRes[5]), Convert.ToString(fqdnRes[6]));
            s_privateKeySn++;

            //generate from SQL
            X509Certificate2 serverCertSql = Utils.Certs.CreateCertificate(s_privateKeyPath, distinguishedName, intSsCertSql, intPassword, duration, s_privateKeySn, certType.server);


            if (writeFile)
            {
                //write signed certificate to file
                File.WriteAllBytes("cs_" + serverName + "_ss.pfx", serverCertSql.Export(X509ContentType.Pfx, s_selfsignedPasswordPfx)); //includes public and private
                File.WriteAllBytes("cs_" + serverName + "_ss.cer", serverCertSql.Export(X509ContentType.Cert));//includes only public
            }
            //write signed certificate to sql database
            Utils.Sql.UpdateSelfSigned(certType.server, serverName, serverCertSql.Export(X509ContentType.Pfx, s_selfsignedPasswordPfx), Convert.ToInt32(intIndex), duration, s_privateKeySn);
            if (certVerify)
            {
                // load selfsigned certificate from database to verify the content
                byte[] servSsCertSql = Utils.Sql.SelectSsCert(certType.server, "ss_cert", "name", serverName);
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

        byte[] intSsCertSql = Utils.Sql.SelectSsCert(certType.server, "ss_cert", "name", serverName);
        X509Certificate2 sqlSelfSigned = new X509Certificate2(intSsCertSql, c_selfsignedPasswordPfx, X509KeyStorageFlags.Exportable);
        byte[] certToSend = sqlSelfSigned.Export(X509ContentType.Cert);
        string privCert = GetPrivateKey(certType.server, serverName);

        Result<List<object>> list = Utils.Sql.SelectWhereObject(certType.server, sshlocs, "name", serverName);


        string[] certDetails = GetCertDetails(certType.server, serverName);
        string[] serverDetails = GetServerDetails(certType.server, serverName);

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
        string privateKeyPem = Utils.Certs.GeneratePrivateKey(keySize);
        //write to sql
        int insertRow = Utils.Sql.InsertInto(certType.user, userName, privateKeyPem, keySize);
        if (writeFile)
        {
            //write to file
            File.WriteAllText("cu_" + userName + "_priv.pem", privateKeyPem);
        }
        MessageBox.Show($"Successfully inserted {insertRow} row(s) into the database");

        lb_user_certs.Items.Clear();
        ReadServers(lb_user_certs, certType.user);
        lb_user_certs.Sorted = true;
        lb_user_certs.SelectedItem = userName;
    }
    private void Bt_gen_user_pub_Click(object sender, EventArgs e)
    {
        string userName = Convert.ToString(lb_user_certs.SelectedItem);
        //read private key
        string s_privateKeyPath = Utils.Sql.SelectWhereString(certType.user, "private_key", "name", userName);
        //generate public key with passed private key
        string publicKeyPem = Utils.Certs.GeneratePublicKey(s_privateKeyPath);
        //write to sql
        int insertRow = Utils.Sql.Update(certType.user, publicKeyPem, userName, "name");
        //write to file
        File.WriteAllText("cu_" + userName + "_pub.pem", publicKeyPem);
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
            byte[] intSsCertSql = Utils.Sql.SelectSsCert(certType.intermediate, "ss_cert", "name", interName);
            string intIndex = Utils.Sql.SelectWhereString(certType.intermediate, "id", "name", interName);
            //read user certificate from SQL
            string u_privateKeyPath = Utils.Sql.SelectWhereString(certType.user, "private_key", "name", userName);
            int u_privateKeySn = Convert.ToInt32(Utils.Sql.SelectWhereString(certType.user, "serialNumber", "name", userName));
            u_privateKeySn++;

            // generate DistinguishedName
            List<object> fqdnRes = Sql.SelectWhereObject(certType.user, fqdn, "name", userName);
            X500DistinguishedName distinguishedName = DNBuilder(Convert.ToString(fqdnRes[0]), Convert.ToString(fqdnRes[1]), Convert.ToString(fqdnRes[2]), Convert.ToString(fqdnRes[3]), Convert.ToString(fqdnRes[4]), Convert.ToString(fqdnRes[5]), Convert.ToString(fqdnRes[6]));

            //generate from SQL
            X509Certificate2 userCertSql = Utils.Certs.CreateCertificate(u_privateKeyPath, distinguishedName, intSsCertSql, intPassword, duration, u_privateKeySn, certType.user);

            if (writeFile)
            {
                //write signed certificate to file
                File.WriteAllBytes("cu_" + userName + "_ss.pfx", userCertSql.Export(X509ContentType.Pfx, u_selfsignedPasswordPfx)); //includes public and private
                File.WriteAllBytes("cu_" + userName + "_ss.cer", userCertSql.Export(X509ContentType.Cert));//includes only public
            }
            //write signed certificate to sql database
            Utils.Sql.UpdateSelfSigned(certType.user, userName, userCertSql.Export(X509ContentType.Pfx, u_selfsignedPasswordPfx), Convert.ToInt32(intIndex), duration, u_privateKeySn);
            if (certVerify)
            {
                // load selfsigned certificate from database to verify the content
                byte[] userSsCertSql = Utils.Sql.SelectSsCert(certType.user, "ss_cert", "name", userName);
                var sqlSelfSigned = new X509Certificate2(userSsCertSql, u_selfsignedPasswordPfx, X509KeyStorageFlags.Exportable);
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

    static void CreateSelfSignedCertificate(string privateKeyPath, string publicKeyPath, string pfxPath, string password)
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

            Result<certType> sqlTable = SqlTable();
            string serverSelect = string.Empty;

            if (sqlTable.IsSuccess)
            {
                if (sqlTable.Value == certType.ca)
                { serverSelect = Convert.ToString(lb_ca_certs.SelectedItem); }
                else if (sqlTable.Value == certType.intermediate)
                { serverSelect = Convert.ToString(lb_int_certs.SelectedItem); }
                else if (sqlTable.Value == certType.server)
                { serverSelect = Convert.ToString(lb_server_certs.SelectedItem); }
                else if (sqlTable.Value == certType.user)
                { serverSelect = Convert.ToString(lb_user_certs.SelectedItem); }

                Result<int> result2 = Utils.Sql.Update(sqlTable.Value, serverSelect, sub_c, sub_s, sub_l, sub_o, sub_ou, sub_n, sub_e);
                if (result2.IsSuccess && result2.Value != 0)
                {
                    MessageBox.Show($"Updated {result2.Value} row(s) in the database", "SQL Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(result2.Reasons[0].Message.ToString(), "Update failed!");
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
            certType table = certType.ca;
            Button btn = (Button)sender;

            if (btn.AccessibleName == "ca")
            {
                table = certType.ca;
                serverSelect = Convert.ToString(lb_ca_certs.SelectedItem);
            }
            else if (btn.AccessibleName == "int")
            {
                table = certType.intermediate;
                serverSelect = Convert.ToString(lb_int_certs.SelectedItem);
            }
            else if (btn.AccessibleName == "server")
            {
                table = certType.server;
                serverSelect = Convert.ToString(lb_server_certs.SelectedItem);
            }
            else if (btn.AccessibleName == "user")
            {
                table = certType.user;
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
            tb_ca_sn.Text = Utils.Sql.SelectWhereString(certType.ca, "serialNumber", "name", serverSelect);



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

            Result<certType> sqlTable = SqlTable();
            string serverSelect = string.Empty;
            if (sqlTable.Value == certType.ca)
            { serverSelect = Convert.ToString(lb_ca_certs.SelectedItem); }
            else if (sqlTable.Value == certType.intermediate)
            { serverSelect = Convert.ToString(lb_int_certs.SelectedItem); }
            else if (sqlTable.Value == certType.server)
            { serverSelect = Convert.ToString(lb_server_certs.SelectedItem); }
            else if (sqlTable.Value == certType.user)
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
            Result<certType> sqlTable = SqlTable();
            string serverSelect = string.Empty;
            if (sqlTable.Value == certType.ca)
            { serverSelect = Convert.ToString(lb_ca_certs.SelectedItem); }
            else if (sqlTable.Value == certType.intermediate)
            { serverSelect = Convert.ToString(lb_int_certs.SelectedItem); }
            else if (sqlTable.Value == certType.server)
            { serverSelect = Convert.ToString(lb_server_certs.SelectedItem); }
            else if (sqlTable.Value == certType.user)
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
        try
        {
            string[] serverDetails = GetCaServerDetails("LangCa");
            MessageBox.Show(serverDetails[0]);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }

    }
}

