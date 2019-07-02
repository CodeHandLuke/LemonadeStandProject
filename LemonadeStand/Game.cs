using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Game
    {
        //member variables
        Player player1;
        public int gameLength;


        //constructors


        //member methods
        public void PlayGame()
        {
            //InitializeGame will show the rules and have the player choose whether they want to play for 7, 14, or 21 days.
            Console.WriteLine($"Welcome to the Lemonade Stand game! You are an entrepreneur that will start with $20 to setup a lemonade stand to sell as much lemonade as possible.");
            Console.ReadLine();
            DisplayRules();
        }

        public void DisplayRules()
        {
            Console.WriteLine($"You can choose 7, 14, or 21 days to run your lemonade stand and sell your lemonade. At the end, your net gains will be calculated to see if you made a profit or a loss.\n\nAt the beginning of each day, you will buy cups, lemons, sugar, and ice cubes, then you will have to determine the quantities of each ingredient you want in your recipe.\n\nThere will be a daily weather forecast which you should use to determine how you set your recipe and price per cup.\n\nYou can experiment with the price and recipe as they relate to the weather, for better results. Press enter to continue...\n");
            Console.ReadLine();
            InitializeGame();
        }

        public int ChooseGameType()
        {
            bool chooseGameType = false;
            while (!chooseGameType)
            {
                Console.WriteLine("Choose whether you want to play for 7, 14, or 21 days by typing in the '7', '14', or '21'...");
                gameLength = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("\n");
                switch (gameLength)
                {
                    case 7:
                        chooseGameType = true;
                        return gameLength;
                    case 14:
                        chooseGameType = true;
                        return gameLength;
                    case 21:
                        chooseGameType = true;
                        return gameLength;
                    default:
                        Console.WriteLine("Invalid Input, Try again.");
                        break;
                }
            }
            return gameLength;
        }

        public void InitializeGame()
        {
            int result = ChooseGameType();
            if (result == 7)
            {
                Console.WriteLine("You chose to play for 7 days");
                Inventory inventory1 = new Inventory();
                player1 = new Human(inventory1);
                player1.InputName();
                Console.WriteLine("\n");
                StartGame();
            }

            else if (result == 14)
            {
                Console.WriteLine("You chose to play for 14 days");
                Inventory inventory1 = new Inventory();
                player1 = new Human(inventory1);
                player1.InputName();
                Console.WriteLine("\n");
            }

            else
            {
                Console.WriteLine("You chose to play for 21 days");
                Inventory inventory1 = new Inventory();
                player1 = new Human(inventory1);
                player1.InputName();
                Console.WriteLine("\n");
            }
        }

        public void StartGame()
        {
            ShowInventory();
        }

        public void ShowInventory()//This is just a display of the player's inventory, from here I want to prompt the player to possibly purchase more.
        {
            Console.WriteLine($"Inventory:\nPlayer Funds: ${player1.totalMoney}\nPaper Cups: {player1.inventory.paperCups}\nLemons: {player1.inventory.lemons}\nCups of Sugar: {player1.inventory.sugarCups}\nIce Cubes: {player1.inventory.iceCubes}\n\nHere you can use your funds to purchase more ingredients or cups to make lemonade.\n\n");
            Console.WriteLine("Press continue to choose how you want to restock your inventory...");
            Console.ReadLine();
            PromptPlayerPurchase();
            Console.Clear();
        }

        public void DisplayPlayerFunds()
        {
            Console.WriteLine($"\nPlayer Funds: ${player1.totalMoney}\n");
        }

        public void PromptPlayerPurchase()
        {
            if (player1.totalMoney > 0)
            {
                player1.PurchaseInventory();
                ShowInventory();
            }

            else
            {
                Console.WriteLine("Unfortunately you do not have enough money to buy more inventory, please proceed to open your lemonade stand and see if you can make more money!");
                Console.ReadLine();
                //add the method to start the game loop
            }
            
        }
    }
}
