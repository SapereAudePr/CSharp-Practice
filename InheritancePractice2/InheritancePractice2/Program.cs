using System.Threading.Tasks.Dataflow;
using System.Xml.Linq;

namespace InheritancePractice2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person john = new Employee("John", "Doe", 30, 1485, "C# Developer", 100000);
            john.DisplayInfo();

            Employee raven = new Manager("Raven", "Smith", 43, 8537, "Lead Manager", 400000, "Art Manager", 12);
            raven.DisplayInfo();

            Console.ReadKey();
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }

        public Person(string name, string surname, int age)
        {
            Name = name;
            Surname = surname;
            Age = age;

            AgePlus(Age);
        }

        public int AgePlus(int age)
        {
            return age + 1;
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Name: {Name} | Surname: {Surname} | Age: {Age}");
        }

        
    }

    public class Employee: Person
    {
        public int Id { get; set; }
        public string Job { get; set; }
        public int Salary { get; set; }

        public Employee(string name, string surname, int age, int id, string job, int salary) : base(name, surname, age)
        {
            Id = id;
            Job = job;
            Salary = salary;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Name: {Name} | Surname: {Surname} | Age: {Age} | ID: {Id} | Job: {Job} | Salary: {Salary}");
        }
    }

    public class Manager : Employee
    {
        public string Position { get; set; }
        public int TeamSize { get; set; }

        public Manager(string name, string surname, int age, int id, string job, int salary, string position, int teamSize) : base(name, surname, age, id, job, salary)
        {
            Position = position;
            TeamSize = teamSize;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Name: {Name} | Surname: {Surname} | Age: {Age} | ID: {Id} | Job: {Job} | Salary: {Salary} | Position: {Position} | Team Size: {TeamSize}");
        }
    }

}
