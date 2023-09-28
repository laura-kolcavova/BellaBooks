using BellaBooks.BookCatalog.Domain.Authors;

namespace BellaBooks.BookCatalog.Api.Contracts.Authors;

public record AuthorDetailDto
{
    public required int Id { get; init; }

    public required string Name { get; init; }

    public static AuthorDetailDto FromEntity(AuthorEntity entity)
    {
        return new AuthorDetailDto
        {
            Id = entity.Id,
            Name = entity.Name,
        };
    }
}
