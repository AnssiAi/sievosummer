using sievosummer.data;
using sievosummer.Models;
using sievosummer.Utilities;

namespace sievosummer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ItemRepository itemRepository = new ItemRepository();
            HikerRepository hikerRepository = new HikerRepository();
            HikerCreator hikerCreator = new HikerCreator(itemRepository, hikerRepository);
            TradeHandler tradeHandler = new TradeHandler(hikerRepository);

            Console.WriteLine("Hello, Hikers!");
            //Create Hikers
            for (int i = 0; i < 2; i++)
            {
                hikerCreator.HikerCreatorDialog();
            }
            Console.WriteLine("--------------");

            //Show info
            foreach (Hiker hiker in hikerRepository.GetAll())
            {
                Console.WriteLine(hiker.ToString());
                Console.WriteLine("--------------");
            }
            Console.WriteLine("--------------");

            //Trade
            try
            {
                tradeHandler.TradeInventories(1, 2);
                foreach (Hiker hiker in hikerRepository.GetAll())
                {
                    Console.WriteLine(hiker.ToString());
                    Console.WriteLine("--------------");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("--------------");
            }
        }
    }
}
