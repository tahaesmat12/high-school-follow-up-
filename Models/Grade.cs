using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hight_school_follow_up.Models
{
    public class Grade
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int gradeid { get; set; }


        [Required]
        [MaxLength(100, ErrorMessage = "the grade must be from 0 to 100")]
        public  int grade { get; set; }

        public bool IsDefault { get; set; }
        public ICollection<StudentCourseGrade> studentcoursegrades { get; set; }
    }
}