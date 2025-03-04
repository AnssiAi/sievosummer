using sievosummer.data;
using sievosummer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sievosummer.Tests.Mockups
{
    internal class ItemRepositoryMock : IListable<Item, NewItemDTO>
    {
        private List<Item> Items;

        public ItemRepositoryMock()
        {
            //Entity Framework databasecontext could be injected here
            Items = new List<Item>();
            Initialize();
        }
        private void Initialize()
        {
            //Initial database fetch could be here instead
            Items.Add(new Item(Items.Count + 1, "Medication", 5));
            Items.Add(new Item(Items.Count + 1, "Water", 4));
            Items.Add(new Item(Items.Count + 1, "Food", 3));
            Items.Add(new Item(Items.Count + 1, "Batteries", 2));
            Items.Add(new Item(Items.Count + 1, "Card deck", 1));
        }

        public void AddNew(NewItemDTO item)
        {
            int newId = Items.Count + 1;
            Items.Add(new Item(newId, item.Name, item.Value));
        }

        public Item GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Item> GetAll()
        {
            return Items;
        }
        public void UpdateItem(Item updated)
        {
            Item? item = Items.FirstOrDefault((h) => h.ItemId == updated.ItemId);
            item = updated;

        }
    }
}
