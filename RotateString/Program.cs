using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RotateString
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(Rotate("0123456", 3));
            Console.WriteLine(Rotate("0123456", 7));
            Console.WriteLine(Rotate("0123456", 6));
            Console.WriteLine(Rotate("0123456", 5));
            Console.WriteLine(Rotate("abcdef", 2));
            Console.ReadKey();
        }

        public static string Rotate(string s, int position)
        {
            if (string.IsNullOrEmpty(s))
                return s;

            if (position <= 0 || position >= s.Length)
                return s;

            s = ReverseString(s, 0, position - 1);
            s = ReverseString(s, position, s.Length - 1);
            s = ReverseString(s, 0, s.Length - 1);
            return s;
        }

        public static string ReverseString(string s, int l, int r)
        {
            var sArray = s.ToArray();
            var i = l;
            var j = r;
            while (i<j)
            {
                var t = sArray[i];
                sArray[i] = sArray[j];
                sArray[j] = t;
                i++;
                j--;
            }

            return string.Concat(sArray);
        }
    }
}
