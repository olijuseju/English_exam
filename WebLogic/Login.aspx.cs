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
using System.Web.Security;


namespace WebLogic
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["valor1"] = null;
            FormsAuthentication.SignOut();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            WebService1 ws = new WebService1();
            string user = EmailTextBox.Text;
            string pass = PassTextBox.Text;

            if (user.Length == 0 || pass.Length == 0)
            {
                return;
            }

            DataTable dt = ws.Login(user, pass);
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["type"].ToString().Equals("client"))
                {
                    DataTable dtClient = ws.GetClientById(Convert.ToInt32(dr["idUser"]));
                    foreach(DataRow drClient in dtClient.Rows)
                    {
                        int valor =Convert.ToInt32(drClient["id"]);

                        Session["valor1"] = valor;
                        FormsAuthentication.SetAuthCookie("user", true);
                        Response.Redirect("user/ClientsPage.aspx");
                    }
                }
                else
                {
                    DataTable dtRec = ws.GetRecepcionistById(Convert.ToInt32(dr["idUser"]));
                    foreach (DataRow drRecep in dtRec.Rows)
                    {
                        int valor = Convert.ToInt32(drRecep["id"]);

                        Session["valor1"] = valor;
                        FormsAuthentication.SetAuthCookie("admin", true);
                        Response.Redirect("Receptionist/ReceptionistPage.aspx");
                    }
                }
            }
        }
    }
}