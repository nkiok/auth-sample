using AuthSample.Features.Account.Models;
using FluentValidation;

namespace AuthSample.Features.Validation
{
    public class SetupPasswordViewModelValidator : AbstractValidator<PasswordSetupViewModel>
    {
        public SetupPasswordViewModelValidator()
        {
            RuleFor(r => r.Password)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .Password();

            RuleFor(r => r.ConfirmPassword)
                .Equal(m => m.Password).WithMessage("The password and confirmation password do not match");
        }
    }
}
