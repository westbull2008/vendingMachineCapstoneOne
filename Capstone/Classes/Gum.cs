using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class Gum : Item
    {
        // Gum constructor, creates Gum with name and price, using Item constructor
        public Gum(string name, decimal price) : base(name, price)
        {
        }
        // Overrides Consume in Item with statement
        public override string Consume()
        {
            return "Chew Chew, Yum!";
        }
    }
}
