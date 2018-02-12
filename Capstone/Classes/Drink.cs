using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class Drink : Item
    {
        // Drink constructor, creates Drink with name and price, using Item constructor
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
