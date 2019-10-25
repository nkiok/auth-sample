using MediatR;

namespace AuthSample.Features.Account.Actions.Notifications
{
    public class AgeValidationFailureNotification : INotification
    {
        public AgeValidationFailureNotification(string userId, string userName)
        {
            UserId = userId;

            UserName = userName;
        }

        public string UserId { get; }

        public string UserName { get; }
    }
}