using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinDifferenceTwoArray
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(MinDiff(new int[] { 1,5,7 }, new int[] { 2, 3, 5, 6}));
            Console.ReadKey();
        }

        public static int MinDiff(int[] a, int[] b)
        {
            if (a.Length == 0 || b.Length == 0)
                return 0;

            var sa = a.OrderBy(e => e).ToArray();
            var sb = b.OrderBy(e => e).ToArray();
            int i = 0;
            int j = 0;
            int min = int.MaxValue;

            while (i< sa.Length && j < sb.Length)
            {
                if (Math.Abs(sa[i] - sb[j]) < min)
                    min = Math.Abs(sa[i] - sb[j]);

                if (sa[i] < sb[j])
                    i++;
                else if (sa[i] > sb[j])
                    j++;
                else
                {
                    i++;
                    j++;
                }
            }

            return min;
        }
    }
}
