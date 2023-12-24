using hight_school_follow_up.Models;
using hight_school_follow_up.Properties.Data;
using Microsoft.AspNetCore.Mvc;


namespace hight_school_follow_up.Controllers
{
    public class teachersController : Controller
    {
        private readonly AppDBcontext _context;

        public teachersController(AppDBcontext context)
        {
            _context = context;
        }


        [HttpGet]
        public ActionResult loginn()
        {
            return View();
        }
        [HttpPost]

        public ActionResult loginn(string temail, string passwordd)
        {
            

            var teacher = _context.Teachers.FirstOrDefault(t => t.temail == temail && t.passwordd == passwordd);
            if (teacher!=null)
            {
            
                // Successful login
                return RedirectToAction("addstudent","students");
            
            }
            else
            {
              
                // Invalid credentials 
                ViewBag.ErrorMessage = "Invalid email or password.";
                return View();
            }
        }

        // Helper method to check email format
        private bool IsEmailValid(string email)
        {
            return email.Contains("@") && email.EndsWith(".com"+"or"+".eg");
        }




        [HttpGet]
        public ActionResult addteacher()
        {
            return  View();
        }


        [HttpPost]
        public ActionResult addteacher(string temail,string teachername,string passwordd,string phonenumber)
        {
           
                teacher t = new teacher();
                t.temail = temail;
                t.teachername = teachername;
                t.passwordd = passwordd;
                t.phonenumber = phonenumber;


            _context.Teachers.Add(t);
                _context.SaveChanges(); 
                ModelState.Clear();
                return RedirectToAction("addcourse","Courses");
            




        }
    }
}
