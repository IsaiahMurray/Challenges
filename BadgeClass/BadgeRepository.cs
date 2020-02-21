using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgeClass
{
    public class BadgeRepository
    {
        private List<string> _doors = new List<string>();
        private Dictionary<int, List<string>> _dictionary = new Dictionary<int, List<string>>();
        public Badge _badge = new Badge();

        public bool AddBadgeToDictionary(int id, List<string> doors)
        {
            int dictionaryLength = _dictionary.Count();
            _dictionary.Add(id, doors);
            bool wasAdded = dictionaryLength + 1 == _dictionary.Count();
            return wasAdded;
        }

        public Dictionary<int, List<string>> GetDictionary()
        {
            return _dictionary;
        }
        public List<string> GetAccessByID(int id)
        {
            if (_dictionary.TryGetValue(id, out _doors))
            {
                return (_doors);
            }
            else
            {
                return null;
            }
        }

        public bool UpdateBadge(int originalID, List<string> newDoors)
        {
            List<string> oldDoors = GetAccessByID(originalID);
           

            if (oldDoors != null)
            {
                oldDoors = newDoors;
                return true;
            }
            else return false;
        }

        public bool DeleteDoorsFromList(int id)
        {
            List<string> accessFound = GetAccessByID(id);

            foreach (string door in accessFound)
            {
             
                bool deletedDoor = accessFound.Remove(door);
                return deletedDoor;
            }
            return false;
        }
    }
}
