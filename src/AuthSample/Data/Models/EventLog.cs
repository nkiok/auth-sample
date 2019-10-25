using System;
using AuthSample.Features.Events;

namespace AuthSample.Data.Models
{
    public class EventLog
    {
        public EventLog(int eventId, string eventCategory, string eventName, EventTypes eventType, DateTimeOffset timestamp)
        {
            EventId = eventId;

            EventCategory = eventCategory;

            EventName = eventName;

            EventType = eventType;

            Timestamp = timestamp;
        }

        public int Id { get; protected set; }

        public int EventId { get; protected set; }

        public string EventCategory { get; protected set; }

        public string EventName { get; protected set; }

        public EventTypes EventType { get; protected set; }

        public string UserId { get; set; }

        public string UserName { get; set; }

        public DateTimeOffset Timestamp { get; protected set; }
    }
}
