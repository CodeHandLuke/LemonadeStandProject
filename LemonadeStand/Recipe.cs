using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Recipe
    {
        //member variables
        public int dailyPaperCups;
        public int dailyLemons;
        public int dailySugarCups;
        public int dailyIceCubes;
        public int pricePerCup;
        public int pitcher;
        public int cupsPerPitcher;


        //constructor
        public Recipe()
        {
            dailyLemons = 4; //!!!***Change these back to 0 after testing
            dailySugarCups = 4; //!!!***Change these back to 0 after testing
            dailyIceCubes = 4; //!!!***Change these back to 0 after testing
            pricePerCup = 15;
            pitcher = 0;
            cupsPerPitcher = 12;
        }


        //member methods


    }
}
