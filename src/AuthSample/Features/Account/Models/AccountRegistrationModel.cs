using System;
using IdentityModel;

namespace AuthSample.Features.Account.Models
{
    public class AccountRegistrationModel
    {
        public AccountRegistrationModel(string name, string email, DateTime? dateOfBirth)
        {
            Name = name;

            Email = email;

            DateOfBirth = dateOfBirth;
        }

        public string Name { get; set; }

        public string Email { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string NormalizedName => Name?.ToUpperInvariant().ToSha256();

        public string NormalizedEmail => Email?.ToUpperInvariant().ToSha256();
    }
}
