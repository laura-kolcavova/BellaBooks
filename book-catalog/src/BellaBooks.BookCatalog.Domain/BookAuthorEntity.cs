using BellaBooks.BookCatalog.Domain.Authors;
using BellaBooks.BookCatalog.Domain.Books;

namespace BellaBooks.BookCatalog.Domain;

public class BookAuthorEntity : IEntity
{
    public int AuthorId { get; }

    public int BookId { get; }

    #region NavigationProperties

    public AuthorEntity Author { get; }

    public BookEntity Book { get; }

    #endregion NavigationProperties

    public BookAuthorEntity(int authorId, int bookId)
    {
        AuthorId = authorId;
        BookId = bookId;
        Author = null!;
        Book = null!;
    }

    public BookAuthorEntity(AuthorEntity author, BookEntity book)
        : this(author.Id, book.Id)
    {
        AuthorId = author.Id;
        BookId = book.Id;
        Author = author;
        Book = book;
    }
}
