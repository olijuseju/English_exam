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
            if (NameClient.Text != "" && LastnameClient.Text != "" && CardNumberClient.Text != "" 
                && PhoneClient.Text != "" && EmailClient.Text != "" && PasswordClient.Text != "")
            {
                int cardNumber = Int16.Parse(CardNumberClient.Text);
                int phone = Int16.Parse(PhoneClient.Text);
                webService.AddClient(NameClient.Text, LastnameClient.Text, cardNumber, phone, EmailClient.Text, PasswordClient.Text);
            }
            else
            {

            }
        }
    }
}