﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class VendingMachine
    {
        List<Item> stockList = new List<Item>();
        Transaction trans = new Transaction();

        static string[] locations =
        {
            "A1", "A2", "A3", "A4",
            "B1", "B2", "B3", "B4",
            "C1", "C2", "C3", "C4",
            "D1", "D2", "D3", "D4"
        };

        public Dictionary<string, Slot> Slots { get; set; } = new Dictionary<string, Slot>();

        public List<Item> PurchasedItems { get; set; } = new List<Item>(); // clear list afterwards

        public void FeedMoney(int dollars)
        {
            trans.MoneyGiven += 100 * dollars;
        }

        public void GetItem(string location)
        {
            PurchasedItems.Add(Slots[location].Items[0]);
            trans.TotalPurchasePrice += Slots[location].Items[0].Price;
        }

        public void MakeSlots()
        {
            foreach(string location in locations)
            {
                Slot slot = new Slot(location);
                Slots[location] = slot;
            }
        }

        public VendingMachine(string stockPath)
        {
            Stock stock = new Stock(stockPath);
            stockList = stock.CreateStockList();
            MakeSlots();
            StockSlots(stockList);

        }

        public void StockSlots(List<Item> stockList)
        {
            for (int i = 0; i < stockList.Count; i++)
            {
                Slots[locations[i]].AddItem(stockList[i]);
            }
        }

        public Item GetItemFromSlot(string location)
        {
            return Slots[location].Items[0];
        }
    }
}
