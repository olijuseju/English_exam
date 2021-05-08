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
    public partial class ReceptionistPage : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            WebService1 webService = new WebService1();
            DataTable dt = webService.GetAllClients();
            foreach (DataRow dr in dt.Rows)
            {
                ListOfClients.Items.Add(dr[1].ToString());
            }
            DataTable dR = webService.GetAllReservations();
            foreach (DataRow drR in dR.Rows)
            {
                ListOfReservations.Items.Add(drR[1].ToString());
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            WebService1 webService = new WebService1();
            if (NameClient.Text != "" && LastnameClient.Text != "" && CardNumberClient.Text != "" 
                && PhoneClient.Text != "" && EmailClient.Text != "" && PasswordClient.Text != "")
            {
                if(webService.ClientExists(NameClient.Text, LastnameClient.Text, 
                    Convert.ToInt32(CardNumberClient.Text), Convert.ToInt32(PhoneClient.Text), 
                    EmailClient.Text, PasswordClient.Text).Equals(true))
                {
                    //dialog exite client
                }
                else
                {
                    webService.AddClient(NameClient.Text, LastnameClient.Text, Convert.ToInt32(CardNumberClient.Text), Convert.ToInt32(PhoneClient.Text), EmailClient.Text, PasswordClient.Text);

                }
            }
            else
            {
                //dialog que esta vacio
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            WebService1 webService = new WebService1();
            if (CliendIdReservation.Text != "" && ArrivalDateReservation.Text != ""
                && ExitDateReservation.Text != "" && PeopleQuantityReservation.Text != "" && RoomIdReservation.Text != "")
            {
                int recepcionistId = (int)Session["valor1"];
                if (webService.ReservationExists(Convert.ToInt32(CliendIdReservation.Text), recepcionistId,
                    Convert.ToInt32(ArrivalDateReservation.Text), Convert.ToInt32(ExitDateReservation.Text),
                    Convert.ToInt32(PeopleQuantityReservation.Text), Convert.ToInt32(RoomIdReservation.Text)).Equals(true))
                {
                    //dialog exite client
                }
                else
                {
                    webService.AddReservation(Convert.ToInt32(CliendIdReservation.Text), recepcionistId,
                    Convert.ToInt32(ArrivalDateReservation.Text), Convert.ToInt32(ExitDateReservation.Text),
                    Convert.ToInt32(PeopleQuantityReservation.Text), Convert.ToInt32(RoomIdReservation.Text));

                }
            }
            else
            {
                //dialog que esta vacio
            }
        }
    }
}