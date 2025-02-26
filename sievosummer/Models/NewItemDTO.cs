using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sievosummer.Models
{
    public class NewItemDTO
    {
        public string Name { get; private set; }
        public int Value { get; private set; }

        public NewItemDTO(string name, int value)
        {
            Name = name;
            Value = value;
        }
    }
}
