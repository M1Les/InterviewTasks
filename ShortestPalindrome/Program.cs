using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPalindrome
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(Shortest("aacecaaa"));
            Console.WriteLine(Shortest(""));
            Console.WriteLine(Shortest("121"));
            Console.WriteLine(Shortest("321"));
            Console.WriteLine(Shortest("221"));
            Console.WriteLine(Shortest("32132"));
            Console.WriteLine(Shortest("33132"));
            Console.WriteLine(Shortest("abcd"));
            Console.WriteLine(Shortest("aabaac"));

            Console.ReadKey();
        }

        public static string Shortest(string s)
        {
            if (s.Length <= 1)
                return s;

            var prefix = string.Empty;

            var needToAppend = false;
            var lPtr = 0;
            var rPtr = s.Length - 1;

            while (lPtr < rPtr)
            {
                if (s[lPtr] == s[rPtr])
                {
                    lPtr++;
                    rPtr--;
                }
                else
                {
                    rPtr = rPtr + lPtr - 1;
                    lPtr = 0;
                    prefix = s.Substring(rPtr + 1, s.Length - rPtr-1);
                    needToAppend = true;
                }
            }

            if (needToAppend)
                return string.Concat(prefix.Reverse()) + s;
            else
                return s;
        }
    }
}
