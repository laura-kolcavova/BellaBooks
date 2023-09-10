using BellaBooks.BookCatalog.Api.Contracts.Authors;
using BellaBooks.BookCatalog.Api.EndpointGroups;
using BellaBooks.BookCatalog.Bussiness.Authors.Commands;
using BellaBooks.BookCatalog.Domain.Constants;
using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BellaBooks.BookCatalog.Api.Endpoints.Authors.AddAuthor;

public class AddAuthorEndpoint : Endpoint<
    AddAuthorDto.Request,
    Results<Ok<AddAuthorDto.Response>, UnprocessableEntity>,
    AddAuthorResponseMapper>
{
    public override void Configure()
    {
        Post("AddAuthor");
        Group<AuthorsEndpointGroup>();
        AllowAnonymous();

        Summary(s =>
        {
            s.Summary = "Add a new author to the catalog";
            s.Description = "The endpoint will add a new author to the catalog and return its Id";
        });
    }

    public override async Task<
        Results<Ok<AddAuthorDto.Response>, UnprocessableEntity>>
        ExecuteAsync(AddAuthorDto.Request req, CancellationToken ct)
    {
        var result = await new AddAuthorCommand
        {
            Name = req.Name
        }.ExecuteAsync(ct);

        if (result.IsFailure)
        {
            return result.Error.Code switch
            {
                GeneralErrorCodes.EntityAlreadyExists or
                GeneralErrorCodes.NoChangesInDatabase or
                _ => TypedResults.UnprocessableEntity()
            };
        }

        return TypedResults.Ok(Map.FromEntity(result.Value));
    }
}
