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


            WebService1 webService = new WebService1();
            //TextBox1.Text = webService.HelloWorld();
            DataTable dt = webService.GetAllClients();
            

            foreach (DataRow dr in dt.Rows)
            {
                TextBox1.Text = dr[1].ToString();
            }
        }
    }
}