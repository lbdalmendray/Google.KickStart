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
                int[] numbers = ReadNumbers();
                int N = numbers[0];
                int K = numbers[1];
                numbers = ReadNumbers();
                int result = Solve(numbers, K);
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

        private static int Solve(int[] numbers, int k)
        {
            int before = 0;
            int result = 0;

            for (int i = numbers.Length - 1 ; i > -1 ; i--)
            {
                if (numbers[i] == before + 1)
                    before++;
                else if (numbers[i] == 1)
                    before = 1;
                else
                    before = 0;
                if (before == k)
                    result++;
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
