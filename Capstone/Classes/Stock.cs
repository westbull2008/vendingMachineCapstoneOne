using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Capstone.Classes
{
    public class Stock
    {
        // A property that says there is a path 
        public string Path { get; set; }

        // Stock constructor which sets up the Stock path
        public Stock(string path)
        {
            Path = path;
        }

        // A method creating an Item list of stock
        public List<Item> CreateStockList()
        {
            // Creates the individual items list of Items
            List<Item> items = new List<Item>();

            try
            {
                //Getting StreamReader to read in the information from the file path
                using (StreamReader sr = new StreamReader(Path))
                {
                    while (!sr.EndOfStream)
                    {
                        // Reads lines from path via StreamReader
                        string line = sr.ReadLine();

                        // Switch which sorts items via Case of Slot locations
                        switch (line[0])
                        {
                            case 'A':
                                items.Add(CreateChip(line));
                                break;
                            case 'B':
                                items.Add(CreateCandy(line));
                                break;
                            case 'C':
                                items.Add(CreateDrink(line));
                                break;
                            case 'D':
                                items.Add(CreateGum(line));
                                break;
                        }
                    }
                }
            }
            // Setting the exception if an incorrect path is entered.
            catch (IOException e)
            {
                Console.WriteLine("You need to input a correct path.");
                Console.WriteLine(e.Message);
            }


            return items;
        }

        // Method invoking Chip class to create a chip item
        private Chip CreateChip(string line)
        {
            // creating a string from input file, splitting at |
            string[] items = line.Split('|');
            // the name is at index one in items string array
            string name = items[1];
            // setting price by parsing string[price] at string array position 2
            decimal price = decimal.Parse(items[2]);
            //creating a new Chip item called chip, with a name and a price.
            Chip chip = new Chip(name, price);

            return chip;
        }

        private Candy CreateCandy(string line)
        {
            string[] items = line.Split('|');
            string name = items[1];
            decimal price = decimal.Parse(items[2]);

            Candy candy = new Candy(name, price);

            return candy;
        }

        private Drink CreateDrink(string line)
        {
            string[] items = line.Split('|');
            string name = items[1];
            decimal price = decimal.Parse(items[2]);

            Drink drink = new Drink(name, price);

            return drink;
        }

        private Gum CreateGum(string line)
        {
            string[] items = line.Split('|');
            string name = items[1];
            decimal price = decimal.Parse(items[2]);

            Gum gum = new Gum(name, price);

            return gum;
        }

    }
}
