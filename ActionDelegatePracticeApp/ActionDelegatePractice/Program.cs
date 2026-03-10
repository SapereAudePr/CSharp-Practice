
namespace ActionDelegatePractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sum = Calculator<int>(10, 20, (x, y) => x + y);
            var substract = Calculator<int>(50, 30, (x, y) => x - y);
            var multiply = Calculator<int>(10, 10, (x, y) => x * y);
            var divide = Calculator<int>(80, 20, (x, y) => x / y);

            var test = Calculator<string>("Hello", "World", (x, y) => $"***{x} | ***{y}");
            Console.WriteLine(test);

            Action<string> action = (x) =>
            {
                Console.WriteLine(x);
            };

            Testing(action);

            Console.ReadKey();
        }

        static T Calculator<T>(T x, T y, Func<T, T, T> func)
        {
            return func(x, y);
        }

        static void Testing(Action<string> action)
        {
            action("Action test");
        }
    }
}
