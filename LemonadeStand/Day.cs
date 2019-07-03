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
        public int currentDay;
        public string dailyForecast;
        public int dailyTemp;
        //Use the day class to generate the weather and also generate the randomized customer, possibly from a list or an array
        //In the game class create an array of Days

        //for loop with index = i, going through the RunDay array. Also create a method in the Day class to run the daily functions like player purchase, setting recipe, running game.


        //constructors


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

        public void BeginDay(Player player1, int gameLength)
        {
            GetDailyForecast();
            GetDailyTemp();
            PromptPlayerPurchase(player1, gameLength);
        }

        public void PromptPlayerPurchase(Player player1, int gameLength)
        {
            if (player1.totalMoney > 0)
            {
                PurchaseInventory(player1, gameLength);
            }

            else
            {
                Console.WriteLine("Unfortunately you do not have enough money to buy more inventory, please proceed to set your recipe.");
                Console.ReadLine();
                SetRecipe(player1, gameLength);
            }

        }//END LINE OF PREVIOUSLY WORKING CODE IN DAY CLASS

        //Recipe newRecipe = new Recipe();
        public void DisplayInventory(Player player1, int gameLength)//This is just a display of the player's inventory, from here I want to prompt the player to possibly purchase more.
        {
            Console.WriteLine($"{player1.name}'s Inventory:\nFunds: ${player1.totalMoney}\nPaper Cups: {player1.inventory.paperCups}\nLemons: {player1.inventory.lemons}\nCups of Sugar: {player1.inventory.sugarCups}\nIce Cubes: {player1.inventory.iceCubes}\n\n");
        }
        public void PurchaseInventory(Player player1, int gameLength)//possibly create a money class to round the player1.totalMoney
        {
            DisplayWeather();
            DisplayInventory(player1, gameLength);
            if (player1.totalMoney > 0)
            {
                Console.WriteLine($"You can choose which items you want to restock and/or set the recipe by typing in the corresponding number...\n1: Paper cups\n2: Lemons\n3: Cups of sugar\n4: Ice cubes\n5: Set the daily recipe\n");
                int result = Convert.ToInt32(UserInterface.ChooseRestockChoice());
                if (result == 1)
                {
                    PurchasePaperCups(player1, gameLength);
                }

                else if (result == 2)
                {
                    PurchaseLemons(player1, gameLength);
                }

                else if (result == 3)
                {
                    PurchaseSugarCups(player1, gameLength);
                }

                else if (result == 4)
                {
                    PurchaseIceCubes(player1, gameLength);
                }

                else if (result == 5)
                {
                    Console.Clear();
                    SetRecipe(player1, gameLength);
                }
            }

            else
            {
                Console.WriteLine($"You don't have enough funds to purchase any items: ${player1.totalMoney}.");
                SetRecipe(player1, gameLength);
            }

        }

        public void PurchasePaperCups(Player player1, int gameLength)
        {
            Console.WriteLine("Type in the amount of paper cups you want to purchase:");
            string multiplier = Console.ReadLine();
            double totalItemCost;
            if (int.TryParse(multiplier, out int result))
            {
                if (player1.totalMoney >= 0)
                {
                    totalItemCost = result * player1.inventory.paperCupCost;
                    if (player1.totalMoney >= totalItemCost)
                    {
                        player1.inventory.paperCups += result;
                        player1.totalMoney -= result * player1.inventory.paperCupCost;
                        Console.Clear();
                        PurchaseInventory(player1, gameLength);
                    }
                    else
                    {
                        Console.WriteLine($"Sorry, you have insufficient funds to purchase this item: ${player1.totalMoney} remaining. Press enter to continue...");
                        Console.Clear();
                        PurchaseInventory(player1, gameLength);
                    }
                }

                else
                {
                    Console.WriteLine($"Sorry, you have insufficient funds to purchase this item: ${player1.totalMoney}. Press enter to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    PurchaseInventory(player1, gameLength);
                }

            }

            else
            {
                Console.WriteLine("Not a valid input, please type in a number, i.e. '20'. Press enter to continue...");
                Console.ReadLine();
                Console.Clear();
                PurchasePaperCups(player1, gameLength);
            }

        }

        public void PurchaseLemons(Player player1, int gameLength)
        {
            Console.WriteLine("Type in the amount of lemons you want to purchase:");
            string multiplier = Console.ReadLine();
            double totalItemCost;
            if (int.TryParse(multiplier, out int result))
            {
                if (player1.totalMoney >= 0)
                {
                    totalItemCost = result * player1.inventory.lemonCost;
                    if (player1.totalMoney >= totalItemCost)
                    {
                        player1.inventory.lemons += result;
                        player1.totalMoney -= result * player1.inventory.lemonCost;
                        Console.Clear();
                        PurchaseInventory(player1, gameLength);
                    }
                    else
                    {
                        Console.WriteLine($"Sorry, you have insufficient funds to purchase this item: ${player1.totalMoney}. Press enter to continue...");
                        Console.ReadLine();
                        Console.Clear();
                        PurchaseInventory(player1, gameLength);
                    }
                }

                else
                {
                    Console.WriteLine($"Sorry, you have insufficient funds to purchase this item: ${player1.totalMoney}. Press enter to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    PurchaseInventory(player1, gameLength);
                }

            }

            else
            {
                Console.WriteLine("Not a valid input, please try again");
                PurchaseLemons(player1, gameLength);
            }

        }

        public void PurchaseSugarCups(Player player1, int gameLength)
        {
            Console.WriteLine("Type in the amount of cups of sugar you want to purchase:");
            string multiplier = Console.ReadLine();
            double totalItemCost;
            if (int.TryParse(multiplier, out int result))
            {
                if (player1.totalMoney >= 0)
                {
                    totalItemCost = result * player1.inventory.sugarCupsCost;
                    if (player1.totalMoney >= totalItemCost)
                    {
                        player1.inventory.sugarCups += result;
                        player1.totalMoney -= result * player1.inventory.sugarCupsCost;
                        Console.Clear();
                        PurchaseInventory(player1, gameLength);
                    }
                    else
                    {
                        Console.WriteLine($"Sorry, you have insufficient funds to purchase this item: ${player1.totalMoney}. Press enter to continue...");
                        Console.ReadLine();
                        Console.Clear();
                        PurchaseInventory(player1, gameLength);
                    }
                }

                else
                {
                    Console.WriteLine($"Sorry, you have insufficient funds to purchase this item: ${player1.totalMoney}. Press enter to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    PurchaseInventory(player1, gameLength);
                }

            }

            else
            {
                Console.WriteLine("Not a valid input, please try again");
                PurchaseSugarCups(player1, gameLength);
            }
        }

        public void PurchaseIceCubes(Player player1, int gameLength)
        {
            Console.WriteLine("Type in the amount of ice cubes you want to purchase:");
            string multiplier = Console.ReadLine();
            double totalItemCost;
            if (int.TryParse(multiplier, out int result))
            {
                if (player1.totalMoney >= 0)
                {
                    totalItemCost = result * player1.inventory.iceCubesCost;
                    if (player1.totalMoney >= totalItemCost)
                    {
                        player1.inventory.iceCubes += result;
                        player1.totalMoney -= result * player1.inventory.iceCubesCost;
                        Console.Clear();
                        PurchaseInventory(player1, gameLength);
                    }
                    else
                    {
                        Console.WriteLine($"Sorry, you have insufficient funds to purchase this item: ${player1.totalMoney}. Press enter to continue...");
                        Console.ReadLine();
                        Console.Clear();
                        PurchaseInventory(player1, gameLength);
                    }
                }

                else
                {
                    Console.WriteLine($"Sorry, you have insufficient funds to purchase this item: ${player1.totalMoney}. Press enter to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    PurchaseInventory(player1, gameLength);
                }

            }

            else
            {
                Console.WriteLine("Not a valid input, please try again");
                PurchaseIceCubes(player1, gameLength);
            }
        }

        public void SetPrice(Player player1, int gameLength)
        {
            Console.WriteLine("Type in the price you want to set per cup (cents). Default is '25'.");
            string adder = Console.ReadLine();
            if (int.TryParse(adder, out int result))
            {
                player1.recipe.pricePerCup = result;
                Console.Clear();
                SetRecipe(player1, gameLength);
            }
            else
            {
                Console.WriteLine("Not a valid input, please type in a number, i.e. '20'. Press enter to continue...");
                Console.ReadLine();
                Console.Clear();
                SetPrice(player1, gameLength);
            }
        }

        public void DisplayRecipe(Player player1, int gameLength)
        {
            Console.WriteLine($"Recipe List:\nPrice per Cup (cents): {player1.recipe.pricePerCup}\nLemons per Pitcher: {player1.recipe.dailyLemons}\nSugar per Pitcher: {player1.recipe.dailySugarCups}\nIce per Cup: {player1.recipe.dailyIceCubes}\n");
        }

        public void SetRecipe(Player player1, int gameLength)
        {
            DisplayRecipe(player1, gameLength);
            Console.WriteLine("Here you can set the recipe for your lemonade, a base recipe would be 4 of each. You can stay with the basic recipe, however, try to set your recipe based on the weather and conditions. The more or less of an ingredient used can affect demand.\nYou can also change the price per cup but try to adjust it based on weather conditions.\nPress enter to continue...\n");
            Console.ReadLine();
            Console.WriteLine($"You can choose which item you want to adjust by typing in the corresponding number...\n1: Lemons per Pitcher\n2: Sugar per Pitcher\n3: Ice per Cup\n4: Set the price per Cup\n5: Start the game!");
            int result = Convert.ToInt32(UserInterface.ChooseRecipeChoice());
            if (result == 1)
            {
                SetLemonsRecipe(player1, gameLength);
            }

            else if (result == 2)
            {
                SetSugarRecipe(player1, gameLength);
            }

            else if (result == 3)
            {
                SetIceRecipe(player1, gameLength);

            }

            else if (result == 4)
            {
                SetPrice(player1, gameLength);
            }

            else if (result == 5)
            {
                //add 'StartGame' method at the end of this method
            }

        }
        public void SetLemonsRecipe(Player player1, int gameLength)
        {
            Console.WriteLine("Type in the amount of lemons per pitcher you want to add to your recipe:");
            string adder = Console.ReadLine();
            if (int.TryParse(adder, out int result))
            {
                if (player1.inventory.lemons >= result)
                {
                    player1.recipe.dailyLemons += result;
                    Console.Clear();
                    SetRecipe(player1, gameLength);
                }
                else
                {
                    Console.WriteLine($"Sorry, you have insufficient inventory to add to this recipe.");
                    Console.ReadLine();
                }
            }

            else
            {
                Console.WriteLine("Not a valid input, please type in a number, i.e. '20'. Press enter to continue...");
                Console.ReadLine();
                Console.Clear();
                SetLemonsRecipe(player1, gameLength);
            }
        }

        public void SetSugarRecipe(Player player1, int gameLength)
        {
            Console.WriteLine("Type in the amount of sugar per pitcher you want to add to your recipe:");
            string adder = Console.ReadLine();
            if (int.TryParse(adder, out int result))
            {
                if (player1.inventory.sugarCups >= result)
                {
                    player1.recipe.dailySugarCups += result;
                    Console.Clear();
                    SetRecipe(player1, gameLength);
                }
                else
                {
                    Console.WriteLine($"Sorry, you have insufficient inventory to add to this recipe.");
                    Console.ReadLine();
                }
            }

            else
            {
                Console.WriteLine("Not a valid input, please type in a number, i.e. '20'. Press enter to continue...");
                Console.ReadLine();
                Console.Clear();
                SetSugarRecipe(player1, gameLength);
            }
        }

        public void SetIceRecipe(Player player1, int gameLength)
        {
            Console.WriteLine("Type in the amount of ice per cup you want to add to your recipe:");
            string adder = Console.ReadLine();
            if (int.TryParse(adder, out int result))
            {
                if (player1.inventory.iceCubes >= result)
                {
                    player1.recipe.dailyIceCubes += result;
                    Console.Clear();
                    SetRecipe(player1, gameLength);
                }
                else
                {
                    Console.WriteLine($"Sorry, you have insufficient inventory to add to this recipe.");
                    Console.ReadLine();
                }
            }

            else
            {
                Console.WriteLine("Not a valid input, please type in a number, i.e. '20'. Press enter to continue...");
                Console.ReadLine();
                Console.Clear();
                SetIceRecipe(player1, gameLength);
            }
        }

        public void DisplayWeather()
        {
            Console.WriteLine($"Today's Forecast: {dailyForecast}\nToday's High Temperature: {dailyTemp}");
        }
    }
}
