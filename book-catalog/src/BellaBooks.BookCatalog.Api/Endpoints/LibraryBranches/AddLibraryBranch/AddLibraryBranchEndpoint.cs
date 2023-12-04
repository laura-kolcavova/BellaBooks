using BellaBooks.BookCatalog.Api.Contracts.LibraryBranches;
using BellaBooks.BookCatalog.Api.EndpointGroups;
using BellaBooks.BookCatalog.Api.Extensions;
using BellaBooks.BookCatalog.Application.Features.LibraryBranches.Commands;
using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BellaBooks.BookCatalog.Api.Endpoints.LibraryBranches.AddLibraryBranch;

internal class AddLibraryBranchEndpoint : Endpoint<
    AddLibraryBranchContracts.RequestDto,
    Results<Ok<AddLibraryBranchContracts.ResponseDto>, ProblemHttpResult>,
    AddLibraryBranchResponseMapper>
{
    public override void Configure()
    {
        Post("AddLibraryBranch");
        Group<LibraryBranchEndpointGroup>();
        AllowAnonymous();

        Summary(s =>
        {
            s.Summary = "Adds a library branch";
            s.Description = "The endpoint will add a library branch to the catalog";
        });

        Description(d => d
           .Produces<ErrorProblemDetails>(StatusCodes.Status422UnprocessableEntity));
    }

    public override async
        Task<Results<Ok<AddLibraryBranchContracts.ResponseDto>, ProblemHttpResult>>
        ExecuteAsync(AddLibraryBranchContracts.RequestDto req, CancellationToken ct)
    {
        var result = await new AddLibraryBranchCommand
        {
            LibraryBranchCode = req.LibraryBranchCode,
            Name = req.Name,
        }.ExecuteAsync(ct);

        if (result.IsFailure)
        {
            return TypedResultsExtended.ErrorProblem(
                result.Error.Message, StatusCodes.Status422UnprocessableEntity, result.Error.Code);
        }

        return TypedResults.Ok(Map.FromEntity(result.Value));
    }
}
