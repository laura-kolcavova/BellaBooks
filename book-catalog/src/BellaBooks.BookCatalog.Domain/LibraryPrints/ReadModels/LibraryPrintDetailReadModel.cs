using BellaBooks.BookCatalog.Domain.Constants.LibraryPrints;

namespace BellaBooks.BookCatalog.Domain.LibraryPrints.ReadModels;

public class LibraryPrintDetailReadModel
{
    public required int Id { get; init; }

    public required int BookId { get; init; }

    public required string Shelfmark { get; init; }

    public required string LibraryBranchCode { get; init; }

    public required LibraryPrintStateCode StateCode { get; init; }
}
