using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace hight_school_follow_up.Models
{
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int courseid { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Invalid course name. Please choose from math, english, arabic, chemistry, physics, geo, french, history, philosophy.")]
        public string coursename { get; set; }

        public ICollection<StudentCourseGrade> studentcoursegrades { get; set; }

    }
}
