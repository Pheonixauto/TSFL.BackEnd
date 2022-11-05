using Dapper;
using System.Data;
using System.Threading.Tasks;

namespace WinWin.Persistence.IGenericDapperRepositories
{
    public interface IGenericDapperRepository
    {
        Task ExcuteNotReturn(string query, DynamicParameters parameters = null, IDbTransaction dbTransaction = null);
        Task<T> ExcuteReturn<T>(string query, DynamicParameters parameters = null, IDbTransaction dbTransaction = null);
        Task<IEnumerable<T>> ExcuteSqlReturnList<T>(string query, DynamicParameters parameters = null, IDbTransaction dbTransaction = null);
        Task<IEnumerable<T>> ExcuteStoreProduceReturnList<T>(string query, DynamicParameters parameters = null, IDbTransaction dbTransaction = null);
    }
}
