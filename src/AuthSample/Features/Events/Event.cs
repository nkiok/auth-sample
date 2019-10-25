using System;
using System.Threading.Tasks;
using EnsureThat;

namespace AuthSample.Features.Events
{
    public abstract class Event
    {
        protected Event(string category, string name, int id, EventTypes type)
        {
            EnsureArg.IsNotNullOrWhiteSpace(category, nameof(category));
            EnsureArg.IsNotNullOrWhiteSpace(name, nameof(name));

            Category = category;

            Name = name;

            Id = id;

            EventType = type;
        }

        protected internal virtual Task PrepareAsync()
        {
            return Task.CompletedTask;
        }

        public int Id { get; set; }

        public string Category { get; set; }

        public string Name { get; set; }

        public EventTypes EventType { get; set; }

        public DateTimeOffset TimeStamp { get; set; }
    }
}