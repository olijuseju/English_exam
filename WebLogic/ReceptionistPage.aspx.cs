using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebLogic.localhost;
using System.Data;
using System.Data.SQLite;
using System.Text;

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

            StringBuilder sb = new StringBuilder();
            sb.Append("<table class=\"table table-striped\" id=\"TablaReservations\">");
            sb.Append("<thead class=\"thead-dark\">");
            sb.Append("<tr>");
            sb.Append("<th scope=\"col\">ID RESERVATION</th>");
            sb.Append("<th scope=\"col\">Client</th>");
            sb.Append("<th scope=\"col\">Receptionist</th>");
            sb.Append("<th scope=\"col\">Arrival date</th>");
            sb.Append("<th scope=\"col\">Exit date</th>");
            sb.Append("<th scope=\"col\">Room</th>");
            sb.Append("</tr>");
            sb.Append("</thead>");
            sb.Append("<tbody id=\"reservationsData\">");
            sb.Append("<tbody id=\"reservationsData\">");

            foreach (DataRow dr in dR.Rows)
            {
                sb.Append("<tr>");
                sb.Append("<th scope=\"row\">" + dr[0].ToString() + "</th>");
                sb.Append("<td>" + dr[1].ToString() + "</td>");
                sb.Append("<td>" + dr[2].ToString() + "</td>");
                sb.Append("<td>" + dr[3].ToString() + "</td>");
                sb.Append("<td>" + dr[4].ToString() + "</td>");
                sb.Append("<td>" + dr[5].ToString() + "</td>");
                sb.Append("</tr>");

            }

            sb.Append("</tbody>");
            sb.Append("</table>");
            TablaReservations.Controls.Add(new Label { Text = sb.ToString() });

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