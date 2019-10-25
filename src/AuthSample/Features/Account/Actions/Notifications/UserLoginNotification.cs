using EnsureThat;
using MediatR;

namespace AuthSample.Features.Account.Actions.Notifications
{
    public class UserLoginNotification : INotification
    {
        public UserLoginNotification(string userId, string userName, bool isSuccess)
        {
            EnsureArg.IsNotNullOrWhiteSpace(userId, nameof(userId));
            EnsureArg.IsNotNullOrWhiteSpace(userName, nameof(userName));

            UserId = userId;

            UserName = userName;

            IsSuccess = isSuccess;
        }

        public string UserId { get; }

        public string UserName { get; }

        public bool IsSuccess { get; }
    }
}
