using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseCommunication.Queries
{
    public class WallQueries
    {
        public const string UpdateModel = @"
UPDATE dbo.WallModels
SET
    [Details] = @Details,
WHERE
    [UserID] = @UserID
    AND
    [MarkerID] = @MarkerID";

        public const string GetModelByUserId = @"
SELECT 
    Details
FROM dbo.WallModels";
    }
}
