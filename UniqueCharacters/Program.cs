using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniqueCharacters
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var str = "asdzxcver";

            Console.WriteLine(HasUnique(str));
            Console.ReadKey();
        }

        private static bool HasUnique(string str)
        {
            var dict = new Dictionary<char, bool>();
            for (int i = 0; i < str.Length; i++)
            {
                if (dict.ContainsKey(str[i]))
                {
                    return false;
                }

                dict.Add(str[i], true);
            }

            return true;
        }
    }
}
