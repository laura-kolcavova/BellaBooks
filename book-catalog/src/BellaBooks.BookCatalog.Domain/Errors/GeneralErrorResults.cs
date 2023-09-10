using BellaBooks.BookCatalog.Domain.Constants;

namespace BellaBooks.BookCatalog.Domain.Errors;

public static class GeneralErrorResults
{
    public static ErrorResult EntityNotFound { get; } = new(GeneralErrorCodes.EntityNotFound, "Entity was not found.");

    public static ErrorResult EntityAlreadyExists { get; } = new(GeneralErrorCodes.EntityAlreadyExists, "Entity already exists.");

    public static ErrorResult EntityInBadState { get; } = new(GeneralErrorCodes.EntityInBadState, "Entity is in bad state.");

    public static ErrorResult EntityNotAdded { get; } = new(GeneralErrorCodes.EntityNotAdded, "Entity was not added.");

    public static ErrorResult EntityNotDeleted { get; } = new(GeneralErrorCodes.EntityNotDeleted, "Entity was not deleted.");

    public static ErrorResult EntityNotUpdated { get; } = new(GeneralErrorCodes.EntityNotUpdated, "Entity was not updated.");

    public static ErrorResult NoChangesInDatabase { get; } = new(GeneralErrorCodes.NoChangesInDatabase, "There were no changes in the database.");
}
