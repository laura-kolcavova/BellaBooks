using BellaBooks.BookCatalog.Domain.Books.ReadModels;
using BellaBooks.BookCatalog.Domain.Constants.LibraryPrints;

namespace BellaBooks.BookCatalog.Api.Contracts.Books;

public record BookListingItemDto
{
    public required int Id { get; init; }

    public required string Title { get; init; }

    public required short PublicationYear { get; init; }

    public required string PublicationCity { get; init; }

    public required string PublicationLanguage { get; init; }

    public required PublisherInfoDto Publisher { get; init; }

    public required IReadOnlyCollection<AuthorInfoDto> Authors { get; init; }

    public required LibraryPrintsInfoDto LibraryPrintsInfo { get; init; }

    public class PublisherInfoDto
    {
        public required string Name { get; init; }

        public static PublisherInfoDto FromEntity(BookListingItemReadModel.PublisherInfoReadModel publisherInfo)
        {
            return new PublisherInfoDto
            {
                Name = publisherInfo.Name,
            };
        }
    }

    public class AuthorInfoDto
    {
        public required string Name { get; init; }

        public static AuthorInfoDto FromEntity(BookListingItemReadModel.AuthorInfoReadModel authorInfo)
        {
            return new AuthorInfoDto
            {
                Name = authorInfo.Name,
            };
        }
    }

    public class LibraryPrintsInfoDto
    {
        public required int Count { get; init; }

        public required IReadOnlyDictionary<LibraryPrintStateCode, int> CountPerLibraryPrintStateCodes { get; init; }

        public static LibraryPrintsInfoDto FromEntity(BookListingItemReadModel.LibraryPrintsInfoReadModel libraryPrintsInfo)
        {
            return new LibraryPrintsInfoDto
            {
                Count = libraryPrintsInfo.Count,
                CountPerLibraryPrintStateCodes = libraryPrintsInfo
                    .CountPerLibraryPrintStateCodes
                    .ToDictionary(
                        keySelector => keySelector.Key,
                        valueSelector => valueSelector.Value)
            };
        }
    }

    public static BookListingItemDto FromEntity(BookListingItemReadModel book)
    {
        return new BookListingItemDto
        {
            Id = book.Id,
            Title = book.Title,
            PublicationYear = book.PublicaitonYear,
            PublicationLanguage = book.PublicationLanguage,
            PublicationCity = book.PublicationCity,
            Publisher = PublisherInfoDto
                .FromEntity(book.Publisher),
            Authors = book.Authors
                .Select(AuthorInfoDto.FromEntity)
                .ToList(),
            LibraryPrintsInfo = LibraryPrintsInfoDto.FromEntity(book.LibraryPrintsInfo),
        };
    }
}