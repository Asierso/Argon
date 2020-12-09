using System;
using System.Diagnostics;
namespace Argon
{
    public class JScript : IScriptModel
    {
        private string scriptFile;
        private string scriptArgs = "";
        public string GetFileName() => scriptFile;
        public string SetFileName(string scriptFile) => this.scriptFile = scriptFile;
        public string GetArgs() => scriptArgs;
        public string SetArgs(string args) => this.scriptArgs = args;
        public JScript(string scriptFile) => this.scriptFile = scriptFile;
        public void Run()
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "node";
                psi.Arguments = scriptFile + " " + scriptArgs;
                var result = Process.Start(psi);
            }
            catch(Exception ex)
            {
                Error err = new Error("Node.js or file not detected", ex);
            }
        }
    }
}
