using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Task21.CustomValidator
{
        public class NameValidator : ValidationAttribute
        {
            protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
            {
                if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
                    return new ValidationResult("Name is required.");

                string name = value.ToString()!;
                if (name.Length < 10)
                    return new ValidationResult("Name must be at least 10 characters.");

                if (!Regex.IsMatch(name, @"^[A-Za-z\s]+$"))
                    return new ValidationResult("Name must contain only alphabets and spaces.");

                return ValidationResult.Success;
            }
        }

    public class DOBValidator : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
                return new ValidationResult("Date of Birth is required.");

            var dob = (DateOnly)value;
            if (dob.Year < 2002 || dob.Year > 2005)
                return new ValidationResult("Year of Birth must be between 2002 and 2005.");

            return ValidationResult.Success;
        }
    }

    public class ServiceTypeValidator : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
                return new ValidationResult("ServiceType is required.");

            var ST = value.ToString();
            if (ST != "IT" && ST != "Logistics" && ST != "Maintainance")
                return new ValidationResult("ServiceType must be IT, Logistics, or Maintainance.");

            return ValidationResult.Success;
        }
    }

    public class ContractDateValidator : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var vendor = (Models.Vendor)validationContext.ObjectInstance;
            if (vendor.ContractEndDate < vendor.ContractStartDate)
                return new ValidationResult("Contract End Date must be after Start Date.");

            return ValidationResult.Success;
        }
    }
}
