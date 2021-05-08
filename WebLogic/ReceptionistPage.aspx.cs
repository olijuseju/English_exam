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
                int cardNumber = Convert.ToInt32(CardNumberClient.Text);
                int phone = Convert.ToInt32(PhoneClient.Text);
                webService.AddClient("name","last",3434,234242,"ASFAF","dsfsd");
            }
            else
            {

            }
        }
    }
}