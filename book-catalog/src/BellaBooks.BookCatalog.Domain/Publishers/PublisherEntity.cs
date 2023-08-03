using BellaBooks.BookCatalog.Domain.Books;

namespace BellaBooks.BookCatalog.Domain.Publishers;

public class PublisherEntity : IEntity<int>, ITrackableEntity
{
    public int Id { get; }

    public string Name { get; }

    public DateTimeOffset? CreatedAt { get; }

    public DateTimeOffset? UpdatedAt { get; }

    #region NavigationProperties

    public ICollection<BookEntity> Books { get; }

    #endregion NavigationProperties

    protected PublisherEntity()
    {
        Name = string.Empty;
        Books = new List<BookEntity>();
    }

    public PublisherEntity(string name)
        : this()
    {
        Name = name;
    }
}
