using System;

namespace Argon
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            if(args.Length > 0)
            {
                FileManager fm = new FileManager(args[0]);
                Memory.CurrentFile = fm.GetAloneFileName();
                Interpreter interpreter = new Interpreter(fm.Read());
                interpreter.Run();
            }
            else
            {
                Console.WriteLine("Argon file chooser");
                Console.Write("Select  file (.arns is not necesary to put):");
                string file = Console.ReadLine();
                Memory.CurrentFile = file;
                FileManager fm = new FileManager(file + ".arns");
                Interpreter interpreter = new Interpreter(fm.Read());
                interpreter.Run();
            }
        }
    }
}
