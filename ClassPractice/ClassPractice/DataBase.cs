using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ClassPractice
{
    class DataBase
    {
        Customer[] _customer;

        public DataBase(Customer[] customer)
        {
            this._customer = customer;
        }

        public void DisplayDB()
        {
            foreach (Customer c in _customer)
            {
                Console.WriteLine($"Name: {c.Name} | KidNames: {String.Join(",", c.KidNames)} | ContactNumber: {c.ContactNumber} | Address: {c.Address} | Password: {c.Password} | ID: {c.Id}");
            }
        }

        
    }
}
