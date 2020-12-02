using System;
using System.Diagnostics;

namespace Argon
{
    public class Methods
    {
        protected ArgonLine scriptLine;
        protected string[] methods = { "print", "println", "font" , "start" };
        public Methods(ArgonLine scriptLine)
        {
            this.scriptLine = scriptLine;
        }
        public void Execute()
        {
            foreach(string methodSingle in methods)
            {
                if (scriptLine.GetMethod().Contains(methodSingle))
                {
                    ExecuteThing(methodSingle);
                }
            }
        }
        public virtual void ExecuteThing(string methodSingle)
        {
            switch (methodSingle)
            {
                case "print": Console.Write("Say: " + scriptLine.GetParameters()[0]); break;
                case "println": Console.WriteLine("Say: " + scriptLine.GetParameters()[0]); break;
                case "font":
                    ConsoleColor color = Console.ForegroundColor;
                    switch(scriptLine.GetParameters()[0])
                    {
                        case "red": color = ConsoleColor.Red; break;
                        case "dark-red": color = ConsoleColor.DarkRed; break;
                        case "yellow": color = ConsoleColor.Yellow; break;
                        case "dark-yellow": color = ConsoleColor.DarkYellow; break;
                        case "green": color = ConsoleColor.Green; break;
                        case "dark-green": color = ConsoleColor.DarkGreen; break;
                        case "blue": color = ConsoleColor.Blue; break;
                        case "dark-blue":color = ConsoleColor.DarkBlue;break;
                    }
                    Console.ForegroundColor = color;
                    break;
                case "start":
                    ProcessStartInfo psi = new ProcessStartInfo();
                    psi.FileName = scriptLine.GetParameters()[0];
                    psi.Arguments = scriptLine.GetParameters()[1];
                    Process.Start(psi);
                    break;
                default: Error error = new Error("Unexist method", new ArgumentException()); break;
            }
        }
    }
}
