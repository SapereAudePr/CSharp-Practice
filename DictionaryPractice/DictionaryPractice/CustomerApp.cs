using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryPractice
{
    class CustomerApp
    {
        private static Dictionary<int, Customer> _customers;

        private static Dictionary<string, string> _commands = new()
        {
            ["!help"] = "see commands",
            ["!displayDb"] = "see database of customers",
            ["!addNewUser"] = "add new user to database",
            ["!quit"] = "quit program",
            ["!searchUser"] = "search a user in the database"
        };

        static void Main(string[] args)
        {
            InitializeCustomers();
            StartProgram();

            Console.ReadKey();
        }

        private static void InitializeCustomers()
        {
            _customers = new Dictionary<int, Customer>
            {
                [1] = new Customer("John", 20, "London", "English"),
                [2] = new Customer("Finn", 24, "Berlin", "German"),
                [3] = new Customer("Rodrigo", 24, "Mexico", "Spanish"),
            };

            _customers.Add(4, new Customer("Ahmet", 28, "Ankara", "Turkish"));
            if (!_customers.TryAdd(5, new Customer("Burak", 22, "Adana", "Turkish"))) Console.WriteLine("Error");
            _customers.Remove(5);
        }

        private static void StartProgram()
        {
            CustomerProgram program = new CustomerProgram(_customers);

            Console.WriteLine("Welcome!");
            Console.WriteLine($"Type \"!help\" to see the commands");

            while (true)
            {
                string? userInput = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(userInput) || !_commands.Keys.Contains(userInput))
                {
                    Console.WriteLine("Unknown command!");
                    continue;
                }

                switch (userInput)
                {
                    case "!help":
                        PrintCommands();
                        break;

                    case "!displayDb":
                        program.PrintDb();
                        break;

                    case "!addNewUser":
                        program.AddNewCustomer();
                        break;
                    case "!searchUser":
                        program.SearchUser();
                        break;

                    case "!quit":
                        Console.WriteLine("Goodbye!");
                        return;

                    default:
                        break;
                }
            }
        }

        private static void PrintCommands()
        {
            int counter = 1;

            foreach (var (key, value) in _commands)
            {
                Console.Write("> ");
                Console.WriteLine($"{counter++}- \"{key}\": {value}");
            }
        }
    }
}
