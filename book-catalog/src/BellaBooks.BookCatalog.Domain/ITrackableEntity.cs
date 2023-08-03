namespace BellaBooks.BookCatalog.Domain;

public interface ITrackableEntity
{
    DateTimeOffset? CreatedAt { get; }

    DateTimeOffset? UpdatedAt { get; }
}
