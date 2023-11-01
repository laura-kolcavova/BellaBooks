using BellaBooks.BookCatalog.Api.Contracts.LibraryBranches;
using BellaBooks.BookCatalog.Api.EndpointGroups;
using BellaBooks.BookCatalog.Api.Extensions;
using BellaBooks.BookCatalog.Domain.LibraryBranches.Commands;
using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BellaBooks.BookCatalog.Api.Endpoints.LibraryBranches.DeactivateLibraryBranch;

public class DisableLibraryBranchEndpoint : Endpoint<
    DisableLibraryBranchContracts.RequestDto,
    Results<Ok, ProblemHttpResult>>
{
    public override void Configure()
    {
        Post("DisableLibraryBranch");
        Group<LibraryBranchEndpointGroup>();
        AllowAnonymous();

        Summary(s =>
        {
            s.Summary = "Disables a library branch";
            s.Description = "The endpoint will disable a library branch";
        });

        Description(d => d
           .Produces<ErrorProblemDetails>(StatusCodes.Status422UnprocessableEntity));
    }

    public override async
        Task<Results<Ok, ProblemHttpResult>>
        ExecuteAsync(DisableLibraryBranchContracts.RequestDto req, CancellationToken ct)
    {
        var result = await new DisableLibraryBranchCommand
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
