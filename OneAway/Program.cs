using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneAway
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(OneAwayIter("123", "123")); //true equal
            Console.WriteLine(OneAwayIter("1235", "123")); //true insert
            Console.WriteLine(OneAwayIter("123", "1235")); //true insert
            Console.WriteLine(OneAwayIter("1236", "1235")); //true replace
            Console.WriteLine(OneAwayIter("1236790", "12356790")); //true insert
            Console.WriteLine(OneAwayIter("1336790", "12356790")); //false replace and insert
            Console.WriteLine(OneAwayIter("12367901", "123567902")); //false insert and replace
            Console.WriteLine(OneAwayIter("123679016", "1235679027")); //false
            Console.WriteLine(OneAwayIter("123", "567")); //false
            Console.WriteLine(OneAwayIter("12", "56")); //false
            Console.WriteLine(OneAwayIter("12", "6")); //false
            Console.WriteLine(OneAwayIter("1", "56")); //false
            Console.WriteLine(OneAwayIter("1", "5")); //true
            Console.ReadKey();
        }

        public static bool OneAwayIter(string str1, string str2)
        {
            if (Math.Abs(str1.Length - str2.Length) > 1)
                return false;

            string s1 = str1.Length < str2.Length ? str1 : str2;
            string s2 = str1.Length < str2.Length ? str2 : str1;
            bool isDiff = false;
            int i = 0;
            int j = 0;

            while (i < s1.Length && j < s2.Length)
            {
                if (s1[i] != s2[j])
                {
                    if (isDiff)
                    {
                        return false;
                    }

                    isDiff = true;

                    if (s1.Length == s2.Length)
                        i++;

                }
                else
                {
                    i++;
                }
                j++;
            }
            return true;
        }

        public static bool OneOrTwoAwayR(int i, int j, string s1, string s2, bool madeReplacement = false)
        {
            if (Math.Abs(s1.Length - s2.Length) > 1)
                return false;

            if (Math.Abs(i - j) > 1)
                return false;

            if ((s1.Length == i || s2.Length == j) && Math.Abs(i-j) <=1)
            {
                return true;
            }

            if (s1[i] == s2[j])
            {
                return OneOrTwoAwayR(i + 1, j + 1, s1, s2, madeReplacement);
            }
            else
            {
                var iDiff = s1.Length > s2.Length ? 1 : 0;
                var jDiff = Math.Abs(iDiff - 1);

                if (madeReplacement == false && i==j)
                {
                    return OneOrTwoAwayR(i + 1, j + 1, s1, s2, true)
                        || (OneOrTwoAwayR(i + iDiff, j + jDiff, s1, s2) && Math.Abs(s1.Length-s2.Length) == 1);
                }
                else if (madeReplacement)
                {
                    return OneOrTwoAwayR(i + iDiff, j + jDiff, s1, s2, madeReplacement) && Math.Abs(s1.Length - s2.Length) == 1;
                }
                else if (Math.Abs(i-j) == 1 && madeReplacement == false)
                {
                    return OneOrTwoAwayR(i+1,j+1,s1,s2,true);
                }
            }

            return false;
        }
    }
}
