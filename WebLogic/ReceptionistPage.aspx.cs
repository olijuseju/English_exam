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
            if (Session["valor1"] != null)
            {
                WebService1 webService = new WebService1();
                DataTable dt = webService.GetClientByReceptionistId(Convert.ToInt32(Session["valor1"]));
                StringBuilder clientTable = new StringBuilder();
                clientTable.Append("<table class=\"table table-striped\" id=\"TableClient\">");
                clientTable.Append("<thead class=\"thead-dark\">");
                clientTable.Append("<tr>");
                clientTable.Append("<th scope=\"col\">Id</th>");
                clientTable.Append("<th scope=\"col\">Name</th>");
                clientTable.Append("<th scope=\"col\">Lastname</th>");
                clientTable.Append("<th scope=\"col\">Cardnumber date</th>");
                clientTable.Append("<th scope=\"col\">Phone</th>");
                clientTable.Append("<th scope=\"col\">Password</th>");
                clientTable.Append("<th scope=\"col\">Actions</th>");
                clientTable.Append("</tr>");
                clientTable.Append("</thead>");
                clientTable.Append("<tbody id=\"ClientData\">");
                clientTable.Append("<tbody id=\"ClientData\">");

                foreach (DataRow dr in dt.Rows)
                {
                    clientTable.Append("<tr>");
                    clientTable.Append("<th scope=\"row\">" + dr[0].ToString() + "</th>");
                    clientTable.Append("<td>" + dr[1].ToString() + "</td>");
                    clientTable.Append("<td>" + dr[2].ToString() + "</td>");
                    clientTable.Append("<td>" + dr[3].ToString() + "</td>");
                    clientTable.Append("<td>" + dr[4].ToString() + "</td>");
                    clientTable.Append("<td>" + dr[5].ToString() + "</td>");
                    clientTable.Append("<td>" + "<button type=\"button\" class=\"btn btn-primary \">Edit</button> <button type=\"button\" class=\" btn btn-danger\">Delete</button>" + "</td>");
                    clientTable.Append("</tr>");

                }

                clientTable.Append("</tbody>");
                clientTable.Append("</table>");
                TablaClientOfReceptionist.Controls.Add(new Label { Text = clientTable.ToString() });

                DataTable dR = webService.GetReservationByReceptionistId(Convert.ToInt32(Session["valor1"]));

                StringBuilder sb = new StringBuilder();
                sb.Append("<table class=\"table table-striped\" id=\"TableReser\">");
                sb.Append("<thead class=\"thead-dark\">");
                sb.Append("<tr>");
                sb.Append("<th scope=\"col\">Id</th>");
                sb.Append("<th scope=\"col\">Client</th>");
                sb.Append("<th scope=\"col\">Recepcionist</th>");
                sb.Append("<th scope=\"col\">Arrival date</th>");
                sb.Append("<th scope=\"col\">Exit date</th>");
                sb.Append("<th scope=\"col\">Room</th>");
                sb.Append("<th scope=\"col\">Actions</th>");
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
                    sb.Append("<td>"+ "<button type=\"button\" class=\"btn btn-primary \">Edit</button> <button type=\"button\" class=\" btn btn-danger\">Delete</button>" + "</td>");
                    sb.Append("</tr>");

                }

                sb.Append("</tbody>");
                sb.Append("</table>");
                TablaReservations.Controls.Add(new Label { Text = sb.ToString() });
            }
            else
            {
                Response.Redirect("Login.aspx");
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
                    EmailClient.Text, PasswordClient.Text, Convert.ToInt32(Session["valor1"])).Equals(true))
                {
                    //dialog exite client
                }
                else
                {
                    webService.AddClient(NameClient.Text, LastnameClient.Text, Convert.ToInt32(CardNumberClient.Text), Convert.ToInt32(PhoneClient.Text), PasswordClient.Text , Convert.ToInt32(Session["valor1"]), EmailClient.Text);

                    int idClient = webService.GetIdClientExists(NameClient.Text, LastnameClient.Text, Convert.ToInt32(CardNumberClient.Text), Convert.ToInt32(PhoneClient.Text), PasswordClient.Text, Convert.ToInt32(Session["valor1"]));
                    webService.AddLogin(EmailClient.Text, PasswordClient.Text, "client", idClient);
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