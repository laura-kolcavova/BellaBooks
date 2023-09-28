CREATE PROCEDURE [seed].[SP_Seed_Authors]
AS
BEGIN
    SET IDENTITY_INSERT [dbo].[Authors] ON

    MERGE INTO [dbo].[Authors] AS Target
    USING (VALUES
        (1, N'Harper Lee'),
        (2, N'George Orwell'),
        (3, N'Gabriel García Márquez'),
        (4, N'Aldous Huxley'),
        (5, N'J.D. Salinger'),
        (6, N'F. Scott Fitzgerald'),
        (7, N'Toni Morrison'),
        (8, N'Alice Walker'),
        (9, N'Kurt Vonnegut'),
        (10, N'Stephen Hawking'),
        (11, N'Jane Austen'),
        (12, N'Douglas Adams'),
        (13, N'J.R.R. Tolkien'),
        (14, N'Anne Frank'),
        (15, N'Khaled Hosseini'),
        (16, N'Paulo Coelho'),
        (17, N'Suzanne Collins'),
        (18, N'J.K. Rowling')
    ) AS SOURCE (
        [Id],
        [Name]
    )
        ON (Target.[Id] = Source.[Id])
        WHEN MATCHED THEN
            UPDATE SET
                [Name] = Source.[Name]
        WHEN NOT MATCHED BY TARGET THEN
            INSERT (
                [Id],
                [Name]
            )
            VALUES (
                Source.[Id],
                Source.[Name]
            )
        WHEN NOT MATCHED BY SOURCE THEN DELETE;
END