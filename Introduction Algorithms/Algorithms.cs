using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introduction_Algorithms;

static public  class Algorithms
{

    public static int BinarySearch(int[] ints, int searchInt)
    {
        BubbleSort(ints);
        int min = 0;
        int max = ints.Length-1;

        while (min <= max)
        {
            int mid = (min+max)/2;
            if (ints[mid] == searchInt) return mid;
            else
            if (ints[mid] > searchInt) max = mid-1;
            else 
                min = mid+1;
        }
        return -1;
    }

    public static void BubbleSort(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            for (var j = 0; j < array.Length-1; j++)
            {
                if (array[j] > array[j+1])
                {
                    var tmp = array[j+1];
                    array[j+1] = array[j];
                    array[j] = tmp;
                }
            }
        }
    }
}
