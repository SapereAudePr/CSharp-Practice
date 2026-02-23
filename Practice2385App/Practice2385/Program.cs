namespace Practice2385
{
    internal class Program
    {
        static void Main(string[] args)
        {
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

            ILogger consoleLogger = new LoggerModel.LogConsole();
            Logger log = new Logger(consoleLogger);
            log.Log("Log Service One Test");

            LoggerService logService = new LoggerService();
            logService.AddService(new LoggerModel.LogConsole());
            logService.LogAll("Log Service All Test");

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
