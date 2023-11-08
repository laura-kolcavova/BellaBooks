using BellaBooks.BookCatalog.Domain.Authors.Commands;
using BellaBooks.BookCatalog.Domain.Authors.ReadModels;
using BellaBooks.BookCatalog.Infrastructure.Contexts;
using BellaBooks.BookCatalog.Infrastructure.Extensions;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BellaBooks.BookCatalog.Infrastructure.Authors.CommandHandlers;

internal class GetAllAuthorsCommandHandler : ICommandHandler<
    GetAllAuthorsCommand, ICollection<AuthorDetailReadModel>>
{
    private readonly BookCatalogContext _bookCatalogContext;
    private readonly ILogger<GetAllAuthorsCommandHandler> _logger;

    public GetAllAuthorsCommandHandler(
        BookCatalogContext bookCatalogContext,
        ILogger<GetAllAuthorsCommandHandler> logger)
    {
        _bookCatalogContext = bookCatalogContext;
        _logger = logger;
    }

    public async Task<
        ICollection<AuthorDetailReadModel>>
        ExecuteAsync(GetAllAuthorsCommand command, CancellationToken ct)
    {
        try
        {
            var authors = await _bookCatalogContext.Authors
                .Select(author => AuthorDetailReadModelExtensions.FromEntity(author))
                .ToListAsync(ct);

            return authors;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected error occurred while getting all authors");
            throw;
        }
    }
}
