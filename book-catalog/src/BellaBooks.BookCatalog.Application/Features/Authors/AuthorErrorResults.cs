using BellaBooks.BookCatalog.Application.Errors;
using BellaBooks.BookCatalog.Domain.Constants;

namespace BellaBooks.BookCatalog.Application.Features.Authors;

public static class AuthorErrorResults
{
    public static ErrorResult AuthorNotFound => new(
        ErrorCodes.Authors.AuthorNotFound,
        "An author was not found.");

    public static ErrorResult AuthorWithSameNameAlreadyExists => new(
        ErrorCodes.Authors.AuthorWithSameNameAlreadyExists,
        "An author with same name already exists.");

    public static ErrorResult AuthorNotAdded => new(
        ErrorCodes.Authors.AuthorNotAdded,
        "An author was not added.");

    public static ErrorResult AuthorInfoNotUpdated => new(
        ErrorCodes.Authors.AuthorInfoNotUpdated,
        "An information about author was not updated.");

    public static ErrorResult AuthorNotRemoved => new(
        ErrorCodes.Authors.AuthorNotRemoved,
        "An author was not removed.");
}
