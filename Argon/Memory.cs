using System;
using System.Collections.Generic;
namespace Argon
{
    public static class Memory
    {
        //Public memory arrays of code interpreter (Global buffers)
        public static Dictionary<String, String> VarList = new Dictionary<string, string>();  
        public static Dictionary<String, String> FunctionList = new Dictionary<string, string>(); 

        //Memory of tmp vars to global instructions
        public static string FileReaded;
        public static string CurrentFile;
        public static bool LockedCode = false;
    }
}