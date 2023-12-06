using BellaBooks.BookCatalog.Application.Errors;
using BellaBooks.BookCatalog.Application.Features.Authors;
using BellaBooks.BookCatalog.Application.Features.Authors.Commands;
using BellaBooks.BookCatalog.Domain.Entities.Authors;
using BellaBooks.BookCatalog.Infrastructure.Contexts;
using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BellaBooks.BookCatalog.Infrastructure.Features.Authors.CommandHandlers;

internal class AddAuthorCommandHandler : IRequestHandler<
    AddAuthorCommand, Result<int, ErrorResult>>
{
    private readonly BookCatalogContext _bookCatalogContext;
    private readonly ILogger<AddAuthorCommandHandler> _logger;

    public AddAuthorCommandHandler(
        BookCatalogContext bookCatalogContext,
        ILogger<AddAuthorCommandHandler> logger)
    {
        _bookCatalogContext = bookCatalogContext;
        _logger = logger;
    }

    public async Task<Result<int, ErrorResult>>
        Handle(AddAuthorCommand request, CancellationToken cancellationToken)
    {
        using var loggerScope = _logger.BeginScope(new Dictionary<string, object>
        {
            ["Name"] = request.Name
        });

        try
        {
            var authorWithNameAlreadyExists = await _bookCatalogContext.Authors
            .AnyAsync(author => author.Name == request.Name, cancellationToken);

            if (authorWithNameAlreadyExists)
            {
                return Result.Failure<int, ErrorResult>
                    (AuthorErrorResults.AuthorWithSameNameAlreadyExists);
            }
            var newAuthor = new AuthorEntity(request.Name);

            _bookCatalogContext.Authors
                .Add(newAuthor);

            var changes = await _bookCatalogContext
                 .SaveChangesAsync(cancellationToken);

            if (changes == 0)
            {
                _logger.LogError("An author was not added");

                return Result.Failure<int, ErrorResult>
                    (AuthorErrorResults.AuthorNotAdded);
            }

            return newAuthor.Id;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected error occurred while adding an author");
            throw;
        }
    }
}
