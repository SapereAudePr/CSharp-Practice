using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp
{
    class Weather
    {
        public string CityName { get; set; }
        public int Temperature { get; set; }
        public int Wind { get; set; }

        public Weather(string cityName, int temperature, int wind)
        {
            CityName = cityName;
            Temperature = temperature;
            Wind = wind;
        }
    }
}
