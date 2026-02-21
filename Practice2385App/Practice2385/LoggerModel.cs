using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice2385
{
    class LoggerModel
    {
        public class LogConsole : BaseLogger
        {
            public override void Log(string s)
            {
                Console.WriteLine($"{GetTime("console")} : {s}");
            }
        }

        public class LogFile : BaseLogger
        {
            private readonly string _filePath;

            public LogFile()
            {
                _filePath = CreatePath();
            }

            protected string CreatePath()
            {
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string folderName = "Logs";
                string folderPath = Path.Combine(desktopPath, folderName);
                Directory.CreateDirectory(folderPath);

                string fileName = "logs.txt";
                string filePath = Path.Combine(folderPath, fileName);

                return filePath;
            }

            public override void Log(string s)
            {
                string logLine = $"{GetTime("file")} : {s}{Environment.NewLine}";

                File.AppendAllText(_filePath, logLine);
            }
        }

        public class Logger
        {
            ILogger _logger;

            public Logger(ILogger logger)
            {
                _logger = logger;
            }

            public void Log(string s)
            {
                _logger.Log(s);
            }
        }
    }
}
