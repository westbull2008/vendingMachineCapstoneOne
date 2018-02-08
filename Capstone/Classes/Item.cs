using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public abstract class Item
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public Item(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public Item()
        {

        }

        public virtual string Consume()
        {
            return "";
        }

    }
}
