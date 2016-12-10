using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplyStrings
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(MultiplyStrings("10", "2"));
            Console.WriteLine(MultiplyStrings("123", "564")); // 69372
            Console.WriteLine(MultiplyStrings("123", "1"));
            Console.WriteLine(MultiplyStrings("1", "123"));
            Console.WriteLine(MultiplyStrings("0", "0"));
            Console.WriteLine(MultiplyStrings("111", "1"));
            Console.WriteLine(MultiplyStrings(int.MaxValue.ToString(), "1"));
            Console.WriteLine(MultiplyStrings("500", "500"));
            Console.ReadKey();
        }

        public static string MultiplyStrings(string s1, string s2)
        {
            var a = s1.Length > s2.Length ? s1: s2;
            var b = s1.Length > s2.Length ? s2 : s1;

            var n = b.Length;
            var m = a.Length;
            var res = new int[n + m - 1];

            var idx = 0;

            var i = 0;
            var j = 0;
            while (i<n && j < m)
            {
                var ki = i;
                var kj = j;
                while (kj>= 0 && ki<n)
                {
                    res[idx] += (b[ki] - '0') * (a[kj]-'0');
                    ki++;
                    kj--;
                }

                idx++;

                if (j < m-1)
                    j++;
                else
                    i++;
            }

            //for (int j = 0; j < n+m-1; j++)
            //{
            //    for (int i = 0; i < m; i++)
            //    {
            //        res[j] += (b[m - i - 1]-'0') * (GetA(a, j + i - 1) - '0');
            //    }
            //}

            //var sb = new StringBuilder();
            for (int jj = res.Length-2; jj >=0; jj--)
            {
                var remainder = res[jj + 1] % 10;
                res[jj] += res[jj + 1] / 10;
                res[jj + 1] = remainder;
            }

            return string.Join("", res);
        }

        private static char GetA(string a, int v)
        {
            if (v >= 0 && v < a.Length)
                return a[v];

            return '0';
        }
    }
}
