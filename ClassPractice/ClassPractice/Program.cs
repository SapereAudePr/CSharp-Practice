namespace ClassPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Customer[] customer = new Customer[]
            {
                new Customer("Raven",
                new string[] {"Martha", "Ayse", "Eylul", "Canan"},
                "58925812",
                "Italy",
                825892),
                new Customer("John",
                new string[] {"Kaan", "Rukiye"},
                "21591258",
                "UK",
                52785),
                new Customer("Alicia",
                new string[] {"Hasan", "Ayfer", "Serkan", "Kadir"},
                "568346",
                "USA",
                1258235),
            };

            StartProgram(customer);

            Console.ReadKey();
        }

        private static void StartProgram(Customer[] customer)
        {
            Console.WriteLine("Welcome!");
            Console.WriteLine($"Type \"displayDb\" to see the customer database");
            string? userInput = Console.ReadLine();
            if (userInput == "displayDb" && userInput != null)
            {
                DataBase db = new(customer);
                db.DisplayDB();
            }
        }
    }
}
