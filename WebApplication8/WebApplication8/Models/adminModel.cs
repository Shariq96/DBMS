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
    public class adminModel
    {
        [Display(Name ="USERNAME")]
        public string username { get; set; }

        [Display(Name = "PASSWORD")]
        [DataType(DataType.Password)]
        public string password { get; set; }
        public void addadmin()
        {
            SqlCommand sq_com = new SqlCommand("addadmin", Connections.GetConnection());
            sq_com.CommandType = CommandType.StoredProcedure;
            sq_com.Parameters.AddWithValue("@username", username);
            sq_com.Parameters.AddWithValue(@"pass", password);
            sq_com.Parameters.AddWithValue("@type", "admin");
            sq_com.ExecuteNonQuery();
        }
    }
}