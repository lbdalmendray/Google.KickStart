using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SolutionTemplate
{
    public class Solution
    {
        public static void Main(string[] args)
        {
            int T = ReadNumber();
            for (int i = 1; i <= T; i++)
            {
                BigInteger[] numbers = ReadBigIntegeNumbers();
                BigInteger N = numbers[0];
                BigInteger D = numbers[1];
                BigInteger[] Days = ReadBigIntegeNumbers();
                BigInteger result = Solve(Days, D);
                ConsoleWriteLine("Case #" + i.ToString() + ": " + result.ToString());
                /*                
                int [] numbers = ReadNumbers();
                int a = numbers[0];
                int b = numbers[1];
                string[] strings = ReadStrings();
                string string1 = strings[0];
                string string2 = strings[1];
                var result = Solve(a, b, string1, string2);
                ConsoleWriteLine("Case #" + i.ToString() + ": " + result.ToString());
                */
            }
        }

        private static BigInteger Solve(BigInteger[] days, BigInteger d)
        {
            for (int i = days.Length -1 ; i > 0; i--)
            {
                d = Solve(days, i, d);
            }
            
            return Solve(days, 0, d);
        }

        private static BigInteger Solve(BigInteger[] days, int i, BigInteger d)
        {
            BigInteger day = days[i];
            BigInteger value = d / day;
            return value * day;
        }

        private static int Solve1(int[] days, int d)
        {
            bool?[,] infos = new bool?[days.Length, d + 1];

            for (int i = days.Length - 1; i > 0; i--)
            {
                for (int j = d; j > 0; j--)
                {
                    Solve(i, j, infos, days, d);
                }
            }

            for (int j = d; j > 0; j--)
            {
                if (Solve(0, j, infos, days, d))
                    return j;
            }

            return 0;
        }

        private static bool Solve(int i, int j, bool? [,] infos, int[] days, int d)
        {
            if (i >= days.Length)
            {
                return true;
            }

            if (infos[i, j].HasValue)
                return infos[i, j].Value;

            var period = days[i];

            if( j%period != 0 )
            {
                infos[i, j] = false;
                return false;
            }

            for (int k = d; k >= j; k--)
            {
                var cResult = Solve(i + 1, k, infos, days, d);
                if ( cResult )
                {
                    infos[i, j] = true;
                    return true;
                }
            }

            infos[i, j] = false;
            return false;
        }

        public static Func<string> ConsoleReadLine { get; set; } = Console.ReadLine;
        public static Action<object> ConsoleWriteLine { get; set; } = Console.WriteLine;

        public static int ReadNumber()
        {
            return int.Parse(ConsoleReadLine());
        }

        public static BigInteger[] ReadBigIntegeNumbers()
        {
            var splitParts = ConsoleReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return splitParts.Select(e => BigInteger.Parse(e)).ToArray();
        }

        public static int[] ReadNumbers()
        {
            var splitParts = ConsoleReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return splitParts.Select(e => int.Parse(e)).ToArray();
        }

        public static string[] ReadStrings()
        {
            return ConsoleReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
