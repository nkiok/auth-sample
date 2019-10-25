using System.Text.RegularExpressions;
using FluentValidation.Validators;

namespace AuthSample.Features.Validation
{
    public class PasswordPropertyValidator : PropertyValidator
    {
        private static readonly Regex PasswordRegex = new Regex(@"(?=^.{12,100}$)(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&amp;*()_+}{&quot;:;'?/&gt;.&lt;,])(?!.*\s).*$", RegexOptions.Compiled | RegexOptions.Singleline);

        public PasswordPropertyValidator() : base(
            "The password length must meet a minimum size of 12 characters and contain at least 1 upper case, 1 lower case, 1 number and 1 special character")
        {
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            if (context.PropertyValue is string value)
            {
                return PasswordRegex.IsMatch(value);
            }

            return false;
        }
    }
}
