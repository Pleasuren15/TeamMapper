using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace team_mapper_domain.Models.Validations;

public class ValidateEmailAttribute : ValidationAttribute
{
    public override bool IsValid(object value)
    {
        if (value is string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, pattern);
        }
        return false;
    }
}
