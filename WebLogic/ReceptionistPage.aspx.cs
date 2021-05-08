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
       
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            WebService1 webService = new WebService1();
            if (NameClient.Text != "" && LastnameClient.Text != "" && CardNumberClient.Text != "" 
                && PhoneClient.Text != "" && EmailClient.Text != "" && PasswordClient.Text != "")
            {
                
                webService.AddClient(NameClient.Text , LastnameClient.Text, Convert.ToInt32(CardNumberClient.Text) , Convert.ToInt32(PhoneClient.Text) , EmailClient.Text , PasswordClient.Text);
            }
            else
            {

            }
        }
    }
}