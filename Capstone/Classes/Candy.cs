using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class Candy : Item
    {
        // Candy constructor, creates Candy with name and price, using Item constructor
        public Candy(string name, decimal price) : base(name, price)
        {
        }

        // Method overriding Consume in Item with statement
        public override string Consume()
        {
            return "Munch Munch, Yum!";
        }
    }
}
