using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hight_school_follow_up.Models
{
    public class StudentParent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int studentparentid { get; set; }

        public int studentid { get; set; }

        public int parentid { get; set; }

        [ForeignKey("studentid")]
        public Student Student { get; set; }

        [ForeignKey("parentid")]
        public Parent parent { get; set; }
    }
}
