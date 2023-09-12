using BellaBooks.BookCatalog.Domain.Constants;

namespace BellaBooks.BookCatalog.Domain.Errors;

public static class GeneralErrorResults
{
    public static ErrorResult EntityNotFound { get; } = new ErrorResult()
    {
        Code = ErrorCodes.General.EntityNotFound,
        Message = "Entity was not found."
    };

    public static ErrorResult EntityAlreadyExists { get; } = new ErrorResult()
    {
        Code = ErrorCodes.General.EntityAlreadyExists,
        Message = "Entity already exists."
    };

    public static ErrorResult EntityInBadState { get; } = new ErrorResult()
    {
        Code = ErrorCodes.General.EntityInBadState,
        Message = "Entity is in bad state."
    };

    public static ErrorResult EntityNotAdded { get; } = new ErrorResult()
    {
        Code = ErrorCodes.General.EntityNotAdded,
        Message = "Entity was not added."
    };

    public static ErrorResult EntityNotDeleted { get; } = new ErrorResult()
    {
        Code = ErrorCodes.General.EntityNotDeleted,
        Message = "Entity was not deleted."
    };

    public static ErrorResult EntityNotUpdated { get; } = new ErrorResult()
    {
        Code = ErrorCodes.General.EntityNotUpdated,
        Message = "Entity was not updated."
    };

    public static ErrorResult NoChangesInDatabase { get; } = new ErrorResult()
    {
        Code = ErrorCodes.General.NoChangesInDatabase,
        Message = "There were no changes in the database."
    };
}
