using BellaBooks.BookCatalog.Domain.Authors;
using BellaBooks.BookCatalog.Domain.Books.ValueObjects;
using BellaBooks.BookCatalog.Domain.Constants.LibraryPrints;
using BellaBooks.BookCatalog.Domain.Genres;
using BellaBooks.BookCatalog.Domain.LibraryPrints;
using BellaBooks.BookCatalog.Domain.Publishers;

namespace BellaBooks.BookCatalog.Domain.Books;

public class BookEntity : IEntity<int>, ITrackableEntity
{
    public int Id { get; }

    public int PublisherId { get; }

    public string Title { get; }

    public string? Summary { get; private set; }

    public PublicationInfoValueObject PublicationInfo { get; private set; }

    public FormatInfoValueObject FormatInfo { get; private set; }

    public DateTimeOffset? CreatedAt { get; }

    public DateTimeOffset? UpdatedAt { get; }

    #region NavigationProperties

    private List<BookGenreEntity> _bookGenres;

    private List<AuthorBookEntity> _authorBooks;

    public PublisherEntity? Publisher { get; private set; }

    public IReadOnlyCollection<LibraryPrintEntity> LibraryPrints { get; }


    public IReadOnlyCollection<BookGenreEntity> BookGenres =>
        _bookGenres
            .ToList();

    public IReadOnlyCollection<AuthorBookEntity> AuthorBooks =>
        _authorBooks
            .ToList();

    #endregion NavigationProperties

    protected BookEntity()
    {
        Title = string.Empty;

        PublicationInfo = new PublicationInfoValueObject()
        {
            Isbn = string.Empty,
            Year = 0,
            City = string.Empty,
            Language = string.Empty,
        };

        FormatInfo = new FormatInfoValueObject();

        LibraryPrints = new List<LibraryPrintEntity>();

        _bookGenres = new List<BookGenreEntity>();
        _authorBooks = new List<AuthorBookEntity>();
    }

    public BookEntity(string title)
        : this()
    {
        Title = title;
    }

    public bool IsAvailable =>
         LibraryPrints.Any(libraryPrint =>
            libraryPrint.StateCode == LibraryPrintStateCode.AV);

    public BookEntity SetPublicationInfo(PublicationInfoValueObject publicationInfo)
    {
        PublicationInfo = publicationInfo;
        return this;
    }

    public BookEntity SetFromatInfo(FormatInfoValueObject formatInfo)
    {
        FormatInfo = formatInfo;
        return this;
    }

    public BookEntity SetSummary(string summary)
    {
        Summary = summary;
        return this;
    }

    public BookEntity SetPublisher(PublisherEntity publisher)
    {
        Publisher = publisher;
        return this;
    }

    public BookEntity SetAuthors(IEnumerable<AuthorEntity> authors)
    {
        var authorBooks = authors
            .Select(author => new AuthorBookEntity(author, this))
            .ToList();

        _authorBooks = authorBooks;

        return this;
    }

    public BookEntity SetGenres(IEnumerable<GenreEntity> genres)
    {
        var bookGenres = genres
            .Select(genre => new BookGenreEntity(this, genre))
            .ToList();

        _bookGenres = bookGenres;

        return this;
    }
}