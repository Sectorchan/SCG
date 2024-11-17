using System;
using System.IO;
using System.Diagnostics;
using System.Linq;
using System.Xml;
using System.Runtime.ConstrainedExecution;
using System.Security.Claims;
using System.Windows.Forms;
using System.Reflection;
using static System.Windows.Forms.LinkLabel;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using System.Text;
using System.Security;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.DataFormats;
using Microsoft.Data.Sqlite;
using SCG.Properties;
using WinFormsApp1.Forms;
using SCG.Forms;
using System.Configuration;
using SCG;
using System.Security.Cryptography;
using static SCG.Ssql;


namespace WinFormsApp1
{
    public partial class MainWindow : Form
    {
        string xml = @"certificates\ca\xml.xml";
        string SSLargument = "";
        string openSSL_bin = "openssl2.exe";
        string openSSLcnf_ca = "openssl-ca.cnf";
        string openSSLcnf_inter = "openssl-inter.cnf";
        string[] _error = [];
        int _caIndex = Settings.Default.CaIndex;
        public string _exePath = System.Reflection.Assembly.GetExecutingAssembly().Location;

        public string ExePath
        {
            get { return _exePath; }
        }


        /// <summary>
        /// Will be passed to the OpenSSL binary
        /// </summary>
        /// <param name="SSLargument1"></param>
        /// <returns></returns>
        public string debugoutput(string SSLargument1)
        {
            try
            {
                Process process = new Process();
                process.StartInfo.FileName = openSSL_bin;
                process.StartInfo.Arguments = SSLargument1;
                //process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.OutputDataReceived += new DataReceivedEventHandler((sender, e) =>
                {
                    // Prepend line numbers to each line of the output.
                    if (!string.IsNullOrEmpty(e.Data))
                    {
                        tb_debugoutput.Text += e.Data;
                    }
                });
                process.Start();
                process.WaitForExit();
                process.Close();
                process.StartInfo.ErrorDialog = true;

                return SSLargument1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fehler bei Debugoutput", ex.Message, MessageBoxButtons.OK);
                SSLargument1 = "Fehler bei Debugoutput";
                return SSLargument1;
            }
        }
        public void UseOpenSSL(string SSLargument1)
        {
            try
            {
                Process process = new Process();
                process.StartInfo.FileName = openSSL_bin;
                process.StartInfo.Arguments = SSLargument1;
                //process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                //process.OutputDataReceived += new DataReceivedEventHandler((sender, e) =>
                //{
                //    // Prepend line numbers to each line of the output.
                //    if (!string.IsNullOrEmpty(e.Data))
                //    {
                //        tb_debugoutput.Text += e.Data;
                //    }
                //});
                process.Start();
                process.WaitForExit();
                process.Close();
                process.StartInfo.ErrorDialog = true;
                int result = process.ExitCode;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error with OpenSSL", ex.Message, MessageBoxButtons.OK);
            }
        }

        public MainWindow()
        {
            #region CheckFolderStructure
            //check the Folderstructure and re-create it if necessary
            StreamReader sr = new StreamReader("FolderStructure.txt");
            string? folder;

            while ((folder = sr.ReadLine()) != null)
            {
                folder = folder.Trim();
                if (folder.EndsWith(".txt"))
                {
                    if (!File.Exists(folder))
                    {
                        File.Create(folder);
                    }
                }
                else
                {
                    if (!Directory.Exists(folder))
                    {
                        Directory.CreateDirectory(folder);
                    }
                }

            }
            #endregion
            if (!File.Exists(xml))
            {
                XDocument doc =
                  new XDocument(
                    new XElement("root",
                      new XElement("name", new XAttribute("filename", xml)),
                      new XElement("date", new XAttribute("created", DateTime.Now), new XAttribute("modified", "")),

                      // From here the CA Section
                      new XElement("ca", "")
                      )
                  );

                doc.Save(xml);
            }

            InitializeComponent();

        }
        /// <summary>
        /// Adds a CA Server entry
        /// </summary>
        /// <param name="file">pass the XML file as relative path</param>
        public void AddCaServer(string file)
        {
            XDocument doc = XDocument.Load(file);
            doc.Root.Element("CA").Add(
               new XElement("name", "Sample-CA"),
                    new XElement("type", "CA"),
                    new XElement("id", "0"),
                    new XElement("Private",
                        new XElement("Bits", "4096"),
                        new XElement("Pass", "passwortca"),
                        new XElement("file", "Sample-CA.key.pem")
                    ),
                    new XElement("Public",
                        new XElement("duration", "7300"),
                        new XElement("pass", "passwortca"),
                        new XElement("cnf", "openssl-ca.cnf"),
                        new XElement("subj",
                          new XElement("C", "DE"),
                          new XElement("ST", "Bavaria"),
                          new XElement("L", "Hausen"),
                          new XElement("OU", "IT"),
                          new XElement("CN", "Lang-CA"),
                          new XElement("email", "admin@admin.de")
                          )
                    )
                );
            doc.Save(file);

            ChangeDateModifiedXml(file);
        }

