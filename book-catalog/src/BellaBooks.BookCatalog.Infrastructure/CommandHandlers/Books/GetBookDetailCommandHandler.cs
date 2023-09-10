using BellaBooks.BookCatalog.Domain.Books;
using BellaBooks.BookCatalog.Domain.Books.Commands;
using BellaBooks.BookCatalog.Domain.Errors;
using BellaBooks.BookCatalog.Infrastructure.Contexts;
using CSharpFunctionalExtensions;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BellaBooks.BookCatalog.Infrastructure.CommandHandlers.Books;

internal class GetBookDetailCommandHandler : ICommandHandler<
    GetBookDetailCommand,
    Result<BookEntity, ErrorResult>>
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

    public async Task<Result<BookEntity, ErrorResult>> ExecuteAsync(GetBookDetailCommand command, CancellationToken ct)
    {
        using var loggerScope = _logger.BeginScope(new Dictionary<string, object>
        {
            ["BookId"] = command.BookId
        });

        try
        {
            var book = await _bookCatalogContext.Books
                .Include(book => book.Publisher)
                .Include(book => book.LibraryPrints)
                .Include(book => book.AuthorBooks)
                    .ThenInclude(ab => ab.Author)
                .Include(book => book.BookGenres)
                    .ThenInclude(bg => bg.Genre)
                .AsNoTracking()
                .SingleOrDefaultAsync(book => book.Id == command.BookId);

            if (book == null)
            {
                return Result.Failure<BookEntity, ErrorResult>
                    (GeneralErrorResults.EntityNotFound);
            }

            return book;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected error occurred while getting a book by Id");
            throw;
        }
    }
}
