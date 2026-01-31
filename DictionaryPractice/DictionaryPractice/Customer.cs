using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryPractice
{
    class Customer
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public string Language { get; set; }


        public Customer(string name, int age, string city, string language)
        {
            Name = name;
            Age = age;
            City = city;
            Language = language;
        }
    }
}
