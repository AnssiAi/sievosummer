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
        private IListable<Hiker, NewHikerDTO> repository;
        public TradeHandler(IListable<Hiker, NewHikerDTO> repo)
        {
            repository = repo;
        }
        public void TradeInventories(int firstId, int secondId)
        {
            Console.WriteLine("Trade inventories");
            try
            {
                Hiker first = repository.GetById(firstId);
                Hiker second = repository.GetById(secondId);

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

                first.SetNewInventory(second.Inventory);
                second.SetNewInventory(holdFirst);

                repository.UpdateItem(first);
                repository.UpdateItem(second);


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
