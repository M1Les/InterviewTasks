using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HistogramTrappingWater
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(TotalVol(new int[] { 1, 5, 3, 0, 6, 9, 8, 2, 3, 4, 5, 4, 3, 2, 0, 7, 10, 5, 3, 3, 2, 3, 7 }));
            Console.ReadKey();
        }

        public static int HistogramFunc(int x)
        {
            var vals = new int[] { 1, 5, 3, 0, 6, 9, 8, 2, 3, 4, 5, 4, 3, 2, 0, 7, 10, 5, 3, 3, 2, 3, 7 }; // 22 // 52
            //{ 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1}; //4
            return vals[x];
        }

        /// <summary>
        /// Two passes to determine maximum element to the left of every element
        /// and maximum element to the right of every element, including the element.
        /// An element can hold water iif max left and max right for it are larger than the element itself.
        /// </summary>
        /// <param name="vals"></param>
        /// <returns></returns>
        public static int TotalVol(int[] vals)
        {
            if (vals.Length == 0)
                return 0;

            int[] left = new int[vals.Length];
            int[] right= new int[vals.Length];
            int runningMaxY = 0;
            int totalWater = 0;

            for (int i = 0; i < vals.Length; i ++)
            {
                runningMaxY = Math.Max(runningMaxY, vals[i]);
                left[i] = runningMaxY;
            }

            runningMaxY = 0;
            for (int i = vals.Length-1; i >=0; i--)
            {
                runningMaxY = Math.Max(runningMaxY, vals[i]);
                right[i] = runningMaxY;
            }

            for (int i = 0; i < vals.Length; i++)
            {
                var y = vals[i];

                totalWater += Math.Min(left[i], right[i]) - vals[i];
            }

            return totalWater;
        }

        //public static int MaxVolOnePass(Func<int, int> h, int minX, int maxX)
        //{
        //    int runningMaxY = 0;
        //    int runningMaxVol = 0;
        //    int maxVol = 0;

        //    for (int x = minX; x <= maxX; x++)
        //    {
        //        var y = h(x);
        //        if (y >= runningMaxY)
        //        {
        //            runningMaxY = y;

        //            if (runningMaxVol > maxVol)
        //            {
        //                maxVol = runningMaxVol;
        //                runningMaxVol = 0;
        //            }
        //        }
        //        else
        //        {
        //            runningMaxVol += runningMaxY - y;
        //        }
        //    }

        //    return maxVol;
        //}

        //public static int TotalVolOnePass(Func<int, int> h, int minX, int maxX)
        //{
        //    int runningMaxY = 0;
        //    int runningMaxVol = 0;
        //    int totalVol = 0;

        //    for (int x = minX; x <= maxX; x++)
        //    {
        //        var y = h(x);
        //        if (y >= runningMaxY)
        //        {
        //            runningMaxY = y;
        //            totalVol += runningMaxVol;
        //            runningMaxVol = 0;
        //        }
        //        else
        //        {
        //            runningMaxVol += runningMaxY - y;
        //        }
        //    }

        //    return totalVol;
        //}

        //public static int MaxWater(int[] arr)
        //{
        //    int len = arr.Length;
        //    if (len == 0) return 0;

        //    int leftMax = 0;
        //    int rightMax = 0;
        //    int water = 0;
        //    int[] dp = new int[len];
        //    // from left
        //    for (int i = 0; i < len - 1; i++)
        //    {
        //        dp[i] = leftMax;
        //        if (arr[i] > leftMax)
        //        {
        //            leftMax = arr[i];
        //        }
        //    }
        //    // from right
        //    for (int i = len - 1; i >= 0; i--)
        //    {
        //        if (Math.Min(dp[i], rightMax) > arr[i])
        //        {
        //            water += Math.Min(dp[i], rightMax) - arr[i];
        //        }
        //        if (arr[i] > rightMax)
        //        {
        //            rightMax = arr[i];
        //        }
        //    }

        //    return water;
        //}
    }
}
