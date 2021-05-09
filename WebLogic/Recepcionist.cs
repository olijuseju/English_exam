using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebLogic
{
    public class Recepcionist
    {

        public Recepcionist()
        {

        }

        public Recepcionist(int id, string name, string lastName, string password, int role)
        {
            this.id = id;
            this.name = name;
            this.lastName = lastName;
            this.password = password;
            this.role = role;
        }

        public Recepcionist(string name, string lastName, string password, int role)
        {
            this.name = name;
            this.lastName = lastName;
            this.password = password;
            this.role = role;
        }


        public int id { get; set; }
        public string name { get; set; }
        public string lastName { get; set; }
        public string password { get; set; }
        public int role { get; set; }
    }
}