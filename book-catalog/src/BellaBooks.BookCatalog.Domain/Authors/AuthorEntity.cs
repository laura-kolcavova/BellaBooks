namespace BellaBooks.BookCatalog.Domain.Authors;

public class AuthorEntity : IEntity<int>, ITrackableEntity
{
    public int Id { get; }

    public string Name { get; }

    public DateTimeOffset? CreatedAt { get; }

    public DateTimeOffset? UpdatedAt { get; }

    #region NavigationProperties

    public IReadOnlyCollection<AuthorBookEntity> AuthorBooks { get; }

    #endregion NavigationProperties

    protected AuthorEntity()
    {
        Name = string.Empty;
        AuthorBooks = new List<AuthorBookEntity>();
    }

    public AuthorEntity(string name)
        : this()
    {
        Name = name;
    }
}
