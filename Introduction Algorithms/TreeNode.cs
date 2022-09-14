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
        while (tmp.Value != value)
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
        NodeInfo[] nis = TreeHelperBFS.GetTreeInLine(Root);

        int deep = 0;
        int x = 30;
        bool pair = true;
        int d1 = 5;
        StringBuilder sb = new StringBuilder();
        StringBuilder sb2 = new StringBuilder();

        sb.Append(s(x+8));
        sb2.Append(s(x));

        foreach (NodeInfo n in nis)
        {
            if (n.Depth > deep)
            {
                Console.WriteLine(sb);
                Console.WriteLine(sb2);
                sb.Clear(); sb2.Clear();

                deep = n.Depth;
                //x = x - 6;
                if (x < 1) x = 5;
                sb.Append(s(x));
                sb2.Append(s(x));
                //Console.WriteLine($"          depth = {deep} ");
            }

            if (pair) d1 = 3; else d1 = 12;
            pair = !pair;
            sb.Append(s(12) +  $"   {n.Node.Value}   ");
            sb2.Append(s(12) + $"/     \\ ");



        }
    }

    /// <summary>
    /// Метод возращает string из X символов
    /// </summary>
    /// <param name="x"></param>
    /// <returns></returns>
    string s(int x)
    {
        var separator = new string('.', x);
        return separator;
    }

    public void RemoveItem(int value)
    {
        var tmp = GetNodeByValue(value);
        var tmp_parent = tmp.Parent;
        if (tmp_parent != null)
        {
            if (tmp_parent.LeftChild == tmp) tmp_parent.LeftChild = null;
            if (tmp_parent.RightChild == tmp) tmp_parent.RightChild = null;
            tmp.Root = tmp;
            tmp.Parent = null;

            foreach (NodeInfo ni in TreeHelperBFS.GetTreeInLine(tmp))
            {
                tmp_parent.Insert(ni.Node.Value);
            }
        }
        else tmp.Value = 0;
    }

    public TreeNode Insert(int value)
    {
        if (this.Parent == null && this.Root == null)
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