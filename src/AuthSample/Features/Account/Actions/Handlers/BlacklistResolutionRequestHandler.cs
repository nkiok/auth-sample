using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AuthSample.Data;
using AuthSample.Data.Models;
using AuthSample.Features.Account.Actions.Requests;
using AuthSample.Features.Events;
using AuthSample.Features.Validation;
using CSharpFunctionalExtensions;
using EnsureThat;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AuthSample.Features.Account.Actions.Handlers
{
    public class BlacklistResolutionRequestHandler : IRequestHandler<BlacklistResolutionRequest, Result>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public BlacklistResolutionRequestHandler(ApplicationDbContext applicationDbContext)
        {
            EnsureArg.IsNotNull(applicationDbContext, nameof(applicationDbContext));
            
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Result> Handle(BlacklistResolutionRequest request, CancellationToken cancellationToken)
        {
            var blacklisted = _applicationDbContext.BlacklistedRegistrations.AsNoTracking()
                .Where(b => b.Email == request.Model.Email && b.Name == request.Model.Name)
                .ToList();

            if (!blacklisted.Any())
            {
                var attempts = _applicationDbContext.EventLogs.AsNoTracking()
                    .OrderByDescending(l => l.Timestamp)
                    .Where(l => l.EventId == EventIds.AgeValidationFailure 
                                && l.EventType == EventTypes.Failure 
                                && l.UserId == request.Model.Email 
                                && l.UserName == request.Model.Name)
                    .Take(3)
                    .ToList();

                if (attempts.Count() == 3 &&
                    (attempts.First().Timestamp - attempts.Last().Timestamp) <= TimeSpan.FromMinutes(60))
                {
                    var blacklistedRegistration = new BlacklistedRegistration(request.Model.Name, request.Model.Email, ValidationMessages.AgeCheckBlacklistReason, DateTimeOffset.UtcNow);

                    await _applicationDbContext.AddAsync(blacklistedRegistration, cancellationToken);

                    await _applicationDbContext.SaveChangesAsync(cancellationToken);

                    blacklisted.Add(blacklistedRegistration);
                }
            }

            return blacklisted.Any()
                ? Result.Failure(string.Join(",", blacklisted.Select(b => b.Reason)))
                : Result.Ok();
        }
    }
}
