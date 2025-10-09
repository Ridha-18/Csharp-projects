using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Task20.CustomValidator
{
    public class NameValidator : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
                return new ValidationResult("Name is required.");

            string name = value.ToString()!;
            if (name.Length < 15)
                return new ValidationResult("Name must be at least 15 characters.");

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

    public class DOJValidator : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
                return new ValidationResult("Date of Joining is required.");

            var doj = (DateOnly)value;
            if (doj > DateOnly.FromDateTime(DateTime.Now))
                return new ValidationResult("Date of Joining must be less than or equal to today's date.");

            return ValidationResult.Success;
        }
    }

    public class DeptValidator : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
                return new ValidationResult("Department is required.");

            var dept = value.ToString();
            if (dept != "HR" && dept != "Accounts" && dept != "IT")
                return new ValidationResult("Department must be HR, Accounts, or IT.");

            return ValidationResult.Success;
        }
    }
}
