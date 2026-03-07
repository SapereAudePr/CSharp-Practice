namespace GenericsAdvancedPractice453
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Test<int> test = new();
            test.Content = 1;
            Console.WriteLine(test.Print());

            Test<string> testStr = new();
            testStr.Content = "Testing";
            Console.WriteLine(testStr.Print());

            Console.ReadKey();
        }
    }
}
