using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompressString
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(Compress("tertbgbgfngthrrrrr"));
            Console.WriteLine(Compress("trrrrr"));
            Console.ReadKey();
        }

        public  static string Compress(string s)
        {
            var length = CompressedLength(s);

            if (s.Length <= length)
                return s;

            var sb = new StringBuilder();
            var count = 0;
            for (int i = 0; i < s.Length; i++)
            {
                count++;
                if (i+1 == s.Length || s[i] != s[i+1])
                {
                    sb.Append(s[i]);
                    sb.Append(count);
                    count = 0;
                }
            }

            return sb.ToString();
        }

        public static int CompressedLength(string s)
        {
            int res = 0;
            int count = 0;
            for (int i = 0; i < s.Length; i++)
            {
                count++;
                if (i+1 == s.Length || s[i] != s[i + 1])
                {
                    res += count.ToString().Length + 1;
                    count = 0;
                }
            }

            return res;
        }
    }
}
