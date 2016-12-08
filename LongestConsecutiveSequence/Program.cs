using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LongestConsecutiveSequence
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(FindMaxConsecutiveLength(new int[] { 1, 8, 5, 9, 2, 6, 3, 7 }));
            Console.WriteLine(FindMaxConsecutiveLength(new int[] { 1, 8, 5, 5, 5, 9, 2, 6, 3, 7 }));
            Console.WriteLine(FindMaxConsecutiveLength(new int[] { 1, 9, 3, 10, 4, 20, 2 }));
            Console.WriteLine(FindMaxConsecutiveLength(new int[] { 36, 41, 56, 35, 44, 33, 34, 92, 43, 32, 42 }));
            Console.ReadKey();
        }
        public static int FindMaxConsecutiveLength(int[] a)
        {
            var n = a.Length;
            var dict = new Dictionary<int, int>();
            var maxLength = 0;

            for (int i = 0; i < n; i++)
            {
                if (!dict.ContainsKey(a[i]))
                {
                    dict.Add(a[i], 1);
                }
                else
                {
                    dict[a[i]]++;
                }
            }

            for (int i = 0; i < n; i++)
            {
                if (!dict.ContainsKey(a[i]-1))
                {
                    // this is the first element in a sequence
                    var tmp = a[i];
                    var length = 0;
                    while (dict.ContainsKey(tmp))
                    {
                        length += dict[tmp];
                        tmp++;
                    }
                    // tmp does not belong to a, tmp-1 does.
                    if (maxLength < length)
                    {
                        maxLength = length;
                    }
                }
            }

            return maxLength;
        }
    }
}
