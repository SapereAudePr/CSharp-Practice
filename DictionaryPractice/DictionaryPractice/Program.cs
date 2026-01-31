//namespace DictionaryPractice
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            Dictionary<int, string> keyValue = new()
//            {
//                [1] = "John",
//                [2] = "Alicia",
//                [3] = "Raven",
//            };

//            keyValue.Add(4, "Nathan");
//            keyValue.Remove(4);

//            if (!keyValue.TryAdd(4, "Jonathan")) Console.WriteLine("Error");

//            foreach (var (key, value) in keyValue)
//            {
//                Console.WriteLine($"Key: {key} | Value: {value}");
//            }

//            foreach (KeyValuePair<int, string> item in keyValue)
//            {
//                var key = item.Key;
//                var value = item.Value;

//                Console.WriteLine($"Key: {key} | Value: {value}");
//            }

//            foreach (var value in keyValue)
//            {
//                Console.WriteLine(value);
//            }

//            Console.WriteLine(keyValue.TryGetValue(1, out string? name) ? name : "null");

//            Console.ReadKey();
//        }
//    }
//}
