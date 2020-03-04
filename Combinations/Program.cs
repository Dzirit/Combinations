using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Combinations
{
    class Program
    {
        static int Print_num = 1;
        static double[] b = new double[] { 0.1, 0.5, 0.9 };
        static double[] c;
        const string writePath = @"D:\Аспирантура\МЭИ\данные\combMax.csv";
        const int numFeaturePermut = 64;
        static async Task Main(string[] args)
        {
            int n =3;
            int m=7;
            double[] a;
            
            int h = n > m ? n : m; // размер массива а выбирается как max(n,m)
            a = new double[h];
            c = new double[h];
            for (int i = 0; i < h; i++)
            {
                a[i] = 1;
            }
            
            using (StreamWriter sw = new StreamWriter(writePath))
            {
                for (int i = 0; i < numFeaturePermut; i++)
                {
                    await Print(a, m, sw);
                    await sw.WriteLineAsync();
                }
                while (NextSet(a, n, m))
                {
                    for (int i = 0; i < numFeaturePermut; i++)
                    {
                        await Print(a, m, sw);
                        await sw.WriteLineAsync();
                    }
                }
            }
        }
        private static async Task Print(double[] a, int n, StreamWriter sw)
        {
            
                Console.Write($"{ Print_num++}:  ");
                for (int i = 0; i < n; i++)
                {
                    if (a[i] == 1)
                    {
                        c[i] = b[0];
                    }
                    if (a[i] == 2)
                    {
                        c[i] = b[1];
                    }
                    if (a[i] == 3)
                    {
                        c[i] = b[2];
                    }
                    Console.Write($"{c[i]} ");
                    await sw.WriteAsync($"{c[i]};;");
                }
                Console.WriteLine();
                
            
            
        }

        private static bool NextSet(double[] a, int n, int m)
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
