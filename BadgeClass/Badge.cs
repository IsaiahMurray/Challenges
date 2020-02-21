using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgeClass
{
    public class Badge
    {
        public int ID { get; set; }
        public List<string> DoorAccess { get; set; }


        public Badge() { }
        public Badge(int id, List<string> doors)
        {
            ID = id;
            DoorAccess = doors;
        }
    }

}
