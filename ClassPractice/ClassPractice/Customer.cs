using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassPractice
{
    class Customer
    {
        public string Name { get; set; }
        public string[] KidNames { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }
        public int Password { get; set; }
        public int Id { get; set; }

        private static int IdNum = 0;

        public Customer(string name, string[] kidNames, string contactNumber, string addess, int password)
        {
            Name = name;
            KidNames = kidNames;
            ContactNumber = contactNumber;
            Address = addess;
            Password = password;
            Id = IdNum++;

            //Console.WriteLine($"{Name}, {ContactNumber}, {Address}, {Password}, {Id}");
        }
    }
}
