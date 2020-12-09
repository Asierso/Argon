using System;

namespace Argon
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            if(args.Length > 0)
            {
                if (args[0] == "--help")
                {
                    Help();
                }
                else
                {
                    FileManager fm = new FileManager(args[0]);
                    Memory.CurrentFile = fm.GetAloneFileName();
                    Interpreter interpreter = new Interpreter(fm.Read());
                    interpreter.Run();
                }
            }
            else
            {
                Console.WriteLine("+-- Argon file chooser --+");
                Console.Write("# Use 'argon --help' to show help");
                Console.Write("# Select  file (.arns is not necesary to put):");
                string file = Console.ReadLine();
                Memory.CurrentFile = file;
                FileManager fm = new FileManager(file + ".arns");
                Interpreter interpreter = new Interpreter(fm.Read());
                interpreter.Run();
                Console.ReadLine();
            }
        }
        public static void Help()
        {
            Console.WriteLine("+-- Help --+");
            Console.WriteLine("# Open file:\n argon file.arns to execute script");
            Console.WriteLine("# Open argon file chooser:\n argon to open file input (you dont need to use .arns");
            Console.WriteLine("+-- Syntax --+");
            Methods mt = new Methods(null);
            foreach (string singleCommand in mt.GetMethodArray())
            {
                Console.WriteLine(singleCommand);
            }
        }
    }
}
