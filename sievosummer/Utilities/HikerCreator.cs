using sievosummer.data;
using sievosummer.Models;
using sievosummer.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sievosummer.Utilities
{
    public class HikerCreator
    {
        private readonly ItemRepository itemRepository;
        private readonly HikerRepository hikerRepository;

        public HikerCreator(ItemRepository itemRepo, HikerRepository hikerRepo)
        {
            itemRepository = itemRepo;
            hikerRepository = hikerRepo;
        }
        public void HikerCreatorDialog()
        {
            Console.WriteLine("-------------------");
            Console.WriteLine("Create a new hiker.");

            string name = GetHikerName();

            int age = GetHikerAge();

            GenderOption gender = GetHikerGender();

            List<double> coordinates = GetLastCoordinates();

            List<Item> inventory = GetInventory();

            bool isInjured = GetInjuredStatus();

            NewHikerDTO hiker = new NewHikerDTO(name, age, gender, coordinates, inventory, isInjured);

            Console.WriteLine($"Hiker: {hiker.Name} created.");

            hikerRepository.CreateHiker(hiker);
        }
        private string GetHikerName()
        {
            Console.WriteLine("Hiker Name.");
            string name = "";

            while (string.IsNullOrWhiteSpace(name))
            {
                Console.Write("Name: ");
                name = Console.ReadLine();
            }

            return name;
        }
        private int GetHikerAge()
        {
            string inputError = "Please give a valid age";
            Console.WriteLine("Hiker age.");
            int age = -1; //Initialized outside accepted range.
            while (age < 0)
            {
                Console.WriteLine("Give age as a whole number.");
                try
                {
                    Console.Write("Age: ");
                    age = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine(inputError);
                }

            }
            return age;
        }
        private GenderOption GetHikerGender()
        {
            string inputError = "Input a number corresponding to gender";
            var options = Enum.GetValues<GenderOption>();
            Console.WriteLine("Hiker Gender.");
            for (int i = 0; i < options.Length; i++)
            {
                Console.WriteLine($"{i} - {options[i]}");
            }

            int gender = -1; //Initialized outside accepted range
            while (gender < 0 || gender > options.Length)
            {
                Console.Write("Gender: ");
                try
                {
                    gender = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine(inputError);
                }

            }
            return (GenderOption)gender;
        }

        private List<double> GetLastCoordinates()
        {
            string inputError = "Please give a valid decimal number.";
            List<double> lastCoordinates = new List<double>();
            Console.WriteLine("Give hikers last known coordinates as decimal numbers.");
            double longitude = 200; //initialized to outside accepted range of -180 to 180.
            double latitude = 100; //initialized to outside accepted range of -90 to 90.
            while (longitude < -180 || longitude > 180)
            {
                Console.WriteLine("Longitude value is between -180 to 180: ");
                Console.Write("Longitude: ");
                try
                {
                    longitude = double.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine(inputError);
                }

            }
            while (latitude < -90 || latitude > 90)
            {
                Console.WriteLine("Latitude value is between -90 to 90: ");
                Console.Write("Latitude: ");
                try
                {
                    latitude = double.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine(inputError);
                }

            }
            lastCoordinates.AddRange([longitude, latitude]);

            return lastCoordinates;
        }

        private List<Item> GetInventory()
        {
            string inputError = "Please give a valid number or exit with q.";
            List<Item> itemListing = itemRepository.GetItems();
            List<Item> inventory = new List<Item>();
            for (int i = 0; i < itemListing.Count; i++)
            {
                Console.WriteLine($"{i} - {itemListing[i].Name}");
            }
            Console.WriteLine("Give item number to add an item. Continue with q.");
            bool close = false;
            while (!close)
            {
                int itemSelect = -1; //Inititalized outside accepted range
                Console.Write("Add item: ");
                string input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input) && input.ToLowerInvariant() == "q")
                {
                    close = true;
                    break;
                }
                try
                {
                    itemSelect = int.Parse(input);
                    inventory.Add(itemListing[itemSelect]);

                }
                catch (Exception)
                {
                    Console.WriteLine(inputError);
                }

            }
            return inventory;
        }
        private bool GetInjuredStatus()
        {
            string inputError = "Please give an aswer as either 1 or 0";
            int injuryInput = -1;
            while (injuryInput < 0 || injuryInput > 1)
            {
                Console.WriteLine("Is the Hiker injured? 1 - yes, 0 - no");
                try
                {
                    Console.Write("Injured: ");
                    injuryInput = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {

                    Console.WriteLine(inputError);
                }
            }
            return injuryInput == 1;
        }
    }
}
