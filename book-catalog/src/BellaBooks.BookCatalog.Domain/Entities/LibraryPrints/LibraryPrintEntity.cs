using BellaBooks.BookCatalog.Domain.Common;
using BellaBooks.BookCatalog.Domain.Constants.LibraryPrints;

namespace BellaBooks.BookCatalog.Domain.Entities.LibraryPrints;

public class LibraryPrintEntity : IEntity<int>, ITrackableEntity
{
    public int Id { get; }

    public int BookId { get; }

    public string Shelfmark { get; private set; }

    public string LibraryBranchCode { get; private set; }

    public LibraryPrintStateCode StateCode { get; private set; }

    public DateTimeOffset? CreatedAt { get; }

    public DateTimeOffset? UpdatedAt { get; }

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
