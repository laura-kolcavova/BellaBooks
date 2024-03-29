﻿using BellaBooks.BookCatalog.Application.Errors;
using BellaBooks.BookCatalog.Application.Features.Publishers;
using BellaBooks.BookCatalog.Application.Features.Publishers.Commands;
using BellaBooks.BookCatalog.Domain.Entities.Publishers;
using BellaBooks.BookCatalog.Infrastructure.Contexts;
using CSharpFunctionalExtensions;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BellaBooks.BookCatalog.Infrastructure.Features.Publishers.CommandHandlers;

internal class AddPublisherCommandHandler : ICommandHandler<
    AddPublisherCommand, Result<int, ErrorResult>>
{
    private readonly BookCatalogContext _bookCatalogContext;
    private readonly ILogger<AddPublisherCommandHandler> _logger;

    public AddPublisherCommandHandler(
        BookCatalogContext bookCatalogContext,
        ILogger<AddPublisherCommandHandler> logger)
    {
        _bookCatalogContext = bookCatalogContext;
        _logger = logger;
    }

    public async Task<
        Result<int, ErrorResult>>
        ExecuteAsync(AddPublisherCommand command, CancellationToken ct)
    {
        using var loggerScope = _logger.BeginScope(new Dictionary<string, object>
        {
            ["Name"] = command.Name
        });

        try
        {
            var publisherWithNameAlreadyExists = await _bookCatalogContext.Publishers
                .AnyAsync(publisher => publisher.Name == command.Name, ct);

            if (publisherWithNameAlreadyExists)
            {
                return Result.Failure<int, ErrorResult>
                    (PublisherErrorResults.PublisherWithSameNameAlreadyExists);
            }

            var newPublisher = new PublisherEntity(command.Name);

            _bookCatalogContext.Publishers
                .Add(newPublisher);

            var changes = await _bookCatalogContext
                 .SaveChangesAsync(ct);

            if (changes == 0)
            {
                _logger.LogError("A publisher was not added");

                return Result.Failure<int, ErrorResult>
                    (PublisherErrorResults.PublisherNotAdded);
            }

            return newPublisher.Id;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected error occurred while adding a publisher");
            throw;
        }
    }
}
