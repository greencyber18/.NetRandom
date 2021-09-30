using Lecture_3.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Lecture_3.Models.Tables
{
    public class Product
    {
        SqlConnection conn;
        public Product(SqlConnection conn) {
            this.conn = conn;
        }
        public void Add(Entity.Product p) {
            string query = String.Format("Insert into Product values ('{0}','{1}','{2}' ,'{3}' )", p.Name, p.Quantity, p.Price, p.Description);
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            int r = cmd.ExecuteNonQuery();
            conn.Close();
        }
        public Entity.Product Get(int id) {
            return null;
        }
        public List<Entity.Product> GetAll() {
            string query = "select * from Product";
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Entity.Product> products = new List<Entity.Product>();
            while (reader.Read())
            {
                Entity.Product p = new Entity.Product()
                {
                    ID = reader.GetInt32(reader.GetOrdinal("ID")),
                    Name = reader.GetString(reader.GetOrdinal("Name")),
                    Quantity = reader.GetInt32(reader.GetOrdinal("Quantity")),
                    Price = reader.GetInt32(reader.GetOrdinal("Price")),
                    Description =reader.GetString(reader.GetOrdinal("Description"))
                };
                products.Add(p);
            }
            conn.Close();
            return products;
        }
    }
}