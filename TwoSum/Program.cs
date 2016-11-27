using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TwoSum
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(SumTwo(new int[] { 2, 7, 11, 15}, 9));
            Console.ReadKey();
        }

        public static Tuple<int, int> SumTwo(int[] num, int sum)
        {
            if (num.Length == 0)
                return Tuple.Create(0, 0);

            var results = new Dictionary<int, int>();
            var n = num.Length;

            for (int i = 0; i < n; i++)
            {
                int matchingIndex;

                if (results.TryGetValue(sum - num[i], out matchingIndex))
                {
                    return Tuple.Create(matchingIndex + 1, i + 1);
                }
                else
                {
                    results.Add(num[i], i);
                }
            }

            return Tuple.Create(0, 0);
        }
    }
}
