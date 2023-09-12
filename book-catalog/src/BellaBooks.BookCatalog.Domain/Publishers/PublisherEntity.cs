using BellaBooks.BookCatalog.Domain.Books;

namespace BellaBooks.BookCatalog.Domain.Publishers;

public class PublisherEntity : IEntity<int>, ITrackableEntity
{
    public int Id { get; }

    public string Name { get; }

    public DateTimeOffset? CreatedAt { get; }

    public DateTimeOffset? UpdatedAt { get; }

    #region NavigationProperties

    public IReadOnlyCollection<BookEntity> Books { get; }

    #endregion NavigationProperties

    public PublisherEntity(string name)
    {
        Name = name;
        Books = new List<BookEntity>();
    }
}
