using BellaBooks.BookCatalog.Domain.Authors;

namespace BellaBooks.BookCatalog.Api.Contracts.Authors;

public record AuthorDto
{
    public required int Id { get; init; }

    public required string Name { get; init; }

    public static AuthorDto FromEntity(AuthorEntity entity)
    {
        return new AuthorDto
        {
            Id = entity.Id,
            Name = entity.Name,
        };
    }
}
