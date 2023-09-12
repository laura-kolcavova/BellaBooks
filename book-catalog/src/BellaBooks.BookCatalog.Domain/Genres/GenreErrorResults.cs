using BellaBooks.BookCatalog.Domain.Constants;
using BellaBooks.BookCatalog.Domain.Errors;

namespace BellaBooks.BookCatalog.Domain.Genres;

public static class GenreErrorResults
{
    public static ErrorResult GenreNotFound =>
       new()
       {
           Code = ErrorCodes.Genres.GenreNotAdded,
           Message = "A genre was not found."
       };

    public static ErrorResult GenreWithSameNameAlreadyExists =>
        new()
        {
            Code = ErrorCodes.Genres.GenreWithSameNameAlreadyExists,
            Message = "A genre with same name already exists."
        };

    public static ErrorResult GenreNotAdded =>
       new()
       {
           Code = ErrorCodes.Genres.GenreNotAdded,
           Message = "A genre was not added."
       };

    public static ErrorResult GenreInfoNotUpdated =>
      new()
      {
          Code = ErrorCodes.Genres.GenreInfoNotUpdated,
          Message = "An information about genre was not updated."
      };

    public static ErrorResult GenreNotRemoved =>
      new()
      {
          Code = ErrorCodes.Genres.GenreNotRemoved,
          Message = "A genre was not removed."
      };
}
