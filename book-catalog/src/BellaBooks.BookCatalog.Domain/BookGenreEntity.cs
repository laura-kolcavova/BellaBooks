using BellaBooks.BookCatalog.Domain.Books;

namespace BellaBooks.BookCatalog.Domain;

public class BookGenreEntity : IEntity
{
    public int BookId { get; }

    public int GenreId { get; }

    #region NavigationProperties

    public BookEntity Book { get; }

    #endregion NavigationProperties

    public BookGenreEntity(BookEntity book, int genreId)
    {
        BookId = book.Id;
        GenreId = genreId;
        Book = book;
    }
}
