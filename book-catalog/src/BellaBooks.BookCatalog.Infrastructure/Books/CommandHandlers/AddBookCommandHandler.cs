using BellaBooks.BookCatalog.Domain.Books;
using BellaBooks.BookCatalog.Domain.Books.Commands;
using BellaBooks.BookCatalog.Domain.Books.ValueObjects;
using BellaBooks.BookCatalog.Domain.Errors;
using BellaBooks.BookCatalog.Domain.Publishers;
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
        });

        try
        {
            var bookWithIsbnExists = await _bookCatalogContext.Books
                .AnyAsync(book => book.PublicationInfo.Isbn == command.Isbn, ct);

            if (bookWithIsbnExists)
            {
                return Result.Failure<int, ErrorResult>(
                    BookErrorResults.BookWithSameIsbnAlreadyExists);
            }

            var publisherExists = await _bookCatalogContext.Publishers
                .AnyAsync(publisher => publisher.Id == command.PublisherId, ct);

            if (!publisherExists)
            {
                return Result.Failure<int, ErrorResult>(
                    PublisherErrorResults.PublisherNotFound);
            }

            if (command.AuthorIds.Count == 0)
            {
                return Result.Failure<int, ErrorResult>(
                   BookErrorResults.NoAuthors);
            }

            var authorIds = await _bookCatalogContext.Authors
                .Where(author => command.AuthorIds.Contains(author.Id))
                .Select(author => author.Id)
                .ToListAsync(ct);

            var genreIds = await _bookCatalogContext.Genres
                .Where(genre => command.GenreIds.Contains(genre.Id))
                .Select(genre => genre.Id)
                .ToListAsync(ct);

            var newBook = new BookEntity(command.Title)
                .SetAuthors(authorIds)
                .SetGenres(genreIds)
                .SetPublisher(command.PublisherId)
                .SetPublicationInfo(new PublicationInfoValueObject(
                    isbn: command.Isbn,
                    year: command.PublicationYear,
                    city: command.PublicationCity,
                    language: command.PublicationLanguage))
                .SetFormatInfo(new FormatInfoValueObject(
                    pageCount: command.PageCount))
                .SetSummary(command.Summary);

            await _bookCatalogContext.Books
                .AddAsync(newBook, ct);

            var changes = await _bookCatalogContext.SaveChangesAsync(ct);

            if (changes == 0)
            {
                _logger.LogError("A book was not added");

                return Result.Failure<int, ErrorResult>(
                    BookErrorResults.BookNotAdded);
            }

            return newBook.Id;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected error occurred while adding a book to the catalog");
            throw;
        }

        throw new NotImplementedException();
    }
}
