using sievosummer.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sievosummer.Models
{
    public class NewHikerDTO
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
        public GenderOption Gender { get; private set; }
        public List<double> LastLocation { get; private set; }
        public List<Item> Inventory { get; private set; }
        public bool IsInjured { get; private set; }

        public NewHikerDTO(string name, int age, GenderOption gender, List<double> coordinates, List<Item> inventory, bool injured)
        {
            Name = name;
            Age = age;
            Gender = gender;
            LastLocation = coordinates;
            Inventory = inventory;
            IsInjured = injured;
        }
    }
}
