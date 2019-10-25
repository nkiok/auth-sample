namespace AuthSample.Features.Events
{
    public class UserLoginSuccessEvent : Event
    {
        public UserLoginSuccessEvent(string userId)
            : base(EventCategories.Authentication,
                  "User Login Success",
                  EventIds.UserLoginSuccess,
                  EventTypes.Success)
        {
            UserId = userId;
        }

        public string UserId { get; set; }
    }
}