namespace GenericsAdvancedPractice453
{
    internal class Test<TFirst, TSecond>
    {
        public TFirst ValueOne { get; set; }
        public TSecond ValueTwo { get; set; }

        public Test(TFirst first, TSecond second)
        {
            ValueOne = first;
            ValueTwo = second;
        }

        public void Display()
        {
            Console.WriteLine($"{ValueOne} | {ValueTwo}");
        }
    }
}
