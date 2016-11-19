using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SubMatrixSumZero
{
    public class Program
    {
        public static void Main(string[] args)
        {

            // var m = new int[,] { { } };
            // answer [null, null]
            var m = new int[,] {
                                  {1, 5, 7 },
                                  {3, 7, -8},
                                  { 4, -8, 9},
                                };

            // answer: [[1,1],[2,2]]

            var re1 = SubSumZero(m);
        }

        public static int[][] SubSumZero(int[,] matrix)
        {
            var res = new int[2][];

            var m = matrix.GetLength(0);
            if (m == 0)
                return res;
            var n = matrix.GetLength(1);

            for(var i = 0;i<n;i++)
            {
                var sum = new int[m];

                for (var j = i; j < n; j++)
                {
                    for (int k = 0; k < m; k++)
                    {
                        sum[k] += matrix[k, j];
                    }

                    var map = new Dictionary<int, int>();
                    map.Add(0, -1);
                    var lastSum = 0;

                    for (int k = 0; k < m; k++)
                    {
                        lastSum += sum[k];

                        if (map.ContainsKey(lastSum))
                        { // if we see a sum that we saw previously, that means that all rows between now and then add up to 0
                            res[0] = new int[] { map[lastSum] + 1, i };
                            res[1] = new int[] { k, j };

                            return res;
                        }
                        else
                        {
                            map.Add(lastSum, k);
                        }
                    }
                }
            }


            return res;
        }
    }
}
