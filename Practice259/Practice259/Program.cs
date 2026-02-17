namespace Practice259
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arrOne = { 4, 5, 12, 20 };
            int[] arrTwo = [2, 2, 1, 1, 1, 2, 2, 2];
            int[] arrThree = { 55, 25, 100, 85, 20, 35 };

            FindTwoSums(arrOne, 16);
            FindTwoSumsOptimized(arrThree, 45);

            FindMajorityElement(arrTwo);

            Console.ReadKey();
        }

        private static void FindTwoSums(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                for (int x = i + 1; x < nums.Length; x++)
                {
                    if (nums[i] + nums[x] == target)
                    {
                        Console.WriteLine($"{i} | {x}");
                        return;
                    }
                }
            }
        }

        private static void FindTwoSumsOptimized(int[] nums, int target)
        {
            Dictionary<int, int> complementMap = [];

            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];

                if (complementMap.ContainsKey(complement))
                {
                    Console.WriteLine($"Index One: {complementMap[complement]} | Index Two: {i} for the target: {target}");
                }

                if (!complementMap.ContainsKey(nums[i]))
                {
                    complementMap.Add(nums[i], i);
                }
            }
        }

        private static void FindMajorityElement(int[] nums)
        {
            int candidate = 0;
            int count = 0;

            if (nums.Length is 0)
            {
                return;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (count == 0)
                {
                    candidate = nums[i];
                }

                if (candidate == nums[i])
                {
                    count++;
                }
                else
                {
                    count--;
                }
            }

            count = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (candidate == nums[i])
                {
                    count++;
                }
            }

            if (count > nums.Length / 2)
            {
                Console.WriteLine($"Majority element found: {candidate}");
            }
            else
            {
                Console.WriteLine("No majority element found!");
            }
        }
    }
}
