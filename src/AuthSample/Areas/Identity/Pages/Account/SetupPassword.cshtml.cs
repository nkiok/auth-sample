using System.Threading.Tasks;
using AuthSample.Features.Account.Actions.Requests;
using AuthSample.Features.Account.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AuthSample.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class ResetPasswordModel : PageModel
    {
        private readonly IMediator _mediator;

        public ResetPasswordModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        [BindProperty]
        public PasswordSetupViewModel Input { get; set; }

        public IActionResult OnGet(string userId, string code)
        {
            if (userId == null)
            {
                return BadRequest("A user id must be supplied for password setup.");
            }

            if (code == null)
            {
                return BadRequest("A code must be supplied for password setup.");
            }
            else
            {
                Input = new PasswordSetupViewModel()
                {
                    Code = code,
                    UserId = userId
                };

                return Page();
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var passwordSetup = new PasswordSetupModel(Input.Password, Input.UserId, Input.Code);

            var result = await _mediator.Send(new SetupPasswordRequest(passwordSetup));

            if (result.Succeeded)
            {
                return RedirectToPage("./Login", new { returnUrl = "/Identity/Account/Manage/Analytics" });
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return Page();
        }
    }
}
