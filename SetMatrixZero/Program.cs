using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SetMatrixZero
{
    public class Program
    {
        public static void Main(string[] args)
        {
            PrintMatrix(SetMatrixZero(new int[,] { { 1, 2, 3 }, { 5, 6, 7 }, { 1, 2, 0 } }));
            PrintMatrix(SetMatrixZero(new int[,] { { 1, 2, 3 }, { 5, 6, 0 }, { 1, 2, 0 } }));
            PrintMatrix(SetMatrixZero(new int[,] { { 1, 0, 3 }, { 5, 6, 7 }, { 1, 2, 0 } }));

            Console.ReadKey();
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


        public static int[,] SetMatrixZero(int[,] matrix)
        {
            if (matrix.GetLength(0) == 0)
                return matrix;

            var m = matrix.GetLength(0);
            var n = matrix.GetLength(1);
            var rowFlags = new bool[m];
            var colFlags = new bool[n];

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i,j] == 0)
                    {
                        rowFlags[i] = true;
                        colFlags[j] = true;
                    }
                }
            }

            for (int i = 0; i < m; i++)
            {
                if (rowFlags[i])
                    matrix = ZeroRow(matrix, i);
            }

            for (int j = 0; j < m; j++)
            {
                if (colFlags[j])
                    matrix = ZeroCol(matrix, j);
            }

            return matrix;
        }

        public static int[,] ZeroRow(int[,] matrix, int row)
        {
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                matrix[row, i] = 0;
            }

            return matrix;
        }
        public static int[,] ZeroCol(int[,] matrix, int column)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                matrix[i, column] = 0;
            }

            return matrix;
        }
    }
}
