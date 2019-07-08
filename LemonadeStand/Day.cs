﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Day
    {
        //member variables
        public string dailyForecast;
        public int dailyTemp;
        public List<BaseCustomer> potentialCustomers;
        private Random rng;

        //Use the day class to generate the weather and also generate the randomized customer, possibly from a list or an array
        //In the game class create an array of Days

        //for loop with index = i, going through the RunDay array. Also create a method in the Day class to run the daily functions like player purchase, setting recipe, running game.


        //constructors
        public Day(Random rng)
        {
            potentialCustomers = new List<BaseCustomer>();
            this.rng = rng;
        }

        //member methods

        WeatherTypes newWeather = new WeatherTypes();
        public string GetDailyForecast()
        {
            dailyForecast = newWeather.GetWeatherForecast();
            return dailyForecast;
        }

        public int GetDailyTemp()
        {
            dailyTemp = newWeather.GetTemperature();
            return dailyTemp;
        }

        public void BeginDay()
        {
            GetDailyForecast();
            GetDailyTemp();
            GenerateCustomer();
        }

        public void GenerateCustomer()
        {
            int numberOfCustomers;
            numberOfCustomers = rng.Next(60, 100);
            for (int index = 0; index < numberOfCustomers; index++)
            {

                potentialCustomers.Add(new BaseCustomer(this.rng));
                //Console.WriteLine(potentialCustomers[index].name); TESTING CODE
                
            }        
        }


        public void DisplayWeather()
        {
            Console.WriteLine($"Today's Forecast: {dailyForecast}\nToday's High Temperature: {dailyTemp}");
        }

        public void SellLemonade(Player player, Day newDay, Store newStore)
        {
            int customerCount;
            customerCount = 0;
            while (player.recipe.pitcher >= 0)
            {
                foreach (BaseCustomer customer in potentialCustomers)
                {
                    bool bought = customer.WillBuy(player, dailyForecast, dailyTemp); //buylogic method in Cust. class
                    if (bought)
                    {
                        Console.WriteLine($"{customer.name} bought a cup of lemonade!!");
                        customerCount += 1;
                        player.totalMoney += player.recipe.pricePerCup;
                    }
                }
                Console.WriteLine($"{customerCount} customers bought a cup of lemonade.\nPress enter to go to next day.");
                Console.ReadLine();
            }
            Console.WriteLine($"Sorry, you have sold out of lemonade!\n{customerCount} customers bought a cup of lemonade.\nPress enter to go to next day.");
            Console.ReadLine();
        }
    }
}
