using BellaBooks.BookCatalog.Domain.Books;

namespace BellaBooks.BookCatalog.Domain;

public class BookAuthorEntity : IEntity
{
    public int AuthorId { get; }

    public int BookId { get; }

    #region NavigationProperties

    public BookEntity Book { get; }

    #endregion NavigationProperties

    protected BookAuthorEntity(int bookId, int authorId)
    {
        BookId = bookId;
        AuthorId = authorId;
        Book = null!;
    }

    public BookAuthorEntity(BookEntity book, int authorId)
    {
        Book = book;
        BookId = book.Id;
        AuthorId = authorId;
    }
}
