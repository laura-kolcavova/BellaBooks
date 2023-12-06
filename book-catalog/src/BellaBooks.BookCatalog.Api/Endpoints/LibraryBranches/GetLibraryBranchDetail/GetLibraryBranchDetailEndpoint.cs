using BellaBooks.BookCatalog.Api.Contracts.LibraryBranches;
using BellaBooks.BookCatalog.Api.EndpointGroups;
using BellaBooks.BookCatalog.Application.Features.LibraryBranches.Queries;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BellaBooks.BookCatalog.Api.Endpoints.LibraryBranches.GetLibraryBranchDetail;

internal class GetLibraryBranchDetailEndpoint : Endpoint<
    GetLibraryBranchDetailContracts.RequestDto,
    Ok<GetLibraryBranchDetailContracts.ResponseDto>,
    GetLibraryBranchDetailResponseMapper>
{
    public override void Configure()
    {
        Get("GetLibraryBranchDetail/{libraryBranchCode}");
        Group<LibraryBranchEndpointGroup>();
        AllowAnonymous();

        Summary(s =>
        {
            s.Summary = "Gets a library branch detail by its code";
            s.Description = "The endpoint will return a library branch detail";
        });
    }

    public override async Task<
        Ok<GetLibraryBranchDetailContracts.ResponseDto>>
        ExecuteAsync(GetLibraryBranchDetailContracts.RequestDto req, CancellationToken ct)
    {
        var result = await new GetLibraryBranchDetailQuery()
        {
            LibraryBranchCode = req.LibraryBranchCode,
        }.ExecuteAsync(ct);

        return TypedResults.Ok(Map.FromEntity(result));
    }
}
