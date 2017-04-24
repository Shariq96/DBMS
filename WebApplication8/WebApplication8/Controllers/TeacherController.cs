using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication8.Models;
using System.Web.Mvc;

namespace WebApplication8.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult tpannel()
        {
            if (Session["type"] != null && (string)Session["type"] != "Teacher")
            {
                Session.RemoveAll();
                return RedirectToAction("Login", "Login");
            }

            if (Convert.ToString(Session["authenticatedt"]) == "true")
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
        public ActionResult stdview(TeacherrModel sm)
        {
            if (Convert.ToString(Session["authenticatedt"]) == "true")
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
        [HttpGet]
        public ActionResult update()
        {
            if (Convert.ToString(Session["authenticatedt"]) == "true")
            {
                TeacherrModel sm = new TeacherrModel();

                return View(sm);
            }
            else
            {

                return RedirectToAction("Login", "Login");
            }
        }
        [HttpPost]
        public ActionResult update(TeacherrModel sm)
        {
            if (Convert.ToString(Session["authenticatedt"]) == "true")
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
        public ActionResult show_result()
        {
            if (Convert.ToString(Session["authenticatedt"]) == "true")
            {
                return View();
            }
            else
            {

                return RedirectToAction("Login", "Login");
            }
        }
        resultEntity db = new resultEntity();
        [HttpPost]
        public ActionResult show_result(resultView d)
        {

            // var b= (from a in db.StudentResults where a.std_id == d.ccra.std_id select a);
            d.ccr = db.StudentResults.Where(t => t.std_id == d.ccra.std_id).ToList();

            return View(d);
        }
        [HttpGet]
        public ActionResult add_result()
        {
            if (Convert.ToString(Session["authenticatedt"]) == "true")
            {
                return View();
            }
            else
            {

                return RedirectToAction("Login", "Login");
            }
           
        }
        [HttpPost]
        public ActionResult add_result(ccra c)
        {
            c.addresultt();
            return View();
        }
        [HttpGet]
        public ActionResult upd_result()
        {
            if (Convert.ToString(Session["authenticatedt"]) == "true")
            {
               
                return View();
            }
            else
            {

                return RedirectToAction("Login", "Login");
            }
           
        }
        [HttpPost]
        public ActionResult upd_result(ccra c)
        {
            c.update_result();
            return View();
        }
    }
}