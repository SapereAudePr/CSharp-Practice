namespace DelegatesPractice
{
    internal class Program
    {
        public delegate void Message(string m);

        static void Main(string[] args)
        {
            //BubbleSort();
            //SubArray();
            //TwoSum();
            //TwoSumHash();




            Console.ReadKey();
        }

        
        static void BubbleSort()
        {
            int[] arr = { 99, 1123, 9582, -1259, -10, -990, 1, 10, 35, -765, 20 };

            int temp;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }

            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
        }

        static void SubArray()
        {
            int[] arr = { 2, -4, 7 };

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i; j < arr.Length; j++)
                {
                    for (int k = i; k <= j; k++)
                    {
                        Console.Write(arr[k] + ",");
                    }

                    Console.WriteLine();
                }
            }
        }

        static void TwoSum()
        {
            int[] arr = { 1, 7, 3, 12, 8, 4};

            int target = 20;

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] + arr[j] == target)
                    {
                        Console.WriteLine($"{arr[i]} and {arr[j]}");
                        break;
                    }
                }
            }
        }

        static void TwoSumHash()
        {
            int[] arr = { 1, 7, 3, 12, 8, 4 };

            Dictionary<int, int> complementMap = new();

            int target = 16;

            for (int i = 0; i < arr.Length; i++)
            {
                int complement = target - arr[i];

                if (complementMap.ContainsKey(complement))
                {
                    Console.WriteLine($"{arr[i]} and {complement}");
                    break;
                }

                if (!complementMap.ContainsKey(arr[i]))
                {
                    complementMap.Add(arr[i], i);
                }
            }
        }

    }
}
