using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Human : Player
    {
        //variables



        //constructors
        public Human (Inventory inventory, Recipe recipe) : base(inventory, recipe)
        {
            //This constructor was created to pass in the inventory values from the Inventory Class
        }


        //methods
        public void DisplayInventory()//This is just a display of the player's inventory, from here I want to prompt the player to possibly purchase more.
        {
            Console.WriteLine($"{name}'s Inventory:\nFunds: ${totalMoney}\nPaper Cups: {inventory.paperCups}\nLemons: {inventory.lemons}\nCups of Sugar: {inventory.sugarCups}\nIce Cubes: {inventory.iceCubes}\n\n");
        }
        public override void PurchaseInventory()//possibly create a money class to round the totalMoney
        {
            DisplayInventory();
            if (totalMoney > 0)
            {
                Console.WriteLine($"You can choose which items you want to restock and/or set the recipe by typing in the corresponding number...\n1: Paper cups\n2: Lemons\n3: Cups of sugar\n4: Ice cubes\n5: Set the daily recipe\n");
                int result = Convert.ToInt32(ChooseRestockChoice());
                if (result == 1)
                {
                    PurchasePaperCups();
                }

                else if (result == 2)
                {
                    PurchaseLemons();
                }

                else if (result == 3)
                {
                    PurchaseSugarCups();
                }

                else if (result == 4)
                {
                    PurchaseIceCubes();
                }

                else if (result == 5)
                {
                    Console.Clear();
                    SetRecipe();
                }
            }

            else
            {
                Console.WriteLine($"You don't have enough funds to purchase any items: ${totalMoney}.");
                SetRecipe();
            }

        }

        public string ChooseRestockChoice()
        {
            bool chosenRestockChoice = false;
            string restockChoice = "";
            while (!chosenRestockChoice)
            {
                restockChoice = (Console.ReadLine());
                Console.WriteLine("\n");
                switch (restockChoice)
                {
                    case "1":
                        chosenRestockChoice = true;
                        return restockChoice;
                    case "2":
                        chosenRestockChoice = true;
                        return restockChoice;
                    case "3":
                        chosenRestockChoice = true;
                        return restockChoice;
                    case "4":
                        chosenRestockChoice = true;
                        return restockChoice;
                    case "5":
                        chosenRestockChoice = true;
                        return restockChoice;
                    default:
                        Console.WriteLine("Invalid input, please try again.");
                        break;
                }
            }
            return restockChoice;
        }

        public void PurchasePaperCups()
        {
            Console.WriteLine("Type in the amount of paper cups you want to purchase:");
            string multiplier = Console.ReadLine();
            double totalItemCost;
            if (int.TryParse(multiplier, out int result))
            {
                if (totalMoney >= 0)
                {
                    totalItemCost = result * inventory.paperCupCost;
                    if (totalMoney >= totalItemCost)
                    {
                        inventory.paperCups += result;
                        totalMoney -= result * inventory.paperCupCost;
                        Console.Clear();
                        PurchaseInventory();
                    }
                    else
                    {
                        Console.WriteLine($"Sorry, you have insufficient funds to purchase this item: ${totalMoney} remaining. Press enter to continue...");
                        Console.Clear();
                        PurchaseInventory();
                    }
                }

                else
                {
                    Console.WriteLine($"Sorry, you have insufficient funds to purchase this item: ${totalMoney}. Press enter to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    PurchaseInventory();
                }

            }

            else
            {
                Console.WriteLine("Not a valid incorrect, please type in a number, i.e. '20'. Press enter to continue...");
                Console.ReadLine();
                Console.Clear();
                PurchasePaperCups();
            }

        }

        public void PurchaseLemons()
        {
            Console.WriteLine("Type in the amount of lemons you want to purchase:");
            string multiplier = Console.ReadLine();
            double totalItemCost;
            if (int.TryParse(multiplier, out int result))
            {
                if (totalMoney >= 0)
                {
                    totalItemCost = result * inventory.lemonCost;
                    if (totalMoney >= totalItemCost)
                    {
                        inventory.lemons += result;
                        totalMoney -= result * inventory.lemonCost;
                        Console.Clear();
                        PurchaseInventory();
                    }
                    else
                    {
                        Console.WriteLine($"Sorry, you have insufficient funds to purchase this item: ${totalMoney}. Press enter to continue...");
                        Console.ReadLine();
                        Console.Clear();
                        PurchaseInventory();
                    }
                }

                else
                {
                    Console.WriteLine($"Sorry, you have insufficient funds to purchase this item: ${totalMoney}. Press enter to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    PurchaseInventory();
                }
                
            }

            else
            {
                Console.WriteLine("Not a valid incorrect, please try again");
                PurchaseLemons();
            }

        }

        public void PurchaseSugarCups()
        {
            Console.WriteLine("Type in the amount of cups of sugar you want to purchase:");
            string multiplier = Console.ReadLine();
            double totalItemCost;
            if (int.TryParse(multiplier, out int result))
            {
                if (totalMoney >= 0)
                {
                    totalItemCost = result * inventory.sugarCupsCost;
                    if (totalMoney >= totalItemCost)
                    {
                        inventory.sugarCups += result;
                        totalMoney -= result * inventory.sugarCupsCost;
                        Console.Clear();
                        PurchaseInventory();
                    }
                    else
                    {
                        Console.WriteLine($"Sorry, you have insufficient funds to purchase this item: ${totalMoney}. Press enter to continue...");
                        Console.ReadLine();
                        Console.Clear();
                        PurchaseInventory();
                    }
                }

                else
                {
                    Console.WriteLine($"Sorry, you have insufficient funds to purchase this item: ${totalMoney}. Press enter to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    PurchaseInventory();
                }

            }

            else
            {
                Console.WriteLine("Not a valid incorrect, please try again");
                PurchaseSugarCups();
            }
        }

        public void PurchaseIceCubes()
        {
            Console.WriteLine("Type in the amount of ice cubes you want to purchase:");
            string multiplier = Console.ReadLine();
            double totalItemCost;
            if (int.TryParse(multiplier, out int result))
            {
                if (totalMoney >= 0)
                {
                    totalItemCost = result * inventory.iceCubesCost;
                    if (totalMoney >= totalItemCost)
                    {
                        inventory.iceCubes += result;
                        totalMoney -= result * inventory.iceCubesCost;
                        Console.Clear();
                        PurchaseInventory();
                    }
                    else
                    {
                        Console.WriteLine($"Sorry, you have insufficient funds to purchase this item: ${totalMoney}. Press enter to continue...");
                        Console.ReadLine();
                        Console.Clear();
                        PurchaseInventory();
                    }
                }

                else
                {
                    Console.WriteLine($"Sorry, you have insufficient funds to purchase this item: ${totalMoney}. Press enter to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    PurchaseInventory();
                }

            }

            else
            {
                Console.WriteLine("Not a valid incorrect, please try again");
                PurchaseIceCubes();
            }
        }

        public override void SetPrice()
        {
            throw new NotImplementedException();
        }

        public override void SetRecipe()
        {
            Console.WriteLine("This is the method for SetRecipe");
            Console.ReadLine();
            //add 'StartGame' method at the end of this method
        }
    }
}
