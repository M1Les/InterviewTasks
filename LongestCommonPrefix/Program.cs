using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestCommonPrefix
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(LongestPref(new string[] { "123", "1", "12"}));
            Console.WriteLine(LongestPref(new string[] { "123", "2", "2" }));
            Console.WriteLine(LongestPref(new string[] { "1", "123", "12" }));
            Console.ReadKey();
        }

        public static string LongestPref(string[] strs)
        {
            if (strs.Length == 0) return string.Empty;

            var m = strs.Length;
            var res = strs[0];
            var seen = new Dictionary<string, string>();

            for (int i = 0; i < m; i++)
            {
                if (seen.ContainsKey(strs[i]))
                    continue;
                else
                    seen.Add(strs[i], res);

                var pref = GetCommonPrefix(res, strs[i]);
                if (pref.Length < res.Length)
                    res = pref;
            }

            return res;
        }

        private static string GetCommonPrefix(string s1, string s2)
        {
            var str1 = s1.Length < s2.Length ? s1 : s2;
            var str2 = s1.Length < s2.Length ? s2 : s1;
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < str1.Length; i++)
            {
                if (str1[i] == str2[i])
                    sb.Append(str1[i]);
                else
                    break;
            }

            return sb.ToString();
        }
    }
}
