using EnsureThat;
using MediatR;

namespace AuthSample.Features.Account.Actions.Notifications
{
    public class UserRegistrationAttemptNotification : INotification
    {
        public UserRegistrationAttemptNotification(string userName, string userEmail, bool isSuccess)
        {
            EnsureArg.IsNotNullOrWhiteSpace(userName, nameof(userName));
            EnsureArg.IsNotNullOrWhiteSpace(userEmail, nameof(userEmail));

            UserName = userName;

            UserEmail = userEmail;

            IsSuccess = isSuccess;
        }

        public string UserName { get; }

        public string UserEmail { get; }

        public bool IsSuccess { get; }
    }
}
