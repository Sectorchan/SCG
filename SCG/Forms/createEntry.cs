using System.Diagnostics.Eventing.Reader;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.Schema;
using FluentResults;
using PL.Certificate;
using SCG;
using static SCG.CustomMessageBox;

namespace SCG.Forms;
public partial class createEntry : Form
{
    #region Private Member
    private Certificate _certs { get; set; }
    private PL.Utils.Tools.serverType _serverType { get; set; }
    private configType _configType { get; set; }
    private int _step { get; set; }
    #endregion
    public createEntry(Certificate certs, PL.Utils.Tools.serverType serverType, configType configType)
    {
        _configType = configType;
        _serverType = serverType;
        _certs = certs;
        _step = 0;
        InitializeComponent();
    }

    private void createEntry_Load(object sender, EventArgs e)
    {
        BuildElements();
        gb_dn.Visible = false;
    }

    #region Private method
    private void BuildElements()
    {
        switch (_configType)
        {
            case configType.keySize:
                Text = $"Create new {_serverType} entry";
                Size = new Size(555, 555);
                Lb_label.Text = $"Enter the {Convert.ToString(_configType)} for\nthe new {_serverType} entry: {_certs.name}";

                Cb_keySize.Visible = true;
                flowControl.Controls.Add(Lb_label);
                flowControl.Controls.Add(Cb_keySize);
                break;
            case configType.selfSigned:
                
                SelfSigned(1);
                break;
            default:
                break;
        }
        Bt_Panel.Controls.Add(Bt_new);
        Bt_Panel.Controls.Add(Bt_Cancel);
        flowControl.Controls.Add(Bt_Panel);
    }
    private void SelfSigned(int step)
    {
        _step = step;
        if (_step == 1)
        {
            Text = $"Create new self-signed entry";
            Lb_label.Text = $"Enter the certificate duration for the \nself-signed certificate in month:";
            Tb_entries.Visible = true;
            Tb_entries.KeyPress += Tb_entries_KeyPress;
            Bt_new.Click -= Bt_new_onClick;
            Bt_new.Click += Bt_Continue_Click;
            Bt_new.Text = "Continue";

            Bt_Panel.Controls.Add(Bt_new);
            Bt_Panel.Controls.Add(Bt_Cancel);
            flowControl.Controls.Add(Bt_Panel);
            flowControl.Controls.Add(Lb_label);
            flowControl.Controls.Add(Tb_entries);

        }
        else if (_step == 2)
        {
            ClearFlowControl();
            string _name = string.Empty;
            if (_serverType == PL.Utils.Tools.serverType.user)
            { _name = "User"; }
            else
            { _name = "server"; }

            Text = $"Set Distinguished Name for the {_serverType.ToString().ToUpper()} {_name}: {_certs.name}";
            flowControl.Controls.Add(gb_dn);

            gb_dn.Visible = true;

            Bt_Panel.Controls.Add(Bt_new);
            Bt_Panel.Controls.Add(Bt_Cancel);
            flowControl.Controls.Add(Bt_Panel);
            Bt_new.Text = "Finish";
            Bt_Cancel.Text = "Cancel";
            Bt_new.Click -= Bt_Continue_Click;
            Bt_new.Click += Bt_new_onClick;

        }
    }
    private void ClearFlowControl()
    {
        for (int i = 0; i < flowControl.Controls.Count; i++)
        {
            flowControl.Controls.RemoveAt(0);
        }
    }
    private void AddButtons()
    {
        Bt_Panel.Controls.Add(Bt_new);   
        Bt_Panel.Controls.Add(Bt_Cancel);
        flowControl.Controls.Add(Bt_Panel);
    }


