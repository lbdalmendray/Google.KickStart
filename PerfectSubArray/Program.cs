using System;
using System.Collections.Generic;
using System.Linq;
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
                int N = ReadNumber();
                int[] numbers = ReadNumbers();
                var result = Solve(numbers);
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

        private static int Solve(int[] numbers)
        {
            int[] sum = new int[numbers.Length];
            sum[0] = numbers[0];
            for (int i = 1; i < numbers .Length; i++)
            {
                sum[i] = numbers[i] + sum[i - 1];
            }

            int result = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = i; j < numbers.Length; j++)
                {
                    int currentSum = sum[j] - (i - 1 > -1 ? sum[i - 1] : 0);
                    double sqrt = Math.Sqrt(currentSum);
                    int sqrtInt = (int)sqrt;
                    double sqrtIntDouble = sqrtInt;
                    if (sqrt == sqrtIntDouble)
                        result++;
                }
            }

            return result;
        }

        public static Func<string> ConsoleReadLine { get; set; } = Console.ReadLine;
        public static Action<object> ConsoleWriteLine { get; set; } = Console.WriteLine;

        public static int ReadNumber()
        {
            return int.Parse(ConsoleReadLine());
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
