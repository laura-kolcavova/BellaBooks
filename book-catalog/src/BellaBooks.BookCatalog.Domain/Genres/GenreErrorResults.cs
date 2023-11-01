using BellaBooks.BookCatalog.Domain.Constants;
using BellaBooks.BookCatalog.Domain.Errors;

namespace BellaBooks.BookCatalog.Domain.Genres;

public static class GenreErrorResults
{
    public static ErrorResult GenreNotFound => new(
        ErrorCodes.Genres.GenreNotFound,
        "A genre was not found.");

    public static ErrorResult GenreWithSameNameAlreadyExists => new(
        ErrorCodes.Genres.GenreWithSameNameAlreadyExists,
        "A genre with same name already exists.");

    public static ErrorResult GenreNotAdded => new(
        ErrorCodes.Genres.GenreNotAdded,
        "A genre was not added.");

    public static ErrorResult GenreInfoNotUpdated => new(
        ErrorCodes.Genres.GenreInfoNotUpdated,
        "An information about genre was not updated.");

    public static ErrorResult GenreNotRemoved => new(
        ErrorCodes.Genres.GenreNotRemoved,
        "A genre was not removed.");
}
