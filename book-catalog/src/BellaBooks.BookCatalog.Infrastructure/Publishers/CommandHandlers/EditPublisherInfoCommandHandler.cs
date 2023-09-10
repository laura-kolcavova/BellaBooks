using BellaBooks.BookCatalog.Bussiness.Publishers.Commands;
using BellaBooks.BookCatalog.Domain.Errors;
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
    private ILogger<EditPublisherInfoCommandHandler> _logger;

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
                    (GeneralErrorResults.EntityNotFound);
            }

            await _bookCatalogContext.Publishers
               .ExecuteUpdateAsync(setters => setters.SetProperty(
                   publisher => publisher.Name, command.Name), ct);

            return UnitResult.Success<ErrorResult>();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected error occurred while editing a publisher info");
            throw;
        }
    }
}
