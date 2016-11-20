using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RotateMatrixClockwise
{
    public class Program
    {
        public static void Main(string[] args)
        {
            PrintMatrix(RotateMatrix(new int[,] {
                {1,2,3},
                {4,5,6},
                {7,8,9}
            }));

            Console.WriteLine("========");

            PrintMatrix(RotateMatrix(new int[,] {
                {1,2,3,4},
                {5,6,7,8},
                {9,10,11,12},
                {13,14,15,16}
            }));

            Console.ReadKey();
        }

        public static int[,] RotateMatrix(int[,] matrix)
        {
            if (matrix.GetLength(0) == 0)
                return matrix;

            if (matrix.GetLength(0) != matrix.GetLength(1))
                return matrix;

            for (int layer = 0; layer < matrix.GetLength(0)/2; layer++)
            {
                matrix = RotateLayer(matrix, layer);
            }

            return matrix;
        }

        public static int[,] RotateLayer(int[,] matrix, int layer)
        {
            var n = matrix.GetLength(0);
            var first = layer;
            var last = n - layer - 1;

            for (int i = first; i < last;i++)
            {
                //var offset = i - last;
                // n-i-1 => last - offset;
                var tmp = matrix[first, i]; // save top
                matrix[first, i] = matrix[n-i-1, first]; //left => top
                matrix[n - i - 1, first] = matrix[last, n - i - 1]; // bottom => left
                matrix[last, n-i-1] = matrix[i, last]; // right => bottom
                matrix[i, last] = tmp; // saved top => right

            }

            return matrix;
        }

        public static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
