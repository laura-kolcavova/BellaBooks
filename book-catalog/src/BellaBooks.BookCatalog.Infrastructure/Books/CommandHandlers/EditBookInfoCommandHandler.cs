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
                .Include(book => book.BookAuthors)
                .Include(book => book.BookGenres)
                .SingleOrDefaultAsync(book => book.Id == command.BookId, ct);

            if (book == null)
            {
                return UnitResult.Failure(
                    BookErrorResults.BookNotFound);
            }

            if (book.PublicationInfo.Isbn != command.Isbn)
            {
                var bookWithIsbnExists = await _bookCatalogContext.Books
                    .AnyAsync(book => book.PublicationInfo.Isbn == command.Isbn, ct);

                if (bookWithIsbnExists)
                {
                    return Result.Failure<int, ErrorResult>(
                        BookErrorResults.BookWithSameIsbnAlreadyExists);
                }
            }

            if (book.PublisherId != command.PublisherId)
            {
                var publisherExists = await _bookCatalogContext.Publishers
                    .AnyAsync(publisher => publisher.Id == command.PublisherId, ct);

                if (!publisherExists)
                {
                    return Result.Failure<int, ErrorResult>(
                        PublisherErrorResults.PublisherNotFound);
                }

                book.SetPublisher(command.PublisherId);
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

            book
                .SetTitle(command.Title)
                .SetAuthors(authorIds)
                .SetGenres(genreIds)
                .SetPublicationInfo(new PublicationInfoValueObject(
                    isbn: command.Isbn,
                    year: command.PublicationYear,
                    city: command.PublicationCity,
                    language: command.PublicationLanguage))
                .SetFormatInfo(new FormatInfoValueObject(
                    pageCount: command.PageCount))
                .SetSummary(command.Summary);

            _bookCatalogContext.Books
                .Update(book);

            var changes = await _bookCatalogContext.SaveChangesAsync(ct);

            if (changes == 0)
            {
                _logger.LogError("An information about book was not edited");

                return Result.Failure<int, ErrorResult>(
                    BookErrorResults.BookInfoNotUpdated);
            }

            return UnitResult.Success<ErrorResult>();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected error occurred while updating a book info");
            throw;
        }
    }
}
