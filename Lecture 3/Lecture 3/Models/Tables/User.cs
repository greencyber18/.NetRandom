using Lecture_3.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Lecture_3.Models.Tables
{
    public class User

    {
        SqlConnection conn;

        public User()
        {
        }

        public User(SqlConnection conn)
        {
            this.conn = conn;
        }

        public int UID { get; private set; }
        public string UName { get; private set; }
        public string UuName { get; private set; }

        public User Authenticate(string UuName, string Password)
        {
            User user = null;
            conn.Open();
            /*var md5 = new MD5CryptoServiceProvider();
            password = md5.ComputeHash(password);*/
            string query = String.Format("select * from Users where UuName='{0}' and Password='{1}'", UuName, Password);

            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                user = new User()
                {
                    UID = reader.GetInt32(reader.GetOrdinal("UID")),
                    UName = reader.GetString(reader.GetOrdinal("UName")),
                    UuName = reader.GetString(reader.GetOrdinal("UuName"))
                };
            }
            conn.Close();
            return user;
        }

    }


}