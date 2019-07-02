using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Weather
    {
        //member variables
        public string weatherForecast;
        public int highTemp;
        



        //constructors


        //member methods
        public void GetWeatherForecast()
        {
            //random from 0,5
        }

        public void GetTemperature()
        {
            //get temp between 50-100
        }

        public void GetDailyForecast()
        {
            GetWeatherForecast();
            GetTemperature();
        }
    }
}
