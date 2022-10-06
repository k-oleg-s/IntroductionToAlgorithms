using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introduction_Algorithms;

internal class Sort
{
    public  int[] BucketSort(int[] A)
    {

        double avg = A.Average();

        var l1 = new List<int>();
        var l2 = new List<int>();

        foreach(int i in A)
        {
            if (i>=avg) l2.Add(i); else l1.Add(i);
        }
        if (l1.Count > 1) l1 = BucketSort(l1.ToArray()).ToList();
        if (l2.Count > 1) l2 = BucketSort(l2.ToArray()).ToList();

        return l1.Concat(l2).ToArray();
    }
}