    #endregion
    #region Events functions
    private void Tb_entries_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
        { e.Handled = true; }
    }


    private void Bt_new_onClick(object sender, EventArgs e)
    {
        switch (_configType)
        {
            case configType.keySize:
                _certs.keySize = Convert.ToInt32(Cb_keySize.SelectedItem);
                DialogResult = DialogResult.OK;
                break;
            case configType.privKey:
                break;
            case configType.selfSigned:
                Tb_entries.KeyPress -= Tb_entries_KeyPress; //remove Digitcheck

                if (_step == 1)
                {
                    ClearFlowControl();
                    SelfSigned(2);
                }
                else if (_step == 2)
                {
                    Close();
                }
                break;
        }
    }
    private void Bt_Continue_Click(object sender, EventArgs e)
    {
        if (_step < 2)
        {
            _step++;
            SelfSigned(_step);
        }
    }
    private void Bt_Back_Click(object sender, EventArgs e)
    {
        if (_step > 1)
        {
            _step--;
            SelfSigned(_step);
        }
    }
    private void Bt_Cancel_Click(object sender, EventArgs e)
    { DialogResult = DialogResult.Cancel; }

    #endregion



    private void createEntry_FormClosing(object sender, FormClosingEventArgs e)
    {
        int countEmptySan = 0;
        if (_configType == configType.selfSigned)
        {
            if (!(string.IsNullOrWhiteSpace(Convert.ToString(Cb_san1.SelectedItem))) || !(string.IsNullOrWhiteSpace(Tb_san1.Text)))
            { _certs.san1 = $"{Cb_san1.SelectedItem}:{Tb_san1.Text}"; }
            else
            { countEmptySan++; }
            if (!(string.IsNullOrWhiteSpace(Convert.ToString(Cb_san2.SelectedItem))) || !(string.IsNullOrWhiteSpace(Tb_san2.Text)))
            { _certs.san1 = $"{Cb_san2.SelectedItem}:{Tb_san2.Text}"; }
            else
            { countEmptySan++; }
            if (!(string.IsNullOrWhiteSpace(Convert.ToString(Cb_san3.SelectedItem))) || !(string.IsNullOrWhiteSpace(Tb_san3.Text)))
            { _certs.san1 = $"{Cb_san3.SelectedItem}:{Tb_san3.Text}"; }
            else
            { countEmptySan++; }
            if (!(string.IsNullOrWhiteSpace(Convert.ToString(Cb_san4.SelectedItem))) || !(string.IsNullOrWhiteSpace(Tb_san4.Text)))
            { _certs.san1 = $"{Cb_san4.SelectedItem}:{Tb_san4.Text}"; }
            else
            { countEmptySan++; }
            if (countEmptySan != 0)
            {
                CustomDialogResult dialogResult = CustomMessageBox.Show($"Not all fields are filled for complete\nSubject alternative names\nProceed to close?", "Warning", MessageBoxIcon.Stop, CustomMessageBox.OkCan_buttons);
                if (dialogResult == CustomDialogResult.Cancel)
                {
                    e.Cancel = true; // Cancel the form closing
                }
                else
                {
                    _certs.ss_duration = Convert.ToInt32(Tb_entries.Text);
                    _certs.subj_country = tb_sub_c.Text;
                    _certs.subj_state = tb_sub_st.Text;
                    _certs.subj_location = tb_sub_loc.Text;
                    _certs.subj_orgaunit = tb_sub_ou.Text;
                    _certs.subj_orgaunit = tb_sub_orga.Text;
                    _certs.subj_commonname = tb_sub_cn.Text;
                    _certs.subj_email = tb_sub_email.Text;
                    DialogResult = DialogResult.OK;
                    e.Cancel = false;
                }
            }
            Dictionary<string, DialogResult> buttons = new Dictionary<string, DialogResult>
            {
                { "Option 11", DialogResult.OK },
                { "Option 22", DialogResult.Cancel },
                { "Abbrechen33", DialogResult.Abort }
            };

            //            CustomMessageBox.Show("message") 

            //DialogResult result = CustomMessageBox.Show($"Not all fields are filled for complete\nSubject alternative names\nProceed to close?", $"Warning", "Yes", "No", MessageBoxIcon.Warning);
            //if (result == DialogResult.OK)
            //{
            //    string s = "";
            //}
            //else
            //{
            //    string sd = "";
            //}
            //if (countEmptySan != 0)
            //{

            //    DialogResult dialogResult = MessageBox.Show($"Not all fields are filled for complete\nSubject alternative names\nProceed?", "WARNING", MessageBoxButtons.RetryCancel, MessageBoxIcon.Question);
            //    if (dialogResult == DialogResult.Retry)
            //    {
            //        e.Cancel = true; // Cancel the form closing
            //    }
            //    else
            //    {
            //        _certs.ss_duration = Convert.ToInt32(Tb_entries.Text);
            //        _certs.subj_country = tb_sub_c.Text;
            //        _certs.subj_state = tb_sub_st.Text;
            //        _certs.subj_location = tb_sub_loc.Text;
            //        _certs.subj_orgaunit = tb_sub_ou.Text;
            //        _certs.subj_orgaunit = tb_sub_orga.Text;
            //        _certs.subj_commonname = tb_sub_cn.Text;
            //        _certs.subj_email = tb_sub_email.Text;

            //        _certs.san1 = $"{Cb_san1.SelectedItem}:{Tb_san1.Text}";
            //        _certs.san2 = $"{Cb_san2.SelectedItem}:{Tb_san2.Text}";
            //        _certs.san3 = $"{Cb_san3.SelectedItem}:{Tb_san3.Text}";
            //        _certs.san4 = $"{Cb_san4.SelectedItem}:{Tb_san4.Text}";

            //        DialogResult = DialogResult.OK;
            //        e.Cancel = false;

            //    }
            //}

        }

    }

    #region Enums
    public enum configType
    {
        keySize,
        privKey,
        selfSigned,
        DNBuilder
    }

    private enum mboxButtonText
    {
        Retry,
        Continue
    }
}
#endregion
