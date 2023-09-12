using BellaBooks.BookCatalog.Domain.Constants;
using BellaBooks.BookCatalog.Domain.Errors;

namespace BellaBooks.BookCatalog.Domain.LibraryPrints;

public static class LibraryPrintErrorResults
{
    public static ErrorResult LibraryPrintNotAdded =>
        new()
        {
            Code = ErrorCodes.LibraryPrints.LibaryPrintNotAdded,
            Message = "A library print was not added"
        };
}
