using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebLogic.localhost;

namespace WebLogic
{
    public partial class ReceptionistPage : System.Web.UI.Page
    {
        WebService1 webService;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            WebService1 webService = new WebService1();
            if (TextBox1.Text != "" && TextBox2.Text != "" && TextBox3.Text != "" 
                && TextBox4.Text != "" && TextBox5.Text != "" && TextBox6.Text != "")
            {
                int cardNumber = Int16.Parse(TextBox3.Text);
                int phone = Int16.Parse(TextBox4.Text);
                webService.AddClient(TextBox1.Text, TextBox2.Text, cardNumber, phone, TextBox5.Text, TextBox6.Text);
            }
            else
            {

            }
        }
    }
}