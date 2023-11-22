using BellaBooks.BookCatalog.Domain.Constants;

namespace BellaBooks.BookCatalog.Application.Errors;

public static class GeneralErrorResults
{
    public static ErrorResult EntityNotFound => new(
        ErrorCodes.General.EntityNotFound,
        "Entity was not found.");

    public static ErrorResult EntityAlreadyExists => new(
        ErrorCodes.General.EntityAlreadyExists,
        "Entity already exists.");

    public static ErrorResult EntityInBadState => new(
        ErrorCodes.General.EntityInBadState,
        "Entity is in bad state.");

    public static ErrorResult EntityNotAdded => new(
        ErrorCodes.General.EntityNotAdded,
        "Entity was not added.");

    public static ErrorResult EntityNotDeleted => new(
        ErrorCodes.General.EntityNotDeleted,
        "Entity was not deleted.");

    public static ErrorResult EntityNotUpdated => new(
        ErrorCodes.General.EntityNotUpdated,
        "Entity was not updated.");

    public static ErrorResult NoChangesInDatabase => new(
        ErrorCodes.General.NoChangesInDatabase,
        "There were no changes in the database.");
}
