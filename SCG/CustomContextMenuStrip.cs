using System;
using System.Windows.Forms;
using static PL.Utils.Tools;

namespace SCG
{
    public class CustomContextMenuStrip : ContextMenuStrip
    {
        public Action<ToolStripItem, EventArgs> CustomItemClicked { get; set; }

        public CustomContextMenuStrip()
        {
            this.ItemClicked += OnItemClicked;
        }

        private void OnItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            CustomItemClicked?.Invoke(e.ClickedItem, e);
        }
    }


    
}
