﻿namespace BellaBooks.BookCatalog.Api.Contracts.Books;

public static class EditBookInfoContracts
{
    public record RequestDto
    {
        public required int BookId { get; init; }

        public required string Title { get; init; }

        public required IReadOnlyCollection<int> AuthorIds { get; init; }

        public required IReadOnlyCollection<int> GenreIds { get; init; }

        public required int PublisherId { get; init; }

        public required string Isbn { get; init; }

        public required short PublicationYear { get; init; }

        public required string PublicationCity { get; init; }

        public required string PublicationLanguage { get; init; }

        public required short? PageCount { get; init; }

        public required string? Summary { get; init; }
    }
}
