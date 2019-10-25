using System.Threading;
using System.Threading.Tasks;
using AuthSample.Features.Account.Actions.Notifications;
using AuthSample.Features.Events;
using MediatR;

namespace AuthSample.Features.Account.Actions.Handlers
{
    public class AgeValidationFailureNotificationHandler : INotificationHandler<AgeValidationFailureNotification>
    {
        private readonly IEventService _eventService;

        public AgeValidationFailureNotificationHandler(IEventService eventService)
        {
            _eventService = eventService;
        }

        public async Task Handle(AgeValidationFailureNotification notification, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(notification.UserId) || string.IsNullOrWhiteSpace(notification.UserName))
            {
                return;
            }

            await _eventService.RaiseAsync(new AgeValidationFailureEvent(notification.UserId, notification.UserName));
        }
    }
}
