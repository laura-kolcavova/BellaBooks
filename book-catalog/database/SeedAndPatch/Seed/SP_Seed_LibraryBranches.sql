CREATE PROCEDURE [seed].[SP_Seed_LibraryBranches]
AS
BEGIN
    MERGE INTO [dbo].[LibraryBranches] AS Target
    USING (VALUES
         ('PB', N'Praha - pobočka'),
         ('BB', N'Brno - pobočka'),
         ('OB', N'Ostrava - pobočka')
    ) AS SOURCE (
        [Code],
        [Name]
    )
        ON (Target.[Code] = Source.[Code])
        WHEN MATCHED THEN
            UPDATE SET
                [Name] = Source.[Name]
        WHEN NOT MATCHED BY TARGET THEN
            INSERT (
                [Code],
                [Name]
            )
            VALUES (
                Source.[Code],
                Source.[Name]
            )
        WHEN NOT MATCHED BY SOURCE THEN DELETE;
END