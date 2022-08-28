using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introduction_Algorithms;

internal class Tests
{

    public void TestNodeClass()
    {
        int[] ints = new int[15];
        Random rnd = new Random();

        Node l = new Node(1);

        for (int i = 0; i < 15; i++)
        {
            ints[i] = rnd.Next(100);
             l.AddNode(ints[i]);
        }

        Node N2 = l.FindNode(ints[3]);
        l.AddNodeAfter(N2, 150);
        Console.WriteLine(l.GetCount());
        l.RemoveNode(N2);
        l.RemoveNode(4);


    }

    public void Test_binary_search()
    {
        int[] ints = new int[30];
        Random rnd = new Random();
        for (int i = 0; i < 30; i++)
        {
            ints[i] = rnd.Next(100);
        }

        int x1;

        x1 = 8;
        int x2 = Algorithms.BinarySearch(ints, ints[x1]);
        Console.WriteLine($" x1={x1}  binary search index: {x2}");

        x1 = 14;
        x2 = Algorithms.BinarySearch(ints, ints[x1]);
        Console.WriteLine($" x1={x1}  binary search index: {x2}");

        x1 = 27;
        x2 = Algorithms.BinarySearch(ints, ints[x1]);
        Console.WriteLine($" x1={x1}  binary search index: {x2}");

    }


}
