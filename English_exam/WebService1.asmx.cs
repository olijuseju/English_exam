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
            string DBpath = Server.MapPath("marseloDatabase.db");
            using (MD5 md5Hash = MD5.Create())
            {
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(pass));
                pass = BitConverter.ToString(data).Replace("-", string.Empty);
            }
            SQLiteConnection conn = new SQLiteConnection("Data Source=" + DBpath + ";Version=3;");

            conn.Open();
            using (conn)
            {
                SQLiteCommand comm = new SQLiteCommand("SELECT * FROM Login WHERE username ='" + user + "'", conn);
                SQLiteDataReader reader = comm.ExecuteReader();
                dt.Load(reader);
                reader.Close();
            }
            return dt;
        }


        [WebMethod]
        public DataTable GetAllClients()
        {
            string DBpath = Server.MapPath("database/marseloDatabase.db");
            DataTable dt = new DataTable();
            using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + DBpath + ";Version=3;"))
                {
                    conn.Open();
                    SQLiteCommand comm = new SQLiteCommand("SELECT * FROM client", conn);
                    SQLiteDataReader reader = comm.ExecuteReader();
                    dt.Load(reader);
                    conn.Close();
                }
            return dt;
        }

    }
}
