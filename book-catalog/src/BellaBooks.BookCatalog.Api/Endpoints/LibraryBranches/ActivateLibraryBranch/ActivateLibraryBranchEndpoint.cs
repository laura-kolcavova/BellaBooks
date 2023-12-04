using BellaBooks.BookCatalog.Api.Contracts.LibraryBranches;
using BellaBooks.BookCatalog.Api.EndpointGroups;
using BellaBooks.BookCatalog.Api.Extensions;
using BellaBooks.BookCatalog.Application.Features.LibraryBranches.Commands;
using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BellaBooks.BookCatalog.Api.Endpoints.LibraryBranches.ActivateLibraryBranch;

public class ActivateLibraryBranchEndpoint : Endpoint<
    ActivateLibraryBranchContracts.RequestDto,
    Results<Ok, ProblemHttpResult>>
{
    public override void Configure()
    {
        Post("ActivateLibraryBranch");
        Group<LibraryBranchEndpointGroup>();
        AllowAnonymous();

        Summary(s =>
        {
            s.Summary = "Activates a library branch";
            s.Description = "The endpoint will activate a library branch";
        });

        Description(d => d
           .Produces<ErrorProblemDetails>(StatusCodes.Status422UnprocessableEntity));
    }

    public override async
        Task<Results<Ok, ProblemHttpResult>>
        ExecuteAsync(ActivateLibraryBranchContracts.RequestDto req, CancellationToken ct)
    {
        var result = await new ActivateLibraryBranchCommand
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
