using WebApplication8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication8.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        [HttpGet]
        public ActionResult Login()
        {
           
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel lm)
        {
            object a = (lm.log());
            if (a.ToString()== "Student")
            {
                Session["authenticateds"] = "true";
                Session["username"] = lm.userName;
                Session["type"] = "Student";
                       return RedirectToAction("stdpanel", "Student");
            }
            else if (a.ToString() == "admin")
            {
                Session["authenticateda"] = "true";
                Session["username"] = lm.userName;
                Session["type"] = "Admin";
                return RedirectToAction("add", "adduser");
            }
            else if (a.ToString() == "Teacher")
            {
                Session["authenticatedt"] = "true";
                Session["username"] = lm.userName;
                Session["type"] = "Teacher";
                return RedirectToAction("tpannel", "Teacher");
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
            //switch (userType)
            //{
            //    case "Admin":
            //        if (lm.AdminLogin())
            //        {
            //            Session["authenticateda"] = "true";
            //            Session["username"] = lm.userName;
            //            Session["userType"] = userType;
            //            return RedirectToAction("add","adduser");
            //        }
            //        else
            //            Session["authenticateda"] = "false";
            //        return RedirectToAction("Login");

            //    case "Student":
            //        if (lm.StudentLogin())
            //        {
            //            Session["authenticateds"] = "true";
            //            Session["username"] = lm.userName;
            //            Session["userType"] = userType;

            //            return RedirectToAction("stdpanel", "Student");
            //        }
            //        else
            //            Session["authentic+ated"] = "false";
            //        return RedirectToAction("Login");

            //    case "Teacher":

            //        if (lm.TeacherLogin())
            //        {
            //            
            //            return RedirectToAction("tpannel","Teacher");
            //        }
            //        else
            //            Session["authenticated"] = "false";
            //        return RedirectToAction("Login");

            //}

            //return RedirectToAction("Login", "Login");

        }
        public ActionResult logout()
        {
            Session["authenticateda"] = "false";
                Session["authenticatedt"] = "false";
                Session["authenticateds"] = "false";
            return RedirectToAction("Login", "Login");
        }
    }
}