using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace WebApplication8.Models
{
    public class teacherModel
    {
        [Display(Name = "ID")]
        [Required]
        public int id { get; set; }

        [Display(Name = "User Name")]
        [Required]
        public string username { get; set; }
        [Display(Name = "EMAIL ID")]
        [Required]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }
        [Display(Name = "Password")]
        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }
        [Display(Name = "FATHER NAME")]
        [Required]
        public string f_name { get; set; }
        
       
        [Display(Name = "CONTACT#")]
        [Required]
        public string contact { get; set; }
        




        public void insert_teach()

        {

            SqlCommand sq_com = new SqlCommand("add_tech", Connections.GetConnection());
            sq_com.CommandType = CommandType.StoredProcedure;
            sq_com.Parameters.AddWithValue("@t_name", username);
            sq_com.Parameters.AddWithValue("@pass", password);
            sq_com.Parameters.AddWithValue("@t_fname", f_name);
            sq_com.Parameters.AddWithValue("@t_contact", contact);
            sq_com.Parameters.AddWithValue("@email", email);
            sq_com.ExecuteNonQuery();

        }
        public void update_data()

        {

            SqlCommand sq_com = new SqlCommand("update_tech", Connections.GetConnection());
            sq_com.CommandType = CommandType.StoredProcedure;
            sq_com.Parameters.AddWithValue("@t_id", id);
            sq_com.Parameters.AddWithValue("@t_name", username);
            sq_com.Parameters.AddWithValue("@pass", password);
            sq_com.Parameters.AddWithValue("@t_fname", f_name);
            sq_com.Parameters.AddWithValue("@t_contact", contact);
           
          

            sq_com.ExecuteNonQuery();

        }
        public void del_data()
        {
            SqlCommand sq_com = new SqlCommand("del_tech", Connections.GetConnection());
            sq_com.CommandType = CommandType.StoredProcedure;
            sq_com.Parameters.AddWithValue("@t_id", id);
            sq_com.ExecuteNonQuery();
        }
        public bool get_data()

        {

            SqlCommand sq_com = new SqlCommand("get_tech", Connections.GetConnection());
            sq_com.CommandType = CommandType.StoredProcedure;

            sq_com.Parameters.AddWithValue("@t_id", id);
            SqlDataAdapter sda = new SqlDataAdapter(sq_com);

            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                username = dt.Rows[0][0].ToString();
                f_name = dt.Rows[0][1].ToString();
                contact = dt.Rows[0][2].ToString();
                return true;
            }
            return false;

        }
    }
}