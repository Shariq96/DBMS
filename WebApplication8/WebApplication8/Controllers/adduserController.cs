using WebApplication8.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.IO;
using Microsoft.Reporting.WebForms;
using System;
using WebApplication8.Controllers;

namespace WebApplication8.Controllers
{
   
    public class adduserController : Controller
    {
      
	
        adduserModel sm = new adduserModel();
       
        //del student
        [HttpGet]
        public ActionResult delstd()
        {
            if (Convert.ToString(Session["authenticateda"]) == "true")
            {
                return View();
            }
            else
            {
                
                return RedirectToAction("Login", "Login");
            }
        }
        [HttpPost]
        public ActionResult delstd(adduserModel au)
        {

           
                au.del_data();
                return View();
          
            
        }
        //del teacher
        [HttpGet]
        public ActionResult delteach()
        {
            if (Convert.ToString(Session["authenticateda"]) == "true")
            {
                return View();
            }
            else
            {

                return RedirectToAction("Login", "Login");
            }
        }
        [HttpPost]
        public ActionResult delteach(teacherModel tm)
        {


            tm.del_data();
            return View();
        }

        //add admin
        [HttpGet]
        public ActionResult addadmin()
        {
            if (Convert.ToString(Session["authenticateda"]) == "true")
            {
                return View();
            }
            else
            {

                return RedirectToAction("Login", "Login");
            }
        }
        [HttpPost]
        public ActionResult addadmin(adminModel am)
        {
           am.addadmin();
            return RedirectToAction("addadmin", "adduser");
        } 
        //show all student data (bio)
        public ActionResult new1()

        {
            if (Convert.ToString(Session["authenticateda"]) == "true")
            {
                var entities = new resultEntity();

                return View(entities.showallstd().ToList());
            }
            else
            {

                return RedirectToAction("Login", "Login");
            }
           

        }
        //show all teacher data (bio)
        public ActionResult showteacher()

        {
            if (Convert.ToString(Session["authenticateda"]) == "true")
            {
                var entities = new teacherEntities1();

                return View(entities.showt().ToList());
            }
            else
            {

                return RedirectToAction("Login", "Login");
            }

           

        }

        [HttpGet]
      
        //admin pannel
        public ActionResult add()
        {
            if (Convert.ToString(Session["authenticateda"]) == "true")
            {
                return View();
            }
            else
            {

                return RedirectToAction("Login", "Login");
            }

        }

        // GET: adduser
        //add studenet
        [HttpGet]
        public ActionResult adduser()
        {
            if (Convert.ToString(Session["authenticateda"]) == "true")
            {
                return View();
            }
            else
            {

                return RedirectToAction("Login", "Login");
            }
        }
        [HttpPost]
        public ActionResult adduser(adduserModel au, string userType,string date)
        {
           
            au.insert_data(userType,date);

            return RedirectToAction("adduser", "adduser");

        }
        [HttpGet]
        //add teacher
        public ActionResult addteach()
        {
            if (Convert.ToString(Session["authenticateda"]) == "true")
            {
                return View();
            }
            else
            {

                return RedirectToAction("Login", "Login");
            }

        }
        [HttpPost]
        public ActionResult addteach(teacherModel tm)
        {

            tm.insert_teach();
            return View();

        }
        [HttpGet]
        //update teacher
        public ActionResult uptodatet()
        {
            if (Convert.ToString(Session["authenticateda"]) == "true")
            {
                return View();
            }
            else
            {

                return RedirectToAction("Login", "Login");
            }

        }
        [HttpPost]
        public ActionResult uptodatet(adduserModel tm)
        {

            tm.update_datat();
            return View(tm);
        }
        [HttpGet]
        //update student
        public ActionResult uptodate()
        {
            if (Convert.ToString(Session["authenticateda"]) == "true")
            {
                return View();
            }
            else
            {

                return RedirectToAction("Login", "Login");
            }

        }
        [HttpPost]
        public ActionResult uptodate(adduserModel au,string userType,string date)
        {

            au.update_data(userType,date);
            return View(au);

        }
        [HttpGet]
        //show data of student by id
        public ActionResult get_std()
        {
            if (Convert.ToString(Session["authenticateda"]) == "true")
            {
                return View();
            }
            else
            {

                return RedirectToAction("Login", "Login");
            }

        }
        [HttpPost]
        public ActionResult get_std(adduserModel au)
        {
            bool chk = (au.get_data());

            if (chk == true)
            {
                return View(au);
            }
            else
            {
                return View(au);
            }

        }
        //show data of teacher by id
        public ActionResult get_t()
        {
            if (Convert.ToString(Session["authenticateda"]) == "true")
            {
                return View();
            }
            else
            {

                return RedirectToAction("Login", "Login");
            }
        }
        [HttpPost]
        public ActionResult get_t(teacherModel tm)
        {
            bool chk = (tm.get_data());

            if (chk == true)
            {
                return View(tm);
            }
                return View();
            

        }

