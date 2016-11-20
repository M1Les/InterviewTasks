using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RomanToInteger
{
    public class Program
    {
        public static readonly Dictionary<char, int> map = new Dictionary<char, int>() {
            {'I', 1},
            {'V', 5},
            {'X', 10},
            {'L', 50},
            {'C', 100},
            {'D', 500},
            {'M', 1000}
        };


        public static void Main(string[] args)
        {
            Console.WriteLine(ConvertRomanToInteger("IV"));//-> 4
            Console.WriteLine(ConvertRomanToInteger("IIV"));//-> 5
            Console.WriteLine(ConvertRomanToInteger("XII"));//-> 12
            Console.WriteLine(ConvertRomanToInteger("XXI"));//-> 21
            Console.WriteLine(ConvertRomanToInteger("XCIX"));//-> 99

            Console.ReadKey();
        }

        public static int ConvertRomanToInteger(string s)
        {
            if (string.IsNullOrEmpty(s))
                return 0;

            int res = map[s[s.Length-1]];
            for (int i = s.Length-2; i >= 0; i--)
            {
                if (map[s[i]] < map[s[i + 1]])
                {
                    res -= map[s[i]];
                }
                else
                {
                    res += map[s[i]];
                }
            }

            return res;
        }
    }
}
