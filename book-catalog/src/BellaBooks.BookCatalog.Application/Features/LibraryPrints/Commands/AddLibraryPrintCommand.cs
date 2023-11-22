using BellaBooks.BookCatalog.Application.Errors;
using CSharpFunctionalExtensions;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Application.Features.LibraryPrints.Commands;

public record AddLibraryPrintCommand : ICommand<
    Result<int, ErrorResult>>
{
    public required int BookId { get; init; }

    public required string LibraryBranchCode { get; init; }

    public required string Shelfmark { get; init; }
}
