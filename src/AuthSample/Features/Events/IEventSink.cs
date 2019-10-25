using System.Threading.Tasks;

namespace AuthSample.Features.Events
{
    public interface IEventSink
    {
        Task PersistAsync(Event evt);
    }
}