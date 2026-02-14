using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ListsPractice
{
    internal class Program
    {
        public class Product
        {
            public string Name { get; set; }
            public double Price { get; set; }


        }

        static void Main(string[] args)
        {

            List<Product> product = new List<Product>
            {
                new Product
                {
                    Name = "Keyboard",
                    Price = 50.11,
                },
                new Product
                {
                    Name = "Monitor",
                    Price = 299.99,
                }
            };


            product.Add
                (
                    new Product
                    {
                        Name = "Mouse",
                        Price = 29.99,
                    }
                );

            // This one returns a list immediately with .ToList() ||| List is created, this code will executed at compile immediately 
            List<Product> greaterThanTen = product.Where(x => x.Price > 10).ToList();

            // Returns the elements from the input that satisfies the condition ||| .Where() only works on iterate, LINQ runs when you enumerate: (foreach, ToList, ToArray, Count, Any, etc.)
            var greaterThanThirty = product.Where(x => x.Price > 30);

            foreach (var item in greaterThanThirty)
            {
                Console.WriteLine($"GreaterThanThirty: {item.Name} {item.Price}");
            }


            foreach (Product item in product)
            {
                Console.WriteLine($"Products list: {item.Name} | {item.Price}");
            }





            List<object> mixedList =
            [
                "John",
                "Raven",
                10,
                40,
                70,
                20,
                30,
                20.11,
                10.1,
                58.2,
                "Alicia"
            ];

            List<int> intNums = new();
            List<string> stringList = new();
            List<double> doubleList = new();

            Console.WriteLine("------------------------------------------------------------------------");
            Console.WriteLine("------------------------------------------------------------------------");
            Console.WriteLine("------------------------------------------------------------------------");

            foreach (object item in mixedList)
            {
                if (item is int number)
                {
                    intNums.Add(number);
                }
                else if (item is string str)
                {
                    stringList.Add(str);
                }
                else if (item is double dbl)
                {
                    doubleList.Add(dbl);
                }
            }

            int sumOfInts = intNums.Sum();
            Console.WriteLine($"Sum of Ints: {sumOfInts}");

            foreach (string item in stringList)
            {
                Console.WriteLine($"String list of items: {item}");
            }

            double sumOfDoubles = doubleList.Sum();
            Console.WriteLine($"Sum of Doubles: {sumOfDoubles}");




            Console.WriteLine("------------------------------------------------------------------------");
            Console.WriteLine("------------------------------------------------------------------------");
            Console.WriteLine("------------------------------------------------------------------------");










            List<string> list = 
                [
                    "421",
                    "27",
                    "152",
                    "534",
                    "24",
                    "214",
                    "51",
                    "24",
                    "27"
                ];


            list.Add("585");

            // Remove returns boolean value
            bool isDeleted = list.Remove("585");
            Console.WriteLine($"Is it deleted? {isDeleted}");

            // RemoveAll can be used with lambda expression
            // It returns int value of how many deleted
            int deletedCount = list.RemoveAll(item => item == "24");

            Console.WriteLine($"How many deleted: {deletedCount}");

            Console.WriteLine($"Length of the list {list.Count}"); // Length of the list
            Console.WriteLine($"How many 27 exists? {list.Count(item => item == "27")}"); // How many of that item exists

            // Use foreach for list
            foreach (string item in list)
            {
                Console.WriteLine(item);
            }

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///



            List<int> nums =
               [
                   10, 5, 8, 9, 1, 10, 4, 7, 13, 20, 1, 3, 8, 4
               ];

            nums.Sort();

            foreach (int num in nums)
            {
                Console.WriteLine(num);
            }

            // Returns bool
            bool anyTen = nums.Any(AnyTen);
            Console.WriteLine($"Any ten? {anyTen}"); // True


            // Returns int
            Predicate<int> isEqualToTen = x => x == 10;

            List<int> howManyTen = nums.FindAll(isEqualToTen);

            int count = 0;

            foreach (int num in howManyTen)
            {
                Console.WriteLine($"How many ten? {num} {count++}");
            }
            
            // FindAll returns a list which contains the founded items in the targeted list
            // That's why it should be stored in a list/var!
            List<int> greaterThan7 = nums.FindAll(item => item > 7);
            List<int> howMany8 = nums.FindAll(item => item == 8);

            foreach (var item in greaterThan7)
            {
                Console.WriteLine($"Found numbers {item}");
            }


            Console.ReadKey();
        }

        private static bool AnyTen(int x)
        {
            return x == 10;
        }
    }
}
