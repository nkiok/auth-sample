using System.Threading;
using System.Threading.Tasks;
using AuthSample.Features.Account.Actions.Notifications;
using AuthSample.Features.Account.Actions.Requests;
using EnsureThat;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace AuthSample.Features.Account.Actions.Handlers
{
    public class SetupPasswordRequestHandler : IRequestHandler<SetupPasswordRequest, IdentityResult>
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IMediator _mediator;

        public SetupPasswordRequestHandler(UserManager<IdentityUser> userManager, IMediator mediator)
        {
            EnsureArg.IsNotNull(userManager, nameof(userManager));
            EnsureArg.IsNotNull(mediator, nameof(mediator));

            _userManager = userManager;

            _mediator = mediator;
        }

        public async Task<IdentityResult> Handle(SetupPasswordRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.Model.UserId);

            if (user == null)
            {
                return IdentityResult.Failed(new IdentityError() { Description = "User not found"});
            }

            var result = await _userManager.ResetPasswordAsync(user, request.Model.Code, request.Model.Password);

            await _mediator.Publish(new UserRegistrationNotification(user.Id, user.UserName, result.Succeeded), cancellationToken);

            return result;
        }
    }
}
