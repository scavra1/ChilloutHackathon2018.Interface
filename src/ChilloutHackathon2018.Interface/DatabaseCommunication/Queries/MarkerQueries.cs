namespace DatabaseCommunication.Queries
{
    public class MarkerQueries
    {
        public const string GetMarkersByUserID = @"
SELECT [MarkerID]
       , [Picture]
       , [ModelID]
       , [UserID]
FROM [dbo].[Markers]
WHERE UserID = @UserID";

       
        public const string AddUserMarker = @"
INSERT INTO [dbo].[Markers]
(
    [UserID],
    [Picture],
    [ModelID]
)
OUTPUT [INSERTED].[MarkerID]
VALUES (@UserID, @Picture, @ModelID)";

        public const string UpdateMarkerModelReference = @"
UPDATE [dbo].[Markers]
SET
    [ModelID] = @ModelID
WHERE [MarkerID] = @MarkerID";

        public const string UpdateMarkerImage = @"
UPDATE [dbo].[Markers]
SET
    [Picture] = @Picture
WHERE [MarkerID] = @MarkerID";

        public const string DeleteMarker = @"
DELETE FROM [dbo].[Markers]
WHERE [MarkerID] = @MarkerID";
    }
}
