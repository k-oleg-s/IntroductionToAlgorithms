using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introduction_Algorithms;


public static class TreeHelper
{
    public static void GoDFS(TreeNode tree)
    {
        var quP = new Queue<TreeNode>(); // нода 
        var quDeep = new Queue<int>();  // глубина ноды

        int deep = 1;
        var n = tree.Root;
        quP.Enqueue(n);
        quDeep.Enqueue(deep);

        while (quP.Count > 0)
        {
            n = quP.Dequeue();
            deep = quDeep.Dequeue();

            Console.WriteLine($"deep : {deep}   parent={n.Parent?.Value ?? .0}  v={n.Value}  ");

            // Если node пошёл в право - то только добавим его в очередь , без вывода инфы на консоль.
            if (n.RightChild != null) { quP.Enqueue(n.RightChild); quDeep.Enqueue(deep+1); }

            // Если node пошёл влево, выводим данные на экран, попутно "запоминая" ноды справа, без вывода инфы на консоль.
            while (n.LeftChild != null)
            {
                deep++;
                var tmp = n.LeftChild;
                if (tmp.RightChild != null) { quP.Enqueue(tmp.RightChild); quDeep.Enqueue(deep+1); }
                Console.WriteLine($"deep : {deep}   parent={tmp.Parent?.Value ?? .0}  v={tmp.Value}  ");
                n = tmp;

            }
        }
    }

    public static void GoBFS(TreeNode tree)
    {
        // обрабатываем по принципу волны. Волна идёт вниз по дереву.
        var quP = new Queue<TreeNode>(); // это фронт волны , для этих нод выводим инфу на консоль 
        var quN = new Queue<TreeNode>(); // это "следующий" фронт волны.

        int deep = 1;
        var n = tree.Root;
        quP.Enqueue(n);

        while (quP.Count > 0)
        {
            Console.Write($"deep : {deep}  ");
            foreach (var q in quP)
            {
                Console.Write($"  parent={q.Parent?.Value ?? .0}  v={q.Value}  ");
                if (q.LeftChild != null) quN.Enqueue(q.LeftChild);
                if (q.RightChild != null) quN.Enqueue(q.RightChild);
            }
            Console.WriteLine("  ");

            quP = new Queue<TreeNode>(quN);
            quN.Clear();

            deep++;
        }
    }

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
                    Node = new TreeNode() { Value = 0 },
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

    public static string s(int x)
    {
        var separator = new string('.', x);
        return separator;
    }
}