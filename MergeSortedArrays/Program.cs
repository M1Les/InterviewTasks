using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MergeSortedArrays
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(string.Join(",", MergeSorted(new int[] { 1, 2, 3, 4}, new int[] { 2, 4, 5, 6 })));
            Console.ReadKey();
        }

        public static int[] MergeSorted(int[] a, int[] b)
        {
            if (a.Length == 0 && b.Length == 0)
                return new int[] { };

            if (a.Length == 0)
                return b;
            if (b.Length == 0)
                return a;


            int i = 0;
            int j = 0;
            var ret = new List<int>();

            while (i < a.Length && j < b.Length)
            {
                if (a[i] <= b[j])
                {
                    ret.Add(a[i]);
                    i++;
                }
                else
                {
                    ret.Add(b[j]);
                    j++;
                }
            }

            if (i < a.Length)
            {
                for (int k = i; k < a.Length; k++)
                    ret.Add(a[k]);
            }

            if (j < b.Length)
            {
                for (int k = j; k < b.Length; k++)
                    ret.Add(b[k]);
            }

            return ret.ToArray();
        }
    }
}
