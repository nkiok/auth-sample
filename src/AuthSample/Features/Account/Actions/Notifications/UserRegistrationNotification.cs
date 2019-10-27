using EnsureThat;
using MediatR;

namespace AuthSample.Features.Account.Actions.Notifications
{
    public class UserRegistrationNotification : INotification
    {
        public UserRegistrationNotification(string userId, string userName, bool isSuccess)
        {
            EnsureArg.IsNotNullOrWhiteSpace(userId, nameof(userId));

            UserId = userId;

            UserName = userName;

            IsSuccess = isSuccess;
        }

        public string UserId { get; }

        public string UserName { get; }

        public bool IsSuccess { get; }
    }
}
