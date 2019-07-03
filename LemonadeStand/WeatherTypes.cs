using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class WeatherTypes
    {
        //member variables 
        public string weatherForecast;
        public int highTemp;
        public string[] forecastArray;


        //constructor
        public WeatherTypes()
        {
            forecastArray = new string[] { "sunny", "cloudy", "rainy", "hazy" };
        }


        //member methods
        public string GetWeatherForecast()
        {
            Random newForecast = new Random();
            int forecast = newForecast.Next(0, forecastArray.Length);
            weatherForecast = forecastArray[forecast];
            return weatherForecast;
        }

        public int GetTemperature()
        {
            Random newTemp = new Random();
            int temperature = newTemp.Next(50, 101);
            highTemp = temperature;
            return highTemp;
        }

        public void GetDailyWeather()
        {
            GetWeatherForecast();
            GetTemperature();
        }
    }
}
