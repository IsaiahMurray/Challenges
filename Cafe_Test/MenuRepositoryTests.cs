using System;
using System.Collections.Generic;
using Komodo_Cafe;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cafe_Test
{
    [TestClass]
    public class MenuRepositoryTests
    {
        [TestMethod]
        public void AddItemToMenu_ShouldGetBoolean()
        {
            MenuItem item = new MenuItem();
            MenuRepository menuRepository = new MenuRepository();

            bool addItem = menuRepository.AddItemToMenu(item);

            Assert.IsTrue(addItem);
        }

        [TestMethod]
        public void GetMenu_ShouldReturnMenu()
        {
            MenuItem item = new MenuItem();
            MenuRepository menuRepo = new MenuRepository();

            menuRepo.AddItemToMenu(item);

            List<MenuItem> menuItems = menuRepo.SeeMenu();

            bool menuHasItems = menuItems.Contains(item);
            Assert.IsTrue(menuHasItems);
        }
    }
}
