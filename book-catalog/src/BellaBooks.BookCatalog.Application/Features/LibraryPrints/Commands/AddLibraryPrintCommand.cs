using BellaBooks.BookCatalog.Application.Errors;
using CSharpFunctionalExtensions;
using MediatR;

namespace BellaBooks.BookCatalog.Application.Features.LibraryPrints.Commands;

public record AddLibraryPrintCommand : IRequest<
    Result<int, ErrorResult>>
{
    public required int BookId { get; init; }

    public required string LibraryBranchCode { get; init; }

    public required string Shelfmark { get; init; }
}
