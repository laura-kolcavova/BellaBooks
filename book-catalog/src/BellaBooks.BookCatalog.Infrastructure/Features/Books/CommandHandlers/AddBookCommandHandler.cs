using BellaBooks.BookCatalog.Application.Errors;
using BellaBooks.BookCatalog.Application.Features.Books;
using BellaBooks.BookCatalog.Application.Features.Books.Commands;
using BellaBooks.BookCatalog.Application.Features.Publishers;
using BellaBooks.BookCatalog.Domain.Entities.Books;
using BellaBooks.BookCatalog.Domain.Entities.Books.ValueObjects;
using BellaBooks.BookCatalog.Infrastructure.Contexts;
using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BellaBooks.BookCatalog.Infrastructure.Features.Books.CommandHandlers;

internal class AddBookCommandHandler : IRequestHandler<
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

    public async Task<Result<int, ErrorResult>>
        Handle(AddBookCommand request, CancellationToken cancellationToken)
    {
        using var loggerScope = _logger.BeginScope(new Dictionary<string, object>
        {
            ["Isbn"] = request.Isbn,
        });

        try
        {
            var bookWithIsbnExists = await _bookCatalogContext.Books
                .AnyAsync(book => book.PublicationInfo.Isbn == request.Isbn, cancellationToken);

            if (bookWithIsbnExists)
            {
                return Result.Failure<int, ErrorResult>(
                    BookErrorResults.BookWithSameIsbnAlreadyExists);
            }

            var publisherExists = await _bookCatalogContext.Publishers
                .AnyAsync(publisher => publisher.Id == request.PublisherId, cancellationToken);

            if (!publisherExists)
            {
                return Result.Failure<int, ErrorResult>(
                    PublisherErrorResults.PublisherNotFound);
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

            var newBook = new BookEntity(request.Title)
                .SetAuthors(authorIds)
                .SetGenres(genreIds)
                .SetPublisher(request.PublisherId)
                .SetPublicationInfo(new PublicationInfoValueObject(
                    isbn: request.Isbn,
                    year: request.PublicationYear,
                    city: request.PublicationCity,
                    language: request.PublicationLanguage))
                .SetFormatInfo(new FormatInfoValueObject(
                    pageCount: request.PageCount))
                .SetSummary(request.Summary);

            await _bookCatalogContext.Books
                .AddAsync(newBook, cancellationToken);

            var changes = await _bookCatalogContext.SaveChangesAsync(cancellationToken);

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
    }
}
