using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstIndexNeedleHaystack
{
    public class Program
    {
        const int DICT_SIZE = 256; // ASCII character table

        public static void Main(string[] args)
        {
            Console.WriteLine(HorspoolSearch("haysneedletack", "needle"));

            Console.ReadKey();
        }

        public static int HorspoolSearch(string s, string pattern)
        {
            if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(pattern))
                return -1;

            var n = s.Length;
            var m = pattern.Length;

            var occ = new int[DICT_SIZE];
            for (int i = 0; i < occ.Length; i++)
            {
                occ[i] = -1;
            }

            for (int i = 0; i < m - 1; i++)
            {
                occ[pattern[i]] = i;
            }

            var startIdx = 0;
            while (startIdx <= n-m)
            {
                var j = m - 1;

                while ((j >= 0) && (s[startIdx + j] == pattern[j]))
                    j--;

                if (j < 0)
                    return startIdx;

                // shift to the rightmost character in the search window
                startIdx += m - 1;
                startIdx -= occ[s[startIdx]];
            }

            return -1;
        }
    }
}
