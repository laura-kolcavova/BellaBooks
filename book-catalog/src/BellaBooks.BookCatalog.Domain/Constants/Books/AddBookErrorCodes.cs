namespace BellaBooks.BookCatalog.Domain.Constants.Books;
public static class AddBookErrorCodes
{
    public const string BookWithIsbnAlreadyExists = "AddBook.BookWithIsbnAlreadyExists";

    public const string PublisherNotFound = "AddBook.PublisherNotFound";

    public const string BookNotAdded = "AddBook.BookNotAdded";
}
