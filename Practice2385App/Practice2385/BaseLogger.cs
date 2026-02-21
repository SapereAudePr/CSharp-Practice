using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice2385
{
    abstract class BaseLogger : ILogger
    {
        private readonly string _filePath;

        protected BaseLogger()
        {
            _filePath = CreatePath();
        }

        protected string GetTime(string? identifier)
        {
            var prefix = identifier switch
            {
                "console" => "[ConsoleLOG]",
                "file" => "[FileLOG]",
                "email" => "[EMAIL]",
                "sms" => "[SMS]",
                _ => null
            };

            DateTime now = DateTime.Now;
            return $"" +
                $"{prefix} | " +
                $"{now.Year}:" +
                $"{now.Month}:" +
                $"{now.Day} - " +
                $"{now.Hour}:" +
                $"{now.Minute}:" +
                $"{now.Second}";
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

        public void WriteFile(string identifier ,string s)
        {
            string logLine = $"{GetTime(identifier)} : {s}{Environment.NewLine}";
            File.AppendAllText(_filePath, logLine);
        }

        public abstract void Log(string s);
    }
}
