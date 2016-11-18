using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SubstringConcatenateAllWords
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var res = FindSubstr(new string[] { "foo", "bar" }, "barfoothefoobarman");

            foreach (var item in res)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }

        public static List<int> FindSubstr(string[] words, string s)
        {
            var res = new List<int>();

            if (string.IsNullOrEmpty(s) || words.Length == 0)
            {
                return res;
            }

            var n = words.Length;
            var k = s.Length;
            var m = words[0].Length;

            var needed = new Dictionary<string, int>();

            for (int i = 0; i < n; i++)
            {
                if (needed.ContainsKey(words[i]))
                {
                    needed[words[i]]++;
                }
                else
                {
                    needed.Add(words[i], 1);
                }
            }

            for (int i = 0; i <= k-n*m; i++)
            {
                int j = 0;
                var actualLeft = new Dictionary<string, int>();
                while (j < n)
                {
                    var word = s.Substring(i + j * m, m);
                    if (needed.ContainsKey(word) == false)
                    {
                        break;
                    }
                    else
                    {
                        if (actualLeft.ContainsKey(word) == false)
                        {
                            actualLeft.Add(word, needed[word] - 1);
                        }
                        else
                        {
                            actualLeft[word]--;
                        }
                        if (actualLeft[word] < 0)
                        {
                            break;
                        }
                    }
                    j++;
                }
                if (j == n)
                {
                    res.Add(i);
                }
            }

            return res;
        }
    }
}
