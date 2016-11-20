using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseSentence
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(ReverseWords("123 456 789"));
            Console.WriteLine(ReverseWords("last     word me"));
            Console.WriteLine(ReverseWords("word"));
            Console.WriteLine(ReverseWords("word      "));
            Console.WriteLine(ReverseWords("    word"));
            Console.WriteLine(ReverseWords("    word "));
            Console.WriteLine(ReverseWords("    word x"));
            Console.ReadKey();
        }

        public static string ReverseWords( string s)
        {
            var reversed = ReverseStringOrPart(s);
            var normalized = new StringBuilder();
            var lastIndex = s.Length - 1;

            for (int i = reversed.Length-1; i > 0; i--)
            {
                if (reversed[i] != ' ' && reversed[i - 1] == ' ')
                {
                    reversed = ReverseStringOrPart(reversed, i, lastIndex);
                    var word = reversed.Substring(i, lastIndex - i + 1);
                    if (normalized.Length > 0)
                        normalized.Insert(0, ' ');
                    normalized.Insert(0, word);
                    lastIndex = -1;
                }
                else if (reversed[i] == ' ' && reversed[i-1] != ' ')
                {
                    lastIndex = i - 1;
                }
            }

            if (lastIndex > 0)
            {
                reversed = ReverseStringOrPart(reversed, 0, lastIndex);
                var word = reversed.Substring(0, lastIndex + 1);
                if (normalized.Length > 0)
                    normalized.Insert(0, ' ');
                normalized.Insert(0, word);
            }

            Console.WriteLine(normalized.ToString());
            return reversed;
        }

        public static string ReverseStringOrPart(string s, int? start = null, int? finish = null)
        {
            var i = start ?? 0;
            var j = finish ?? s.Length - 1;
            var strArray = s.ToArray();

            while (i<j)
            {
                var tmp = strArray[i];
                strArray[i] = s[j];
                strArray[j] = tmp;
                i++;
                j--;
            }

            return string.Concat(strArray);
        }
    }
}
