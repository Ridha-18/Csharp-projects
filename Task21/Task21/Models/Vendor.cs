using System.ComponentModel.DataAnnotations;
using Task21.CustomValidator;

namespace Task21.Models
{
    public class Vendor
    {
        [Key]
        [Required(ErrorMessage = "ID is required")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Company Name is required")]
        [StringLength(50)]
        public string CompanyName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Enter a valid email address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Phone number is required")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be 10 digits")]
        public string Phone { get; set; }
        [ServiceTypeValidator]
        public string ServiceType { get; set; }
        [Required(ErrorMessage = "Contract Start Date is required")]
        public DateOnly ContractStartDate { get; set; }
        [Required(ErrorMessage = "Contract End Date is required")]
        [ContractDateValidator]
        public DateOnly ContractEndDate { get; set; }
    }
}
