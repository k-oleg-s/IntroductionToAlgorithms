using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introduction_Algorithms;

static public class Algorithms
{
    static public string SimpleNumber(int n)
    {
        int d = 0;
        for (int i = 2; i < n; i++)
        {
            if (n % i == 0) d++;
        }
        if (d == 0) { Console.WriteLine($" {n} простое"); return "y"; }
        else { Console.WriteLine($" {n} НЕ простое"); return "n"; }
    }

    static int StrangeSum(int[] inputArray)   // O(n^3)
    {
        int sum = 0;
        for (int i = 0; i < inputArray.Length; i++) // n
        {
            for (int j = 0; j < inputArray.Length; j++) // n*n
            {
                for (int k = 0; k < inputArray.Length; k++)          // n*n*n              
                {
                    int y = 0;
                    if (j != 0)
                    {
                        y = k / j;
                    }
                    sum += inputArray[i] + i + k + j + y;
                }
            }
        }
        return sum;
    }

    static public int F_cycle(int n)
    {
        if (n == 0) return 0;
        if (n == 1) return 1;

        int prev1 = 1;
        int prev2 = 1;
        int current = 1;

        for (int i = 2; i <= n; i++)
        {
            if (i==2)
            {
                prev2 = 0; prev1 = 1;
            }
            current = prev2 + prev1;
            prev2 = prev1;
            prev1 = current;
        }
        return current;
    }

    static public int F_recurse(int n)
    {
        if (n == 0) return 0;
        if (n == 1) return 1;

        return F_recurse(n-2)+F_recurse(n-1);
    }
}
