using sievosummer.data;
using sievosummer.Models;
using sievosummer.Tests.TestUtilities;
using sievosummer.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sievosummer.Tests.data
{
    [TestClass]
    public class HikerRepositoryTests
    {
        ItemEqualityComparer itemEqualityComparer = new ItemEqualityComparer();

        static Item medicine = new Item(1, "Medicine", 5);
        static Item water = new Item(2, "Water", 4);
        static Item food = new Item(3, "Food", 3);


        [TestMethod]
        public void CreateHiker_ValidNewHikerDTO_IsAddedToList()
        {
            HikerRepository hikerRepository = new HikerRepository();
            List<double> doeCoordinates = [28.0028, 86.8652];
            List<Item> doeInventory = [medicine, medicine, food, food, food, food, food];
            NewHikerDTO johnDoe = new NewHikerDTO("John Doe", 24, (GenderOption)1, doeCoordinates, doeInventory, false);

            List<double> doerCoordinates = [28.0092, 86.8545];
            List<Item> doerInventory = [food, food, food, medicine, medicine, medicine, water, water];
            NewHikerDTO johnDoer = new NewHikerDTO("John Doer", 26, (GenderOption)0, doerCoordinates, doerInventory, false);
            hikerRepository.AddNew(johnDoe);
            hikerRepository.AddNew(johnDoer);

            List<Hiker> result = hikerRepository.GetAll();

            Assert.AreEqual(2, result.Count);
        }
        [TestMethod]
        public void GetHikerByID_ValidId_ReturnsHiker()
        {
            HikerRepository hikerRepository = new HikerRepository();
            List<double> doeCoordinates = [28.0028, 86.8652];
            List<Item> doeInventory = [medicine, medicine, food, food, food, food, food];
            NewHikerDTO johnDoe = new NewHikerDTO("John Doe", 24, (GenderOption)1, doeCoordinates, doeInventory, false);

            hikerRepository.AddNew(johnDoe);
            int validId = 1;

            Hiker result = hikerRepository.GetById(validId);

            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void GetHikerByID_InvalidId_ThrowsException()
        {
            HikerRepository hikerRepository = new HikerRepository();
            List<double> doeCoordinates = [28.0028, 86.8652];
            List<Item> doeInventory = [medicine, medicine, food, food, food, food, food];
            NewHikerDTO johnDoe = new NewHikerDTO("John Doe", 24, (GenderOption)1, doeCoordinates, doeInventory, false);

            hikerRepository.AddNew(johnDoe);
            int invalidId = 5;
            string expected = "Hiker not found.";
            string result = "";
            try
            {
                Hiker hiker = hikerRepository.GetById(invalidId);
            }
            catch (Exception ex)
            {

                result = ex.Message;
            }

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void UpdateHiker_ValidID_InventoryIsUpdated()
        {
            HikerRepository hikerRepository = new HikerRepository();
            List<double> doeCoordinates = [28.0028, 86.8652];
            List<Item> doeInventory = [medicine, medicine, food, food, food, food, food];
            NewHikerDTO johnDoe = new NewHikerDTO("John Doe", 24, (GenderOption)1, doeCoordinates, doeInventory, false);

            hikerRepository.AddNew(johnDoe);
            int validId = 1;
            List<Item> expectedInventory = [food, food, food, medicine, medicine, medicine, water, water];
            Hiker hiker = hikerRepository.GetById(validId);
            hiker.SetNewInventory(expectedInventory);
            hikerRepository.UpdateItem(hiker);

            Hiker updated = hikerRepository.GetById(validId);


            bool result = Enumerable.SequenceEqual(expectedInventory, updated.Inventory, itemEqualityComparer);

            Assert.IsTrue(result);
        }
    }
}
