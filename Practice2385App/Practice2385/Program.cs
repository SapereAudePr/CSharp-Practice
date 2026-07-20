using Practice2385.BankTransferSystem;
using Practice2385.LoginSystemPainVersion;
using Practice2385.OrderProcessingPractice;
using Practice2385.UserServicePractice;
using Practice2385.ValidatorPractice;
using Practice2385.ValidatorPractice2;

namespace Practice2385
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //NotificationService service = new NotificationService();
            //service.AddProvider(new NotificationModel.EmailNotification());
            //service.AddProvider(new NotificationModel.SmsNotification());
            //service.NotifyAll("John", "Welcome");

            //INotification eMail = new NotificationModel.EmailNotification();
            //Notify eNotify = new Notify(eMail);
            //eNotify.NotifyOne("Raven", "Hello");

            //INotification sms = new NotificationModel.SmsNotification();
            //Notify sNotify = new Notify(sms);
            //sNotify.NotifyOne("Alicia", "Hi");

            //ILogger consoleLogger = new LoggerModel.LogConsole();
            //Logger log = new Logger(consoleLogger);
            //log.Log("Log Service One Test");

            //LoggerService logService = new LoggerService();
            //logService.AddService(new LoggerModel.LogConsole());
            //logService.LogAll("Log Service All Test");


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


            //var full = Box<string>.Put("full")
            //    .IsFull()
            //    .Describe();


            //var empty = Box<string>.Empty()
            //    .IsFull()
            //    .Describe();



            //var result = LoginService.FindUser("First")
            //    .OnSuccess(x => LoginService.CheckPassword(x, "123456789"))
            //    .OnSuccess(x => LoginService.CheckBanned(x))
            //    .OnSuccess(x => LoginService.GenerateToken(x))
            //    .Print();


            //var test = LoginService.FindUser("Second")
            //    .OnSuccess(x => LoginService.CheckPassword(x, "123456789"))
            //    .OnSuccess(x => LoginService.CheckBanned(x))
            //    .OnSuccess(x => LoginService.GenerateToken(x))
            //    .Print(x => 
            //    $"UserName: {x.User.UserName} | " +
            //    $"Password: {x.User.Password} | " +
            //    $"IsBanned: {x.User.isBanned} | " +
            //    $"Token: {x.Token}");




            //var test = BankService.FindAccount("ACC002")
            //    .OnSuccess(x => BankService.CheckBalance(x, 200m))
            //    .OnSuccess(x => BankService.FindReceiver(x, "ACC003"))
            //    .OnSuccess(x => BankService.ProcessTransfer(x, 200m))
            //    .OnSuccess(x => BankService.GenerateReceipt(x))
            //    .Print(ctx =>
            //            $"Transfer complete\n" +
            //            $"{ctx.Sender.Owner} → {ctx.Receiver.Owner}\n" +
            //            $"Amount: {ctx.Amount}\n" +
            //            $"Sender remaining: {ctx.Sender.Balance}");



            

            Console.ReadKey();
        }
    }
}
