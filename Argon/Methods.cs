using System;
using System.Diagnostics;

namespace Argon
{
    public class Methods
    {
        protected ArgonLine scriptLine;
        protected string[] methods = { "print.line", "print", "font" , "start" , "file.write.line", "file.write", "file.read.line","file.read", "var"};
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
                    break;
                }
            }
        }
        public virtual void ExecuteThing(string methodSingle)
        {
            FileManager fileManager = new FileManager(null);
            switch (methodSingle)
            {
                case "print":
                    if (scriptLine.GetParameters()[0].Contains("$") && Memory.VarList.ContainsKey(scriptLine.GetParameters()[0].TrimStart(new char[] { '$' })))
                    {
                        Console.Write(Memory.VarList[scriptLine.GetParameters()[0].TrimStart(new char[] { '$'})]);
                    }
                    else
                    {
                        Console.Write(scriptLine.GetParameters()[0]);
                    }
                    break;
                case "print.line":
                    if (scriptLine.GetParameters()[0].Contains("$") && Memory.VarList.ContainsKey(scriptLine.GetParameters()[0].TrimStart(new char[] { '$' })))
                    {
                        Console.WriteLine(Memory.VarList[scriptLine.GetParameters()[0].TrimStart(new char[] { '$' })]);
                    }
                    else
                    {
                        Console.WriteLine(scriptLine.GetParameters()[0]);
                    }
                    break;
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
                        case "white":color = ConsoleColor.White;break;
                    }
                    Console.ForegroundColor = color;
                    break;
                case "start":
                    ProcessStartInfo psi = new ProcessStartInfo();
                    psi.FileName = scriptLine.GetParameters()[0];
                    psi.Arguments = scriptLine.GetParameters()[1];
                    Process.Start(psi);
                    break;
                case "file.write":
                    if (scriptLine.GetParameters()[0].Contains("$") && Memory.VarList.ContainsKey(scriptLine.GetParameters()[0].TrimStart(new char[] { '$' })))
                    {
                        fileManager.SetFile(Memory.VarList[scriptLine.GetParameters()[0].TrimStart(new char[] { '$' })]);
                    }
                    else
                    {
                        fileManager.SetFile(scriptLine.GetParameters()[0]);
                    }
                    if (scriptLine.GetParameters()[1].Contains("$") && Memory.VarList.ContainsKey(scriptLine.GetParameters()[1].TrimStart(new char[] { '$' })))
                    {
                        fileManager.Write(Memory.VarList[scriptLine.GetParameters()[1].TrimStart(new char[] { '$' })]);
                    }
                    else
                    {
                        fileManager.Write(scriptLine.GetParameters()[1]);
                    }
                    break;
                case "file.write.line":
                    if (scriptLine.GetParameters()[0].Contains("$") && Memory.VarList.ContainsKey(scriptLine.GetParameters()[0].TrimStart(new char[] { '$' })))
                    {
                        fileManager.SetFile(Memory.VarList[scriptLine.GetParameters()[0].TrimStart(new char[] { '$' })]);
                    }
                    else
                    {
                        fileManager.SetFile(scriptLine.GetParameters()[0]);
                    }
                    if (scriptLine.GetParameters()[1].Contains("$") && Memory.VarList.ContainsKey(scriptLine.GetParameters()[1].TrimStart(new char[] { '$' })))
                    {
                        fileManager.WriteLine(Memory.VarList[scriptLine.GetParameters()[1].TrimStart(new char[] { '$' })]);
                    }
                    else
                    {
                        fileManager.WriteLine(scriptLine.GetParameters()[1]);
                    }
                    break;
                case "file.read":
                    if (scriptLine.GetParameters()[0].Contains("$") && Memory.VarList.ContainsKey(scriptLine.GetParameters()[0].TrimStart(new char[] { '$' })))
                    {
                        fileManager.SetFile(Memory.VarList[scriptLine.GetParameters()[0].TrimStart(new char[] { '$' })]);
                    }
                    else
                    {
                        fileManager.SetFile(scriptLine.GetParameters()[0]);
                    }
                    Memory.FileReaded = fileManager.Read();
                    if(Memory.VarList.ContainsKey(scriptLine.GetParameters()[1]))
                    {
                        Memory.VarList[scriptLine.GetParameters()[1]] = Memory.FileReaded;
                    }
                    else
                    {
                        Memory.VarList.Add(scriptLine.GetParameters()[1], Memory.FileReaded);
                    }
                    break;
                case "file.read.line":
                    if (scriptLine.GetParameters()[0].Contains("$") && Memory.VarList.ContainsKey(scriptLine.GetParameters()[0].TrimStart(new char[] { '$' })))
                    {
                        fileManager.SetFile(Memory.VarList[scriptLine.GetParameters()[0].TrimStart(new char[] { '$' })]);
                    }
                    else
                    {
                        fileManager.SetFile(scriptLine.GetParameters()[0]);
                    }
                    Memory.FileReaded = fileManager.ReadLine();
                    if (Memory.VarList.ContainsKey(scriptLine.GetParameters()[1]))
                    {
                        Memory.VarList[scriptLine.GetParameters()[1]] = Memory.FileReaded;
                    }
                    else
                    {
                        Memory.VarList.Add(scriptLine.GetParameters()[1], Memory.FileReaded);
                    }
                    break;
                case "var":
                    string varEquals = "null";
                    if(scriptLine.GetParameters().Length > 1)
                    {
                        varEquals = scriptLine.GetParameters()[1];
                    }
                    Memory.VarList.Add(scriptLine.GetParameters()[0],varEquals);
                    //Console.WriteLine(scriptLine.GetParameters()[0] + " set to " + varEquals);
                    break;

                default: Error error = new Error("Unexist method", new ArgumentException()); break;
            }
        }
    }
}
