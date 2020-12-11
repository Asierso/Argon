using System;
using System.Collections.Generic;
namespace Argon
{
    public static class Memory
    {
        //Public memory arrays of code interpreter
        public static Dictionary<String, String> VarList = new Dictionary<string, string>();  
        public static Dictionary<String, String> FunctionList = new Dictionary<string, string>(); 
        public static string FileReaded;
        public static string CurrentFile;
        public static bool LockedCode = false;
    }
}
