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
    public class ccra
    {
        [Display(Name ="CLASS ID")]
        public int class_id { get; set; }

        [Display(Name = "STUDENT ID")]
        public int std_id { get; set; }

        [Display(Name = "NAME")]
        public string name { get; set; }

        [Display(Name = "ATTENDANCE DATE")]
        public string att_date { get; set; }

        [Display(Name = "ATTENDANCE STATUS")]
        public string att_status { get; set; }

        [Display(Name = "TEACHER ID")]
        public int t_id { get; set; }

        [Display(Name = "COURSE ID")]
        public int course_id { get; set; }


        [Display(Name = "COURSE NAME")]
        public string course_name { get; set; }

        [Display(Name = "COURSE CRH")]
        public int course_crh { get; set; }

        [Display(Name = "EXAM DATE")]
        public string date_exam { get; set; }

        [Display(Name = "REFISTRATION DATE")]
        public string reg_date { get; set; }


        [Display(Name = "EXAM ID")]
        public int exam_id { get; set; }

        [Display(Name = "EXAM TITLE")]
        public string exam_title { get; set; }

        [Display(Name = "MAX MARKS")]
        public int max_marks { get; set; }

        [Display(Name = "MIN MARKS")]
        public int min_marks { get; set; }


        [Display(Name = "MARKS OBTAINED")]
        public int marks_obt { get; set; }

        [Display(Name = "ATT DATE")]
        public DateTime att { get; set; }


        public void add_cr()
        {
            SqlCommand sq_com = new SqlCommand("add_course", Connections.GetConnection());
            sq_com.CommandType = CommandType.StoredProcedure;
            sq_com.Parameters.AddWithValue("@course_name", course_name);
            sq_com.Parameters.AddWithValue("@course_crh", course_crh);
            sq_com.ExecuteNonQuery();
        }
        public void add_class()
        {
            SqlCommand sq_com = new SqlCommand("add_class", Connections.GetConnection());
            sq_com.CommandType = CommandType.StoredProcedure;
            sq_com.Parameters.AddWithValue("@course_id", course_id);
            sq_com.Parameters.AddWithValue("@t_id", t_id);
            sq_com.ExecuteNonQuery();
        }
        public void add_stdclass(string date)
        {
            SqlCommand sq_com = new SqlCommand("add_stdclass", Connections.GetConnection());
            sq_com.CommandType = CommandType.StoredProcedure;
            sq_com.Parameters.AddWithValue("@class_id", class_id);
            sq_com.Parameters.AddWithValue("@std_id", std_id);
            sq_com.Parameters.AddWithValue("@reg_date", date);
            sq_com.ExecuteNonQuery();
        }
        public void addexam(string date)
        {
            SqlCommand sq_com = new SqlCommand("add_classexam", Connections.GetConnection());
            sq_com.CommandType = CommandType.StoredProcedure;
            sq_com.Parameters.AddWithValue("@class_id", class_id);
            sq_com.Parameters.AddWithValue("@exam_id", exam_id);
            sq_com.Parameters.AddWithValue("@exam_date", date);
            sq_com.ExecuteNonQuery();
        }
        
        public void addresult(int class_id, int exam_id, int std_id, int marks_obt)
        {
            SqlCommand sq_com = new SqlCommand("examreslt", Connections.GetConnection());
            sq_com.CommandType = CommandType.StoredProcedure;
            sq_com.Parameters.AddWithValue("@class_id", class_id);
            sq_com.Parameters.AddWithValue("@exam_id", exam_id);
            sq_com.Parameters.AddWithValue("@std_id", std_id);
            sq_com.Parameters.AddWithValue("@marks_obt", marks_obt);
            sq_com.ExecuteNonQuery();
        }
        public void addresultt()
        {
            SqlCommand sq_com = new SqlCommand("examreslt", Connections.GetConnection());
            sq_com.CommandType = CommandType.StoredProcedure;
            sq_com.Parameters.AddWithValue("@class_id", class_id);
            sq_com.Parameters.AddWithValue("@exam_id", exam_id);
            sq_com.Parameters.AddWithValue("@std_id", std_id);
            sq_com.Parameters.AddWithValue("@marks_obt", marks_obt);
            sq_com.ExecuteNonQuery();
        }
        public void attt()
        {
            SqlCommand sq_com = new SqlCommand("attend", Connections.GetConnection());
            sq_com.CommandType = CommandType.StoredProcedure;
            sq_com.Parameters.AddWithValue("@class_id", class_id);
            sq_com.Parameters.AddWithValue("@std_id", std_id);
            sq_com.Parameters.AddWithValue("@att_date", System.DateTime.Now);
            sq_com.Parameters.AddWithValue("@att_status", att_status);
            sq_com.ExecuteNonQuery();
        }

        public void update_result()

        {

            SqlCommand sq_com = new SqlCommand("upd_result", Connections.GetConnection());
            sq_com.CommandType = CommandType.StoredProcedure;
            sq_com.Parameters.AddWithValue("@std_id", std_id);
            sq_com.Parameters.AddWithValue("@class_id", class_id);
            sq_com.Parameters.AddWithValue("@marks_obt", marks_obt);
            sq_com.ExecuteNonQuery();

        }
    }
}