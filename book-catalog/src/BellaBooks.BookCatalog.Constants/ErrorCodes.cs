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

    public static class LibraryBranches
    {
        public const string LibraryBranchNotFound = $"{nameof(LibraryBranches)}.{nameof(LibraryBranchNotFound)}";

        public const string LibraryBranchWithSameCodeAlreadyExists = $"{nameof(LibraryBranches)}.{nameof(LibraryBranchWithSameCodeAlreadyExists)}";

        public const string LibraryBranchNotAdded = $"{nameof(LibraryBranches)}.{nameof(LibraryBranchNotAdded)}";

        public const string LibraryBranchInfoNotUpdated = $"{nameof(LibraryBranches)}.{nameof(LibraryBranchInfoNotUpdated)}";

        public const string LibraryBranchNotRemoved = $"{nameof(LibraryBranches)}.{nameof(LibraryBranchNotRemoved)}";

        public const string LibraryBranchIsDisabled = $"{nameof(LibraryBranches)}.{nameof(LibraryBranchIsDisabled)}";

        public const string LibraryBranchActivatingFailed = $"{nameof(LibraryBranches)}.{nameof(LibraryBranchActivatingFailed)}";

        public const string LibraryBranchDisablingFailed = $"{nameof(LibraryBranches)}.{nameof(LibraryBranchDisablingFailed)}";
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
        public const string LibraryPrintNotFound = $"{nameof(LibraryPrints)}.{nameof(LibraryPrintNotFound)}";

        public const string LibraryPrintNotAdded = $"{nameof(LibraryPrints)}.{nameof(LibraryPrintNotAdded)}";

        public const string LibraryPrintNotRemoved = $"{nameof(LibraryPrints)}.{nameof(LibraryPrintNotRemoved)}";

        public const string LibraryPrintStateIsSameAsNewOne = $"{nameof(LibraryPrints)}.{nameof(LibraryPrintStateIsSameAsNewOne)}";

        public const string LibraryPrintStateNotChanged = $"{nameof(LibraryPrints)}.{nameof(LibraryPrintStateNotChanged)}";

        public const string LibraryPrintLocationIsSameAsNewOne = $"{nameof(LibraryPrints)}.{nameof(LibraryPrintLocationIsSameAsNewOne)}";

        public const string LibraryPrintLocationNotChanged = $"{nameof(LibraryPrints)}.{nameof(LibraryPrintLocationNotChanged)}";
    }
}
