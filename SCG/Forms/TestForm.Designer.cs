namespace SCG.Forms;

partial class TestForm
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        flow = new FlowLayoutPanel();
        label1 = new Label();
        label2 = new Label();
        textBox1 = new TextBox();
        textBox2 = new TextBox();
        SuspendLayout();
        // 
        // flow
        // 
        flow.AutoSize = true;
        flow.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        flow.Location = new Point(51, 31);
        flow.Name = "flow";
        flow.Size = new Size(0, 0);
        flow.TabIndex = 0;
        flow.ControlAdded += flow_ControlAdded;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(301, 59);
        label1.Name = "label1";
        label1.Size = new Size(38, 15);
        label1.TabIndex = 1;
        label1.Text = "label1";
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(301, 97);
        label2.Name = "label2";
        label2.Size = new Size(38, 15);
        label2.TabIndex = 2;
        label2.Text = "label2";
        // 
        // textBox1
        // 
        textBox1.Location = new Point(442, 76);
        textBox1.Name = "textBox1";
        textBox1.Size = new Size(100, 23);
        textBox1.TabIndex = 3;
        // 
        // textBox2
        // 
        textBox2.Location = new Point(434, 148);
        textBox2.Name = "textBox2";
        textBox2.Size = new Size(100, 23);
        textBox2.TabIndex = 4;
        // 
        // TestForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(textBox2);
        Controls.Add(textBox1);
        Controls.Add(label2);
        Controls.Add(label1);
        Controls.Add(flow);
        Name = "TestForm";
        Text = "TestForm";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private FlowLayoutPanel flow;
    private Label label1;
    private Label label2;
    private TextBox textBox1;
    private TextBox textBox2;
}