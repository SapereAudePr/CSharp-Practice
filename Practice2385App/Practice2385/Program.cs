using System.Diagnostics;

namespace Practice2385
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ILogger consoleLogger = new LoggerModel.LogConsole();
            LoggerModel.Logger cLogger = new LoggerModel.Logger(consoleLogger);
            cLogger.Log("Test");

            ILogger fileLogger = new LoggerModel.LogFile();
            LoggerModel.Logger fLogger = new LoggerModel.Logger(fileLogger);
            fLogger.Log("Test");

            //string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //string folderName = "test";
            //string folderPath = Path.Combine(desktop, folderName);
            //string fileName = "test.txt";
            //string filePath = Path.Combine(folderPath, fileName);

            //ProcessStartInfo startInfo = new ProcessStartInfo()
            //{
            //    FileName = filePath,
            //    UseShellExecute = true
            //};

            //try
            //{
            //    Process.Start(startInfo);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"{Environment.NewLine}{ex.Message}");
            //}
            //finally
            //{
            //    Console.WriteLine("Process done");
            //}

            Console.ReadKey();
        }
    }
}
