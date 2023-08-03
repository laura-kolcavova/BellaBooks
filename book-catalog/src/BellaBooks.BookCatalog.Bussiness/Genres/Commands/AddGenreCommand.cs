using BellaBooks.BookCatalog.Domain.Errors;
using CSharpFunctionalExtensions;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Bussiness.Genres.Commands;

public class AddGenreCommand : ICommand<
    Result<int, ErrorResult>>
{
    public required string Name { get; init; }
}
