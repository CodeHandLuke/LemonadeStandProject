using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Inventory
    {
        //member variables
        public int paperCups;
        public int lemons;
        public int sugarCups;
        public int iceCubes;
        public double paperCupCost = .0368;
        public double lemonCost = .097;
        public double sugarCupsCost = .0725;
        public double iceCubesCost = .0092;



        //constructors
        public Inventory() //!!!***Change these back to 0 after testing
        {
            paperCups = 100;
            lemons = 100;
            sugarCups = 100;
            iceCubes = 1000;
        }


        //member methods
    }
}
