﻿using BellaBooks.BookCatalog.Api.Contracts.Authors;
using BellaBooks.BookCatalog.Api.Contracts.Genres;
using BellaBooks.BookCatalog.Api.Contracts.LibraryPrints;
using BellaBooks.BookCatalog.Api.Contracts.Publishers;
using BellaBooks.BookCatalog.Domain.Books;

namespace BellaBooks.BookCatalog.Api.Contracts.Books;

public record BookDetailDto
{
    public required int Id { get; init; }

    public required string Title { get; init; }

    public required string Isbn { get; init; }

    public required short PublicationYear { get; init; }

    public required string PublicationCity { get; init; }

    public required string PublicationLanguage { get; init; }

    public required short? PageCount { get; init; }

    public required string? Summary { get; init; }

    public required PublisherDetailDto? Publisher { get; init; }

    public required IReadOnlyCollection<AuthorDetailDto> Authors { get; init; }

    public required IReadOnlyCollection<GenreDetailDto> Genres { get; init; }

    public required IReadOnlyCollection<LibraryPrintDetailDto> LibraryPrints { get; init; }

    public static BookDetailDto FromEntity(BookEntity book)
    {
        return new BookDetailDto
        {
            Id = book.Id,
            Title = book.Title,
            Isbn = book.PublicationInfo.Isbn,
            PublicationYear = book.PublicationInfo.Year,
            PublicationLanguage = book.PublicationInfo.Language,
            PublicationCity = book.PublicationInfo.City,
            PageCount = book.FormatInfo.PageCount,
            Publisher = book.Publisher != null
             ? PublisherDetailDto.FromEntity(book.Publisher)
             : null,
            Summary = book.Summary,
            Authors = book.BookAuthors
                .Select(ab => AuthorDetailDto.FromEntity(ab.Author))
                .ToList(),
            Genres = book.BookGenres
                .Select(bg => GenreDetailDto.FromEntity(bg.Genre))
                .ToList(),
            LibraryPrints = book.LibraryPrints
                .Select(LibraryPrintDetailDto.FromEntity)
                .ToList()
        };
    }
}