using System;
namespace Argon
{
    public class ArgonLine
    {
        private string method;
        private string[] parameters = new string[10];
        public ArgonLine(string method, string[] parameters)
        {
            this.method = method;
            this.parameters = parameters;
        }
        public string[] GetParameters() { return parameters; }
        public string GetMethod() { return method; }
    }
}
