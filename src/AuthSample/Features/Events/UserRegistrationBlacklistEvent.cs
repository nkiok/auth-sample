namespace AuthSample.Features.Events
{
    public class UserRegistrationBlacklistEvent : Event
    {
        public UserRegistrationBlacklistEvent(string userId, string userName)
            : base(EventCategories.Registration,
                "User Registration Blacklisted",
                EventIds.UserRegistrationBlacklist,
                EventTypes.Information)
        {
            UserId = userId;

            UserName = userName;
        }

        public string UserId { get; set; }

        public string UserName { get; set; }
    }
}