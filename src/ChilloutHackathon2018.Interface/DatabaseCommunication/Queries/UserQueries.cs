using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseCommunication.Queries
{
    public class UserQueries
    {
        public const string FindUser = @"
SELECT  [UserID]
        , [FirstName]
        , [LastName]
FROM [dbo].[Users]
WHERE [Login] = @Username
        AND [Password] = @Password";
    }
}
