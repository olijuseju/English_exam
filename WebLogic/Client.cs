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
        public string email { get; set; }
        public string password { get; set; }
        

        public Client(int id, string name, string lastName, int cardNumer, int phone , string email, string password)
        {
            this.id = id;
            this.name = name;
            this.lastName = lastName;
            this.email = email;
            this.password = password;
            this.cardNumer = cardNumer;
            this.phone = phone;
        }

        public Client( string name, string lastName, int cardNumer, int phone, string email, string password)
        {
            
            this.name = name;
            this.lastName = lastName;
            this.email = email;
            this.password = password;
            this.cardNumer = cardNumer;
            this.phone = phone;
        }

        public Client() { }
    }
}