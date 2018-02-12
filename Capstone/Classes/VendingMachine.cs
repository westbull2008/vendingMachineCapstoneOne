using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    // creating a class called VendingMachine
    public class VendingMachine
    {
        // creating a list of Items called stockList
        List<Item> stockList = new List<Item>();
        
        // creating a PurchaseLog called log, with name Log.txt
        PurchaseLog log = new PurchaseLog("Log.txt");
        
        // creating a new Transaction called Trans
        public Transaction Trans { get; set; } = new Transaction();

        // Setting location names of slots into a string
        static string[] locations =
        {
            "A1", "A2", "A3", "A4",
            "B1", "B2", "B3", "B4",
            "C1", "C2", "C3", "C4",
            "D1", "D2", "D3", "D4"
        };

        // Creating a dictionary called Slots from Slot class, with a get and set
        public Dictionary<string, Slot> Slots { get; set; } = new Dictionary<string, Slot>();
        
        // Creating a list of Items called PurchasedItems, 
        public List<Item> PurchasedItems { get; set; } = new List<Item>(); // clear list afterwards
        
        //Creating a method called FeedMoney, with int parameter dollars, to enter money
        public void FeedMoney(int dollars)
        {
            // Setting MoneyGiven in Trans to a value in pennies for calculation
            Trans.MoneyGiven += 100 * dollars;
        
            // Sending FeedMoney transaction details to purchase log.
            log.PrintLog(log.PrintFeedMoney(dollars, Trans.BalanceInDollars));// feedmoney log
        }
        // Creating a method called PurchaseItem, with a parameter of the slot location
        public void PurchaseItem(string location)
        {
            //Adding an item using GetItemFromSlot method to PurchasedItems
            PurchasedItems.Add(GetItemFromSlot(location));
            
            // Multiplying purchase price of item by 100 to calculate in pennies
            Trans.TotalPurchasePrice += 100 * GetItemFromSlot(location).Price;
            
            // Sending PurchaseItem transaction details to purchase log.
            log.PrintLog(log.PrintPurchase(GetItemFromSlot(location).Name, GetItemFromSlot(location).Price, Trans.BalanceInDollars));// purchase log
            
            // Removes an item from the slot using RemoveItem method
            Slots[location].RemoveItem();

        }
        // A method creating slots using the Slot class
        public void MakeSlots()
        {
            // Searching through each slot location in locations
            foreach (string location in locations)
            {
                // Creating a new Slot using constructor at the specific slot location
                Slot slot = new Slot(location);
                Slots[location] = slot;
            }
        }
        // A constructor called VendingMachine, using the string parameter stockPath
        public VendingMachine(string stockPath)
        {
            // creating new stock using Stock constructor
            Stock stock = new Stock(stockPath);

            // Adding new stock creation to stock list
            stockList = stock.CreateStockList();

            // Using MakeSlots method to create the slots
            MakeSlots();

            // Using StockSlots method to add items to the stock list
            StockSlots(stockList);

        }

        // A method called StockSlots, using the parameters from the stockList List
        public void StockSlots(List<Item> stockList)
        {
            // A for loop through the stockList list
            for (int i = 0; i < stockList.Count; i++)
            {
                // Adding each item from stockList to the slots at the specific locations.
                Slots[locations[i]].AddItem(stockList[i]);
            }
        }

        // A method called GetItemFromSlot using Item class, with the location as a parameter 
        public Item GetItemFromSlot(string location)
        {
            // Return Items from the location in Slots dictionary
            return Slots[location].Items[0];
        }

        // A method called GetItemInfo which has a parameter of the location
        public string GetItemInfo(string location)
        {
            // Creating an empty string called info
            string info = "";
            
            // A loop that's invoked if the slot location is not empty that
            if (!Slots[location].IsEmpty)
            {
                // The info printed out, including the location, item name, item price, and amount remaining
                info = $"[{location}] {Slots[location].Items[0].Name} {Slots[location].Items[0].Price} ({Slots[location].AmountOfItems})";
            }
            else
            {
                // Printing that the item is sold out if slot location is empty.
                info = $"[{location}] "/*{Slots[location].Items[0].Name} {Slots[location].Items[0].Price}?*/ + "(SOLD OUT!!!)";

            }

            return info;
        }
        
    }
}
