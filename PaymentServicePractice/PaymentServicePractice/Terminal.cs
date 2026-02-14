using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentServicePractice
{
    class Terminal
    {
        private Dictionary<string, Action> _commands;
        private CustomerDb _customerDb;
        private ShopDb _shopDb;

        public Terminal(CustomerDb customerDb, ShopDb shopDb)
        {
            _customerDb = customerDb;
            _shopDb = shopDb;
            InitializeCommands();
        }

        private void InitializeCommands()
        {
            _commands = new Dictionary<string, Action>
            {
                ["!help"] = () => DisplayHelp(),
                ["!addCustomer"] = () => _customerDb.AddCustomer(),
                ["!displayCustomers"] = () => _customerDb.DisplayCustomers(),
                ["!deleteCustomer"] = () => _customerDb.DeleteCustomer(),
                ["!editCustomer"] = () => _customerDb.EditCustomer(),
                ["!login"] = () => _customerDb.LogAsUser(),
                ["!logOut"] = () => LogOutCurrentCustomer(), 
                ["!displayShop"] = () => _shopDb.DisplayShop(),
                ["!shop"] = () => _shopDb.Shop(),
                ["!License"] = () => License(),
                ["!clear"] = () =>
                {
                    Console.Clear();
                    Console.Write("Console cleared");
                },
            };
        }

        public void StartTerminal()
        {
            Console.WriteLine("Welcome!");
            Console.WriteLine("To see commands type !help");

            string? userInput = Console.ReadLine()?.Trim();

            while (true)
            {
                if (_commands.ContainsKey(userInput))
                {
                    _commands[userInput]();

                }
                else if (userInput == "!quit")
                {
                    Console.WriteLine("Goodbye!");
                    break;
                }
                else
                {
                    Console.WriteLine("Unknown command");
                }

                userInput = Console.ReadLine()?.Trim();
            }
        }

        private void DisplayHelp()
        {
            foreach (string key in _commands.Keys)
            {
                if (key.Equals("!License"))
                {
                    Console.BackgroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine("!License");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($"{key}");

                }
            }
            Console.WriteLine("!quit");
        }

        private void LogOutCurrentCustomer()
        {
            Customer customer = _customerDb.GetLoggedInCustomer();
            customer.HasLoggedIn = false;
            Console.WriteLine($"{customer.Name} has logged out");
            return;
        }

        private void License()
        {
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("\nThis app designed and developed by Melih Özyeşil for educational purposes and practice \n");
            Console.ResetColor();

            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Git Account: https://github.com/SapereAudePr");
            Console.ResetColor();
        }
    }
}
