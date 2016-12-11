using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LastWordLength
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(WordLength("21232"));
            Console.WriteLine(WordLength(""));
            Console.WriteLine(WordLength(" 23"));
            Console.WriteLine(WordLength("23 "));
            Console.WriteLine(WordLength("23   "));
            Console.WriteLine(WordLength("23 rthfg"));
            Console.WriteLine(WordLength("23 rthfg   "));
            Console.WriteLine(WordLength(" 23 rthfg   "));
            Console.ReadKey();
        }

        public static int WordLength(string s)
        {
            var n = s.Length;
            var length = 0;
            var i = n-1;

            while (i >= 0 && s[i] == ' ')
            {
                i--;
            }

            while (i >=0 && s[i] != ' ')
            {
                i--;
                length++;
            }

            return length;
        }
    }
}
