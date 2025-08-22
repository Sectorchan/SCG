using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCG.Forms;
using static PL.Utils.Tools;

namespace PL.Certificate;
//[DebuggerDisplay("ID = {id}, Name = {name}")]

public class Certificate
{
    public int id { get; set; }
    public string name { get; set; }
    public int keySize { get; set; }
    public string private_key { get; set; }
    public string private_createDT { get; set; }
    public string public_cert { get; set; }
    public string public_createDT { get; set; }
    public byte[] ss_cert { get; set; }
    public string ss_createDT { get; set; }
    public string signed_against { get; set; }
    public string signed_createDT { get; set; }
    private int _ss_duration;
    public int ss_duration
    {
        get => _ss_duration;
        set
        {
            _ss_duration = value;
        }
    }
    //public int ss_duration { get; set; }
    public string subj_country { get; set; }
    public string subj_state { get; set; }
    public string subj_location { get; set; }
    public string subj_organisation { get; set; }
    public string subj_orgaunit { get; set; }
    public string subj_commonname { get; set; }
    public string subj_email { get; set; }
    public long serialNumber { get; set; }
    public string cert_priv_filename { get; set; }
    public string cert_priv_fileext { get; set; }
    public string cert_priv_path { get; set; }
    public string cert_pub_filename { get; set; }
    public string cert_pub_fileext { get; set; }
    public string cert_pub_path { get; set; }
    public string cert_signed_filename { get; set; }
    public string cert_signed_fileext { get; set; }
    public string cert_signed_path { get; set; }
    public long length { get; set; }
    public string host_name { get; set; }
    public string host_username { get; set; }
    public string host_password { get; set; }
    public int cert_autoupload { get; set; }
    public string san1 { get; set; }
    public string san2 { get; set; }
    public string san3 { get; set; }
    public string san4 { get; set; }

    public static Certificate GetSelectedCert(Server form, serverType type)
    {
        ListBox listBox = type switch
        {
            serverType.ca => form.lb_ca_certs,
            serverType.intermediate => form.lb_int_certs,
            serverType.server => form.lb_server_certs,
            serverType.user => form.lb_user_certs,
            _ => null
        };

        return listBox.SelectedItem as Certificate;
    }
}
