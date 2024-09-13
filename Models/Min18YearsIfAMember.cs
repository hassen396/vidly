
using System.ComponentModel.DataAnnotations;

namespace vidly.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer) validationContext.ObjectInstance;
            if (customer.MembershipTypeId == MembershipType.PayAsYouGo || 
            customer.MembershipTypeId == MembershipType.Unknown)

            return ValidationResult.Success;

            if (customer.DateOfBirth == null)
            return new ValidationResult("Birth date is required"); 
            var age = DateTime.Now.Year - customer.DateOfBirth.Value.Year;

            return (age >= 18)
            ? ValidationResult.Success 
            : new ValidationResult("customer should be at least 18 years old to go on a membership");
        }
    }
}