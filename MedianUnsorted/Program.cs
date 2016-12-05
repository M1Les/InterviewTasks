using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedianUnsorted
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(MedianUnsorted(new int[] { 4, 5, 1, 2, 3 }));
            Console.WriteLine(MedianUnsorted(new int[] { 7, 9, 4, 5 }));
            Console.ReadKey();
        }

        public static int MedianUnsorted(int[] a)
        {
            if (a.Length == 0)
                return 0;

            var sorted = a.OrderBy(e => e).ToList();
            if (a.Length % 2 == 0)
                return sorted[a.Length / 2 - 1];
            else
                return sorted[a.Length / 2];
        }
    }
}
