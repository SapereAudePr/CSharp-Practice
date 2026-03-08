namespace GenericsAdvancedPractice453
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Test<string> test = new();

            Test<ClassTest> testClass = new();

            Console.ReadKey();
        }
    }

    public class ClassTest
    {

    }
}
