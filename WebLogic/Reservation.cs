using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebLogic
{
    public class Reservation
    {
        public int id { get; set; }
        public int clientId { get; set; }
        public int RecepcionistId { get; set; }
        public int arrivalDate { get; set; }
        public int exitDate { get; set; }
        public int PeopleQuantity { get; set; }
        public int RoomId { get; set; }

    }
}