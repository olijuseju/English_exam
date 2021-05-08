using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebLogic
{
    public class Room
    {
        public Room()
        {

        }

        public Room(int id, int number, string typeRoom, string name, string available, int spaces)
        {
            this.id = id;
            this.number = number;
            this.typeRoom = typeRoom;
            this.name = name;
            this.available = available;
            this.spaces = spaces;
        }

        public int id { get; set; }
        public int number { get; set; }
        public string typeRoom { get; set; }
        public string name { get; set; }
        public string available { get; set; }
        public int spaces { get; set; }
    }
}