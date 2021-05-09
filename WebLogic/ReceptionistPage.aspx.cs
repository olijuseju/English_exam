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
using System.IO;
using Newtonsoft.Json;

namespace WebLogic
{
    public partial class ReceptionistPage : System.Web.UI.Page
    {
        private int role;
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
                    clientTable.Append("<td>" + "<asp:LinkButton ID = 'Workarea' Text 'qlo' onclick = 'Workarea_Click' runat = 'server'></asp:LinkButton >" + "</td>");
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
                    Button b1 = new Button();
                    b1.Text = "button Label";
                    b1.ID = "ButtonId";
                    sb.Append("</tr>");

                }

                sb.Append("</tbody>");
                sb.Append("</table>");
                TablaReservations.Controls.Add(new Label { Text = sb.ToString() });

                DataTable myUser = webService.GetRecepcionistById(Convert.ToInt32(Session["valor1"]));
                foreach (DataRow dr in myUser.Rows)
                {
                    role = Convert.ToInt32(dr["role"]);
                }

                if (role == 1)
                {
                    Button5.Visible = true;
                    Button6.Visible = true;
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }

            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (role != 1)
            {

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

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (role != 1)
            {
                List<Client> clients = new List<Client>();
                List<LoginC> loginCs = new List<LoginC>();
                WebService1 webService = new WebService1();
                DataTable dt = webService.GetClientByReceptionistId(Convert.ToInt32(Session["valor1"]));
                foreach (DataRow dr in dt.Rows)
                {
                    clients.Add(new Client(Convert.ToInt32(dr["id"]), dr["name"].ToString(), dr["lastName"].ToString(), Convert.ToInt32(dr["cardNumber"]), Convert.ToInt32(dr["phone"]), dr["password"].ToString(), Convert.ToInt32(dr["RecepcionistId"])));
                    DataTable dtLogins = webService.GetLoginByClientId(Convert.ToInt32(dr["id"]));
                    foreach(DataRow drLogin in dtLogins.Rows)
                    {
                        loginCs.Add(new LoginC(Convert.ToInt32(drLogin[0]), drLogin[1].ToString(), drLogin[2].ToString(), drLogin[3].ToString(), Convert.ToInt32(drLogin[4])));
                    }
                }
                string JSONObject = JsonConvert.SerializeObject(clients);
                string JSONObjectLogins = JsonConvert.SerializeObject(loginCs);

                JSONObject += "\n" + JSONObjectLogins;
                webService.ClearClientList();

                TextBox1.Text = JSONObject;
                System.IO.File.WriteAllText(Server.MapPath("~/JsonData/jsondataClients.txt"), JSONObject);
            }
            else
            {
                List<Client> clients = new List<Client>();
                List<LoginC> loginCs = new List<LoginC>();
                WebService1 webService = new WebService1();
                DataTable dt = webService.GetAllClients();
                foreach (DataRow dr in dt.Rows)
                {
                    clients.Add(new Client(Convert.ToInt32(dr["id"]), dr["name"].ToString(), dr["lastName"].ToString(), Convert.ToInt32(dr["cardNumber"]), Convert.ToInt32(dr["phone"]), dr["password"].ToString(), Convert.ToInt32(dr["RecepcionistId"])));
                    DataTable dtLogins = webService.GetLoginByClientId(Convert.ToInt32(dr["id"]));
                    foreach (DataRow drLogin in dtLogins.Rows)
                    {
                        loginCs.Add(new LoginC(Convert.ToInt32(drLogin[0]), drLogin[1].ToString(), drLogin[2].ToString(), drLogin[3].ToString(), Convert.ToInt32(drLogin[4])));
                    }
                }
                string JSONObject = JsonConvert.SerializeObject(clients);
                string JSONObjectLogins = JsonConvert.SerializeObject(loginCs);

                JSONObject += "\n" + JSONObjectLogins;
                webService.ClearClientList();

                TextBox1.Text = JSONObject;
                System.IO.File.WriteAllText(Server.MapPath("~/JsonData/jsondataClients.txt"), JSONObject);
            }
           
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (role != 1)
            {
                List<Reservation> reservations = new List<Reservation>();
                WebService1 webService = new WebService1();
                DataTable dt = webService.GetReservationByReceptionistId(Convert.ToInt32(Session["valor1"]));
                foreach (DataRow dr in dt.Rows)
                {
                    reservations.Add(new Reservation(Convert.ToInt32(dr[0]), Convert.ToInt32(dr[1]), Convert.ToInt32(dr[2]), Convert.ToInt32(dr[3]), Convert.ToInt32(dr[4]), Convert.ToInt32(dr[5]), Convert.ToInt32(dr[6])));
                }
                string JSONObject = JsonConvert.SerializeObject(reservations);
                webService.ClearClientList();

                TextBox1.Text = JSONObject;
                System.IO.File.WriteAllText(Server.MapPath("~/JsonData/jsondataReservations.txt"), JSONObject);
            }
            else
            {
                List<Reservation> reservations = new List<Reservation>();
                WebService1 webService = new WebService1();
                DataTable dt = webService.GetAllReservations();
                foreach (DataRow dr in dt.Rows)
                {
                    reservations.Add(new Reservation(Convert.ToInt32(dr[0]), Convert.ToInt32(dr[1]), Convert.ToInt32(dr[2]), Convert.ToInt32(dr[3]), Convert.ToInt32(dr[4]), Convert.ToInt32(dr[5]), Convert.ToInt32(dr[6])));
                }
                string JSONObject = JsonConvert.SerializeObject(reservations);
                webService.ClearClientList();

                TextBox1.Text = JSONObject;
                System.IO.File.WriteAllText(Server.MapPath("~/JsonData/jsondataReservations.txt"), JSONObject);
            }
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            List<Recepcionist> recepcionists = new List<Recepcionist>();
            List<LoginC> loginCs = new List<LoginC>();
            WebService1 webService = new WebService1();
            DataTable dt = webService.GetAllReceptionists();
            foreach (DataRow dr in dt.Rows)
            {
                recepcionists.Add(new Recepcionist(Convert.ToInt32(dr[0]), dr[1].ToString(), dr[2].ToString(), dr[4].ToString(), Convert.ToInt32(dr[3])));
                DataTable dtLogins = webService.GetLoginByReceptionistId(Convert.ToInt32(dr["id"]));
                foreach (DataRow drLogin in dtLogins.Rows)
                {
                    loginCs.Add(new LoginC(Convert.ToInt32(drLogin[0]), drLogin[1].ToString(), drLogin[2].ToString(), drLogin[3].ToString(), Convert.ToInt32(drLogin[4])));
                }
            }
            string JSONObject = JsonConvert.SerializeObject(recepcionists); 
            string JSONObjectLogins = JsonConvert.SerializeObject(loginCs);

            JSONObject += "\n" + JSONObjectLogins;
            webService.ClearClientList();

            TextBox1.Text = JSONObject;
            System.IO.File.WriteAllText(Server.MapPath("~/JsonData/jsondataReceptionists.txt"), JSONObject);
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            List<Room> rooms = new List<Room>();
            WebService1 webService = new WebService1();
            DataTable dt = webService.GetAllRoom();
            foreach (DataRow dr in dt.Rows)
            {
                rooms.Add(new Room(Convert.ToInt32(dr[0]), Convert.ToInt32(dr[0]), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), Convert.ToInt32(dr[5])));
            }
            string JSONObject = JsonConvert.SerializeObject(rooms);
            webService.ClearClientList();
            TextBox1.Text = JSONObject;
            System.IO.File.WriteAllText(Server.MapPath("~/JsonData/jsondataRooms.txt"), JSONObject);
        }
    }
}