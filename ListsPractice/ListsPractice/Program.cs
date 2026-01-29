namespace ListsPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
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
