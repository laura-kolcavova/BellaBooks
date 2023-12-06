using BellaBooks.BookCatalog.Application.Errors;
using CSharpFunctionalExtensions;
using MediatR;

namespace BellaBooks.BookCatalog.Application.Features.LibraryBranches.Commands;

public record AddLibraryBranchCommand : IRequest<
    Result<string, ErrorResult>>
{
    public required string LibraryBranchCode { get; init; }

    public required string Name { get; init; }
}
