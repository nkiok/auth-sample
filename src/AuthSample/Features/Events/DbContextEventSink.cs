using System.Threading.Tasks;
using AuthSample.Data;
using AuthSample.Data.Models;
using AuthSample.Features.Account.Models;
using EnsureThat;

namespace AuthSample.Features.Events
{
    public class DbContextEventSink : IEventSink
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public DbContextEventSink(ApplicationDbContext applicationDbContext)
        {
            EnsureArg.IsNotNull(applicationDbContext, nameof(applicationDbContext));

            _applicationDbContext = applicationDbContext;
        }

        public async Task PersistAsync(Event evt)
        {
            var eventLog = new EventLog(evt.Id, evt.Category, evt.Name, evt.EventType, evt.TimeStamp);

            switch (evt)
            {
                case UserLoginFailureEvent userLoginFailureEvent:
                    eventLog.UserId = userLoginFailureEvent.UserId;
                    break;
                case UserLoginSuccessEvent userLoginSuccessEvent:
                    eventLog.UserId = userLoginSuccessEvent.UserId;
                    break;
                case UserLogoutEvent userLogoutSuccessEvent:
                    eventLog.UserId = userLogoutSuccessEvent.UserId;
                    break;
                case UserRegistrationAttemptSuccessEvent userRegistrationSuccessEvent:
                    eventLog.UserId = userRegistrationSuccessEvent.UserId;
                    break;
                case UserRegistrationAttemptFailureEvent userRegistrationAttemptFailureEvent:
                    eventLog.UserId = userRegistrationAttemptFailureEvent.UserId;
                    break;
                case UserRegistrationSuccessEvent userRegistrationSuccessEvent:
                    eventLog.UserId = userRegistrationSuccessEvent.UserId;
                    break;
                case UserRegistrationFailureEvent userRegistrationFailureEvent:
                    eventLog.UserId = userRegistrationFailureEvent.UserId;
                    break;
                case AgeValidationFailureEvent ageValidationFailureEvent:
                    eventLog.UserId = ageValidationFailureEvent.UserId;
                    break;
            }

            await _applicationDbContext.AddAsync(eventLog);

            await _applicationDbContext.SaveChangesAsync();
        }
    }
}
