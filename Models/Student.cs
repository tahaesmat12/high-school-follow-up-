using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace hight_school_follow_up.Models
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]


        [Required]
        [MaxLength(100, ErrorMessage = "wrong")]
        public int studentid { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "wrong")]
        public string studentname { get; set; }

        [Required]
        [Range(1, 3, ErrorMessage = "The level must be between 1 and 3.")]
        public int level { get; set; }


        [MaxLength(255)]
        public string behaviour { get; set; }

        // One-to-Many relationship with StudentCourse
        public ICollection<StudentCourseGrade> studentcoursegrades { get; set; }

        // One-to-Many relationship with StudentParent
        public ICollection<StudentParent> studentparents { get; set; }

       
    }
}
