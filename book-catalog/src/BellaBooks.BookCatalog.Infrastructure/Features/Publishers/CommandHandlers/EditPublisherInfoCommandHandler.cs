using BellaBooks.BookCatalog.Application.Errors;
using BellaBooks.BookCatalog.Application.Features.Publishers;
using BellaBooks.BookCatalog.Application.Features.Publishers.Commands;
using BellaBooks.BookCatalog.Infrastructure.Contexts;
using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BellaBooks.BookCatalog.Infrastructure.Features.Publishers.CommandHandlers;

internal class EditPublisherInfoCommandHandler : IRequestHandler<
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

    public async Task<UnitResult<ErrorResult>> Handle(EditPublisherInfoCommand request, CancellationToken cancellationToken)
    {
        using var loggerScope = _logger.BeginScope(new Dictionary<string, object>
        {
            ["PublisherId"] = request.PublisherId,
            ["Name"] = request.Name,
        });

        try
        {
            var publisherExists = await _bookCatalogContext.Publishers
                .AnyAsync(publisher => publisher.Id == request.PublisherId, cancellationToken);

            if (!publisherExists)
            {
                return UnitResult.Failure
                    (PublisherErrorResults.PublisherNotFound);
            }

            var changes = await _bookCatalogContext.Publishers
                .Where(publisher => publisher.Id == request.PublisherId)
                .ExecuteUpdateAsync(setters => setters.SetProperty(
                    publisher => publisher.Name, request.Name), cancellationToken);

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
