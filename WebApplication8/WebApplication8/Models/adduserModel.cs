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
    public class adduserModel
    {
        [Display(Name = "Class ID")]
        [Required]
        public int class_id { get; set; }
        [Display(Name = "EMAIL ID")]
        [Required]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

        [Display(Name = "ID")]
        [Required]
        public int id { get; set; }

        public int Mark { get; set; }
        [Display(Name = "User Name")]
        [Required]
        public string username { get; set; }
        [Display(Name = "Password")]
        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }
        [Display(Name = "FATHER NAME")]
        [Required]
        public string f_name { get; set; }
        [Display(Name = "DATE OF BIRTH")]
        [Required]
        public string dob { get; set; }
        [Display(Name = "GENDER")]
        [Required]
        public string gender { get; set; }
        [Display(Name = "ADDRESS TYPE")]
        [Required]
        public string addr1 { get; set; }
        [Display(Name = "ADDRESS")]
        [Required]
        public string addr { get; set; }
        [Display(Name = "YOUR CONTACT")]
        [Required]
        public string contact { get; set; }
        [Display(Name = "GARDIUN CONTACT")]
        [Required]
        public string fcontact { get; set; }
        [Display(Name = "Curse ID")]
        [Required]
        public string course_id { get; set; }

        public void del_data()
        {
            SqlCommand sq_com = new SqlCommand("del_std", Connections.GetConnection());
            sq_com.CommandType = CommandType.StoredProcedure;
            sq_com.Parameters.AddWithValue("@std_id", id);
            sq_com.ExecuteNonQuery();
           
        }

        public void insert_data(string userType,string date)

      {

            SqlCommand sq_com = new SqlCommand("add_user", Connections.GetConnection());
            sq_com.CommandType = CommandType.StoredProcedure;

            sq_com.Parameters.AddWithValue("@std_name", username);
            sq_com.Parameters.AddWithValue("@password", password);
            sq_com.Parameters.AddWithValue("@std_fname", f_name);
            sq_com.Parameters.AddWithValue("@std_dob", date);
            sq_com.Parameters.AddWithValue("@gender", userType);
            sq_com.Parameters.AddWithValue("@std_contact", contact);
            sq_com.Parameters.AddWithValue("@std_fcontact", fcontact);
            sq_com.Parameters.AddWithValue("@addr_type", addr1);
            sq_com.Parameters.AddWithValue("@addr", addr);
            sq_com.Parameters.AddWithValue("@email", email);


            sq_com.ExecuteNonQuery();
    
            
        }
        public void update_data(string userType, string date)

        {

            SqlCommand sq_com = new SqlCommand("update_std", Connections.GetConnection());
            sq_com.CommandType = CommandType.StoredProcedure;
            sq_com.Parameters.AddWithValue("@std_id", id);
            sq_com.Parameters.AddWithValue("@std_name", username);
            sq_com.Parameters.AddWithValue("@password", password);
            sq_com.Parameters.AddWithValue("@std_fname", f_name);
            sq_com.Parameters.AddWithValue("@std_dob", date);
            sq_com.Parameters.AddWithValue("@gender", userType);
            sq_com.Parameters.AddWithValue("@std_contact", contact);
            sq_com.Parameters.AddWithValue("@std_fcontact", fcontact);
            sq_com.Parameters.AddWithValue("@addr_type", addr1);
            sq_com.Parameters.AddWithValue("@addr", addr);

            sq_com.ExecuteNonQuery();

        }
        public void update_datat()

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
        public bool get_data()
        {

            SqlCommand sq_com = new SqlCommand("get_std", Connections.GetConnection());
            sq_com.CommandType = CommandType.StoredProcedure;

            sq_com.Parameters.AddWithValue("@std_id", id);
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
        public List<adduserModel> getid()
        {
            List<adduserModel> gt = new List<adduserModel>();
            SqlCommand sc = new SqlCommand("getid", Connections.GetConnection());
            sc.CommandType = CommandType.StoredProcedure;

            SqlDataReader sdr = sc.ExecuteReader();
            while(sdr.Read())
            {
                adduserModel asd = new adduserModel();
                asd.id = Convert.ToInt32(sdr["class_id"]);
                gt.Add(asd);
                
            }
            sdr.Close();
            return (gt);

        }
        public List<adduserModel> getstd(int id)
        {
            List<adduserModel> gt = new List<adduserModel>();
            SqlCommand sc = new SqlCommand("stdbyclid", Connections.GetConnection());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@class_id", id);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                adduserModel asd = new adduserModel();
                asd.id = Convert.ToInt32(sdr["std_id"]);
                asd.username = (string)sdr["std_name"];
                asd.course_id = (sdr["course_id"]).ToString();
                gt.Add(asd);

            }
            sdr.Close();
            return (gt);

        }
        public void all_std()
        {
            SqlCommand sq_com = new SqlCommand("showallstd", Connections.GetConnection());
            sq_com.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter sda = new SqlDataAdapter(sq_com);
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {

                id = int.Parse(dr[0].ToString());
                username = dr[1].ToString();
                f_name = dr[2].ToString();
                gender = dr[3].ToString();
                dob = dr[2].ToString();
                contact = dr[4].ToString();
                fcontact = dr[5].ToString();
                addr1 = dr[6].ToString();
                addr = dr[7].ToString();


            }
        }

            public List<adduserModel> get_all_std()
        {
            List<adduserModel> std_list = new List<adduserModel>();

            SqlCommand sc = new SqlCommand("showallstd", Connections.GetConnection());
            sc.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter sda = new SqlDataAdapter(sc);

            DataTable dt = new DataTable();
            sda.Fill(dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                adduserModel sm = new adduserModel();
                sm.id= Convert.ToInt32(dt.Rows[i][0]);
                sm.username = dt.Rows[i][1].ToString();
                sm.f_name = dt.Rows[i][2].ToString();
                sm.gender = dt.Rows[i][3].ToString();
                sm.dob = dt.Rows[i][4].ToString();
                sm.addr1 = dt.Rows[i][5].ToString();
                sm.addr = dt.Rows[i][6].ToString();
                sm.contact= dt.Rows[i][7].ToString();


                std_list.Add(sm);
            }
            return (std_list);
        }
           
    }
    }
