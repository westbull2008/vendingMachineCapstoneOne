using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class Candy : Item
    {
        // creates Candy property with name and price; makes use of Item constructor??
        public Candy(string name, decimal price) : base(name, price)
        {
        }

        // Overrides Consume in Item with statement
        public override string Consume()
        {
            return "Munch Munch, Yum!";
        }
    }
}
