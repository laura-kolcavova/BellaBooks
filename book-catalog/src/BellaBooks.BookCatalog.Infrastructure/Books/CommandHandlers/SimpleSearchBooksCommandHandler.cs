using BellaBooks.BookCatalog.Bussiness.Books;
using BellaBooks.BookCatalog.Domain.Books;
using BellaBooks.BookCatalog.Domain.Books.Commands;
using BellaBooks.BookCatalog.Domain.Books.ReadModels;
using BellaBooks.BookCatalog.Infrastructure.Contexts;
using CSharpFunctionalExtensions;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace BellaBooks.BookCatalog.Infrastructure.Books.CommandHandlers;

internal class SimpleSearchBooksCommandHandler : ICommandHandler<
    SimpleSearchBooksCommand,
    ICollection<BookListingItemReadModel>>
{
    private readonly BookCatalogContext _bookCatalogContext;
    private readonly ILogger<SimpleSearchBooksCommandHandler> _logger;

    public SimpleSearchBooksCommandHandler(
        BookCatalogContext bookCatalogContext,
        ILogger<SimpleSearchBooksCommandHandler> logger)
    {
        _bookCatalogContext = bookCatalogContext;
        _logger = logger;
    }

    public async Task<
        ICollection<BookListingItemReadModel>>
        ExecuteAsync(SimpleSearchBooksCommand command, CancellationToken ct)
    {
        try
        {
            var query = _bookCatalogContext.Books
                .Include(book => book.Publisher)
                .Include(book => book.AuthorBooks)
                    .ThenInclude(ab => ab.Author)
                .Where(GetFilterExpression(command.SearchInput, command.Filter))
                .Select(book => new BookListingItemReadModel
                {
                    Id = book.Id,
                    Title = book.Title,
                    PublicaitonYear = book.PublicationInfo.Year,
                    PublicationCity = book.PublicationInfo.City,
                    PublicationLanguage = book.PublicationInfo.Language,
                    Publisher = book.Publisher!,
                    Authors = book.AuthorBooks
                        .Select(ab => ab.Author)
                        .ToList()
                })
                .AsNoTracking();

            var books = await query.ToListAsync(ct);

            return books;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"An unexpected error occurred while trying to search (simple) for books");
            throw;
        }
    }


    private static Expression<Func<BookEntity, bool>> GetFilterExpression(string searchInput, SimpleSearchFilter filter)
    {
        if (filter == SimpleSearchFilter.Title)
        {
            return (book) => book.Title.Contains(searchInput);
        }

        if (filter == SimpleSearchFilter.Isbn)
        {
            return (book) => book.PublicationInfo.Isbn == searchInput;
        }

        if (
           filter == SimpleSearchFilter.Author)
        {
            return (book) => book.AuthorBooks.Any(ab => ab.Author.Name.Contains(searchInput));
        }

        return (book) =>
            book.Title.Contains(searchInput) ||
            book.PublicationInfo.Isbn == searchInput ||
            book.AuthorBooks.Any(ab => ab.Author.Name.Contains(searchInput));
    }
}
