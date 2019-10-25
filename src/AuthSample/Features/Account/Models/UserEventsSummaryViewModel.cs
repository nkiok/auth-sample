using System;
using System.Collections.Generic;
using AuthSample.Features.Events;

namespace AuthSample.Features.Account.Models
{
    public class UserEventsSummaryViewModel
    {
        public int EventId { get; }

        public string EventName { get; }

        public string EventCategory { get; }

        public EventTypes EventType { get; }

        public int NumberOfEvents { get; }

        public DateTimeOffset LastCaptured { get; }

        public IEnumerable<DateTimeOffset> EventTimestamps { get; }

        public string BootstrapClass
        {
            get
            {
                switch (EventType)
                {
                    case EventTypes.Success:
                        return "text-white bg-success mb-3";
                    case EventTypes.Failure:
                        return "text-white bg-danger mb-3";
                    case EventTypes.Information:
                        return "text-white bg-info mb-3";
                    case EventTypes.Error:
                        return "text-white bg-danger mb-3";
                    default:
                        return "bg-light mb-3";
                }
            }
        }

        public UserEventsSummaryViewModel(int eventId, string eventCategory, string eventName, EventTypes eventType, int numberOfEvents, DateTimeOffset lastCaptured, IEnumerable<DateTimeOffset> eventTimestamps)
        {
            EventId = eventId;

            EventCategory = eventCategory;

            EventName = eventName;

            EventType = eventType;

            NumberOfEvents = numberOfEvents;

            LastCaptured = lastCaptured;

            EventTimestamps = eventTimestamps;
        }
    }
}
