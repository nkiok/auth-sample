namespace AuthSample.Features.Validation
{
    public static class ValidationMessages
    {
        public const string AgeCheckFailMessage = "You must be at least 18 years old.";

        public const string InvalidDate = "is not a valid date.";

        public const string AgeCheckBlacklistReason = "Locked out, age check failed more than three times in 1 hour";
    }
}
