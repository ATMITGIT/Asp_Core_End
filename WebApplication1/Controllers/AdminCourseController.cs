using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AdminCourseController : Controller
    {
        private readonly IHostingEnvironment _environment;
        private ApplicationContext db;
        public AdminCourseController(IHostingEnvironment IHostingEnvironment,ApplicationContext t)
        {
            _environment = IHostingEnvironment;
            db = t;
        }
        public IActionResult Index()
        {
            return View("admincourse");
        }
        public IActionResult What()
        {
            ViewData["course"] = db.Courses.ToList();
            return View("whadminadd");
        }
        [HttpPost]
        public IActionResult addWh(string sel,string title)
        {
         
            Wh w = new Wh {WhName=title,CourseId=int.Parse(sel) };
            db.Whs.Add(w);
            db.SaveChanges();
            return Redirect("What");
        }
        

        public IActionResult Level()
        {
            ViewData["Course"] = db.Courses.ToList();
         
            return View("bglevel");
        }
        [HttpPost]
        public IActionResult Level(string sel, string description, string title)
        {
            ViewData["Course"] = db.Courses.ToList();
            Level l = new Level { BgLevelText=description,BgLevelTitle=title,CourseId=int.Parse(sel)};
            db.Levels.Add(l);
            db.SaveChanges();
            return View("bglevel");
        }
        public IActionResult Video()
        {
            ViewData["course"] = db.Courses.ToList();
            ViewData["level"] = db.Levels.ToList();
            return View("addVideo");
        }
        [HttpPost]
        public IActionResult addVideo(string sel, string sel1, string title, string text,string link)
        {
            var newFileName = string.Empty;

            if (HttpContext.Request.Form.Files != null)
            {
                var fileName = string.Empty;
                string PathDB = string.Empty;

                var files = HttpContext.Request.Form.Files;

                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        //Getting FileName
                        fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');

                        //Assigning Unique Filename (Guid)
                        var myUniqueFileName = Convert.ToString(Guid.NewGuid());

                        //Getting file Extension
                        var FileExtension = Path.GetExtension(fileName);

                        // concating  FileName + FileExtension
                        newFileName = myUniqueFileName + FileExtension;

                        // Combines two strings into a path.
                        fileName = Path.Combine(_environment.WebRootPath, "Files1") + $@"\{newFileName}";

                        // if you want to store path of folder in database
                        PathDB = "Files1/" + newFileName;

                        using (FileStream fs = System.IO.File.Create(fileName))
                        {
                            file.CopyTo(fs);
                            fs.Flush();
                        }
                        /*    FileModel m = new FileModel { Path = PathDB };
                            a.Add(m);
                            a.SaveChanges();*/
                        /*    Course c = new Course { CourseImage = PathDB, CourseTitle = title, CourseDescription = shortt };
                            db.Courses.Add(c);
                            db.SaveChanges();*/
                        VideoBg bg = new VideoBg {CourseId=int.Parse(sel),LevelId=int.Parse(sel1),VideoTitle=title,VideoText=text,VideoImg=PathDB,Link=link };
                        db.VideoBgs.Add(bg);
                        db.SaveChanges();
                    }
                }
            }

                    return Redirect("Video");
        }
        public IActionResult addCourse(string title,string shortt)
        {
            var newFileName = string.Empty;

            if (HttpContext.Request.Form.Files != null)
            {
                var fileName = string.Empty;
                string PathDB = string.Empty;

                var files = HttpContext.Request.Form.Files;

                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        //Getting FileName
                        fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');

                        //Assigning Unique Filename (Guid)
                        var myUniqueFileName = Convert.ToString(Guid.NewGuid());

                        //Getting file Extension
                        var FileExtension = Path.GetExtension(fileName);

                        // concating  FileName + FileExtension
                        newFileName = myUniqueFileName + FileExtension;

                        // Combines two strings into a path.
                        fileName = Path.Combine(_environment.WebRootPath, "Files") + $@"\{newFileName}";

                        // if you want to store path of folder in database
                        PathDB = "Files/" + newFileName;

                        using (FileStream fs = System.IO.File.Create(fileName))
                        {
                            file.CopyTo(fs);
                            fs.Flush();
                        }
                        /*    FileModel m = new FileModel { Path = PathDB };
                            a.Add(m);
                            a.SaveChanges();*/
                        Course c = new Course {CourseImage=PathDB,CourseTitle=title,CourseDescription=shortt };
                        db.Courses.Add(c);
                        db.SaveChanges();
                    }
                }


            }
            return Redirect("Index");
        }
    }
}