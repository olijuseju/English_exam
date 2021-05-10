using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebLogic.localhost;
using System.Data;

namespace WebLogic
{
    public partial class UserClientPage : System.Web.UI.Page
    {
        public WebService1 webService = new WebService1();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["valor1"] != null)
            {

                DataTable dt = webService.GetClientById(Convert.ToInt32(Session["valor1"]));
                foreach (DataRow dr in dt.Rows)
                {
                    Label1.Text = "Bienvenido, señor/a " + dr[1].ToString() + " " + dr[2].ToString();

                }

                DataTable ReservationsTable = webService.GetReservationByClientId(Convert.ToInt32(Session["valor1"]));
                foreach (DataRow ReservationsTableRow in ReservationsTable.Rows)
                {
                    ListBox1.Items.Add("Arrival Date: " + ReservationsTableRow["arrivalDate"]);
                    ListBox1.Items.Add("End Date: " + ReservationsTableRow["exitDate"]);
                    ListBox1.Items.Add("Room: ");
                    DataTable RoomDataTable = webService.GetRoomById(Convert.ToInt32(ReservationsTableRow["RoomId"]));
                    foreach (DataRow RoomTableRow in RoomDataTable.Rows)
                    {
                        ListBox1.Items.Add("Number: " + RoomTableRow["number"]);
                        ListBox1.Items.Add("Name: " + RoomTableRow["Name"]);
                        ListBox1.Items.Add("Type of Room: " + RoomTableRow["typeRoom"]);
                        ListBox1.Items.Add("Spaces: " + RoomTableRow["spaces"]);
                    }
                    ListBox1.Items.Add("Number of people: " + ReservationsTableRow["PeopleQuantity"]);
                    ListBox1.Items.Add("Recepcionist: ");
                    DataTable RecDataTable = webService.GetRecepcionistById(Convert.ToInt32(ReservationsTableRow["RecepcionistId"]));
                    foreach (DataRow RecTableRow in RecDataTable.Rows)
                    {
                        ListBox1.Items.Add("Name: " + RecTableRow["Name"] + " " + RecTableRow["LastName"]);
                    }

                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}