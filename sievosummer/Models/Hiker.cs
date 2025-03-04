using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using sievosummer.data;
using sievosummer.Types;

namespace sievosummer.Models
{
    public class Hiker
    {
        public int HikerId { get; private set; }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public GenderOption Gender { get; private set; }
        public List<double> LastLocation { get; private set; }
        public List<Item> Inventory { get; private set; }
        public bool IsInjured { get; private set; }

        public Hiker(int id, string name, int age, GenderOption gender, List<double> coordinates, List<Item> inventory, bool injured)
        {
            HikerId = id;
            Name = name;
            Age = age;
            Gender = gender;
            LastLocation = coordinates;
            Inventory = inventory;
            IsInjured = injured;
        }

        public int GetInventoryValue()
        {
            return Inventory.Aggregate(0, (sum, item) => sum + item.Value);
        }

        public void SetNewInventory(List<Item> inventory)
        {
            Inventory = inventory;
        }

        public override string ToString()
        {
            string result = $"HikerId: {HikerId}, Name: {Name}, Age: {Age}, Gender: {Gender}, LastLocation: [{LastLocation[0].ToString()}, {LastLocation[1].ToString()}], ";
            List<int> ids = Inventory.Select((i) => i.ItemId).Distinct().ToList();

            for (int i = 0; i < ids.Count; i++) {
                int id = ids[i];
                Item item = Inventory.FirstOrDefault(item => item.ItemId == id);
                if(i == 0)
                {
                    result += "Inventory: ";
                }
                int itemCount = Inventory.Aggregate(0, (sum, item) => item.ItemId == id ? sum + 1 : sum);
                result += $"{item.Name}: {itemCount}";
                if (i < Inventory.Count)
                {
                    result += ", ";
                }
            }

            result += $"Injured: {IsInjured.ToString()}";

            return result;
        }
    }
}
