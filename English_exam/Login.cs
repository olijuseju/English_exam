using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace English_exam
{
    public class Login
    {
        public int id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string type { get; set; }
        public int userId { get; set; }


        public Login()
        {

        }


        public Login(int id, string email, string password, string type, int userId)
        {
            this.id = id;
            this.email = email;
            this.password = password;
            this.type = type;
            this.userId = userId;
        }

        public Login(string email, string password, string type, int userId)
        {
            this.email = email;
            this.password = password;
            this.type = type;
            this.userId = userId;
        }
    }
}