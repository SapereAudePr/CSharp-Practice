using System;
using System.Collections.Generic;
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

        }
    }
}
