using BellaBooks.BookCatalog.Api.Contracts.LibraryBranches;
using BellaBooks.BookCatalog.Api.EndpointGroups;
using BellaBooks.BookCatalog.Api.Extensions;
using BellaBooks.BookCatalog.Application.Features.LibraryBranches.Commands;
using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BellaBooks.BookCatalog.Api.Endpoints.LibraryBranches.EditLibraryBranchInfo;

internal class EditLibraryBranchInfoEndpoint : Endpoint<
    EditLibraryBranchInfoContracts.RequestDto,
    Results<Ok, ProblemHttpResult>>
{
    public override void Configure()
    {
        Post("EditLibraryBranchInfo");
        Group<LibraryBranchEndpointGroup>();
        AllowAnonymous();

        Summary(s =>
        {
            s.Summary = "Edit a library branch info";
            s.Description = "The endpoint will edit a library branch info";
        });

        Description(d => d
           .Produces<ErrorProblemDetails>(StatusCodes.Status422UnprocessableEntity));
    }

    public override async
        Task<Results<Ok, ProblemHttpResult>>
        ExecuteAsync(EditLibraryBranchInfoContracts.RequestDto req, CancellationToken ct)
    {
        var result = await new EditLibraryBranchInfoCommand
        {
            LibraryBranchCode = req.LibraryBranchCode,
            Name = req.Name,
        }.ExecuteAsync(ct);

        if (result.IsFailure)
        {
            return TypedResultsExtended.ErrorProblem(
                result.Error.Message, StatusCodes.Status422UnprocessableEntity, result.Error.Code);
        }

        return TypedResults.Ok();
    }
}
