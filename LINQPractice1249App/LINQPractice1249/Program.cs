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

        public void SortByAge()
        {
            var sortByAge = students.OrderByDescending(x => x.Age);
            //var sortByAge = from student in students
            //                where student.Age > 15 
            //                orderby student.Name 
            //                select student;

            foreach (Student s in sortByAge)
            {
                s.Print();
            }
        }

        public void FromUniId1()
        {
            //var res = students.Where(x => x.UniId == 1);
            //foreach (var s in res)
            //{
            //    s.Print();
            //}

            var x = from s in students
                    join uni in universities on s.UniId equals uni.Id
                    where uni.Name.Equals("Los Santos Uni")
                    select s;

            foreach (var y in x)
            {
                y.Print();
            }
        }

        public void GetUsersFromUniId()
        {
            Console.WriteLine("Enter uni Id");
            if (!int.TryParse(Console.ReadLine(), out int temp)) throw new Exception("Invalid input");
            var x = from s in students
                    where s.UniId.Equals(temp)
                    select s;

            foreach (var s in x)
            {
                s.Print();
            }
        }

        //public void StAndUniCollection()
        //{
        //    var x = from s in students
        //            join uni in universities
        //            on s.UniId equals uni.Id
        //            where uni.Id.Equals(1)
        //            orderby s.Name descending
        //            select new {x = s.Name, y = uni.Name};

        //    var j = x.ToList();

        //    foreach (var s in j)
        //    {
        //        var u = s.x.ToString();
        //        var i = s.y.ToString();
        //        Console.WriteLine($"{u} | {i}");
        //    }
        //}

        public void StAndUniCollection()
        {
            var x = from s in students
                    join uni in universities
                    on s.UniId equals uni.Id
                    where uni.Id.Equals(1)
                    orderby s.Name descending
                    select new { StudentName = s.Name, UniName = uni.Name };

            foreach (var s in x)
            {
                var sName = s.StudentName;
                var uniName = s.UniName;
                Console.WriteLine($"{sName} | {uniName}");
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
            //manager.SortByAge();
            //manager.FromUniId1();
            //manager.GetUsersFromUniId();
            manager.StAndUniCollection();

            Console.ReadKey();
        }
    }
}
