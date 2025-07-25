using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PL.Utils.Tools;

namespace SCG;
public class CustomButton : Button
{
    public certType _certType { get; set; }
    public serverType _serverType { get; set; }
    public fdqnType _fqdnType { get; set; }
    public info _certInfo { get; set; }
    

    public event EventHandler<CustomClickEventArgs>? CustomClick;

    protected override void OnClick(EventArgs e)
    {
        base.OnClick(e);  // ruft die normalen Click-Handler auf
        CustomClick?.Invoke(this, new CustomClickEventArgs(_certType, _serverType, _fqdnType, _certInfo));
    }
    public CustomButton()
    {
        Width = 75;
        Height = 23;
        Name = "Bt_";
        Text = "Button";
    }
}
public class CustomClickEventArgs : EventArgs
{
    public certType CertType { get; }
    public serverType ServerType { get; }
    public fdqnType FqdnType { get; }
    public info CertInfo { get; }

    public CustomClickEventArgs(certType certType, serverType serverType, fdqnType fqdnType, info certInfo)
    {
        CertType = certType;
        ServerType = serverType;
        FqdnType = fqdnType;
        CertInfo = certInfo;
    }
}

