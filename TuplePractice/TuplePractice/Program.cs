namespace TuplePractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            (string message, bool isCorrect) = CheckResult(3);

            Console.WriteLine($"{message} {isCorrect}");

            Sum(10, 20);

            var sw = message switch
            {
                "1" => 1,
                "2" => 2,
                _ => 4
            };


            Console.ReadKey();
        }

        static (string message, bool isCorrect) CheckResult(int input) => input switch
        {
            1 => ("Green", true),
            2 => ("Red", false),
            3 => ("Black", true),
            _ => ("None", false)
        };

        static int Sum(int a, int b) => a + b;
    }
}
