using BellaBooks.BookCatalog.Api.Contracts.Books;
using BellaBooks.BookCatalog.Api.EndpointGroups;
using BellaBooks.BookCatalog.Api.Extensions;
using BellaBooks.BookCatalog.Bussiness.Books.Commands;
using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BellaBooks.BookCatalog.Api.Endpoints.Books.AddBook;

public class AddBookEndpoint : Endpoint<
    AddBookDto.Request,
    Results<Ok<AddBookDto.Response>, ProblemHttpResult>,
    AddBookResponseMapper>
{
    public override void Configure()
    {
        Post("AddBook");
        Group<BooksEndpointGroup>();
        AllowAnonymous();

        Summary(s =>
        {
            s.Summary = "Add a new book to the catalog";
            s.Description = "The endpoint will add a new book to the catalog and return its Id";
        });

        Description(d => d
            .Produces<ProblemDetailResponse>(StatusCodes.Status422UnprocessableEntity));
    }

    public override async Task<
        Results<Ok<AddBookDto.Response>, ProblemHttpResult>>
        ExecuteAsync(AddBookDto.Request req, CancellationToken ct)
    {
        var result = await CreateAddBookCommand(req)
            .ExecuteAsync(ct);

        if (result.IsFailure)
        {
            return TypedResultsExtended.ProblemResponse(
                result.Error.Message, StatusCodes.Status422UnprocessableEntity, result.Error.Code);
        }

        return TypedResults.Ok(Map.FromEntity(result.Value));
    }

    private static AddBookCommand CreateAddBookCommand(AddBookDto.Request req)
    {
        return new AddBookCommand()
        {
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
