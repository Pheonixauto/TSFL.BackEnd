using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;
using WinWin.Persistence.DataBaseContext;
using WinWin.Persistence.IGenericRepositories;

namespace WinWin.Persistence.GenericRepositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly WinWinDBContext _winWinDBContext;

        public GenericRepository(WinWinDBContext winWinDBContext)
        {
            _winWinDBContext = winWinDBContext;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _winWinDBContext.Set<T>().ToListAsync();
        }



        public async Task<T?> GetById(Guid id)
        {
            return await _winWinDBContext.Set<T>().FindAsync(id);

        }

        public async Task<IEnumerable<T>> GetByExpression(Expression<Func<T, bool>> expression)
        {
            return await _winWinDBContext.Set<T>().Where(expression).ToListAsync();
        }
        public void Delete(T entity)
        {
            EntityEntry entityEntry = _winWinDBContext.Entry<T>(entity);
            entityEntry.State = EntityState.Deleted;
        }
        public void Delete(Guid id)
        {
            var entity = _winWinDBContext.Set<T>().Find(id);
            if (entity != null)
            {
                EntityEntry entityEntry = _winWinDBContext.Entry<T>(entity);
                entityEntry.State = EntityState.Deleted;
            }
        }

        public void DeleteByExpression(Expression<Func<T, bool>> expression)
        {
            var entities = _winWinDBContext.Set<T>().Where(expression).ToList();
            if (entities.Count > 0)
            {
                _winWinDBContext.Set<T>().RemoveRange(entities);
            }
        }

        public async Task Insert(T entity)
        {
            await _winWinDBContext.Set<T>().AddAsync(entity);
        }

        public async Task InsertRange(IEnumerable<T> entities)
        {
            await _winWinDBContext.Set<T>().AddRangeAsync(entities);

        }

        public void Update(T entity)
        {
            EntityEntry entityEntry = _winWinDBContext.Entry<T>(entity);
            entityEntry.State = EntityState.Modified;
        }
        public virtual IQueryable<T> Table => _winWinDBContext.Set<T>();
        public async Task CommitAsync()
        {
            await _winWinDBContext.SaveChangesAsync();
        }
        public void Commit()
        {
            _winWinDBContext.SaveChanges();
        }

        public IEnumerable<T> GetTest(string sql, SqlParameter[] parameters)
        {
            return _winWinDBContext.Set<T>().FromSqlRaw(sql,parameters).ToList();      
        }

        public async Task<IEnumerable<T>> GetAll1(string sql)
        {
            return await _winWinDBContext.Set<T>().FromSqlRaw(sql).ToListAsync();

        }
    }
}
