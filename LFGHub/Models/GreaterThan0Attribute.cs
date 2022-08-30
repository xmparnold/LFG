using System.ComponentModel.DataAnnotations;
namespace LFGHub.Models;

public class GreaterThan0Attribute : ValidationAttribute 
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null)
        {
            return ValidationResult.Success;
        }
        if ((int)value <= 0)
        {
            return new ValidationResult("must be greater than 0");
        }
        return ValidationResult.Success;
    }
}