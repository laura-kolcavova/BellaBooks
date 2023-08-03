namespace BellaBooks.BookCatalog.Api.Configuration;

public class ConnectionStringAndPasswordSection
{
    public required string ConnectionString { get; set; }

    public required string Password { get; set; }
}
