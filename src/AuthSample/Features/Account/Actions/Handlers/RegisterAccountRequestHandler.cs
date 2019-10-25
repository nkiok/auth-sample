using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using AuthSample.Features.Account.Actions.Requests;
using EnsureThat;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace AuthSample.Features.Account.Actions.Handlers
{
    public class RegisterAccountRequestHandler : IRequestHandler<RegisterAccountRequest, RegisterAccountContext>
    {
        private readonly UserManager<IdentityUser> _userManager;

        public RegisterAccountRequestHandler(UserManager<IdentityUser> userManager)
        {
            EnsureArg.IsNotNull(userManager, nameof(userManager));

            _userManager = userManager;
        }

        public async Task<RegisterAccountContext> Handle(RegisterAccountRequest request, CancellationToken cancellationToken)
        {
            if (!request.IsValid)
            {
                return new RegisterAccountContext(IdentityResult.Failed(), new IdentityUser(), null);
            }

            try
            {
                var user = new IdentityUser { UserName = request.Model.Email, Email = request.Model.Email, EmailConfirmed = request.EmailConfirmed };

                var userResult = await _userManager.CreateAsync(user);

                if (!userResult.Succeeded)
                {
                    return new RegisterAccountContext(userResult, user, null);
                }

                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, request.Model.Name)
                };

                if (request.Model.DateOfBirth.HasValue && request.Model.DateOfBirth.Value != default)
                {
                    claims.Add(new Claim(ClaimTypes.DateOfBirth, request.Model.DateOfBirth.Value.Date.ToString("O")));
                }

                var claimsResult = await _userManager.AddClaimsAsync(user, claims);

                if(!claimsResult.Succeeded)
                { 
                    return new RegisterAccountContext(claimsResult, user, null);
                }

                var passwordToken = await _userManager.GeneratePasswordResetTokenAsync(user);

                return new RegisterAccountContext(claimsResult, user, passwordToken);
            }
            catch (IdentityResultException identityResultException)
            {
                return new RegisterAccountContext(identityResultException.IdentityResult, null, null);
            }
        }
    }
}
