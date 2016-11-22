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

            Console.WriteLine(OrderByCaseInplace("sdfDSdfDSg".ToArray()));
            Console.WriteLine(OrderByCaseInplace("QsdfDSdfDSg".ToArray()));
            Console.WriteLine(OrderByCaseInplace("AsdfDSdfDSg".ToArray()));
            Console.WriteLine(OrderByCaseInplace("".ToArray()));
            Console.WriteLine(OrderByCaseInplace("A".ToArray()));
            Console.WriteLine(OrderByCaseInplace("z".ToArray()));

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

        public static string OrderByCaseInplace(char[] s)
        {
            if (s.Length == 0 || s.Length == 1)
                return string.Concat(s);

            int p1 = 1;
            int p2 = s.Length - 1;

            while (p1<s.Length && IsSameCase(s[p1], s[p1-1]))
            {
                p1++;
            }

            while (p1<p2)
            {
                if (IsDifferentCase(s[p1], s[p2]))
                {
                    var tmp = s[p1];
                    s[p1] = s[p2];
                    s[p2] = tmp;
                    p1++;
                    p2--;
                }
                else if (IsSameCase(s[p1], s[p2]) && IsSameCase(s[p1-1], s[p2]))
                {
                    p1++;
                }
                else
                {
                    p2--;
                }
            }

            return string.Concat(s);
        }

        public static bool IsSameCase(char c1, char c2)
        {
            return (char.IsLower(c1) && char.IsLower(c2))
                || (char.IsUpper(c1) && char.IsUpper(c2));
        }

        public static bool IsDifferentCase(char c1, char c2)
        {
            return (char.IsLower(c1) && char.IsUpper(c2))
                || (char.IsUpper(c1) && char.IsLower(c2));
        }
    }
}
