using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class BaseCustomer
    {
        //member variables
        public string name;
        public int thirstLevel;
        public bool frugal;

        //constructors
        //
        public BaseCustomer(Random rng)
        {
            string[] names = { "Adam", "Brittany", "Chris", "Deziree", "Eric", "Felicia", "Gary", "Helen", "Isaac", "Jackie", "Luke" };
            int index = rng.Next(0, names.Length);
            name = names[index];
            thirstLevel = rng.Next(3, 11);
            frugal = Convert.ToBoolean(rng.Next(0, 2));
        }

        //member methods

        public void ConsumerConsideration(Player player, string forecast, int highTemperature)
        {
            if (forecast == "sunny" || forecast == "hazy" && highTemperature > 75 && player.recipe.dailyIceCubes >= 6)
            {
                thirstLevel += 4;
                if (player.recipe.pricePerCup <= 15)
                {
                    thirstLevel += 4;
                }
                else if (frugal == true)
                {
                    if (player.recipe.pricePerCup > 45)
                    {
                        thirstLevel -= 2;
                    }
                }
                else if (player.recipe.dailyLemons <= 3 || player.recipe.dailySugarCups <= 3)
                {
                    thirstLevel -= 2;
                }
            }

            else if (forecast == "sunny" || forecast == "hazy" && highTemperature > 75)
            {
                thirstLevel += 3;
                if (player.recipe.pricePerCup <= 15)
                {
                    thirstLevel += 3;
                }
                else if (frugal == true)
                {
                    if (player.recipe.pricePerCup > 35)
                    {
                        thirstLevel -= 2;
                    }
                }

                else if (player.recipe.dailyLemons <= 3 || player.recipe.dailySugarCups <= 3)
                {
                    thirstLevel -= 1;
                }
            }

            else if (forecast == "sunny" || forecast == "hazy" && highTemperature < 75)
            {
                thirstLevel += 2;
                if (player.recipe.pricePerCup <= 15)
                {
                    thirstLevel += 3;
                }
                else if (frugal == true)
                {
                    if (player.recipe.pricePerCup > 30)
                    {
                        thirstLevel -= 3;
                    }
                }

                else if (player.recipe.dailyLemons < 3 || player.recipe.dailySugarCups < 3)
                {
                    thirstLevel -= 2;
                }
            }

            else if (forecast == "cloudy" || forecast == "rainy" && highTemperature > 70)
            {
                thirstLevel += 1;
                if (player.recipe.pricePerCup <= 10)
                {
                    thirstLevel += 3;
                }
               else if (frugal == true)
                {
                    if (player.recipe.pricePerCup > 20)
                    {
                        thirstLevel -= 3;
                    }
                }
                else if (player.recipe.dailyLemons < 3 || player.recipe.dailySugarCups < 3)
                {
                    thirstLevel -= 2;
                }
            }

            else if (forecast == "cloudy" || forecast == "rainy" && highTemperature < 70)
            {
                thirstLevel -= 1;
                if (player.recipe.pricePerCup <= 12)
                {
                    thirstLevel += 2;
                }
               else if (frugal == true)
                {
                    if (player.recipe.pricePerCup > 15)
                    {
                        thirstLevel -= 4;
                    }
                }

                else if (player.recipe.dailyLemons < 3 || player.recipe.dailySugarCups < 3)
                {
                    thirstLevel -= 2;
                }
            }
        }
        public bool WillBuy(Player player, string forecast, int highTemperature)
        {
            ConsumerConsideration(player, forecast, highTemperature);
            if (thirstLevel >= 7)
            {
                return true;
            }

            else
            {
                return false;
            }
        }

    }
}
