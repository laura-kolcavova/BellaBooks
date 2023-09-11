namespace BellaBooks.BookCatalog.Domain.Constants.Books;
public static class AddBookErrorCodes
{
    public const string BookWithIsbnAlreadyExists = "AddBook.BookWithIsbnAlreadyExists";

    public const string PublisherNotFound = "AddBook.PublisherNotFound";

    public const string NoAuthors = "AddBook.NoAuthors";

    public const string BookNotAdded = "AddBook.BookNotAdded";
}
