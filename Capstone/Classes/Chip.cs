using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class Chip : Item
    {
        public Chip(string name, decimal price) : base(name, price)
        {
        }

        public override string Consume()
        {
            return "Crunch Crunch, Yum!";
        }
    }
}
