using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SQLite;
using System.Security.Cryptography;
using System.Text;

namespace English_exam
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public DataTable Login(string user, string pass)
        {
            DataTable dt = new DataTable();
            string DBpath = Server.MapPath("database/marseloDatabase.db");
            SQLiteConnection conn = new SQLiteConnection("Data Source=" + DBpath + ";Version=3;");
            conn.Open();
            using (conn)
            {
                SQLiteCommand comm = new SQLiteCommand("SELECT * FROM Login WHERE `email` ='" + user+"' AND `password` ='" + pass+"' ;", conn);
                SQLiteDataReader reader = comm.ExecuteReader();
                dt.Load(reader);
                reader.Close();
            }
            return dt;
        }

        [WebMethod]
        public bool ClientExists(string name, string lastname, int cardnumber, int phone, string email, string password)
        {
            DataTable dt = GetAllClients();
            foreach (DataRow dr in dt.Rows)
            {
                if (dr[1].ToString().Equals(name) && dr[2].ToString().Equals(lastname) && dr[3].ToString().Equals(Convert.ToString(cardnumber))
                    && dr[4].ToString().Equals(Convert.ToString(phone)) && dr[5].ToString().Equals(email) && dr[6].ToString().Equals(password))
                {
                    return true;
                }
                
            }

            return false;

        }


        [WebMethod]
        public void AddClient(string name, string lastname, int cardnumber, int phone, string email , string password)
        {
            Client client = new Client(name,lastname,cardnumber,phone,email,password);
            string DBpath = Server.MapPath("database/marseloDatabase.db");
            using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + DBpath + ";Version=3;"))
            {
                conn.Open();
                SQLiteCommand comm = new SQLiteCommand("INSERT INTO Client (Name, Lastname, CardNumber, Phone,Email,Password) VALUES ( '"+client.name +"' , '"+ client.lastName +"' , '" + client.cardNumer + "' , '" + client.phone +"' , '" + client.email +"' , '" + client.password +"'  )", conn);
                SQLiteDataAdapter da = new SQLiteDataAdapter();
                da.InsertCommand = comm;
                da.InsertCommand.ExecuteNonQuery();
                conn.Close();
            }
            
        }

        [WebMethod]
        public bool ReservationExists(int clientId, int recepcionistId, int arrivalDate, int exitDate, int peopleQuatenty, int roomId)
        {
            DataTable dt = GetAllReservations();
            foreach (DataRow dr in dt.Rows)
            {
                if (dr[1].ToString().Equals(Convert.ToString(clientId)) && dr[2].ToString().Equals(Convert.ToString(recepcionistId)) && dr[3].ToString().Equals(Convert.ToString(arrivalDate))
                    && dr[4].ToString().Equals(Convert.ToString(exitDate)) && dr[5].ToString().Equals(Convert.ToString(peopleQuatenty)) && dr[6].ToString().Equals(Convert.ToString(roomId)))
                {
                    return true;
                }

            }

            return false;

        }

        [WebMethod]
        public void AddReservation(int clientId, int recepcionistId, int arrivalDate, int exitDate, int peopleQuatenty, int roomId)
        {
            Reservation reservation = new Reservation(clientId,recepcionistId, arrivalDate,exitDate, peopleQuatenty,roomId);
            string DBpath = Server.MapPath("database/marseloDatabase.db");
            using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + DBpath + ";Version=3;"))
            {
                conn.Open();
                SQLiteCommand comm = new SQLiteCommand("INSERT INTO Reservation (ClientId, RecepcionistId, ArrivalDate, ExitDate,PeopleQuantity,RoomId) VALUES ( '" + reservation.clientId + "' , '" + reservation.RecepcionistId + "' , '" + reservation.arrivalDate + "' , '" + reservation.exitDate + "' , '" + reservation.PeopleQuantity + "' , '" + reservation.RoomId + "'  )", conn);
                SQLiteDataAdapter da = new SQLiteDataAdapter();
                da.InsertCommand = comm;
                da.InsertCommand.ExecuteNonQuery();
                conn.Close();
            }
            
        }

        [WebMethod]
        public DataTable GetAllClients()
        {

            List<Client> listClients= new List<Client>();
            string DBpath = Server.MapPath("database/marseloDatabase.db");
            DataTable dt = new DataTable();
            using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + DBpath + ";Version=3;"))
                {
                    conn.Open();
                    SQLiteCommand comm = new SQLiteCommand("SELECT * FROM Client", conn);
                    SQLiteDataReader reader = comm.ExecuteReader();
                    dt.Load(reader);
                    conn.Close();
                }
            return dt;
        }

        [WebMethod]
        public DataTable GetClientById(int id)
        {

            List<Client> listClients = new List<Client>();
            string DBpath = Server.MapPath("database/marseloDatabase.db");
            DataTable dt = new DataTable();
            using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + DBpath + ";Version=3;"))
            {
                conn.Open();
                SQLiteCommand comm = new SQLiteCommand("SELECT * FROM Client WHERE `id` ="+ id, conn);
                SQLiteDataReader reader = comm.ExecuteReader();
                dt.Load(reader);
                conn.Close();
            }
            return dt;
        }

        [WebMethod]
        public DataTable GetRoomById(int id)
        {

            List<Client> listClients = new List<Client>();
            string DBpath = Server.MapPath("database/marseloDatabase.db");
            DataTable dt = new DataTable();
            using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + DBpath + ";Version=3;"))
            {
                conn.Open();
                SQLiteCommand comm = new SQLiteCommand("SELECT * FROM Room WHERE `id` =" + id, conn);
                SQLiteDataReader reader = comm.ExecuteReader();
                dt.Load(reader);
                conn.Close();
            }
            return dt;
        }

        [WebMethod]
        public DataTable GetReservationByClientId(int Cid)
        {

            List<Client> listClients = new List<Client>();
            string DBpath = Server.MapPath("database/marseloDatabase.db");
            DataTable dt = new DataTable();
            using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + DBpath + ";Version=3;"))
            {
                conn.Open();
                SQLiteCommand comm = new SQLiteCommand("SELECT * FROM Reservation WHERE `clientId` =" + Cid, conn);
                SQLiteDataReader reader = comm.ExecuteReader();
                dt.Load(reader);
                conn.Close();
            }
            return dt;
        }

        [WebMethod]
        public DataTable GetRecepcionistById(int id)
        {

            List<Client> listClients = new List<Client>();
            string DBpath = Server.MapPath("database/marseloDatabase.db");
            DataTable dt = new DataTable();
            using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + DBpath + ";Version=3;"))
            {
                conn.Open();
                SQLiteCommand comm = new SQLiteCommand("SELECT * FROM Receptionist WHERE `id` =" + id, conn);
                SQLiteDataReader reader = comm.ExecuteReader();
                dt.Load(reader);
                conn.Close();
            }
            return dt;
        }
        [WebMethod]

        public DataTable GetAllReservations()
        {

            List<Client> listClients = new List<Client>();
            string DBpath = Server.MapPath("database/marseloDatabase.db");
            DataTable dt = new DataTable();
            using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + DBpath + ";Version=3;"))
            {
                conn.Open();
                SQLiteCommand comm = new SQLiteCommand("SELECT * FROM Reservation", conn);
                SQLiteDataReader reader = comm.ExecuteReader();
                dt.Load(reader);
                conn.Close();
            }
            return dt;
        }

        [WebMethod]

        public DataTable GetAllReceptionists()
        {

            List<Client> listClients = new List<Client>();
            string DBpath = Server.MapPath("database/marseloDatabase.db");
            DataTable dt = new DataTable();
            using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + DBpath + ";Version=3;"))
            {
                conn.Open();
                SQLiteCommand comm = new SQLiteCommand("SELECT * FROM Receptionist", conn);
                SQLiteDataReader reader = comm.ExecuteReader();
                dt.Load(reader);
                conn.Close();
            }
            return dt;
        }

                [WebMethod]

        public DataTable GetAllRoom()
        {

            List<Client> listClients = new List<Client>();
            string DBpath = Server.MapPath("database/marseloDatabase.db");
            DataTable dt = new DataTable();
            using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + DBpath + ";Version=3;"))
            {
                conn.Open();
                SQLiteCommand comm = new SQLiteCommand("SELECT * FROM Room", conn);
                SQLiteDataReader reader = comm.ExecuteReader();
                dt.Load(reader);
                conn.Close();
            }
            return dt;
        }
    }
}
