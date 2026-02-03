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

        string[] _dayNames =
        [
            "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"
        ];

        string[] _seasons =
        {
            "Winter", "Spring", "Summer", "Autumn"
        };

        private int dayCount = 0;

        public WeatherApp() { }
        
        public void Run()
        {
            InitializeWeather();
            UserTerminal();
        }

        private void InitializeWeather()
        {
            _weather = new Dictionary<int, Weather>
            {
                [1] = new Weather("Ankara", _random.Next(-30, 36), _random.Next(0, 51)),
                [2] = new Weather("Adana", _random.Next(-1, 56), _random.Next(0, 36)),
            };
        }

        private void UserTerminal()
        {
            Console.WriteLine("Welcome!");
            Console.WriteLine("Enter city name.");
            string? cityAnswer = Console.ReadLine();

            while (true)
            {

                if (string.IsNullOrWhiteSpace(cityAnswer))
                {
                    Console.WriteLine("Invalid input");
                    cityAnswer = Console.ReadLine();
                    continue;
                }


                cityAnswer = cityAnswer.Trim();

                bool isCityExist = _weather.Values.Any(w => w.CityName.Equals(cityAnswer, StringComparison.OrdinalIgnoreCase));
                if (!isCityExist)
                {
                    Console.WriteLine("City not found");
                    cityAnswer = Console.ReadLine();
                    continue;
                }


                Console.WriteLine("Enter day amount");
                string? dayAnswer = Console.ReadLine();
                if (!int.TryParse(dayAnswer, out dayCount) || dayCount <= 0)
                {
                    dayAnswer = Console.ReadLine();
                    continue;
                }

                break;
            }

            ExecuteProgram(cityAnswer, dayCount);
        }

        private int ExecuteProgram(string city, int dayAmount)
        {
            int minTemp = -5;
            int maxTemp = 6;

            int minWind = -5;
            int maxWind = 6;

            Weather selectedCity = _weather.Values.First(i => i.CityName.Equals(city, StringComparison.OrdinalIgnoreCase));

            int initialTemp = selectedCity.Temperature;
            int initialWind = selectedCity.Wind;

            string currentSeason = _seasons[_random.Next(_seasons.Length)];

            int weekNum = 0;

            Console.WriteLine($"\nSeason: -----------{currentSeason.ToUpper()}-----------");

            for (int i = 0; i < dayAmount; i++)
            {
                string day = _dayNames[i % 7];
                
                initialTemp += _random.Next(minTemp, maxTemp);
                int currentTemp = initialTemp;

                initialWind += _random.Next(minWind, maxWind);
                int currentWind = initialWind;

                if (i % 7 == 0)
                {
                    weekNum = (i / 7) + 1;

                    Console.WriteLine($"\nWeek- {weekNum}\n");
                }

                
                Console.WriteLine($"{i + 1}--)  City: {city.ToUpper()} | Day: {day} | Temperature: {currentTemp} | Wind: {currentWind}");
            }

            return dayAmount;
        }
    }
}
