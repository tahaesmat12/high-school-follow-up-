using hight_school_follow_up.Models;
using hight_school_follow_up.Properties.Data;
using Microsoft.AspNetCore.Mvc;

namespace hight_school_follow_up.Controllers
{
    public class GradesController : Controller
    {
        private readonly AppDBcontext _context;

        public GradesController(AppDBcontext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult addgrades()
        {
            return View();
        }

        [HttpPost]
        public ActionResult addgrades(int grade)
        { if (grade > 0 && grade <= 100)
            {
                Grade g = new Grade();
                g.grade = grade;
           


             
                
              
                _context.Grades.Add(g);
              

                _context.SaveChanges();

                TempData["Message"] = "The insert is done.";

                return RedirectToAction("addstudent", "students");
            }
            else
            {
                ViewBag.ErrorMessage = "the grade must be from 0 to 100";
                return View();
            }
        }
    }
}
