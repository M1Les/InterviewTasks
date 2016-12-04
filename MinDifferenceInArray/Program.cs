using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinDifferenceInArray
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(MinDiffBySorting(new int[] { 1, 2, 3 }));
            Console.WriteLine(MinDiffBySorting(new int[] { 1, 5, 3, 19, 18, 25 }));
            Console.WriteLine(MinDiffBySorting(new int[] { 30, 5, 20, 9 }));
            Console.WriteLine(MinDiffBySorting(new int[] { 1, 19, -4, 31, 38, 25, 100 }));
            Console.ReadKey();
        }

        public static int MinDiffBySorting(int[] a) // O(nlog(n))
        {
            if (a.Length == 0 || a.Length == 1)
                return 0;
            int[] sa = a.OrderBy(e => e).ToArray();
            int minDiff = int.MaxValue;
            for (int i = 1; i < sa.Length; i++)
            {
                 minDiff = Math.Min(minDiff, sa[i] - sa[i - 1]); // no need for modulo since i >= i-1 because we sorted the array
            }

            return minDiff;
        }
    }
}
