using BellaBooks.BookCatalog.Bussiness.Authors.Commands;
using BellaBooks.BookCatalog.Domain.Authors;
using BellaBooks.BookCatalog.Domain.Errors;
using BellaBooks.BookCatalog.Infrastructure.Contexts;
using CSharpFunctionalExtensions;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BellaBooks.BookCatalog.Infrastructure.Authors.CommandHandlers;
internal class GetAuthorDetailCommandHandler : ICommandHandler<
    GetAuthorDetailCommand, Result<AuthorEntity, ErrorResult>>
{
    private readonly BookCatalogContext _bookCatalogContext;
    private readonly ILogger<GetAuthorDetailCommandHandler> _logger;

    public GetAuthorDetailCommandHandler(
        BookCatalogContext bookCatalogContext,
        ILogger<GetAuthorDetailCommandHandler> logger)
    {
        _bookCatalogContext = bookCatalogContext;
        _logger = logger;
    }

    public async Task<
        Result<AuthorEntity, ErrorResult>>
        ExecuteAsync(GetAuthorDetailCommand command, CancellationToken ct)
    {
        using var loggerScope = _logger.BeginScope(new Dictionary<string, object>
        {
            ["AuthorId"] = command.AuthorId
        });

        try
        {
            var author = await _bookCatalogContext.Authors
                .AsNoTracking()
                .SingleOrDefaultAsync(author => author.Id == command.AuthorId, ct);

            if (author == null)
            {
                return Result.Failure<AuthorEntity, ErrorResult>
                    (GeneralErrorResults.EntityNotFound);
            }

            return author;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected occurred while getting an author detail");
            throw;
        }
    }
}
