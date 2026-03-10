namespace Threads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TaskVersion();
            //ParallelVersion();
            Console.ReadKey();
        }

        static void TaskVersion()
        {
            Task.Run(() => ProcessFile(1));
            Task.Run(() => ProcessFile(2));
            Task.Run(() => ProcessFile(3));
        }

        static void ParallelVersion()
        {
            Parallel.For(1, 5, fileId =>
            {
                ProcessFile(fileId);
            });

        }
        static void ProcessFile(int fileId)
        {
            Console.WriteLine($"Processing file {fileId} on thread: {Thread.CurrentThread.ManagedThreadId}");

            Thread.Sleep(2000);

            Console.WriteLine($"Finished file {fileId} on thread: {Thread.CurrentThread.ManagedThreadId}");
        }
    }
}
