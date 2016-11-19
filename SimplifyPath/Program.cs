using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplifyPath
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(GetSimplifiedPath("/1/2/./../gg/"));
            Console.WriteLine(GetSimplifiedPath("/home/"));
            Console.WriteLine(GetSimplifiedPath("/home//s"));
            Console.WriteLine(GetSimplifiedPath("/a/./b/../../c/"));
            Console.WriteLine(GetSimplifiedPath("/../"));
            Console.WriteLine(GetSimplifiedPath("/./"));
            Console.WriteLine(GetSimplifiedPath("/"));
            Console.WriteLine(GetSimplifiedPath("//"));
            Console.WriteLine(GetSimplifiedPath("/"));
            Console.WriteLine(GetSimplifiedPath(""));
            Console.ReadKey();
        }

        private static string GetSimplifiedPath(string path)
        {
            if (string.IsNullOrEmpty(path))
                return "/";

            var parts = path.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            var res = new List<string>();

            for (int i = 0; i < parts.Length; i++)
            {
                if (parts[i] == "..")
                {
                    if (res.Count > 0)
                        res.RemoveAt(res.Count-1);
                }
                else if (parts[i] != ".")
                {
                    res.Add(parts[i]);
                }
            }

            var sb = new StringBuilder("/");
            for (int i = 0; i < res.Count; i++)
            {
                sb.Append(res[i] + "/");
            }
            if (sb.Length > 1)
                sb.Remove(sb.Length - 1, 1);

            return sb.ToString();
        }
    }
}
