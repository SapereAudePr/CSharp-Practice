using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryPractice
{
    class CustomerProgram
    {
        private Dictionary<int ,Customer> _customer;

        public CustomerProgram(Dictionary<int, Customer> customer)
        {
            _customer = customer;
        }

        public void PrintDb()
        {
            foreach (var (key, value) in _customer)
            {
                Console.WriteLine($"Key: {key} | Name: {value.Name} | Age: {value.Age} | City: {value.City} | Language: {value.Language}");
            }
        }

        public void AddNewCustomer()
        {
            Console.WriteLine("Enter user name: ");
            string userName = Console.ReadLine();

            Console.WriteLine("Enter user age:");
            if (!int.TryParse(Console.ReadLine(), out int userAge)) Console.WriteLine("Invalid age");

            Console.WriteLine("Enter user city:");
            string userCity = Console.ReadLine();

            Console.WriteLine("Enter user language:");
            string userLanguage = Console.ReadLine();

            // Find the latest key of the dictionary
            int newKey = _customer.Any() ? _customer.Keys.Max() + 1 : 1;

            if (!_customer.TryAdd(newKey, new Customer(userName, userAge, userCity, userLanguage))) Console.WriteLine("Error");

            Console.WriteLine($"New user added: {userName} | {userAge} | {userCity} | {userLanguage}");
        }

        public void SearchUser()
        {
            Console.WriteLine("Enter the user name you want to find");
            string? userInput = Console.ReadLine();

            if (string.IsNullOrEmpty(userInput))
            {
                Console.WriteLine("Invalid input");
                return;
            }

            foreach (var value in _customer.Values)
            {
                if (value.Name.Equals(userInput, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"User found: {value.Name} | {value.Age} | {value.City} | {value.Language}");
                }
            }
        }
    }
}
