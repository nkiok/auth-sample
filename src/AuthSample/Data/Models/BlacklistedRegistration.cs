using System;
using EnsureThat;

namespace AuthSample.Data.Models
{
    public class BlacklistedRegistration
    {
        public BlacklistedRegistration(string name, string email, string reason, DateTimeOffset timestamp)
        {
            EnsureArg.IsNotNullOrWhiteSpace(name, nameof(name));
            EnsureArg.IsNotNullOrWhiteSpace(email, nameof(email));
            EnsureArg.IsNotNullOrWhiteSpace(reason, nameof(reason));

            Name = name;

            Email = email;

            Reason = reason;

            Timestamp = timestamp;
        }

        public int Id { get; protected set; }

        public string Name { get; protected set; }

        public string Email { get; protected set; }

        public string Reason { get; protected set; }

        public DateTimeOffset Timestamp { get; protected set; }
    }
}
