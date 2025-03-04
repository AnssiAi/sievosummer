using sievosummer.data;
using sievosummer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sievosummer.Tests.Mockups
{
    internal class HikerRepositoryMock : IListable<Hiker, NewHikerDTO>
    {
        private List<Hiker> Hikers;

        public HikerRepositoryMock()
        {
            //Entity Framework databasecontext could be injected here
            Hikers = new List<Hiker>();
        }

        public void AddNew(NewHikerDTO hiker)
        {
            int newId = Hikers.Count + 1;
            Hikers.Add(new Hiker(newId, hiker.Name, hiker.Age, hiker.Gender, hiker.LastLocation, hiker.Inventory, hiker.IsInjured));
        }

        public Hiker GetById(int id)
        {

            Hiker? hiker = Hikers.FirstOrDefault((h) => h.HikerId == id);

            if (hiker == null)
            {
                throw new Exception("Hiker not found.");
            }
            return hiker;
        }

        public List<Hiker> GetAll()
        {
            return Hikers;
        }

        public void UpdateItem(Hiker updated)
        {
            Hiker? hiker = Hikers.FirstOrDefault((h) => h.HikerId == updated.HikerId);
            hiker = updated;

        }
    }
}
