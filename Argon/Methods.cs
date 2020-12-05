using System;
using System.Diagnostics;

namespace Argon
{
    public class Methods
    {
        protected ArgonLine scriptLine;
        protected string[] methods = {"//", "print.line", "print", "font" , "file.write.line", "file.write", "file.read.line","file.read", "var" , "function.external", "if" , "function.open" , "function.close","function", "start" };
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
            Error error;
            switch (methodSingle)
            {
                case "print":
                    if (Memory.LockedCode == false)
                    {
                        if (scriptLine.GetParameters()[0].Contains("$") && Memory.VarList.ContainsKey(scriptLine.GetParameters()[0].TrimStart(new char[] { '$' })))
                        {
                            Console.Write(Memory.VarList[scriptLine.GetParameters()[0].TrimStart(new char[] { '$' })]);
                        }
                        else
                        {
                            Console.Write(scriptLine.GetParameters()[0]);
                        }
                    }
                    break;
                case "print.line":
                    if (Memory.LockedCode == false)
                    {
                        if (scriptLine.GetParameters()[0].Contains("$") && Memory.VarList.ContainsKey(scriptLine.GetParameters()[0].TrimStart(new char[] { '$' })))
                        {
                            Console.WriteLine(Memory.VarList[scriptLine.GetParameters()[0].TrimStart(new char[] { '$' })]);
                        }
                        else
                        {
                            Console.WriteLine(scriptLine.GetParameters()[0]);
                        }
                    }
                    break;
                case "font":
                    if (Memory.LockedCode == false)
                    {
                        ConsoleColor color = Console.ForegroundColor;
                        switch (scriptLine.GetParameters()[0])
                        {
                            case "red": color = ConsoleColor.Red; break;
                            case "dark-red": color = ConsoleColor.DarkRed; break;
                            case "yellow": color = ConsoleColor.Yellow; break;
                            case "dark-yellow": color = ConsoleColor.DarkYellow; break;
                            case "green": color = ConsoleColor.Green; break;
                            case "dark-green": color = ConsoleColor.DarkGreen; break;
                            case "blue": color = ConsoleColor.Blue; break;
                            case "dark-blue": color = ConsoleColor.DarkBlue; break;
                            case "white": color = ConsoleColor.White; break;
                        }
                        Console.ForegroundColor = color;
                    }
                    break;
                case "start":
                    if (Memory.LockedCode == false)
                    {
                        ProcessStartInfo psi = new ProcessStartInfo();
                        psi.FileName = scriptLine.GetParameters()[0];
                        psi.Arguments = scriptLine.GetParameters()[1];
                        Process.Start(psi);
                    }
                    break;
                case "file.write":
                    if (Memory.LockedCode == false)
                    {
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
                    }
                    break;
                case "file.write.line":
                    if (Memory.LockedCode == false)
                    {
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
                    }
                    break;
                case "file.read":
                    if (Memory.LockedCode == false)
                    {
                        if (scriptLine.GetParameters()[0].Contains("$") && Memory.VarList.ContainsKey(scriptLine.GetParameters()[0].TrimStart(new char[] { '$' })))
                        {
                            fileManager.SetFile(Memory.VarList[scriptLine.GetParameters()[0].TrimStart(new char[] { '$' })]);
                        }
                        else
                        {
                            fileManager.SetFile(scriptLine.GetParameters()[0]);
                        }
                        Memory.FileReaded = fileManager.Read();
                        if (Memory.VarList.ContainsKey(scriptLine.GetParameters()[1]))
                        {
                            Memory.VarList[scriptLine.GetParameters()[1]] = Memory.FileReaded;
                        }
                        else
                        {
                            Memory.VarList.Add(scriptLine.GetParameters()[1], Memory.FileReaded);
                        }
                    }
                    break;
                case "file.read.line":
                    if (Memory.LockedCode == false)
                    {
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
                    }
                    break;
                case "var":
                    if (Memory.LockedCode == false)
                    {
                        string varEquals = "null";
                        if (scriptLine.GetParameters().Length > 1)
                        {
                            varEquals = scriptLine.GetParameters()[1];
                        }
                        Memory.VarList.Add(scriptLine.GetParameters()[0], varEquals);
                    }
                    //Console.WriteLine(scriptLine.GetParameters()[0] + " set to " + varEquals);
                    break;
                case "function.external":
                    if (Memory.LockedCode == false)
                    {
                        string callName = "null";
                        if (scriptLine.GetParameters()[0].Contains("$") && Memory.VarList.ContainsKey(scriptLine.GetParameters()[0].TrimStart(new char[] { '$' })))
                        {
                            callName = Memory.VarList[scriptLine.GetParameters()[0].TrimStart(new char[] { '$' })];
                        }
                        else
                        {
                            callName = scriptLine.GetParameters()[0];
                        }
                        fileManager.SetFile(callName + ".arns");
                        if (fileManager.Exists() == true)
                        {
                            //Starts new thread of excution
                            Interpreter callInterpreter = new Interpreter(fileManager.Read());
                            callInterpreter.Run();
                        }
                        else
                        {
                            error = new Error(scriptLine.GetParameters()[0]);
                        }
                    }
                    break;
                case "if":
                    if (Memory.LockedCode == false)
                    {
                        string[] conditions = new string[2];
                        if (scriptLine.GetParameters()[0].Contains("$") && Memory.VarList.ContainsKey(scriptLine.GetParameters()[0].TrimStart(new char[] { '$' })))
                        {
                            conditions[0] = Memory.VarList[scriptLine.GetParameters()[0].TrimStart(new char[] { '$' })];
                        }
                        else
                        {
                            conditions[0] = scriptLine.GetParameters()[0];
                        }
                        if (scriptLine.GetParameters()[2].Contains("$") && Memory.VarList.ContainsKey(scriptLine.GetParameters()[2].TrimStart(new char[] { '$' })))
                        {
                            conditions[1] = Memory.VarList[scriptLine.GetParameters()[2].TrimStart(new char[] { '$' })];
                        }
                        else
                        {
                            conditions[1] = scriptLine.GetParameters()[2];
                        }
                        bool conditionResult = false;
                        switch (scriptLine.GetParameters()[1])
                        {
                            case ">":
                                if (Int32.Parse(conditions[0]) > Int32.Parse(conditions[1]))
                                {
                                    conditionResult = true;
                                }
                                break;
                            case ">=":
                                if (Int32.Parse(conditions[0]) > Int32.Parse(conditions[1]))
                                {
                                    conditionResult = true;
                                }
                                break;
                            case "==":
                                if (conditions[0] == conditions[1])
                                {
                                    conditionResult = true;
                                }
                                break;
                            case "!=":
                                if (conditions[0] != conditions[1])
                                {
                                    conditionResult = true;
                                }
                                break;
                            case "<=":
                                if (Int32.Parse(conditions[0]) <= Int32.Parse(conditions[1]))
                                {
                                    conditionResult = true;
                                }
                                break;
                            case "<":
                                if (Int32.Parse(conditions[0]) < Int32.Parse(conditions[1]))
                                {
                                    conditionResult = true;
                                }
                                break;
                        }
                        if(conditionResult == true)
                        {
                            if(scriptLine.GetParameters()[3].Contains("()"))
                            {
                                Interpreter interpreter = new Interpreter(Memory.FunctionList[scriptLine.GetParameters()[3].TrimEnd(new char[] { '(', ')' })]);
                                interpreter.Run();
                            }
                        }

                    }
                    break;
                case "function.open":
                    if(Memory.FunctionList.ContainsKey(scriptLine.GetParameters()[0]))
                    {
                        error = new Error("Override error");
                    }
                    else
                    {
                        Memory.FunctionList.Add(scriptLine.GetParameters()[0],"null");
                        Function function = new Function(scriptLine.GetParameters()[0], Memory.CurrentFile);
                        function.Detect();
                        //Console.WriteLine(Memory.FunctionList[scriptLine.GetParameters()[0]]);
                        Memory.LockedCode = true;
                    }

                    break;
                case "function.close":
                    Memory.LockedCode = false;
                break;
                case "function":
                    if (Memory.LockedCode == false)
                    {
                        if (scriptLine.GetParameters()[0].Contains("()"))
                        {
                            Interpreter interpreter = new Interpreter(Memory.FunctionList[scriptLine.GetParameters()[0].TrimEnd(new char[] { '(', ')' })]);
                            interpreter.Run();
                        }
                    }
                    break;
                case "//":break;
                default: error = new Error("Unexist method", new ArgumentException()); break;
            }
        }
    }
}
