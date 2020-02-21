using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Cafe
{
    public class MenuRepository
    {
        public readonly List<MenuItem> _menu = new List<MenuItem>();

        public bool AddItemToMenu(MenuItem item)
        {
            int menuLength = _menu.Count();
            _menu.Add(item);
            bool itemAdded = menuLength + 1 == _menu.Count();
            return itemAdded;
        }

        public List<MenuItem> SeeMenu()
        {
            return _menu;
        }

        public MenuItem GetMenuItemByName(string mealName)
        {
            foreach (MenuItem item in _menu)
            {
                if (item.MealName.ToLower() == mealName.ToLower())
                {
                    return item;
                } 
            }
            return null;
        }

        public bool DeleteExistingMenuItem(string mealName)
        {
            MenuItem foundItem = GetMenuItemByName(mealName);
            bool deletedItem = _menu.Remove(foundItem);
            return deletedItem;
        }
    }
}
