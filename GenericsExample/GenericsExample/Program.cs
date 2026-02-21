namespace GenericsExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] num = { 1, 4, 6, 9 };
            string[] str = { "Ans", "Moe", "Jan" };
            bool[] b = { true, false, false, true };

            Generic(num);
            Generic(str);
            Generic(b);
            

            Console.ReadKey();
        }

        static void Generic<T>(T[] arr)
        {
            foreach (T item in arr)
            {
                Console.WriteLine(item);
            }
        }
    }
}
