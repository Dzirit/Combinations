using System;
using System.Collections.Generic;
using System.Linq;

namespace Combinations
{
    class Program
    {
        static int Print_num = 1;
        static void Main(string[] args)
        {
            int n =3;
            int m=6;
            int[] a;
            int h = n > m ? n : m; // размер массива а выбирается как max(n,m)
            a = new int[h];
            for (int i = 0; i < h; i++)
            {
                a[i] = 1;
            }
            Print(a, m);
            while (NextSet(a, n, m))
            {
                Print(a, m);
            }
        }
        private static void Print(int[] a, int n)
        {
            Console.Write($"{ Print_num++}:  ");
            for (int i = 0; i < n; i++)
            {
                Console.Write($"{a[i]} ");
            }
            Console.WriteLine();
        }

        private static bool NextSet(int[] a, int n, int m)
        {
            int j = m - 1;
            while (j >= 0 && a[j] == n)
            {
                j--;
            }
            if (j < 0)
            {
                return false;
            }
            if (a[j] >= n)
            {
                j--;
            }
            a[j]++;
            if (j == m - 1)
            {
                return true;
            }
            for (int k = j + 1; k < m; k++)
            {
                a[k] = 1;
            }
            return true;
        }

    }
}
