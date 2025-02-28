using sievosummer.data;
using sievosummer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sievosummer.Utilities
{
    public class TradeHandler
    {
        private HikerRepository repository;
        public TradeHandler(HikerRepository repo)
        {
            repository = repo;
        }
        public void TradeInventories(int firstId, int secondId)
        {
            Console.WriteLine("Trade inventories");
            try
            {
                Hiker first = repository.GetHikerById(firstId);
                Hiker second = repository.GetHikerById(secondId);

                if (first.IsInjured)
                {
                    throw new Exception($"Trade could not complete: {first.Name} is injured.");
                }
                if (second.IsInjured)
                {
                    throw new Exception($"Trade could not complete: {second.Name} is injured.");

                }

                if (first.GetInventoryValue() != second.GetInventoryValue())
                {
                    int firstValue = first.GetInventoryValue();
                    int secondValue = second.GetInventoryValue();

                    if (firstValue > secondValue)
                    {
                        throw new Exception($"Trade could not complete: {second.Name} has less inventory points to exchange.");

                    }
                    if (secondValue > firstValue)
                    {
                        throw new Exception($"Trade could not complete: {first.Name} has less inventory points to exchange.");
                    }
                }

                List<Item> holdFirst = first.Inventory;

                repository.UpdateHikerInventory(first.HikerId, second.Inventory);
                repository.UpdateHikerInventory(second.HikerId, holdFirst);

                Console.WriteLine("Trade completed.");
                Console.WriteLine("--------------");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            
        }
    }
}
