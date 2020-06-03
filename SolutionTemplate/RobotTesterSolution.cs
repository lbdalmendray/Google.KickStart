using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionTemplate
{
    public class RobotTesterSolution : ReadWriteChanger
    {
        private string initLine;
        private string[] inputLines;
        private int inputLinesIndex = 0;
        private string[] outputLines;
        private int outputLinesIndex = 0;
        private States currentState;
        private Type typeSolution; // This represent the static class solution
        public RobotTesterSolution(Type typeSolution, string initLine , string[] inputLines , string [] outputLines )
        {
            this.initLine = initLine;
            this.inputLines = inputLines;
            this.outputLines = outputLines;

            if (initLine == null)
                currentState = States.InputLine;
            else
                currentState = States.InitLine;

            this.typeSolution = typeSolution;
        }
        public override string ConsoleReadLine()
        {
            if (currentState == States.InitLine)
            {
                currentState = States.InputLine;
                return initLine;
            }
            else if ( currentState == States.InputLine)
            {
                currentState = States.OutputLine;
                if (inputLinesIndex == inputLines.Length)
                {
                    throw new Exception();
                    //while (true) { }
                }
                string result = inputLines[inputLinesIndex];
                inputLinesIndex++;
                return result;
            }
            else // CurrentState == States.OutputLine  || CurrentState == States.AfterBadAnswer
            {
                throw new Exception();
                //while (true) { }
            }
        }

        public override void ConsoleWriteLine(object obj)
        {
            if (currentState == States.InitLine)
            {
                throw new Exception();
                //while (true) { }
            }
            else if (currentState == States.InputLine)
            {
                throw new Exception();
                //while (true) { }                
            }
            else if ( currentState == States.OutputLine)
            {
                currentState = States.InputLine;
                if (outputLinesIndex == outputLines.Length)
                {
                    throw new Exception();
                    //while (true) { }
                }
                string result = outputLines[outputLinesIndex];
                outputLinesIndex++;
                string stringObj = obj as string;
                if ( result == stringObj)
                {
                    // DO NOTHING 
                }
                else
                {
                    currentState = States.AfterBadAnswer;
                }
            }
            else // CurrentState == States.AfterBadAnswer
            {
                throw new Exception();
            }
        }

        public bool Execute()
        {
            try
            {
                var consoleReadLineProperty = typeSolution.GetProperty("ConsoleReadLine");
                consoleReadLineProperty.GetSetMethod().Invoke(null, new object[] { (Func<string>)ConsoleReadLine });

                var consoleWriteLineProperty = typeSolution.GetProperty("ConsoleWriteLine");
                consoleWriteLineProperty.GetSetMethod().Invoke(null, new object[] { (Action<object>)ConsoleWriteLine });

                var main = typeSolution.GetMethod("Main");
                main.Invoke(null, new object[] { null });

                /*
                 Solution.ConsoleReadLine = ConsoleReadLine;
                Solution.ConsoleWriteLine = ConsoleWriteLine;
                Solution.Main(null);
                */
                if (currentState == States.AfterBadAnswer
                    || inputLinesIndex < inputLines.Length
                    || outputLinesIndex < outputLines.Length)
                    return false;
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        private enum States
        {
            InitLine,
            InputLine,
            OutputLine,
            AfterBadAnswer
        }
    }
}
