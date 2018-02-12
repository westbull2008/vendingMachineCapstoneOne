using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;
using System.Collections.Generic;

namespace CapstoneTests
{
    [TestClass]
    public class VendingMachineTests
    {
        [TestMethod]
        // ensures slots are created properly from text file
        public void SlotsAreCreatedProperly()
        {
            VendingMachine machine = new VendingMachine("vendingmachine.csv");

            Item item = machine.GetItemFromSlot("B3");

            Assert.AreEqual("Wonka Bar", item.Name);

        }

        [TestMethod]
        // checks correct price is at slot location
        public void PriceOfItemInSlot()
        {
            VendingMachine machine = new VendingMachine("vendingmachine.csv");

            Item item = machine.GetItemFromSlot("B3");

            decimal result = item.Price;

            Assert.AreEqual(1.50M, result);
        }
    }
}
