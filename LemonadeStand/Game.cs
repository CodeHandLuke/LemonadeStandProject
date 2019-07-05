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
        public Player player1;
        public int gameLength;
        public Random rng;


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



        public void InitializeGame()
        {
            int result = Convert.ToInt32(UserInterface.ValidateGameChoice());
            if (result == 7)
            {
                gameLength = result;
                Console.WriteLine("You chose to play for 7 days\n");
                Inventory inventory1 = new Inventory();
                Recipe recipe1 = new Recipe();
                Random rng = new Random();
                Day newDay = new Day(rng);
                player1 = new Player(inventory1, recipe1);
                player1.InputName();
                Store newStore = new Store(newDay);
                Console.Clear();
                newDay.BeginDay();
                newStore.PromptPlayerPurchase(player1, newDay, newStore); //Put this in menu options / Then RunGame here
            }

            else if (result == 14)
            {
                gameLength = result;
                Console.WriteLine("You chose to play for 14 days\n");
                Inventory inventory1 = new Inventory();
                Recipe recipe1 = new Recipe();
                Day newDay = new Day(rng);
                Store newStore = new Store(newDay);
                player1 = new Player(inventory1, recipe1);
                player1.InputName();
                Console.Clear();
                

            }

            else
            {
                gameLength = result;
                Console.WriteLine("You chose to play for 21 days\n");
                Inventory inventory1 = new Inventory();
                Recipe recipe1 = new Recipe();
                Day newDay = new Day(rng);
                Store newStore = new Store(newDay);
                player1 = new Player(inventory1, recipe1);
                player1.InputName();
                Console.Clear();
                

            }
        }

        public void DisplayPlayerFunds()
        {
            Console.WriteLine($"\nPlayer Funds: ${player1.totalMoney}\n");
        }

        public void RunGame()
        {

        }
    }
}
