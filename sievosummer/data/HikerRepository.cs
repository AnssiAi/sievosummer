using sievosummer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sievosummer.data
{
    public class HikerRepository
    {
        private List<Hiker> Hikers;

        public HikerRepository()
        {
            //Entity Framework databasecontext could be injected here
            Hikers = new List<Hiker>();
        }

        public List<Hiker> GetHikers()
        {
            return Hikers;
        }

        public void CreateHiker(NewHikerDTO newHiker)
        {
            int newId = Hikers.Count + 1;
            Hikers.Add(new Hiker(newId, newHiker.Name, newHiker.Age, newHiker.Gender, newHiker.LastLocation, newHiker.Inventory, newHiker.IsInjured));
        }

        public Hiker GetHikerById(int id)
        {

            Hiker? hiker = Hikers.FirstOrDefault((h) => h.HikerId == id);

            if (hiker == null)
            {
                throw new Exception("Hiker not found.");
            }
            return hiker;
        }

        public void UpdateHikerInventory(int id, List<Item> newInventory)
        {
            //Models update from web frontend
            Hiker? toUpdate = Hikers.FirstOrDefault((h) => h.HikerId == id);
            if (toUpdate == null)
            {
                throw new Exception("Hiker not found.");
            }
            toUpdate.SetNewInventory(newInventory);
        }
    }
}
