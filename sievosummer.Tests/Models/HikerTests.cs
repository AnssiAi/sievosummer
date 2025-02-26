using sievosummer.Models;
using sievosummer.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sievosummer.Tests.Models
{
    [TestClass]
    public class HikerTests
    {
        static List<double> johnCoordinates = [28.0028, 86.8652];
        static Item medicine = new Item(1, "Medicine", 5);
        static Item water = new Item(2, "Water", 4);
        static Item food = new Item(3, "Food", 3);



        [TestMethod]
        public void GetInventoryValue_Returns_CorrectInt()
        {
            List<Item> johnInventory = [medicine, medicine, food, food, food, food, food];
            Hiker johnDoe = new Hiker(1, "John Doe", 24, (GenderOption)1, johnCoordinates, johnInventory, false);
            int expected = 25;

            int result = johnDoe.GetInventoryValue();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void SetNewInventory_ListReplaces_HikerInventory()
        {
            List<Item> johnInventory = [medicine, medicine, food, food, food, food, food];
            Hiker johnDoe = new Hiker(1, "John Doe", 24, (GenderOption)1, johnCoordinates, johnInventory, false);
            List<Item> expected = [food, food, food, medicine, medicine, medicine, water, water];

            johnDoe.SetNewInventory(expected);

            Assert.AreEqual(expected, johnDoe.Inventory);
        }

        [TestMethod]
        public void ToString_Returns_StringWithValues()
        {
            List<Item> johnInventory = [medicine, medicine, food, food, food, food, food];
            Hiker johnDoe = new Hiker(1, "John Doe", 24, (GenderOption)1, johnCoordinates, johnInventory, false);
            string expected = "HikerId: 1, Name: John Doe, Age: 24, Gender: Male, LastLocation: [28,0028, 86,8652], Inventory: Medicine: 2, Food: 5, Injured: False";

            string result = johnDoe.ToString();

            Assert.AreEqual(expected, result);
        }
    }
}
