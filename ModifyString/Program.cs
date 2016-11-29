using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModifyString
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(ReplaceSpaces("123 3567 "));
            Console.WriteLine(ReplaceSpaces(""));
            Console.WriteLine(ReplaceSpaces(" "));
            Console.WriteLine(ReplaceSpaces(" dfs"));
            Console.WriteLine(ReplaceSpaces(" df  s   "));
            Console.ReadKey();
        }

        public static string ReplaceSpaces(string str)
        {
            var newLength = str.Length;
            for (int k = 0; k < str.Length; k++)
            {
                if (str[k] == ' ')
                    newLength += 2;
            }

            var ret = new char[newLength];
            var i = str.Length-1;
            var j = newLength-1;

            while (i >=0)
            {
                if (str[i] == ' ')
                {
                    ret[j] = '0';
                    ret[j-1] = '2';
                    ret[j-2] = '%';
                    j -= 3;
                }
                else
                {
                    ret[j] = str[i];
                    j--;
                }

                i--;
            }
            return new string(ret);
        }
    }
}
