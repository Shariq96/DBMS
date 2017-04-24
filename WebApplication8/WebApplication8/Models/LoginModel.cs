using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication8.Models
{
    public class LoginModel

    {
        [Display(Name = "User Name")]
        [Required]
        public string userName { get; set; }
        [Display(Name = "Password")]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }



        public object log()
        {
            SqlCommand sq_com = new SqlCommand("loginn", Connections.GetConnection());
            sq_com.CommandType = CommandType.StoredProcedure;
            sq_com.Parameters.AddWithValue("@name", userName);
            SqlDataAdapter sda = new SqlDataAdapter(sq_com);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
                if (dt.Rows[0][1].Equals(Password))
                {
                    HttpContext.Current.Session["user"] = dt.Rows[0][0].ToString();
                    return HttpContext.Current.Session["type"] = dt.Rows[0][2].ToString();
                   

                }
            return false;
        }
        //public bool AdminLogin()
        //{


        //    SqlCommand sq_com = new SqlCommand("adminlgn", Connections.GetConnection());
        //    sq_com.CommandType = CommandType.StoredProcedure;



        //    sq_com.Parameters.AddWithValue("@username", userName);
        //    SqlDataAdapter sda = new SqlDataAdapter(sq_com);

        //    DataTable dt = new DataTable();
        //    sda.Fill(dt);
        //    if (dt.Rows.Count > 0)
        //        if (dt.Rows[0][0].Equals(Password))
        //        {
        //            return true;
        //        }
        //    return false;
        //}
        //public bool StudentLogin()
        //{
        //    SqlCommand sq_com = new SqlCommand("stdlgn", Connections.GetConnection());
        //    sq_com.CommandType = CommandType.StoredProcedure;
        //    sq_com.Parameters.AddWithValue("@std_name", userName);
        //    SqlDataAdapter sda = new SqlDataAdapter(sq_com);
        //    DataTable dt = new DataTable();
        //    sda.Fill(dt);
        //    if (dt.Rows.Count > 0)
        //        if (dt.Rows[0][0].Equals(Password))
        //        {

        //            HttpContext.Current.Session["user"] = dt.Rows[0][1].ToString();
        //            return true;
        //        }
        //    return false;
        //}
        //public bool TeacherLogin()
        //{
        //    SqlCommand sq_com = new SqlCommand("tlgn", Connections.GetConnection());
        //    sq_com.CommandType = CommandType.StoredProcedure;
        //    sq_com.Parameters.AddWithValue("@t_name", userName);
        //    SqlDataAdapter sda = new SqlDataAdapter(sq_com);
        //    DataTable dt = new DataTable();
        //    sda.Fill(dt);
        //    if (dt.Rows.Count > 0)
        //        if (dt.Rows[0][0].Equals(Password))
        //        {

        //            HttpContext.Current.Session["user"] = dt.Rows[0][1].ToString();
        //            return true;
        //        }
        //    return false;
        //}

        }

}