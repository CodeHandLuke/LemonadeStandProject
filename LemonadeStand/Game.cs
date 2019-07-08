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
        public int currentDay;
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
                Store newStore = new Store(newDay);
                player1 = new Player(inventory1, recipe1, newDay, newStore);
                player1.InputName();
                Console.Clear();
                RunGame(player1, inventory1, recipe1, newDay, newStore);
            }

            else if (result == 14)
            {
                gameLength = result;
                Console.WriteLine("You chose to play for 14 days\n");
                Inventory inventory1 = new Inventory();
                Recipe recipe1 = new Recipe();
                Random rng = new Random();
                Day newDay = new Day(rng);
                Store newStore = new Store(newDay);
                player1 = new Player(inventory1, recipe1, newDay, newStore);
                player1.InputName();
                Console.Clear();
                

            }

            else
            {
                gameLength = result;
                Console.WriteLine("You chose to play for 21 days\n");
                Inventory inventory1 = new Inventory();
                Recipe recipe1 = new Recipe();
                Random rng = new Random();
                Day newDay = new Day(rng);
                Store newStore = new Store(newDay);
                player1 = new Player(inventory1, recipe1, newDay, newStore);
                player1.InputName();
                Console.Clear();
                

            }
        }

        public void DisplayPlayerFunds()
        {
            Console.WriteLine($"\nPlayer Funds: ${player1.totalMoney}\n");
        }

        public void RunGame(Player player, Inventory inventory, Recipe recipe, Day newDay, Store newStore)
        {
            currentDay = 1;
            while (currentDay <= gameLength)
            {
                newDay.BeginDay();
                MainMenu(player, newDay, newStore);
                player.FillPitcher();
                newDay.CheckLemonade(player, newDay, newStore);
                newDay.SellLemonade(player, newDay, newStore);
                DisplayProfits(player);
                player.profits = 0;
                Console.Clear();
                currentDay++;
            }


        }

        public void MainMenu(Player player, Day newDay, Store newStore)
        {
            Console.WriteLine($"Day: {currentDay}");
            Console.WriteLine($"You can navigate from this screen by typing in the corresponding number...\n1: Go to Store\n2: Set Recipe\n3: Run your Lemonade Stand!\n");
            int result = Convert.ToInt32(UserInterface.ChooseMenuChoice());
            while (result !=3)
            {
                if (result == 1)
                {
                    Console.Clear();
                    newStore.PurchaseInventory(player, newDay, newStore);
                }

                else if (result == 2)
                {
                    Console.Clear();
                    player.SetRecipe(player, newDay, newStore);
                }

                else if (result == 3)
                {
                    Console.Clear();
                }
                Console.Clear();
                Console.WriteLine($"You can navigate from this screen by typing in the corresponding number...\n1: Go to Store\n2: Set Recipe\n3: Run your Lemonade Stand!\n");
                result = Convert.ToInt32(UserInterface.ChooseMenuChoice());
            }
        }

        public void DisplayProfits(Player player)
        {
            player.netGains += player.profits;
            Console.WriteLine($"Your total funds are now ${player.totalMoney}.\nYour total gains for the week are ${player.netGains}\nPress enter to go to next day.");
            Console.ReadLine();
        }

    }
}
