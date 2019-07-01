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
            Console.WriteLine($"You can choose which item you want to restock by typing in the corresponding number\n1: Paper cups\n2: Lemons\n3: Cups of sugar\n4: Ice cubes\n");
            int result = ChooseRestockChoice();
            if (result == 1)
            {
                //purchase paper cups
            }

            else if (result == 2)
            {
                //purchase lemons
            }

            else if (result == 3)
            {
                //purchase cups of sugar
            }

            else if (result == 4)
            {
                //purchase ice cubes
            }
        }

        public int ChooseRestockChoice()//Don't forget to add a bulk discount
        {
            bool chosenRestockChoice = false;
            int restockChoice = 0;
            while (!chosenRestockChoice)
            {
                Console.WriteLine("Choose whether you want to play for 7, 14, or 21 days by typing in the '7', '14', or '21'...");
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
                    default:
                        Console.WriteLine("Invalid Input, Try again.");
                        break;
                }
            }
            return restockChoice;
        }

        public void PurchasePaperCups()
        {
            Console.WriteLine("Type in the amount of paper cups you want to purchase. The more you purchase, the cheaper the overall cost of items\nType in the number of paper cups you want to buy:");
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
