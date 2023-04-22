using System.ComponentModel.DataAnnotations;

namespace LibraNet.BookCatalog.Domain.Entities.Genres
{
    public class GenreEntity : IEntity<int>, ITrackableEntity, IValidatableObject
    {
        public int Id { get; }

        public string Name { get; private set; } = string.Empty;

        public DateTimeOffset? CreatedAt { get; }

        public DateTimeOffset? UpdatedAt { get; }

        #region NavigationProperties

        public IReadOnlyCollection<BookGenreEntity> BookGenres { get; } = new List<BookGenreEntity>();

        #endregion NavigationProperties

        public void Update(string name)
        {
            Name = name;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                yield return new ValidationResult($"{nameof(Name)} must not be empty.");
            }

            yield return ValidationResult.Success!;
        }
    }
}
