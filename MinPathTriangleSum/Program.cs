using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinPathTriangleSum
{
    public class Program
    {
        public static void Main(string[] args)
        {

            Console.WriteLine(MaxPathSum(new int[][] { new int[] {2},
    new int[] {3, 4},
   new int[] {6, 5, 7},
  new int[] {4, 1, 8, 3} })); // 11 = 2+3+5+1
            Console.ReadKey();
        }

        public static int MaxPathSum(int[][] a)
        {
            if (a.Length == 0) return 0;
            if (a[0] == null || a[0].Length != 1) return 0;

            int[][] sum = new int[a.Length][];

            sum[0] = new int[a[0].Length];
            sum[0][0] = a[0][0];

            for (int i = 1; i < a.Length; i++)
            {
                sum[i] = new int[a[i].Length];
                for (int j = 0; j < a[i].Length; j++)
                {
                    sum[i][j] = a[i][j] + Math.Min(sum[i - 1][Math.Max(0, j - 1)], sum[i - 1][Math.Min(a[i - 1].Length - 1, j)]);
                }
            }

            return sum[a.Length - 1].Min(v => v);
        }
    }
}
