using BellaBooks.BookCatalog.Domain.Constants.LibraryPrints;
using BellaBooks.BookCatalog.Domain.LibraryPrints.ReadModels;

namespace BellaBooks.BookCatalog.Api.Contracts.LibraryPrints;

public class LibraryPrintDetailDto
{
    public required int Id { get; init; }

    public required int BookId { get; init; }

    public required string Shelfmark { get; init; }

    public required string LibraryBranchCode { get; init; }

    public required LibraryPrintStateCode StateCode { get; init; }

    public static LibraryPrintDetailDto FromEntity(LibraryPrintDetailReadModel entity)
    {
        return new LibraryPrintDetailDto
        {
            Id = entity.Id,
            BookId = entity.BookId,
            Shelfmark = entity.Shelfmark,
            LibraryBranchCode = entity.LibraryBranchCode,
            StateCode = entity.StateCode,
        };
    }
}
