using BellaBooks.BookCatalog.Domain.Constants;
using BellaBooks.BookCatalog.Domain.Errors;

namespace BellaBooks.BookCatalog.Domain.LibraryPrints;

public static class LibraryPrintErrorResults
{
    public static ErrorResult LibraryPrintNotFound => new(
        ErrorCodes.LibraryPrints.LibraryPrintNotFound,
        "A library print was not found");

    public static ErrorResult LibraryPrintNotAdded => new(
        ErrorCodes.LibraryPrints.LibraryPrintNotAdded,
        "A library print was not added");

    public static ErrorResult LibraryPrintNotRemoved => new(
        ErrorCodes.LibraryPrints.LibraryPrintNotRemoved,
        "A library print was not removed");

    public static ErrorResult LibraryPrintStateIsSameAsNewOne => new(
        ErrorCodes.LibraryPrints.LibraryPrintStateIsSameAsNewOne,
        "A library print state cannot be changed because the library print has already set this state");

    public static ErrorResult LibraryPrintStateNotChanged => new(
        ErrorCodes.LibraryPrints.LibraryPrintStateNotChanged,
        "A library print state was not changed");

    public static ErrorResult LibraryPrintLocationIsSameAsNewOne => new(
        ErrorCodes.LibraryPrints.LibraryPrintLocationIsSameAsNewOne,
        "A library print location cannot be changed because the library print has already set this location");

    public static ErrorResult LibraryPrintLocationNotChanged => new(
        ErrorCodes.LibraryPrints.LibraryPrintLocationNotChanged,
        "A library print location was not changed");
}
