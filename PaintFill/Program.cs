using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaintFill
{
    public class Program
    {
        public static void Main(string[] args)
        {
            PrintMatrix(Fill(new int[,] { {2,2,3,2,2 }, {1,2,1,1,3 }, {2,1,1,1,1 } }, 1, 1, null, 77));
            Console.ReadKey();
        }

        public static int[,] Fill(int[,] matrix, int x, int y, int? origColor, int newColor)
        {
            if (x < 0 || x >= matrix.GetLength(0))
                return matrix;
            if (y < 0 || y >= matrix.GetLength(1))
                return matrix;

            if (origColor.HasValue == false)
                origColor = matrix[x, y];

            if (matrix[x,y] == origColor.Value)
            {
                matrix[x, y] = newColor;

                matrix = Fill(matrix, x - 1, y, origColor, newColor);
                matrix = Fill(matrix, x+1, y, origColor, newColor);
                matrix = Fill(matrix, x, y-1, origColor, newColor);
                matrix = Fill(matrix, x, y+1, origColor, newColor);
            }

            return matrix;
        }

        public static void PrintMatrix(int[,] m)
        {
            for (int i = 0; i < m.GetLength(0); i++)
            {
                for (int j = 0; j < m.GetLength(1); j++)
                {
                    Console.Write(m[i,j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
