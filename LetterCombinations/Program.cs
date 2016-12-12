using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetterCombinations
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(string.Join(",", LetterCombs("2")));
            Console.WriteLine(string.Join(",", LetterCombs("23")));
            Console.ReadKey();
        }

        public static ICollection<string> LetterCombs(string a)
        {
            var ret = new List<string>();

            if (a.Length == 0)
                return ret;

            var keyboard = new string[] { "", "", "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz" };

            LetterCombsR(keyboard, a, ret, "");

            return ret;
        }

        private static void LetterCombsR(string[] keyboard, string a, List<string> ret, string working)
        {
            if (working.Length == a.Length)
            {
                ret.Add(working);
                return;
            }

            var digit = a[working.Length] - '0';
            var letters = keyboard[digit];

            for (int i = 0; i < letters.Length; i++)
            {
                LetterCombsR(keyboard, a, ret, working + letters[i]);
            }
        }
    }
}
