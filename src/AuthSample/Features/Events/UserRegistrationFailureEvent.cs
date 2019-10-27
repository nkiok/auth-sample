namespace AuthSample.Features.Events
{
    public class UserRegistrationFailureEvent : Event
    {
        public UserRegistrationFailureEvent(string userId, string userName)
            : base(EventCategories.Registration,
                "User Registration Failure",
                EventIds.UserRegistration,
                EventTypes.Failure)
        {
            UserId = userId;

            UserName = userName;
        }

        public string UserId { get; }

        public string UserName { get; }
    }
}