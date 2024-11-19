using System.ComponentModel.DataAnnotations;

namespace StudentDemoForGuid.Models
{
    public class Student
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(25, ErrorMessage = "Max Length of Name is 25 Characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }
    }
}
