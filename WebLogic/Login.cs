using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebLogic
{
    public class LoginC
    {
        public int id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string type { get; set; }
        public int userId { get; set; }


        public LoginC()
        {

        }


        public LoginC(int id, string email, string password, string type, int userId)
        {
            this.id = id;
            this.email = email;
            this.password = password;
            this.type = type;
            this.userId = userId;
        }

        public LoginC(string email, string password, string type, int userId)
        {
            this.email = email;
            this.password = password;
            this.type = type;
            this.userId = userId;
        }
    }
}