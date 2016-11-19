using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageNewspaper
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(CanMakeMessage("1234567123456", "1155"));
            Console.WriteLine(CanMakeMessage("1234567123456", "11559"));
            Console.WriteLine(CanMakeMessage("1234567123456", " "));
            Console.WriteLine(CanMakeMessage("1234567123456", "    "));
            Console.WriteLine(CanMakeMessage("1234567123456", ""));
            Console.WriteLine(CanMakeMessage("", ""));
            Console.ReadKey();
        }

        public static bool CanMakeMessage(string newspaper, string message)
        {
            if (string.IsNullOrEmpty(message)
                || (string.IsNullOrEmpty(message) && string.IsNullOrEmpty(newspaper)))
                return true;
            if (string.IsNullOrEmpty(newspaper))
                return false;

            var freq = new Dictionary<char, int>();

            for (int i = 0; i < newspaper.Length; i++)
            {
                if (newspaper[i] != ' ')
                {
                    if (freq.ContainsKey(newspaper[i]))
                        freq[newspaper[i]]++;
                    else
                        freq.Add(newspaper[i], 1);
                }
            }

            for (int i = 0; i < message.Length; i++)
            {
                if (message[i] != ' ')
                {
                    if (freq.ContainsKey(message[i]) == false)
                        return false;
                    else if (freq[message[i]] == 0)
                        return false;
                    else
                        freq[message[i]]--;
                }
            }

            return true;
        }
    }
}
