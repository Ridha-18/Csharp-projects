using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Task20.CustomValidator;

namespace Task20.Models
{
    public class Employee
    {
        [Key]
        [Required(ErrorMessage = "ID is required")]
        public int Id { get; set; }
        [NameValidator]
        public string Name { get; set; }
        [DOBValidator]
        public DateOnly DOB { get; set; }
        [DOJValidator]
        public DateOnly DOJ { get; set; }
        [Range(12000, 60000, ErrorMessage = "Salary must be between 12000 and 60000")]
        public int? Salary { get; set; } // Nullable
        [DeptValidator]
        public string Department { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Confirm Password is required")]
        [Compare("Password", ErrorMessage = "Passwords must match")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }



    }
}
