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

        private static List<string> _commands = new List<string>()
            {
                "!help",
                "!displayDb",
                "!quit",
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

                if (!_commands.Contains(userInput) || string.IsNullOrWhiteSpace(userInput))
                {
                    Console.WriteLine($"Unknown Command. Type \"!help\" to see commands");
                    continue;
                }

                switch (userInput)
                {
                    case var cmd when cmd == _commands[0]:
                        PrintCommands();
                        break;
                    case var cmd when cmd == _commands[1]:
                        program.PrintDb();
                        break;
                    case var cmd when cmd == _commands[2]:
                        Console.WriteLine("Goodbye!");
                        return;

                    default:
                        Console.WriteLine($"Unknown command, please type \"!help\" to see commands");
                        break;
                }
            }
        }

        private static void PrintCommands()
        {
            foreach (string command in _commands)
            {
                Console.WriteLine($"\n{command}");
            }
        }
    }
}
