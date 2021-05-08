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
            using (MD5 md5Hash = MD5.Create())
            {
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(pass));
                pass = BitConverter.ToString(data).Replace("-", string.Empty);
            }
            SQLiteConnection conn = new SQLiteConnection("Data Source=" + DBpath + ";Version=3;");

            conn.Open();
            using (conn)
            {
                SQLiteCommand comm = new SQLiteCommand("SELECT * FROM Login WHERE `email` = @email AND `password` = @pass", conn);
                comm.Parameters.AddWithValue("@email", Convert.ToString(user));
                comm.Parameters.AddWithValue("@pass", Convert.ToString(pass));
                SQLiteDataReader reader = comm.ExecuteReader();
                dt.Load(reader);
                reader.Close();
            }
            return dt;
        }

        [WebMethod]
        public void AddClient(string name, string lastname, int cardnumber, int phone, string email , string password)
        {
            Client client = new Client(name,lastname,cardnumber,phone,email,password);
            string DBpath = Server.MapPath("database/marseloDatabase.db");
            using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + DBpath + ";Version=3;"))
            {
                conn.Open();
                SQLiteCommand comm = new SQLiteCommand("INSERT INTO Client (Name, Lastname, CardNumber, Phone,Email,Password) VALUES ("+ client +" )", conn);

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
