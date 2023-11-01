using BellaBooks.BookCatalog.Domain.Publishers.Commands;
using BellaBooks.BookCatalog.Domain.Errors;
using BellaBooks.BookCatalog.Domain.Publishers;
using BellaBooks.BookCatalog.Infrastructure.Contexts;
using CSharpFunctionalExtensions;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BellaBooks.BookCatalog.Infrastructure.Publishers.CommandHandlers;

internal class EditPublisherInfoCommandHandler : ICommandHandler<
    EditPublisherInfoCommand, UnitResult<ErrorResult>>
{
    private readonly BookCatalogContext _bookCatalogContext;
    private readonly ILogger<EditPublisherInfoCommandHandler> _logger;

    public EditPublisherInfoCommandHandler(
        BookCatalogContext bookCatalogContext,
        ILogger<EditPublisherInfoCommandHandler> logger)
    {
        _bookCatalogContext = bookCatalogContext;
        _logger = logger;
    }

    public async Task<
        UnitResult<ErrorResult>>
        ExecuteAsync(EditPublisherInfoCommand command, CancellationToken ct)
    {
        using var loggerScope = _logger.BeginScope(new Dictionary<string, object>
        {
            ["PublisherId"] = command.PublisherId,
            ["Name"] = command.Name,
        });

        try
        {
            var publisherExists = await _bookCatalogContext.Publishers
                .AnyAsync(publisher => publisher.Id == command.PublisherId, ct);

            if (!publisherExists)
            {
                return UnitResult.Failure
                    (PublisherErrorResults.PublisherNotFound);
            }

            var changes = await _bookCatalogContext.Publishers
                 .Where(publisher => publisher.Id == command.PublisherId)
                 .ExecuteUpdateAsync(setters => setters.SetProperty(
                     publisher => publisher.Name, command.Name), ct);

            if (changes == 0)
            {
                _logger.LogError("An information about publisher was not updated");

                return UnitResult.Failure
                    (PublisherErrorResults.PublisherInfoNotUpdated);
            }

            return UnitResult.Success<ErrorResult>();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected error occurred while editing a publisher info");
            throw;
        }
    }
}
