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
        public void SlotsAreCreatedProperly()
        {
            VendingMachine machine = new VendingMachine("vendingmachine.csv");

            Item item = machine.GetItemFromSlot("B3");

            Assert.AreEqual("Wonka Bar", item.Name);

        }

        [TestMethod]
        public void PriceOfItemInSlot()
        {
            VendingMachine machine = new VendingMachine("vendingmachine.csv");

            Item item = machine.GetItemFromSlot("B3");

            decimal result = item.Price;

            Assert.AreEqual(1.50M, result);
        }
    }
}
