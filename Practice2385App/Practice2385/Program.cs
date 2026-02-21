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

            //INotification sNotification = new NotificationModel.EmailNotification();
            //INotification eNotification = new NotificationModel.SmsNotification();
            //NotificationService provider = new NotificationService();
            //provider.AddProvider(sNotification);
            //provider.AddProvider(eNotification);

            //provider.NotifyAll($"Alice", "Welcome");


            NotificationService service = new NotificationService();
            service.AddProvider(new NotificationModel.EmailNotification());
            service.AddProvider(new NotificationModel.SmsNotification());
            service.NotifyAll("John", "Welcome");

            INotification eMail = new NotificationModel.EmailNotification();
            Notify eNotify = new Notify(eMail);
            eNotify.NotifyOne("Raven", "Hello");

            INotification sms = new NotificationModel.SmsNotification();
            Notify sNotify = new Notify(sms);
            sNotify.NotifyOne("Alicia", "Hi");


            LoggerModel.LoggerService logService = new LoggerModel.LoggerService();
            logService.AddService(new LoggerModel.LogConsole());
            logService.LogAll("LOG SERVICE TESTING");

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
