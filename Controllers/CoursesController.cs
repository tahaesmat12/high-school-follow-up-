using hight_school_follow_up.Models;
using hight_school_follow_up.Properties.Data;
using Microsoft.AspNetCore.Mvc;

namespace hight_school_follow_up.Controllers
{
    public class CoursesController : Controller
    {
        private readonly AppDBcontext _context;

        public CoursesController(AppDBcontext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult addcourse()
        {
            return View();
        }


        [HttpPost]
        public ActionResult addcourse(string coursename)
        {
            if (coursename == "arabic" || coursename == "english" || coursename == "french" || coursename == "history" || coursename == "math" || coursename == "chemistry" || coursename == "physics" || coursename == "geo" || coursename == "philosophy")
            {

             

                Course c = new Course();
                
                c.coursename = coursename;
                _context.Courses.Add(c);
                
                _context.SaveChanges();
                ModelState.Clear();
                return RedirectToAction("addgrades", "Grades");
            }
            
           else
            {
                ViewBag.ErrorMessage = "enter a course from these specific courses (math,english,arabic,chemistry,physics,geo,french,history,philosophy )"; 
                return View();
            }



        }
    }
}
