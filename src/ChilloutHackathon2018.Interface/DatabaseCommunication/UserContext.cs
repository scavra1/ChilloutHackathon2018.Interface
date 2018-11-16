namespace DatabaseCommunication
{
    using DatabaseCommunication.Queries;
    using InterfaceModels.User;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// User database context
    /// </summary>
    public class UserContext : DatabaseContext
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="connectionString"></param>
        public UserContext(string connectionString) : base(connectionString)
        {
        }

        /// <summary>
        /// Finds User by their name and password.
        /// </summary>
        /// <param name="userCredentials">User's credentials</param>
        /// <returns>User information</returns>
        public UserInfo FindUser(UserCredentials userCredentials)
        {
            var parameters = new Dictionary<string, object>();

            parameters.Add("Username", userCredentials.UserName);
            parameters.Add("Password", userCredentials.Password);

            return QueryFirstOrDefault<UserInfo>(UserQueries.FindUser, parameters);
        }
    }
}
