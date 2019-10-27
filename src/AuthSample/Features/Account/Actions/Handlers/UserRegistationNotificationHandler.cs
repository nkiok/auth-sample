using System.Threading;
using System.Threading.Tasks;
using AuthSample.Features.Account.Actions.Notifications;
using AuthSample.Features.Events;
using MediatR;

namespace AuthSample.Features.Account.Actions.Handlers
{
    public class UserRegistationNotificationHandler : INotificationHandler<UserRegistrationNotification>
    {
        private readonly IEventService _eventService;

        public UserRegistationNotificationHandler(IEventService eventService)
        {
            _eventService = eventService;
        }

        public async Task Handle(UserRegistrationNotification notification, CancellationToken cancellationToken)
        {
            if (notification.IsSuccess)
            { 
                await _eventService.RaiseAsync(new UserRegistrationSuccessEvent(notification.UserId));
            }
            else
            {
                await _eventService.RaiseAsync(new UserRegistrationFailureEvent(notification.UserId, notification.UserName));
            }
        }
    }
}
