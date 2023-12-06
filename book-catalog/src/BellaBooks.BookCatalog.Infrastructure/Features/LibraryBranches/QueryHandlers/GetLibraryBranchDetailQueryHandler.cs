using BellaBooks.BookCatalog.Application.Features.LibraryBranches.Queries;
using BellaBooks.BookCatalog.Infrastructure.Contexts;
using BellaBooks.BookCatalog.Infrastructure.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BellaBooks.BookCatalog.Infrastructure.Features.LibraryBranches.QueryHandlers;
internal class GetLibraryBranchDetailQueryHandler : IRequestHandler<
    GetLibraryBranchDetailQuery, LibraryBranchDetailReadModel?>
{
    private readonly BookCatalogContext _bookCatalogContext;
    private readonly ILogger<GetLibraryBranchDetailQueryHandler> _logger;

    public GetLibraryBranchDetailQueryHandler(
        BookCatalogContext bookCatalogContext,
        ILogger<GetLibraryBranchDetailQueryHandler> logger)
    {
        _bookCatalogContext = bookCatalogContext;
        _logger = logger;
    }

    public async Task<LibraryBranchDetailReadModel?> Handle(GetLibraryBranchDetailQuery request, CancellationToken cancellationToken)
    {
        using var loggerScope = _logger.BeginScope(new Dictionary<string, object>
        {
            ["LibaryBranchCode"] = request.LibraryBranchCode
        });

        try
        {
            var libraryBranch = await _bookCatalogContext.LibraryBranches
                .Where(libraryBranch => libraryBranch.Code == request.LibraryBranchCode)
                .SelectLibraryBranchDetailReadModel()
                .SingleOrDefaultAsync(cancellationToken);

            return libraryBranch;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected occurred while getting a library branch detail");
            throw;
        }
    }
}
