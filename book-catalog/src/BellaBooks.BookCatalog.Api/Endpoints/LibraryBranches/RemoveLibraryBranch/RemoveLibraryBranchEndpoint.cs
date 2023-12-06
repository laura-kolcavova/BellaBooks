using BellaBooks.BookCatalog.Api.Contracts.LibraryBranches;
using BellaBooks.BookCatalog.Api.EndpointGroups;
using BellaBooks.BookCatalog.Api.Extensions;
using BellaBooks.BookCatalog.Application.Features.LibraryBranches.Commands;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BellaBooks.BookCatalog.Api.Endpoints.LibraryBranches.RemoveLibraryBranch;

public class RemoveLibraryBranchEndpoint : Endpoint<
    RemoveLibraryBranchContracts.RequestDto,
    Results<Ok, ProblemHttpResult>>
{
    public override void Configure()
    {
        Delete("RemoveLibraryBranch");
        Group<LibraryBranchEndpointGroup>();
        AllowAnonymous();

        Summary(s =>
        {
            s.Summary = "Removes a library branch";
            s.Description = "The endpoint will remove a library branch";
        });

        Description(d => d
           .Produces<ErrorProblemDetails>(StatusCodes.Status422UnprocessableEntity));
    }

    public override async
        Task<Results<Ok, ProblemHttpResult>>
        ExecuteAsync(RemoveLibraryBranchContracts.RequestDto req, CancellationToken ct)
    {
        var result = await new RemoveLibraryBranchCommand
        {
            LibraryBranchCode = req.LibraryBranchCode,
        }.ExecuteAsync(ct);

        if (result.IsFailure)
        {
            return TypedResultsExtended.ErrorProblem(
                result.Error.Message, StatusCodes.Status422UnprocessableEntity, result.Error.Code);
        }

        return TypedResults.Ok();
    }
}
