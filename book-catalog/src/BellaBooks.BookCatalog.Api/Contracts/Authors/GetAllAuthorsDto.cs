namespace BellaBooks.BookCatalog.Api.Contracts.Authors;

public static class GetAllAuthorsDto
{
    public record Response
    {
        public required ICollection<AuthorDto> Authors { get; init; }
    }
}
