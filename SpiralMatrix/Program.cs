using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpiralMatrix
{
    public class Program
    {
        public static void Main(string[] args)
        {
            SpiralMatrix(new int[,] {
                {1,2,3},
                {6,5,4}
            });

            SpiralMatrix(new int[,] {
                {1,2,3},
                {4,5,6},
                {7,8,9}
            });

            Console.ReadKey();
        }

        public static void SpiralMatrix(int[,] matrix)
        {
            if (matrix.GetLength(0) == 0)
                return;

            if (matrix.GetLength(1) == 0)
                return;

            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);

            int maxShift = (Math.Min(m, n) % 2) == 0 ? Math.Min(m, n) / 2 : Math.Min(m, n) / 2 + 1;

            for (int k = 0; k < maxShift; k++)
            {
                int row = k;
                int col = k;

                for (int i = col; i < n-col-1; i++)
                {
                    Console.WriteLine(matrix[row, i]);
                }
                for (int j = row; j < m - row - 1; j++)
                {
                    Console.WriteLine(matrix[j, n-col-1]);
                }
                for (int i = n-col-1; i > col; i--)
                {
                    Console.WriteLine(matrix[m-row-1, i]);
                }
                for (int j = m-row-1; j > row; j--)
                {
                    Console.WriteLine(matrix[j, col]);
                }

                if (col == n - col - 1 && m - row - 1 == row)
                    Console.WriteLine(matrix[row, col]);
            }
        }
    }
}
