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
        private List<Client> listOfClients = new List<Client>();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Session["valor1"] != null)
            {
                setListOfClients();

                isAdmin();
                if (Page.IsPostBack == false)
                {
                    ListBoxClients();

                    ListBoxReservation();
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }


        }

        private void setListOfClients()
        {
            listOfClients.Clear();
            WebService1 webService = new WebService1();
            DataTable dt = webService.GetClientByReceptionistId(Convert.ToInt32(Session["valor1"]));
            DataTable dtLogin;
            foreach (DataRow dr in dt.Rows)
            {
                dtLogin = webService.GetLoginByClientId(Convert.ToInt32(dr["Id"]));
                listOfClients.Add(new Client(Convert.ToInt32(dr["Id"]), dr["Name"].ToString(), dr["Lastname"].ToString(),
                    (int)Convert.ToInt64(dr["CardNumber"]), (int)Convert.ToInt64(dr["Phone"]), 
                    dr["Password"].ToString(), Convert.ToInt32(dr["RecepcionistId"])));
            }
        }

        private void isAdmin()
        {
            WebService1 webService = new WebService1();
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

        private void ListBoxClients()
        {
           
            ListsOfClientOfRecepcionist.Items.Clear();

            foreach (Client client in listOfClients)
            {
                ListsOfClientOfRecepcionist.Items.Add("Name: "+client.name + " LastName: " + client.lastName + " CardNumber: " + client.cardNumer.ToString() + " Phone: " + client.phone.ToString() + " Password: " + client.password + " ID Recepcionist: " + client.RecpcionistId.ToString());

            }
        }
        private void ListBoxReservation()
        {
            TablaReservations.Controls.Clear();
            WebService1 webService = new WebService1();
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


            foreach (DataRow dr in dR.Rows)
            {
                sb.Append("<tr>");
                sb.Append("<th scope=\"row\">" + dr[0].ToString() + "</th>");
                sb.Append("<td>" + dr[1].ToString() + "</td>");
                sb.Append("<td>" + dr[2].ToString() + "</td>");
                sb.Append("<td>" + dr[3].ToString() + "</td>");
                sb.Append("<td>" + dr[4].ToString() + "</td>");
                sb.Append("<td>" + dr[5].ToString() + "</td>");
                sb.Append("<td>" + "<button type=\"button\" runat=\"server\" onserverclick=\"EditClient_Click\" class=\"btn btn-primary\" > Edit</button> " +
                    "<button type=\"button\" runat=\"server\" onserverclick =\"EditClient_Click()\" class=\"btn btn-danger\" > Delete</button> ");
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
                if (webService.ClientExists(NameClient.Text, LastnameClient.Text,
                    (int)Convert.ToInt64(CardNumberClient.Text), (int)Convert.ToInt32(PhoneClient.Text),
                    EmailClient.Text, PasswordClient.Text, Convert.ToInt32(Session["valor1"])).Equals(true))
                {
                    //dialog exite client
                }
                else
                {
                    webService.AddClient(NameClient.Text, LastnameClient.Text, (int)Convert.ToInt32(CardNumberClient.Text), (int)Convert.ToInt32(PhoneClient.Text), PasswordClient.Text, Convert.ToInt32(Session["valor1"]), EmailClient.Text);

                    int idClient = webService.GetIdClientExists(NameClient.Text, LastnameClient.Text, (int)Convert.ToInt32(CardNumberClient.Text), (int)Convert.ToInt32(PhoneClient.Text), PasswordClient.Text, Convert.ToInt32(Session["valor1"]));
                    webService.AddLogin(EmailClient.Text, PasswordClient.Text, "client", idClient);
                    ListBoxClients();
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

        protected void EditClient_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void ListsOfClientOfRecepcionist_SelectedIndexChanged(object sender, EventArgs e)
        {
            RemoveClientButton.Text = "Remove";
            RemoveClientButton.Enabled = true;
            NameClientUpdate.Enabled = true;
            LastnameClientUpdate.Enabled = true;
            CardNumberClientUpdate.Enabled = true;
            PhoneClientUpdate.Enabled = true;
            
            PasswordClientUpdate.Enabled = true;
            btnUpdateClient.Enabled = true;
            
            int pos = 0;
            pos = ListsOfClientOfRecepcionist.SelectedIndex;

            Client updateClient= listOfClients[pos];
            NameClientUpdate.Text = updateClient.name;
            LastnameClientUpdate.Text = updateClient.lastName;
            CardNumberClientUpdate.Text = updateClient.cardNumer.ToString();
            PhoneClientUpdate.Text = updateClient.phone.ToString();
            PasswordClientUpdate.Text = updateClient.password;
            

        }

        protected void RemoveClientButton_Click(object sender, EventArgs e)
        {
            ListsOfClientOfRecepcionist.ClearSelection();
            RemoveClientButton.Enabled = false;
            RemoveClientButton.Text = "Select a client of the list to remove";
            NameClientUpdate.Enabled = false;
            NameClientUpdate.Text = "";
            LastnameClientUpdate.Enabled = false;
            LastnameClientUpdate.Text = "";
            CardNumberClientUpdate.Enabled = false;
            CardNumberClientUpdate.Text = "";
            PhoneClientUpdate.Enabled = false;
            PhoneClientUpdate.Text = "";
            PasswordClientUpdate.Enabled = false;
            PasswordClientUpdate.Text = "";
            btnUpdateClient.Enabled = false;

        }

        protected void btnUpdateClient_Click(object sender, EventArgs e)
        {
            if(NameClientUpdate.Text != "" && LastnameClientUpdate.Text != "" && CardNumberClientUpdate.Text != "" 
                && PhoneClientUpdate.Text != ""
                && PasswordClientUpdate.Text != "")
            {
                WebService1 webService = new WebService1();
                //webService.UpdateClient(NameClient.Text , LastnameClientUpdate.Text, CardNumberClientUpdate.Text , PasswordClientUpdate.Text);
            }
            else
            {
                //dialog
            }
        }
    }
}