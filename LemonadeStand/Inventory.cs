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



        //constructors
        public Inventory()
        {
            this.paperCups = 0;
            this.lemons = 0;
            this.sugarCups = 0;
            this.iceCubes = 0;
        }


        //member methods
    }
}
