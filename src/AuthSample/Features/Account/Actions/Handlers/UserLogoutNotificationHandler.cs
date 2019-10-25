using System.Threading;
using System.Threading.Tasks;
using AuthSample.Features.Account.Actions.Notifications;
using AuthSample.Features.Events;
using MediatR;

namespace AuthSample.Features.Account.Actions.Handlers
{
    public class UserLogoutNotificationHandler : INotificationHandler<UserLogoutNotification>
    {
        private readonly IEventService _eventService;

        public UserLogoutNotificationHandler(IEventService eventService)
        {
            _eventService = eventService;
        }

        public async Task Handle(UserLogoutNotification notification, CancellationToken cancellationToken)
        {
            await _eventService.RaiseAsync(new UserLogoutEvent(notification.UserId));
        }
    }
}
