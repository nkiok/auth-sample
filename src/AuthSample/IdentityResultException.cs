using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Identity;

namespace AuthSample
{
    public class IdentityResultException : Exception
    {
        [DebuggerStepThrough, DebuggerHidden]
        public static void ThrowOnError(IdentityResult identityResult)
        {
            if (!identityResult.Succeeded)
            {
                throw new IdentityResultException(identityResult);
            }
        }

        public static IdentityResultException Failed(string errorMessage, string code = null)
        {
            return new IdentityResultException(IdentityResult.Failed(new IdentityError
            {
                Code = code,
                Description = errorMessage
            }));
        }

        public IdentityResultException(IdentityResult identityResult) : base("An error occurred during identity management")
        {
            IdentityResult = identityResult;
        }

        public IdentityResult IdentityResult { get; }
    }
}
