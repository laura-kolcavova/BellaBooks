CREATE PROCEDURE [seed].[SP_Seed_LibraryPrints]
AS
BEGIN
    SET IDENTITY_INSERT [dbo].[LibraryPrints] ON

    MERGE INTO [dbo].[LibraryPrints] AS Target
    USING (VALUES
         (1, 1, 'A123', 'BB', 'AV'),
         (2, 2, 'B456', 'PB', 'AV'),
         (3, 3, 'C789', 'BB', 'AV'),
         (4, 4, 'D012', 'OB', 'AV'),
         (5, 2, 'E345', 'PB', 'AV'),
         (6, 6, 'F678', 'BB', 'AV'),
         (7, 1, 'G901', 'OB', 'AV'),
         (8, 8, 'H234', 'PB', 'AV'),
         (9, 5, 'I567', 'BB', 'AV'),
         (10, 10, 'J890', 'OB', 'AV'),
         (11, 11, 'K123', 'PB', 'AV'),
         (12, 1, 'L456', 'BB', 'AV'),
         (13, 13, 'M789', 'OB', 'AV'),
         (14, 14, 'N012', 'PB', 'AV'),
         (15, 2, 'O345', 'BB', 'AV'),
         (16, 16, 'P678', 'OB', 'AV'),
         (17, 17, 'Q901', 'PB', 'AV'),
         (18, 18, 'R234', 'BB', 'AV'),
         (19, 11, 'S567', 'OB', 'AV'),
         (20, 20, 'T890', 'PB', 'AV'),
         (21, 7, 'U123', 'BB', 'AV'),
         (22, 2, 'V456', 'PB', 'AV'),
         (23, 3, 'W789', 'BB', 'AV'),
         (24, 4, 'X012', 'OB', 'AV'),
         (25, 2, 'Y345', 'PB', 'AV'),
         (26, 6, 'Z678', 'BB', 'AV'),
         (27, 1, 'AA901', 'OB', 'AV'),
         (28, 8, 'AB234', 'PB', 'AV'),
         (29, 5, 'AC567', 'BB', 'AV'),
         (30, 10, 'AD890', 'OB', 'AV'),
         (31, 11, 'AE123', 'PB', 'AV'),
         (32, 1, 'AF456', 'BB', 'AV'),
         (33, 13, 'AG789', 'OB', 'AV'),
         (34, 14, 'AH012', 'PB', 'AV'),
         (35, 2, 'AI345', 'BB', 'AV'),
         (36, 16, 'AJ678', 'OB', 'AV'),
         (37, 17, 'AK901', 'PB', 'AV'),
         (38, 18, 'AL234', 'BB', 'AV'),
         (39, 9, 'AM567', 'OB', 'AV'),
         (40, 20, 'AN890', 'PB', 'AV'),
         (41, 12, 'AO123', 'BB', 'AV'),
         (42, 15, 'AP456', 'PB', 'AV'),
         (43, 19, 'AQ789', 'BB', 'AV')
    ) AS SOURCE (
        [Id],
        [BookId],
        [Shelfmark],
        [LibraryBranchCode],
        [StateCode]
    )
        ON (Target.[Id] = Source.[Id])
        WHEN MATCHED THEN
            UPDATE SET
                [BookId] = Source.[BookId],
                [Shelfmark] = Source.[Shelfmark],
                [LibraryBranchCode] = Source.[LibraryBranchCode],
                [StateCode] = Source.[StateCode]
        WHEN NOT MATCHED BY TARGET THEN
            INSERT (
                [Id],
                [BookId],
                [Shelfmark],
                [LibraryBranchCode],
                [StateCode]
            )
            VALUES (
                Source.[Id],
                Source.[BookId],
                Source.[Shelfmark],
                Source.[LibraryBranchCode],
                Source.[StateCode]
            )
        WHEN NOT MATCHED BY SOURCE THEN DELETE;
END