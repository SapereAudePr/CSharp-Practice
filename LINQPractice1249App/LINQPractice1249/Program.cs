using System.Numerics;

namespace LINQPractice1249
{
    class University
    {
        public required int Id { get; set; }

        public required string Name { get; set; }

        public void Print()
        {
            Console.WriteLine($"University {Name} | ID: {Id}");
        }
    }

    class Student
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required int Age { get; set; }
        public required string Gender { get; set; }

        public required int UniId { get; set; }

        public void Print()
        {
            Console.WriteLine($"Name: {Name} | Age: {Age} | Gender: {Gender} | ID: {Id} | UniID: {UniId}");
        }
    }

    class UniversityManager
    {
        public List<University> universities;
        public List<Student> students;

        public UniversityManager()
        {
            universities = new()
            {
                new University {Id = 1, Name = "Los Santos Uni"},
                new University {Id = 2, Name = "New York Uni"},
            };

            students = new()
            {
                new Student {Id = 1, Name = "John", Age = 20, Gender = "Male", UniId = 1},
                new Student {Id = 2, Name = "Alicia", Age = 21, Gender = "Female", UniId = 1},
                new Student {Id = 3, Name = "Raven", Age = 22, Gender = "Female", UniId = 1},
                new Student {Id = 4, Name = "Mike", Age = 21, Gender = "Male", UniId = 2},
                new Student {Id = 5, Name = "Josh", Age = 23, Gender = "Male", UniId = 2},
            };
        }

        public void MaleStudents()
        {
            IEnumerable<Student> maleStudents = students
                .Where(x => x.Gender.Equals("Male"))
                .OrderBy(x => x.Name);

            foreach (Student student in maleStudents)
            {
                student.Print();
            }
        }

        public void FemaleStudents()
        {
            IEnumerable<Student> femaleStudents = students
                .Where(x => x.Gender.Equals("Female"))
                .OrderBy(x => x.Name);

            foreach (Student student in femaleStudents)
            {
                student.Print();
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            UniversityManager manager = new();
            //manager.MaleStudents();
            //manager.FemaleStudents();

            Console.ReadKey();
        }
    }
}
