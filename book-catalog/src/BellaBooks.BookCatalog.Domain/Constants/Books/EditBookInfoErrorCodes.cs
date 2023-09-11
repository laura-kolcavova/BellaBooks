namespace BellaBooks.BookCatalog.Domain.Constants.Books;

public static class EditBookInfoErrorCodes
{
    public const string BookNotFound = "EditBookInfo.BookNotFound";

    public const string BookWithIsbnAlreadyExists = "EditBookInfo.BookWithIsbnAlreadyExists";

    public const string PublisherNotFound = "EditBookInfo.PublisherNotFound";

    public const string NoAuthors = "EditBookInfo.NoAuthors";

    public const string BookNotUpdated = "EditBookInfo.BookNotUpdated";
}
