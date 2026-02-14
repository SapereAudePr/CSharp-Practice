using System.Net;
using System.Xml.Linq;

namespace ClassesOOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string carAnswer = ReadString("Enter car string");
            //string specAnswer = ReadString("Enter spec string");

            Customer john = new Customer("John", "Birmingham", 58215954);
            Customer alicia = new Customer("Alicia");

            //AssignNewCustomer();

            john.Password = "129582158";
            alicia.Password = "t3496g5436rdwk";
            

         
            

            Console.ReadKey();
        }

        static string ReadString(string prompt)
        {
            Console.WriteLine(prompt);
            string input = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine($"Try Again!");
                input = Console.ReadLine();
            }

            return input;
        }

        //static void AssignNewCustomer()
        //{
        //    Customer newCustomer = new Customer();
        //    Console.WriteLine("Enter new Customer name");
        //    newCustomer.Name = Console.ReadLine();
        //    Console.WriteLine("Enter adress");
        //    newCustomer.Address = Console.ReadLine();
        //    Console.WriteLine("Enter contact number");
        //    newCustomer.ContactNumber = int.Parse(Console.ReadLine());

            
        //}
    }
}
