using BellaBooks.BookCatalog.Domain.Common;
using BellaBooks.BookCatalog.Domain.Entities.Books;

namespace BellaBooks.BookCatalog.Domain.Entities;

public class BookGenreEntity : IEntity
{
    public int BookId { get; }

    public int GenreId { get; }

    #region NavigationProperties

    public BookEntity Book { get; }

    #endregion NavigationProperties

    protected BookGenreEntity(int bookId, int genreId)
    {
        BookId = bookId;
        GenreId = genreId;
        Book = null!;
    }

    public BookGenreEntity(BookEntity book, int genreId)
    {
        BookId = book.Id;
        GenreId = genreId;
        Book = book;
    }
}
