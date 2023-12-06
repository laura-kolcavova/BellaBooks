using BellaBooks.BookCatalog.Application.Errors;
using CSharpFunctionalExtensions;
using MediatR;

namespace BellaBooks.BookCatalog.Application.Features.Genres.Commands;

public record AddGenreCommand : IRequest<
    Result<int, ErrorResult>>
{
    public required string Name { get; init; }
}
