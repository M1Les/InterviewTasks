using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreedyJustify
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var words = new string[] { "asdf", "dfdfds", "gfgfhewfdfsdf", "asdf", "dfdfds", "asdf", "dfdfds" ,"asdf", "dfdfds" };
            var res = Justify(words, 15);

            foreach (var item in res)
            {
                Console.WriteLine(item + '|');
            }

            Console.ReadKey();
        }

        public static List<string> Justify(string[] words, int l)
        {
            var res = new List<string>();
            int i = 0;
            int n = words.Length;

            while (i < n)
            {
                int currLength = words[i].Length;

                int j = i + 1;
                while(j < n && currLength + words[j].Length + (j-i) < l)
                {
                    currLength += words[j++].Length;
                }

                var sb = new StringBuilder(words[i]);

                bool isLastLine = j == n;
                bool isSingleWord = j == i + 1;
                int average = (isLastLine || isSingleWord) ? 1 : (l - currLength) / (j - i - 1);
                int extra = (isLastLine || isSingleWord) ? 0 : (l - currLength) % (j - i - 1);

                for (int k = i+1; k < j; k++)
                {
                    sb.Append(GetPadding(extra>0 ? average +1: average));
                    sb.Append(words[k]);
                    extra--;
                }

                sb.Append(GetPadding(l - sb.Length));
                i = j;
                res.Add(sb.ToString());
            }

            return res;
        }

        public static string GetPadding(int count)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < count; i++)
            {
                sb.Append(" ");
            }

            return sb.ToString();
        }
    }
}
