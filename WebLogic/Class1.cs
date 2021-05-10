using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebLogic
{
    public class Client
    {
        public int id { get; set; }
        public string name { get; set; }
        public string lastName { get; set; }
        public int cardNumer { get; set; }
        public int phone { get; set; }
        public string password { get; set; }
        public int RecpcionistId { get; set; }
        public string email { get; set; }

        public Client(int id, string name, string lastName, int cardNumer, int phone, string password, int RecepcionistId)
        {
            this.id = id;
            this.name = name;
            this.lastName = lastName;
            this.password = password;
            this.cardNumer = cardNumer;
            this.phone = phone;
            this.RecpcionistId = RecepcionistId;
        }

        public Client(int id, string name, string lastName, int cardNumer, int phone, string password, int RecepcionistId, string email)
        {
            this.id = id;
            this.name = name;
            this.lastName = lastName;
            this.password = password;
            this.cardNumer = cardNumer;
            this.phone = phone;
            this.RecpcionistId = RecepcionistId;
            this.email = email;
        }

        public Client(string name, string lastName, int cardNumer, int phone, string password, int RecepcionistId)
        {
            this.name = name;
            this.lastName = lastName;
            this.password = password;
            this.cardNumer = cardNumer;
            this.phone = phone;
            this.RecpcionistId = RecepcionistId;
        }

        public Client() { }
    }
}