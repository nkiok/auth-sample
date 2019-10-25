using System.Linq;
using AuthSample.Data.Models;
using AuthSample.Features.Events;

namespace AuthSample.Data
{
    public static class ApplicationDbContextConvenience
    {
        public static IQueryable<EventLog> UserEvents(this ApplicationDbContext dbContext, string userId, string userName, int[] eventsFilter)
        {
            return 
                dbContext.EventLogs
                    .Where(e => e.EventCategory == EventCategories.Authentication
                                && (e.UserId == userId || e.UserId == userName)
                                && eventsFilter.Contains(e.EventId));
        }
    }
}