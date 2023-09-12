using BellaBooks.BookCatalog.Domain.Constants;
using BellaBooks.BookCatalog.Domain.Errors;

namespace BellaBooks.BookCatalog.Domain.Publishers;

public static class PublisherErrorResults
{
    public static ErrorResult PublisherNotFound =>
       new()
       {
           Code = ErrorCodes.Publishers.PublisherNotAdded,
           Message = "A publisher was not found."
       };

    public static ErrorResult PublisherWithSameNameAlreadyExists =>
        new()
        {
            Code = ErrorCodes.Publishers.PublisherWithSameNameAlreadyExists,
            Message = "A publisher with same name already exists."
        };

    public static ErrorResult PublisherNotAdded =>
       new()
       {
           Code = ErrorCodes.Publishers.PublisherNotAdded,
           Message = "A publisher was not added."
       };

    public static ErrorResult PublisherInfoNotUpdated =>
      new()
      {
          Code = ErrorCodes.Publishers.PublisherInfoNotUpdated,
          Message = "An information about publisher was not updated."
      };

    public static ErrorResult PublisherNotRemoved =>
      new()
      {
          Code = ErrorCodes.Publishers.PublisherNotRemoved,
          Message = "A publisher was not removed."
      };
}
