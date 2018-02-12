using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class Slot
    {
        // Creates a new property which is a list of Items, from Item class
        public List<Item> Items { get; set; } = new List<Item>();

        //A property considering the number of items; returns the count of the item list
        public int AmountOfItems { get => Items.Count; }

        // A property considering the location of the slots.
        public string Location { get; set; }

        // A property setting the price allocated, using Price in Item class
        public decimal Price { get => Items[0].Price; }

        // A slot constructor, which will create a slot at a particular location.
        public Slot(string location)
        {
            Location = location;
        }

        // A property of the slot called IsFull, which sets the upper limit at 5
        public bool IsFull { get => AmountOfItems == 5; }

        // A property of the slot called IsEmpty, which sets the lower limit at 0
        public bool IsEmpty { get => AmountOfItems == 0; }

        // A method which adds an item to the slot.
        public void AddItem(Item item)
        {
            while (!IsFull)
            {   //When the slot is not full, this adds an item, until it is full.
                Items.Add(item);
            }
        }
        // A method which removes an item from the slot
        public void RemoveItem()
        {   //Removes the item from the front of the slot
            Items.RemoveAt(0);
        }
    }
}
