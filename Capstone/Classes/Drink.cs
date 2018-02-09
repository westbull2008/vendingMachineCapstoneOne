using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class Drink : Item
    {
        // creates Chip property with name and price
        public Drink(string name, decimal price) : base(name, price)
        {
        }
        // Overrides Consume in Item with statement
        public override string Consume()
        {
            return "Glug Glug, Yum!";
        }
    }
}
