using BellaBooks.BookCatalog.Domain.Common;

namespace BellaBooks.BookCatalog.Domain.Entities.Authors;

public class AuthorEntity : IEntity<int>, ITrackableEntity
{
    public int Id { get; }

    public string Name { get; }

    public DateTimeOffset? CreatedAt { get; }

    public DateTimeOffset? UpdatedAt { get; }

    public AuthorEntity(string name)
    {
        Name = name;
    }
}
