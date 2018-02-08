using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class Slot
    {
        public List<Item> Items { get; set; } = new List<Item>();

        public int AmountOfItems { get => Items.Count; }

        public string Location { get; set; }

        public decimal Price { get => Items[0].Price; }

        public Slot(string location)
        {
            Location = location;
        }

        public bool IsFull { get => AmountOfItems == 5; }

        public bool IsEmpty { get => AmountOfItems == 0; }

        public void AddItem(Item item)
        {
            while (!IsFull)
            {
                Items.Add(item);
            }
        }
    }
}
