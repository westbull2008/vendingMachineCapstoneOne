using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public abstract class Item
    {
        // sets Name property
        public string Name { get; set; }

        //sets Price property
        public decimal Price { get; set; }

        // default item constructor, no parameters
        public Item()
        {

        }

        //Constructor that sets Item with name and price, calling above properties
        public Item(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        // Method which consumes the item
        public virtual string Consume()
        {
            return "";
        }

    }
}
