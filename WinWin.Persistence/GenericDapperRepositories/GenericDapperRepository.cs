using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using WinWin.Persistence.IGenericDapperRepositories;

namespace WinWin.Persistence.GenericDapperRepositories
{
    public class GenericDapperRepository : IGenericDapperRepository
    {
        private readonly string connectionString = string.Empty;
        public GenericDapperRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("WinWinConnectionString");
        }
        public async Task ExcuteNotReturn(string query, DynamicParameters parameters = null, IDbTransaction dbTransaction=null)
        {
            using (var dbConnection = new SqlConnection(connectionString))
            {
               await  dbConnection.ExecuteAsync(query, parameters,dbTransaction, commandType: CommandType.Text);
            }
            
        }

        public async Task<T> ExcuteReturn<T>(string query, DynamicParameters parameters = null, IDbTransaction dbTransaction = null)
        {
            using (var dbConnection = new SqlConnection(connectionString))
            {
               return (T)Convert.ChangeType( await dbConnection.ExecuteScalarAsync<T>(query, parameters, dbTransaction, commandType: CommandType.StoredProcedure), typeof(T));
            }
        }

        public async Task<IEnumerable<T>> ExcuteSqlReturnList<T>(string query, DynamicParameters parameters = null, IDbTransaction dbTransaction = null)
        {
            using (var dbConnection = new SqlConnection(connectionString))
            {
               return await dbConnection.QueryAsync<T>(query, parameters, dbTransaction, commandType: CommandType.Text);
            }
        }

        public async Task<IEnumerable<T>> ExcuteStoreProduceReturnList<T>(string query, DynamicParameters parameters = null, IDbTransaction dbTransaction = null)
        {
            using (var dbConnection = new SqlConnection(connectionString))
            {
                return await dbConnection.QueryAsync<T>(query, parameters, dbTransaction, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
