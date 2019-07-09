using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Player
    {
        //member variables
        public string name;
        public double totalMoney;
        public double profits; //how much the player makes per day
        public double expenses; //how much player spent on ingredients per day
        public double netGains; //total profits during the game 
        public double netProfit; //total loss or profit at the end of the game
        public double netLoss; //total losses during the game
        public Inventory inventory;
        public Recipe recipe;




        //constructors
        public Player(Inventory inventory, Recipe recipe, Day day, Store store)
        {
            totalMoney = 20;
            netGains = 0;
            netProfit = 0;
            netLoss = 0;
            profits = 0;
            expenses = 0;
            this.inventory = inventory;
            this.recipe = recipe;

        }


        //member methods
        public void InputName() //This method serves to have the players (human) input their own name
        {
            Console.WriteLine("Please enter a name for Player");
            name = Console.ReadLine();
        }

        public void DisplayInventory()//This is just a display of the player's inventory, from here I want to prompt the player to possibly purchase more.
        {
            Console.WriteLine($"{name}'s Inventory:\nFunds: ${totalMoney}\nPaper Cups: {inventory.paperCups}\nLemons: {inventory.lemons}\nCups of Sugar: {inventory.sugarCups}\nIce Cubes: {inventory.iceCubes}\n\n");
        }

        public void SetPrice(Player player, Day newDay, Store newStore)
        {
            Console.WriteLine("Type in the price you want to set per cup (cents). Default is '25'.");
            string adder = Console.ReadLine();
            if (int.TryParse(adder, out int result))
            {
                recipe.pricePerCup = result;
                Console.Clear();
                SetRecipe(player, newDay, newStore);
            }
            else
            {
                Console.WriteLine("Not a valid input, please type in a number, i.e. '20'. Press enter to continue...");
                Console.ReadLine();
                Console.Clear();
                SetPrice(player, newDay, newStore);
            }
        }

        public void DisplayRecipe()
        {
            Console.WriteLine($"Recipe List:\nPrice per Cup (cents): {recipe.pricePerCup}\nLemons per Pitcher: {recipe.dailyLemons}\nSugar per Pitcher: {recipe.dailySugarCups}\nIce per Cup: {recipe.dailyIceCubes}\n");
        }

        public void SetRecipe(Player player, Day newDay, Store newStore)
        {
            newDay.DisplayWeather();
            DisplayRecipe();
            Console.WriteLine("Here you can set the recipe for your lemonade, a base recipe would be 4 of each. You can stay with the basic recipe, however, try to set your recipe based on the weather and conditions. The more or less of an ingredient used can affect demand.\nYou can also change the price per cup but try to adjust it based on weather conditions.\n");
            Console.WriteLine($"You can choose which item you want to adjust by typing in the corresponding number...\n1: Lemons per Pitcher\n2: Sugar per Pitcher\n3: Ice per Cup\n4: Set the price per Cup\n5: Return to the Store.");
            int result = Convert.ToInt32(UserInterface.ChooseRecipeChoice());
            if (result == 1)
            {
                SetLemonsRecipe(player, newDay, newStore);
            }

            else if (result == 2)
            {
                SetSugarRecipe(player, newDay, newStore);
            }

            else if (result == 3)
            {
                SetIceRecipe(player, newDay, newStore);

            }

            else if (result == 4)
            {
                SetPrice(player, newDay, newStore);
            }

            else if (result == 5)
            {
                Console.Clear();
                newStore.PromptPlayerPurchase(player, newDay, newStore);
            }
        }
        public void SetLemonsRecipe(Player player, Day newDay, Store newStore)
        {
            Console.WriteLine("Type in the amount of lemons per pitcher you want to add to your recipe:");
            string adder = Console.ReadLine();
            if (int.TryParse(adder, out int result))
            {
                if (inventory.lemons >= result)
                {
                    recipe.dailyLemons = result;
                    Console.Clear();
                    SetRecipe(player, newDay, newStore);
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
                SetLemonsRecipe(player, newDay, newStore);
            }
        }

        public void SetSugarRecipe(Player player, Day newDay, Store newStore)
        {
            Console.WriteLine("Type in the amount of sugar per pitcher you want to add to your recipe:");
            string adder = Console.ReadLine();
            if (int.TryParse(adder, out int result))
            {
                if (inventory.sugarCups >= result)
                {
                    recipe.dailySugarCups = result;
                    Console.Clear();
                    SetRecipe(player, newDay, newStore); //If I use the while loop in the SetRecipe M, get rid of these loops in the helper methods
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
                SetSugarRecipe(player, newDay, newStore);
            }
        }

        public void SetIceRecipe(Player player, Day newDay, Store newStore)
        {
            Console.WriteLine("Type in the amount of ice per cup you want to add to your recipe:");
            string adder = Console.ReadLine();
            if (int.TryParse(adder, out int result))
            {
                if (inventory.iceCubes >= result)
                {
                    recipe.dailyIceCubes = result;
                    Console.Clear();
                    SetRecipe(player, newDay, newStore);
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
                SetIceRecipe(player, newDay, newStore);
            }
        }

        public bool FillPitcher()
        {
             if (inventory.lemons >= recipe.dailyLemons && inventory.sugarCups >= recipe.dailySugarCups && inventory.paperCups >= recipe.cupsPerPitcher)
            {
                return true;
            }

             else
            {
                Console.WriteLine("Sorry, you do not have enough ingredients to refill your pitcher!");
                return false;
            }
        }

        public void RefillPitcher()
        {
            inventory.paperCups -= 12;
            inventory.lemons -= recipe.dailyLemons;
            inventory.sugarCups -= recipe.dailySugarCups;
            recipe.pitcher += 12;
        }

        public bool CheckPitcher()
        {
            if (recipe.pitcher < 1)
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
