namespace DatabaseCommunication.Queries
{
    public class MarkerQueries
    {
        public const string GetMarkersByUserID = @"
SELECT [MarkerID]
       , [Picture]
       , [ModelID]
FROM [dbo].[Markers]
WHERE UserID = @UserID";

       
        public const string AddUserMarker = @"
INSERT INTO [dbo].[Markers]
OUTPUT [INSERTED].[MarkerID]
(
    [UserID],
    [Picture],
    [ModelID]
)
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
