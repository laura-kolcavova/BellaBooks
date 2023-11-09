CREATE VIEW [dbo].[vBookListingItems]
AS
SELECT
     B.[Id]
    ,B.[Title]
    ,B.[Isbn]
    ,B.[PublisherId]
    ,B.[PublicationYear]
    ,B.[PublicationLanguage]
    ,B.[PublicationCity]
    ,B.[PageCount]
    ,B.[Summary]
    ,P.[Name] AS PublisherName
    ,(SELECT STUFF(
        (
            SELECT ';' + A.[Name]
            FROM [dbo].[Authors] A
            INNER JOIN [dbo].[BookAuthors] BA ON BA.[BookId] = B.[Id]
            WHERE A.[Id] = BA.[AuthorId]
            FOR XML PATH('')
        ), 1, 1, '')) AS AuthorNames
    ,(SELECT STUFF(
        (
            SELECT ';' + LP.[StateCode]
            FROM [dbo].[LibraryPrints] LP
            WHERE LP.[BookId] = B.[Id]
            FOR XML PATH('')
        ), 1, 1, '')) AS LibraryPrintStateCodes
FROM [dbo].[Books] B
INNER JOIN [dbo].[Publishers] P ON P.[Id] = B.[PublisherId]