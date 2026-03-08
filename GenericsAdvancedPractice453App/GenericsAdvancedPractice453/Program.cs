namespace GenericsAdvancedPractice453
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Test<int, string> test = new(1, "String");
            test.Display();

            Console.ReadKey();
        }
    }
}
