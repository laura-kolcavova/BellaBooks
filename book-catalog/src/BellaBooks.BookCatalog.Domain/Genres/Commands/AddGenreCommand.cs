using BellaBooks.BookCatalog.Domain.Errors;
using CSharpFunctionalExtensions;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Domain.Genres.Commands;

public record AddGenreCommand : ICommand<
    Result<int, ErrorResult>>
{
    public required string Name { get; init; }
}
