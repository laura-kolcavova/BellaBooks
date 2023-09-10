namespace BellaBooks.BookCatalog.Domain.Genres;

public class GenreEntity : IEntity<int>, ITrackableEntity
{
    public int Id { get; }

    public string Name { get; }

    public DateTimeOffset? CreatedAt { get; }

    public DateTimeOffset? UpdatedAt { get; }

    public IReadOnlyCollection<BookGenreEntity> BookGenres { get; }

    protected GenreEntity()
    {
        Name = string.Empty;
        BookGenres = new List<BookGenreEntity>();
    }

    public GenreEntity(string name)
        : this()
    {
        Name = name;
    }
}
