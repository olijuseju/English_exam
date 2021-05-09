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
        public bool ClientExists(string name, string lastname, int cardnumber, int phone, string email, string password, int Rid)
        {
            DataTable dt = GetAllClients();
            foreach (DataRow dr in dt.Rows)
            {
                if (dr[1].ToString().Equals(name) && dr[2].ToString().Equals(lastname) && dr[3].ToString().Equals(Convert.ToString(cardnumber))
                    && dr[4].ToString().Equals(Convert.ToString(phone)) && dr[5].ToString().Equals(password) && Convert.ToInt32(dr[6]) == Rid)
                {
                    return true;
                }

            }

            return false;

        }

        [WebMethod]
        public int GetIdClientExists(string name, string lastname, int cardnumber, int phone, string password, int Rid)
        {
            DataTable dt = GetAllClients();
            foreach (DataRow dr in dt.Rows)
            {
                if (dr[1].ToString().Equals(name) && dr[2].ToString().Equals(lastname) && dr[3].ToString().Equals(Convert.ToString(cardnumber))
                    && dr[4].ToString().Equals(Convert.ToString(phone)) && dr[5].ToString().Equals(password) && Convert.ToInt32(dr[6])==Rid)
                {
                    return Convert.ToInt32(dr[0]);
                }

            }

            return -1;

        }


        [WebMethod]
        public void AddClient(string name, string lastname, int cardnumber, int phone, string password, int Rid, string email)
        {
            Client client = new Client(name,lastname,cardnumber,phone,password,Rid);
            string DBpath = Server.MapPath("database/marseloDatabase.db");
            using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + DBpath + ";Version=3;"))
            {
                conn.Open();
                SQLiteCommand comm = new SQLiteCommand("INSERT INTO Client (Name, Lastname, CardNumber, Phone, Password, RecepcionistId) VALUES ( '"+client.name +"' , '"+ client.lastName +"' , '" + client.cardNumer + "' , '" + client.phone +"' , '" + client.password + "' , '" + client.RecpcionistId + "'  )", conn);
                SQLiteDataAdapter da = new SQLiteDataAdapter();
                da.InsertCommand = comm;
                da.InsertCommand.ExecuteNonQuery();
                conn.Close();
            }
        }

        [WebMethod]
        public void RemoveClientbyId(int id)
        {
            string DBpath = Server.MapPath("database/marseloDatabase.db");
            using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + DBpath + ";Version=3;"))
            {
                conn.Open();
                SQLiteCommand comm = new SQLiteCommand("DELETE FROM Client WHERE id =" +  id, conn);
                SQLiteDataAdapter da = new SQLiteDataAdapter();
                da.InsertCommand = comm;
                da.InsertCommand.ExecuteNonQuery();
                conn.Close();
            }
        }

        [WebMethod]
        public void RemoveLoginbyId(int id)
        {
            string DBpath = Server.MapPath("database/marseloDatabase.db");
            using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + DBpath + ";Version=3;"))
            {
                conn.Open();
                SQLiteCommand comm = new SQLiteCommand("DELETE FROM Login WHERE id =" + id, conn);
                SQLiteDataAdapter da = new SQLiteDataAdapter();
                da.InsertCommand = comm;
                da.InsertCommand.ExecuteNonQuery();
                conn.Close();
            }
        }

        [WebMethod]
        public void AddLogin(string email, string password, string type, int userId)
        {
            Login login = new Login(email, password, type, userId);
            string DBpath = Server.MapPath("database/marseloDatabase.db");
            using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + DBpath + ";Version=3;"))
            {
                conn.Open();
                SQLiteCommand comm = new SQLiteCommand("INSERT INTO Login (Email, password, type,idUser) VALUES (  '" + login.email + "' , '" + login.password + "' , '" + login.type + "' , " + login.userId+ ")", conn);
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
        public DataTable GetLoginByClientId(int id)
        {

            List<Client> listClients = new List<Client>();
            string DBpath = Server.MapPath("database/marseloDatabase.db");
            DataTable dt = new DataTable();
            using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + DBpath + ";Version=3;"))
            {
                conn.Open();
                SQLiteCommand comm = new SQLiteCommand("SELECT * FROM Login WHERE `idUser` =" + id + " AND `type` = 'client'", conn);
                SQLiteDataReader reader = comm.ExecuteReader();
                dt.Load(reader);
                conn.Close();
            }
            return dt;
        }

        [WebMethod]
        public DataTable GetLoginByReceptionistId(int id)
        {

            List<Client> listClients = new List<Client>();
            string DBpath = Server.MapPath("database/marseloDatabase.db");
            DataTable dt = new DataTable();
            using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + DBpath + ";Version=3;"))
            {
                conn.Open();
                SQLiteCommand comm = new SQLiteCommand("SELECT * FROM Login WHERE `idUser` =" + id + " AND `type` = 'recepcionist'", conn);
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
        public DataTable GetReservationByReceptionistId(int Rid)
        {

            List<Client> listClients = new List<Client>();
            string DBpath = Server.MapPath("database/marseloDatabase.db");
            DataTable dt = new DataTable();
            using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + DBpath + ";Version=3;"))
            {
                conn.Open();
                SQLiteCommand comm = new SQLiteCommand("SELECT * FROM Reservation WHERE `RecepcionistId` =" + Rid, conn);
                SQLiteDataReader reader = comm.ExecuteReader();
                dt.Load(reader);
                conn.Close();
            }
            return dt;
        }

        [WebMethod]
        public DataTable GetClientByReceptionistId(int Rid)
        {

            List<Client> listClients = new List<Client>();
            string DBpath = Server.MapPath("database/marseloDatabase.db");
            DataTable dt = new DataTable();
            using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + DBpath + ";Version=3;"))
            {
                conn.Open();
                SQLiteCommand comm = new SQLiteCommand("SELECT * FROM Client WHERE `RecepcionistId` =" + Rid, conn);
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


        [WebMethod]
        public void UpdateClient(int id, string name, string lastname, int cardnumber, int phone, string password, string email)
        {
            string DBpath = Server.MapPath("database/marseloDatabase.db");
            using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + DBpath + ";Version=3;"))
            {
                conn.Open();
                SQLiteCommand comm = new SQLiteCommand("UPDATE Client SET name = '" + name + "'," + " lastname = '" + lastname + "'," + " cardnumber = " + cardnumber + ", " + " phone = " + phone + ", " + "password = '" + password + "'" + " WHERE id = " + id, conn);
                SQLiteDataAdapter da = new SQLiteDataAdapter();
                da.InsertCommand = comm;
                da.InsertCommand.ExecuteNonQuery();
                conn.Close();
            }
        }

        [WebMethod]
        public void UpdateReceptionist(int id, string name, string lastname, string password)
        {
            string DBpath = Server.MapPath("database/marseloDatabase.db");
            using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + DBpath + ";Version=3;"))
            {
                conn.Open();
                SQLiteCommand comm = new SQLiteCommand("UPDATE Receptionist SET name = '" + name + "'," + " lastname = '" + lastname + "'," + " password = '" + password + "'" + " WHERE id = " + id, conn);
                SQLiteDataAdapter da = new SQLiteDataAdapter();
                da.InsertCommand = comm;
                da.InsertCommand.ExecuteNonQuery();
                conn.Close();
            }
        }

        [WebMethod]
        public void UpdateLogin(int id, string email, string password)
        {
            string DBpath = Server.MapPath("database/marseloDatabase.db");
            using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + DBpath + ";Version=3;"))
            {
                conn.Open();
                SQLiteCommand comm = new SQLiteCommand("UPDATE Login SET email = '" + email + "'," + " password = '" + password + "' WHERE id = " + id, conn);
                SQLiteDataAdapter da = new SQLiteDataAdapter();
                da.InsertCommand = comm;
                da.InsertCommand.ExecuteNonQuery();
                conn.Close();
            }
        }

        [WebMethod]
        public void ChangePasswordLogin(int id, string password)
        {
            string DBpath = Server.MapPath("database/marseloDatabase.db");
            using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + DBpath + ";Version=3;"))
            {
                conn.Open();
                SQLiteCommand comm = new SQLiteCommand("UPDATE Login SET password = '" + password +"' WHERE id = " + id, conn);
                SQLiteDataAdapter da = new SQLiteDataAdapter();
                da.InsertCommand = comm;
                da.InsertCommand.ExecuteNonQuery();
                conn.Close();
            }
        }

        [WebMethod]
        public void ChangePasswordClient(int id, string password)
        {
            string DBpath = Server.MapPath("database/marseloDatabase.db");
            using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + DBpath + ";Version=3;"))
            {
                conn.Open();
                SQLiteCommand comm = new SQLiteCommand("UPDATE Client SET password = '" + password + "' WHERE id = " + id, conn);
                SQLiteDataAdapter da = new SQLiteDataAdapter();
                da.InsertCommand = comm;
                da.InsertCommand.ExecuteNonQuery();
                conn.Close();
            }
        }

        [WebMethod]
        public void ChangePasswordReceptionist(int id, string password)
        {
            string DBpath = Server.MapPath("database/marseloDatabase.db");
            using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + DBpath + ";Version=3;"))
            {
                conn.Open();
                SQLiteCommand comm = new SQLiteCommand("UPDATE Receptionist SET password = '" + password + "' WHERE id = " + id, conn);
                SQLiteDataAdapter da = new SQLiteDataAdapter();
                da.InsertCommand = comm;
                da.InsertCommand.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}
