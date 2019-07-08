using System;
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
        public int customerCount;

        //Use the day class to generate the weather and also generate the randomized customer, possibly from a list or an array
        //In the game class create an array of Days

        //for loop with index = i, going through the RunDay array. Also create a method in the Day class to run the daily functions like player purchase, setting recipe, running game.


        //constructors
        public Day(Random rng)
        {
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
            potentialCustomers = new List<BaseCustomer>();
            int numberOfCustomers;
            numberOfCustomers = rng.Next(50, 100);
            for (int index = 0; index < numberOfCustomers; index++)
            {
                potentialCustomers.Add(new BaseCustomer(this.rng));                
            }        
        }

        public void DisplayWeather()
        {
            Console.WriteLine($"Today's Forecast: {dailyForecast}\nToday's High Temperature: {dailyTemp}");
        }

        public void SellLemonade(Player player, Day newDay, Store newStore)
        {
            customerCount = 0;
            bool refillPitcher;
            refillPitcher = player.FillPitcher();
            if (refillPitcher)
            {
                player.RefillPitcher();
            }

            else
            {
                Console.WriteLine("TEST DAY Sorry, you do not have enough ingredients to refill your pitcher!");
            }

            foreach (BaseCustomer customer in potentialCustomers)
            {
                bool bought = customer.WillBuy(player, dailyForecast, dailyTemp);
                if (player.recipe.pitcher <= 0)
                {
                    if (player.FillPitcher())
                    {
                        player.RefillPitcher();
                        if (bought)
                        {
                            customerCount += 1;
                            player.recipe.pitcher -= 1;
                            player.inventory.iceCubes -= player.recipe.dailyIceCubes;
                            player.totalMoney += player.recipe.pricePerCup * .01;
                            player.profits += player.recipe.pricePerCup * .01;
                        }
                    }

                    else
                    {
                        Console.WriteLine("You have sold out of lemonade!");
                        break;
                    }
                }

                else
                {
                    if (bought)
                    {
                        customerCount += 1;
                        player.recipe.pitcher -= 1;
                        player.inventory.iceCubes -= player.recipe.dailyIceCubes;
                        player.totalMoney += player.recipe.pricePerCup * .01;
                        player.profits += player.recipe.pricePerCup * .01;
                    }
                }
            }
        }

        public void DisplayEarnings(Player player)
        {
            Console.WriteLine($"\n{customerCount} customers bought a cup of lemonade and you made ${player.profits} in profit for the day.\nPress enter to see your net gains for the week.");
            Console.ReadLine();
        }
    }
}
