using EnsureThat;
using MediatR;

namespace AuthSample.Features.Account.Actions.Notifications
{
    public class UserRegistrationNotification : INotification
    {
        public UserRegistrationNotification(string userId, bool isSuccess)
        {
            EnsureArg.IsNotNullOrWhiteSpace(userId, nameof(userId));

            UserId = userId;

            IsSuccess = isSuccess;
        }

        public string UserId { get; }

        public bool IsSuccess { get; }
    }
}
