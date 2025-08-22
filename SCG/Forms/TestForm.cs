using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SCG.Forms;
public partial class TestForm : Form
{
    public TestForm()
    {

        InitializeComponent();
        flow.Width = 3;
        flow.Controls.Add(label1);
        flow.Controls.Add(textBox1);
        flow.Controls.Add(label2);
        flow.Controls.Add(textBox2);
    }

    private void flow_ControlAdded(object sender, ControlEventArgs e)
    {
        int sort = 2;
        int idx = flow.Controls.IndexOf(e.Control);
        bool breakAfter = ((idx + 1) % sort == 0);
        flow.SetFlowBreak(e.Control, breakAfter);
        e.Control.Margin = new Padding(5);

    }
}
