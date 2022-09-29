using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TSFL.Domain.Entities.Common;

namespace TSFL.Application.IRepository.IGennericRepository
{
    public interface IReadGennericRepository<T> : IGennericRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll(bool tracking=true);
        IQueryable<T> GetWhere(Expression<Func<T,bool>> expression, bool tracking = true);
        Task<T> GetSingleAsync(Expression<Func<T,bool>> expression, bool tracking = true);
        Task<T> GetByIdAsync(Guid id, bool tracking = true);
    }
}
