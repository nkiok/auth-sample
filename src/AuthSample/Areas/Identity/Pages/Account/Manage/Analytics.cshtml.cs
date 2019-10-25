using System.Threading.Tasks;
using AuthSample.Data;
using AuthSample.Features.Account.Models;
using AuthSample.Features.Account.Models.Mappers.UserLoginEvents;
using AuthSample.Features.Events;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AuthSample.Areas.Identity.Pages.Account.Manage
{
    public class AnalyticsModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _dbContext;

        private static readonly int[] EventsFilter =
        {
            EventIds.UserLoginSuccess,
            EventIds.UserLoginFailure,
            EventIds.UserLogout
        };

        public AnalyticsModel(UserManager<IdentityUser> userManager, ApplicationDbContext dbContext)
        {
            _userManager = userManager;
            
            _dbContext = dbContext;
        }

        public UserEventsIndexViewModel EventsIndex { get; set; }

        public async Task<IActionResult> OnGet()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var events = _dbContext.UserEvents(user.Id, user.UserName, EventsFilter);

            EventsIndex = UserEventsIndexViewModelFactory.Create(user.Id, events);

            return Page();
        }
    }
}