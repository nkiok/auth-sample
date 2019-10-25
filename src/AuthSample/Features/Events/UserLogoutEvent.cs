namespace AuthSample.Features.Events
{
    public class UserLogoutEvent : Event
    {
        public UserLogoutEvent(string userId)
            : base(EventCategories.Authentication,
                  "User Logout",
                  EventIds.UserLogout,
                  EventTypes.Information)
        {
            UserId = userId;
        }

        public string UserId { get; set; }
    }
}