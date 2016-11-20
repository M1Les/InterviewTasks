using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReverseInt
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(ReverseInteger(int.MaxValue-1));
            Console.WriteLine(ReverseInteger(123));
            Console.WriteLine(ReverseInteger(-123));
            Console.WriteLine(ReverseInteger(1));
            Console.WriteLine(ReverseInteger(0));
            Console.WriteLine(ReverseInteger(-1));
            Console.WriteLine(ReverseInteger(-11));
            Console.WriteLine(ReverseInteger(11));
            Console.WriteLine(ReverseInteger(int.MaxValue));
            Console.WriteLine(ReverseInteger(int.MinValue));
            Console.ReadKey();


        }

        public static int ReverseInteger(int x)
        {
            if (x == int.MinValue || x == int.MaxValue)
                return 0;

            var res = 0; // or use long as a type and check if we overshoot int.MaxValue
            bool isNegative = x < 0;
            var workingNum = Math.Abs(x);
            var tmp = workingNum % 10;
            while (workingNum != 0)
            {
                res = 10 * res + tmp;
                workingNum = workingNum / 10;
                tmp = workingNum % 10;

                if (res > (int.MaxValue - tmp) / 10)
                    return 0;
            }

            return isNegative ? -res : res;
        }
    }
}
