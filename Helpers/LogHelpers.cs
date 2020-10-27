using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace AutomationFramework.Helpers
{
    public class LogHelpers
    {
        //Log File Name Dynamic as Days

        private static string _logFileName = string.Format("{0:yyyymmddhhmmss}", DateTime.Now);
        private static StreamWriter _streamW = null;

        //Create a file which can store the log info
        
        public static void createLogFile()
        {
            string dir = @"e:\Framework\";
            if (Directory.Exists(dir))
            {
                _streamW = File.AppendText(dir + _logFileName + ".log");
            }
            else
            {
                Directory.CreateDirectory(dir);
                _streamW = File.AppendText(dir + _logFileName + ".log");
            }
        }


        //Method which write text in log file

        public static void writeFile(string logMessage)
        {
            _streamW.Write("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
            _streamW.WriteLine("     {0}", logMessage);
            _streamW.Flush();
        }

    }
}