        //add course
        [HttpGet]
        public ActionResult add_course()
        {
            if (Convert.ToString(Session["authenticateda"]) == "true")
            {
                return View();
            }
            else
            {

                return RedirectToAction("Login", "Login");
            }

        }
        [HttpPost]
        public ActionResult add_course(ccra c)
        {
            c.add_cr();
            return View();
        }
        [HttpGet]
        public ActionResult add_class()
        {
            if (Convert.ToString(Session["authenticateda"]) == "true")
            {
                return View();
            }
            else
            {

                return RedirectToAction("Login", "Login");
            }

        }
        [HttpPost]
        public ActionResult add_class(ccra c)
        {
            c.add_class();
            return View();
        }
        [HttpGet]
        public ActionResult add_stdclass()
        {
            if (Convert.ToString(Session["authenticateda"]) == "true")
            {
                return View();
            }
            else
            {

                return RedirectToAction("Login", "Login");
            }

        }
        [HttpPost]
        public ActionResult add_stdclass(ccra c,string date)
        {
            c.add_stdclass(date);
            return View();
        }
        [HttpGet]
        public ActionResult add_classexam()
        {
            if (Convert.ToString(Session["authenticateda"]) == "true")
            {
                return View();
            }
            else
            {

                return RedirectToAction("Login", "Login");
            }

        }
        [HttpPost]
        public ActionResult add_classexam(ccra c,string date)
        {
            c.addexam(date);
            return View();
        }
        List<adduserModel> adu_list;
        [HttpGet]
        public ActionResult add_result()

        { 
            if (Convert.ToString(Session["authenticateda"]) == "true")
        {     adduserModel adu = new adduserModel();
                adu_list = adu.getid();
                ViewBag.shrk = new SelectList(adu_list, "id", "id",1);
                return View(adu);
            }
            else
            {

                return RedirectToAction("Login", "Login");

            }

        }
        [HttpPost]
        public ActionResult add_res(int? id)
          
        {  if (Convert.ToString(Session["authenticateda"]) == "true")
        {    adduserModel adu = new adduserModel();
               adu_list = adu.getid();
                ViewBag.shrk = new SelectList(adu_list, "id", "id");

                var std = adu.getstd((int)id);
                ViewBag.std = std;
                Session["selectedclass"] = id; 
                return View("add_result",adu);
            }
            else
            {

                return RedirectToAction("Login", "Login");

            }

        }
        [HttpPost] 
        public ActionResult add_result(FormCollection fc)
        {
            
            int classId = (int)Session["selectedclass"];
            ccra cc= new ccra();
            
            for (int i = 0; i < fc.AllKeys.Count(); i+=4)
            {
                int course_id = Convert.ToInt32(fc[i+2]);
                int id = Convert.ToInt32(fc[i]);
                int Mark = Convert.ToInt32(fc[i + 3]);
                cc.addresult(classId,course_id,id,Mark);
            }
            return Content("Update Completed!");
        }

        [HttpGet]
        public ActionResult show_result()
        {

            if (Convert.ToString(Session["authenticateda"]) == "true")
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
           // d.ccr = db.StudentResults.Where(t => t.std_id == d.ccra.std_id).ToList();
            d.ccr = db.StudentResults.Where(t => t.class_id == d.ccra.class_id).ToList(); 
            return View(d);    
        }
        [HttpGet]
        public ActionResult show_course()
        {

            if (Convert.ToString(Session["authenticateda"]) == "true")
            {
                return View();
            }
            else
            {

                return RedirectToAction("Login", "Login");
            }

        }

