CREATE PROCEDURE [seed].[SP_Seed_Authors]
AS
BEGIN
    SET IDENTITY_INSERT [dbo].[Authors] ON

    MERGE INTO [dbo].[Authors] AS Target
    USING (VALUES
        (1, 'Harper Lee'),
        (2, 'George Orwell'),
        (3, 'Gabriel García Márquez'),
        (4, 'Aldous Huxley'),
        (5, 'J.D. Salinger'),
        (6, 'F. Scott Fitzgerald'),
        (7, 'Toni Morrison'),
        (8, 'Alice Walker'),
        (9, 'Kurt Vonnegut'),
        (10, 'Stephen Hawking'),
        (11, 'Jane Austen'),
        (12, 'Douglas Adams'),
        (13, 'J.R.R. Tolkien'),
        (14, 'Anne Frank'),
        (15, 'Khaled Hosseini'),
        (16, 'Paulo Coelho'),
        (17, 'Suzanne Collins'),
        (18, 'J.K. Rowling')
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