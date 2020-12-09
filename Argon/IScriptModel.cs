using System;
namespace Argon
{
    public interface IScriptModel
    {
        string GetFileName();
        string SetFileName(string scriptFile);
        string GetArgs();
        string SetArgs(string args);
        void Run();
    }
}
