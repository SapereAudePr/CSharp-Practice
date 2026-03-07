namespace GenericsAdvancedPractice453
{
    internal class Test<T>
    {
        public T Content { get; set; }

        public string Print()
        {
            return $"{Content}";
        }
    }
}
