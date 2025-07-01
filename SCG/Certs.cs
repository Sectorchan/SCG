using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL;
public class Certs
{
    public int id { get; set; }
    public string name { get; set; }
    public int keySize { get; set; }
    public string private_key { get; set; }
    public int private_createDT { get; set; }
    public string public_cert { get; set; }
    public int public_createDT { get; set; }
    public string ss_cert { get; set; }
    public int ss_createDT { get; set; }
    public int ss_duration { get; set; }
    public string subj_country { get; set; }
    public string subj_state { get; set; }
    public string subj_location { get; set; }
    public string subj_organisation { get; set; }
    public string subj_orgaunit { get; set; }
    public string subj_commonname { get; set; }
    public string subj_email { get; set; }
    public long serialNumber { get; set; }
    public string host_name { get; set; }
    public string host_username { get; set; }
    public string host_password { get; set; }
    public string cert_filename { get; set; }
    public string cert_priv_ext { get; set; }
    public string cert_pub_ext { get; set; }
    public string cert_path { get; set; }
    public int cert_autoupload { get; set; }


    // Wichtig: ToString bestimmt, was in der ListBox angezeigt wird
    public override string ToString()
    {
        return name;
    }
}
