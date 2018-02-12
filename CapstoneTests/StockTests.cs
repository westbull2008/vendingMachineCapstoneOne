using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;
using System.Collections.Generic;

namespace CapstoneTests
{
    [TestClass]
    public class StockTests
    {
        [TestMethod]
        // checks that stock list is created from text file properly
        public void StockListIsProperlyCreatedFromTextFile()
        {
            Stock stock = new Stock("vendingmachine.csv");

            List<Item> items = stock.CreateStockList();

            string itemName = items[6].Name;
            decimal itemPrice = items[6].Price;

            Assert.AreEqual("Wonka Bar", itemName);
            Assert.AreEqual((decimal)1.50, itemPrice);

        }
    }
}
