using BellaBooks.BookCatalog.Application.Errors;
using CSharpFunctionalExtensions;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Application.Features.Books.Commands;

public record AddBookCommand : ICommand<
    Result<int, ErrorResult>>
{
    public required string Title { get; init; }

    public required IReadOnlyCollection<int> AuthorIds { get; init; }

    public required IReadOnlyCollection<int> GenreIds { get; init; }

    public required int PublisherId { get; init; }

    public required string Isbn { get; init; }

    public required short PublicationYear { get; init; }

    public required string PublicationCity { get; init; }

    public required string PublicationLanguage { get; init; }

    public required short? PageCount { get; init; }

    public required string? Summary { get; init; }
}
