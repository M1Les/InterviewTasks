using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LongestWordsInDictionary
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(string.Join(",", FindLongest(new string[] { "1", "1", "1", "1", "1", "1", "" })));
            Console.WriteLine(string.Join(",", FindLongest(new string[] { "1", "1", "1", "1", "1", "1" })));
            Console.WriteLine(string.Join(",", FindLongest(new string[] { "", "1", "1", "1", "1", "1" })));
            Console.WriteLine(string.Join(",", FindLongest(new string[] { "", "1", "1", "1", "", "1" })));
            Console.WriteLine(string.Join(",", FindLongest(new string[] { "1", "1", "11223", "11", "1", "12", "" })));
            Console.WriteLine(string.Join(",", FindLongest(new string[] { "1", "1", "11223", "11", "1", "12", "11223" })));
            Console.WriteLine(string.Join(",", FindLongest(new string[] { "1", "1", "11223", "11", "1", "12", "11223" })));
            Console.WriteLine(string.Join(",", FindLongest(new string[] { "" })));
            Console.WriteLine(string.Join(",", FindLongest(new string[] { "","" })));
            Console.ReadKey();
        }

        public static ICollection<string> FindLongest(string[] a)
        {
            var n = a.Length;

            var ret = new List<string>();
            int maxLength = int.MinValue;

            for (int i = 0; i < n; i++)
            {
                if (a[i].Length > maxLength)
                {
                    ret = new List<string>();
                    maxLength = a[i].Length;
                }
                if (maxLength == a[i].Length)
                {
                    ret.Add(a[i]);
                }
            }

            return ret;
        }
    }
}
