using BellaBooks.BookCatalog.Bussiness.Books.Commands;
using BellaBooks.BookCatalog.Domain.Books;
using BellaBooks.BookCatalog.Domain.Books.ValueObjects;
using BellaBooks.BookCatalog.Domain.Constants.Books;
using BellaBooks.BookCatalog.Domain.Errors;
using BellaBooks.BookCatalog.Infrastructure.Contexts;
using CSharpFunctionalExtensions;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BellaBooks.BookCatalog.Infrastructure.Books.CommandHandlers;

internal class AddBookCommandHandler : ICommandHandler<
    AddBookCommand, Result<int, ErrorResult>>
{
    private readonly BookCatalogContext _bookCatalogContext;
    private readonly ILogger<AddBookCommandHandler> _logger;

    public AddBookCommandHandler(
        BookCatalogContext bookCatalogContext,
        ILogger<AddBookCommandHandler> logger)
    {
        _bookCatalogContext = bookCatalogContext;
        _logger = logger;
    }

    public async Task<
        Result<int, ErrorResult>>
        ExecuteAsync(AddBookCommand command, CancellationToken ct)
    {
        using var loggerScope = _logger.BeginScope(new Dictionary<string, object>
        {
            ["Isbn"] = command.Isbn,
            ["PublisherId"] = command.PublisherId,
        });

        try
        {
            var bookWithIsbnExists = await _bookCatalogContext.Books
                .AnyAsync(book => book.PublicationInfo.Isbn == command.Isbn, ct);

            if (bookWithIsbnExists)
            {
                return Result.Failure<int, ErrorResult>(
                    BookWithIsbnAlreadyExists(command.Isbn));
            }

            var publisher = await _bookCatalogContext.Publishers
                .SingleOrDefaultAsync(publisher => publisher.Id == command.PublisherId, ct);

            if (publisher == null)
            {
                return Result.Failure<int, ErrorResult>(
                    PublisherNotFound(command.PublisherId));
            }

            var authors = await _bookCatalogContext.Authors
                .Where(author => command.AuthorIds.Contains(author.Id))
                .ToListAsync(ct);

            var genres = await _bookCatalogContext.Genres
                .Where(genre => command.GenreIds.Contains(genre.Id))
                .ToListAsync(ct);

            var newBook = new BookEntity(command.Title)
                .SetAuthors(authors)
                .SetGenres(genres)
                .SetPublisher(publisher)
                .SetPublicationInfo(new PublicationInfoValueObject()
                {
                    Isbn = command.Isbn,
                    Year = command.PublicationYear,
                    City = command.PublicationCity,
                    Language = command.PublicationLanguage
                })
                .SetFromatInfo(new FormatInfoValueObject()
                {
                    PageCount = command.PageCount,
                })
                .SetSummary(command.Summary);

            await _bookCatalogContext.Books
                .AddAsync(newBook, ct);

            var changes = await _bookCatalogContext.SaveChangesAsync(ct);

            if (changes == 0)
            {
                return Result.Failure<int, ErrorResult>(
                    BookNotAdded(command.Isbn));
            }

            return newBook.Id;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected error occurred while add a book to the catalog");
            throw;
        }

        throw new NotImplementedException();
    }

    private static ErrorResult BookWithIsbnAlreadyExists(string isbn) =>
        new ErrorResult(AddBookErrorCodes.BookWithIsbnAlreadyExists,
            $"A book with ISBN {isbn} already exists");

    private static ErrorResult PublisherNotFound(int publisherId) =>
        new ErrorResult(AddBookErrorCodes.PublisherNotFound,
            $"A publisher with Id {publisherId} was not found");

    private static ErrorResult BookNotAdded(string isbn) =>
       new ErrorResult(AddBookErrorCodes.BookNotAdded,
           $"Adding of book with Isbn {isbn} failed");
}
