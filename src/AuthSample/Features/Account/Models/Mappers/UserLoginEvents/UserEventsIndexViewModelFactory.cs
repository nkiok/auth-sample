using System.Linq;
using AuthSample.Data.Models;

namespace AuthSample.Features.Account.Models.Mappers.UserLoginEvents
{
    public static class UserEventsIndexViewModelFactory
    {
        public static UserEventsIndexViewModel Create(string userId, IQueryable<EventLog> eventLogs)
        {
            var data = eventLogs.ToList();

            var summaries = data
                .GroupBy(e => new {e.EventId, e.EventType, e.EventCategory, e.EventName})
                .Select(g => UserEventsSummaryViewModelFactory.Create(g.Key.EventId, g.Key.EventCategory,
                    g.Key.EventName, g.Key.EventType, g.Count(), g.Max(e => e.Timestamp),
                    data.Where(d => d.EventId == g.Key.EventId).Select(d => d.Timestamp)));

            return new UserEventsIndexViewModel(userId, summaries);
        }
    }
}
