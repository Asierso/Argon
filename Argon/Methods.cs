using System;
using System.Diagnostics;
using System.Threading;

namespace Argon
{
    public class Methods
    {
        protected ArgonLine scriptLine;
        protected string[] methods = {"//", "print.line", "font" , "file.write.line", "file.write", "file.read.line","file.read", "var" , "function.external", "if" , "function.open" , "function.close","function", "start" , "network.download.text", "network.download.file" , "math.sum", "math.rest", "math.multiply", "math.divide" , "math.sqrt", "join","js.run.args.print", "js.run.args","js.run.print","js.run","print","wait"};
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
        public string[] GetMethodArray() => methods;
        #region MethodsList
        public virtual void ExecuteThing(string methodSingle)
        {
            FileManager fileManager = new FileManager(null);
            Network network = new Network(null);
            int[] numbers = new int[2];
            string[] jsr = new string[2];
            string[] texts = new string[2];
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
                        if (scriptLine.GetParameters()[0].Contains("$") && Memory.VarList.ContainsKey(scriptLine.GetParameters()[0].TrimStart(new char[] { '$' })) && Memory.VarList[scriptLine.GetParameters()[0].TrimStart(new char[] { '$' })].Contains("()"))
                        {
                            Interpreter interpreter = new Interpreter(Memory.FunctionList[Memory.VarList[scriptLine.GetParameters()[0].TrimStart(new char[] {'$' })].TrimEnd(new char[] { '(', ')' })]);
                            interpreter.Run();
                        }
                        else if (scriptLine.GetParameters()[0].Contains("()"))
                        {
                            Interpreter interpreter = new Interpreter(Memory.FunctionList[scriptLine.GetParameters()[0].TrimEnd(new char[] { '(', ')' })]);
                            interpreter.Run();
                        }
                        else
                        {
                            //Function error
                        }
                    }
                    break;
                case "network.download.text":
                    if (Memory.LockedCode == false)
                    {
                        if(scriptLine.GetParameters()[0].Contains("$") && Memory.VarList.ContainsKey(scriptLine.GetParameters()[0].TrimStart(new char[] { '$' })))
                        {
                            network.SetUrl(Memory.VarList[scriptLine.GetParameters()[0].TrimStart(new char[] { '$' })]);
                            Memory.VarList[scriptLine.GetParameters()[1]] = network.DownloadString();
                        }
                        else
                        {
                            network.SetUrl(scriptLine.GetParameters()[0]);
                            Memory.VarList[scriptLine.GetParameters()[1]] = network.DownloadString();
                        }
                    }
                    break;
                case "network.download.file":
                    if (Memory.LockedCode == false)
                    {
                        if (scriptLine.GetParameters()[0].Contains("$") && Memory.VarList.ContainsKey(scriptLine.GetParameters()[0].TrimStart(new char[] { '$' })))
                        {
                            network.SetUrl(Memory.VarList[scriptLine.GetParameters()[0].TrimStart(new char[] { '$' })]);
                        }
                        else
                        {
                            network.SetUrl(scriptLine.GetParameters()[0]);
                        }
                        if (scriptLine.GetParameters()[1].Contains("$") && Memory.VarList.ContainsKey(scriptLine.GetParameters()[1].TrimStart(new char[] { '$' })))
                        {
                             network.DownloadFile(Memory.VarList[scriptLine.GetParameters()[1].TrimStart(new char[] { '$' })]);
                        }
                        else
                        {
                             network.DownloadFile(scriptLine.GetParameters()[1]);
                        }
                    }
                    break;
                case "math.sum":
                    if (Memory.LockedCode == false)
                    {

                        if (scriptLine.GetParameters()[0].Contains("$") && Memory.VarList.ContainsKey(scriptLine.GetParameters()[0].TrimStart(new char[] { '$' })))
                        {
                            numbers[0] = Int32.Parse(Memory.VarList[scriptLine.GetParameters()[0].TrimStart(new char[] { '$' })]);
                        }
                        else
                        {
                            numbers[0] = Int32.Parse(scriptLine.GetParameters()[0]);
                        }
                        if (scriptLine.GetParameters()[1].Contains("$") && Memory.VarList.ContainsKey(scriptLine.GetParameters()[1].TrimStart(new char[] { '$' })))
                        {
                            numbers[1] = Int32.Parse(Memory.VarList[scriptLine.GetParameters()[1].TrimStart(new char[] { '$' })]);
                        }
                        else
                        {
                            numbers[1] = Int32.Parse(scriptLine.GetParameters()[1]);
                        }
                        Memory.VarList[scriptLine.GetParameters()[2].TrimStart(new char[] { '$' })] = Convert.ToString(numbers[0] + numbers[1]);
                    }
                    break;
                case "math.rest":
                    if (Memory.LockedCode == false)
                    {
                        if (scriptLine.GetParameters()[0].Contains("$") && Memory.VarList.ContainsKey(scriptLine.GetParameters()[0].TrimStart(new char[] { '$' })))
                        {
                            numbers[0] = Int32.Parse(Memory.VarList[scriptLine.GetParameters()[0].TrimStart(new char[] { '$' })]);
                        }
                        else
                        {
                            numbers[0] = Int32.Parse(scriptLine.GetParameters()[0]);
                        }
                        if (scriptLine.GetParameters()[1].Contains("$") && Memory.VarList.ContainsKey(scriptLine.GetParameters()[1].TrimStart(new char[] { '$' })))
                        {
                            numbers[1] = Int32.Parse(Memory.VarList[scriptLine.GetParameters()[1].TrimStart(new char[] { '$' })]);
                        }
                        else
                        {
                            numbers[1] = Int32.Parse(scriptLine.GetParameters()[1]);
                        }
                        Memory.VarList[scriptLine.GetParameters()[2].TrimStart(new char[] { '$' })] = Convert.ToString(numbers[0] - numbers[1]);
                    }
                    break;
                case "math.multiply":
                    if (Memory.LockedCode == false)
                    {
                        if (scriptLine.GetParameters()[0].Contains("$") && Memory.VarList.ContainsKey(scriptLine.GetParameters()[0].TrimStart(new char[] { '$' })))
                        {
                            numbers[0] = Int32.Parse(Memory.VarList[scriptLine.GetParameters()[0].TrimStart(new char[] { '$' })]);
                        }
                        else
                        {
                            numbers[0] = Int32.Parse(scriptLine.GetParameters()[0]);
                        }
                        if (scriptLine.GetParameters()[1].Contains("$") && Memory.VarList.ContainsKey(scriptLine.GetParameters()[1].TrimStart(new char[] { '$' })))
                        {
                            numbers[1] = Int32.Parse(Memory.VarList[scriptLine.GetParameters()[1].TrimStart(new char[] { '$' })]);
                        }
                        else
                        {
                            numbers[1] = Int32.Parse(scriptLine.GetParameters()[1]);
                        }
                        Memory.VarList[scriptLine.GetParameters()[2].TrimStart(new char[] { '$' })] = Convert.ToString(numbers[0] * numbers[1]);
                    }
                    break;
                case "math.divide":
                    if (Memory.LockedCode == false)
                    {
                        if (scriptLine.GetParameters()[0].Contains("$") && Memory.VarList.ContainsKey(scriptLine.GetParameters()[0].TrimStart(new char[] { '$' })))
                        {
                            numbers[0] = Int32.Parse(Memory.VarList[scriptLine.GetParameters()[0].TrimStart(new char[] { '$' })]);
                        }
                        else
                        {
                            numbers[0] = Int32.Parse(scriptLine.GetParameters()[0]);
                        }
                        if (scriptLine.GetParameters()[1].Contains("$") && Memory.VarList.ContainsKey(scriptLine.GetParameters()[1].TrimStart(new char[] { '$' })))
                        {
                            numbers[1] = Int32.Parse(Memory.VarList[scriptLine.GetParameters()[1].TrimStart(new char[] { '$' })]);
                        }
                        else
                        {
                            numbers[1] = Int32.Parse(scriptLine.GetParameters()[1]);
                        }
                        Memory.VarList[scriptLine.GetParameters()[2].TrimStart(new char[] { '$' })] = Convert.ToString(numbers[0] / numbers[1]);
                    }
                    break;
                case "math.sqrt":
                    if (Memory.LockedCode == false)
                    {
                        if (scriptLine.GetParameters()[0].Contains("$") && Memory.VarList.ContainsKey(scriptLine.GetParameters()[0].TrimStart(new char[] { '$' })))
                        {
                            numbers[0] = Int32.Parse(Memory.VarList[scriptLine.GetParameters()[0].TrimStart(new char[] { '$' })]);
                        }
                        else
                        {
                            numbers[0] = Int32.Parse(scriptLine.GetParameters()[0]);
                        }
                        Memory.VarList[scriptLine.GetParameters()[1].TrimStart(new char[] { '$' })] = Convert.ToString(Math.Sqrt(numbers[0]));
                    }
                    break;
                case "join":
                    if (Memory.LockedCode == false)
                    {
                        if (scriptLine.GetParameters()[0].Contains("$") && Memory.VarList.ContainsKey(scriptLine.GetParameters()[0].TrimStart(new char[] { '$' })))
                        {
                            texts[0] = Memory.VarList[scriptLine.GetParameters()[0].TrimStart(new char[] { '$' })];
                        }
                        else
                        {
                            texts[0] = scriptLine.GetParameters()[0];
                        }
                        if (scriptLine.GetParameters()[1].Contains("$") && Memory.VarList.ContainsKey(scriptLine.GetParameters()[1].TrimStart(new char[] { '$' })))
                        {
                            texts[1] = Memory.VarList[scriptLine.GetParameters()[1].TrimStart(new char[] { '$' })];
                        }
                        else
                        {
                            texts[1] = scriptLine.GetParameters()[1];
                        }
                        Memory.VarList[scriptLine.GetParameters()[2].TrimStart(new char[] { '$' })] = texts[0] + texts[1];
                    }
                    break;
                case "js.run":
                    if (Memory.LockedCode == false)
                    {
                        if (scriptLine.GetParameters()[0].Contains("$") && Memory.VarList.ContainsKey(scriptLine.GetParameters()[0].TrimStart(new char[] { '$' })))
                        {
                            jsr[0] = Memory.VarList[scriptLine.GetParameters()[0].TrimStart(new char[] { '$' })];
                        }
                        else
                        {
                            jsr[0] = scriptLine.GetParameters()[0];
                        }
                        if (scriptLine.GetParameters()[1].Contains("$") && Memory.VarList.ContainsKey(scriptLine.GetParameters()[1].TrimStart(new char[] { '$' })))
                        {
                            JScriptOut jScript = new JScriptOut(jsr[0],scriptLine.GetParameters()[1]);
                            jScript.Run();
                        }
                    }
                    break;
                case "js.run.args":
                    if (Memory.LockedCode == false)
                    {
                        if (scriptLine.GetParameters()[0].Contains("$") && Memory.VarList.ContainsKey(scriptLine.GetParameters()[0].TrimStart(new char[] { '$' })))
                        {
                            jsr[0] = Memory.VarList[scriptLine.GetParameters()[0].TrimStart(new char[] { '$' })];
                        }
                        else
                        {
                            jsr[0] = scriptLine.GetParameters()[0];
                        }
                        if (scriptLine.GetParameters()[1].Contains("$") && Memory.VarList.ContainsKey(scriptLine.GetParameters()[1].TrimStart(new char[] { '$' })))
                        {
                            jsr[1] = Memory.VarList[scriptLine.GetParameters()[1].TrimStart(new char[] { '$' })];
                        }
                        else
                        {
                            jsr[1] = scriptLine.GetParameters()[1];
                        }
                        if (scriptLine.GetParameters()[2].Contains("$") && Memory.VarList.ContainsKey(scriptLine.GetParameters()[2].TrimStart(new char[] { '$' })))
                        {
                            JScriptOut jScript = new JScriptOut(jsr[0],scriptLine.GetParameters()[2]);
                            jScript.SetArgs(jsr[1]);
                            jScript.Run();
                        }

                    }
                    break;
                case "js.run.print":
                    if (Memory.LockedCode == false)
                    {
                        if (scriptLine.GetParameters()[0].Contains("$") && Memory.VarList.ContainsKey(scriptLine.GetParameters()[0].TrimStart(new char[] { '$' })))
                        {
                            jsr[0] = Memory.VarList[scriptLine.GetParameters()[0].TrimStart(new char[] { '$' })];
                        }
                        else
                        {
                            jsr[0] = scriptLine.GetParameters()[0];
                        }
                        JScript jScript = new JScript(jsr[0]);
                        jScript.Run();
                    }
                    break;
                case "js.run.args.print":
                    if (Memory.LockedCode == false)
                    {
                        if (scriptLine.GetParameters()[0].Contains("$") && Memory.VarList.ContainsKey(scriptLine.GetParameters()[0].TrimStart(new char[] { '$' })))
                        {
                            jsr[0] = Memory.VarList[scriptLine.GetParameters()[0].TrimStart(new char[] { '$' })];
                        }
                        else
                        {
                            jsr[0] = scriptLine.GetParameters()[0];
                        }
                        if (scriptLine.GetParameters()[1].Contains("$") && Memory.VarList.ContainsKey(scriptLine.GetParameters()[1].TrimStart(new char[] { '$' })))
                        {
                            jsr[1] = Memory.VarList[scriptLine.GetParameters()[1].TrimStart(new char[] { '$' })];
                        }
                        else
                        {
                            jsr[1] = scriptLine.GetParameters()[1];
                        }
                        JScript jScript = new JScript(jsr[0]);
                        jScript.SetArgs(jsr[1]);
                        jScript.Run();
                    }
                    break;
                case "wait":
                    if (Memory.LockedCode == false)
                    {
                        try
                        {
                            if (scriptLine.GetParameters()[0].Contains("$") && Memory.VarList.ContainsKey(scriptLine.GetParameters()[0].TrimStart(new char[] { '$' })))
                            {
                                Thread.Sleep(Int32.Parse(Memory.VarList[scriptLine.GetParameters()[0].TrimStart(new char[] { '$' })]));
                            }
                            else
                            {
                                Thread.Sleep(Int32.Parse(scriptLine.GetParameters()[0]));
                            }
                        }
                        catch(Exception ex)
                        {
                            error = new Error("Int expected", ex);
                        }
                    }
                    break;
                case "//":break;
                default: error = new Error("Unexist method", new ArgumentException()); break;
            }
        }
        #endregion MethodsList
    }
}
