using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hight_school_follow_up.Models
{
    public class Parent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int parentid { get; set; }

        [Required]
        [MaxLength(100)]
        public string parentname { get; set; }

        [Required]
        [EmailAddress]
        public string email { get; set; }

        [Required]
        [MaxLength(60)]
        
        public string password { get; set; }

        // One-to-Many relationship with StudentParent
        public ICollection<StudentParent> studentparents { get; set; }

        // Add a property for the image data
        public byte[] parentimage { get; set; }
        public string ImagePath {  get; set; }

    }
}
