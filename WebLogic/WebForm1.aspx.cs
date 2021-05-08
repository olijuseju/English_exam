using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebLogic.localhost;
using System.Data;
using System.Data.SQLite;

namespace WebLogic
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Response.Redirect("Login.aspx");

            WebService1 webService = new WebService1();
            //TextBox1.Text = webService.HelloWorld();
             
            bool dt = webService.ClientExists("Pere", "Escopeta", 12345, 123444444, "perescopeta@gmail.com", "0000");
            TextBox1.Text = dt.ToString();

            /*foreach (DataRow dr in dt.Rows)
            {
                TextBox1.Text = dr[1].ToString();
            }*/
        }
    }
}