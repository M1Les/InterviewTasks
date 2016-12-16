using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniquePaths
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(CountUniquePaths(new int[,] { { } }));
            Console.WriteLine(CountUniquePaths(new int[,] { {0} }));
            Console.WriteLine(CountUniquePaths(new int[,] { { 0, 0 } }));
            Console.WriteLine(CountUniquePaths(new int[,] { {0, 0, 0}, {0, 0, 0} }));

            Console.WriteLine(CountUniquePathsWithObstacles(new int[,] { { } }));
            Console.WriteLine(CountUniquePathsWithObstacles(new int[,] { { 0 } }));
            Console.WriteLine(CountUniquePathsWithObstacles(new int[,] { { 0, 0 } }));
            Console.WriteLine(CountUniquePathsWithObstacles(new int[,] { { 0, 0, 0 } }));
            Console.WriteLine(CountUniquePathsWithObstacles(new int[,] { { 0, 0, 0 }, { 0, 0, 0 } }));
            Console.WriteLine(CountUniquePathsWithObstacles(new int[,] { { 0, 1, 0 }, { 0, 0, 0 } }));
            Console.WriteLine(CountUniquePathsWithObstacles(new int[,] { { 0, 0, 1 }, { 0, 0, 0 } }));
            Console.WriteLine(CountUniquePathsWithObstacles(new int[,] { { 0, 0, 0 }, { 0, 0, 1 } }));
            Console.WriteLine(CountUniquePathsWithObstacles(new int[,] { { 1, 0, 0 }, { 0, 0, 0 } }));

            Console.ReadKey();
        }

        public static int CountUniquePaths(int[,] matrix)
        {
            if (matrix.GetLength(0) == 0 || matrix.GetLength(1) == 0)
                return 0;

            var m = matrix.GetLength(0);
            var n = matrix.GetLength(1);

            matrix[0, 0] = 1;

            for (int i = 1; i < m; i++)
            {
                matrix[i, 0] = 1;
            }
            for (int j = 1; j < n; j++)
            {
                matrix[0, j] = 1;
            }

            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    matrix[i, j] = matrix[i - 1, j] + matrix[i, j - 1];
                }
            }

            return matrix[m - 1, n - 1];
        }

        public static int CountUniquePathsWithObstacles(int[,] map)
        {
            if (map.GetLength(0) == 0 || map.GetLength(1) == 0)
                return 0;

            if (map[0, 0] == 1)
                return 0;

            var m = map.GetLength(0);
            var n = map.GetLength(1);

            if (map[0, 0] == 1)
                return 0;

            var matrix = new int[m, n];

            matrix[0, 0] = 1;

            for (int i = 1; i < m; i++)
            {
                if (map[i, 0] == 1)
                    matrix[i, 0] = 0;
                else
                    matrix[i, 0] = matrix[i-1, 0];
            }
            for (int j = 1; j < n; j++)
            {
                if (map[0, j] == 1)
                    matrix[0, j] = 0;
                else
                    matrix[0, j] = matrix[0, j - 1];
            }

            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    if (map[i, j] == 1)
                        matrix[i, j] = 0;
                    else
                        matrix[i, j] = matrix[i - 1, j] + matrix[i, j - 1];
                }
            }

            return matrix[m - 1, n - 1];
        }
    }
}
