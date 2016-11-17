using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZigZagConversion
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var str = "paypalishiring";
            var rowCount = 1;

            var result = ConvertFirstTry(str, rowCount);
            var res = Convert(str, rowCount);

            Console.WriteLine(result);
            Console.ReadKey();
        }

        public static string ConvertFirstTry(string str, int rowCount)
        {
            if (str == null)
                throw new ArgumentNullException(nameof(str));

            if (str.Length <= 1 || rowCount <= 1)
                return str;

            var result = new StringBuilder();

            var secColIdxBase = 2 * rowCount - 2;

            for (int m = 0; m < rowCount; m++)
            {
                var colIdx = m;
                var secColIdx = secColIdxBase;

                while (colIdx < str.Length)
                {
                    result.Append(str[colIdx]);
                    Debug.Write(colIdx + " ");

                    if (secColIdx < str.Length && secColIdx < colIdx + 2 * rowCount - 2 && secColIdx > colIdx)
                    {
                        result.Append(str[secColIdx]);
                        Debug.Write(secColIdx + " ");
                    }

                    colIdx += 2 * rowCount - 2;
                    secColIdx += 2 * rowCount - 2;
                }

                secColIdxBase--;
            }

            return result.ToString();
        }

        public static string Convert(string s, int numRows)
        {
            int n = s.Length;
            if (n <= 1 || numRows <= 1) return s;
            StringBuilder res = new StringBuilder();
            for (int i = 0; i < numRows; ++i)
            {
                for (int j = 0; j + i < n; j += 2 * numRows - 2)
                {
                    res.Append(s[j + i]);
                    Debug.Write(j + i + " ");
                    if (i == 0 || i == numRows - 1) continue;
                    if (j + 2 * numRows - 2 - i < n)
                    {
                        res.Append(s[j + 2 * numRows - 2 - i]);
                        Debug.Write(j + 2 * numRows - 2 - i + " ");
                    }
                }
            }
            return res.ToString();
        }
    }
}
