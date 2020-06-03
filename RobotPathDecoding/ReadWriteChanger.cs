using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionTemplate
{
    /// <summary>
    /// This ReadWriteChanger is a Base class to define what ConsoleReadLine and 
    /// ConsoleWriteLine has to be usufull . 
    /// </summary>
    public abstract class ReadWriteChanger
    {
        public ReadWriteChanger()
        {
            Solution.ConsoleReadLine = this.ConsoleReadLine;
            Solution.ConsoleWriteLine = this.ConsoleWriteLine;
        }
        public abstract string ConsoleReadLine();
        public abstract void ConsoleWriteLine(object obj);
    }
    public class ReadLinesChanger : ReadWriteChanger
    {
        string[] lines;
        int index = 0;
        public ReadLinesChanger(string [] lines)
        {
            this.lines = lines;
        }
        public override string ConsoleReadLine()
        {
            string result = lines[index];
            index++;
            if (index == lines.Length)
                index--;
            return result;            
        }
        public override void ConsoleWriteLine(object obj)
        {
            // DO NOTHING 
        }
    }
}
