using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AuthSample.Features.Account.Actions.Notifications;
using AuthSample.Features.Account.Actions.Requests;
using AuthSample.Features.Account.Models;
using AuthSample.Features.Validation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AuthSample.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly IMediator _mediator;

        public RegisterModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [Display(Name = "Name")]
            public string Name { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Date)]
            [AgeConstraint(AtLeastYears = 18, ErrorMessage = ValidationMessages.AgeCheckFailMessage)]
            [Display(Name = "Date of birth")]
            [ModelBinder(BinderType = typeof(DateModelBinder))]
            public DateTime? DateOfBirth { get; set; }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var accountRegistration = new AccountRegistrationModel(Input.Name, Input.Email, Input.DateOfBirth);

            if (!ModelState.IsValid)
            {
                if(ModelState.Values.SelectMany(v => v.Errors).Any(e => e.ErrorMessage == ValidationMessages.AgeCheckFailMessage))
                {
                    await _mediator.Publish(new AgeValidationFailureNotification(Input.Email, Input.Name));
                }

                var registrationAttempt = await _mediator.Send(new RegistrationAttemptedRequest(accountRegistration, ModelState.IsValid));

                if (registrationAttempt.IsFailure)
                {
                    ModelState.AddModelError(string.Empty, registrationAttempt.Error);

                    return Page();
                }

                return Page();
            }

            var registrationContext = await _mediator.Send(new RegisterAccountRequest(accountRegistration, ModelState.IsValid));

            if (!registrationContext.IdentityResult.Succeeded)
            {
                await _mediator.Publish(new UserRegistrationAttemptNotification(accountRegistration.Name, accountRegistration.Email, registrationContext.IdentityResult.Succeeded));

                foreach (var error in registrationContext.IdentityResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);

                    return Page();
                }
            }

            return RedirectToPage("./SetupPassword", new { userId = registrationContext.User.Id, code = registrationContext.PasswordToken });
        }
    }
}
