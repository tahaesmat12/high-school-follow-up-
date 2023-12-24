using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hight_school_follow_up.Models
{
    public class TeacherCourse
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int teachercourseid { get; set; }

        public int teacherid { get; set; }

        public int courseid { get; set; }

        [ForeignKey("teacherid")]
        public teacher teacher { get; set; }

        [ForeignKey("courseid")]
        public Course course { get; set; }
    }
}
