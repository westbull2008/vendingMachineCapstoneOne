using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class Chip : Item
    {
        // creates Chip property with name and price
        public Chip(string name, decimal price) : base(name, price)
        {
        }
        // Overrides Consume in Item with statement
        public override string Consume()
        {
            return "Crunch Crunch, Yum!";
        }
    }
}
