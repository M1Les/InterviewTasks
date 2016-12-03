using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckPermutation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(Check("",""));
            Console.WriteLine(Check("123", "321"));
            Console.WriteLine(Check("13211", "11231"));
            Console.WriteLine(Check("123113", "312313"));
            Console.WriteLine(Check("222", "222"));
            Console.WriteLine(Check("12", ""));
            Console.ReadKey();
        }

        public static bool Check(string str1, string str2)
        {
            if (str1.Length != str2.Length)
                return false;

            if (str1.Length == 0)
                return true;

            var hash = new Dictionary<char, int>();

            for (int i = 0; i < str1.Length; i++)
            {
                int c;
                if (hash.TryGetValue(str1[i], out c))
                {
                    hash[str1[i]]++;
                }
                else
                {
                    hash.Add(str1[i], 1);
                }
            }

            for (int i = 0; i < str2.Length; i++)
            {
                if (hash.ContainsKey(str2[i]))
                    hash[str2[i]]--;
                else
                    return false;
            }

            return !hash.Any(kvp => kvp.Value != 0);
        }
    }
}
