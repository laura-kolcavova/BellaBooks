using BellaBooks.BookCatalog.Domain.Constants;

namespace BellaBooks.BookCatalog.Domain.Errors;

public static class GeneralErrorResults
{
    //public static ErrorResult UnexpectedError { get; } = new(GeneralErrorCodes.UnexpectedError, "Unexpected error occured.");

    public static ErrorResult EntityNotFound { get; } = new(GeneralErrorCodes.EntityNotFound, "Entity wasn't found.");

    public static ErrorResult EntityAlreadyExists { get; } = new(GeneralErrorCodes.EntityAlreadyExists, "Entity already exists.");

    public static ErrorResult EntityInBadState { get; } = new(GeneralErrorCodes.EntityInBadState, "Entity is in bad state.");

    public static ErrorResult NoChangesInDatabase { get; } = new(GeneralErrorCodes.NoChangesInDatabase, "There were no changes in the database.");

    //public static ErrorResult DatabaseError { get; } = new(GeneralErrorCodes.DatabaseError, "Database error occured.");
}
