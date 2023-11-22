namespace BellaBooks.BookCatalog.Domain.Common;

public interface ITrackableEntity
{
    DateTimeOffset? CreatedAt { get; }

    DateTimeOffset? UpdatedAt { get; }
}
