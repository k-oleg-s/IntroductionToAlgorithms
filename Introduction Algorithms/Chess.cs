﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introduction_Algorithms;

static public  class Chess
{
    static public  void Task()
    {
        const int N = 4;
        const int M = 4;

        int[,] A = new int[N, M];
        int i, j;
        for (j = 0; j < M; j++)
            A[0, j] = 1; // Первая строка заполнена единицами
        for (i = 1; i < N; i++)
        {
            A[i, 0] = 1;
            for (j = 1; j < M; j++)
                A[i, j] = A[i, j - 1] + A[i - 1, j];
        }
        Print2(N, M, A);
    }

    static void Print2(int n, int m, int[,] a)
    {
        int i, j;
        for (i = 0; i < n; i++)
        {
            for (j = 0; j < m; j++)
                Console.Write($"{a[i, j]}  ");
            Console.Write("\r\n");
        }
    }

}
