namespace DatabaseCommunication
{
    using Dapper;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Threading.Tasks;

    public class DatabaseContext
    {
        public DatabaseContext(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public List<T> Query<T>(string sqlCommand, Dictionary<string, object> parameters)
        {
            var dynamicParameters = new DynamicParameters();

            foreach (var param in parameters)
            {
                dynamicParameters.Add(param.Key, param.Value);
            }

            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                return sqlConnection.Query<T>(sqlCommand, dynamicParameters).AsList();
            }
        }

        public T QuerySingle<T>(string sqlCommand, Dictionary<string, object> parameters)
        {
            var dynamicParameters = new DynamicParameters();
            foreach (var param in parameters)
            {
                dynamicParameters.Add(param.Key, param.Value);
            }

            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                return sqlConnection.QuerySingle<T>(sqlCommand, dynamicParameters);
            }
        }
        public T QueryFirstOrDefault<T>(string sqlCommand, Dictionary<string, object> parameters)
        {
            var dynamicParameters = new DynamicParameters();
            foreach (var param in parameters)
            {
                dynamicParameters.Add(param.Key, param.Value);
            }

            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                return sqlConnection.QueryFirstOrDefault<T>(sqlCommand, dynamicParameters);
            }
        }

        public async Task<T> QueryFirstOrDefaultAsync<T>(string sqlCommand, Dictionary<string, object> parameters)
        {
            var dynamicParameters = new DynamicParameters();
            foreach (var param in parameters)
            {
                dynamicParameters.Add(param.Key, param.Value);
            }

            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                return await sqlConnection.QueryFirstOrDefaultAsync<T>(sqlCommand, dynamicParameters);
            }
        }

        protected string ConnectionString { get; set; }
    }
}