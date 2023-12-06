﻿using BellaBooks.BookCatalog.Application.Features.Books;
using BellaBooks.BookCatalog.Application.Features.Books.Queries;
using BellaBooks.BookCatalog.Domain.Constants.LibraryPrints;
using BellaBooks.BookCatalog.Infrastructure.Contexts;
using Dapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Data;

namespace BellaBooks.BookCatalog.Infrastructure.Features.Books.QueryHandlers;

internal class SimpleSearchBooksQueryHandler : IRequestHandler<
    SimpleSearchBooksQuery,
    IReadOnlyCollection<BookListingItemReadModel>>
{
    private readonly BookCatalogContext _bookCatalogContext;
    private readonly ILogger<SimpleSearchBooksQueryHandler> _logger;

    public SimpleSearchBooksQueryHandler(
        BookCatalogContext bookCatalogContext,
        ILogger<SimpleSearchBooksQueryHandler> logger)
    {
        _bookCatalogContext = bookCatalogContext;
        _logger = logger;
    }

    public async Task<IReadOnlyCollection<BookListingItemReadModel>> Handle(SimpleSearchBooksQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var dbConnection = _bookCatalogContext.Database.GetDbConnection();

            var sqlCommand = new CommandDefinition(
            @$"
            SELECT *
            FROM [dbo].[vBookListingItems]
            WHERE {BuildFilteringQuery(request.Filter, request.SearchInput)}
            OFFSET @Offset ROWS
            FETCH NEXT @Limit ROWS ONLY
            ",
            new
            {
                request.SearchInput,
                request.OffsetPaginationFilter.Offset,
                request.OffsetPaginationFilter.Limit,
            },
            commandType: CommandType.Text,
            cancellationToken: cancellationToken);

            var bookListingItems = await dbConnection
                .QueryAsync<BookListingItemReadModel, string, string, BookListingItemReadModel>(
                sqlCommand,
                (book, authorNames, libraryPrintStateCodes) =>
                {
                    book.AuthorsNames = authorNames
                        .Split(';')
                        .ToList();

                    book.LibraryPrintStateCodes = libraryPrintStateCodes
                        .Split(';')
                        .Select(stateCode => (LibraryPrintStateCode)Enum.Parse(typeof(LibraryPrintStateCode), stateCode))
                        .ToList();

                    return book;
                },

                splitOn: "AuthorNames,LibraryPrintStateCodes");


            return bookListingItems.ToList();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"An unexpected error occurred while trying to search (simple) for books");
            throw;
        }
    }

    private static string BuildFilteringQuery(SimpleSearchFilter filter, string? searchInput)
    {
        if (string.IsNullOrWhiteSpace(searchInput))
        {
            return string.Empty;
        }

        if (filter == SimpleSearchFilter.Title)
        {
            return "Title LIKE '%' + @SearchInput + '%'";
        }

        if (filter == SimpleSearchFilter.Isbn)
        {
            return "Isbn = @SearchInput";
        }

        if (filter == SimpleSearchFilter.Author)
        {
            return "AuthorNames LIKE '%' + @SearchInput + '%'";
        }

        return @"
        Title LIKE '%@SearchInput%' OR
        Isbn = @SearchInput OR
        AuthorNames LIKE '%' + @SearchInput + '%'";
    }
}
