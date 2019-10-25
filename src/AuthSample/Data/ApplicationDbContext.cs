using AuthSample.Data.Models;
using AuthSample.Features.Account.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AuthSample.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<BlacklistedRegistration> BlacklistedRegistrations { get; set; }

        public DbSet<EventLog> EventLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BlacklistedRegistration>(entity =>
            {
                entity.HasIndex(c => new { c.Email, c.Name })
                    .HasName("IX_Email_Name");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Reason)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<EventLog>(entity =>
            {
                entity.HasIndex(c => c.EventId)
                    .HasName("IX_EventId");

                entity.Property(e => e.EventCategory)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.EventName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.UserName)
                    .HasMaxLength(256);

                entity.Property(e => e.EventType)
                    .IsRequired();
            });
        }
    }
}
