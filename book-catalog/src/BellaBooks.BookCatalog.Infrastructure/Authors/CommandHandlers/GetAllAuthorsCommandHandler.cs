using BellaBooks.BookCatalog.Domain.Authors.Commands;
using BellaBooks.BookCatalog.Domain.Authors;
using BellaBooks.BookCatalog.Infrastructure.Contexts;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BellaBooks.BookCatalog.Infrastructure.Authors.CommandHandlers;

internal class GetAllAuthorsCommandHandler : ICommandHandler<
    GetAllAuthorsCommand, ICollection<AuthorEntity>>
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
        ICollection<AuthorEntity>>
        ExecuteAsync(GetAllAuthorsCommand command, CancellationToken ct)
    {
        try
        {
            var authors = await _bookCatalogContext.Authors
                .AsNoTracking()
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
