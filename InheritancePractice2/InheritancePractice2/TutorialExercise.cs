using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritancePractice2
{
    class TutorialExercise
    {
        public class Person
        {
            public Person(string name)
            {
                Console.WriteLine($"Person constructor: {name}");
            }
        }

        public class Employee : Person
        {
            public Employee(string name, int id) : base(name)
            {
                Console.WriteLine($"Employee constructor: {name}, ID: {id}");
            }
        }

        public class Exercise
        {
            public void PrintMessages()
            {
                var employee = new Employee("John Doe", 123);
            }
        }
    }
}
