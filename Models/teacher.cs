using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hight_school_follow_up.Models
{
    public class teacher
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int teacherid { get; set; }

        [Required]
        [MaxLength(100)]
        public string teachername { get; set; }

        [Phone]
        public string phonenumber { get; set; }

        [Required]
        [MaxLength(50)]
        public string passwordd { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.(com|eg)$", ErrorMessage = "Invalid email format. Use '@' and either '.com' or '.eg'")]
        public string temail { get; set; }

        // One-to-Many relationship with TeacherCourse
        public ICollection<TeacherCourse> teachercourses { get; set; }
    }
}
