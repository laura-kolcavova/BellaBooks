using BellaBooks.BookCatalog.Domain.Authors;
using BellaBooks.BookCatalog.Domain.Errors;
using CSharpFunctionalExtensions;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Bussiness.Authors.Commands;

public record GetAuthorDetailCommand : ICommand<
     Result<AuthorEntity, ErrorResult>>
{
    public required int AuthorId { get; init; }
}
