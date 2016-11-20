using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsPrime
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(IsPrimeRecursive(7, 2));
            Console.ReadKey();
        }

        public static bool IsPrimeRecursive(int x, int divisor)
        {
            if (x < 1)
                return false;

            if (x <= 3)
                return true;

            if (divisor > Math.Sqrt(x))
                return true;
            else if (x % divisor == 0)
                return false;

            return IsPrimeRecursive(x, divisor + 1);
        }
    }
}
