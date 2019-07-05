using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Store
    {
        //member variables


        //constructors
        public Store(Day newDay)
        {
            newDay.DisplayWeather();
        }


        //member methods

        public void DisplayInventory(Player player)//This is just a display of the player's inventory, from here I want to prompt the player to possibly purchase more.
        {
            Console.WriteLine($"{player.name}'s Inventory:\nFunds: ${player.totalMoney}\nPaper Cups: {player.inventory.paperCups}\nLemons: {player.inventory.lemons}\nCups of Sugar: {player.inventory.sugarCups}\nIce Cubes: {player.inventory.iceCubes}\n\n");
        }

        public void PromptPlayerPurchase(Player player, Day newDay, Store newStore)
        {
            if (player.totalMoney > 0)
            {
                PurchaseInventory(player, newDay, newStore);
            }

            else
            {
                Console.WriteLine("Unfortunately you do not have enough money to buy more inventory, please proceed to set your recipe.");
                Console.ReadLine();
                player.SetRecipe(player, newDay, newStore);
            }
        }

        public void PurchaseInventory(Player player, Day newDay, Store newStore)//possibly create a money class to round the totalMoney
        {
            newDay.DisplayWeather();
            if (player.totalMoney > 0)
            {
                DisplayInventory(player);
                Console.WriteLine($"You can choose which items you want to restock and/or set the recipe by typing in the corresponding number...\n1: Paper cups\n2: Lemons\n3: Cups of sugar\n4: Ice cubes\n5: Set the daily recipe\n");
                int result = Convert.ToInt32(UserInterface.ChooseRestockChoice());
                if (result == 1)
                {
                    PurchasePaperCups(player, newDay, newStore);
                }

                else if (result == 2)
                {
                    PurchaseLemons(player, newDay, newStore);
                }

                else if (result == 3)
                {
                    PurchaseSugarCups(player, newDay, newStore);
                }

                else if (result == 4)
                {
                    PurchaseIceCubes(player, newDay, newStore);
                }

                else if (result == 5)
                {
                    Console.Clear();
                    player.SetRecipe(player, newDay, newStore);//change to branching options of player menu **CHANGE THIS**
                }
            }

            else
            {
                Console.WriteLine($"You don't have enough funds to purchase any items: ${player.totalMoney}.");
                player.SetRecipe(player, newDay, newStore);//change to branching options of player menu **CHANGE THIS**
            }

        }
        public void PurchasePaperCups(Player player, Day newDay, Store newStore)
        {
            Console.WriteLine("Type in the amount of paper cups you want to purchase:");
            string multiplier = Console.ReadLine();
            double totalItemCost;
            if (int.TryParse(multiplier, out int result))
            {
                if (player.totalMoney >= 0)
                {
                    totalItemCost = result * player.inventory.paperCupCost;
                    if (player.totalMoney >= totalItemCost)
                    {
                        player.inventory.paperCups += result;
                        player.totalMoney -= result * player.inventory.paperCupCost;
                        Console.Clear();
                        PurchaseInventory(player, newDay, newStore);
                    }
                    else
                    {
                        Console.WriteLine($"Sorry, you have insufficient funds to purchase this item: ${player.totalMoney} remaining. Press enter to continue...");
                        Console.Clear();
                        PurchaseInventory(player, newDay, newStore);
                    }
                }

                else
                {
                    Console.WriteLine($"Sorry, you have insufficient funds to purchase this item: ${player.totalMoney}. Press enter to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    PurchaseInventory(player, newDay, newStore);
                }

            }

            else
            {
                Console.WriteLine("Not a valid input, please type in a number, i.e. '20'. Press enter to continue...");
                Console.ReadLine();
                Console.Clear();
                PurchasePaperCups(player, newDay, newStore);
            }

        }

        public void PurchaseLemons(Player player, Day newDay, Store newStore)
        {
            Console.WriteLine("Type in the amount of lemons you want to purchase:");
            string multiplier = Console.ReadLine();
            double totalItemCost;
            if (int.TryParse(multiplier, out int result))
            {
                if (player.totalMoney >= 0)
                {
                    totalItemCost = result * player.inventory.lemonCost;
                    if (player.totalMoney >= totalItemCost)
                    {
                        player.inventory.lemons += result;
                        player.totalMoney -= result * player.inventory.lemonCost;
                        Console.Clear();
                        PurchaseInventory(player, newDay, newStore);
                    }
                    else
                    {
                        Console.WriteLine($"Sorry, you have insufficient funds to purchase this item: ${player.totalMoney}. Press enter to continue...");
                        Console.ReadLine();
                        Console.Clear();
                        PurchaseInventory(player, newDay, newStore);
                    }
                }

                else
                {
                    Console.WriteLine($"Sorry, you have insufficient funds to purchase this item: ${player.totalMoney}. Press enter to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    PurchaseInventory(player, newDay, newStore);
                }

            }

            else
            {
                Console.WriteLine("Not a valid input, please try again");
                PurchaseLemons(player, newDay, newStore);
            }

        }

        public void PurchaseSugarCups(Player player, Day newDay, Store newStore)
        {
            Console.WriteLine("Type in the amount of cups of sugar you want to purchase:");
            string multiplier = Console.ReadLine();
            double totalItemCost;
            if (int.TryParse(multiplier, out int result))
            {
                if (player.totalMoney >= 0)
                {
                    totalItemCost = result * player.inventory.sugarCupsCost;
                    if (player.totalMoney >= totalItemCost)
                    {
                        player.inventory.sugarCups += result;
                        player.totalMoney -= result * player.inventory.sugarCupsCost;
                        Console.Clear();
                        PurchaseInventory(player, newDay, newStore);
                    }
                    else
                    {
                        Console.WriteLine($"Sorry, you have insufficient funds to purchase this item: ${player.totalMoney}. Press enter to continue...");
                        Console.ReadLine();
                        Console.Clear();
                        PurchaseInventory(player, newDay, newStore);
                    }
                }

                else
                {
                    Console.WriteLine($"Sorry, you have insufficient funds to purchase this item: ${player.totalMoney}. Press enter to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    PurchaseInventory(player, newDay, newStore);
                }

            }

            else
            {
                Console.WriteLine("Not a valid input, please try again");
                PurchaseSugarCups(player, newDay, newStore);
            }
        }

        public void PurchaseIceCubes(Player player, Day newDay, Store newStore)
        {
            Console.WriteLine("Type in the amount of ice cubes you want to purchase:");
            string multiplier = Console.ReadLine();
            double totalItemCost;
            if (int.TryParse(multiplier, out int result))
            {
                if (player.totalMoney >= 0)
                {
                    totalItemCost = result * player.inventory.iceCubesCost;
                    if (player.totalMoney >= totalItemCost)
                    {
                        player.inventory.iceCubes += result;
                        player.totalMoney -= result * player.inventory.iceCubesCost;
                        Console.Clear();
                        PurchaseInventory(player, newDay, newStore);
                    }
                    else
                    {
                        Console.WriteLine($"Sorry, you have insufficient funds to purchase this item: ${player.totalMoney}. Press enter to continue...");
                        Console.ReadLine();
                        Console.Clear();
                        PurchaseInventory(player, newDay, newStore);
                    }
                }

                else
                {
                    Console.WriteLine($"Sorry, you have insufficient funds to purchase this item: ${player.totalMoney}. Press enter to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    PurchaseInventory(player, newDay, newStore);
                }

            }

            else
            {
                Console.WriteLine("Not a valid input, please try again");
                PurchaseIceCubes(player, newDay, newStore);
            }
        }
    }
}
