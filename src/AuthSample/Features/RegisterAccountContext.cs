using EnsureThat;
using Microsoft.AspNetCore.Identity;

namespace AuthSample.Features
{
    public class RegisterAccountContext
    {
        public RegisterAccountContext(IdentityResult identityResult, IdentityUser user, string passwordToken)
        {
            EnsureArg.IsNotNull(identityResult, nameof(identityResult));
            EnsureArg.IsNotNull(user, nameof(user));

            IdentityResult = identityResult;

            User = user;

            PasswordToken = passwordToken;
        }

        public IdentityResult IdentityResult { get; }

        public IdentityUser User { get; }

        public string PasswordToken { get; }
    }
}
