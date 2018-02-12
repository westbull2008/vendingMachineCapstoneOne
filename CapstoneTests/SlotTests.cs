using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;
using System.Collections.Generic;

namespace CapstoneTests
{
    [TestClass]
    public class SlotTests
    {
        [TestMethod]
        // Tests if slot stops adding at five
        public void AddItemOnlyAddsFive()
        {
            Slot slot = new Slot("A1");
            Chip chips = new Chip("Lays", 0.75M);

            slot.AddItem(chips);

            int result = slot.AmountOfItems;

            Assert.AreEqual(5, result);

        }

        [TestMethod]
        // tests that correct price is at slot location
        public void PriceOfSlotIsEqualToItemPrice()
        {
            Slot slot = new Slot("A1");
            Chip chips = new Chip("Lays", 0.75M);

            slot.AddItem(chips);

            decimal result = slot.Price;

            Assert.AreEqual(0.75M, result);
        }
    }
}
