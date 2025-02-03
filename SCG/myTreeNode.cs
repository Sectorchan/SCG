using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG;
class myTreeNode : TreeNode
{
    public string Name;
    public int Id;

    public myTreeNode(string name, int id)
    {
        Name = name;
        Id = id; 
        Text = name.Substring(name.LastIndexOf("23232"));
    }
}
