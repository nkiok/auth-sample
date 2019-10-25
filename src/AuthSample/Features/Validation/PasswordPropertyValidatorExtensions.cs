using FluentValidation;

namespace AuthSample.Features.Validation
{
    public static class PasswordPropertyValidatorExtensions
    {
        public static IRuleBuilderOptions<T, string> Password<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new PasswordPropertyValidator());
        }
    }
}
