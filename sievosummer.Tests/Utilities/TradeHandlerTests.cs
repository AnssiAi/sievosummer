using sievosummer.data;
using sievosummer.Models;
using sievosummer.Tests.TestUtilities;
using sievosummer.Types;
using sievosummer.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sievosummer.Tests.Utilities
{
    [TestClass]
    public class TradeHandlerTests
    {
        ItemEqualityComparer itemEqualityComparer = new ItemEqualityComparer();

        static Item medicine = new Item(1, "Medicine", 5);
        static Item water = new Item(2, "Water", 4);
        static Item food = new Item(3, "Food", 3);


        [TestMethod]
        public void TradeInventories_NonEqualInvetories_NoTrade()
        {
            HikerRepository hikerRepository = new HikerRepository();
            TradeHandler tradeHandler = new TradeHandler(hikerRepository);
            List<double> doeCoordinates = [28.0028, 86.8652];
            List<Item> doeInventory = [medicine, medicine, food, food, food, food, food];
            NewHikerDTO johnDoe = new NewHikerDTO("John Doe", 24, (GenderOption)1, doeCoordinates, doeInventory, false);

            List<double> doerCoordinates = [28.0092, 86.8545];
            List<Item> doerInventory = [food, food, food, medicine, medicine, medicine, water, water];
            NewHikerDTO johnDoer = new NewHikerDTO("John Doer", 26, (GenderOption)0, doerCoordinates, doerInventory, false);

            hikerRepository.CreateHiker(johnDoe);
            hikerRepository.CreateHiker(johnDoer);

            string expect = "Trade could not complete: John Doe has less inventory points to exchange.";
            string result = "";
            try
            {
                tradeHandler.TradeInventories(1, 2);
            }
            catch (Exception ex)
            {

                result = ex.Message;
            }

            Assert.AreEqual(expect, result);
        }
        [TestMethod]
        public void TradeInventories_EqualInventories_TradeSuccessful()
        {
            HikerRepository hikerRepository = new HikerRepository();
            TradeHandler tradeHandler = new TradeHandler(hikerRepository);
            List<double> doeCoordinates = [28.0028, 86.8652];
            List<Item> doeInventory = [medicine, water, water, water, water, water];
            NewHikerDTO johnDoe = new NewHikerDTO("John Doe", 24, (GenderOption)1, doeCoordinates, doeInventory, false);

            List<double> doerCoordinates = [28.0092, 86.8545];
            List<Item> doerInventory = [food, food, food, food, food, medicine, medicine];
            NewHikerDTO johnDoer = new NewHikerDTO("John Doer", 26, (GenderOption)0, doerCoordinates, doerInventory, false);

            hikerRepository.CreateHiker(johnDoe);
            hikerRepository.CreateHiker(johnDoer);

            try
            {
                tradeHandler.TradeInventories(1, 2);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Hiker doe = hikerRepository.GetHikerById(1);
            Hiker doer = hikerRepository.GetHikerById(2);

            bool result = Enumerable.SequenceEqual(doerInventory, doe.Inventory, itemEqualityComparer) && Enumerable.SequenceEqual(doeInventory, doer.Inventory, itemEqualityComparer);

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TradeInventories_HikerInjured_NoTrade()
        {
            HikerRepository hikerRepository = new HikerRepository();
            TradeHandler tradeHandler = new TradeHandler(hikerRepository);
            List<double> doeCoordinates = [28.0028, 86.8652];
            List<Item> doeInventory = [medicine, water, water, water, water, water];
            NewHikerDTO johnDoe = new NewHikerDTO("John Doe", 24, (GenderOption)1, doeCoordinates, doeInventory, true);

            List<double> doerCoordinates = [28.0092, 86.8545];
            List<Item> doerInventory = [food, food, food, food, food, medicine, medicine];
            NewHikerDTO johnDoer = new NewHikerDTO("John Doer", 26, (GenderOption)0, doerCoordinates, doerInventory, false);

            hikerRepository.CreateHiker(johnDoe);
            hikerRepository.CreateHiker(johnDoer);

            string expected = "Trade could not complete: John Doe is injured.";
            string result = "";
            try
            {
                tradeHandler.TradeInventories(1, 2);
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }

            Assert.AreEqual(expected, result);
        }
    }
}
