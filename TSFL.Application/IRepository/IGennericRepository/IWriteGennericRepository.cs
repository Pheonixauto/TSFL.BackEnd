using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSFL.Domain.Entities.Common;

namespace TSFL.Application.IRepository.IGennericRepository
{
    public interface IWriteGennericRepository<T>: IGennericRepository<T> where T : BaseEntity
    {
        Task<bool> AddAsync(T model);
        Task<bool> AddRangeAsync(List<T> model);
        bool Remove(T model);
        bool RemoveRange(List<T> model);

        Task<bool> RemoveAsync(Guid id);
        bool Update(T model);

        Task<int> SaveAsync();
    }
}
