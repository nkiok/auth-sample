using System;
using System.Collections.Generic;
using System.Linq;
using AuthSample.Data;
using AuthSample.Features.Events;
using Microsoft.AspNetCore.Mvc;

namespace AuthSample
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ChartDataController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        private static readonly int[] EventsFilter =
        {
            EventIds.UserLoginSuccess,
            EventIds.UserLoginFailure
        };

        public class EventAggregate
        {
            public EventAggregate(EventTypes eventType, string eventName, int eventCount)
            {
                EventType = eventType;

                EventName = eventName;

                EventCount = eventCount;
            }

            public EventTypes EventType { get; }

            public string EventName { get; }

            public int EventCount { get; }

            public string Style
            {
                get
                {
                    switch (EventType)
                    {
                        case EventTypes.Success:
                            return "#28a745";
                        case EventTypes.Failure:
                            return "#dc3545";
                        case EventTypes.Information:
                            return "#17a2b8";
                        case EventTypes.Error:
                            return "red";
                        default:
                            return "#007bff";
                    }
                }
            }
        }

        public ChartDataController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IEnumerable<EventAggregate> Get()
        {
            var events = _dbContext.EventLogs
                .Where(e => e.Timestamp >= DateTimeOffset.UtcNow.AddDays(-30) && EventsFilter.Contains(e.EventId))
                .GroupBy(e => new {e.EventId, e.EventType, e.EventName})
                .OrderByDescending(g => g.Count())
                .Select(g => new EventAggregate(g.Key.EventType, g.Key.EventName, g.Count()));

            return events;
        }
    }
}