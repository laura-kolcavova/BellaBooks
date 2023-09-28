using BellaBooks.BookCatalog.Domain.Authors;
using BellaBooks.BookCatalog.Domain.Books.ValueObjects;
using BellaBooks.BookCatalog.Domain.Genres;
using BellaBooks.BookCatalog.Domain.LibraryPrints;
using BellaBooks.BookCatalog.Domain.Publishers;

namespace BellaBooks.BookCatalog.Domain.Books;

public class BookEntity : IEntity<int>, ITrackableEntity
{
    public int Id { get; }

    public int PublisherId { get; private set; }

    public string Title { get; private set; }

    public string? Summary { get; private set; }

    public PublicationInfoValueObject PublicationInfo { get; private set; }

    public FormatInfoValueObject FormatInfo { get; private set; }

    public DateTimeOffset? CreatedAt { get; }

    public DateTimeOffset? UpdatedAt { get; }

    #region NavigationProperties

    private List<BookGenreEntity> _bookGenres;

    private List<BookAuthorEntity> _bookAuthors;

    public PublisherEntity? Publisher { get; private set; }

    public IReadOnlyCollection<LibraryPrintEntity> LibraryPrints { get; }


    public IReadOnlyCollection<BookGenreEntity> BookGenres =>
        _bookGenres
            .ToList();

    public IReadOnlyCollection<BookAuthorEntity> BookAuthors =>
        _bookAuthors
            .ToList();

    #endregion NavigationProperties

    public BookEntity(string title)
    {
        Title = title;
        PublicationInfo = null!;
        FormatInfo = null!;

        LibraryPrints = new List<LibraryPrintEntity>();

        _bookGenres = new List<BookGenreEntity>();
        _bookAuthors = new List<BookAuthorEntity>();
    }

    public BookEntity SetTitle(string title)
    {
        Title = title;
        return this;
    }

    public BookEntity SetPublicationInfo(PublicationInfoValueObject publicationInfo)
    {
        PublicationInfo = publicationInfo;
        return this;
    }

    public BookEntity SetFormatInfo(FormatInfoValueObject formatInfo)
    {
        FormatInfo = formatInfo;
        return this;
    }

    public BookEntity SetSummary(string? summary)
    {
        Summary = summary;
        return this;
    }

    public BookEntity SetPublisher(int publisherId)
    {
        PublisherId = publisherId;
        return this;
    }

    public BookEntity SetPublisher(PublisherEntity publisher)
    {
        Publisher = publisher;
        return SetPublisher(publisher.Id);
    }

    public BookEntity SetAuthors(IEnumerable<AuthorEntity> authors)
    {
        if (!authors.Any())
        {
            throw new ArgumentException("Collection of authors must not be empty", nameof(authors));
        }

        var bookAuthors = authors
            .Select(author => new BookAuthorEntity(author, this))
            .ToList();

        _bookAuthors = bookAuthors;

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