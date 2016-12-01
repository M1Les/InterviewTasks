using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReorderParity
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(string.Join(",", ReorderOneCycle(new int[] { 1,2,3,5,6,7})));
            Console.WriteLine(string.Join(",", ReorderOneCycle(new int[] { 2 })));
            Console.WriteLine(string.Join(",", ReorderOneCycle(new int[] { 2,2,2,2,2 })));
            Console.WriteLine(string.Join(",", ReorderOneCycle(new int[] { 3,3,3,3,3 })));
            Console.WriteLine(string.Join(",", ReorderOneCycle(new int[] { 3,3, 2, 2, 2 })));
            Console.WriteLine(string.Join(",", ReorderOneCycle(new int[] { 2,2, 3, 3, 3 })));
            Console.ReadKey();
        }

        public static int[] ReorderOneCycle(int[] a)
        {
            if (a.Length == 0)
                return a;

            int i = 0;
            int j = a.Length - 1;
            while (i<j)
            {
                if (a[i] % 2 == 0)
                    i++;
                else if (a[j] % 2 != 0)
                    j--;
                else
                {
                    var tmp = a[i];
                    a[i] = a[j];
                    a[j] = tmp;
                }
            }

            return a;

            return a;
        }

        public static int[] Reorder(int[] a)
        {
            if (a.Length == 0)
                return a;

            int i = 0;int j = a.Length - 1;
            while (i<j)
            {
                while ( i < a.Length && a[i] % 2 == 0)
                    i++;
                while (j >=0 && a[j] % 2 != 0)
                    j--;
                if (i<j)
                {
                    var tmp = a[i];
                    a[i] = a[j];
                    a[j] = tmp;
                }
            }

            return a;

        }
    }
}
