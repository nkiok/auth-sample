using System.Threading;
using System.Threading.Tasks;
using AuthSample.Features.Account.Actions.Notifications;
using AuthSample.Features.Events;
using MediatR;

namespace AuthSample.Features.Account.Actions.Handlers
{
    public class UserRegistrationAttemptNotificationHandler : INotificationHandler<UserRegistrationAttemptNotification>
    {
        private readonly IEventService _eventService;

        public UserRegistrationAttemptNotificationHandler(IEventService eventService)
        {
            _eventService = eventService;
        }

        public async Task Handle(UserRegistrationAttemptNotification notification, CancellationToken cancellationToken)
        {
            if (notification.IsSuccess)
            {
                await _eventService.RaiseAsync(new UserRegistrationAttemptSuccessEvent(notification.UserEmail, notification.UserName));
            }
            else
            {
                await _eventService.RaiseAsync(new UserRegistrationAttemptFailureEvent(notification.UserEmail, notification.UserName));
            }
        }
    }
}
