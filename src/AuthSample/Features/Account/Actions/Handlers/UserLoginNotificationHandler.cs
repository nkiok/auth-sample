using System.Threading;
using System.Threading.Tasks;
using AuthSample.Features.Account.Actions.Notifications;
using AuthSample.Features.Events;
using MediatR;

namespace AuthSample.Features.Account.Actions.Handlers
{
    public class UserLoginNotificationHandler : INotificationHandler<UserLoginNotification>
    {
        private readonly IEventService _eventService;

        public UserLoginNotificationHandler(IEventService eventService)
        {
            _eventService = eventService;
        }

        public async Task Handle(UserLoginNotification notification, CancellationToken cancellationToken)
        {
            if (notification.IsSuccess)
            {
                await _eventService.RaiseAsync(new UserLoginSuccessEvent(notification.UserId));
            }
            else
            {
                await _eventService.RaiseAsync(new UserLoginFailureEvent(notification.UserName));
            }
        }
    }
}
