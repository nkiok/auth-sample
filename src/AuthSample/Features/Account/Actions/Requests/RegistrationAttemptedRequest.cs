using AuthSample.Features.Account.Models;
using CSharpFunctionalExtensions;
using EnsureThat;
using MediatR;

namespace AuthSample.Features.Account.Actions.Requests
{
    public class RegistrationAttemptedRequest : IRequest<Result>
    {
        public RegistrationAttemptedRequest(AccountRegistrationModel model, bool isValid)
        {
            EnsureArg.IsNotNull(model, nameof(model));

            Model = model;

            IsValid = isValid;
        }

        public AccountRegistrationModel Model { get; }

        public bool IsValid;
    }
}