using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGuessing
{
    public class Solution
    {
        static void Main(string[] args)
        {
            int T = int.Parse(Console.ReadLine());
            bool wrongAnswer = false;
            for (int i = 1; i <= T; i++)
            {
                int [] bounds = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                int A = bounds[0] + 1;
                int B = bounds[1];
                int N = int.Parse(Console.ReadLine());
                while(true)
                {
                    int middle = (A + B) / 2;
                    Console.WriteLine(middle);
                    var response = Console.ReadLine();
                    if( response == "CORRECT")
                    {
                        break;
                    }
                    else if(response == "TOO_SMALL")
                    {
                        A = middle + 1;
                    }
                    else if (response == "TOO_BIG")
                    {
                        B = middle - 1;
                    }
                    else//else if (response == "WRONG_ANSWER")
                    {
                        wrongAnswer = true;
                        break;
                    }
                }
                if (wrongAnswer)
                {
                    break;
                }
            }
            
        }
    }
}
