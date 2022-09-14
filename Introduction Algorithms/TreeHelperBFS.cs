using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introduction_Algorithms;


public static class TreeHelperBFS
{
    public static NodeInfo[] GetTreeInLine(ITree tree)
    {
        var bufer = new Queue<NodeInfo>();
        var returnArray = new List<NodeInfo>();
        var root = new NodeInfo() { Node = tree.GetRoot() };
        bufer.Enqueue(root);
        while (bufer.Count != 0)
        {
            var element = bufer.Dequeue();
            returnArray.Add(element);
            var depth = element.Depth + 1;

            if (element.Node.LeftChild != null)
            {
                var left = new NodeInfo()
                {
                    Node = element.Node.LeftChild,
                    Depth = depth,
                };
                bufer.Enqueue(left);
            }

            if (element.Node.LeftChild == null && element.Node.RightChild != null)
            {
                var left = new NodeInfo()
                {
                    Node = new TreeNode() { Value=0},
                    Depth = depth,
                };
                bufer.Enqueue(left);
            }

            if (element.Node.RightChild != null)
            {
                var right = new NodeInfo()
                {
                    Node = element.Node.RightChild,
                    Depth = depth,
                };
                bufer.Enqueue(right);
            }
            if (element.Node.RightChild == null && element.Node.LeftChild != null)
            {
                var right = new NodeInfo()
                {
                    Node = new TreeNode() { Value = 0 },
                    Depth = depth,
                };
                bufer.Enqueue(right);
            }
        }
        return returnArray.ToArray();
    }

    public static  string s(int x)
    {
        var separator = new string('.', x);
        return separator;
    }
}