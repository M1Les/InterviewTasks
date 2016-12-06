using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaxSpacing
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(FindMaxSpacing(new int[] { 1,2,3,4,5 }));
            Console.WriteLine(FindMaxSpacing(new int[] { 1, 7, 3, 4, 5 }));
            Console.ReadKey();
        }

        public static int FindMaxSpacing(int[] a)
        {
            int n = a.Length;
            int[] p = new int[n];
            for (int i = 0; i < n; i++)
            {
                p[i] = ((i == 0) || (a[i] < p[i - 1])) ? a[i] : p[i - 1];
            }

            int best = 0;
            for (int j = n - 1; j > best; j--)
            {
                while ((j > best) && (a[j] >= p[j - best - 1]))
                {
                    ++best;
                }
            }
            return best;
        }
    }
}
