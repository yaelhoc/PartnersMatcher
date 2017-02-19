using Assignment_4.Controller;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_4.Model
{
    public class MyModel : IModel
    {
        private IController _c;
        private SqlConnection con = new SqlConnection();

        //consturctor
        public MyModel(IController control)
        {
            _c = control;
            //con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Integrated Security=true;AttachDbFilename=c:\db\Database1.mdf;";
            con.ConnectionString = @"Data Source=YAEL\SQLEXPRESS;Initial Catalog=proj;Integrated Security=True;Connect Timeout=15;";
        }

        // check if the user exist in the system when trying to login
        public bool Login(string username, string password, string status)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SELECT Count(*) FROM Users WHERE username='" + username + "' and password='" + password + "'and LoginStatus like '%" + status + "%'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
                return true;
            else
                return false;
        }

        //function which add new user profile to the system
        public bool Register(string username, string password, string firstName, string lastName, string email, string telephone, string sex, string age, string lastLogin, string lastStatus, string familystat, bool smoking, bool friendly, bool animal)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Users (username,password,firstName,lastName,EmailAdress,telephone,sex,age,lastLogin,loginStatus,familyStatus,issmoking,isfriendly,isanimalLover) VALUES ('" + username + "','" + password + "','" + firstName + "','" + lastName + "','" + email + "','" + telephone + "','" + sex + "','" + age + "','','" +lastStatus+"','" + familystat + "','" + smoking + "','" + friendly + "','" + animal + "')", con);
            try
            {
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch
            {
                con.Close();
                return false;
            }
        }

        //function which search ads by filters in the system
        public DataTable Search(string query)
        {
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt==null)
                return null;
            else
                return dt; 
        }

        // function which add new ad to the system
        public bool publishAd(string query)
        {
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = query;
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return true;
        }
        // function which check if the user already saved in the system
        public bool alreadyRegistered(string _user)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SELECT Count(*) FROM UserPreferences WHERE userName='" + _user+"' ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
                return true;
            else
                return false;
        }

        //function which check if the user exist in the database by email adress and his authority is roomate 
        public bool UserExist(string mail)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SELECT Count(*) FROM Users WHERE EmailAdress='" + mail + "'and LoginStatus in ('שותף במודעה')", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
                return true;
            else
                return false;
        }

        //function which check if the username has authorization of partner or owner
        public bool checkOwnership(string username)
        {
            string query = string.Format("SELECT Count(*) FROM Users WHERE username='" + username + "' " + " " + "and (LoginStatus  like '%בעל מודעה%' or LoginStatus like '%שותף במודעה%')");
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
                return true;
            else
                return false;
        }

        // function which add the user preferences to the system in registrations
        public void addPrefenencesByDomain(string query)
        {
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = query;
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        // function which initialize the main window
        public DataTable Initiliaze()
        {
            SqlDataAdapter sda = new SqlDataAdapter("SELECT adNumber,publishDate,location,domain FROM Ads Where adStatus='active'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }

        // function which update the last login date when the user entered the system
        public void updateLastLogin(string user)
        {
            SqlCommand sUpdate = new SqlCommand();
            DateTime date = DateTime.Now;
            sUpdate.CommandText = string.Format("Update Users set LastLogin= " + "'" + date + "'" + " where username=" + "'" + user + "'");
            sUpdate.Connection = con;
            con.Open();
            sUpdate.ExecuteNonQuery();
            con.Close();
        }

        // function which count total number of ads in the system
        public int countAds()
        {
            SqlDataAdapter sda = new SqlDataAdapter("SELECT Count(*) FROM Ads", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return (Convert.ToInt32(dt.Rows[0][0].ToString()));
        }

        // function which save the ad number which related to the user in the system
        public void insertToUserAds(string qur)
        {
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = qur;
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery(); 
            con.Close();
        }

    }
}
