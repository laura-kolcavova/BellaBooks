using BellaBooks.BookCatalog.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace BellaBooks.BookCatalog.Infrastructure.Common;

internal abstract class BaseDbContext<TContext> : DbContext
    where TContext : DbContext
{
    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        UpdateTrackingFields();
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
