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
        var passed = new HashSet<Node>();   // Здесь помещаем те ноды по которым информация уже выведена -  волна уже прошла
        var q = new Queue<Node>();  // Основная очередь -  фронт волны

        var n = start_node;

        while (n != null)
        {
            passed.Add(n);
            Console.WriteLine($" V={n.Value}  ");
            List<Edge> edges = n.Edges;
            foreach (Edge e in edges)
            {
                Console.Write($" w={e.Weight}  to  node {e.N.Value} ");
                if (!passed.Contains(e.N))      //  т.е. по алгоритму волны - если нода ещё не пройдена , то помещаем в фронт волны
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
        var passed = new HashSet<Node>();  // Здесь помещаем те ноды по которым информация уже выведена

        var stack = new Stack<Node>();      // Используем для следующего шага - что бы уйти вглубь
        var que = new Queue<Node>();        // Очередь нодов , в которые не пошли при первом проходе. Когда закончатся ноды в стэке (т.е. в глубине) - вернёмся сюда
        que.Enqueue(start_node);
        Node tmp;

        while (que.Count > 0 || stack.Count > 0)
        {
            if (stack.Count > 0) tmp = stack.Pop();     // вначале идём вглубину
            else tmp = que.Dequeue();       // если нету нодов вглубине - возвращаемся сюда 

            List<Edge> edges = tmp.Edges;
            passed.Add(tmp);

            Console.WriteLine($" Node   {tmp.Value}  ");


            if (edges.Count == 1)       
            {
                Console.Write($" Node   {tmp.Value}  лист, далее Edges нету");
            }
            else if (edges.Count > 1)
            {

                if (!passed.Contains(edges.First().N))  // выбор следующей ноды в глубину - просто беру First из Edges
                {
                    stack.Push(edges.First().N);
                    passed.Add(edges.First().N);
                }

                foreach (Edge e in edges)
                {
                    Console.Write($" Edge weight  {e.Weight}  to node {e.N.Value} ;  ");    // для текущей ноды перечислим все пути, их вес и ноды куда ведут эти пути
                    if (e.N != edges.First().N && !passed.Contains(e.N)) { que.Enqueue(e.N); passed.Add(e.N); }
                }
            }
            Console.WriteLine(" ");
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
