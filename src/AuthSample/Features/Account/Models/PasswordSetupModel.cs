using EnsureThat;

namespace AuthSample.Features.Account.Models
{
    public class PasswordSetupModel
    {
        public PasswordSetupModel(string password, string userId, string code)
        {
            EnsureArg.IsNotNullOrWhiteSpace(password, nameof(password));
            EnsureArg.IsNotNullOrWhiteSpace(userId, nameof(userId));
            EnsureArg.IsNotNullOrWhiteSpace(code, nameof(code));

            Password = password;

            UserId = userId;

            Code = code;
        }

        public string Password { get; set; }

        public string UserId { get; set; }

        public string Code { get; set; }
    }
}
