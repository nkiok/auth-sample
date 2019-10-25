namespace AuthSample.Features.Events
{
    public class UserRegistrationAttemptSuccessEvent : Event
    {
        public UserRegistrationAttemptSuccessEvent(string userId, string userName)
            : base(EventCategories.Registration,
                "User Registration Attempt Success",
                EventIds.UserRegistrationAttempt,
                EventTypes.Success)
        {
            UserId = userId;

            UserName = userName;
        }

        public string UserId { get; set; }

        public string UserName { get; set; }
    }
}
