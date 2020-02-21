using System;
using System.Collections.Generic;
using BadgeClass;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BadgeRepoTests
{
    [TestClass]
    public class RepoTests
    {
        [TestMethod]
        public void AddBadgeToDictionary_ShouldReturnTrue()
        {
            Badge badge = new Badge();
            List<string> doors = new List<string>();
            BadgeRepository badgeRepository = new BadgeRepository();
            int id = badge.ID;

            bool addBadge = badgeRepository.AddBadgeToDictionary(id, doors);
            Assert.IsTrue(addBadge);
        }
        private BadgeRepository _badgeRepository = new BadgeRepository();
        private Badge _badge = new Badge();

        [TestMethod]
        public void GetDictionary_ShouldReturnCollection()
        {
            Badge badge = new Badge();
            BadgeRepository badgeRepository = new BadgeRepository();

            Dictionary<int, List<string>> dictionary = badgeRepository.GetDictionary();
            
            List<string> doors = new List<string>();

            badgeRepository.AddBadgeToDictionary(badge.ID, doors);
            


            bool dictionaryHasKey = dictionary.ContainsKey(badge.ID);
            bool dictionaryHasValue = dictionary.ContainsValue(doors);
            Assert.IsTrue(dictionaryHasKey);
            Assert.IsTrue(dictionaryHasValue);

        }

        [TestMethod]
        public void UpdateExistingDoors_ShouldreturnTrue()
        {
            List<string> listOne = new List<string>();
            
            listOne.Add("A1");
            listOne.Add("A2");
            listOne.Add("B1");

            _badgeRepository.AddBadgeToDictionary(123, listOne);

            List<string> listTwo = new List<string>();
            listTwo.Add("B2");
            listTwo.Add("B3");

            bool updateDoors = _badgeRepository.UpdateBadge(123, listTwo);
            Assert.IsTrue(updateDoors);
        }

        [TestMethod]
        public void DeleteDoorsFromBadge()
        {
            List<string> listOne = new List<string>
            {
                "A1",
                "A2",
                "B1"
            };

            _badgeRepository.AddBadgeToDictionary(123, listOne);

            bool removeDoors = _badgeRepository.DeleteDoorsFromList(123);
            Assert.IsTrue(removeDoors);
        }
    }
}
