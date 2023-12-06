using BellaBooks.BookCatalog.Application.Errors;
using BellaBooks.BookCatalog.Application.Features.Authors;
using BellaBooks.BookCatalog.Application.Features.Authors.Commands;
using BellaBooks.BookCatalog.Infrastructure.Contexts;
using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BellaBooks.BookCatalog.Infrastructure.Features.Authors.CommandHandlers;

internal class EditAuthorInfoCommandHandler : IRequestHandler<
    EditAuthorInfoCommand, UnitResult<ErrorResult>>
{
    private readonly BookCatalogContext _bookCatalogContext;
    private readonly ILogger<EditAuthorInfoCommandHandler> _logger;

    public EditAuthorInfoCommandHandler(
        BookCatalogContext bookCatalogContext,
        ILogger<EditAuthorInfoCommandHandler> logger)
    {
        _bookCatalogContext = bookCatalogContext;
        _logger = logger;
    }

    public async Task<UnitResult<ErrorResult>>
        Handle(EditAuthorInfoCommand request, CancellationToken cancellationToken)
    {
        using var loggerScope = _logger.BeginScope(new Dictionary<string, object>
        {
            ["AuthorId"] = request.AuthorId,
            ["Name"] = request.Name,
        });

        try
        {
            var authorExists = await _bookCatalogContext.Authors
            .AnyAsync(author => author.Id == request.AuthorId, cancellationToken);

            if (!authorExists)
            {
                return UnitResult.Failure
                    (AuthorErrorResults.AuthorNotFound);
            }

            var changes = await _bookCatalogContext.Authors
            .Where(author => author.Id == request.AuthorId)
                .ExecuteUpdateAsync(setters => setters.SetProperty(
                author => author.Name, request.Name), cancellationToken);

            if (changes == 0)
            {
                _logger.LogError("An information about author was not updated");

                return UnitResult.Failure
                    (AuthorErrorResults.AuthorInfoNotUpdated);
            }

            return UnitResult.Success<ErrorResult>();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected error occurred while editing an author info");
            throw;
        }
    }
}
