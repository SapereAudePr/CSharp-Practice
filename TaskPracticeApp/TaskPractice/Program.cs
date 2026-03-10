namespace TaskPractice
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            DownloadService downloadService = new();
            Console.WriteLine("To start downloading type 1");
            if (!int.TryParse(Console.ReadLine(), out int input)) throw new Exception("Invalid input");
            if (input is 1)
            {
                await downloadService.DownloadFile();
            }
        }
    }
}
