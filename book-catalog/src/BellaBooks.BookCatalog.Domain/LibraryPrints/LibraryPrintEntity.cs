using BellaBooks.BookCatalog.Domain.Books;
using BellaBooks.BookCatalog.Domain.Constants.LibraryPrints;

namespace BellaBooks.BookCatalog.Domain.LibraryPrints;

public class LibraryPrintEntity : IEntity<int>, ITrackableEntity
{
    public int Id { get; }

    public int BookId { get; }

    public string Shelfmark { get; private set; }

    public string LibraryBrancheCode { get; private set; }

    public LibraryPrintStateCode StateCode { get; private set; }

    public DateTimeOffset? CreatedAt { get; }

    public DateTimeOffset? UpdatedAt { get; }

    #region NavigationProperties

    public BookEntity? Book { get; }

    #endregion NavigationProperties

    protected LibraryPrintEntity()
    {
        Shelfmark = string.Empty;
        LibraryBrancheCode = string.Empty;
        Book = null;
    }

    public LibraryPrintEntity(
        BookEntity book,
        string libraryBrancheCode,
        string shelfmark,
        LibraryPrintStateCode stateCode)
        : this()
    {
        Book = book;
        LibraryBrancheCode = libraryBrancheCode;
        Shelfmark = shelfmark;
        StateCode = stateCode;
    }

    public LibraryPrintEntity ChangeShelfLocation(string shelfmark)
    {
        Shelfmark = shelfmark;
        return this;
    }

    public LibraryPrintEntity ChangeLibraryBranche(string libraryBrancheCode, string shelfmark)
    {
        LibraryBrancheCode = libraryBrancheCode;
        Shelfmark = shelfmark;
        return this;
    }

    public LibraryPrintEntity ChangeState(LibraryPrintStateCode stateCode)
    {
        StateCode = stateCode;
        return this;
    }
}
