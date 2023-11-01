using BellaBooks.BookCatalog.Domain.Books;
using BellaBooks.BookCatalog.Domain.Constants.LibraryPrints;
using BellaBooks.BookCatalog.Domain.LibraryBranches;

namespace BellaBooks.BookCatalog.Domain.LibraryPrints;

public class LibraryPrintEntity : IEntity<int>, ITrackableEntity
{
    public int Id { get; }

    public int BookId { get; }

    public string Shelfmark { get; private set; }

    public string LibraryBranchCode { get; private set; }

    public LibraryPrintStateCode StateCode { get; private set; }

    public DateTimeOffset? CreatedAt { get; }

    public DateTimeOffset? UpdatedAt { get; }

    #region NavigationProperties

    public BookEntity? Book { get; }

    public LibraryBranchEntity? LibraryBranch { get; }

    #endregion NavigationProperties

    public LibraryPrintEntity(
        int bookId,
        string libraryBranchCode,
        string shelfmark,
        LibraryPrintStateCode stateCode)
    {
        BookId = bookId;
        LibraryBranchCode = libraryBranchCode;
        Shelfmark = shelfmark;
        StateCode = stateCode;
    }

    public LibraryPrintEntity MoveToLocation(string libraryBranchCode, string shelfmark)
    {
        LibraryBranchCode = libraryBranchCode;
        Shelfmark = shelfmark;
        return this;
    }

    public LibraryPrintEntity ChangeState(LibraryPrintStateCode stateCode)
    {
        StateCode = stateCode;
        return this;
    }
}
