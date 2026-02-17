using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace InterfacePractice1295
{
    class FileLogger : ILogger
    {
        private string CreatePath()
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string folderName = "Logs";
            string folderPath = Path.Combine(desktopPath, folderName);
            string fileName = "Log.txt";
            string filePath = Path.Combine(folderPath, fileName);

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            return filePath;
        }

        public void LogMessage(string message)
        {
            message = $"{message} {Environment.NewLine}";

            string filePath = CreatePath();

            File.AppendAllText(filePath, message);
        }
    }

    public class ConsoleLogger : ILogger
    {
        public void LogMessage(string message)
        {
            Console.WriteLine($"[LOG]: {message}{Environment.NewLine}");
        }
    }

    public class App
    {
        ILogger _logger;

        public App(ILogger logger)
        {
            _logger = logger;
        }

        public void Log(string message)
        {
            _logger.LogMessage(message);
        }
    }
}
