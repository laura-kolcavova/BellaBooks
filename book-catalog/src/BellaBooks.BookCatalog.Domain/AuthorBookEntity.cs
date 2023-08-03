using BellaBooks.BookCatalog.Domain.Authors;
using BellaBooks.BookCatalog.Domain.Books;

namespace BellaBooks.BookCatalog.Domain;

public class AuthorBookEntity : IEntity
{
    public int AuthorId { get; }

    public int BookId { get; }

    #region NavigationProperties

    public AuthorEntity Author { get; }

    public BookEntity Book { get; }

    #endregion NavigationProperties

    private AuthorBookEntity()
    {
        Author = null!;
        Book = null!;
    }

    public AuthorBookEntity(AuthorEntity author, BookEntity book)
    {
        Author = author;
        Book = book;
    }
}
