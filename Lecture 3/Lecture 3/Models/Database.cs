using Lecture_3.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace Lecture_3.Models
{
    public class Database
    {
        public Products Products { get; set; }
       
        public Database() {
            string connString = @"Server=DESKTOP-3LSC78C\SQLEXPRESS;Database=Products;Integrated Security=true";
            SqlConnection conn = new SqlConnection(connString);
            Products = new Products(conn);
            
        }
    }
}