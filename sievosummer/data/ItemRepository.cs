using sievosummer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sievosummer.data
{
    public class ItemRepository
    {
        private List<Item> Items;

        public ItemRepository()
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

        public List<Item> GetItems() { return Items; }

        public void CreateItem(NewItemDTO newItem)
        {
            int newId = Items.Count + 1;
            Items.Add(new Item(newId, newItem.Name, newItem.Value));
        }
    }
}
