namespace EnumPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Run();
            Console.ReadKey();
        }

        private static void Run()
        {
            Random rnd = new();

            Array allValues = Enum.GetValues(typeof(Type));

            int rndNum = rnd.Next(allValues.Length);

            Type type = (Type)rndNum;

            Console.WriteLine($"Type: {type} | Value: {(int)type}");

            string color = type switch
            {
                Type.None => "Yellow",
                Type.Off => "Red",
                Type.On => "Green",
                _ => "Unknown"
            };

            Console.WriteLine($"Color: {color}");
        }
    }
}
