using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace PaymentServicePractice
{
    class CustomerDb
    {
        private Dictionary<int, Customer> _customer;
        private static int idNum = 0;

        public CustomerDb()
        {
            InitializeCustomers();
        }

        public void InitializeCustomers()
        {
            _customer = new Dictionary<int, Customer>()
            {
                [1] = new Customer("John", 250.00m, false, idNum++),
                [2] = new Customer("Raven", 300.00m, false, idNum++)
            };
        }

        public void AddCustomer()
        {
            string customerName = "";
            decimal customerBalance = 0.0m;
            int newKey = _customer.Count == 0 ? 1 : _customer.Keys.Max() + 1;
            bool hasLoggedIn = false;
            int newId = _customer.Count == 0 ? 1 : _customer.Last().Value.Id + 1;

            Console.WriteLine("Enter customer name...");
            customerName = Console.ReadLine();
            customerName = !string.IsNullOrEmpty(customerName) ? customerName : "Unknown";

            Console.WriteLine("Enter customer balance...");
            bool tryParse = decimal.TryParse(Console.ReadLine(), out customerBalance);
            if (!tryParse)
            {
                customerBalance = 0.0m;
                Console.WriteLine($"Invalid input! Balance is {customerBalance}");
            }

            _customer.Add(newKey, new Customer(customerName, customerBalance, hasLoggedIn, newId));

            Console.WriteLine($"Customer name: {customerName} | Customer balance: {customerBalance} | ID: {newId}");
        }

        public void DeleteCustomer()
        {
            Console.WriteLine("Enter the customer name you want to delete");
            string? userInput = Console.ReadLine();

            var entry = _customer.FirstOrDefault
                (x => x.Value.Name.Equals
                (userInput, StringComparison.OrdinalIgnoreCase));

            if (entry.Value == null)
            {
                Console.WriteLine("Customer not found!");
                return;
            }

            Console.WriteLine($"Customer found --- Name: {entry.Value.Name} | ID: {entry.Value.Id}\n");
            Console.WriteLine($"Input user ID to delete:");


            bool checkUserAnswer = int.TryParse(Console.ReadLine(), out int userAnswer);
            if (checkUserAnswer)
            {
                if (userAnswer == entry.Value.Id)
                {
                    _customer.Remove(entry.Key);

                    Console.WriteLine("Customer deleted.");
                }
                else
                {
                    Console.WriteLine("Invalid ID!");
                }
            }
            else
            {
                Console.WriteLine("Invalid input");
            }

        }

        public void EditCustomer()
        {
            Console.WriteLine("Enter customer ID");
            string? userInput = Console.ReadLine();
            if (!int.TryParse(userInput, out int userId))
            {
                Console.WriteLine("Invalid Input");
                return;
            }

            var entry = _customer.FirstOrDefault(x => x.Value.Id.Equals(userId));

            if (entry.Value == null)
            {
                Console.WriteLine("Customer not found!");
                return;
            }

            Console.WriteLine($"Customer found ---- " +
                $"Name: {entry.Value.Name} | " +
                $"Balance: {entry.Value.Balance} |" +
                $"ID: {entry.Value.Id}\n");

            Console.WriteLine("To change customer's name type \"y\"");

            userInput = Console.ReadLine();
            if (userInput == "y")
            {
                Console.WriteLine("Enter new name...");
                userInput = Console.ReadLine();
                if (!string.IsNullOrEmpty(userInput))
                {
                    entry.Value.Name = userInput;
                    Console.WriteLine($"Name changed successfully!\nNew name: {entry.Value.Name}");
                }
                else
                {
                    Console.WriteLine("Invalid input");
                    return;
                }
            }

            Console.WriteLine("To change customer's balance type \"y\"");

            userInput = Console.ReadLine();
            if (userInput == "y")
            {
                if (!string.IsNullOrEmpty(userInput))
                {
                    Console.WriteLine("Enter the new balance");
                    userInput = Console.ReadLine();
                    if (decimal.TryParse(userInput, out decimal newBalance))
                    {
                        entry.Value.Balance = newBalance;
                        Console.WriteLine($"Balance changed successfully!\nNew balance: {entry.Value.Balance}");
                    }
                    else
                    {
                        Console.WriteLine("Invalid balance format");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input");
                    return;
                }
            }
        }

        public void LogAsUser()
        {
            Console.WriteLine("Enter ID of the user you want to login");
            bool parse = int.TryParse(Console.ReadLine(), out int userId);
            if (parse)
            {
                Customer? user = GetById(userId);
                if (_customer.Values.Any(x => x.Id == userId))
                {
                    if (user.HasLoggedIn)
                    {
                        Console.WriteLine("You're already logged in. Type !logout to logout...");
                        return;
                    }
                    Console.WriteLine($"Logged in as {user.Name} | {user.Balance} | {user.Id}");
                    user.HasLoggedIn = true;
                }

                Console.WriteLine("\nTo log out type !logOut");
            }
        }

        public void DisplayCustomers()
        {
            if (_customer != null)
            {
                foreach (var (key, value) in _customer)
                {
                    Console.WriteLine($"Key: {key} | Name: {value.Name} | Balance: {value.Balance} | ID: {value.Id}");
                }
            }
            else
            {
                throw new Exception("Customer is empty/not initialized");
            }
            
        }

        public Customer GetById(int id)
        {
            var customer = _customer.Values.FirstOrDefault(x => x.Id == id);
            return customer != null ? customer : throw new Exception("Customer not found!");
        }

        public Customer GetByName(string name)
        {
            var customer = _customer.Values.FirstOrDefault(x => x.Name == name);
            return customer != null ? customer : throw new Exception("Customer not found!");
        }

        public Customer GetLoggedInCustomer()
        {
            Customer? customer = _customer.Values.FirstOrDefault(x => x.HasLoggedIn == true);
            return customer;
        }
    }
}