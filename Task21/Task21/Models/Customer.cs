using System.ComponentModel.DataAnnotations;
using Task21.CustomValidator;

namespace Task21.Models
{
    public class Customer
    {
        [Key]
        [Required(ErrorMessage = "ID is required")]
        public int Id { get; set; }

        [NameValidator]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Enter a valid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be 10 digits")]
        public string Phone { get; set; }

        [DOBValidator]
        public DateOnly DOB { get; set; }


    }
}
