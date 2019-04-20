using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvenDigits
{
    public class Solution
    {
        public static void Main(string[] args)
        {
            int T = int.Parse(Console.ReadLine());
            for (int i = 1; i <= T; i++)
            {
                var result = Solve();
                Console.WriteLine("Case #" + i.ToString() + ": " + result.ToString());
            }
        }

        public static ulong Solve()
        {
            
            var lastResult = ReadChar();
            while (!lastResult.isNewLine)
            {
                if (lastResult.value % 2 == 1)
                {
                    break;
                }

                lastResult = ReadChar();
            }

            if (lastResult.isNewLine)
                return 0;
            ulong subNumber = lastResult.value;
            ulong upNumber = subNumber != 9 ? (ulong)(subNumber + 1) : 2*((ulong)(subNumber + 1)) ;
            ulong downNumber = (ulong)(subNumber - 1);

            lastResult = ReadChar();
            while (!lastResult.isNewLine)
            {
                subNumber *= 10;
                subNumber += lastResult.value;

                upNumber *= 10;

                downNumber *= 10;
                downNumber += 8;

                lastResult = ReadChar();
            }

            var result1 = upNumber - subNumber ;
            var result2 = subNumber - downNumber;
            return Math.Min(result1, result2);

        }

        private static Result ReadChar()
        {
            int readResult = Console.Read();
            if(readResult == -1)
                return new Result { isNewLine = true };
            var result = (char)readResult;

            if( Environment.NewLine.Contains(result))
            {
                int count = 1;
                while(Environment.NewLine.Length > count)
                {
                    result = (char)Console.Read();
                    count++;
                }
                return new Result { isNewLine = true };
            }

            return new Result { value = ulong.Parse(result.ToString()) };
        }

        public static void Main1(string[] args)
        {
            int T = int.Parse(Console.ReadLine());
            for (int i = 1; i <= T; i++)
            {
                string nString = Console.ReadLine();
                int result = Solve1(nString);
                Console.WriteLine("Case #" + i.ToString() + ": " + result.ToString());
            }
        }

        public static int Solve1(string nString)
        {
            int[] digits = nString.Select(e => int.Parse(e.ToString())).ToArray();

            int firstOddIndex = -1;
            for (int i = 0; i < digits.Length; i++)
            {
                if (digits[i] % 2 == 1)
                {
                    firstOddIndex = i;
                    break;
                }
            }

            if (firstOddIndex == -1)
                return 0;

            int subNumber = int.Parse(new string(nString.Skip(firstOddIndex).ToArray()));

            int Pow10 = (int)Math.Pow(10, digits.Length - 1 - firstOddIndex);
            int nextNumber = digits[firstOddIndex] != 9 ? (digits[firstOddIndex]+1)*Pow10 : 2*(digits[firstOddIndex] + 1) * Pow10;
            int previousNumber = (digits[firstOddIndex] - 1) * Pow10;
            for (int i = 0; i < digits.Length - 1 - firstOddIndex; i++)
            {
                Pow10 /= 10;
                previousNumber += 8 * Pow10;
            }

            int result1 = Math.Abs(subNumber - nextNumber);
            int result2 = Math.Abs(subNumber - previousNumber);

            return Math.Min(result1, result2);
        }        
    }

    public class Result
    {
       public bool isNewLine ;
       public ulong value;
    }
}
