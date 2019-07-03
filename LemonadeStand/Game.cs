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
            Console.WriteLine($"Welcome to the Lemonade Stand game! You are an entrepreneur that will start with $20 to setup a lemonade stand to sell as much lemonade as possible in a specified timeframe.");
            Console.ReadLine();
            DisplayRules();
        }

        public void DisplayRules()
        {
            Console.WriteLine($"You can choose 7, 14, or 21 days to run your lemonade stand and sell your lemonade. At the end, your net gains will be calculated to see if you made a profit or a loss.\n\nAt the beginning of each day, you will buy cups, lemons, sugar, and ice cubes, then you will have to determine the quantities of each ingredient you want in your recipe.\n\nThere will be a daily weather forecast which you should use to determine how you set your recipe and price per cup.\n\nYou can experiment with the price and recipe as they relate to the weather, for better results. Press enter to continue...\n");
            Console.ReadLine();
            Console.Clear();
            InitializeGame();
        }

        public string ValidateGameChoice()
        {
            bool isInputValid = false;
            string gameChoice = "";
            while (!isInputValid)
            {
                Console.WriteLine("Choose whether you want to play for 7, 14, or 21 days by typing in the '7', '14', or '21'...");
                gameChoice = Console.ReadLine();
                switch (gameChoice)
                {
                    case "7":
                        isInputValid = true;
                        Console.Clear();
                        return gameChoice;
                    case "14":
                        isInputValid = true;
                        Console.Clear();
                        return gameChoice;
                    case "21":
                        isInputValid = true;
                        Console.Clear();
                        return gameChoice;
                    default:
                        Console.WriteLine("Invalid Input, Try again.");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                }
            }
            return gameChoice;
        }

        public void InitializeGame()
        {
            int result = Convert.ToInt32(ValidateGameChoice());
            if (result == 7)
            {
                Console.WriteLine("You chose to play for 7 days\n");
                Inventory inventory1 = new Inventory();
                Recipe recipe1 = new Recipe();
                player1 = new Human(inventory1, recipe1);
                player1.InputName();
                Console.Clear();
                PromptPlayerPurchase();
            }

            else if (result == 14)
            {
                Console.WriteLine("You chose to play for 14 days\n");
                Inventory inventory1 = new Inventory();
                Recipe recipe1 = new Recipe();
                player1 = new Human(inventory1, recipe1);
                player1.InputName();
                Console.Clear();
                PromptPlayerPurchase();
            }

            else
            {
                Console.WriteLine("You chose to play for 21 days\n");
                Inventory inventory1 = new Inventory();
                Recipe recipe1 = new Recipe();
                player1 = new Human(inventory1, recipe1);
                player1.InputName();
                Console.Clear();
                PromptPlayerPurchase();
            }
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
            }

            else
            {
                Console.WriteLine("Unfortunately you do not have enough money to buy more inventory, please proceed to set your recipe.");
                Console.ReadLine();
                player1.SetRecipe();
            }
            
        }
    }
}
