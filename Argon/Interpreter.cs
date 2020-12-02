using System;
namespace Argon
{
    public class Interpreter
    {
        public string script = "";
        public Interpreter(string script)
        {
            this.script = script;
        }
        public void Run()
        {
            string[] scriptLines = script.Split(';');
            foreach (string scriptLineSingle in scriptLines)
            {
                string realScriptLineSingle = "";
                int[] bufferOfScriptLineSingle = new int[4] { 0, 0, 0, 0 };
                string[] textBufferOfScriptLineSingle = new string[10];
                foreach (char scriptLineSingleChar in scriptLineSingle)
                {
                    if (scriptLineSingleChar == '"')
                    {
                        bufferOfScriptLineSingle[0]++;
                        if (bufferOfScriptLineSingle[0] == 2)
                        {
                            bufferOfScriptLineSingle[1]++;
                            bufferOfScriptLineSingle[0] = 0;
                        }
                    }
                    if (bufferOfScriptLineSingle[0] == 0)
                    {
                        if (scriptLineSingleChar != ' ' && scriptLineSingleChar != '"') //Deny characters
                        {
                            realScriptLineSingle += scriptLineSingleChar.ToString();
                        }
                    }
                    else
                    {
                        if (scriptLineSingleChar != '"')
                        {
                            textBufferOfScriptLineSingle[bufferOfScriptLineSingle[1]] += scriptLineSingleChar.ToString();
                        }
                    }
                }
                Methods method = new Methods(new ArgonLine(realScriptLineSingle,textBufferOfScriptLineSingle));
                method.Execute();
            }
        }
    }
}