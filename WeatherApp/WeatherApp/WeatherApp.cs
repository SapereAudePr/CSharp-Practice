using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp
{
    class WeatherApp
    {
        private static Random _random = new Random();

        private static Dictionary<int, Weather> _weather;

        string[] dayNames =
        [
            "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"
        ];

        private int dayCount = 0;

        public WeatherApp()
        {
            
        }
        public void Run()
        {
            InitializeWeather();
            UserTerminal();
        }

        private void UserTerminal()
        {
            Console.WriteLine("Welcome!");
            Console.WriteLine("Enter city name.");
            string? cityAnswer = Console.ReadLine();

            while (true)
            {
                
                if (!string.IsNullOrWhiteSpace(cityAnswer))

                cityAnswer = cityAnswer.Trim();

                bool isCityExist = _weather.Values.Any(w => w.CityName.Equals(cityAnswer, StringComparison.OrdinalIgnoreCase));
                if (!isCityExist)

                Console.WriteLine("Enter day amount");
                string? dayAnswer = Console.ReadLine();
                if (!int.TryParse(dayAnswer, out dayCount) || dayCount <= 0)

                break;
            }

            

            ExecuteProgram(cityAnswer ,dayCount);
        }

        private void InitializeWeather()
        {
            _weather = new Dictionary<int, Weather>
            {
                [1] = new Weather("Ankara", _random.Next(-30, 36), _random.Next(0, 51)),
                [2] = new Weather("Adana", _random.Next(-1, 56), _random.Next(0, 36)),
            };
        }

        private int ExecuteProgram(string city ,int dayAmount)
        {
            int initialTemp = 0;
            int minTemp = -5;
            int maxTemp = 5;

            initialTemp = _weather[1].Temperature;

            for (int i = 0; i < dayAmount; i++)
            {
                string day = dayNames[i % 7];
                initialTemp += _random.Next(minTemp, maxTemp);
                int currentTemp = initialTemp;

                Console.WriteLine($"City: {city.ToUpper()} | Day: {day} | Temperature: {currentTemp}");
            }

            

            return dayAmount;
        }
    }
}
