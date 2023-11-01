using BellaBooks.BookCatalog.Domain.Books;
using BellaBooks.BookCatalog.Domain.Books.Commands;
using BellaBooks.BookCatalog.Infrastructure.Contexts;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BellaBooks.BookCatalog.Infrastructure.Books.CommandHandlers;

internal class GetBookDetailCommandHandler : ICommandHandler<
    GetBookDetailCommand,
    BookEntity?>
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
        BookEntity?>
        ExecuteAsync(GetBookDetailCommand command, CancellationToken ct)
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
                    .ThenInclude(libaryPrint => libaryPrint.LibraryBranch)
                .Include(book => book.BookAuthors)
                    .ThenInclude(ab => ab.Author)
                .Include(book => book.BookGenres)
                    .ThenInclude(bg => bg.Genre)
                .AsNoTracking()
                .SingleOrDefaultAsync(book => book.Id == command.BookId, ct);

            return book;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected error occurred while getting a book by Id");
            throw;
        }
    }
}
