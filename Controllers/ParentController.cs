using hight_school_follow_up.Models;
using hight_school_follow_up.Models ;
using hight_school_follow_up.Properties.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Runtime.InteropServices;
using BCrypt.Net;


public class ParentController : Controller
{
    private readonly AppDBcontext _context;

    public ParentController(AppDBcontext context)
    {
        _context = context;
    }
    [HttpGet]
    public IActionResult Index()
    {
        return View("Register");
    }

    // Registration Action
    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Register(string email, string parentName, string password, int studentId, IFormFile parentImage, string confirmPassword)
    {
        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
        var existingStudent = _context.Students.FirstOrDefault(s => s.studentid == studentId);

        if (existingStudent == null)
        {
            ViewBag.ErrorMessage = "wrong studentid";
            return View();
        }

        if (password != confirmPassword)
        {
            ModelState.AddModelError("confirmPassword", "Passwords do not match");
        }

        // Check if email format is valid
        if (!IsValidEmail(email))
        {
            ModelState.AddModelError("Email", "Invalid email format. Email must include '@' and end with '.com'");
        }

        // Handle image file
        // ...

        // Handle image file
        byte[] parentImageBytes = null;
        string imagePath = null;

        if (parentImage != null && parentImage.Length > 0)
        {
            using (var memoryStream = new MemoryStream())
            {
                parentImage.CopyTo(memoryStream);
                parentImageBytes = memoryStream.ToArray();

                // Save the image file to a designated folder (you need to create the folder)
                var imagePathOnServer = Path.Combine("wwwroot", "images", $"{Guid.NewGuid()}_parent_image.jpg");
                System.IO.File.WriteAllBytes(imagePathOnServer, parentImageBytes);

                imagePath = $"/images/{Path.GetFileName(imagePathOnServer)}";
            }
        }

        // ...


        var parent = new Parent
        {
            email = email,
            parentname = parentName,
            password = hashedPassword,
            parentimage = parentImageBytes,
            ImagePath = imagePath
        };

        _context.Parents.Add(parent);

        parent.studentparents = new List<StudentParent>
    {
        new StudentParent
        {
            studentid = studentId,
            parent = parent,
        }
    };

        _context.SaveChanges();

        ModelState.Clear();

        return RedirectToAction(nameof(Login));
    }

    // Helper method to check email format
    private bool IsValidEmail(string email)
    {
        return email.Contains("@") && email.EndsWith(".com");
    }

    // Helper method to check if the string contains only letters
   





    // Login Action
    public ActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Login(string email, string password)
    {
        if (!IsEmailValid(email))
        {
            ViewBag.ErrorMessage = "Invalid email format. Email must include '@' and end with '.com'.";
            return View();
        }

        var parent = _context.Parents.FirstOrDefault(p => p.email == email && p.password == password);
        if (parent != null)
        {
            // Successful login
            return RedirectToAction(nameof(SearchStudent));
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
        return email.Contains("@") && email.EndsWith(".com");
    }

   



// Search Student Action
public ActionResult SearchStudent()
    {
        return View();
    }

    [HttpPost]
    public ActionResult SearchStudent(int studentID, string studentName)
    {
        var student = _context.Students.FirstOrDefault(s => s.studentid == studentID && s.studentname == studentName);
        if (student != null)
        {
            // Student found
            return RedirectToAction("DisplayStudentDetails", "Parent", new { studentID = studentID });
        }
        else
        {
            // Student not found 
            ViewBag.ErrorMessage = "Student not found.";
            return View();
        }
    }


    [HttpGet]
    public ActionResult DisplayStudentDetails(int studentId)
    {
        List<Student> studentlist = _context.Students.ToList();
        List<Course> courselist = _context.Courses.ToList();
        List<Grade> gradelist = _context.Grades.ToList();
        List<teacher> teacherlist = _context.Teachers.ToList();

        ViewData["displaydata"] = from student in _context.Students
                                  where student.studentid == studentId
                                  join studentCourseGrade in _context.StudentCourseGrades on student.studentid equals studentCourseGrade.studentid
                                  join course in _context.Courses on studentCourseGrade.courseid equals course.courseid
                                  join grade in _context.Grades on studentCourseGrade.gradeid equals grade.gradeid into gradeDetails
                                  from grade in gradeDetails.DefaultIfEmpty()
                                  join teacherCourse in _context.TeacherCourses on course.courseid equals teacherCourse.courseid into teacherCourses
                                  from teacherCourseItem in teacherCourses.DefaultIfEmpty()
                                  join teacher in _context.Teachers on teacherCourseItem.teacherid equals teacher.teacherid into teachers
                                  from teacherItem in teachers.DefaultIfEmpty()
                                  select new DisplayViewModel
                                  {
                                      studentlist = student,
                                      courselist = course,
                                      gradelist = grade,
                                      teacherlist = teacherItem
                                  };

        return View(ViewData["displaydata"]);
    }





}
