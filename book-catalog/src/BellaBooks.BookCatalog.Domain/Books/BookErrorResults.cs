using BellaBooks.BookCatalog.Domain.Constants;
using BellaBooks.BookCatalog.Domain.Errors;

namespace BellaBooks.BookCatalog.Domain.Books;

public static class BookErrorResults
{
    public static ErrorResult BookNotFound => new(
        ErrorCodes.Books.BookNotFound,
        "A book was not found.");

    public static ErrorResult BookWithSameIsbnAlreadyExists => new(
        ErrorCodes.Books.BookWithIsbnAlreadyExists,
        "A book with same ISBN already exists.");

    public static ErrorResult NoAuthors => new(
        ErrorCodes.Books.NoAuthors,
        "A book has no authors.");

    public static ErrorResult BookNotAdded => new(
        ErrorCodes.Books.BookNotAdded,
        "A book was not added.");

    public static ErrorResult BookInfoNotUpdated => new(
        ErrorCodes.Books.BookInfoNotUpdated,
        "An information about book was not updated.");

    public static ErrorResult BookNotRemoved => new(
        ErrorCodes.Books.BookNotRemoved,
        "A book was not removed.");
}
