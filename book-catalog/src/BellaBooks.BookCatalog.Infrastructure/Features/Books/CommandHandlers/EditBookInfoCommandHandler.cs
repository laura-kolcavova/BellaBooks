using BellaBooks.BookCatalog.Application.Errors;
using BellaBooks.BookCatalog.Application.Features.Books;
using BellaBooks.BookCatalog.Application.Features.Books.Commands;
using BellaBooks.BookCatalog.Application.Features.Publishers;
using BellaBooks.BookCatalog.Domain.Entities.Books.ValueObjects;
using BellaBooks.BookCatalog.Infrastructure.Contexts;
using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BellaBooks.BookCatalog.Infrastructure.Features.Books.CommandHandlers;

internal class EditBookInfoCommandHandler : IRequestHandler<
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

    public async Task<UnitResult<ErrorResult>>
        Handle(EditBookInfoCommand request, CancellationToken cancellationToken)
    {
        using var loggerScope = _logger.BeginScope(new Dictionary<string, object>
        {
            ["BookId"] = request.BookId,
            ["Isbn"] = request.Isbn,
        });

        try
        {
            var book = await _bookCatalogContext.Books
                .Include(book => book.BookAuthors)
                .Include(book => book.BookGenres)
                .SingleOrDefaultAsync(book => book.Id == request.BookId, cancellationToken);

            if (book == null)
            {
                return UnitResult.Failure(
                    BookErrorResults.BookNotFound);
            }

            if (book.PublicationInfo.Isbn != request.Isbn)
            {
                var bookWithIsbnExists = await _bookCatalogContext.Books
                    .AnyAsync(book => book.PublicationInfo.Isbn == request.Isbn, cancellationToken);

                if (bookWithIsbnExists)
                {
                    return Result.Failure<int, ErrorResult>(
                        BookErrorResults.BookWithSameIsbnAlreadyExists);
                }
            }

            if (book.PublisherId != request.PublisherId)
            {
                var publisherExists = await _bookCatalogContext.Publishers
                    .AnyAsync(publisher => publisher.Id == request.PublisherId, cancellationToken);

                if (!publisherExists)
                {
                    return Result.Failure<int, ErrorResult>(
                        PublisherErrorResults.PublisherNotFound);
                }

                book.SetPublisher(request.PublisherId);
            }

            if (request.AuthorIds.Count == 0)
            {
                return Result.Failure<int, ErrorResult>(
                    BookErrorResults.NoAuthors);
            }

            var authorIds = await _bookCatalogContext.Authors
                .Where(author => request.AuthorIds.Contains(author.Id))
                .Select(author => author.Id)
                .ToListAsync(cancellationToken);

            var genreIds = await _bookCatalogContext.Genres
                .Where(genre => request.GenreIds.Contains(genre.Id))
                .Select(genre => genre.Id)
                .ToListAsync(cancellationToken);

            book
                .SetTitle(request.Title)
                .SetAuthors(authorIds)
                .SetGenres(genreIds)
                .SetPublicationInfo(new PublicationInfoValueObject(
                    isbn: request.Isbn,
                    year: request.PublicationYear,
                    city: request.PublicationCity,
                    language: request.PublicationLanguage))
                .SetFormatInfo(new FormatInfoValueObject(
                    pageCount: request.PageCount))
                .SetSummary(request.Summary);

            _bookCatalogContext.Books
                .Update(book);

            var changes = await _bookCatalogContext.SaveChangesAsync(cancellationToken);

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
