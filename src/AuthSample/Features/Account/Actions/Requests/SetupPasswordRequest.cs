using AuthSample.Features.Account.Models;
using EnsureThat;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace AuthSample.Features.Account.Actions.Requests
{
    public class SetupPasswordRequest : IRequest<IdentityResult>
    {
        public SetupPasswordRequest(PasswordSetupModel model)
        {
            EnsureArg.IsNotNull(model, nameof(model));

            Model = model;
        }

        public PasswordSetupModel Model { get; }
    }
}