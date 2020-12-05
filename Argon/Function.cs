using System;
using System.IO;
namespace Argon
{
    public class Function
    {
        //Execute function.open and function.close
        private string functionName;
        private string scriptFile;
        public Function(string functionName,string scriptFile)
        {
            this.functionName = functionName;
            this.scriptFile = scriptFile;
        }
        public void Detect()
        {
            StreamReader str = new StreamReader(scriptFile + ".arns");
            while(true)
            {
                string line = str.ReadLine();
                if(line.Contains("function.open") && line.Contains(functionName))
                {
                    break;
                }
            }
            string readed = "";
            while(true)
            {
                string line = str.ReadLine();
                if (line.Contains("function.close") && line.Contains(functionName))
                {
                    break;
                }
                else if(line.Contains("function.external"))
                {
                    Error error = new Error("Use external in a function is not allowed",new AccessViolationException());
                }
                else
                {
                    readed += line + "\n";
                }
            }
            Memory.FunctionList[functionName] = readed;
            str.Close();
        }
    }
}
