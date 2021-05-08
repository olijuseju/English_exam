using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebLogic
{
    public class Room
    {
        public int id { get; set; }
        public int number { get; set; }
        public string typeRoom { get; set; }
        public string name { get; set; }
        public string available { get; set; }
        public int spaces { get; set; }
    }
}