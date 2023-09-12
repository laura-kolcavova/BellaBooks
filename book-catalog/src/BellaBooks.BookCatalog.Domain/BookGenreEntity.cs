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

    public BookGenreEntity(int bookId, int genreId)
    {
        BookId = bookId;
        GenreId = genreId;
        Book = null!;
        Genre = null!;
    }

    public BookGenreEntity(BookEntity book, GenreEntity genre)
    {
        BookId = book.Id;
        GenreId = genre.Id;
        Book = book;
        Genre = genre;
    }
}
