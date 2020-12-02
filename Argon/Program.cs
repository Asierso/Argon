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
                Interpreter interpreter = new Interpreter(fm.Read());
                interpreter.Run();
            }
            else
            {
                Console.WriteLine("Argon Console");
                Console.Write("Select  file (.arns is not necesary to put):");
                string file = Console.ReadLine();
                FileManager fm = new FileManager(file + ".arns");
                Interpreter interpreter = new Interpreter(fm.Read());
                interpreter.Run();
            }
        }
    }
}
