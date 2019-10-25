using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnsureThat;
using Microsoft.AspNetCore.Authentication;

namespace AuthSample.Features.Events
{
    public class DefaultEventService : IEventService
    {
        private readonly IEnumerable<IEventSink> _sinks;
        private readonly ISystemClock _clock;

        public DefaultEventService(IEnumerable<IEventSink> sinks, ISystemClock clock)
        {
            _sinks = sinks;

            _clock = clock;
        }

        public async Task RaiseAsync(Event evt)
        {
            EnsureArg.IsNotNull(evt, nameof(evt));

            await PrepareEventAsync(evt);

            await Task.WhenAll(_sinks.Select(s => s.PersistAsync(evt)));
        }

        protected virtual async Task PrepareEventAsync(Event evt)
        {
            evt.TimeStamp = _clock.UtcNow;

            await evt.PrepareAsync();
        }
    }
}