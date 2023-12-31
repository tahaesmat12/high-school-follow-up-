﻿
using hight_school_follow_up.Models;
using hight_school_follow_up.Properties.Data;
using Microsoft.AspNetCore.Mvc;

namespace hight_school_follow_up.Controllers
{
    public class StudentsController : Controller
    {
        private readonly AppDBcontext _context;

        public StudentsController(AppDBcontext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Addstudent()
        {
            return View();
        }
        [HttpPost]

        [HttpPost]
        public IActionResult AddStudent(string studentname, int level, string behaviour)
        {
            if (level == 1 || level == 2 || level == 3)
            {
                var student = new Student
                {
                    behaviour = behaviour,
                    studentname = studentname,
                    level = level
                };

                _context.Students.Add(student);

                //// Save changes to get the student ID generated by the database
                //_context.SaveChanges();

                //// Create a StudentCourseGrade entry for each course and save to the database
                //var courses = _context.Courses.ToList(); // Assuming you have a Courses DbSet in your context
                //var defaultGrade = _context.Grades.FirstOrDefault(g => g.IsDefault);

                //foreach (var course in courses)
                //{
                //    //var studentCourseGrade = new StudentCourseGrade
                //    //{
                //    //    studentid = student.studentid,
                //    //    //courseid = course.courseid,
                //    //    //gradeid = course // Use default grade or handle this based on your logic
                //    //};

                //    //_context.StudentCourseGrades.Add(studentCourseGrade);
                //}

                //_context.SaveChanges();

                ModelState.Clear();
                return RedirectToAction("addcourse", "Courses");
            }
            else
            {
                ViewBag.ErrorMessage = "The level must be equal to 1, 2, or 3";
                return View();
            }
        }

        private bool IsLettersOnly(string input)
        {

            return !string.IsNullOrWhiteSpace(input) && input.All(char.IsLetter);
        }
        [HttpGet]
        public IActionResult deletestudent()
        {
            return View();

        }
        [HttpPost]

        public ActionResult deletestudent(int studentid, string studentName)
        {

            var student = _context.Students.FirstOrDefault(s => s.studentid == studentid && s.studentname == studentName);
            if (studentid != null)
            {

                _context.Students.Remove(student);
                _context.SaveChanges();
            }
            else
            {

                ViewBag.ErrorMessage = "Student not found.";
                return View();
            }


            ModelState.Clear();

            return RedirectToAction(nameof(deletestudent));
        }








    }
}