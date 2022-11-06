using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WinWin.Persistence.IGenericRepositories
{
    public interface IGenericRepository<T> where T : class 
    {

        void Update(T entity);
        void Delete(T entity);
        void DeleteByExpression(Expression<Func<T, bool>> expression);
        void Commit();
    
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetByExpression(Expression<Func<T, bool>> expression);
        Task<T?> GetById(Guid id);
        Task Insert(T entity);
        Task InsertRange(IEnumerable<T> entities);
        Task CommitAsync();
    }
}
