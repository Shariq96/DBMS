using System;
using WebApplication8.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace WebApplication8.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student

        public ActionResult stdpanel()
        {

            if (Session["type"] != null && (string)Session["type"] != "Student")
            {
                Session.RemoveAll();
                return RedirectToAction("Login", "Login");
            }
            if (Convert.ToString(Session["authenticateds"]) == "true")
            {
                var a = Session["user"];


                return View();
            }
            else
            {

                return RedirectToAction("Login", "Login");
            }

        }
        [HttpGet]
        public ActionResult stdview(StudentModel sm)
        {
            if (Convert.ToString(Session["authenticateds"]) == "true")
            {
                bool chk = (sm.view());

                if (chk == true)
                {
                    return View(sm);
                }
                else
                {
                    return View(sm);
                }
            }
            else
            {

                return RedirectToAction("Login", "Login");
            }
            
        }
        resultEntity db = new resultEntity();
        [HttpGet]
        public ActionResult show_result(resultView d)

        {
            if (Convert.ToString(Session["authenticateds"]) == "true")
            {
                var a = Session["user"];
                int b = Convert.ToInt32(a);
                return View(d.ccr = db.StudentResults.Where(t => t.std_id == b).ToList());
            }
            else
            {

                return RedirectToAction("Login", "Login");
            }
          
        }
        [HttpGet]
        public ActionResult update()
        {

            if (Convert.ToString(Session["authenticateds"]) == "true")
            {
                StudentModel sm = new StudentModel();

                return View(sm);
            }
            else
            {

                return RedirectToAction("Login", "Login");
            }
            
        }
        [HttpPost]
        public ActionResult update(StudentModel sm)
        {
            if (Convert.ToString(Session["authenticateds"]) == "true")
            {
                sm.update_data();
                return View();

            }
            else
            {

                return RedirectToAction("Login", "Login");
            }
             }

        [HttpGet]
        public ActionResult show_course(resultView d)

        {
            if (Convert.ToString(Session["authenticateds"]) == "true")
            {
                var a = Session["user"];
                int b = Convert.ToInt32(a);
                return View(d.ccr = db.StudentResults.Where(t => t.std_id == b).ToList());
            }
            else
            {

                return RedirectToAction("Login", "Login");
            }
            
        }
        [HttpGet]
        public ActionResult sattendance(resultView d)
        {
            if (Convert.ToString(Session["authenticateds"]) == "true")
            {
                var a = Session["user"];
                int b = Convert.ToInt32(a);
                return View(d.ccr = db.StudentResults.Where(t => t.std_id == b).ToList());
            }
            else
            {

                return RedirectToAction("Login", "Login");
            }
        }
        
    }
}