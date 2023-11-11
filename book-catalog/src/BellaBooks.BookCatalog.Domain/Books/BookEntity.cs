using BellaBooks.BookCatalog.Domain.Books.ValueObjects;
using BellaBooks.BookCatalog.Domain.LibraryPrints;

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

    private readonly List<BookGenreEntity> _bookGenres;

    private readonly List<BookAuthorEntity> _bookAuthors;

    public IReadOnlyCollection<LibraryPrintEntity> LibraryPrints { get; }


    public IReadOnlyCollection<BookGenreEntity> BookGenres =>
        _bookGenres;

    public IReadOnlyCollection<BookAuthorEntity> BookAuthors =>
        _bookAuthors;

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

    public BookEntity SetAuthors(IEnumerable<int> authorIds)
    {
        if (!authorIds.Any())
        {
            throw new ArgumentException("Collection of authors must not be empty", nameof(authorIds));
        }

        var bookAuthors = authorIds
            .Select(authorId => new BookAuthorEntity(this, authorId));

        _bookAuthors.Clear();
        _bookAuthors.AddRange(_bookAuthors);

        return this;
    }


    public BookEntity SetGenres(IEnumerable<int> genreIds)
    {
        var bookGenres = genreIds
            .Select(genreId => new BookGenreEntity(this, genreId));

        _bookGenres.Clear();
        _bookGenres.AddRange(bookGenres);

        return this;
    }
}