using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hight_school_follow_up.Models
{
    public class StudentCourseGrade
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int studentcoursegradeid { get; set; }

        public int studentid { get; set; }

        public int courseid { get; set; }
        public int gradeid { get; set; }

        [ForeignKey("gradeid")]
        public Grade grade { get; set; }

    


        [ForeignKey("studentid")]
        public Student student { get; set; }

        [ForeignKey("courseid")]
        public Course course { get; set; }
    }
}
