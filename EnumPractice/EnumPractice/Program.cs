namespace EnumPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Time();

            //Enums();

            Console.ReadKey();
        }

        private static void Time()
        {
            DateTime now = DateTime.Now;
            int year = now.Year;
            int day = now.Day;
            Int32 hour = now.Hour;
            Int32 minute = now.Minute;
            Int32 second = now.Second;
            Int32 millisecond = now.Millisecond;

            Console.WriteLine($"" +
                $"Year: {year} | " +
                $"Day: {day} | " +
                $"Hour: {hour} | " +
                $"Minute: {minute} | " +
                $"Second: {second} | " +
                $"Millisecond: {millisecond}");

            DateTime d = new(1993, 01, 14);
            TimeSpan t = now.Subtract(d);
            double days = t.TotalDays;
            double hours = t.TotalHours;
            double minutes = t.TotalMinutes;
            double seconds = t.TotalSeconds;

            Console.WriteLine($"" +
                $"Days: {days:F2} | " +
                $"Hours: {hours:F2} | " +
                $"Minutes: {minutes:F2} | " +
                $"Seconds: {seconds:F2}");

            double x = days / 365.2425;
            Console.WriteLine($"{x:F0}");

            double y = 27000 / 365.2425;
            Console.WriteLine($"{y:F0}");

            DateTime endDate = now.AddYears(76);
            TimeSpan difference = endDate - now;
            double j = difference.TotalDays;
            Console.WriteLine(j);

            DateTime bDay = new DateTime(2025, 04, 22);
            TimeSpan diff = now - bDay;
            double jj = diff.TotalDays;
            double remainingDays = 365.2425 - jj;
            TimeSpan rr = diff.Divide(remainingDays);
            Console.WriteLine(rr);
            Console.WriteLine($"{remainingDays:F0}");
        }

        

        private static void Enums()
        {
            Random rnd = new();

            Array allValues = Enum.GetValues(typeof(Type));

            int rndNum = rnd.Next(allValues.Length);

            Type type = (Type)rndNum;

            Console.WriteLine($"Type: {type} | Value: {(int)type}");

            string color = type switch
            {
                Type.None => "Yellow",
                Type.Off => "Red",
                Type.On => "Green",
                _ => "Unknown"
            };

            Console.WriteLine($"Color: {color}");
        }
    }
}
