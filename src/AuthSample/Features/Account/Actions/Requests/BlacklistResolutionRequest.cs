using AuthSample.Features.Account.Models;
using CSharpFunctionalExtensions;
using EnsureThat;
using MediatR;

namespace AuthSample.Features.Account.Actions.Requests
{
    public class BlacklistResolutionRequest : IRequest<Result>
    {
        public BlacklistResolutionRequest(AccountRegistrationModel model)
        {
            EnsureArg.IsNotNull(model, nameof(model));

            Model = model;
        }

        public AccountRegistrationModel Model { get; }
    }
}
