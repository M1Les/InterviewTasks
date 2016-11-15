using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DungeonGame
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var result = CalculateMinimumHPOneDimension(new int[,] { { 0 } });

            Console.WriteLine(result);

            Console.ReadKey();
        }

        private static int CalculateMinimumHPOneDimension(int[,] dungeon)
        {
            var n = dungeon.GetLength(0);
            var m = dungeon.GetLength(1);

            if (m == 0)
                return 1;

            var min_hp = new int[m];

            for (var i = n - 1; i >= 0; i--)
            {
                for (var j = m - 1; j >= 0; j--)
                {
                    if (i == n - 1 && j == m - 1)
                    {
                        min_hp[j] = Math.Max(1 - dungeon[i, j], 1);
                    }
                    else if (i == n - 1)
                    {
                        min_hp[j] = Math.Max(min_hp[j + 1] - dungeon[i, j], 1);
                    }
                    else if (j == m - 1)
                    {
                        min_hp[j] = Math.Max(min_hp[j] - dungeon[i, j], 1);
                    }
                    else
                    {
                        min_hp[j] = Math.Min(Math.Max(min_hp[j + 1] - dungeon[i, j], 1), Math.Max(min_hp[j] - dungeon[i, j], 1));
                    }
                }
            }

            return min_hp[0];
        }
    }
}
