using BellaBooks.BookCatalog.Domain.Constants;
using BellaBooks.BookCatalog.Domain.Errors;

namespace BellaBooks.BookCatalog.Domain.Books;

public static class BookErrorResults
{
    public static ErrorResult BookNotFound =>
       new()
       {
           Code = ErrorCodes.Books.BookNotFound,
           Message = $"A book was not found."
       };

    public static ErrorResult BookWithSameIsbnAlreadyExists =>
        new()
        {
            Code = ErrorCodes.Books.BookWithIsbnAlreadyExists,
            Message = $"A book with same ISBN already exists."
        };

    public static ErrorResult NoAuthors =>
        new()
        {
            Code = ErrorCodes.Books.NoAuthors,
            Message = "A book has no authors."
        };

    public static ErrorResult BookNotAdded =>
         new()
         {
             Code = ErrorCodes.Books.BookNotAdded,
             Message = "A book was not added."
         };

    public static ErrorResult BookInfoNotUpdated =>
      new()
      {
          Code = ErrorCodes.Books.BookInfoNotUpdated,
          Message = "An information about book was not updated."
      };

    public static ErrorResult BookNotRemoved =>
     new()
     {
         Code = ErrorCodes.Books.BookNotRemoved,
         Message = "A book was not removed."
     };
}
