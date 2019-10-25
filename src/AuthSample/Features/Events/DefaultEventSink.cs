using System.Threading.Tasks;
using EnsureThat;
using Microsoft.Extensions.Logging;

namespace AuthSample.Features.Events
{
    public class DefaultEventSink : IEventSink
    {
        private readonly ILogger<DefaultEventSink> _logger;

        public DefaultEventSink(ILogger<DefaultEventSink> logger)
        {
            _logger = logger;
        }

        public Task PersistAsync(Event evt)
        {
            EnsureArg.IsNotNull(evt, nameof(evt));

            _logger.LogInformation("{timestamp} {@event}", evt.TimeStamp.ToString("O"), evt);

            return Task.CompletedTask;
        }
    }
}