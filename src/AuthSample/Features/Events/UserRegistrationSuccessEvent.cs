namespace AuthSample.Features.Events
{
    public class UserRegistrationSuccessEvent : Event
    {
        public UserRegistrationSuccessEvent(string userId)
            : base(EventCategories.Registration,
                "User Registration Success",
                EventIds.UserRegistration,
                EventTypes.Success)
        {
            UserId = userId;
        }

        public string UserId { get; set; }
    }
}
