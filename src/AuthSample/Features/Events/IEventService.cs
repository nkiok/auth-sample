using System.Threading.Tasks;

namespace AuthSample.Features.Events
{
    public interface IEventService
    {
        Task RaiseAsync(Event evt);
    }
}