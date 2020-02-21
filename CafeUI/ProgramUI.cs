using Komodo_Cafe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeUI
{
    public class ProgramUI
    {
        private readonly MenuRepository _menuRepository = new MenuRepository();

        public void Run()
        {
            SeedContent();
            RunMenu();
        }

        private void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Select an option number: \n" +
                "1. Display Menu\n" +
                "2. Exit");

                string userInput = Console.ReadLine();
                userInput = userInput.Replace(" ", "");
                switch (userInput)
                {
                    case "1":
                        DisplayMenuItems();
                        break;

                    case "2":
                        //--Exit
                        continueToRun = false;
                        break;
                    default:
                        break;
                }
            }

        }
        private void DisplayMenuItems()
        {
            Console.Clear();

            List<MenuItem> menu = _menuRepository.SeeMenu();
            foreach (MenuItem item in menu)
            {
                Console.WriteLine($"Meal Number: {item.MealNumber}\n" +
                    $"Meal Name: {item.MealName}\n" +
                    $"Meal Description: {item.MealDescription}\n" +
                    $"Meal Ingredients: {item.Ingredients}\n" +
                    $"Meal Cost: {item.MealCost}");
            }
            Console.WriteLine("Press something and go away..");
            Console.ReadKey();
        }
        private void SeedContent()
        {
            MenuItem chickenSandwhich = new MenuItem(1, "Chicken Sandwhich,", "Boneless fried chicken on a brioche bun, served with fries and a drink.",
                "Bread and Chicken.", 35.50);
            _menuRepository.AddItemToMenu(chickenSandwhich);
            MenuItem chickenTenders = new MenuItem(2, "Chicken Tenders", "Fried chicken tenders.", "Chicken tenderloins", 50.75);
            _menuRepository.AddItemToMenu(chickenTenders);
        }
    }
}
