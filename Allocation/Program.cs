using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allocation
{
    public class Solution
    {
        public static void Main(string[] args)
        {
            int T = int.Parse(Console.ReadLine());

            for (int i = 1; i <= T; i++)
            {
                int[] NandB = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                int N = NandB[0];
                int B = NandB[1];
                int[] Avalues = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                var result = Solve(Avalues, B);
                Console.WriteLine("Case #" + i.ToString() + ": " + result.ToString());
            }
        }

        private static int Solve(int[] avalues, int b)
        {
            int result = 0;

            Array.Sort(avalues);

            int sum = 0;
            for (int i = 0; i < avalues.Length; i++)
            {
                sum += avalues[i];
                if (sum > b)
                    break;
                result++;
            }           

            return result;
        }
    }
}
