using System.Collections.Generic;

namespace AuthSample.Features.Account.Models
{
    public class UserEventsIndexViewModel
    {
        public string UserId { get; }

        public IEnumerable<UserEventsSummaryViewModel> Summaries { get; }

        public UserEventsIndexViewModel(string userId, IEnumerable<UserEventsSummaryViewModel> summaries)
        {
            UserId = userId;

            Summaries = summaries;
        }
    }
}
