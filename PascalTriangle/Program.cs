using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PascalTriangle
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var res = BuildPascalTriangle(5);
            Console.ReadKey();
        }

        public static IReadOnlyCollection<int[]> BuildPascalTriangle(int rows)
        {
            var ret = new List<int[]>();
            if (rows < 1)
                return ret;

            var prev = new int[] { 1 };
            ret.Add(prev);
            for (int i = 1; i < rows; i++)
            {
                var curr = new int[prev.Length+1];
                curr[0] = 1;
                curr[curr.Length - 1] = 1;
                for (int j = 1; j < curr.Length-1; j++)
                {
                    curr[j] = prev[j - 1] + prev[j];
                }
                ret.Add(curr);
                prev = curr;
            }

            return ret;
        }
    }
}

