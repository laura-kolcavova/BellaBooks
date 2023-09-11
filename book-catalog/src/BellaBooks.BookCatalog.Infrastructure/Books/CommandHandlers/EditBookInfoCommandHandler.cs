using BellaBooks.BookCatalog.Bussiness.Books.Commands;
using BellaBooks.BookCatalog.Domain.Books.ValueObjects;
using BellaBooks.BookCatalog.Domain.Constants.Books;
using BellaBooks.BookCatalog.Domain.Errors;
using BellaBooks.BookCatalog.Infrastructure.Contexts;
using CSharpFunctionalExtensions;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BellaBooks.BookCatalog.Infrastructure.Books.CommandHandlers;

internal class EditBookInfoCommandHandler : ICommandHandler<
    EditBookInfoCommand, UnitResult<ErrorResult>>
{
    private readonly BookCatalogContext _bookCatalogContext;
    private readonly ILogger<EditBookInfoCommandHandler> _logger;

    public EditBookInfoCommandHandler(
        BookCatalogContext bookCatalogContext,
        ILogger<EditBookInfoCommandHandler> logger)
    {
        _bookCatalogContext = bookCatalogContext;
        _logger = logger;
    }

    public async Task<
        UnitResult<ErrorResult>>
        ExecuteAsync(EditBookInfoCommand command, CancellationToken ct)
    {
        using var loggerScope = _logger.BeginScope(new Dictionary<string, object>
        {
            ["BookId"] = command.BookId,
            ["Isbn"] = command.Isbn,
        });

        try
        {
            var book = await _bookCatalogContext.Books
                .Include(book => book.AuthorBooks)
                .Include(book => book.BookGenres)
                .SingleOrDefaultAsync(book => book.Id == command.BookId, ct);

            if (book == null)
            {
                return UnitResult.Failure(BookNotFound(command.BookId));
            }

            if (book.PublicationInfo.Isbn != command.Isbn)
            {
                var bookWithIsbnExists = await _bookCatalogContext.Books
                    .AnyAsync(book => book.PublicationInfo.Isbn == command.Isbn, ct);

                if (bookWithIsbnExists)
                {
                    return Result.Failure<int, ErrorResult>(
                        BookWithIsbnAlreadyExists(command.Isbn));
                }
            }

            if (book.PublisherId != command.PublisherId)
            {
                var publisher = await _bookCatalogContext.Publishers
                    .SingleOrDefaultAsync(publisher => publisher.Id == command.PublisherId, ct);

                if (publisher == null)
                {
                    return Result.Failure<int, ErrorResult>(
                        PublisherNotFound(command.PublisherId));
                }

                book.SetPublisher(publisher);
            }

            if (command.AuthorIds.Count == 0)
            {
                return Result.Failure<int, ErrorResult>(
                       NoAuthors());
            }

            var authors = await _bookCatalogContext.Authors
                .Where(author => command.AuthorIds.Contains(author.Id))
                .ToListAsync(ct);

            var genres = await _bookCatalogContext.Genres
                .Where(genre => command.GenreIds.Contains(genre.Id))
                .ToListAsync(ct);

            book
                .SetTitle(command.Title)
                .SetAuthors(authors)
                .SetGenres(genres)
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

            _bookCatalogContext.Books
                .Update(book);

            var changes = await _bookCatalogContext.SaveChangesAsync(ct);

            if (changes == 0)
            {
                return Result.Failure<int, ErrorResult>(
                    BookNotUpdated());
            }

            return UnitResult.Success<ErrorResult>();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected error occurred while updating a book info");
            throw;
        }
    }

    private static ErrorResult BookNotFound(int bookId) =>
       new(EditBookInfoErrorCodes.BookNotFound,
           $"A book with Id {bookId} was not found.");


    private static ErrorResult BookWithIsbnAlreadyExists(string isbn) =>
        new(EditBookInfoErrorCodes.BookWithIsbnAlreadyExists,
            $"A book with ISBN {isbn} already exists.");

    private static ErrorResult PublisherNotFound(int publisherId) =>
        new(EditBookInfoErrorCodes.PublisherNotFound,
            $"A publisher with Id {publisherId} was not found.");

    private static ErrorResult NoAuthors() =>
        new(EditBookInfoErrorCodes.NoAuthors,
            $"A book has to have at least one author.");

    private static ErrorResult BookNotUpdated() =>
       new(EditBookInfoErrorCodes.BookNotUpdated,
           $"A book was not updated.");
}
