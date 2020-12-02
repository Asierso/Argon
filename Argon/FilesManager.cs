using System;
using System.IO;
namespace Argon
{
    public class FileManager
    {
        private string file = "";
        private StreamReader str;
        private StreamWriter stw;
        public FileManager(string file)
        {
            this.file = file;
        }
        public string Read()
        {
            string read = "";
            try
            {
                str = new StreamReader(file);
                read = str.ReadToEnd();
                str.Close();
            }
            catch(Exception ex)
            {
                Error error = new Error("File not founded", ex);
            }
            return read;
        }
        public string ReadLine()
        {
            string read = "";
            try
            {
                str = new StreamReader(file);
                read = str.ReadLine();
                str.Close();
            }
            catch(Exception ex)
            {
                Error error = new Error("File not founded", ex);
            }
            return read;
        }
        public void Write(string text)
        {
            stw = new StreamWriter(file);
            stw.Write(text);
            stw.Close();
        }
        public void WriteLine(string text)
        {
            stw = new StreamWriter(file);
            stw.WriteLine(text);
            stw.Close();
        }
        public void SetFile(string file) => this.file = file;
    }
}
