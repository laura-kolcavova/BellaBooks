CREATE PROCEDURE [seed].[SP_Seed_Publishers]
AS
BEGIN
    SET IDENTITY_INSERT [dbo].[Publishers] ON

    MERGE INTO [dbo].[Publishers] AS Target
    USING (VALUES
        (1, 'HarperCollins'),
        (2, 'Penguin Books'),
        (3, 'Editorial Sudamericana'),
        (4, 'Little, Brown and Company'),
        (5, 'Charles Scribner''s Sons'),
        (6, 'Alfred A. Knopf'),
        (7, 'Harcourt Brace Jovanovich'),
        (8, 'Delacorte Press'),
        (9, 'Bantam Books'),
        (10, 'Thomas Egerton'),
        (11, 'Pan Books'),
        (12, 'George Allen & Unwin'),
        (13, 'Contact Publishing'),
        (14, 'Riverhead Books'),
        (15, 'Editora Rocco'),
        (16, 'Scholastic Corporation'),
        (17, 'Bloomsbury Publishing')
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