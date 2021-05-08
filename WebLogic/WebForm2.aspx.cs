using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebLogic
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["valor1"] != null)
            {
                Button1.Text = Session["valor1"].ToString();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}