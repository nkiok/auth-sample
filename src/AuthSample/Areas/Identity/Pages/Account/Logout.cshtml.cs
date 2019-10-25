using System.Security.Claims;
using System.Threading.Tasks;
using AuthSample.Features.Account.Actions.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace AuthSample.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<LogoutModel> _logger;
        private readonly IMediator _mediator;

        public LogoutModel(SignInManager<IdentityUser> signInManager, ILogger<LogoutModel> logger, IMediator mediator)
        {
            _signInManager = signInManager;

            _logger = logger;

            _mediator = mediator;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(string returnUrl = null)
        {
            await _signInManager.SignOutAsync();

            await _mediator.Publish(new UserLogoutNotification(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value));

            _logger.LogInformation("User logged out.");

            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }

            return RedirectToPage();
        }
    }
}