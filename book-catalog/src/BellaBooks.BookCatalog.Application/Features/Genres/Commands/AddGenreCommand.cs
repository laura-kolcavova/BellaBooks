using BellaBooks.BookCatalog.Application.Errors;
using CSharpFunctionalExtensions;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Application.Features.Genres.Commands;

public record AddGenreCommand : ICommand<
    Result<int, ErrorResult>>
{
    public required string Name { get; init; }
}
