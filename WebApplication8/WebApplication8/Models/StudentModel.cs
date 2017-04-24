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
    public class StudentModel
    {
        [Display(Name = "NAME")]
        public string username { get; set; }
        [Display(Name = "FATHER NAME")]
        public string f_name { get; set; }
        [Display(Name = "PASSWORD")]
        public string pass { get; set; }
        [Display(Name = "GENDER")]
        public string gender { get; set; }
        [Display(Name = "ADDRESS")]
        public string addr { get; set; }
        [Display(Name = "ADDRESS TYPE")]
        public string addr1 { get; set; }
        [Display(Name = "DOB")]
        public string dob { get; set; }
        [Display(Name = "CONTACT")]
        public string contact { get; set; }
        [Display(Name = "FATHER CONTACT")]
        public string fcontact { get; set; }
        [Display(Name = "Teacher ID")]
        public int t_id { get; set; }
        [Display(Name = "Course ID")]
        public int course_id { get; set; }

        [Display(Name = "Course Name")]
        public string course_name { get; set; }
        [Display(Name = "Course CRH")]
        public int course_crh { get; set; }
        [Display(Name = "CLASS ID")]
        public int class_id { get; set; }


        public bool view()
        {
            SqlCommand sq_com = new SqlCommand("get_std", Connections.GetConnection());
            sq_com.CommandType = CommandType.StoredProcedure;

            sq_com.Parameters.AddWithValue("@std_id",(HttpContext.Current.Session["user"]));
            SqlDataAdapter sda = new SqlDataAdapter(sq_com);

            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                username = dt.Rows[0][0].ToString();
                f_name = dt.Rows[0][1].ToString();
                gender = dt.Rows[0][3].ToString();
                dob = dt.Rows[0][2].ToString();
                contact = dt.Rows[0][4].ToString();
                fcontact = dt.Rows[0][5].ToString();
                addr1 = dt.Rows[0][6].ToString();
                addr = dt.Rows[0][7].ToString();
                return true;
            }
            return false;
        }
        public void update_data()

        {

            SqlCommand sq_com = new SqlCommand("update_std", Connections.GetConnection());
            sq_com.CommandType = CommandType.StoredProcedure;
            sq_com.Parameters.AddWithValue("@std_id", (HttpContext.Current.Session["user"]));
            sq_com.Parameters.AddWithValue("@std_name", username);
            sq_com.Parameters.AddWithValue("@password", pass);
            sq_com.Parameters.AddWithValue("@std_fname", f_name);
            sq_com.Parameters.AddWithValue("@std_dob", dob);
            sq_com.Parameters.AddWithValue("@gender", gender);
            sq_com.Parameters.AddWithValue("@std_contact", contact);
            sq_com.Parameters.AddWithValue("@std_fcontact", fcontact);
            sq_com.Parameters.AddWithValue("@addr_type", addr1);
            sq_com.Parameters.AddWithValue("@addr", addr);

            sq_com.ExecuteNonQuery();

        }
    }
}