using BellaBooks.BookCatalog.Application.Errors;
using BellaBooks.BookCatalog.Domain.Constants;

namespace BellaBooks.BookCatalog.Application.Features.Publishers;

public static class PublisherErrorResults
{
    public static ErrorResult PublisherNotFound => new(
        ErrorCodes.Publishers.PublisherNotFound,
        "A publisher was not found.");

    public static ErrorResult PublisherWithSameNameAlreadyExists => new(
        ErrorCodes.Publishers.PublisherWithSameNameAlreadyExists,
        "A publisher with same name already exists.");

    public static ErrorResult PublisherNotAdded => new(
        ErrorCodes.Publishers.PublisherNotAdded,
        "A publisher was not added.");

    public static ErrorResult PublisherInfoNotUpdated => new(
        ErrorCodes.Publishers.PublisherInfoNotUpdated,
        "An information about publisher was not updated.");

    public static ErrorResult PublisherNotRemoved => new(
        ErrorCodes.Publishers.PublisherNotRemoved,
        "A publisher was not removed.");
}
