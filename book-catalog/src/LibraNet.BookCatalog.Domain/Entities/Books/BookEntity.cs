using LibraNet.BookCatalog.Domain.Entities.Publishers;
using System.ComponentModel.DataAnnotations;

namespace LibraNet.BookCatalog.Domain.Entities.Books
{
    public class BookEntity : IEntity<int>, ITrackableEntity, IValidatableObject
    {
        public int Id { get; }

        public string Title { get; private set; } = string.Empty;

        public string ISBN { get; private set; } = string.Empty;

        public int PublisherId { get; private set; }

        public int PublicationYear { get; private set; }

        public string? PublicationPlace { get; private set; }

        public string? PublicationLanguage { get; private set; }

        public int? Pages { get; private set; }

        public DateTimeOffset? CreatedAt { get; }

        public DateTimeOffset? UpdatedAt { get; }

        #region NavigationProperties

        public IReadOnlyCollection<AuthorBookEntity> AuthorBooks { get; } = new List<AuthorBookEntity>();

        public IReadOnlyCollection<BookGenreEntity> BookGenres { get; } = new List<BookGenreEntity>();

        public PublisherEntity Publisher { get; private set; } = null!;

        #endregion NavigationProperties

        public void Update(
            string title,
            string isbn,
            int publisherId,
            int publicationYear,
            string? publicationPlace,
            string? publicationLanguage,
            int? pages)
        {
            Title = title;
            ISBN = isbn; // TODO Validate ISBN
            PublisherId = publisherId;
            PublicationYear = publicationYear;
            PublicationPlace = publicationPlace;
            PublicationLanguage = publicationLanguage;
            Pages = pages;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(Title))
            {
                yield return new ValidationResult($"{nameof(Title)} must not be empty.");
            }

            yield return ValidationResult.Success!;
        }
    }
}