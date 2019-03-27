using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training
{
    public class Solution
    {
        public static void Main(string[] args)
        {
            int T = int.Parse(Console.ReadLine());
            for (int i = 1; i <= T; i++)
            {
                var numbers = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                int N = numbers[0];
                int P = numbers[1];
                var Skills = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                var result = Solve(Skills,P);
                Console.WriteLine("Case #" + i.ToString() + ": " + result.ToString());
            }
        }

        public static int Solve(int [] Skills, int P)
        {
            Dictionary<int, int> skillGroups = new Dictionary<int, int>();
            foreach (var skill in Skills)
            {
                if (!skillGroups.ContainsKey(skill))
                    skillGroups.Add(skill, 0);
                skillGroups[skill] += 1;
            }

            var skillGroupArray = skillGroups.ToArray();
            Array.Sort(skillGroupArray.Select(e => e.Key).ToArray(), skillGroupArray);

            int result = int.MaxValue;

            for (int i = skillGroupArray.Length -1 ; i >= 0  ; i--)
            {
                int currentResult = 0;
                if (skillGroupArray[i].Value >= P)
                    return 0;
                int count = skillGroupArray[i].Value;
                for (int j = i-1; j >= 0 ; j--)
                {
                    if(skillGroupArray[j].Value >= P-count)
                    {
                        currentResult += (P - count) * (skillGroupArray[i].Key - skillGroupArray[j].Key);
                        count = P;
                        break;
                    }
                    else
                    {
                        count += skillGroupArray[j].Value;
                        currentResult += (skillGroupArray[j].Value) * (skillGroupArray[i].Key - skillGroupArray[j].Key);
                    }
                }
                if (count == P)
                {
                    if (currentResult < result)
                        result = currentResult;
                }
                else
                    break;                
            }

            return result;
        }
    }
}
