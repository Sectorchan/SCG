using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG;
public class TreeViewHelper
{
    // Methode zum Durchsuchen des TreeView nach einem Knoten mit einem bestimmten Namen
    public static TreeNode FindNode(TreeNodeCollection nodes, string name)
    {
        foreach (TreeNode node in nodes)
        {
            if (node.Text == name) // Vergleiche den Namen
            {
                return node; // Passenden Knoten gefunden
            }

            // Rekursiv die untergeordneten Knoten durchsuchen
            TreeNode foundNode = FindNode(node.Nodes, name);
            if (foundNode != null)
            {
                return foundNode;
            }
        }
        return null; // Kein passender Knoten gefunden
    }

    // Methode zum Hinzufügen eines neuen Eintrags zu einem bestimmten Knoten
    public static void AddNode(TreeView treeView, string parentName, string newNodeText)
    {
        TreeNode parentNode = FindNode(treeView.Nodes, parentName);
        if (parentNode != null)
        {
            // Neuen Knoten zu den untergeordneten Knoten des gefundenen Knotens hinzufügen
            parentNode.Nodes.Add(new TreeNode(newNodeText));
            parentNode.Expand(); // Optional: Knoten aufklappen
        }
        else
        {
            MessageBox.Show($"Knoten mit dem Namen '{parentName}' wurde nicht gefunden.");
        }
    }
}
