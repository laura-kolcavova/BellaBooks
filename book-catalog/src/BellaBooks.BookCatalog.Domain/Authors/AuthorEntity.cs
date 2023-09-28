namespace BellaBooks.BookCatalog.Domain.Authors;

public class AuthorEntity : IEntity<int>, ITrackableEntity
{
    public int Id { get; }

    public string Name { get; }

    public DateTimeOffset? CreatedAt { get; }

    public DateTimeOffset? UpdatedAt { get; }

    #region NavigationProperties

    public IReadOnlyCollection<BookAuthorEntity> BookAuthors { get; }

    #endregion NavigationProperties

    public AuthorEntity(string name)
    {
        Name = name;
        BookAuthors = new List<BookAuthorEntity>();
    }
}
