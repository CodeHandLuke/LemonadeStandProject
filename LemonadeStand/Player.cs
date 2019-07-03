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
        public double netGains;
        public double netProfit;
        public double netLoss;
        public Inventory inventory;
        public Recipe recipe;




        //constructors
        public Player(Inventory inventory, Recipe recipe)
        {
            totalMoney = 20;
            netGains = 0;
            netProfit = 0;
            netLoss = 0;
            this.inventory = inventory;
            this.recipe = recipe;

        }


        //member methods
        public void InputName() //This method serves to have the players (human) input their own name
        {
            Console.WriteLine("Please enter a name for Player");
            name = Console.ReadLine();
        }

        //public virtual void PurchaseInventory(); //This will serve as the function to prompt the player to purchase their daily inventory

        //public virtual void SetPrice(); //This method will have the player set the price per cup of lemonade

        //public virtual void SetRecipe(); //This method will have the player set the amount of each item to use in the recipe
    }
}
