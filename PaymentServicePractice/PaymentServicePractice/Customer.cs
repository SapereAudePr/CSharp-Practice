using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentServicePractice
{
    class Customer
    {
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public bool HasLoggedIn { get; set; }
        public int Id { get; set; }
       
        public Customer(string name, decimal balance, bool hasLoggedIn ,int id)
        {
            Name = name;
            Balance = balance;
            HasLoggedIn = hasLoggedIn;
            Id = id;
        }
    }
}
