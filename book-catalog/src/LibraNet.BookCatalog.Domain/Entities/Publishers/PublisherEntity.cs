using LibraNet.BookCatalog.Domain.Entities.Books;
using System.ComponentModel.DataAnnotations;

namespace LibraNet.BookCatalog.Domain.Entities.Publishers
{
    public class PublisherEntity : IEntity<int>, ITrackableEntity, IValidatableObject
    {
        public int Id { get; }

        public string Name { get; private set; } = string.Empty;

        public DateTimeOffset? CreatedAt { get; }

        public DateTimeOffset? UpdatedAt { get; }

        #region NavigationProperties

        public IReadOnlyCollection<BookEntity> Books { get; } = new List<BookEntity>();

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