        /// <summary>
        /// Changes the XML attribute of date modified to now
        /// </summary>
        /// <param name="file">pass the XML file as relative path</param>
        public void ChangeDateModifiedXml(string file)
        {
            XDocument doc = XDocument.Load(file);
            XElement element = doc.Descendants("date").First();
            XAttribute attribute = element.Attribute("modified");
            attribute.Value = DateTime.Now.ToString();
            doc.Save(file);
        }
        public void AddCaPrivKey(string xmlfile)
        {

            XDocument doc = XDocument.Load(xmlfile);
            doc.Root.Element("CA").Add(
               new XElement(tb_ca_priv_name.Text,
                    new XElement("type", "CA"),
                    new XElement("id", _caIndex),
                    new XElement("Private",
                        new XElement("Bits", "4096"),
                        new XElement("Pass", tb_ca_key_pw1.Text),
                        new XElement("file", tb_ca_priv_name.Text + ".key.pem")
                    )
                )
            );
            doc.Save(xmlfile);
            _caIndex++;
            Settings.Default.CaIndex = _caIndex;
            Settings.Default.Save();
            ChangeDateModifiedXml(xmlfile);
            RefreshCaPrivLb(xmlfile);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            RefreshCaPrivLb(xml);
        }
        public void RefreshCaPrivLb(string xmlfile)
        {
            lb_ca_priv.Items.Clear();

            XDocument doc = XDocument.Load(xmlfile);
            foreach (XElement xe in doc.Descendants("CA"))
            //  .Where(e => e.Element("type").Value == "Ca");
            {
                MessageBox.Show(xe.Element("id").Value);
            }
        }
        /// <summary>
        /// Creates the CA private Key
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ca_priv_key_gen_click(object sender, EventArgs e)
        {
            //Openssl command: openssl2.exe genrsa -aes256 -passout pass:test -out certificates/ca/private/ca.key.pem 4096
            if (!string.IsNullOrWhiteSpace(tb_ca_priv_name.Text) || !string.IsNullOrWhiteSpace(tb_ca_key_pw1.Text) || !string.IsNullOrWhiteSpace(tb_ca_key_pw2.Text))// Check if no box is empty.
            {
                if ((tb_ca_key_pw1.Text.Length >= 4) && (tb_ca_key_pw2.Text.Length >= 4)) //openssl requires atleast 4 digit passwords
                {
                    if (tb_ca_key_pw1.Text.Equals(tb_ca_key_pw2.Text))
                    {
                        RSA rsa = RSA.Create();
                        rsa.KeySize = 4096;

                        var CaName = tb_ca_priv_name.Text;
                        var Privbits = rsa.KeySize;
                        var Privpass = tb_ca_key_pw1.Text;
                        var Privkey = rsa.ExportRSAPrivateKeyPem();

                        if (Global.UseOpenSSL)
                        {
                            SSLargument = @"genrsa -aes256 -passout pass:" + tb_ca_key_pw1.Text + " -out certificates/ca/private/" + tb_ca_priv_name.Text + ".kkey.pem 4096";
                            UseOpenSSL(SSLargument);
                        }
                        else
                        {
                            Ssqlc(Global.database, SQLOption.INSERT_INTO, SQLTable.ca, CaName, Privbits, Privpass, Privkey);
                            if (Global.WriteToFile)
                            {
                                using (StreamWriter outputFile = new StreamWriter("certificates/ca/private/" + tb_ca_cert_name.Text + "key.pem"))
                                { outputFile.WriteLine(rsa.ExportPkcs8PrivateKeyPem()); }
                            }
                        }

                        //tb_debugoutput.Text = debugoutput(SSLargument);
                        return;
                    }
                    else
                    { _error = ["Passwort nicht identisch", "Fehlende Information"]; }
                }
                else { _error = ["Passwort mindestern 4 Stellen", "Passwort falsch"]; }
            }
            else { _error = ["Eingabe unvollständig", "Fehlende Information"]; }
            MessageBox.Show(_error[0], _error[1]);
        }
        /// <summary>
        /// Creates the CA public certificate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ca_cert_key_gen_Click(object sender, EventArgs e)
        {
            //Openssl command: openssl2.exe req -config openssl-ca.cnf -key certificates/ca/private/ca.key.pem -passin pass:test -new -x509 -days 7300 -sha256 -extensions v3_ca -out certificates/ca/certs/ca.cert.pem -subj "/C=DE/ST=Bavaria/L=Schwabhausen/O=Lang-Lan/OU=IT/CN=Lang-CA2509/emailAddress=admin3@diefamilielang.de"
            if (!string.IsNullOrWhiteSpace(tb_ca_priv_name.Text) || !string.IsNullOrWhiteSpace(tb_ca_key_pw1.Text) || !string.IsNullOrWhiteSpace(tb_ca_key_pw2.Text))// Check if no box is empty.
            {
                if (tb_ca_key_pw1.Text.Length >= 4 && tb_ca_key_pw2.Text.Length >= 4)
                {
                    if (tb_ca_key_pw1.Text.Equals(tb_ca_key_pw2.Text))
                    {
                        SSLargument = @"req -config " + openSSLcnf_ca + " -key certificates/ca/private/" + tb_ca_priv_name.Text + ".key.pem -passin pass:" + tb_ca_key_pw_in.Text + " -new -x509 -days " + tb_ca_cert_days.Text + " -sha256 -extensions v3_ca -out certificates/ca/certs/" + tb_ca_priv_name.Text + ".cert.pem -subj \"/C=DE/ST=Bavaria/L=Schwabhausen/O=Lang-Lan/OU=IT/CN=Lang-CA/emailAddress=admmin@diefamilielang.de\"";

                        var sql = "UPDATE ca SET public_duration = @Public_Duration, public_pass = @Public_Pass, public_createDT = @Public_CreateDT, cnf = @Ca_Cnf, subj_country = @Subj_Country, subj_state = @Subj_State, subj_location = @Subj_Location, subj_orgaunit = @Subj_OrgaUnit, subj_commonname = @Subj_CommonName, subj_email= @Subj_EMail WHERE name = @Ca_Name";

                        var PublicDuration = tb_ca_cert_days.Text;
                        var PublicPass = tb_ca_key_pw_in.Text;
                        var PublicCreateDT = DateTime.Now.ToString();
                        var CaCnf = Global.ca_cnf;
                        var SubjCountry = "DE";
                        var SubjState = "Bavaria";
                        var SubjLocation = "Schwabhausen";
                        var SubjOrgaUnit = "IT";
                        var SubjCommonName = "Lang-CA-Cert";
                        var SubjEMail = "admin@lang.de";
                        var CaName = tb_ca_cert_name.Text;

                        using var connection = new SqliteConnection(Global.database);
                        connection.Open();

                        // Bind parameters values
                        using var command = new SqliteCommand(sql, connection);

                        command.Parameters.AddWithValue("@Public_Duration", PublicDuration);
                        command.Parameters.AddWithValue("@Public_Pass", PublicPass);
                        command.Parameters.AddWithValue("@Public_CreateDT", PublicCreateDT);
                        command.Parameters.AddWithValue("@Ca_Cnf", CaCnf);
                        command.Parameters.AddWithValue("@Subj_Country", SubjCountry);
                        command.Parameters.AddWithValue("@Subj_State", SubjState);
                        command.Parameters.AddWithValue("@Subj_Location", SubjLocation);
                        command.Parameters.AddWithValue("@Subj_OrgaUnit", SubjOrgaUnit);
                        command.Parameters.AddWithValue("@Subj_CommonName", SubjCommonName);
                        command.Parameters.AddWithValue("@Subj_EMail", SubjEMail);
                        command.Parameters.AddWithValue("@Ca_Name", CaName);



                        // Execute the INSERT statement
                        var rowInserted = command.ExecuteNonQuery();


                        tb_debugoutput.Text = debugoutput(SSLargument);
                        return;
                    }
                    else
                    {
                        _error = ["Passwort nicht identisch", "Fehlende Information"];
                        //MessageBox.Show("Passwort NICHT Identisch", "Fehlende Information", MessageBoxButtons.OK);
                    }
                }
                else { _error = ["Passwort mindestern 4 Stellen", "Passwort falsch"]; }
            }
            else { _error = ["Eingabe unvollständig", "Fehlende Information"]; }
            MessageBox.Show(_error[0], _error[1]);
        }
        /// <summary>
        /// Creates the Intermediate private key
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_inter_key_gen_Click(object sender, EventArgs e)
        {
            //Openssl command: openssl2.exe genrsa -aes256 -passout pass:test2 -out certificates/intermediate/private/int.key.pem 4096
            if ((!string.IsNullOrWhiteSpace(tb_inter_priv_name.Text) || !string.IsNullOrWhiteSpace(tb_inter_key_pw1.Text) || !string.IsNullOrWhiteSpace(tb_inter_key_pw2.Text)))// Check if no box is empty.
            {
                if (tb_inter_key_pw1.Text.Length >= 4 && tb_inter_key_pw2.Text.Length >= 4)
                {
                    if (tb_inter_key_pw1.Text.Equals(tb_inter_key_pw2.Text))
                    {
                        SSLargument = @"genrsa -aes256 -passout pass:" + tb_inter_key_pw1.Text + " -out certificates/intermediate/private/" + tb_inter_priv_name.Text + ".key.pem 4096";
                        tb_debugoutput.Text = debugoutput(SSLargument);
                    }
                    else { MessageBox.Show("Passwort NICHT Identisch", "Fehlende Information", MessageBoxButtons.OK); }
                }
                else { MessageBox.Show("Passwort mindestern 4 Stellen", "Fehlende Information", MessageBoxButtons.OK); }
            }
            else { MessageBox.Show("Eingabe unvollständig!", "Fehlende Information", MessageBoxButtons.OK); }
        }
        /// <summary>
        /// Creates the Intermediate CSR
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_inter_csr_gen_Click(object sender, EventArgs e)
        {
            //Openssl command: openssl2.exe req -config openssl-inter.cnf -new -sha256 -key certificates/intermediate/private/int.key.pem -passin pass:test2 -out certificates/intermediate/csr/int.csr.pem -subj "/C=DE/ST=Bavaria/L=Schwabhausen/O=Lang-Lan/OU=IT/CN=Lang-Intermediate2509/emailAddress=admin2@diefamilielang.de"
            if (!string.IsNullOrWhiteSpace(tb_inter_priv_name.Text) || !string.IsNullOrWhiteSpace(tb_inter_key_pw1.Text) || !string.IsNullOrWhiteSpace(tb_inter_key_pw2.Text))// Check if no box is empty.
            {
                if (tb_inter_key_pw1.Text.Length >= 4 && tb_inter_key_pw2.Text.Length >= 4)
                {
                    if (tb_inter_key_pw1.Text.Equals(tb_inter_key_pw2.Text))
                    {
                        SSLargument = @"req -config " + openSSLcnf_inter + " -new -sha256 -key certificates/intermediate/private/" + tb_inter_priv_name.Text + ".key.pem -passin pass:" + tb_inter_key_pw1.Text + "  -out certificates/intermediate/csr/" + tb_inter_priv_name.Text + ".csr.pem -subj \"/C=DE/ST=Bavaria/L=Schwabhausen/O=Lang-Lan/OU=IT/CN=Lang-Intermediate2709/emailAddress=admin-intermediate@diefamilielang.de\"";
                        tb_debugoutput.Text = debugoutput(SSLargument);
                    }
                    else { MessageBox.Show("Passwort NICHT Identisch", "Fehlende Information", MessageBoxButtons.OK); }
                }
                else { MessageBox.Show("Passwort mindestern 4 Stellen", "Fehlende Information", MessageBoxButtons.OK); }
            }
            else { MessageBox.Show("Eingabe unvollständig!", "Fehlende Information", MessageBoxButtons.OK); }
        }
        /// <summary>
        /// Creates the Intermediate certificate signed by the CA
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_inter_sign_ca_name_Click(object sender, EventArgs e)
        {
            //openssl command: openssl2.exe ca -config openssl-ca.cnf -passin pass:test -rand_serial -extensions v3_intermediate_ca -days 3650 -batch -md sha256 -in certificates/intermediate/csr/int.csr.pem -out certificates/intermediate/certs/int.cert.pem 
            //                              ca -config openssl-ca.cnf -passin pass:test -rand_serial -extensions v3_intermediate_ca -days 3650 -batch -md sha256 -in certificates/intermediate/csr/int.csr.pem -out certificates/intermediate/certs/int.cert.pem"
            if (tb_inter_sign_ca_key_in.Text.Length >= 4)
            {
                SSLargument = @"ca -config " + openSSLcnf_ca + " -passin pass:" + tb_inter_sign_ca_key_in.Text + " -rand_serial -extensions v3_intermediate_ca -days " + tb_inter_cert_days.Text + " -batch -md sha256 -in certificates/intermediate/csr/" + tb_inter_cert_name.Text + ".csr.pem -out certificates/intermediate/certs/" + tb_inter_cert_name.Text + ".cert.pem";
                tb_debugoutput.Text = debugoutput(SSLargument);
            }
        }
        private void cb_inter_sign_CheckStateChanged(object sender, EventArgs e)
        {
            if (cb_inter_sign.Checked)
            {
                bt_inter_sign_ca_name.Enabled = true;
            }
            else
            {
                bt_inter_sign_ca_name.Enabled = false;
            }
        }
        /// <summary>
        /// Creates the application or server private key
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_appl_priv_gen_click(object sender, EventArgs e)
        {
            SSLargument = @"genrsa -out certificates/server/private/" + tb_appl_priv_name.Text + ".key.pem 4096";
            tb_debugoutput.Text = debugoutput(SSLargument);
        }
        /// <summary>
        /// Creates the application or server CSR
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_appl_csr_gen_click(object sender, EventArgs e)
        {
            SSLargument = @"req -config " + openSSLcnf_inter + " -x509 -key certificates/server/private/" + tb_appl_priv_name.Text + ".key.pem -sha256 -out certificates/server/csr/" + tb_appl_csr_name.Text + ".csr.pem -subj \"/C=DE/ST=Bavaria/L=Schwabhausen/O=Lang-Lan/OU=IT/CN=server/emailAddress=admin@diefamilielang.de/subjectAltName=DNS:ubn-grafana.lang,DNS:grafana,IP:192.168.1.20\"";
            tb_debugoutput.Text = debugoutput(SSLargument);
        }
        /// <summary>
        /// Creates the application or server public certificate signed from the Intermediate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_appl_sign_inter_name_Click(object sender, EventArgs e)
        {
            SSLargument = @"ca -config " + openSSLcnf_inter + " -passin pass:" + tb_inter_key_pw1.Text + " -extensions server_cert  -rand_serial -batch -days " + tb_appl_cert_days.Text + " -md sha256 -in certificates/server/csr/" + tb_appl_priv_name.Text + ".csr.pem -out certificates/server/certs/" + tb_appl_csr_name.Text + ".cert.pem ";    //-subj \"/C=DE/ST=Bavaria/L=Schwabhausen/O=Lang-Lan/OU=IT/CN=server/emailAddress=admin@diefamilielang.de/subjectAltName=DNS:ubn-grafana.lang, DNS:grafana, IP:192.168.1.20\"";
            tb_debugoutput.Text = debugoutput(SSLargument);
        }
        private void opensslCnfCa_click(object sender, EventArgs e)
        {
            openSSL_CA_Configfile form2 = new openSSL_CA_Configfile();
            form2.ShowDialog();
            tb_cat_ca_name.Text = form2.opensslCaCnfPath;

        }
        private void opensslCnfInt_click(object sender, EventArgs e)
        {


        }
        private void button1_Click(object sender, EventArgs e)
        {
            XDocument d = new XDocument(
    new XComment("This is a comment."),
    new XProcessingInstruction("xml-stylesheet",
        "href='mystyle.css' title='Compact' type='text/css'"),
    new XElement("Pubs",
        new XElement("Book",
            new XElement("Title", "Artifacts of Roman Civilization"),
            new XElement("Author", "Moreno, Jordao")
        ),
        new XElement("Book",
            new XElement("Title", "Midieval Tools and Implements"),
            new XElement("Author", "Gazit, Inbar")
        )
    ),
    new XComment("This is another comment.")
);
            d.Declaration = new XDeclaration("1.0", "utf-8", "true");
            Console.WriteLine(d);

            d.Save("ApplicationSettings.xml");
        }
        private void serverConfigList_click(object sender, EventArgs e)
        {
            Server form3 = new Server();
            form3.ShowDialog();
        }
        private void Main_onLoad(object sender, EventArgs e)
        {
            //RefreshCaPrivLb(xml);
            //using var connection = new SqliteConnection(Global.database);
            //connection.Open();
            //var sql = "SELECT name FROM ca";
            //using var command = new SqliteCommand(sql, connection);
            //using var reader = command.ExecuteReader();
            //if (reader.HasRows)
            //{
            //    while (reader.Read())
            //    {
            //        var name = reader.GetString(0);
            //        lb_ca_priv.Items.Add(name);
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("No Server found", "", MessageBoxButtons.OK);
            //}

        }


    }

    public static class Global
    {
        public static string database = @"..\..\..\databasev2.db";
        //public static string database = @"Data Source=database.db";
        public static string ca_cnf = "openssl-ca.cnf";
        public static bool WriteToFile = true;
        public static bool UseOpenSSL = false;
    }

}
