namespace AuthSample.Features.Events
{
    public class UserRegistrationFailureEvent : Event
    {
        public UserRegistrationFailureEvent(string userId)
            : base(EventCategories.Registration,
                "User Registration Failure",
                EventIds.UserRegistration,
                EventTypes.Failure)
        {
            UserId = userId;
        }

        public string UserId { get; set; }
    }
}