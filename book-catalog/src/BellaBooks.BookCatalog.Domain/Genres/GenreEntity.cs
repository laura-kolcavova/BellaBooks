namespace BellaBooks.BookCatalog.Domain.Genres;

public class GenreEntity : IEntity<int>, ITrackableEntity
{
    public int Id { get; }

    public string Name { get; }

    public DateTimeOffset? CreatedAt { get; }

    public DateTimeOffset? UpdatedAt { get; }

    public IReadOnlyCollection<BookGenreEntity> BookGenres { get; }

    public GenreEntity(string name)
    {
        Name = name;
        BookGenres = new List<BookGenreEntity>();
    }
}
