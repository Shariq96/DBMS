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
    public class TeacherrModel
    {
        [Display(Name ="NAME")]
        public string username { get; set; }
        [Display(Name = "FATHER NAME")]
        public string f_name { get; set; }
        [Display(Name = "PASS")]
        public string pass { get; set; }

        [Display(Name = "CONTACT")]
        public string contact { get; set; }
        [Display(Name = "Teacher ID")]
        public int t_id { get; set; }


        public bool view()
        {
            SqlCommand sq_com = new SqlCommand("get_tech", Connections.GetConnection());
            sq_com.CommandType = CommandType.StoredProcedure;

            sq_com.Parameters.AddWithValue("@t_id", (HttpContext.Current.Session["user"]));
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
        public void update_data()

        {

            SqlCommand sq_com = new SqlCommand("get_teach", Connections.GetConnection());
            sq_com.CommandType = CommandType.StoredProcedure;
            sq_com.Parameters.AddWithValue("@t_id", (HttpContext.Current.Session["user"]));
            sq_com.Parameters.AddWithValue("@t_name", username);
            sq_com.Parameters.AddWithValue("@pass", pass);
            sq_com.Parameters.AddWithValue("@t_fname", f_name);
            sq_com.Parameters.AddWithValue("@t_contact", contact);
            sq_com.ExecuteNonQuery();

        }
    
    }
}