using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introduction_Algorithms;

public class Graf
{
    public void GoGraphBFS(Node start_node)
    {
        var passed = new HashSet<Node>();
        var front = new HashSet<Node>();
        var in_front = new HashSet<Node>();
        var q = new Queue<Node>();

        var n = start_node;

         while (n != null)
        {
            passed.Add(n);
            Console.WriteLine($" V={n.Value}  ");
            List<Edge> edges = n.Edges;
            foreach (Edge e in edges)
            {
                    Console.Write($" w={e.Weight}  to  node {e.N.Value} ");
                if (!passed.Contains(e.N))
                {
                    q.Enqueue(e.N);
                    passed.Add(e.N);
                }
            }
            if (q.Count > 0) n = q.Dequeue(); else n = null;
            Console.WriteLine(" ");
         }
    }

    public void GoGraphDFS(Node start_node)
    {
        var passed = new HashSet<Node>();
        var front = new List<Node>();
        var in_front = new List<Node>();

        var q = new Queue<Node>();

        front.Add(start_node);
        passed.Add(start_node);


        while (front.Count > 0)
        {
            foreach (Node n in front)
            {
                passed.Add(n);
                Console.WriteLine($" V={n.Value}  ");
                List<Edge> edges = n.Edges;
                foreach (Edge e in edges)
                {
                    Console.Write($" w={e.Weight}  to  node {e.N.Value} ");
                }
            }
            front = GetNewFront(front, passed);
        }
    }

    private List<Node> GetNewFront(List<Node> nodes, HashSet<Node> passed)
    {
        List<Node> new_nodes = new List<Node>();

        foreach (Node n in nodes)
        {
            if (!passed.Contains(n))
            {
                new_nodes.Add(n);
                passed.Add(n);
            }
        }

        return new_nodes;
    }

    public Node AddNode(Node node, int val, int wght)
    {
        var newNode = new Node()
        {
            Value = val,
            Edges = new List<Edge>()
            {
                new Edge() { N=node, Weight=wght },
            }

        };

        var newEdge = new Edge()
        {
            N = newNode,
            Weight = wght
        };

        if (node.Edges == null)
        {
            node.Edges = new List<Edge>();
        }
        node.Edges.Add(newEdge);

        return newNode;
    }
}
