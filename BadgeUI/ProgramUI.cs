using BadgeClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgeUI
{
    public class ProgramUI
    {
        private BadgeRepository _badgeRepository = new BadgeRepository();

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

                Console.WriteLine("Hello Security Admin, What would you like to do? \n" +
                    "1. Add a badge.\n" +
                    "2. Edit a badge.\n" +
                    "3. List all Badges\n" +
                    "4. Exit.");

                string userInput = Console.ReadLine();
                userInput = userInput.Replace(" ", "");
                switch (userInput)
                {
                    case "1":
                        AddBadge();
                        break;

                    case "2":
                        UpdateBadge();
                        break;

                    case "3":
                        ListAllBadges();
                        break;

                    case "4":
                        continueToRun = false;
                        break;

                    default:
                        break;
                }

            }
        }

        private void AddBadge()
        {
            Console.Clear();

            List<string> newList = new List<string>();
            Badge newBadge = new Badge();
            Console.WriteLine("What is the number on the badge:");
            string userInput = Console.ReadLine();
            newBadge.ID = int.Parse(userInput);

            Console.WriteLine("List a door that it needs access to:");
            string doorInput = Console.ReadLine();
            newList.Add(doorInput);

            Console.WriteLine("Any other doors(y/n)?");
            string input = Console.ReadLine();
            switch (input)
            {
                case "y":
                    Console.WriteLine("List a door that it needs access to:");
                    doorInput = Console.ReadLine();
                    newList.Add(doorInput);
                    _badgeRepository.AddBadgeToDictionary(newBadge.ID, newList);
                    break;

                case "n":
                    _badgeRepository.AddBadgeToDictionary(newBadge.ID, newList);
                    break;
            }
            Console.WriteLine("The badge had been added! Press any key to continue");
            Console.ReadKey();

        }
        private void UpdateBadge()
        {
            Console.Clear();

            Badge badge = new Badge();
            Console.WriteLine("What is the badge number to update?");
            string userInput = Console.ReadLine();
            badge.ID = int.Parse(userInput);
            List<string> accessedDoors = _badgeRepository.GetAccessByID(badge.ID);

            Console.Clear();

            Console.WriteLine($"{badge.ID} has access to these doors:");
            foreach (string door in accessedDoors)
            {
                Console.WriteLine(door);
            }

            Console.WriteLine("What would you like to do?\n" +
                "1. Add a door.\n" +
                "2. Remove a door.");
            string nextInput = Console.ReadLine();
            switch (nextInput)
            {
                case "2":
                    Console.WriteLine("Which door would you like to remove? ");

                    string doorInputR = Console.ReadLine();
                    if (accessedDoors.Contains(doorInputR))
                    {
                        accessedDoors.Remove(doorInputR);
                        Console.WriteLine("The door has been removed. This badge now has access to:");
                        foreach (string door in accessedDoors)
                        {
                            Console.WriteLine(door);
                        }
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("That door is not in this badge's access list. Press any key to continue.");
                        Console.ReadKey();
                    }
                    break;

                case "1":
                    Console.WriteLine("What door would you like to add access to?");
                    string doorInputA = Console.ReadLine();
                    accessedDoors.Add(doorInputA);

                    Console.Clear();

                    Console.WriteLine("Now this badge has acces to:");
                    foreach (string door in accessedDoors)
                    {
                        Console.WriteLine(door);
                    }
                    break;
            }
            Console.WriteLine("Press any key to return to the main menu.");
            Console.ReadKey();
        }

        private void ListAllBadges()
        {
            Console.Clear();


            Dictionary<int, List<string>> dictionary = _badgeRepository.GetDictionary();
            //List<string> list = _badgeRepository.GetAccessByID();

            //foreach (KeyValuePair<int, List<string>> badge in dictionary)
            //{
            //    foreach (string door in (badge.Value)
            //    {

            //    }
            //    Console.WriteLine("Id: {0}, DoorsAccessible: {1}",
            //badge.Key, badge.Value);
            //}
            Console.WriteLine("Here is the list of badges and all doors they have access to:");
            foreach(int id in dictionary.Keys)
            {
                Console.WriteLine(id);
                foreach(string door in dictionary[id])
                {
                  Console.Write("{0}, ", door);
                }
                Console.WriteLine();
            }
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
        private void SeedContent()
        {
            List<string> listOne = new List<string>
            {
                "A1",
                "A2",
                "B1",
                "B2"
            };
            _badgeRepository.AddBadgeToDictionary(246, listOne);

            List<string> listTwo = new List<string>
            {
                "C1",
                "C2",
                "D1",
                "D2"
            };
            _badgeRepository.AddBadgeToDictionary(123, listTwo);

            List<string> listThree = new List<string>
            {
                "A1",
                "B2",
                "C1",
                "D2"
            };
            _badgeRepository.AddBadgeToDictionary(321, listThree);
        }
    }
}
