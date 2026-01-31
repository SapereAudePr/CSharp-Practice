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
            bool parseUserAge = int.TryParse(Console.ReadLine(), out int userAge);

            Console.WriteLine("Enter user city:");
            string userCity = Console.ReadLine();

            Console.WriteLine("Enter user language:");
            string userLanguage = Console.ReadLine();

            if (!_customer.TryAdd(_customer.Keys.Last() +1, new Customer(userName, userAge, userCity, userLanguage))) Console.WriteLine("Error");

            Console.WriteLine($"New user added: {_customer.Keys} | {userName} | {userAge} | {userCity} | {userLanguage}");
        }
    }
}
