using BellaBooks.BookCatalog.Domain.Books;
using BellaBooks.BookCatalog.Domain.Genres;

namespace BellaBooks.BookCatalog.Domain;

public class BookGenreEntity : IEntity
{
    public int BookId { get; }

    public int GenreId { get; }

    #region NavigationProperties

    public BookEntity Book { get; }

    public GenreEntity Genre { get; }

    #endregion NavigationProperties

    private BookGenreEntity()
    {
        Book = null!;
        Genre = null!;
    }

    public BookGenreEntity(BookEntity book, GenreEntity genre)
    {
        Book = book;
        Genre = genre;
    }
}
