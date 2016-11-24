using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WordBreak
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(WordBreak("123456123", new List<string> { "123", "45", "12", "1" }));
            Console.WriteLine(WordBreakR("123456123", new List<string> { "123", "456", "12", "1", "" }));
            Console.ReadKey();
        }

        public static bool WordBreak(string s, IReadOnlyCollection<string> words)
        {
            bool[] matches = new bool[s.Length + 1];
            matches[0] = true;

            for (int end = 0; end < s.Length; end++)
            {
                for (int begin = 0; begin < s.Length; begin++)
                {
                    if (matches[begin] && words.Contains(s.Substring(begin, end-begin+1)))
                    {
                        matches[end + 1] = true;
                        break;
                    }
                }
            }

            return matches[s.Length];
        }

        public static bool WordBreakR(string s, IReadOnlyCollection<string> w)
        {
            if (s.Length == 0)
                return true;

            foreach (var word in w)
            {
                if (word.Length != 0 && word.Length <= s.Length && s.StartsWith(word) && WordBreakR(s.Substring(word.Length, s.Length - word.Length), w))
                    return true;
            }

            return false;
        }
    }
}
