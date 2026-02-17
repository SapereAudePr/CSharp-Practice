namespace InterfacePractice1295
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ILogger fileLogger = new FileLogger();
            App app = new(fileLogger);
            app.Log("Test");

            ILogger consoleLogger = new ConsoleLogger();
            app = new(consoleLogger);
            app.Log("Testing");


            int[] arr = { 1, 3, 7, 3, 3, 10, 3, 4, 3, 3, 3, 3};
            int[] result = TwoSums(arr, 7);
            for (int i = 0; i < result.Length; i++)
            {
                Console.WriteLine($"{result[i]} | ");
            }
            Console.ReadKey();
        }
        
        private static int[] TwoSums(int[] arr, int target)
        {
            Dictionary<int, int> complementMap = new();

            for (int i = 0; i < arr.Length; i++)
            {
                int complement = target - arr[i];

                if (complementMap.ContainsKey(complement))
                {
                    return [complementMap[complement], i];
                }

                if (!complementMap.ContainsKey(arr[i]))
                {
                    complementMap.Add(arr[i], i);
                }
            }

            return [-1, -1];
        }
    }
}
