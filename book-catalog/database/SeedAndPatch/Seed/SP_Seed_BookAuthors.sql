CREATE PROCEDURE [seed].[SP_Seed_BookAuthors]
AS
BEGIN
    MERGE INTO [dbo].[BookAuthors] AS Target
    USING (VALUES
        (1, 1), -- Harper Lee - To Kill a Mockingbird
        (2, 2), -- George Orwell - 1984
        (3, 3), -- Gabriel García Márquez - One Hundred Years of Solitude
        (4, 4), -- Aldous Huxley - Brave New World
        (5, 5), -- J.D. Salinger - The Catcher in the Rye
        (2, 6), -- George Orwell - Animal Farm
        (6, 7), -- F. Scott Fitzgerald -  Great Gatsby
        (7, 8), -- Toni Morrison - Beloved
        (8, 9), -- Alice Walker - The Color Purple
        (9, 10), -- Kurt Vonnegut - Slaughterhouse-Five
        (10, 11), -- Stephen Hawking - A Brief History of Time
        (11, 12), -- Jane Austen - Pride and Prejudice
        (12, 13), -- Douglas Adams - The Hitchhiker''s Guide to the Galaxy
        (13, 14), -- J.R.R. Tolkien - The Hobbit
        (13, 15), -- J.R.R. Tolkien - The Lord of the Rings
        (14, 16), -- Anne Frank - The Diary of a Young Girl
        (15, 17), -- Khaled Hosseini - The Kite Runner
        (16, 18), -- Paulo Coelho - The Alchemist
        (17, 19), -- Suzanne Collins - The Hunger Games
        (18, 20) -- J.K. Rowling - Harry Potter and the Philosopher''s Stone
    ) AS SOURCE (
        [AuthorId],
        [BookId]
    )
        ON (Target.[AuthorId] = Source.[AuthorId] AND Target.[BookId] = Source.[BookId])
        WHEN NOT MATCHED BY TARGET THEN
            INSERT (
                [AuthorId],
                [BookId]
            )
            VALUES (
                Source.[AuthorId],
                Source.[BookId]
            )
        WHEN NOT MATCHED BY SOURCE THEN DELETE;
END