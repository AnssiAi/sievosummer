using sievosummer.data;
using sievosummer.Models;
using sievosummer.Tests.TestUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sievosummer.Tests.data
{
    [TestClass]
    public class ItemRepositoryTests
    {
        ItemRepository itemRepository = new ItemRepository();
        ItemEqualityComparer itemEqualityComparer = new ItemEqualityComparer();

        [TestMethod]
        public void GetItems_Returns_CorrectList()
        {
            List<Item> testItems = new List<Item>();
            testItems.Add(new Item(testItems.Count + 1, "Medication", 5));
            testItems.Add(new Item(testItems.Count + 1, "Water", 4));
            testItems.Add(new Item(testItems.Count + 1, "Food", 3));
            testItems.Add(new Item(testItems.Count + 1, "Batteries", 2));
            testItems.Add(new Item(testItems.Count + 1, "Card deck", 1));

            List<Item> result = itemRepository.GetItems();

            bool equal = Enumerable.SequenceEqual(testItems, result, itemEqualityComparer);

            Assert.IsTrue(equal);
        }

        [TestMethod]
        public void CreateItem_ValidNewItemDTO_IsAddedToList()
        {
            int expectedCount = 6;
            NewItemDTO expectedItem = new NewItemDTO("Map", 6);
            itemRepository.CreateItem(expectedItem);

            List<Item> result = itemRepository.GetItems();
            Item item = result.FirstOrDefault(item => item.Name == expectedItem.Name);

            Assert.AreEqual(expectedCount, result.Count);
            Assert.IsTrue(item != null);
            Assert.AreEqual(expectedItem.Name, item.Name);
        }
    }
}
