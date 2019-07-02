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
        public Human (Inventory inventory) : base(inventory)
        {
        }


        //methods
        public override void PurchaseInventory()
        {
            if (totalMoney > 0)
            {
                Console.WriteLine($"You can choose which item you want to restock or whether to start the game by typing in the corresponding number\n1: Paper cups\n2: Lemons\n3: Cups of sugar\n4: Ice cubes\n5: Start the game and run your lemonade stand!");
                int result = ChooseRestockChoice();
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
                    //purchase cups of sugar
                }

                else if (result == 4)
                {
                    //purchase ice cubes
                }

                else if (result == 5)
                {
                    //start game
                }
            }

            else
            {
                //start lemonade game
            }

        }

        public int ChooseRestockChoice()
        {
            bool chosenRestockChoice = false;
            int restockChoice = 0;
            while (!chosenRestockChoice)
            {
                restockChoice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("\n");
                switch (restockChoice)
                {
                    case 1:
                        chosenRestockChoice = true;
                        return restockChoice;
                    case 2:
                        chosenRestockChoice = true;
                        return restockChoice;
                    case 3:
                        chosenRestockChoice = true;
                        return restockChoice;
                    case 4:
                        chosenRestockChoice = true;
                        return restockChoice;
                    case 5:
                        chosenRestockChoice = true;
                        return restockChoice;
                    default:
                        Console.WriteLine("Invalid Input, Try again.");
                        break;
                }
            }
            return restockChoice;
        }

        public void PurchasePaperCups()
        {
            Console.WriteLine("Type in the amount of paper cups you want to purchase:");
            string multiplier = Console.ReadLine();
            if (int.TryParse(multiplier, out int result))
            {
                inventory.paperCups += result;
                totalMoney -= result * inventory.paperCupCost;
            }

            else
            {
                Console.WriteLine("Not a valid incorrect, please try again");
                ChooseRestockChoice();
            }

        }

        public void PurchaseLemons()
        {
            Console.WriteLine("Type in the amount of lemons cups you want to purchase:");
            string multiplier = Console.ReadLine();
            if (int.TryParse(multiplier, out int result))
            {
                inventory.lemons += result;
                totalMoney -= result * inventory.lemonCost;
            }

            else
            {
                Console.WriteLine("Not a valid incorrect, please try again");
                ChooseRestockChoice();
            }

        }

        public override void SetPrice()
        {
            throw new NotImplementedException();
        }

        public override void SetRecipe()
        {
            throw new NotImplementedException();
        }
    }
}
