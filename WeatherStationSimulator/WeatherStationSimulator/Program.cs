namespace WeatherStationSimulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            int dayAmount = 0;

            Console.WriteLine("Enter day amount");
            while (!int.TryParse(Console.ReadLine(), out dayAmount) || dayAmount <= 0)
            {
                Console.WriteLine("Enter a number greater than 0.");
            }

            string[] cities = { "Adana", "Ankara", "Erzurum", "Mersin" };

            Console.WriteLine($"Enter your city name:\n{string.Join("\n", cities)}\n");
            string cityChoice = Console.ReadLine();

            while (!cities.Contains(cityChoice, StringComparer.OrdinalIgnoreCase))
            {
                Console.WriteLine("Enter a valid city name");
                cityChoice = Console.ReadLine();
            }

            string[] days = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

            string[] seasons = { "Spring", "Summer", "Autumn", "Winter" };

            string currentSeason = seasons[random.Next(seasons.Length)];

            int[] temperature = new int[dayAmount];

            int[] wind = new int[dayAmount];

            string[] coldWeather = { "Snow", "Blizzard", "Freezing", "Hail", "Frost" };

            string[] hotWeather = { "Sunny", "Heatwave", "Scorching", "Dry", "Humid" };

            string[] mildWeather = { "Cloudy", "Breezy", "Cool", "Overcast", "Pleasant" };

            string[] stormyWeather = { "Thunderstorm", "Heavy Rain", "Lightning", "Windy", "Tornado" };

            int weekCount = 0;

            string currentWeather = "";

            int currentTemp = 0;

            int selectedCity = 1;

            switch (cityChoice.ToLower())
            {
                case "Adana":
                    if (currentSeason == "Spring")
                    {
                        currentTemp = random.Next(15, 31);
                    }
                    else if (currentSeason == "Summer")
                    {
                        currentTemp = random.Next(25, 56);
                    }
                    else if (currentSeason == "Autumn")
                    {
                        currentTemp = random.Next(10, 35);
                    }
                    else if (currentSeason == "Winter")
                    {
                        currentTemp = random.Next(-3, 25);
                    }
                    selectedCity = 1;
                    break;

                case "Ankara":
                    if (currentSeason == "Spring")
                    {
                        currentTemp = random.Next(0, 26);
                    }
                    else if (currentSeason == "Summer")
                    {
                        currentTemp = random.Next(10, 41);
                    }
                    else if (currentSeason == "Autumn")
                    {
                        currentTemp = random.Next(5, 26);
                    }
                    else if (currentSeason == "Winter")
                    {
                        currentTemp = random.Next(-20, 11);
                    }
                    selectedCity = 2;
                    break;

                case "Erzurum":
                    if (currentSeason == "Spring")
                    {
                        currentTemp = random.Next(0, 26);
                    }
                    else if (currentSeason == "Summer")
                    {
                        currentTemp = random.Next(10, 36);
                    }
                    else if (currentSeason == "Autumn")
                    {
                        currentTemp = random.Next(10, 21);
                    }
                    else if (currentSeason == "Winter")
                    {
                        currentTemp = random.Next(-30, 1);
                    }
                    selectedCity = 3;
                    break;

                case "Mersin":
                    if (currentSeason == "Spring")
                    {
                        currentTemp = random.Next(15, 36);
                    }
                    else if (currentSeason == "Summer")
                    {
                        currentTemp = random.Next(25, 56);
                    }
                    else if (currentSeason == "Autumn")
                    {
                        currentTemp = random.Next(10, 35);
                    }
                    else if (currentSeason == "Winter")
                    {
                        currentTemp = random.Next(-3, 25);
                    }
                    selectedCity = 4;
                    break;

                default:
                    break;
            }

            for (int i = 0; i < dayAmount; i++)
            {
                if (i % 7 == 0)
                {
                    weekCount++;
                    Console.WriteLine($"\n-- Week {weekCount}");
                }

                if (i != 0) currentTemp += random.Next(-8, 9);

                /*/

                currentTemp = selectedCity switch
                {
                    1 => Math.Clamp(currentTemp, -3, 55),
                    2 => Math.Clamp(currentTemp, -20, 35),
                    3 => Math.Clamp(currentTemp, -40, 30),
                    4 => Math.Clamp(currentTemp, -3, 50),
                    _ => currentTemp
                };

                /*/

                temperature[i] = currentTemp;

                string dayNames = days[i % days.Length];
                wind[i] = random.Next(0, 61);

                if (temperature[i] < 0 && wind[i] < 50)
                {
                    currentWeather = coldWeather[random.Next(coldWeather.Length)];
                }
                else if (temperature[i] > 30 && wind[i] < 50)
                {
                    currentWeather = hotWeather[random.Next(hotWeather.Length)];
                }
                else if (wind[i] > 50 && temperature[i] < 30)
                {
                    currentWeather = stormyWeather[random.Next(stormyWeather.Length)];
                }
                else
                {
                    currentWeather = mildWeather[random.Next(mildWeather.Length)];
                }

                Console.WriteLine($"{currentSeason} | {cityChoice} | {dayNames} | {temperature[i]}°C | Wind: {wind[i]} | {currentWeather}");
            }

            FindExtremes(days, temperature, wind);

            Console.ReadKey();
        }

        static void FindExtremes(string[] days, int[] temp, int[] wind)
        {
            double tempAverage = (double)temp.Sum() / temp.Length;
            double windAverage = (double)wind.Sum() / wind.Length;
            //int minTemp = temp.Min();
            //int maxTemp = temp.Max();
            int minTemp = temp[0];
            int maxTemp = temp[0];
            int minIndex = 0;
            int maxIndex = 0;

            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i] < minTemp)
                {
                    minTemp = temp[i];
                    minIndex = i;
                }

                if (temp[i] > maxTemp)
                {
                    maxTemp = temp[i];
                    maxIndex = i;
                }
            }

            string coldestDay = days[minIndex % days.Length];
            var coldWeek = (minIndex / 7) + 1;
            string hottestDay = days[maxIndex % days.Length];
            var hotWeek = (maxIndex / 7) + 1;

            Console.WriteLine($"\nAverage temperature: {tempAverage:F1}°C");
            Console.WriteLine($"Average wind speed: {windAverage:F1} km/h");
            Console.WriteLine($"Minimum temperature: {minTemp}°C | {coldestDay} | Week {coldWeek}");
            Console.WriteLine($"Maximum temperature: {maxTemp}°C | {hottestDay} | Week {hotWeek}");
        }
    }
}
