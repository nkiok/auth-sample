using AuthSample.Features.Account.Models;
using EnsureThat;
using MediatR;

namespace AuthSample.Features.Account.Actions.Requests
{
    public class RegisterAccountRequest : IRequest<RegisterAccountContext>
    {
        public RegisterAccountRequest(AccountRegistrationModel model, bool isValid)
        {
            EnsureArg.IsNotNull(model, nameof(model));

            Model = model;

            IsValid = isValid;

            EmailConfirmed = true;
        }

        public AccountRegistrationModel Model { get; }

        public bool EmailConfirmed { get; }

        public bool IsValid { get; }
    }
}