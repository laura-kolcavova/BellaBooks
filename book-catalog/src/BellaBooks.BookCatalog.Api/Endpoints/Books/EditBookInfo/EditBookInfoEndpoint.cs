using BellaBooks.BookCatalog.Api.Contracts.Books;
using BellaBooks.BookCatalog.Api.EndpointGroups;
using BellaBooks.BookCatalog.Api.Extensions;
using BellaBooks.BookCatalog.Bussiness.Books.Commands;
using BellaBooks.BookCatalog.Domain.Constants.Books;
using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BellaBooks.BookCatalog.Api.Endpoints.Books.EditBookInfo;

public class EditBookInfoEndpoint : Endpoint<
    EditBookInfoDto.Request,
    Results<Ok, ProblemHttpResult>>
{
    public override void Configure()
    {
        Post("EditBookInfo");
        Group<BooksEndpointGroup>();
        AllowAnonymous();

        Summary(s =>
        {
            s.Summary = "Edits a book info";
            s.Description = "The endpoint will edit a book info";
        });

        Description(d => d
            .Produces<ProblemDetailResponse>(StatusCodes.Status404NotFound)
            .Produces<ProblemDetailResponse>(StatusCodes.Status422UnprocessableEntity));
    }

    public override async Task<
        Results<Ok, ProblemHttpResult>>
        ExecuteAsync(EditBookInfoDto.Request req, CancellationToken ct)
    {
        var result = await CreateEditBookInfoCommand(req)
            .ExecuteAsync(ct);

        if (result.IsFailure)
        {
            return result.Error.Code switch
            {
                EditBookInfoErrorCodes.BookNotFound
                    => TypedResultsExtended.ProblemResponse(
                        result.Error.Message, StatusCodes.Status404NotFound, result.Error.Code),

                _ => TypedResultsExtended.ProblemResponse(
                    result.Error.Message, StatusCodes.Status422UnprocessableEntity, result.Error.Code)
            };
        }

        return TypedResults.Ok();
    }

    private static EditBookInfoCommand CreateEditBookInfoCommand(EditBookInfoDto.Request req)
    {
        return new EditBookInfoCommand()
        {
            BookId = req.BookId,
            Title = req.Title,
            AuthorIds = req.AuthorIds,
            GenreIds = req.GenreIds,
            PublisherId = req.PublisherId,
            Isbn = req.Isbn,
            PublicationYear = req.PublicationYear,
            PublicationCity = req.PublicationCity,
            PublicationLanguage = req.PublicationLanguage,
            PageCount = req.PageCount,
            Summary = req.Summary,
        };
    }
}
