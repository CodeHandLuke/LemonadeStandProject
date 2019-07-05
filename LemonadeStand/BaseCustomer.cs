using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class BaseCustomer
    {
        //member variables
        //Customer will have these variables: name; thirstLevel; frugal (bool);
        public string name;
        public int thirstLevel;
        public bool frugal;

        //constructors
        //
        public BaseCustomer(Random rng)
        {
            string[] names = { "Adam", "Brittany", "Chris", "Deziree", "Eric", "Felicia", "Gary", "Helen", "Isaac", "Jackie", "Luke" };
            int index = rng.Next(0, 11);
            name = names[index];
            thirstLevel = rng.Next(50, 101);
            frugal = Convert.ToBoolean(rng.Next(0, 2));
        }

        //member methods

        public void WillBuy()
        {
            //formula to determine whether customer will buy lemonade
        }
    }
}
