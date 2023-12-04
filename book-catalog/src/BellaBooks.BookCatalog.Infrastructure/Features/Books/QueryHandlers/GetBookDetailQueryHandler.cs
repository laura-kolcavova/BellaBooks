using BellaBooks.BookCatalog.Application.Features.Authors.Queries;
using BellaBooks.BookCatalog.Application.Features.Books.Queries;
using BellaBooks.BookCatalog.Application.Features.Genres.Queries;
using BellaBooks.BookCatalog.Application.Features.LibraryPrints.Queries;
using BellaBooks.BookCatalog.Infrastructure.Contexts;
using Dapper;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Data;

namespace BellaBooks.BookCatalog.Infrastructure.Features.Books.QueryHandlers;

internal class GetBookDetailQueryHandler : ICommandHandler<
    GetBookDetailQuery,
    BookDetailReadModel?>
{
    private readonly BookCatalogContext _bookCatalogContext;
    private readonly ILogger<GetBookDetailQueryHandler> _logger;

    public GetBookDetailQueryHandler(
        BookCatalogContext bookCatalogContext,
        ILogger<GetBookDetailQueryHandler> logger)
    {
        _bookCatalogContext = bookCatalogContext;
        _logger = logger;
    }

    public async Task<
        BookDetailReadModel?>
        ExecuteAsync(GetBookDetailQuery command, CancellationToken ct)
    {
        using var loggerScope = _logger.BeginScope(new Dictionary<string, object>
        {
            ["BookId"] = command.BookId
        });

        try
        {
            var connection = _bookCatalogContext.Database.GetDbConnection();

            var sqlCommand = BuildSqlCommand(command.BookId, ct);

            using var result = await connection.QueryMultipleAsync(sqlCommand);

            var bookDetail = await result.ReadFirstOrDefaultAsync<BookDetailReadModel>();

            if (bookDetail == null)
            {
                return bookDetail;
            }

            bookDetail.Authors = (await result.ReadAsync<AuthorDetailReadModel>()).ToList();

            bookDetail.Genres = (await result.ReadAsync<GenreDetailReadModel>()).ToList();

            bookDetail.LibraryPrints = (await result.ReadAsync<LibraryPrintDetailReadModel>()).ToList();

            return bookDetail;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected error occurred while getting a book by Id");
            throw;
        }
    }

    private static CommandDefinition BuildSqlCommand(int bookId, CancellationToken cancellationToken)
    {
        var sqlCommand = new CommandDefinition(@"
                SELECT TOP 1
                     B.[Id]
                    ,B.[Title]
                    ,B.[Isbn]
                    ,B.[PublicationYear]
                    ,B.[PublicationCity]
                    ,B.[PublicationLanguage]
                    ,B.[PageCount]
                    ,B.[Summary]
                    ,P.[Id] AS PublisherId
                    ,P.[Name] AS PublisherName
                FROM [BookCatalog].[dbo].[Books] B
                INNER JOIN [Publishers] P ON P.[ID] = B.[PublisherId]
                WHERE B.[ID] = @bookId;

                SELECT A.[Id], A.[Name]
                FROM [BookAuthors] BA
                INNER JOIN [Authors] A ON A.[Id] = BA.[BookId]
                WHERE BA.[BookId] = @bookId

                SELECT G.[Id], G.[Name]
                FROM [BookGenres] BG
                INNER JOIN [Genres] G ON G.[Id] = BG.[GenreId]
                WHERE BG.[BookId] = @bookId

                SELECT
                     LP.[Id]
                    ,LP.[BookId]
                    ,LP.[LibraryBranchCode]
                    ,LP.[Shelfmark]
                    ,LP.[StateCode]
                FROM [LibraryPrints] LP
                WHERE LP.[BookId] = @bookId
                ",
                new
                {
                    bookId,
                },
                commandType: CommandType.Text,
                cancellationToken: cancellationToken);

        return sqlCommand;
    }
}
