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
                int R = numbers[0];
                int C = numbers[1];
                char[,] wall = new char[R, C];
                for (int j = 0; j < R; j++)
                {
                    string line = ConsoleReadLine();
                    for (int k = 0; k < line.Length; k++)
                    {
                        wall[j, k] = line[k];
                    }
                }

                string result = Solve(wall);
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

        public static string Solve(char[,] wall)
        {

            ///// CREATING SHAPE POSITIONS 
            Dictionary<char, HashSet<Tuple<int, int>>> shapePositions = new Dictionary<char, HashSet<Tuple<int, int>>>();

            for (int i = 0; i < wall.GetLength(0); i++)
            {
                for (int j = 0; j < wall.GetLength(1); j++)
                {
                    HashSet<Tuple<int, int>> hash = null;
                    if ( shapePositions.TryGetValue(wall[i,j],out hash))
                    {
                        hash.Add(new Tuple<int, int>(i, j));
                    }
                    else
                    {
                        hash = new HashSet<Tuple<int, int>>();
                        shapePositions.Add(wall[i, j], hash);
                        hash.Add(new Tuple<int, int>(i, j));
                    }
                }
            }

            /////////// GENERATING GRAPH

            HashSet<int>[] graph = new HashSet<int>[shapePositions.Keys.Count];
            var array = shapePositions.ToArray();
            for (int i = 0; i < array.Length; i++)
            {
                graph[i] = new HashSet<int>();
            }

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length; j++)
                {
                    if (i == j)
                        continue;
                    foreach (var pos in array[i].Value)
                    {
                        var x = pos.Item1;
                        var y = pos.Item2;
                        if (array[j].Value.Contains(new Tuple<int, int>(x - 1, y)))
                            graph[j].Add(i);
                    }
                }
            }

            LinkedList<int> result = new LinkedList<int>();
            bool[] selected = new bool[graph.Length];
            while(result.Count < graph.Length)
            {
                bool selectedOne = false;
                for (int i = 0; i < graph.Length; i++)
                {
                    if (selected[i])
                        continue;
                    if ( graph[i].Count == 0)
                    {
                        selected[i] = true;
                        selectedOne = true;
                        result.AddLast(i);
                        for (int k = 0; k < graph.Length; k++)
                        {
                            if (k == i)
                                continue;
                            if (graph[k].Contains(i))
                                graph[k].Remove(i);
                        }
                    }
                }

                if (!selectedOne)
                    break;
            }

            if ( result.Count == graph.Length)
            {
                var charResult = result.Select(e => array[e].Key);
                return new string(charResult.ToArray());
            }
            return (-1).ToString();
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
