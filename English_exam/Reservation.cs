using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace English_exam
{

    public class Reservation
    {

        public Reservation()
        {

        }

        public Reservation(int id, int clientId, int RecepcionistId, int arrivalDate, int exitDate, int PeopleQuantity, int RoomId)
        {
            this.id = id;
            this.clientId = clientId;
            this.RecepcionistId = RecepcionistId;
            this.arrivalDate = arrivalDate;
            this.exitDate = exitDate;
            this.PeopleQuantity = PeopleQuantity;
            this.RoomId = RoomId;
        }
        public Reservation(int clientId, int RecepcionistId, int arrivalDate, int exitDate, int PeopleQuantity, int RoomId)
        {
            this.clientId = clientId;
            this.RecepcionistId = RecepcionistId;
            this.arrivalDate = arrivalDate;
            this.exitDate = exitDate;
            this.PeopleQuantity = PeopleQuantity;
            this.RoomId = RoomId;
        }

        public int id { get; set; }
        public int clientId { get; set; }
        public int RecepcionistId { get; set; }
        public int arrivalDate { get; set; }
        public int exitDate { get; set; }
        public int PeopleQuantity { get; set; }
        public int RoomId { get; set; }

    }
}