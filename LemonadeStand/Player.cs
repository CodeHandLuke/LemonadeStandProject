using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public abstract class Player
    {
        //member variables
        public string playerName;
        public double totalMoney;
        public double netGains;
        public double netProfit;
        public double netLoss;
        public Inventory inventory;




        //constructors
        public Player(Inventory inventory)
        {
            totalMoney = 20;
            netGains = 0;
            netProfit = 0;
            netLoss = 0;
            this.inventory = inventory;
        }


        //member methods
        public void InputName() //This method serves to have the players (human) input their own name
        {
            Console.WriteLine("Please enter a name for Player");
            playerName = Console.ReadLine();
        }

        public abstract void PurchaseInventory(); //This will serve as the function to prompt the player to purchase their daily inventory

        public abstract void SetPrice(); //This method will have the player set the price per cup of lemonade

        public abstract void SetRecipe(); //This method will have the player set the amount of each item to use in the recipe
    }
}
