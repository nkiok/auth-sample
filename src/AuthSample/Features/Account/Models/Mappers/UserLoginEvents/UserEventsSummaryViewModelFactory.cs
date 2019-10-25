using System;
using System.Collections.Generic;
using AuthSample.Features.Events;

namespace AuthSample.Features.Account.Models.Mappers.UserLoginEvents
{
    public static class UserEventsSummaryViewModelFactory
    {
        public static UserEventsSummaryViewModel Create(int eventId, string eventCategory, string eventName, EventTypes eventType, int numberOfEvents, DateTimeOffset lastCaptured, IEnumerable<DateTimeOffset> eventTimestamps)
        {
            return new UserEventsSummaryViewModel(eventId, eventCategory, eventName, eventType, numberOfEvents, lastCaptured, eventTimestamps);
        }
    }
}
