using Microsoft.VisualBasic.FileIO;
using System.Text.RegularExpressions;

namespace RegexPractice
{
    internal partial class Program
    {
        static void Main(string[] args)
        {
            CreateFile();
            MatchNumbers();
            Console.ReadKey();
        }

        static void CreateFile()
        {
            string desktop = Path.GetFullPath(SpecialDirectories.Desktop);
            string fileName = "PhoneNums.txt";
            string fileLocation = Path.Combine(desktop, fileName);

            string text = "" +
                "0322 551 153 0042\n" +
                "(0322) 551 153 0042\n" +
                "03225511530042\n" +
                "5511530042\n" +
                "05511530042\n" +
                "+90 532 175 98 21\n" +
                "+905321759821\n" +
                "5321234567\n" +
                "952!81852111";

            File.WriteAllText(fileLocation, text);
        }

        static void MatchNumbers()
        {
            string desktop = Path.GetFullPath(SpecialDirectories.Desktop);
            string fileName = "PhoneNums.txt";
            string fileLocation = Path.Combine(desktop, fileName);

            string trPhonePattern = @"\b?(?:\+|0)?\(?(?:\d{2,4})?\)?[ \.\-\#]?\d{3}[ \.\-\#]?\d{3}[ \.\-\#]?\d{2}[ \.\-\#]?\d{2}(?:\d{4})?\b";
            Regex regex = new(trPhonePattern);

            List<string> validNums = [];

            foreach (var num in File.ReadAllLines(fileLocation))
            {
                if (regex.IsMatch(num)) validNums.Add(num);
            }

            Console.WriteLine($"{validNums.Count} Valid numbers found:\n");

            foreach (var num in validNums)
            {
                Console.WriteLine(num);
            }
        }
    }
}
