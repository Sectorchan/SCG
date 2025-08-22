using System.Data;

namespace SCG;
public class CustomMessageBox : Form
{
    #region Private Member
    private Label _lb_message;
    private FlowLayoutPanel _Flp_buttonPanel;
    private PictureBox _Pb_iconBox;

    private DialogResult _result = DialogResult.None;
    private CustomDialogResult _customResult = CustomDialogResult.None;
    private Dictionary<string, DialogResult> _buttonResults = new Dictionary<string, DialogResult>();
    public static Dictionary<string, CustomDialogResult> OkCan_buttons = new Dictionary<string, CustomDialogResult>
        {
            { "OK", CustomDialogResult.OK },
            { "Cancel", CustomDialogResult.Cancel }
        };
    public static Dictionary<string, CustomDialogResult> ConBackCan_buttons = new Dictionary<string, CustomDialogResult>
        {
            { "Continue", CustomDialogResult.Continue },
            { "Back", CustomDialogResult.Back },
            { "Cancel", CustomDialogResult.Cancel }
        };
    #endregion
    /// <summary>
    /// Custom Messagebox with default Buttons.
    /// </summary>
    /// <param name="message"></param>
    /// <param name="buttonTexts"></param>
    /// <param name="icon"></param>
    private CustomMessageBox(string message, string caption, string[] buttonTexts, MessageBoxIcon icon = MessageBoxIcon.None)
    {
        Text = caption;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        StartPosition = FormStartPosition.CenterScreen;
        MaximizeBox = false;
        MinimizeBox = false;
        AutoSize = true;
        AutoSizeMode = AutoSizeMode.GrowAndShrink;
        Padding = new Padding(5);

        var layout = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            AutoSize = true,
            ColumnCount = 2
        };
        Controls.Add(layout);

        _Pb_iconBox = new PictureBox
        {
            Size = new Size(32, 32),
            Margin = new Padding(5),
            SizeMode = PictureBoxSizeMode.CenterImage
        };
        switch (icon)
        {
            case MessageBoxIcon.Information:
                _Pb_iconBox.Image = SystemIcons.Information.ToBitmap();
                break;
            case MessageBoxIcon.Warning:
                _Pb_iconBox.Image = SystemIcons.Warning.ToBitmap();
                break;
            case MessageBoxIcon.Error:
                _Pb_iconBox.Image = SystemIcons.Error.ToBitmap();
                break;
            case MessageBoxIcon.Question:
                _Pb_iconBox.Image = SystemIcons.Question.ToBitmap();
                break;
            default:
                _Pb_iconBox.Visible = false;
                break;
        }
        layout.Controls.Add(_Pb_iconBox, 0, 0);

        _lb_message = new Label
        {
            Text = message,
            AutoSize = true,
            MaximumSize = new Size(400, 0),
            Margin = new Padding(10, 10, 10, 20)
        };
        layout.Controls.Add(_lb_message, 1, 0);

        _lb_message.MaximumSize = Size;

        // Buttons
        _Flp_buttonPanel = new FlowLayoutPanel
        {
            FlowDirection = FlowDirection.RightToLeft,
            Dock = DockStyle.Fill,
            AutoSize = true
        };
        layout.SetColumnSpan(_Flp_buttonPanel, 2);
        layout.Controls.Add(_Flp_buttonPanel, 0, 1);

