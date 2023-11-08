using BellaBooks.BookCatalog.Domain.LibraryPrints;
using BellaBooks.BookCatalog.Domain.LibraryPrints.ReadModels;

namespace BellaBooks.BookCatalog.Infrastructure.Extensions;

public static class LibraryPrintDetailReadModelExtensions
{
    public static LibraryPrintDetailReadModel FromEntity(LibraryPrintEntity entity)
    {
        return new LibraryPrintDetailReadModel
        {
            Id = entity.Id,
            BookId = entity.BookId,
            LibraryBranchCode = entity.LibraryBranchCode,
            Shelfmark = entity.Shelfmark,
            StateCode = entity.StateCode,
        };
    }
}
