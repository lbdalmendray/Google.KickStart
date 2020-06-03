using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workout
{
    class Solution
    {
        static void Main(string[] args)
        {
            int T = int.Parse(Console.ReadLine());

            for (int i = 1; i <= T; i++)
            {
                int[] NK = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                int N = NK[0];
                int K = NK[1];
                int[] Minutes = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                int result = Solve(Minutes, N, K);
                Console.WriteLine("Case #" + i.ToString() + ": " + result.ToString());
            }
        }

        private static int Solve(int[] minutes, int n, int k)
        {
            SortedDictionary<int, int> dict = new SortedDictionary<int, int>(Comparer<int>.Create(
               delegate (int a, int b)
               {
                   return b - a;
               }));

            for (int i = 1; i < minutes.Length; i++)
            {
                int diff = minutes[i] - minutes[i - 1];
                if (!dict.ContainsKey(diff))
                {
                    dict.Add(diff, 1);
                }
                else
                {
                    dict[diff]++;
                }
            }

            for (int i = 0; i < k; i++)
            {
                if (dict.Count == 1)
                    break;

                var firstSecond = dict.Take(2).ToArray();
                var first = firstSecond[0];
                var second = firstSecond[1];

                var firstValue = first.Key;
                var secondValue = second.Key;

                var secondValueIncrement = (firstValue / secondValue);
                var otherValue = firstValue % secondValue;

                var totalIncrement = first.Value * (secondValueIncrement + (otherValue > 0 ? 1 : 0));

                if (i + totalIncrement - 1 >= k)
                    break;

                i += totalIncrement - 1;
                dict[secondValue] += first.Value * (secondValueIncrement);

                if (otherValue > 0)
                {
                    if (!dict.ContainsKey(otherValue))
                    {
                        dict.Add(otherValue, first.Value);
                    }
                    else
                    {
                        dict[otherValue]+= first.Value;
                    }
                }

                dict.Remove(first.Key);
            }

            return dict.First().Key;
        }

        private static int Solve1(int[] minutes, int n, int k)
        {
            SortedDictionary<int, int> dict = new SortedDictionary<int, int>(Comparer<int>.Create(
               delegate (int a, int b)
                {
                    return b - a;
                }));

            for (int i = 1; i < minutes.Length; i++)
            {
                int diff = minutes[i] - minutes[i - 1];
                if (!dict.ContainsKey(diff))
                {
                    dict.Add(diff, 1);
                }
                else
                {
                    dict[diff]++;
                }
            }

            for (int i = 0; i < k ; i++)
            {
                var keyValue = dict.First();
                if (keyValue.Key == 1)
                    return 1;
                if( keyValue.Value == 1)
                {
                    dict.Remove(keyValue.Key);
                }
                else
                {
                    dict[keyValue.Key]--;
                }

                var diff = keyValue.Key;
                int newDiff1 = diff / 2;
                int newDiff2 = diff - newDiff1;

                if (!dict.ContainsKey(newDiff1))
                {
                    dict.Add(newDiff1, 1);
                }
                else
                {
                    dict[newDiff1]++;
                }

                if (!dict.ContainsKey(newDiff2))
                {
                    dict.Add(newDiff2, 1);
                }
                else
                {
                    dict[newDiff2]++;
                }
            }

            return dict.First().Key;

        }
    }
}
