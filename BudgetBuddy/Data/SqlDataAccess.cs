using Dapper;
using MySqlConnector;
using System.Data;
using System.Data.SqlClient;

namespace BudgetBuddy.Data
{
    public class SqlDataAccess : ISqlDataAccess
    {
        private readonly IConfiguration config;
        private readonly MySqlConnection connection;

        public SqlDataAccess(MySqlConnection connection, IConfiguration config)
        {
            this.connection = connection; 
            this.config = config;
        }
        public async Task<IEnumerable<T>> LoadData<T, U>(string sql, U parameters)
        {
            return await connection.QueryAsync<T>(sql, parameters);
        }

        public async Task SaveData<T>(string sql, T parameters)
        {
            await connection.ExecuteAsync(sql, parameters);
        }
    }
}
