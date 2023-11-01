namespace BellaBooks.BookCatalog.Infrastructure.Authentication;

public class JwtBearerConfiguration
{
    public string Secret { get; set; } = string.Empty;

    public TimeSpan TokenLifetime { get; set; }
}
