using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Dynamic;
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
                string program = ConsoleReadLine();
                int[] result = Solve(program);
                int w = result[1]+1;
                int h = result[0]+1;
                ConsoleWriteLine("Case #" + i.ToString() + ": " + w + " " + h);

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

        private static int[] Solve(string program)
        {
            int[] pos = new int[] { 0, 0 };
            LinkedList<Token> tokens = GenerateTokens(program);

            var tokenArray = tokens.ToArray();
            ProcessTokenArray(tokenArray);
            ExecuteProgram(tokenArray, 0, tokenArray.Length - 1, pos);

            return pos;
        }

        private static void ExecuteProgram(Token[] tokenArray, int index1, int index2, int[] pos)
        {
            if (index1 > index2)
                return;

            if ( tokenArray[index1].Type == Types.Movements  )
            {
                foreach (var movement in tokenArray[index1].Movements)
                {
                    Move(pos, movement);
                }
                ExecuteProgram(tokenArray, index1 + 1, index2, pos);
            }
            else if (tokenArray[index1].Type == Types.Number)
            {
                var token = tokenArray[index1];
                for (int i = 0; i < token.Number; i++)
                {
                    ExecuteProgram(tokenArray, index1 + 1, token.CPIndex - 1, pos);
                }
                ExecuteProgram(tokenArray, token.CPIndex+1, index2, pos);
            }
        }

        private static void ProcessTokenArray(Token[] tokenArray)
        {
            LinkedList<Token> positions = new LinkedList<Token>();
            for (int i = 0; i < tokenArray.Length; i++)
            {
                if (tokenArray[i].Type == Types.Number)
                    positions.AddLast(tokenArray[i]);
                else if ( tokenArray[i].Type == Types.CloseParenthesis)
                {
                    positions.Last.Value.CPIndex = i;
                    positions.RemoveLast();
                }
            }
        }

        private static int[] Solve1(string program)
        {
            int[] pos = new int[] { 0, 0 };
            LinkedList<Token> tokens = GenerateTokens(program);
            var movements = Calculate(tokens);

            foreach (var movement in movements)
            {
                Move(pos, movement);
            }

            return pos;
        }

        private static void Move(int[] pos, char movement)
        {
            int maxValue = 1000000000 - 1;

            int row = pos[0];
            int column = pos[1];
            if (movement == 'N')
            {
                if (row == 0)
                    row = maxValue;
                else
                    row = row - 1;
            }
            else if (movement == 'S')
            {
                if (row == maxValue)
                    row = 0;
                else
                    row = row + 1;
            }
            else if (movement == 'W')
            {
                if (column == 0)
                    column = maxValue;
                else
                    column = column - 1;
            }
            else // if (movement == 'E')
            {
                if (column == maxValue)
                    column = 0;
                else
                    column = column + 1;
            }

            pos[0] = row;
            pos[1] = column;
        }

        private static LinkedList<char> Calculate(LinkedList<Token> tokens)
        {
            var node = tokens.First;
            while (tokens.Count > 1)
            {
                var token = node.Value;

                if (token.Type == Types.Number)
                {
                    node = node.Next;
                }
                else if (token.Type == Types.Movements)
                {
                    node = ProcessMovementType(node, tokens);
                }
                else // ( token.Type == Types.CloseParenthesis )
                {
                    var movements =  node.Previous.Value.Movements;
                    var number = node.Previous.Previous.Value.Number;
                    var movementsCopy = movements.ToArray();
                    for (int i = 0; i < number - 1; i++)
                    {
                        foreach (var item in movementsCopy)
                        {
                            movements.AddLast(item);
                        }
                    }
                    tokens.Remove(node.Previous.Previous);
                    ProcessMovementType(node.Previous, tokens);
                    var nodeNext = node.Next;
                    tokens.Remove(node);
                    node = nodeNext;                    
                }
            }

            return tokens.First.Value.Movements;
        }

        private static LinkedListNode<Token> ProcessMovementType(LinkedListNode<Token> node, LinkedList<Token> tokens)
        {
            var nodeNext = node.Next;
            var token = node.Value;
            if (node.Previous != null && node.Previous.Value.Type == Types.Movements)
            {
                var currentMovements = token.Movements;
                var prevMovements = node.Previous.Value.Movements;
                foreach (var item in currentMovements)
                {
                    prevMovements.AddLast(item);
                }
                tokens.Remove(node);
            }
            else // NOTHING
            {

            }

            return nodeNext;
        }

        private static LinkedList<Token> GenerateTokens(string program)
        {
            LinkedList<Token> result = new LinkedList<Token>();
            for (int i = 0; i < program.Length; i++)
            {
                Token newToken = null;
                if (IsMovement(program[i]))
                {
                    newToken = new Token { Type = Types.Movements };
                    LinkedList<char> movements = new LinkedList<char>();
                    newToken.Movements = movements;
                    movements.AddLast(program[i]);
                    
                    int j = i + 1;
                    for (; j < program.Length; j++)
                    {
                        if (IsMovement(program[j]))
                        {
                            movements.AddLast(program[j]);
                        }
                        else
                        {
                            break;
                        }
                    }
                    j--;
                    i = j;
                }
                else if ( Char.IsDigit(program[i]) )
                {
                    int number = int.Parse(program[i].ToString());
                    i++;
                    newToken = new Token { Type = Types.Number , Number = number } ; 

                }
                else
                {
                    newToken = new Token { Type = Types.CloseParenthesis };
                }

                result.AddLast(newToken);
            }
            return result;
        }

        private static bool IsMovement(char v)
        {
            return new char[] { 'N', 'S', 'E', 'W' }.Contains(v);
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

    internal class Token
    {
        public Types Type { get; internal set; }
        public LinkedList<char> Movements { get; internal set; }
        public int Number { get; internal set; }
        public int CPIndex { get; internal set; }
    }

    internal enum Types
    {
        Movements,
        Number,
        CloseParenthesis
    }
}
