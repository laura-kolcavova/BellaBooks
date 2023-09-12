namespace BellaBooks.BookCatalog.Domain.Constants;
public static class ErrorCodes
{
    public static class General
    {
        public const string EntityNotFound = $"{nameof(EntityNotFound)}";

        public const string EntityAlreadyExists = $"{nameof(EntityAlreadyExists)}";

        public const string EntityInBadState = $"{nameof(EntityInBadState)}";

        public const string EntityNotAdded = $"{nameof(EntityNotAdded)}";

        public const string EntityNotDeleted = $"{nameof(EntityNotDeleted)}";

        public const string EntityNotUpdated = $"{nameof(EntityNotUpdated)}";

        public const string NoChangesInDatabase = $"{nameof(NoChangesInDatabase)}";
    }

    public static class Books
    {
        public const string BookNotFound = $"{nameof(Books)}.{nameof(BookNotFound)}";

        public const string BookWithIsbnAlreadyExists = $"{nameof(Books)}.{nameof(BookWithIsbnAlreadyExists)}";

        public const string NoAuthors = $"{nameof(Books)}.{nameof(NoAuthors)}";

        public const string BookNotAdded = $"{nameof(Books)}.{nameof(BookNotAdded)}";

        public const string BookInfoNotUpdated = $"{nameof(Books)}.{nameof(BookInfoNotUpdated)}";

        public const string BookNotRemoved = $"{nameof(Books)}.{nameof(BookNotRemoved)}";
    }

    public static class Publishers
    {
        public const string PublisherNotFound = $"{nameof(Publishers)}.{nameof(PublisherNotFound)}";

        public const string PublisherWithSameNameAlreadyExists = $"{nameof(Publishers)}.{nameof(PublisherWithSameNameAlreadyExists)}";

        public const string PublisherNotAdded = $"{nameof(Publishers)}.{nameof(PublisherNotAdded)}";

        public const string PublisherInfoNotUpdated = $"{nameof(Publishers)}.{nameof(PublisherInfoNotUpdated)}";

        public const string PublisherNotRemoved = $"{nameof(Publishers)}.{nameof(PublisherNotRemoved)}";
    }

    public static class Authors
    {
        public const string AuthorNotFound = $"{nameof(Authors)}.{nameof(AuthorNotFound)}";

        public const string AuthorWithSameNameAlreadyExists = $"{nameof(Authors)}.{nameof(AuthorWithSameNameAlreadyExists)}";

        public const string AuthorNotAdded = $"{nameof(Authors)}.{nameof(AuthorNotAdded)}";

        public const string AuthorInfoNotUpdated = $"{nameof(Authors)}.{nameof(AuthorInfoNotUpdated)}";

        public const string AuthorNotRemoved = $"{nameof(Authors)}.{nameof(AuthorNotRemoved)}";
    }

    public static class Genres
    {
        public const string GenreNotFound = $"{nameof(Genres)}.{nameof(GenreNotFound)}";

        public const string GenreWithSameNameAlreadyExists = $"{nameof(Genres)}.{nameof(GenreWithSameNameAlreadyExists)}";

        public const string GenreNotAdded = $"{nameof(Genres)}.{nameof(GenreNotAdded)}";

        public const string GenreInfoNotUpdated = $"{nameof(Genres)}.{nameof(GenreInfoNotUpdated)}";

        public const string GenreNotRemoved = $"{nameof(Genres)}.{nameof(GenreNotRemoved)}";
    }

    public static class LibraryPrints
    {
        public const string LibaryPrintNotAdded = $"{nameof(LibraryPrints)}.{nameof(LibaryPrintNotAdded)}";
    }
}
