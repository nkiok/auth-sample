using EnsureThat;
using MediatR;

namespace AuthSample.Features.Account.Actions.Notifications
{
    public class UserLogoutNotification : INotification
    {
        public UserLogoutNotification(string userId)
        {
            EnsureArg.IsNotNullOrWhiteSpace(userId, nameof(userId));

            UserId = userId;
        }

        public string UserId { get; }
    }
}