        [HttpPost]
        public ActionResult show_course(resultView d)
        {

            // var b= (from a in db.StudentResults where a.std_id == d.ccra.std_id select a);
            d.ccr = db.StudentResults.Where(t => t.std_id == d.ccra.std_id).ToList();
            return View(d);
        }
        [HttpGet]
        public ActionResult Get_all_std()
        {
            if (Convert.ToString(Session["authenticateda"]) == "true")
            {
                List<adduserModel> std_list = sm.get_all_std().ToList();
                return View(std_list);
            }
            else
            {

                return RedirectToAction("Login", "Login");
            }
                
            
            
        }
        [HttpGet]
        public ActionResult GetLis(int? id)
        {

            var obj = db.std_infor.Where(t => t.std_id == id).FirstOrDefault();
            adduserModel obj2 = new adduserModel();
            obj2.id = obj.std_id;

            return View("delstd", obj2);
        }
        [HttpPost]
        public ActionResult GetLis(adduserModel au)
        {
            au.del_data(); 
            return View("delstd", au);
        }
        [HttpGet]
        public ActionResult GetList(int? id)
        {

            var obj = db.std_infor.Where(t => t.std_id == id).FirstOrDefault();
            adduserModel obj2 = new adduserModel();
            obj2.id = obj.std_id;

            return View("uptodate", obj2);
        }
        [HttpPost]
        public ActionResult GetList(adduserModel au,string userType,string date)
        {

            au.update_data(userType, date);
            return View("uptodate",au);
        }
        teacherEntities1 tt = new teacherEntities1();
        [HttpGet]
        public ActionResult Gett(int? id)
        {

            var obj = tt.faculties.Where(t => t.t_id == id).FirstOrDefault();
            adduserModel obj2 = new adduserModel();
            obj2.id = obj.t_id;

            return View("uptodatet", obj2);
        }
        [HttpPost]
        public ActionResult Gett(adduserModel au)
        {

            au.update_datat();
            return View("uptodatet", au);
        }




        public ActionResult Report()
        {
            if (Convert.ToString(Session["authenticateda"]) == "true")
            {
                LocalReport lr = new LocalReport();

                string path = Path.Combine(Server.MapPath("~/Reporting"), "Report1.rdlc");
                if (System.IO.File.Exists(path))
                {
                    lr.ReportPath = path;
                }

                List<reportModel> cm = reportModel.get_report_data().ToList();

                ReportDataSource rd = new ReportDataSource("DataSet1", cm);
                lr.DataSources.Add(rd);
                string reportType = "PDF";
                string mimeType;
                string encoding;
                string fileNameExtension;

                string deviceInfo =

                "<DeviceInfo>" +
                "  <OutputFormat>" + reportType + "</OutputFormat>" +
                "  <PageWidth>11in</PageWidth>" +
                "  <PageHeight>8.5in</PageHeight>" +
                "  <MarginTop>0.5in</MarginTop>" +
                "  <MarginLeft>0.5in</MarginLeft>" +
                "  <MarginRight>0.5in</MarginRight>" +
                "  <MarginBottom>0.5in</MarginBottom>" +
                "</DeviceInfo>";
                
                Warning[] warnings;
                string[] streams;
                byte[] renderedBytes;

                renderedBytes = lr.Render(
                    reportType,
                    deviceInfo,
                    out mimeType,
                    out encoding,
                    out fileNameExtension,
                    out streams,
                    out warnings);


                return File(renderedBytes, mimeType);

            }
            else
            {

                return RedirectToAction("Login", "Login");
            }
            
        }

        [HttpGet]
        public ActionResult attendance()
        {
            if (Convert.ToString(Session["authenticateda"]) == "true")
            {
                return View();
            }
            else
            {

                return RedirectToAction("Login", "Login");
            }
        }    
        [HttpPost]
        public ActionResult attendance(ccra c)
        {
            c.attt();
            return View();
        }
        [HttpGet]
        public ActionResult sattendance()
        {
            if (Convert.ToString(Session["authenticateda"]) == "true")
            {
                return View();
            }
            else
            {

                return RedirectToAction("Login", "Login");
            }
        }
        
        [HttpPost]
        public ActionResult sattendance(resultView d)
        {

            d.ccr = db.StudentResults.Where(t => t.class_id == d.ccra.class_id);
            return View(d);

        }
    }
}