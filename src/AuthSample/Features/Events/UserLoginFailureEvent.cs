namespace AuthSample.Features.Events
{
    public class UserLoginFailureEvent : Event
    {
        public UserLoginFailureEvent(string userId)
            : base(EventCategories.Authentication,
                  "User Login Failure",
                  EventIds.UserLoginFailure,
                  EventTypes.Failure)
        {
            UserId = userId;
        }

        public string UserId { get; set; }
    }
}
