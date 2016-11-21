using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReorderByCase
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(OrderByCase("sdfDSdfDSg"));
            Console.WriteLine(OrderByCase("QsdfDSdfDSg"));
            Console.WriteLine(OrderByCase("AsdfDSdfDSg"));
            Console.WriteLine(OrderByCase(""));
            Console.WriteLine(OrderByCase("A"));
            Console.WriteLine(OrderByCase("z"));
            Console.ReadKey();
        }

        public static string OrderByCase(string s)
        {
            if (string.IsNullOrEmpty(s))
                return s;

            var first = new StringBuilder();
            var second = new StringBuilder();
            var isFirstCurrent = true;

            first.Append(s[0]);

            for (int i = 1; i < s.Length; i++)
            {
                //if ((s[i-1] - 'A' >=0 && s[i]-'A' < 0)
                //    ||(s[i - 1] - 'A' < 0 && s[i] - 'A' >= 0))
                if ((char.IsUpper(s[i - 1]) && char.IsLower(s[i]))
                    || (char.IsLower(s[i - 1]) && char.IsUpper(s[i])))
                {
                    isFirstCurrent = !isFirstCurrent;
                }

                if (isFirstCurrent)
                    first.Append(s[i]);
                else
                    second.Append(s[i]);
            }

            return first.ToString() + second.ToString();
        }
    }
}
