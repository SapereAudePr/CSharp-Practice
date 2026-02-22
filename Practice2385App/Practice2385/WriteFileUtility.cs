using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice2385
{
    class WriteFileUtility
    {
        public string Prefix { get; }

        private readonly string _filePath;

        public WriteFileUtility()
        {
            _filePath = CreatePath();
        }


        private string CreatePath()
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string folderName = "Logs";
            string folderPath = Path.Combine(desktopPath, folderName);
            Directory.CreateDirectory(folderPath);

            string fileName = "logs.txt";
            string filePath = Path.Combine(folderPath, fileName);

            return filePath;
        }
        public void WriteFile(string identifier, string s)
        {
            string logLine = $"{Prefix}{s}{Environment.NewLine}";
            File.AppendAllText(_filePath, logLine);
        }
    }
}
