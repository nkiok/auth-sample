using System.Threading;
using System.Threading.Tasks;
using AuthSample.Features.Account.Actions.Notifications;
using AuthSample.Features.Account.Actions.Requests;
using CSharpFunctionalExtensions;
using EnsureThat;
using MediatR;

namespace AuthSample.Features.Account.Actions.Handlers
{
    public class RegistrationAttemptedRequestHandler : IRequestHandler<RegistrationAttemptedRequest, Result>
    {
        private readonly IMediator _mediator;

        public RegistrationAttemptedRequestHandler(IMediator mediator)
        {
            EnsureArg.IsNotNull(mediator, nameof(mediator));

            _mediator = mediator;
        }
        
        public async Task<Result> Handle(RegistrationAttemptedRequest request, CancellationToken cancellationToken)
        {
            var blacklisted = await _mediator.Send(new BlacklistResolutionRequest(request.Model), cancellationToken);

            await _mediator.Publish(new UserRegistrationAttemptNotification(request.Model.Name, request.Model.Email, request.IsValid), cancellationToken);

            return blacklisted;           
        }
    }
}