        foreach (var (text, index) in buttonTexts.Select((t, i) => (t, i)))
        {
            var btn = new Button
            {
                Text = text,
                AutoSize = true,
                Margin = new Padding(5)
            };

            // Standard-DialogResult für ersten Button = OK, Rest = Cancel
            if (index == 0)
                btn.DialogResult = DialogResult.OK;
            else
                btn.DialogResult = DialogResult.Cancel;

            btn.Click += (s, e) =>
            {
                _result = btn.DialogResult;
                Close();
            };

            _Flp_buttonPanel.Controls.Add(btn);
        }
    }
    /// <summary>
    /// Custom Messagebox with CustomButtons in order to make use the CustomDialogResult enum.
    /// Make sure to use the CustomButton class!
    /// </summary>
    /// <param name="message"></param>
    /// <param name="_buttonResults"></param>
    /// <param name="icon"></param>
    private CustomMessageBox(string message, string caption, Dictionary<string, CustomDialogResult> _buttonResults, MessageBoxIcon icon = MessageBoxIcon.None)
    {
        Text = caption;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        StartPosition = FormStartPosition.CenterScreen;
        MaximizeBox = false;
        MinimizeBox = false;
        AutoSize = true;
        AutoSizeMode = AutoSizeMode.GrowAndShrink;
        Padding = new Padding(5);
        MaximumSize = new Size(Screen.FromControl(this).WorkingArea.Size.Width, Screen.FromControl(this).WorkingArea.Size.Height);

        var layout = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            AutoSize = true,
            ColumnCount = 2
        };
        Controls.Add(layout);

        _Pb_iconBox = new PictureBox
        {
            Size = new Size(32, 32),
            Margin = new Padding(5),
            SizeMode = PictureBoxSizeMode.CenterImage
        };
        switch (icon)
        {
            case MessageBoxIcon.Information:
                _Pb_iconBox.Image = SystemIcons.Information.ToBitmap();
                break;
            case MessageBoxIcon.Warning:
                _Pb_iconBox.Image = SystemIcons.Warning.ToBitmap();
                break;
            case MessageBoxIcon.Error:
                _Pb_iconBox.Image = SystemIcons.Error.ToBitmap();
                break;
            case MessageBoxIcon.Question:
                _Pb_iconBox.Image = SystemIcons.Question.ToBitmap();
                break;
            default:
                _Pb_iconBox.Visible = false;
                break;
        }
        layout.Controls.Add(_Pb_iconBox, 0, 0);

        _lb_message = new Label
        {
            Text = message,
            AutoSize = true,
            MaximumSize = new Size(400, 0), // Text umbrechen ab 400px Breite
            Margin = new Padding(10, 10, 10, 20)
        };
        layout.Controls.Add(_lb_message, 1, 0);



        // CustomButtons
        _Flp_buttonPanel = new FlowLayoutPanel
        {
            FlowDirection = FlowDirection.RightToLeft,
            Dock = DockStyle.Fill,
            AutoSize = true
        };
        layout.SetColumnSpan(_Flp_buttonPanel, 2);
        layout.Controls.Add(_Flp_buttonPanel, 0, 1);


        foreach (var element in _buttonResults)
        {
            var btn = new CustomButton
            {
                Text = element.Key,
                AutoSize = true,
                Margin = new Padding(5),
                _customDialogResult = element.Value,
            };

            btn.Click += (s, e) =>
            {
                _customResult = btn._customDialogResult;
                Close();
            };
            //int hh = _Flp_buttonPanel.Height;
            //int ww = _Flp_buttonPanel.Width;
            _Flp_buttonPanel.Controls.Add(btn);
            //hh = _Flp_buttonPanel.Height;
            //ww = _Flp_buttonPanel.Width;

        }
    }
    public enum CustomDialogResult
    {
        None = DialogResult.None,
        OK = DialogResult.OK,
        Cancel = DialogResult.Cancel,
        Yes = DialogResult.Yes,
        No = DialogResult.No,
        // eigene Erweiterungen
        RetryCustom = 100,
        SomethingElse = 101,
        Continue = 102,
        Back = 103
    }
    //public static DialogResult Show(string message, params string[] buttons)
    //{
    //    return Show(message, MessageBoxIcon.None, buttons);
    //}

    public static DialogResult Show(string message, string caption, MessageBoxIcon icon, Dictionary<string, DialogResult> _buttonResult)
    {

        if (_buttonResult == null || _buttonResult.Count == 0)
        {
            _buttonResult = new Dictionary<string, DialogResult>
            {
                { "OK", DialogResult.OK }
            };
        }
        using (var msgBox = new CustomMessageBox(message, caption, ["sd", "3"], icon))
        {
            msgBox.ShowDialog();
            return msgBox._result;
        }
    }
    public static CustomDialogResult Show(string message, string caption, MessageBoxIcon icon, Dictionary<string, CustomDialogResult> _buttonResult = null)
    {

        if (_buttonResult == null || _buttonResult.Count == 0)
        {
            _buttonResult = new Dictionary<string, CustomDialogResult>
            {
                { "OK", CustomDialogResult.OK }
            };
        }
        using (var msgBox = new CustomMessageBox(message, caption, _buttonResult, icon))
        {
            msgBox.ShowDialog();
            return msgBox._customResult;
        }
    }
    public static DialogResult Show(string message, string caption, MessageBoxIcon icon, params string[] buttons)
    {
        if (buttons == null || buttons.Length == 0)
        {
            buttons = new[] {
                "OK"
            };
        }
        using (var msgBox = new CustomMessageBox(message, caption, buttons, icon))
        {
            msgBox.ShowDialog();
            return msgBox._result;
        }
    }
}
