using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebLogic.localhost;


namespace WebLogic
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            WebService1 ws = new WebService1();
            string user = EmailTextBox.Text;
            string pass = PassTextBox.Text;
            using (MD5 md5Hash = MD5.Create())
            {
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(pass));
                pass = BitConverter.ToString(data).Replace("*", string.Empty);
            }
            if (user.Length == 0 || pass.Length == 0)
            {
                return;
            }

            DataTable dt = ws.Login(user, pass);
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["email"].ToString() == user)
                {
                    using (MD5 md5Hash = MD5.Create())
                    {

                        string passHash = dr["password"].ToString().ToUpper();
                        if (pass == passHash)
                        {
                            if (dr["role"].ToString() == "recepcionist")
                            {
                                Response.Redirect("./ReceptionistPage.aspx");

                            }
                            else if (dr["role"].ToString() == "client")
                            {
                                Response.Redirect("./Webform2.aspx");

                            }
                        }
                    }
                }
            }
        }
    }
}