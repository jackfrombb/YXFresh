using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace BoringLib
{
    public class Log
    {
        const string log_file_path = "/log.txt";
        string owner = "";

        public Log(string owner="")
        {
            this.owner = owner;
            if (!File.Exists(log_file_path))
            {
                File.CreateText(log_file_path);
            }
        }

        public void ToLog(string msg)
        {
            string log_text = string.Format("DATE:\n{0}\nFROM: {1}\nTEXT:\n{2}\n", 
                DateTime.Now, owner, msg);

            File.AppendAllText(log_file_path, log_text);
        }

        public void ClearLogs()
        {
            File.Delete(log_file_path);
            File.CreateText(log_file_path);
        }
    }
}
