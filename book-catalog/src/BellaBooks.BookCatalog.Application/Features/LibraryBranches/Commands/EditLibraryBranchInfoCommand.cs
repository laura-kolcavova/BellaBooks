using BellaBooks.BookCatalog.Application.Errors;
using CSharpFunctionalExtensions;
using MediatR;

namespace BellaBooks.BookCatalog.Application.Features.LibraryBranches.Commands;

public record EditLibraryBranchInfoCommand : IRequest<
    UnitResult<ErrorResult>>
{
    public required string LibraryBranchCode { get; init; }

    public required string Name { get; init; }
}
