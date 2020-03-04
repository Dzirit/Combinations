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
            Console.Read();
            Console.Read();
            

        }
        private static void Print(int[] a, int n)
        {
            //C++ TO C# CONVERTER NOTE: This static local variable declaration (not allowed in C#) has been moved just prior to the method:
            //  static int num = 1;
            Console.Write("{0,3}", Print_num++);
            Console.Write("{0,3}", ":  ");
            for (int i = 0; i < n; i++)
            {
                Console.Write("{0,3}", a[i]);
                Console.Write("{0,3}", " ");
            }
            Console.Write("{0,3}", "\n");
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
