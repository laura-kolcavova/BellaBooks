namespace BellaBooks.BookCatalog.Api.Configuration;

internal class ConnectionStringAndPasswordSection
{
    public required string ConnectionString { get; set; }

    public required string Password { get; set; }
}
