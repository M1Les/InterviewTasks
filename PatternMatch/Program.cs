using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatternMatch
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(IsMatch("fgfgd", "*"));
            Console.WriteLine(IsMatch("",""));
            Console.WriteLine(IsMatch("", "****?*"));
            Console.WriteLine(IsMatch("a", "*?**"));
            Console.WriteLine(IsMatch("a", "a**"));
            Console.WriteLine(IsMatch("ab", "a**b"));

            Console.WriteLine(IsMatch("baaabab", "a**b"));

            Console.WriteLine(IsMatch("baaabab", "*****ba*****ab"));
            Console.WriteLine(IsMatch("baaabab", "ba*****ab"));
            Console.WriteLine(IsMatch("baaabab", "ba*ab"));
            Console.WriteLine(IsMatch("baaabab", "a*ab"));
            Console.WriteLine(IsMatch("baaabab", "a*****ab"));
            Console.WriteLine(IsMatch("baaabab", "*a*****ab"));
            Console.WriteLine(IsMatch("baaabab", "ba*ab****"));
            Console.WriteLine(IsMatch("baaabab", "****"));
            Console.WriteLine(IsMatch("baaabab", "*"));
            Console.WriteLine(IsMatch("baaabab", "aa?ab"));
            Console.WriteLine(IsMatch("baaabab", "b*b"));
            Console.WriteLine(IsMatch("baaabab", "a*a"));
            Console.WriteLine(IsMatch("baaabab", "baaabab"));
            Console.WriteLine(IsMatch("baaabab", "?baaabab"));
            Console.WriteLine(IsMatch("baaabab", "*baaaba*"));

            Console.ReadKey();
        }

        public static bool IsMatch(string s, string p)
        {
            var m = new bool[s.Length+1, p.Length+1];

            m[0, 0] = true;

            for (int i = 1; i <= s.Length; i++)
            {
                m[i, 0] = false;
            }

            for (int j = 1; j <= p.Length; j++)
            {
                m[0, j] = p[j - 1] == '*' ? m[0, j - 1] : false;
            }

            for (int i = 1; i <= s.Length; i++)
            {
                for (int j = 1; j <= p.Length; j++)
                {
                    if (s[i - 1] == p[j - 1] || p[j - 1] == '?')
                    {
                        m[i, j] = m[i - 1, j - 1];
                    }
                    else if (p[j-1] == '*')
                    {
                        m[i, j] = m[i - 1, j] || m[i, j - 1];
                    }
                    else
                    {
                        m[i, j] = false;
                    }
                }
            }

            return m[s.Length, p.Length];
        }
    }
}
