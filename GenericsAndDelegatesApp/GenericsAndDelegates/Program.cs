namespace GenericsAndDelegates
{
    internal class Program
    {
        public delegate int Comparison<T>(T x, T y);

        class Person
        {
            public required string Name { get; set; }
            public required int Age { get; set; }
        }

        class PersonSorter
        {
            public void Sort(Person[] people, Comparison<Person> comparison)
            {
                for (int i = 0; i < people.Length - 1; i++)
                {
                    for (int j = i + 1; j < people.Length; j++)
                    {
                        if (comparison(people[i], people[j]) > 0)
                        {
                            Person temp = people[i];
                            people[i] = people[j];
                            people[j] = temp;
                        }
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            Person[] people =
            {
                new Person {Name = "John", Age = 30},
                new Person {Name = "Alicia", Age = 20},
                new Person {Name = "Bob", Age = 28},
            };

            var sorter = (new PersonSorter());
            //sorter.Sort(people, CompareByAge);
            sorter.Sort(people, CompareByName);

            foreach (Person person in people)
            {
                Console.WriteLine(person.Name + " " + person.Age);
            }

            Console.ReadKey();
        }

        static int CompareByAge(Person x, Person y) => x.Age.CompareTo(y.Age);
        static int CompareByName(Person x, Person y) => x.Name.CompareTo(y.Name);

    }
}
