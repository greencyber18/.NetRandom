using Lecture_3.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Lecture_3.Models.Tables
{
    public class Products
    {
        SqlConnection conn;
        public Products(SqlConnection conn) {
            this.conn = conn;
        }

      
        public void Add(Entity.Products p) {
            string query = String.Format("Insert into Product values ('{0}','{1}','{2}' ,'{3}' )", p.Name, p.Quantity, p.Price, p.Description);
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            int r = cmd.ExecuteNonQuery();
            conn.Close();
        }
        public Entity.Products Get(int ID) {
            return null;
        }

       /*
       public Products GetID(int ID)
        {
            string query = "select *  from Product where ID=" + ID;
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            Products p = new Products();
            if (reader.Read())
            {


                p.ID = reader.GetInt32(reader.GetOrdinal("ID"));
              

            }
            conn.Close();
            return p;
        } */

        public List<Entity.Products> GetAll() {
            string query = "select * from Product";
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Entity.Products> product = new List<Entity.Products>();
            while (reader.Read())
            {
                Entity.Products p = new Entity.Products()
                {
                    ID = reader.GetInt32(reader.GetOrdinal("ID")),
                    Name = reader.GetString(reader.GetOrdinal("Name")),
                    Quantity = reader.GetInt32(reader.GetOrdinal("Quantity")),
                    Price = reader.GetInt32(reader.GetOrdinal("Price")),
                    Description =reader.GetString(reader.GetOrdinal("Description"))
                };
                product.Add(p);
            }
            conn.Close();
            return product;
        }



        public void delete(int ID)
        {
            string query = "Delete from Product where Id=" + ID;
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}