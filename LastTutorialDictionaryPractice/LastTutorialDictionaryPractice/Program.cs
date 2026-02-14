namespace LastTutorialDictionaryPractice
{
    internal class Program
    {
        class Student
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Grade { get; set; }

            public Student(int id, string name, int grade)
            {
                Id = id;
                Name = name;
                Grade = grade;
            }

        }

        static void Main(string[] args)
        {
            var students = new Dictionary<string, Student>
            {
                ["John"] = new Student(1, "John", 85),
                ["Alice"] = new Student(2, "Alice", 90),
                ["Bob"] = new Student(3, "Bob", 78),
            };

            foreach (var value in students.Values)
            {
                Console.WriteLine($"Name: {value.Name}, Id: {value.Id}, Grade: {value.Grade}");
            }

            Console.ReadKey();
        }
    }
}
