using sievosummer.Models;
namespace sievosummer.Tests.Models
{
    [TestClass]
    public class ItemTests
    {
        [TestMethod]
        public void ToString_Returns_StringWithValues()
        {
            Item testItem = new Item(1, "Test", 3);
            
            string result = testItem.ToString();

            Assert.AreEqual("ID: 1, Test: 3 points", result);

        }
    }
}