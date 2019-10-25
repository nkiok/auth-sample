namespace AuthSample.Features.Events
{
    public static class EventIds
    {
        private const int RegistrationEventsStart = 1000;
        public const int UserRegistration = RegistrationEventsStart + 0;
        public const int UserRegistrationAttempt = RegistrationEventsStart + 1;
        public const int UserRegistrationBlacklist = RegistrationEventsStart + 2;

        private const int ValidationEventStart = 2000;
        public const int AgeValidationFailure = ValidationEventStart + 0;

        private const int AuthenticationEventsStart = 3000;
        public const int UserLoginSuccess = AuthenticationEventsStart + 0;
        public const int UserLoginFailure = AuthenticationEventsStart + 1;
        public const int UserLogout = AuthenticationEventsStart + 2;
    }
}