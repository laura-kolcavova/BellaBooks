using BellaBooks.BookCatalog.Api.Contracts.LibraryBranches;
using BellaBooks.BookCatalog.Api.EndpointGroups;
using BellaBooks.BookCatalog.Domain.LibraryBranches.Commands;
using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BellaBooks.BookCatalog.Api.Endpoints.LibraryBranches.GetLibraryBranches;

internal class GetLibraryBranchesEndpoint : EndpointWithoutRequest<
    Ok<GetLibraryBranchesContracts.ResponseDto>,
    GetLibraryBranchesResponseMapper>
{
    public override void Configure()
    {
        Get("GetLibraryBranches");
        Group<LibraryBranchEndpointGroup>();
        AllowAnonymous();

        Summary(s =>
        {

            s.Summary = "Gets collection of library branches";
            s.Description = "The endpoint will return collection of library branches";
        });
    }

    public override async Task<
        Ok<GetLibraryBranchesContracts.ResponseDto>>
        ExecuteAsync(CancellationToken ct)
    {
        var libraryBranches = await new GetLibraryBranchesCommand()
            .ExecuteAsync(ct);

        return TypedResults.Ok(Map.FromEntity(libraryBranches));
    }
}
