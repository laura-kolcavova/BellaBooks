using BellaBooks.BookCatalog.Application.Errors;
using BellaBooks.BookCatalog.Domain.Constants;

namespace BellaBooks.BookCatalog.Application.Features.Genres;

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
