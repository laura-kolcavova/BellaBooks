using BellaBooks.BookCatalog.Domain.Constants;
using BellaBooks.BookCatalog.Domain.Errors;

namespace BellaBooks.BookCatalog.Domain.Authors;

public static class AuthorErrorResults
{
    public static ErrorResult AuthorNotFound =>
       new()
       {
           Code = ErrorCodes.Authors.AuthorNotAdded,
           Message = "An author was not found."
       };

    public static ErrorResult AuthorWithSameNameAlreadyExists =>
        new()
        {
            Code = ErrorCodes.Authors.AuthorWithSameNameAlreadyExists,
            Message = "An author with same name already exists."
        };

    public static ErrorResult AuthorNotAdded =>
       new()
       {
           Code = ErrorCodes.Authors.AuthorNotAdded,
           Message = "An author was not added."
       };

    public static ErrorResult AuthorInfoNotUpdated =>
      new()
      {
          Code = ErrorCodes.Authors.AuthorInfoNotUpdated,
          Message = "An information about author was not updated."
      };

    public static ErrorResult AuthorNotRemoved =>
      new()
      {
          Code = ErrorCodes.Authors.AuthorNotRemoved,
          Message = "An author was not removed."
      };
}
