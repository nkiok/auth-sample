namespace AuthSample.Features.Events
{
    public class UserRegistrationAttemptFailureEvent : Event
    {
        public UserRegistrationAttemptFailureEvent(string userId, string userName)
            : base(EventCategories.Registration,
                "User Registration Attempt Failure",
                EventIds.UserRegistrationAttempt,
                EventTypes.Failure)
        {
            UserId = userId;

            UserName = userName;
        }

        public string UserId { get; set; }

        public string UserName { get; set; }
    }
}