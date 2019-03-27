using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcels
{
    public class Solution
    {
        public static void Main(string[] args)
        {
            int T = int.Parse(Console.ReadLine());
            for (int i = 1; i <= T; i++)
            {
                var numbers = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                int R = numbers[0];
                int C = numbers[1];
                bool[,] squares = new bool[R, C];

                for (int j = 0; j < R; j++)
                {
                    var line = Console.ReadLine();
                    for (int k = 0; k < C; k++)
                    {
                        squares[j, k] = line[k] == '1';
                    }
                }

                var result = Solve(squares);
                Console.WriteLine("Case #" + i.ToString() + ": " + result.ToString());
            }
        }

        public static int Solve(bool[,] squares)
        {
            LinkedList<PosDistance> empties = new LinkedList<PosDistance>();
            LinkedList<Position> offices = new LinkedList<Position>();


            for (int i = 0; i < squares.GetLength(0); i++)
            {
                for (int j = 0; j < squares.GetLength(1); j++)
                {
                    if (!squares[i, j])
                        empties.AddLast(new PosDistance(i, j, int.MaxValue));
                    else
                        offices.AddLast(new Position(i, j));
                }
            }

            int max = GetMaxDistance(empties, offices);

            foreach (var empty in empties.ToArray())
            {
                int currentMax = GetMaxDistanceNoChange(empties, empty);
                if (currentMax < max)
                    max = currentMax;
            }

            return max;
        }

        private static int GetMaxDistanceNoChange(LinkedList<PosDistance> empties, Position office)
        {
            int result = 0;
            foreach (var empty in empties)
            {
                int currentDistance = Math.Min(empty.Distance, GetMaxDistance(empty, office));
                if (currentDistance > result)
                    result = currentDistance;
            }

            return result;
        }

        private static int GetMaxDistance(LinkedList<PosDistance> empties, LinkedList<Position> offices)
        {
            int result = 0;
            foreach (var office in offices)
            {
                foreach (var empty in empties)
                {
                    int currentDistance = GetMaxDistance(empty, office);
                    if (currentDistance < empty.Distance)
                        empty.Distance = currentDistance;
                    if (currentDistance > result)
                        result = currentDistance;
                }
            }

            return result;
        }

        private static int GetMaxDistance(PosDistance empty, Position office)
        {
            return Math.Abs(empty.X - office.X) + Math.Abs(empty.Y - office.Y);
        }
    }

    public class Position
    {
        public int X;
        public int Y;
        public Position(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }

    public class PosDistance : Position
    {
        public int Distance;
        public PosDistance(int x, int y, int Distance) :
            base(x, y)
        {
            this.Distance = Distance;
        }
    }
}
