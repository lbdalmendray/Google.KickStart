using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plates
{
    class Solution
    {
        static void Main(string[] args)
        {
            int T = int.Parse(Console.ReadLine());

            for (int i = 1; i <= T; i++)
            {
                int[] NKP = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                int N = NKP[0];
                int K = NKP[1];
                int P = NKP[2];
                int[][] stacks = new int[N][];
                for (int j = 0; j < N; j++)
                {
                    int[] beauties = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                    stacks[j] = beauties;
                }

                int result = Solve(stacks,P,K);
                Console.WriteLine("Case #" + i.ToString() + ": " + result.ToString());
            }
        }

        private static int Solve(int[][] stacks, int p , int k )
        {
            int?[,] infos = new int?[stacks.Length,p+1];

            for (int i = 1; i < k; i++)
            {
                for (int j = 0; j < stacks.Length; j++)
                {
                    stacks[j][i] += stacks[j][i - 1];
                }
            }

            return Calculate(0, stacks, p, k, infos);
        }

        private static int Calculate(int index, int[][] sums, int p, int k, int?[,] infos )
        {
            if (infos[index, p].HasValue)
                return infos[index, p].Value;
            int result;
            if (index == sums.Length - 1)
            {
                result = p > k ? int.MinValue : (p == 0 ? 0 : sums[index][p - 1]);
            }
            else
            {
                var restCount = (sums.Length - index - 1) * k;
                result = restCount < p ? int.MinValue : Calculate(index + 1, sums, p, k, infos);
                int pNew = p;
                for (int i = 0; i < k; i++)
                {
                    pNew--;
                    if (pNew < 0)
                        break;
                    int currentResult;
                    if (restCount < pNew)
                        currentResult = int.MinValue;
                    else
                    {
                        currentResult =  Calculate(index + 1, sums, pNew, k, infos);
                        currentResult += sums[index][i];
                    }
                    if (result < currentResult)
                        result = currentResult;
                }
            }
            infos[index, p] = result;
            return result;
        }
    }
}
