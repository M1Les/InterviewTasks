using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsomorphicStrings
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(IsIso("abb","edd"));
            Console.WriteLine(IsIso("abb", "edf"));
            Console.ReadKey();
        }

        public static bool IsIso(string a, string b)
        {
            if (a.Length == 0 && b.Length == 0)
                return true;

            if (a.Length != b.Length)
                return false;

            var map = new Dictionary<char, char>();
            for (int i = 0; i < a.Length; i++)
            {
                if (!map.ContainsKey(a[i]))
                {
                    map.Add(a[i], b[i]);
                }
                else if (map[a[i]] != b[i])
                {
                    return false;
                }
            }
            map.Clear();
            for (int i = 0; i < b.Length; i++)
            {
                if (!map.ContainsKey(b[i]))
                {
                    map.Add(b[i], a[i]);
                }
                else if (map[b[i]] != a[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
