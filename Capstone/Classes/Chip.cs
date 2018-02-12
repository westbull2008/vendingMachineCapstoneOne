using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class Chip : Item
    {
        // Chip constructor, creates Chip with name and price, using Item constructor
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
