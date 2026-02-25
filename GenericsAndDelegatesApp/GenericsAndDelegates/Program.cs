namespace GenericsAndDelegates
{
    internal class Program
    {
        private delegate int Compare<T>(T x, T y);

        class Person
        {
            public required string Name { get; set; }
            public required int Age { get; set; }
        }

        class PersonSorter
        {
            public void Sort<T>(T[] items, Compare<T> compare) where T : Person
            {
                for (int i = 0; i < items.Length - 1; i++)
                {
                    for (int j = i + 1; j < items.Length; j++)
                    {
                        if (compare(items[i], items[j]) > 0)
                        {
                            T temp = items[i];
                            items[i] = items[j];
                            items[j] = temp;
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

            MulticastDelegate multiCast = new();
            multiCast.Run();

            PersonSorter sorter = new();
            //sorter.Sort(people, (Person x, Person y) => x.Age.CompareTo(y.Age));
            sorter.Sort(people, CompareByAge);

            var result = people.OrderBy(x => x.Name).ThenBy(x => x.Age);

            foreach (var item in result)
            {
                Console.WriteLine(item.Name + " " + item.Age);
            }

            foreach (Person person in people)
            {
                Console.WriteLine(person.Name + " " + person.Age);
            }

            Console.ReadKey();
        }

        static void SortByAscending(Person[] people)
        {
            var result = people.OrderBy(x => x.Age);
            foreach (var person in result)
            {
                Console.WriteLine($"{person.Name} | {person.Age}");
            }
        }

        static void SortByDescending(Person[] people)
        {
            var result = people.OrderByDescending(x => x.Age);
            foreach (var person in result)
            {
                Console.WriteLine($"{person.Name} | {person.Age}");
            }
        }

        static int CompareByAge(Person x, Person y) => x.Age.CompareTo(y.Age);
        static int CompareByName(Person x, Person y) => x.Name.CompareTo(y.Name);

    }
}
