using LibraNet.BookCatalog.Domain;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace LibraNet.BookCatalog.Infrastructure
{
    public abstract class BaseDbContext<TContext> : DbContext
        where TContext : DbContext
    {
        protected BaseDbContext(DbContextOptions<TContext> options)
        : base(options)
        {
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            UpdateTrackingFields();

            var validationErrors = ChangeTracker
               .Entries<IValidatableObject>()
               .SelectMany(e => e.Entity.Validate(null!))
               .Where(r => r != ValidationResult.Success);

            if (validationErrors.Any())
            {
                var errorMessage = validationErrors
                   .Select(v => v.ErrorMessage)
                   .Aggregate((current, next) => current + Environment.NewLine + next);

                throw new ValidationException(errorMessage);
            }

            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            UpdateTrackingFields();

            return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public void UpdateTrackingFields()
        {
            var now = DateTimeOffset.UtcNow;

            foreach (var entry in ChangeTracker.Entries<ITrackableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                    {
                        entry.Property(p => p.UpdatedAt).CurrentValue = now;
                        break;
                    }
                    case EntityState.Added:
                    {
                        var currentValue = entry.Property(p => p.CreatedAt).CurrentValue;

                        if (currentValue == null)
                        {
                            entry.Property(p => p.CreatedAt).CurrentValue = now;
                        }

                        break;
                    }
                }
            }
        }
    }
}
