namespace AuthSample.Features.Events
{
    public class AgeValidationFailureEvent : Event
    {
        public AgeValidationFailureEvent(string userId, string userName)
            : base(EventCategories.Validation,
                "Age Validation Failure",
                EventIds.AgeValidationFailure,
                EventTypes.Failure)
        {
            UserId = userId;

            UserName = userName;
        }

        public string UserId { get; set; }

        public string UserName { get; set; }
    }
}