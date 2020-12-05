using System;
namespace Argon
{
    public class Error
    {
        private Exception errorException;
        public Error(Exception errorException) //Normal error
        {
            this.errorException = errorException;
            SaveLogs();
        }
        public Error(string syntaxError,Exception errorException) //Syntax error
        {
            this.errorException = errorException;
            ConsoleColor fore = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(syntaxError);
            Console.ForegroundColor = fore;
            SaveLogs();
        }
        public Error(string fileName) //Call error
        {
            ConsoleColor fore = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(fileName + " class not exists");
            Console.ForegroundColor = fore;
            errorException = new MissingMethodException();
            SaveLogs();
        }
        private void SaveLogs()
        {
            FileManager fmanager = new FileManager("errorlogs.log");
            fmanager.Write(errorException.ToString());
        }
    }
}