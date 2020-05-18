using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CourseController : Controller
    { private ApplicationContext db;
        public CourseController(ApplicationContext t) {
            db = t;
        }
        public IActionResult Index()
        {
            /*Course c= db.Courses.FirstOrDefault(x=>x.CourseId==1);
             List<Wh> w = db.Whs.Where(x => x.CourseId == c.CourseId).ToList();
             List<Level> l = db.Levels.Where(x=>x.CourseId==c.CourseId).ToList();
             List<VideoBg> v = db.VideoBgs.Where(x=>x.CourseId==c.CourseId).ToList();
             ViewBag.obj= c;
             ViewData["wh"] = w;
             ViewData["level"] = l;
             ViewData["video"] = v;
             return View("Course");*/
            string pass = HttpContext.Session.GetString("password");
            if (pass == null)
            {
                return Redirect("~/Student/Login");
            }
            else
            {
                Course c = db.Courses.FirstOrDefault(x => x.CourseId == 1);
                List<Wh> w = db.Whs.Where(x => x.CourseId == c.CourseId).ToList();
                List<Level> l = db.Levels.Where(x => x.CourseId == c.CourseId).ToList();
                List<VideoBg> v = db.VideoBgs.Where(x => x.CourseId == c.CourseId).ToList();
                ViewBag.obj = c;
                ViewData["wh"] = w;
                ViewData["level"] = l;
                ViewData["video"] = v;
                return View("Course");
            }
         
        }
        public IActionResult Page(int id)
        {
            string pass = HttpContext.Session.GetString("password");
            if (pass == null)
            {
                return Redirect("~/Student/Login");
            }
            else
            {
                VideoBg c = db.VideoBgs.FirstOrDefault(x => x.VideoId == id);
                List<VideoBg> v = db.VideoBgs.Where(x => x.CourseId == c.CourseId).ToList();
                List<Level> l = db.Levels.Where(x => x.CourseId == c.CourseId).ToList();
                ViewBag.obj = c;
                ViewData["level"] = l;
                ViewData["video"] = v;
                return View("pagecourse");
            }
        }
    }
}