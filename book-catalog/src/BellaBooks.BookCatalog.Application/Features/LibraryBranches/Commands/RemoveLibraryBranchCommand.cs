using BellaBooks.BookCatalog.Application.Errors;
using CSharpFunctionalExtensions;
using MediatR;

namespace BellaBooks.BookCatalog.Application.Features.LibraryBranches.Commands;

public record RemoveLibraryBranchCommand : IRequest<
    UnitResult<ErrorResult>>
{
    public required string LibraryBranchCode { get; init; }
}
