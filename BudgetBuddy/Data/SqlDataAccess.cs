using Dapper;
using MySqlConnector;
using System.Data;
using System.Data.SqlClient;

namespace BudgetBuddy.Data
{
    public class SqlDataAccess : ISqlDataAccess
    {
        private readonly IConfiguration config;

        public SqlDataAccess(IConfiguration config)
        {
            this.config = config;
        }
        public async Task<IEnumerable<T>> LoadData<T, U>(string sql, U parameters, string connectionId = "Default")
        {
            using IDbConnection connection = new MySqlConnection(config.GetConnectionString(connectionId));
            return await connection.QueryAsync<T>(sql, parameters);
        }

        public async Task SaveData<T>(string sql, T parameters, string connectionId = "Default")
        {
            using IDbConnection connection = new MySqlConnection(config.GetConnectionString(connectionId));
            await connection.ExecuteAsync(sql, parameters);
        }
    }
}
