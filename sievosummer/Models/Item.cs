using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sievosummer.Models
{
    public class Item
    {
        public int ItemId { get; private set; }
        public string Name { get; private set; }
        public int Value { get; private set; }

        public Item(int id, string name, int value) {
            ItemId = id;
            Name = name;
            Value = value;
        }

        public override string ToString()
        {
            return $"ID: {ItemId}, {Name}: {Value} points";
        }
    }
}
