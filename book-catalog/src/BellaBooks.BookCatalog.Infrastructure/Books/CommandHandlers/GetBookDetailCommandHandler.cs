using BellaBooks.BookCatalog.Domain.Books.Commands;
using BellaBooks.BookCatalog.Domain.Books.ReadModels;
using BellaBooks.BookCatalog.Infrastructure.Contexts;
using BellaBooks.BookCatalog.Infrastructure.Extensions;
using Dapper;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Data;

namespace BellaBooks.BookCatalog.Infrastructure.Books.CommandHandlers;

internal class GetBookDetailCommandHandler : ICommandHandler<
    GetBookDetailCommand,
    BookDetailReadModel?>
{
    private readonly BookCatalogContext _bookCatalogContext;
    private readonly ILogger<GetBookDetailCommandHandler> _logger;

    public GetBookDetailCommandHandler(
        BookCatalogContext bookCatalogContext,
        ILogger<GetBookDetailCommandHandler> logger)
    {
        _bookCatalogContext = bookCatalogContext;
        _logger = logger;
    }

    public async Task<
        BookDetailReadModel?>
        ExecuteAsync(GetBookDetailCommand command, CancellationToken ct)
    {
        using var loggerScope = _logger.BeginScope(new Dictionary<string, object>
        {
            ["BookId"] = command.BookId
        });

        try
        {
            var connection = _bookCatalogContext.Database.GetDbConnection();

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
                WHERE B.[ID] = @bookId",
                new
                {
                    bookId = command.BookId,
                },
                commandType: CommandType.Text,
                cancellationToken: ct);

            var bookDetail = await connection.QueryFirstAsync<BookDetailReadModel>(sqlCommand);

            if (bookDetail == null)
            {
                return bookDetail;
            }

            bookDetail.Authors = await _bookCatalogContext.BookAuthors
                .Join(
                    _bookCatalogContext.Authors,
                    bookAuthor => bookAuthor.AuthorId,
                    author => author.Id,
                    (bookAuthor, author) => AuthorDetailReadModelExtensions.FromEntity(author))
                .ToListAsync(ct);

            bookDetail.Genres = await _bookCatalogContext.BookGenres
               .Join(
                    _bookCatalogContext.Genres,
                    bookGenre => bookGenre.GenreId,
                    genre => genre.Id, (bookGenre, genre) => GenreDetailReadModelExtensions.FromEntity(genre))
               .ToListAsync(ct);

            bookDetail.LibraryPrints = await _bookCatalogContext.LibraryPrints
                .Where(libaryPrint => libaryPrint.BookId == command.BookId)
                .Select(libraryPrint => LibraryPrintDetailReadModelExtensions.FromEntity(libraryPrint))
                .ToListAsync(ct);

            return bookDetail;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected error occurred while getting a book by Id");
            throw;
        }
    }
}
