using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introduction_Algorithms;

public class TreeNode : ITree
{
    public int Value { get; set; }
    public TreeNode? LeftChild { get; set; }
    public TreeNode? RightChild { get; set; }
    public TreeNode? Parent { get; set; }
    public TreeNode? Root { get; set; }

    public void AddItem(int value)
    {
        Insert(value);
    }

    public override bool Equals(object obj)
    {
        var node = obj as TreeNode;
        if (node == null)
            return false;
        return node.Value == Value;
    }

    public TreeNode GetNodeByValue(int value)
    {
        var tmp = Root;
        while (tmp.Value != value  )
        {
            if (value > tmp.Value)
            {
                if (tmp.RightChild != null)
                {
                    tmp = tmp.RightChild;
                    continue;
                }
            }
            else if (value < tmp.Value)
            {
                if (tmp.LeftChild != null)
                {
                    tmp = tmp.RightChild;
                    continue;
                }
            }
            else
            {
                throw new Exception($" значение {value} не содержится в дереве"); //                 Дерево построено неправильно
            }
        }
        return tmp;
    }

    public TreeNode GetRoot()
    {
        return Root;
    }

    public void PrintTree()
    {
        //PreOrderTravers(Root);
        //var ni = new NodeInfo();

        foreach (NodeInfo ni in TreeHelper.GetTreeInLine(this))
        {
            Console.WriteLine($" dep = {ni.Depth} , on val = {ni.Node.Value}");
        }

        NodeInfo[] nodeInfos = TreeHelper.GetTreeInLine(this);


    }
    public void PreOrderTravers(TreeNode root)
    {
        if (root != null)
        {
            Console.WriteLine($"                 {root.Value}              " );

            Console.WriteLine($"             ___                           ");
            PreOrderTravers(root.LeftChild);
            Console.WriteLine($"                             ___           ");
            PreOrderTravers(root.RightChild);
        }
    }

    public void RemoveItem(int value)
    {
        var tmp = GetNodeByValue(value);
        var tmp_parent    = tmp.Parent;
        if (tmp_parent != null)
        {
            if (tmp_parent.LeftChild == tmp) tmp_parent.LeftChild = null;
            if (tmp_parent.RightChild == tmp) tmp_parent.RightChild = null;
            tmp.Root = tmp;
            tmp.Parent = null;

            foreach (NodeInfo ni in TreeHelper.GetTreeInLine(tmp))
            {
                tmp_parent.Insert(ni.Node.Value);
            }
        }
        else tmp.Value = 0;
    }

    public TreeNode Insert( int value)
    {
        if (this.Parent == null && this.Root==null)
        {
            Value = value;
            Root = this;
            return this;
        }

        TreeNode tmp = this.Root;
        while (tmp != null)
        {
            if (value > tmp.Value)
            {
                if (tmp.RightChild != null)
                {
                    tmp = tmp.RightChild;
                    continue;
                }
                else
                {
                    var new_node = new TreeNode();
                    new_node.Value = value;
                    new_node.Parent = tmp;
                    new_node.Root = this.Root;
                    tmp.RightChild = new_node;
                    return new_node;
                }
            }
            else if (value < tmp.Value)
            {
                if (tmp.LeftChild != null)
                {
                    tmp = tmp.LeftChild;
                    continue;
                }
                else
                {
                    var new_node = new TreeNode();
                    new_node.Value = value;
                    new_node.Parent = tmp;
                    new_node.Root = this.Root;
                    tmp.LeftChild = new_node;
                    return new_node;
                }
            }
            else
            {
                //Console.WriteLine($"value {value} already exists in tree"); //                 Дерево построено неправильно
                return null;
            }
        }
        return null;
    }


}