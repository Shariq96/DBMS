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
    public class reportModel
    {
        [Display(Name = "STUDENT ID")]
        public int std_id { get; set; }

        [Display(Name = "STUDENT NAME")]
        public string std_name { get; set; }

        [Display(Name = "FATHER NAME")]
        public string std_fname { get; set; }

        [Display(Name = "GENDER")]
        public string gender { get; set; }

        [Display(Name = "DOB")]
        public string std_dob { get; set; }

        [Display(Name = "ADDRESS")]
        public string addr { get; set; }

        [Display(Name = "ADDRESS TYPE")]
        public string addr_type { get; set; }

        [Display(Name = "STUDENT CONTACT")]
        public string std_contact { get; set; }

        public static List<reportModel> get_report_data()
        {
            List<reportModel> rm_list = new List<reportModel>();

            SqlCommand sc = new SqlCommand("showallstd", Connections.GetConnection());
            sc.CommandType = CommandType.StoredProcedure;

            SqlDataReader sdr = sc.ExecuteReader();

            while (sdr.Read())
            {
                reportModel rm = new reportModel();
                rm.std_id = Convert.ToInt32(sdr["std_id"]);
                rm.std_name = sdr["std_name"].ToString();
                rm.std_fname = sdr["std_fname"].ToString();
                rm.gender = sdr["gender"].ToString();
                rm.std_dob = sdr["std_dob"].ToString();
                rm.std_contact = sdr["std_contact"].ToString();
                rm.addr_type = sdr["addr_type"].ToString();
                rm.addr = sdr["addr"].ToString();

                rm_list.Add(rm);
            }

            sdr.Close();
            return (rm_list);
        }
    }
}