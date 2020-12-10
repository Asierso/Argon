using System;
using System.Diagnostics;
namespace Argon
{
    public class JScript : IScriptModel
    {
        protected string scriptFile;
        protected string scriptArgs = "";
        public string GetFileName() => scriptFile;
        public string SetFileName(string scriptFile) => this.scriptFile = scriptFile;
        public string GetArgs() => scriptArgs;
        public string SetArgs(string args) => this.scriptArgs = args;
        public JScript(string scriptFile) => this.scriptFile = scriptFile;
        public virtual void Run()
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "node";
                psi.Arguments = scriptFile + " " + scriptArgs;
                Process.Start(psi);
            }
            catch(Exception ex)
            {
                Error err = new Error("Node.js or file not detected", ex);
            }
        }
    }
    public class JScriptOut : JScript,IScriptModel
    {
        private string selectedVar = "";
        public JScriptOut(string scriptFile, string selectedVar) : base(scriptFile)
        {
            this.scriptFile = scriptFile;
            this.selectedVar = selectedVar;
        }
        public override void Run()
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "node";
                psi.Arguments = scriptFile + " " + scriptArgs;
                psi.CreateNoWindow = true;
                psi.UseShellExecute = false;
                psi.RedirectStandardOutput = true;
                psi.WindowStyle = ProcessWindowStyle.Hidden;
                Process proc = new Process
                {
                    StartInfo = psi
                };
                proc.Start();
                string getOut = proc.StandardOutput.ReadToEnd();
                if (selectedVar.Contains("$") && Memory.VarList.ContainsKey(selectedVar.TrimStart(new char[] { '$' })))
                {
                    Memory.VarList[selectedVar.TrimStart(new char[] { '$' })] = getOut.TrimEnd(new char[] { '\n'});
                }
                else
                {
                    //Throw error
                    Error error = new Error("Invalid var");
                }
            }
            catch (Exception ex)
            {
                Error err = new Error("Node.js or file not detected", ex);
            }
        }
    }
}
